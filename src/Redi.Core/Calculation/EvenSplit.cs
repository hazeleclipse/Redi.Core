// -----------------------------------------------------------------------
// <copyright file="EvenSplit.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Value;

namespace Redi.Core.Calculation;

public class EvenSplit<T> : IStakeDivisionCalculation<T>
    where T : notnull
{
    public EvenSplit(IReadOnlyCollection<T> stakers, Stake dividend)
    {
        Stakers = stakers;
        Dividend = dividend;
    }

    public IReadOnlyCollection<T> Stakers { get; init; }

    public decimal Dividend { get; init; }

    public IReadOnlyCollection<(T, Stake)> Execute()
    {
        var quotients = new List<(T, Stake)>();
        var quotient = Dividend / Stakers.Count;

        foreach (var staker in Stakers)
            quotients.Add((staker, quotient));

        return quotients;
    }
}