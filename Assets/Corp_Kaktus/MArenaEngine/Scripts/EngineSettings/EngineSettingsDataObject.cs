using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings
{
    [Serializable]
    public class EngineSettingsDataObject
    {
        public bool validate = true;
        
        [Header("Build Settings")] 
        public bool controlClientBuild;
        
        [Header("Debug Settings")] 
        public int debugLevel;
        
        [Header("Loaders settings")]
        public GameObject clientLoader;
        public GameObject controllerLoader;
        public GameObject serverLoader;
        
         [Space]
        public bool autoLoadEditorHost;

        
        public void Validate()
        {
            if (!validate) { return; }
            
            
            /*SceneCheck(clientScene,"clientScene");
            SceneCheck(uiScene,"uiScene");*/
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