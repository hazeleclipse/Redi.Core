// -----------------------------------------------------------------------
// <copyright file="EvenSplit.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Calculation;

public class EvenSplit<T> : IStakeDivisionCalculation<T>
    where T : class
{
    public EvenSplit(ICollection<T> stakers, decimal dividend)
    {
        Stakers = stakers;
        Dividend = dividend;
    }

    private ICollection<T> Stakers { get; init; }

    private decimal Dividend { get; init; }

    public List<(T, decimal)> Execute()
    {
        var quotients = new List<(T, decimal)>();
        var quotient = Dividend / Stakers.Count;

        foreach (var staker in Stakers)
            quotients.Add((staker, quotient));

        return quotients;
    }
}