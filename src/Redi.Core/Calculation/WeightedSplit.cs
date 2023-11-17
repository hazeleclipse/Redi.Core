// -----------------------------------------------------------------------
// <copyright file="WeightedSplit.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Calculation;

public class WeightedSplit<T> : IStakeDivisionCalculation<T>
    where T : notnull
{
    public WeightedSplit(IReadOnlyCollection<(T, Weight)> weightedStakers, Stake dividend)
    {
        ArgumentNullException.ThrowIfNull(weightedStakers, nameof(weightedStakers));
        ArgumentOutOfRangeException.ThrowIfZero(weightedStakers.Count, nameof(WeightedStakers.Count));
        WeightedStakers = weightedStakers;

        ArgumentNullException.ThrowIfNull(dividend, nameof(dividend));
        Dividend = dividend;
    }

    public IReadOnlyCollection<(T, Weight)> WeightedStakers { get; init; }

    public Stake Dividend { get; init; }

    public IReadOnlyCollection<(T, Stake)> Execute()
    {
        var quotients = new List<(T, Stake)>();

        ulong totalWeight = 0;
        foreach (var (_, weight) in WeightedStakers)
            totalWeight += weight;

        foreach (var (staker, weight) in WeightedStakers)
        {
            var quotient = (Dividend * weight) / totalWeight;
            quotients.Add((staker, quotient));
        }

        return quotients;
    }
}
