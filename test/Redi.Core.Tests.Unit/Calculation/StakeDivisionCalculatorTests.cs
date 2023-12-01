// -----------------------------------------------------------------------
// <copyright file="StakeDivisionCalculatorTests.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Calculation;
using Redi.Core.Value;

namespace Redi.Core.Tests.Unit;

public class StakeDivisionCalculatorTests
{
    private static readonly string Staker = "staker";
    private static readonly Stake Dividend = new (1.0M);

    [Fact]
    public void EvenSplit_NullStakers_ThrowsArgumentNullException()
    {
        // Arrange
        List<string> stakers = null!;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            StakeDivisionCalculator<string>.EvenSplit(stakers, Dividend);
        });
    }

    [Fact]
    public void EvenSplit_ZeroStakers_ThrowsArgumentOfOfRange()
    {
        // Arrange
        var stakers = new List<string>() { };

        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            StakeDivisionCalculator<string>.EvenSplit(stakers, Dividend);
        });
    }

    [Theory]
    [InlineData(100)]
    public void EvenSplit_ReturnsEqualDividendForEach(ushort stopRange)
    {
        // Arrange
        var stakers = new List<string>();

        foreach (var index in Enumerable.Range(1, stopRange))
        {
            stakers.Add(Staker);
            var quotient = Dividend / index;

            // Act
            var stakes = StakeDivisionCalculator<string>.EvenSplit(stakers, Dividend);

            // Assert
            foreach ((_, var stake) in stakes)
                Assert.Equal(quotient, stake.Value);
        }
    }

    [Fact]
    public void WeightedSplit_NullWeightedStakers_ThrowsArgumentNullException()
    {
        // Arrange
        List<(string, Weight)> weightedStakers = null!;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            StakeDivisionCalculator<string>.WeightedSplit(weightedStakers, Dividend);
        });
    }

    [Fact]
    public void WeightedSplit_ZeroStakers_ThrowsArgumentOfOfRange()
    {
        // Arrange
        var weightedStakers = new List<(string, Weight)>() { };

        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            StakeDivisionCalculator<string>.WeightedSplit(weightedStakers, Dividend);
        });
    }

    [Theory]
    [InlineData(new ushort[] { 1, 1, 1 })]
    [InlineData(new ushort[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
    public void WeightedSplit_ReturnsWeightedDividendForEach(ushort[] weights)
    {
        // Arrange
        var stakers = new List<(string, Weight)>();
        uint totalWeight = 0;

        foreach (var weight in weights)
        {
            stakers.Add((Staker, weight));
            totalWeight += weight;
            var index = 0;

            // Act
            var stakes = StakeDivisionCalculator<string>.WeightedSplit(stakers, Dividend);

            // Assert
            foreach ((_, var stake) in stakes)
            {
                var quotient = Dividend * ((decimal)stakers[index].Item2 / totalWeight);
                Assert.Equal(quotient, stake.Value);
                index++;
            }
        }
    }
}
