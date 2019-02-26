using System;
using System.Collections.Generic;
using System.Text;

namespace CommonFx.Web.JoinConfigs
{
    public class JoinJsConfig
    {
        public JoinJsConfig()
        {
            Entries = new Dictionary<string, JoinJsConfigEntry>(StringComparer.OrdinalIgnoreCase);
        }

        public JoinJsConfig(string joinPath): this()
        {
            JoinJsConfigVirtualPath = joinPath;
        }

        public Dictionary<string, JoinJsConfigEntry> Entries { get; set; }

        public JoinJsConfig AddOrReplace(string uniqueName, string virutalPath, string desc = null)
        {
            if (!Entries.ContainsKey(uniqueName))
            {
                //add
                Entries[uniqueName] = new JoinJsConfigEntry() { UniqueName = uniqueName, VirtualPath = virutalPath, Desc = desc };
                return this;
            }

            //update
            var requireJsConfigEntry = Entries[uniqueName];
            requireJsConfigEntry.UniqueName = uniqueName;
            requireJsConfigEntry.VirtualPath = virutalPath;
            requireJsConfigEntry.Desc = desc;
            return this;
        }

        public string JoinJsConfigVirtualPath { get; set; }

        private string _joinJsConfigContentCache = null;
        public void JoinJsConfigInit(bool hardRefresh = false)
        {
            if (string.IsNullOrWhiteSpace(JoinJsConfigVirtualPath))
            {
                throw new InvalidOperationException("初始化前必须为JoinJsConfigVirtualPath指定一个有效的虚拟路径");
            }
            var savePath = FileServer.MapPath(JoinJsConfigVirtualPath);
            var fileExists = FileServer.Exists(savePath);
            if (hardRefresh || !fileExists)
            {
                _joinJsConfigContentCache = null;
            }
            
            if (_joinJsConfigContentCache != null)
            {
                return;
            }
            
            if (Entries.Count == 0)
            {
                _joinJsConfigContentCache = string.Empty;
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var jsConfigEntry in Entries.Values)
                {
                    sb.AppendLine(string.Format("//config for {0}", jsConfigEntry.UniqueName));
                    var filePath = FileServer.MapPath(jsConfigEntry.VirtualPath);
                    var jsConfig = FileServer.ReadAllText(filePath);
                    sb.AppendLine(jsConfig.TrimEnd());
                    sb.AppendLine("");
                }
                _joinJsConfigContentCache = sb.ToString();
            }
            
            if (fileExists)
            {
                var oldValue = FileServer.ReadAllText(savePath);
                var newHash = HashHelper.HashString(_joinJsConfigContentCache);
                var oldHash = HashHelper.HashString(oldValue);
                if (newHash == oldHash)
                {
                    return;
                }
            }
            //save hash value
            FileServer.WriteAllText(savePath, _joinJsConfigContentCache);
        }

        private IFileServer _fileServer;
        public IFileServer FileServer
        {
            get { return _fileServer ?? (_fileServer = Web.FileServer.Resolve()); }
            set { _fileServer = value; }
        }

        private IHashHelper _hashHelper;

        public IHashHelper HashHelper
        {
            get { return _hashHelper ?? (_hashHelper = CommonFx.HashHelper.Resolve()); }
            set { _hashHelper = value; }
        }
    }
}
