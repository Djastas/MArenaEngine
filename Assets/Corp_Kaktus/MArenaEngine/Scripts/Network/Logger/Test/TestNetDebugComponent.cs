using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger.Test
{
    public class TestNetDebugComponent : MonoBehaviour
    {
        [ContextMenu("Debug")]
        public void TestDebug()
        {
            NetDebugger.instance.Log("test Debug");
        }
    }
}