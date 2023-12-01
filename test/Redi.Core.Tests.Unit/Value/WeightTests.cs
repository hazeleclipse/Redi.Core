// -----------------------------------------------------------------------
// <copyright file="WeightTests.cs" company="Hazel Eclipse">
// Copyright (c) Hazel Eclipse. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Redi.Core.Value;

namespace Redi.Core.Tests.Unit;

public class WeightTests
{
    [Fact]
    public void Ctor_ValueInRange_CreatesWeight()
    {
        // Arrange
        // Act
        var weight = new Weight(1);

        // Assert
        Assert.Equal(1, weight.Value);
    }

    [Fact]
    public void Ctor_ValueLessThanOne_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Weight(0);
        });
    }

    [Fact]
    public void ObjectInitializer_ValueInRange_CreatesWeight()
    {
        // Arrange
        // Act
        var weight = new Weight { Value = 1 };

        // Assert
        Assert.Equal(1, weight.Value);
    }

    [Fact]
    public void ObjectInitializer_ValueLessThanOne_ThrowsArgumentOutOfRange()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Weight { Value = 0 };
        });
    }
}
