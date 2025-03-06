using System;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    public class EngineSettingsDataScriptable : ScriptableObject
    {
        public static EngineSettingsDataScriptable Instance;
        public EngineSettingsDataObject data;
        
        public const string SettingsAssetPath = "Resources/"; // todo 
        public const string SettingsAssetName = "EngineSettings"; // todo 
        // rename engine, repath

        public static EngineSettingsDataScriptable LoadData()
        {
            if (Instance != null)
            {
                return Instance;
            }
            // var settings = AssetDatabase.LoadAssetAtPath<EngineSettingsDataScriptable>(SettingsAssetPath);
            var settings = Resources.Load<EngineSettingsDataScriptable>(SettingsAssetName);
           
            if (settings != null)
            {
                Instance = settings;
                return settings;
            }

           
#if UNITY_EDITOR
            return Init();

#else
            Debug.LogError("EngineSettingsDataScriptable Not Exist");
            NetDebugger.instance.Log("EngineSettingsDataScriptable Not Exist");
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