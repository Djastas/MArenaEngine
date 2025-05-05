using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay
{
    public class LevelLoadController : Singleton<LevelLoadController>
    {
        public Scene currentScene;

        protected override void Awake()
        {
            base.Awake();
            if (EngineSettings.EngineSettings.settings.loadStartLevel)
            {
                LoadLevel(EngineSettings.EngineSettings.settings.startMainLevel);
            }
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
            var loadedScene = SceneManager.GetSceneByName(levelName);
            currentScene = loadedScene;
            
            Check();
        }

        private void Start()
        {
            Check();
        }

        private void Check()
        {
            if (currentScene.isLoaded)
            {
                return;
            }

            Debug.LogError("[LevelLoadController] Main level scene not loaded");
        }
    }
}