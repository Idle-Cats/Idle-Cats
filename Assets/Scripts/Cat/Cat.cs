using System;
using UnityEngine;

public class Cat : MonoBehaviour {
    public CatType catType;

    public CatType GetCatType() {
        return catType;
    }

    public void setCatType(CatType catType) {
        this.catType = catType;
        GetComponent<SpriteRenderer>().color = getCatColor(catType);
    }

    private Color getCatColor(CatType type) {

        Color color = new Color(0.0f, 0.0f, 0.0f);

        switch (type)
        {
            case CatType.GREY:
                color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case CatType.BROWN:
                color = new Color(0.0f, 0.0f, 0.0f); 
                break;
            case CatType.WHITE:
                color = new Color(1.0f, 1.0f, 1.0f);
                break;
            case CatType.GINGER:
                color = new Color(0.7f, 0.3f, 0.1f);
                break;
            case CatType.TEAL:
                color = new Color(0.4f, 0.6f, 0.7f);
                break;
            case CatType.PINK:
                color = new Color(0.7f, 0.0f, 0.5f);
                break;
            case CatType.BLUE:
                color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case CatType.GREEN:
                color = new Color(0.0f, 1.0f, 0.0f);
                break;
            case CatType.RED:
                color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case CatType.RAINBOW:
                color = new Color(0.0f, 0.0f, 0.0f);
                break;
        }
        return color;
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