namespace NextInput.Input;

/// <summary>
/// Static helper class to convert values to their standardized NextInput counterpart
/// </summary>
public static class Convert
{
    /// <summary>
    /// Converts a <see cref="sbyte"/> to a NextInput Axis value
    /// <param name="value">The raw value between sbyte.<see cref="sbyte.MinValue"/> to sbyte.<see cref="sbyte.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(sbyte value) => (float)(value - sbyte.MinValue) / byte.MaxValue;
    /// <summary>
    /// Converts a <see cref="sbyte"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(sbyte value, sbyte min, sbyte max) => (float)(value - min) / (max - min);
    
    /// <summary>
    /// Converts a <see cref="byte"/> to a NextInput Axis value
    /// <param name="value">The raw value between byte.<see cref="byte.MinValue"/> to byte.<see cref="byte.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(byte value) => (float)value / byte.MaxValue;
    /// <summary>
    /// Converts a <see cref="byte"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(byte value, byte min, byte max) => (float)(value - min) / (max - min);
    
    /// <summary>
    /// Converts a <see cref="short"/> to a NextInput Axis value
    /// <param name="value">The raw value between short.<see cref="short.MinValue"/> to short.<see cref="short.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(short value) => (float)(value - short.MinValue) / ushort.MaxValue;
    /// <summary>
    /// Converts a <see cref="short"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(short value, short min, short max) => (float)(value - min) / (max - min);
    
    /// <summary>
    /// Converts a <see cref="ushort"/> to a NextInput Axis value
    /// <param name="value">The raw value between ushort.<see cref="ushort.MinValue"/> to ushort.<see cref="ushort.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(ushort value) => (float)value / ushort.MaxValue;
    /// <summary>
    /// Converts a <see cref="ushort"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(ushort value, ushort min, ushort max) => (float)(value - min) / (max - min);
    
    /// <summary>
    /// Converts a <see cref="int"/> to a NextInput Axis value
    /// <param name="value">The raw value between int.<see cref="int.MinValue"/> to int.<see cref="int.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(int value) => ((float)value / int.MaxValue + 1f) / 2f;
    // TODO!
    
    /// <summary>
    /// Converts a <see cref="uint"/> to a NextInput Axis value
    /// <param name="value">The raw value between uint.<see cref="uint.MinValue"/> to uint.<see cref="uint.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(uint value) => (float)((double)value / uint.MaxValue);
    /// <summary>
    /// Converts a <see cref="uint"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(uint value, uint min, uint max) => (float)(value - min) / (max - min);
    
    /// <summary>
    /// Converts a <see cref="long"/> to a NextInput Axis value
    /// <param name="value">The raw value between long.<see cref="long.MinValue"/> to long.<see cref="long.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(long value) => ((float)value / long.MaxValue + 1f) / 2f;
    // TODO!
    
    /// <summary>
    /// Converts a <see cref="ulong"/> to a NextInput Axis value
    /// <param name="value">The raw value between ulong.<see cref="ulong.MinValue"/> to ulong.<see cref="ulong.MaxValue"/></param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(ulong value) => (float)((double)value / ulong.MaxValue);
    /// <summary>
    /// Converts a <see cref="ulong"/> with a defined minimum and maximum to a NextInput Axis value
    /// <param name="value">The raw value between <paramref name="min"/> and <paramref name="max"/></param>
    /// <param name="min">The minimum value that <paramref name="value"/> can be</param>
    /// <param name="max">The maximum value that <paramref name="value"/> can be</param>
    /// <returns>A standard NextInput Axis value: a <see cref="float"/> between 0 and 1</returns>
    /// </summary>
    public static float ToAxis(ulong value, ulong min, ulong max) => (float)(value - min) / (max - min);
    
    // TODO: Float conversion
}