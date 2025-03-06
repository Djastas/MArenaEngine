namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    public static class TypeUtils
    {
        public static int ConvertLongToInt(ulong value) => (int)(value & 0xFFFFFFFF);
    }
}