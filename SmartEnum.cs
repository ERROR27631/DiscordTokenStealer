﻿namespace DiscordTokenStealer;
public partial class SmartEnum<T> where T : class
{
    private static int _count = 0; // Default enum value
}

public partial class SmartEnum<T> where T : class
{
    public readonly string Name;

    public readonly int Value;

    public SmartEnum(string name, int? value = null)
    {
        Name = name;
        if (!value.HasValue)
        {
            Value = _count;
            Interlocked.Increment(ref _count);
        }
    }

    public override bool Equals(object? obj) => obj switch
    {
        int val => Value == val,
        SmartEnum<T> smartEnum => smartEnum.Value == Value,
        _ => false
    };

    public override int GetHashCode() => Value.GetHashCode();
}