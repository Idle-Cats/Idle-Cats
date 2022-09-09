using System;
using static CatList;
using System.Collections.Generic;   // for List<>

public class Cats {
    private CatType type;

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
    public static Cats GenerateRandomCat() {
        CatList catList = CatList.getInstance();
        Random random = new Random();
        int randomNumber = random.Next(0, 1000);

        if (randomNumber == 24 ) {
            CatList.getInstance().AddCat(new Cats(CatType.TEAL));
            return new Cats(CatType.TEAL);

        } else if (randomNumber == 945) {
            CatList.getInstance().AddCat(new Cats(CatType.PINK));
            return new Cats(CatType.PINK);

        } else if (randomNumber == 337) {
            CatList.getInstance().AddCat(new Cats(CatType.BLUE));
            return new Cats(CatType.BLUE);

        } else if (randomNumber == 438) {
            CatList.getInstance().AddCat(new Cats(CatType.GREEN));
            return new Cats(CatType.GREEN);

        } else if (randomNumber == 267) {
            CatList.getInstance().AddCat(new Cats(CatType.RED));
            return new Cats(CatType.RED);

        } else if (randomNumber == 420) {
            if (random.Next(0, 50) == 7) {
                CatList.getInstance().AddCat(new Cats(CatType.RAINBOW));
                return new Cats(CatType.RAINBOW);
            } else {
                // gen new cat
                Console.WriteLine("Generating new cat...");
                return GenerateRandomCat();
            }
            // if random less than 500
        } else if (randomNumber < 500) {
            List<Cats> cList = new List<Cats>(catList.discoveredCats);
            CatType catType = cList[random.Next(catList.discoveredCats.Count)].GetCatType();
            return new Cats(catType);

        } else {
            CatType catType = (CatType)random.Next(0, 4);
            CatList.getInstance().AddCat(new Cats(catType));
            return new Cats(catType);
        }
    }

    public enum CatType {
        GREY,
        BROWN,
        WHITE,
        GINGER,
        TEAL,
        PINK,
        BLUE,
        GREEN,
        RED,
        RAINBOW,
        WELCOME,
        PARTY,
        HELP
    }
}