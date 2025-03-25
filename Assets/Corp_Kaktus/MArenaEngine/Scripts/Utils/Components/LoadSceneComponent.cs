using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class LoadSceneComponent : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        [SerializeField] private bool loadOnStart;
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void Start()
        {
            if (loadOnStart)
                LoadScene(sceneToLoad);
        }
    }
}