using System;

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
        Random random = new Random();
        int randomNumber = random.Next(0, 1000);
        if (randomNumber == 24 ) {
            return new Cats(CatType.TEAL);
        } else if (randomNumber == 945) {
            return new Cats(CatType.PINK);
        } else if (randomNumber == 337) {
            return new Cats(CatType.BLUE);
        } else if (randomNumber == 438) {
            return new Cats(CatType.GREEN);
        } else if (randomNumber == 267) {
            return new Cats(CatType.RED);
        } else if (randomNumber == 420) {
            if (random.Next(0, 50) == 7) {
                return new Cats(CatType.RAINBOW);
            } else {
                // gen new cat
                Console.WriteLine("Generating new cat...");
                return GenerateRandomCat();
            }
        } else {
            CatType catType = (CatType)random.Next(0, 10); // change back to 4 when done testing
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
        RAINBOW
    }
}