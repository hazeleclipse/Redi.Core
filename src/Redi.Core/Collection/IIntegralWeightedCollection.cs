// -----------------------------------------------------------------------
// <copyright file="IIntegralWeightedCollection.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Collection;

public interface IIntegralWeightedCollection<T>
    : ICollection<KeyValuePair<T, Weight>>
    where T : notnull
{
    uint TotalWeight { get; }
}
