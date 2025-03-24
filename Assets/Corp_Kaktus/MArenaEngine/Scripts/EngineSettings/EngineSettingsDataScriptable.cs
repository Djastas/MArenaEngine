using System;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    /// <summary>
    /// ScriptableObject for managing(save\load) settings data
    /// </summary>
    public class EngineSettingsDataScriptable : ScriptableObject
    {
        [SerializeField] private EngineSettingsDataObject data;
        private static EngineSettingsDataScriptable _instance;
        
        private const string SettingsAssetPath = "Resources/";
        private const string SettingsAssetName = "MainSettings";

        public static EngineSettingsDataObject LoadData() => LoadInstance().data;

        public static EngineSettingsDataScriptable LoadInstance()
        {
            if (_instance) { return _instance; }
            _instance = Resources.Load<EngineSettingsDataScriptable>(SettingsAssetName);
           
            if (_instance) { return _instance; }

           
#if UNITY_EDITOR
            return Init();

#else
            Debug.LogError("EngineSettingsDataScriptable not exist");
            return null;
#endif
        }

#if UNITY_EDITOR
        private static EngineSettingsDataScriptable Init()
        {
            try
            {
                var settings = CreateInstance<EngineSettingsDataScriptable>();
                AssetDatabase.CreateAsset(settings, Paths.RootFolder + SettingsAssetPath + SettingsAssetName + ".asset");
                AssetDatabase.SaveAssets();
                Debug.Log("successfully initialized engine settings");
                return settings;
            }
            catch (Exception e)
            {
                Debug.LogError("Can't initialize engine settings");
                Debug.LogError(e);
                throw;
            }
            
        }
#endif
    }
}