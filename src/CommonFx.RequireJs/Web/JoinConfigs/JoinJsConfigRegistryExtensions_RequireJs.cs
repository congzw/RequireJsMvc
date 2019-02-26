namespace CommonFx.Web.JoinConfigs
{
    public static class JoinJsConfigRegistryExtensionsRequireJs
    {
        public static string JoinJsConfigKey = "~/Content/Scripts/app_config_require.js";
        public static JoinJsConfig RequireJs(this JoinJsConfigRegistry registry)
        {
            if (registry.Configs.ContainsKey(JoinJsConfigKey))
            {
                return registry.Configs[JoinJsConfigKey];
            }
            registry.Configs.Add(JoinJsConfigKey, new JoinJsConfig(JoinJsConfigKey));
            return registry.Configs[JoinJsConfigKey];
        }
    }
}