using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;
using static CatList;

public class CatProperties : MonoBehaviour
{
    private Cats cat;
    CatList catList = CatList.getInstance();
    private int boosts;

    // Start is called before the first frame update
    void Start()
    {
        CatList.getInstance().AddCat(new Cats(CatType.GREEN));
        Cats cat = Cats.GenerateRandomCat();

        switch (cat.GetCatType())
        {
            case CatType.GREY:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
                boosts = 1;
                break;
            case CatType.BROWN:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
                boosts = 1;
                break;
            case CatType.WHITE:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
                boosts = 1;
                break;
            case CatType.GINGER:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.3f, 0.1f);
                boosts = 1;
                break;
            case CatType.TEAL:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.6f, 0.7f);
                boosts = 5;
                break;
            case CatType.PINK:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.0f, 0.5f);
                boosts = 5;
                break;
            case CatType.BLUE:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case CatType.GREEN:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
                boosts = 5;
                break;
            case CatType.RED:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
                boosts = 5;
                break;
            case CatType.RAINBOW:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
                boosts = 10;
                break;
        }
        // print(catList.PrintCats());
        print(cat.PrintCat() + " Boosts: " + boosts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}