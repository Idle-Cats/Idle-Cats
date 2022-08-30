using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;

public class CatColour : MonoBehaviour
{
    private Cats cat;
    // create a serializable class for the cat type
    [SerializeField] public CatType catType;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
