using Unity.Netcode;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    public static class Testtt
    {
        [Rpc(SendTo.SpecifiedInParams)]
        public static void testRPC(RpcParams rpcParams)
        {
            
        }
    }
}