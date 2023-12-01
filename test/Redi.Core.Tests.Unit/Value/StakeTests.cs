// -----------------------------------------------------------------------
// <copyright file="StakeTests.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Value;

namespace Redi.Core.Tests.Unit;

public class StakeTests
{
    [Fact]
    public void Ctor_ValueInRange_CreatesStake()
    {
        // Arrange
        // Act
        var stake = new Stake(0.5M);

        // Assert
        Assert.Equal(0.5M, stake.Value);
    }

    [Fact]
    public void Ctor_ValueLessThanZero_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Stake(-0.01M);
        });
    }

    [Fact]
    public void Ctor_ValueGreaterThanOne_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Stake(1.1M);
        });
    }

    [Fact]
    public void ObjectInitializer_ValueInRange_CreatesStake()
    {
        // Arrange
        // Act
        var stake = new Stake { Value = 0.5M };

        // Assert
        Assert.Equal(0.5M, stake.Value);
    }

    [Fact]
    public void ObjectInitializer_ValueLessThanZero_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Stake { Value = -0.01M };
        });
    }

    [Fact]
    public void ObjectInitializer_ValueGreaterThanOne_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Stake { Value = -1.1M };
        });
    }
}
