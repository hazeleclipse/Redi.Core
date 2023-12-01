// -----------------------------------------------------------------------
// <copyright file="StakeDivisionCalculator.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Value;

namespace Redi.Core.Calculation;

public static class StakeDivisionCalculator<T>
    where T : notnull
{
    public static IReadOnlyCollection<(T, Stake)> EvenSplit(
        ICollection<T> stakers,
        Stake dividend)
    {
        ArgumentNullException.ThrowIfNull(stakers, nameof(stakers));
        ArgumentOutOfRangeException.ThrowIfZero(stakers.Count, nameof(stakers.Count));
        var quotients = new List<(T, Stake)>();
        var quotient = dividend / stakers.Count;

        foreach (var staker in stakers)
            quotients.Add((staker, quotient));

        return quotients;
    }

    public static IReadOnlyCollection<(T, Stake)> WeightedSplit(
        ICollection<(T, Weight)> weightedStakers,
        Stake dividend)
    {
        ArgumentNullException.ThrowIfNull(weightedStakers, nameof(weightedStakers));
        ArgumentOutOfRangeException.ThrowIfZero(weightedStakers.Count, nameof(weightedStakers.Count));
        var quotients = new List<(T, Stake)>();

        ulong totalWeight = 0;
        foreach (var (_, weight) in weightedStakers)
            totalWeight += weight;

        foreach (var (staker, weight) in weightedStakers)
        {
            var quotient = dividend * weight / totalWeight;
            quotients.Add((staker, quotient));
        }

        return quotients;
    }
}
