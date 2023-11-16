// -----------------------------------------------------------------------
// <copyright file="IntegerWeightedSplit.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Calculation;

public class IntegerWeightedSplit<T> : IStakeDivisionCalculation<T>
    where T : class
{
    public IntegerWeightedSplit(ICollection<(T, byte)> weightedStakers, decimal dividend)
    {
        WeightedStakers = weightedStakers;
        Dividend = dividend;
    }

    private ICollection<(T, byte)> WeightedStakers { get; init; }

    private decimal Dividend { get; init; }

    public List<(T, decimal)> Execute()
    {
        var quotients = new List<(T, decimal)>();

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
