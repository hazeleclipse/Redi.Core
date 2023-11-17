// -----------------------------------------------------------------------
// <copyright file="Stake.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core;

public readonly struct Stake
{
    public Stake(decimal value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1, nameof(value));
        Value = value;
    }

    public decimal Value { get; init; }

    public static implicit operator Stake(decimal value)
        => new (value);

    public static implicit operator decimal(Stake value)
        => value.Value;
}
