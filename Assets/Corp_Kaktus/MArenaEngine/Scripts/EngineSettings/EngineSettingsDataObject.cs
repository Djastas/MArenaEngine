using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    /// <summary>
    /// Main settings object.
    /// Put settings here. Access from EngineSettings -> EngineSettingsDataScriptable -> LoadData()
    /// </summary>
    [Serializable]
    public class EngineSettingsDataObject 
    {
        public bool validate = true;
        
        [Header("Build Settings")] 
        public bool controlClientBuild;
        public bool useVRSimulator;
        
        [Header("Debug Settings")] 
        public int debugLevel;
        
        [Header("Loaders settings")]
        public GameObject clientLoader;
        public GameObject controllerLoader;
        public GameObject serverLoader;

        public bool loadStartLevel = true;
        public string startMainLevel = "_";
        
         [Space]
        public bool autoLoadEditorHost;

        
        public void Validate()
        {
            if (!validate) { return; }
            // put here checks
        }
        public void SceneCheck(string sceneName,string scenePropertyName)
        {
            if (!SceneInBuildSettings(sceneName))
            {
                Debug.LogWarning($"{scenePropertyName} not in build settings scene name: {sceneName}");
            }
        }
        public bool SceneInBuildSettings(string sceneName)
        {
            for (var sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
                if (SceneManager.GetSceneByBuildIndex(sceneIndex).name == sceneName)
                    return true;
            return false;
        }
    }
}