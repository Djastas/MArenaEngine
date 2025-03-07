using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class LoadSceneComponent : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}