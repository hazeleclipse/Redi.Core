// -----------------------------------------------------------------------
// <copyright file="Weight.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Value;

public readonly struct Weight
{
    private readonly ushort value;

    public Weight(ushort value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(value));
        this.value = value;
    }

    public ushort Value
    {
        get => this.value;
        init
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(value));
            this.value = value;
        }
    }

    public static implicit operator Weight(ushort value)
        => new (value);

    public static implicit operator ushort(Weight value)
        => value.Value;
}
