using System;
using System.Collections.Generic;

namespace CommonFx.Web.JoinConfigs
{
    public class JoinJsConfigRegistry
    {
        public JoinJsConfigRegistry()
        {
            Configs = new Dictionary<string, JoinJsConfig>(StringComparer.OrdinalIgnoreCase);
        }
        public IDictionary<string, JoinJsConfig> Configs { get; set; }

        public static JoinJsConfigRegistry Instance = new JoinJsConfigRegistry();
    }
}