using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class CatTests {
    [Test]
    public void CheckCatsAdded () {
        // adds all the cats to the cat list
        var catList = CatList.getInstance();
        catList.discoveredCats.Clear();

        catList.AddCatType(CatType.GREY);
        catList.AddCatType(CatType.BROWN);
        catList.AddCatType(CatType.WHITE);
        catList.AddCatType(CatType.GINGER);
        catList.AddCatType(CatType.TEAL);
        catList.AddCatType(CatType.PINK);
        catList.AddCatType(CatType.BLUE);
        catList.AddCatType(CatType.GREEN);
        catList.AddCatType(CatType.RED);
        catList.AddCatType(CatType.RAINBOW);
        catList.AddCatType(CatType.WELCOME);
        catList.AddCatType(CatType.PARTY);

        //ACT
        int expectedCats = 12;
        int cats = catList.discoveredCats.Count;

        //ASSERT
        Assert.That(cats, Is.EqualTo(expectedCats));
    }
}

