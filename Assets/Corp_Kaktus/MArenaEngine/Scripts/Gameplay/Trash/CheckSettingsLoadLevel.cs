using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class CheckSettingsLoadLevel : MonoBehaviour
    {
        [Header("Warning: return always setup scene")]
        [SerializeField] private string level;
        [SerializeField] private string setupScene;

        // todo 
        // check connection
        // check settings
        // wait before load
        // scene in build settings check
        // if server skip
        
        public void Start()
        {
            SceneManager.LoadScene(setupScene);
        }
    }
}