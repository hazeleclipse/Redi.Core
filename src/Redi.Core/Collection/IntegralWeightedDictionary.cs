// -----------------------------------------------------------------------
// <copyright file="IntegralWeightedDictionary.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

namespace Redi.Core.Collection;

public class IntegralWeightedDictionary<T>
    : IIntegralWeightedDictionary<T>
    where T : notnull
{
    public uint TotalWeight { get; private set; } = 0;

    public ICollection<T> Keys => Dictionary.Keys;

    public ICollection<Weight> Values => Dictionary.Values;

    public int Count => Dictionary.Count;

    public bool IsReadOnly { get; set; }

    private Dictionary<T, Weight> Dictionary { get; } = new Dictionary<T, Weight>();

    public Weight this[T key]
    {
        get => Dictionary[key];
        set
        {
            if (Dictionary.TryGetValue(key, out Weight currentWeight))
                TotalWeight = TotalWeight - currentWeight + value;
            else
                TotalWeight += value;

            Dictionary[key] = value;
        }
    }

    public void Add(T key, Weight value)
    {
        if (Dictionary.TryGetValue(key, out Weight currentWeight))
                TotalWeight = TotalWeight - currentWeight + value;
        else
            TotalWeight += value;

        Dictionary.Add(key, value);
    }

    public void Add(KeyValuePair<T, Weight> item)
    {
        if (Dictionary.TryGetValue(item.Key, out Weight currentWeight))
                TotalWeight = TotalWeight - currentWeight + item.Value;
        else
            TotalWeight += item.Value;

        Dictionary.Add(item.Key, item.Value);
    }

    public void Clear()
    {
        TotalWeight = 0;
        Dictionary.Clear();
    }

    public bool Contains(KeyValuePair<T, Weight> item)
        => Dictionary.Contains(item);

    public bool ContainsKey(T key)
        => Dictionary.ContainsKey(key);

    public void CopyTo(KeyValuePair<T, Weight>[] array, int arrayIndex)
        => ((ICollection)Dictionary).CopyTo(array, arrayIndex);

    public IEnumerator<KeyValuePair<T, Weight>> GetEnumerator()
        => Dictionary.GetEnumerator();

    public bool Remove(T key)
    {
        if (Dictionary.TryGetValue(key, out Weight currentWeight))
            TotalWeight -= currentWeight;

        return Dictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<T, Weight> item)
    {
        if (Dictionary.TryGetValue(item.Key, out Weight currentWeight))
            TotalWeight -= currentWeight;

        return Dictionary.Remove(item.Key);
    }

    public bool TryGetValue(T key, [MaybeNullWhen(false)] out Weight value)
    {
        Weight innerValue;
        if (Dictionary.TryGetValue(key, out innerValue))
        {
            value = innerValue;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
