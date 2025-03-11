using System;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Utils
{
    public static class Utils
    {
        public static void SetIp(string ip)
        {
            GetUnityTransport().ConnectionData.Address = ip;
        }

        public static UnityTransport GetUnityTransport()
        {
            var temp = (NetworkManager.Singleton.NetworkConfig.NetworkTransport);
            try
            {
                var unityTransport = (UnityTransport)temp;
                return unityTransport;
            }
            catch (Exception e)
            {
                Debug.LogError("Network transport is not UnityTransport!");
                Debug.LogError(e);
                throw;
            }
        }

        public static void SetPlayerPrefab(GameObject playerPrefab)
        {
            NetworkManager.Singleton.NetworkConfig.PlayerPrefab = playerPrefab;
        }
    }
}