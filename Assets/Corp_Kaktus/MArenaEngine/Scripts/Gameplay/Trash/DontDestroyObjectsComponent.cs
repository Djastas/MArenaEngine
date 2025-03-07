using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class DontDestroyObjectsComponent : MonoBehaviour    
    {
        [SerializeField] private List<GameObject> objects;

        public void Awake()
        {
            foreach (var o in objects) DontDestroyOnLoad(o);
        }
    }
}