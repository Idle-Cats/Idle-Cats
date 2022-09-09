using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;
using static CatList;

public class CatColours : MonoBehaviour
{
    private Cats cat;
    CatList catList = CatList.getInstance();

    // Start is called before the first frame update
    void Start()
    {
        CatList.getInstance().AddCat(new Cats(CatType.GREEN));
        Cats cat = Cats.GenerateRandomCat();

        switch (cat.GetCatType())
        {
            case CatType.GREY:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case CatType.BROWN:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
                break;
            case CatType.WHITE:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
                break;
            case CatType.GINGER:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.3f, 0.1f);
                break;
            case CatType.TEAL:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.6f, 0.7f);
                break;
            case CatType.PINK:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.0f, 0.5f);
                break;
            case CatType.BLUE:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case CatType.GREEN:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
                break;
            case CatType.RED:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case CatType.RAINBOW:
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
                break;
        }
        // print size of cat list
        // print(catList.discoveredCats.Count);
        print(catList.PrintCats());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
