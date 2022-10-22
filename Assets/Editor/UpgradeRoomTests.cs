using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class UpgradeRoomTests
{
    [Test]
    public void CheckUpgradeResourceIncrease()
    {
        //ARRANGE
        var resourceRoom = new ResourceRoomHelper();

        resourceRoom.timesGenerationUpgraded = 5;

        //ACT
        int expectedGenerationCost = 2400;
        int cost = resourceRoom.generationUpgradeCost();

        //ASSERT
        Assert.That(cost, Is.EqualTo(expectedGenerationCost));

    }

    [Test]
    public void CheckInventUpgradeEffects()
    {
        //ARRANGE
        var resourceRoom = new ResourceRoomHelper();

        resourceRoom.timesInventUpgraded = 5;

        //ACT
        float expectedInventory = 7000;
        resourceRoom.upgradeInventButtonPress();
        float inventory = resourceRoom.roomCapacity;

        //ASSERT
        Assert.That(inventory, Is.EqualTo(expectedInventory));
    }
}
