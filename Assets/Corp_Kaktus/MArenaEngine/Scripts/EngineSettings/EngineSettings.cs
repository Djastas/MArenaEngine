namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    /// <summary>
    /// public static link for setting data
    /// </summary>
    public static class EngineSettings
    {
        public static EngineSettingsDataObject settings 
            => EngineSettingsDataScriptable.LoadData();
    }
}