// -----------------------------------------------------------------------
// <copyright file="Stake.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Value;

public readonly struct Stake
{
    private readonly decimal value;

    public Stake(decimal value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1, nameof(value));
        this.value = value;
    }

    public decimal Value
    {
        get => this.value;
        init
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1, nameof(value));
            this.value = value;
        }
    }

    public static implicit operator Stake(decimal value)
        => new (value);

    public static implicit operator decimal(Stake value)
        => value.Value;
}
