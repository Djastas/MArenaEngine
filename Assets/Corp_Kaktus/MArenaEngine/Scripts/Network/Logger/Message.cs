using Unity.Netcode;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger
{
    public class Message : INetworkSerializable
    {
        public string Value;
        public ulong OwnerId;

        public Message(string message, ulong ownerId)
        {
            Value = message;
            OwnerId = ownerId;
        }

        public Message() { }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Value);
            serializer.SerializeValue(ref OwnerId);
        }
    }
}