using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class GameProgressionTest{
    [Test]
    public void CheckCatResourcesUnlockTest() {
        //ARRANGE
        var gameProgression = new GameProgressionHelper();
        var catList = CatList.getInstance();
        catList.discoveredCats.Clear();
        
        gameProgression.food = 1000000;
        gameProgression.minerals = 1000000;
        gameProgression.catPower = 1000000;
    
        gameProgression.catList = catList;

        //ACT
        int expectedCats = 4;
        gameProgression.CheckUserResources();
        int cats = catList.discoveredCats.Count;

        //ASSERT
        Assert.That(cats, Is.EqualTo(expectedCats));

    }

    [Test]
    public void CheckRoomUnlockCats() {
        //ARRANGE
        var gameProgression = new GameProgressionHelper();
        var catList = CatList.getInstance();
        catList.discoveredCats.Clear();
        
        gameProgression.roomCount = 11;
    
        gameProgression.catList = catList;

        //ACT
        int expectedCats = 2;
        gameProgression.buildRoomCheck();
        int cats = catList.discoveredCats.Count;

        //ASSERT
        Assert.That(cats, Is.EqualTo(expectedCats));
    }
}
