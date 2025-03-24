namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    public static class EngineSettings
    {
        public static EngineSettingsDataObject settings 
            => EngineSettingsDataScriptable.LoadData();
    }
}