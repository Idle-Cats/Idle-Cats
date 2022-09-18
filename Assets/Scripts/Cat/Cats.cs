using System;
using static CatList;
using System.Collections.Generic;   // for List<>

public class Cats {
    public CatType type;

    public Cats() {
    }

    public Cats(CatType catType) {
        this.type = catType;
    }

    public CatType GetCatType() {
        return this.type;
    }

    public string PrintCat() {
        return "Cat type: " + this.type;
    }

    // generate a random cat
    //not needed
    // public static Cats GenerateRandomCat() {
    //         List<Cats> cList = new List<Cats>(catList.discoveredCats);
    //         CatType catType = cList[random.Next(catList.discoveredCats.Count)].GetCatType();
    //         return new Cats(catType);
    // }

    // all cats
    public enum CatType {
        GREY, //milestone1
        BROWN, //milestone2
        WHITE, //milestone3
        GINGER, //milestone4
        TEAL, //milestone5
        PINK, //milestone6
        BLUE, //milestone7
        GREEN, //milestone8
        RED, //milestone9
        RAINBOW, //milestone10
        WELCOME, //milestone11
        PARTY, //milestone12
        HELP //mileston13
    }
}