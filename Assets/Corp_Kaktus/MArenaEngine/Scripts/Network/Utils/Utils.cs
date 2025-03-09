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
            var temp = (NetworkManager.Singleton.NetworkConfig.NetworkTransport);
            try
            {
                var unityTransport = (UnityTransport)temp;
                unityTransport.ConnectionData.Address = ip;
            }
            catch (Exception e)
            {
                Debug.LogError("Network transport is not UnityTransport!");
                Debug.LogError(e);
            }
        }
    }
}