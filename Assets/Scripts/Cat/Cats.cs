using System;
using static CatList;

public class Cats {
    public CatType type;
    private int pBoost;
    private int sBoost;

    public Cats(CatType catType) {
        this.type = catType;
    }

    public CatType GetCatType() {
        return this.type;
    }

    public string PrintCat() {
        return "Cat type: " + this.type;
    }

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

    public static int GetPBoost(CatType type) {
        switch (type) {
            case CatType.GREY:
            case CatType.BROWN:
            case CatType.WHITE:
            case CatType.GINGER:
                return 1;
            case CatType.TEAL:
            case CatType.PINK:
            case CatType.BLUE:
            case CatType.GREEN:
            case CatType.RED:
                return 2;
            case CatType.RAINBOW:
                return 10;
            case CatType.WELCOME:
            case CatType.PARTY:
            case CatType.HELP:
                return 5;
            default:
                return 0;
        }
    }

    public static int GetSBoost(CatType type) {
        switch (type) {
            case CatType.GREY:
            case CatType.BROWN:
            case CatType.WHITE:
            case CatType.GINGER:
                return 2;
            case CatType.TEAL:
            case CatType.PINK:
            case CatType.BLUE:
            case CatType.GREEN:
            case CatType.RED:
                return 4;
            case CatType.RAINBOW:
                return 20;
            case CatType.WELCOME:
            case CatType.PARTY:
            case CatType.HELP:
                return 10;
            default:
                return 0;
        }
    }
}