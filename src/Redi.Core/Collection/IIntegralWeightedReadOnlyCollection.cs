// -----------------------------------------------------------------------
// <copyright file="IIntegralWeightedReadOnlyCollection.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Collection;

public interface IIntegralWeightedReadOnlyCollection<T>
    : IReadOnlyCollection<KeyValuePair<T, Weight>>
    where T : notnull
{
    uint TotalWeight { get; }
}
