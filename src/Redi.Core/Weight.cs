// -----------------------------------------------------------------------
// <copyright file="Weight.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core;

public readonly struct Weight
{
    public Weight(ushort value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(value));
        Value = value;
    }

    public ushort Value
    {
        get => Value;
        init
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(value));
            Value = value;
        }
    }

    public static implicit operator Weight(ushort value)
        => new (value);

    public static implicit operator ushort(Weight value)
        => value.Value;
}
