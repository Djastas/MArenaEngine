using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using UnityEngine;


namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.UI
{
    public class TabController : MonoBehaviour
    {
        public SerializableDictionary<string, GameObject> tabs = new ();

        public void OpenTab(string tabName)
        {
            foreach (var tab in  tabs)
            {
                tab.Value.SetActive(tab.Value.name == tabName);
            }
        }

        
    }
}