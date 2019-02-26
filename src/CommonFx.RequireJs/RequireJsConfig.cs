﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonFx.RequireJs
{
    public class RequireJsConfig
    {
        public RequireJsConfig()
        {
            RequireJsConfigEntries = new Dictionary<string, RequireJsConfigEntry>(StringComparer.OrdinalIgnoreCase);
        }

        public Dictionary<string, RequireJsConfigEntry> RequireJsConfigEntries { get; set; }

        public RequireJsConfig AddOrReplace(string uniqueName, string virutalPath, string desc = null)
        {
            if (!RequireJsConfigEntries.ContainsKey(uniqueName))
            {
                //add
                RequireJsConfigEntries[uniqueName] = new RequireJsConfigEntry() { UniqueName = uniqueName, VirtualPath = virutalPath, Desc = desc };
                return this;
            }

            //update
            var requireJsConfigEntry = RequireJsConfigEntries[uniqueName];
            requireJsConfigEntry.UniqueName = uniqueName;
            requireJsConfigEntry.VirtualPath = virutalPath;
            requireJsConfigEntry.Desc = desc;
            return this;
        }

        private string _joinJsConfigVirtualPath = "~/Content/Scripts/app_config_join.js";
        public string JoinJsConfigVirtualPath
        {
            get { return _joinJsConfigVirtualPath; }
            set { _joinJsConfigVirtualPath = value; }
        }

        private string _joinJsFilesAsContentCache = null;
        public void JoinJsConfigInit(bool hardRefresh = false)
        {
            var savePath = FileServer.MapPath(JoinJsConfigVirtualPath);
            var fileExists = FileServer.Exists(savePath);
            if (hardRefresh || !fileExists)
            {
                _joinJsFilesAsContentCache = null;
            }
            
            if (_joinJsFilesAsContentCache != null)
            {
                return;
            }
            
            if (RequireJsConfigEntries.Count == 0)
            {
                _joinJsFilesAsContentCache = string.Empty;
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var requireJsConfigEntry in RequireJsConfigEntries.Values)
                {
                    sb.AppendLine(string.Format("//config for {0}", requireJsConfigEntry.UniqueName));
                    var filePath = FileServer.MapPath(requireJsConfigEntry.VirtualPath);
                    var jsConfig = FileServer.ReadAllText(filePath);
                    sb.AppendLine(jsConfig.TrimEnd());
                    sb.AppendLine("");
                }
                _joinJsFilesAsContentCache = sb.ToString();
            }
            
            if (fileExists)
            {
                var oldValue = FileServer.ReadAllText(savePath);
                var newHash = HashHelper.HashString(_joinJsFilesAsContentCache);
                var oldHash = HashHelper.HashString(oldValue);
                if (newHash == oldHash)
                {
                    return;
                }
            }
            //save hash value
            FileServer.WriteAllText(savePath, _joinJsFilesAsContentCache);
        }

        private IFileServer _fileServer;
        public IFileServer FileServer
        {
            get { return _fileServer ?? (_fileServer = CommonFx.FileServer.Resolve()); }
            set { _fileServer = value; }
        }

        private IHashHelper _hashHelper;
        public IHashHelper HashHelper
        {
            get { return _hashHelper ?? (_hashHelper = CommonFx.HashHelper.Resolve()); }
            set { _hashHelper = value; }
        }


        public static RequireJsConfig Instance = new RequireJsConfig();
    }

    public class RequireJsConfigEntry
    {
        public string UniqueName { get; set; }
        public string VirtualPath { get; set; }
        public string Desc { get; set; }
    }
}
