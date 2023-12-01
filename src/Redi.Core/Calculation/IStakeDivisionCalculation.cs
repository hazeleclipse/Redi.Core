// -----------------------------------------------------------------------
// <copyright file="IStakeDivisionCalculation.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Value;

namespace Redi.Core.Calculation;

public interface IStakeDivisionCalculation<T>
    where T : notnull
{
    IReadOnlyCollection<(T, Stake)> Execute();
}
