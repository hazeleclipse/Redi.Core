// -----------------------------------------------------------------------
// <copyright file="IIntegralWeightedDictionary.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Redi.Core.Collection;

public interface IIntegralWeightedDictionary<T>
    : IDictionary<T, Weight>, IIntegralWeightedCollection<T>
    where T : notnull
{
}
