namespace NextInput.Input;

public static class Convert
{
    public static float ToAxis(sbyte value) => (float)(value - sbyte.MinValue) / byte.MaxValue;
    public static float ToAxis(sbyte value, sbyte min, sbyte max) => (float)(value - min) / (max - min);
    
    public static float ToAxis(byte value) => (float)value / byte.MaxValue;
    public static float ToAxis(byte value, byte min, byte max) => (float)(value - min) / (max - min);
    
    public static float ToAxis(short value) => (float)(value - short.MinValue) / ushort.MaxValue;
    public static float ToAxis(short value, short min, short max) => (float)(value - min) / (max - min);
    
    public static float ToAxis(ushort value) => (float)value / ushort.MaxValue;
    public static float ToAxis(ushort value, ushort min, ushort max) => (float)(value - min) / (max - min);
    
    public static float ToAxis(int value) => ((float)value / int.MaxValue + 1f) / 2f;
    // TODO!
    
    public static float ToAxis(uint value) => (float)((double)value / uint.MaxValue);
    public static float ToAxis(uint value, uint min, uint max) => (float)(value - min) / (max - min);
    
    public static float ToAxis(long value) => ((float)value / long.MaxValue + 1f) / 2f;
    // TODO!
    
    public static float ToAxis(ulong value) => (float)((double)value / ulong.MaxValue);
    public static float ToAxis(ulong value, ulong min, ulong max) => (float)(value - min) / (max - min);
    
    // TODO: Float conversion
}