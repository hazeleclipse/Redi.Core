// -----------------------------------------------------------------------
// <copyright file="IStakeDivisionCalculation.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Calculation;

public interface IStakeDivisionCalculation<T>
    where T : class
{
    List<(T, decimal)> Execute();
}
