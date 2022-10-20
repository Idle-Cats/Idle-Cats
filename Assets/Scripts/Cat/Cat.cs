using System;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour {
    public CatType catType;

    public Sprite catImage0;
    public Sprite catImage1;
    public Sprite catImage2;
    public Sprite catImage3;
    public Sprite catImage4;
    public Sprite catImage5;
    public Sprite catImage6;
    public Sprite catImage7;
    public Sprite catImage8;
    public Sprite catImage9;
    public Sprite catImage10;
    public Sprite catImage11;

    public CatType GetCatType() {
        return catType;
    }

    public void setCatType(CatType catType) {
        this.catType = catType;
        GetComponent<SpriteRenderer>().color = getCatColor(catType);
        // set cat size width = 130 and height = 30 using rect transform
        this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    private Color getCatColor(CatType type) {

        Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        switch (type)
        {
            case CatType.GREY:
                GetComponent<SpriteRenderer>().sprite = catImage0;
                break;
            case CatType.BROWN:
                GetComponent<SpriteRenderer>().sprite = catImage1;
                break;
            case CatType.WHITE:
                GetComponent<SpriteRenderer>().sprite = catImage2;
                break;
            case CatType.GINGER:
                GetComponent<SpriteRenderer>().sprite = catImage3;
                break;
            case CatType.TEAL:
                GetComponent<SpriteRenderer>().sprite = catImage4;
                break;
            case CatType.PINK:
                GetComponent<SpriteRenderer>().sprite = catImage5;
                break;
            case CatType.BLUE:
                GetComponent<SpriteRenderer>().sprite = catImage6;
                break;
            case CatType.GREEN:
                GetComponent<SpriteRenderer>().sprite = catImage7;
                break;
            case CatType.RED:
                GetComponent<SpriteRenderer>().sprite = catImage8;
                break;
            case CatType.RAINBOW:
                GetComponent<SpriteRenderer>().sprite = catImage9;
                break;
            case CatType.WELCOME:
                GetComponent<SpriteRenderer>().sprite = catImage10;
                break;
            case CatType.PARTY:
                GetComponent<SpriteRenderer>().sprite = catImage11;
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
    }