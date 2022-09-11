using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;
using static CatList;
public class CatListDisplay : MonoBehaviour
{
    private Cats cat;
    // create a serializable class for the cat type
    [SerializeField] public CatType catType;
    // create a serializable class for the catlist
    [SerializeField] public CatList catList;

    void Start()
    {
        Cats cat = new Cats(catType);

        bool exists = CatList.getInstance().catTypeExists(cat.GetCatType());
        // if cat exists in catlist, set sprite to active otherwise set to inactive
        float opacity = exists ? 1.0f : 0.5f;
        
        // set colours regarding cats - can change
        switch (cat.GetCatType())
        {
            case CatType.GREY:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, opacity);
                break;
            case CatType.BROWN:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, opacity);
                break;
            case CatType.WHITE:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, opacity);
                break;
            case CatType.GINGER:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.3f, 0.1f, opacity);
                break;
            case CatType.TEAL:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.6f, 0.7f, opacity);
                break;
            case CatType.PINK:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.0f, 0.5f, opacity);
                break;
            case CatType.BLUE:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, opacity);
                break;
            case CatType.GREEN:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, opacity);
                break;
            case CatType.RED:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, opacity);
                break;
            case CatType.RAINBOW:
                this.transform.Find("Renderer").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, opacity);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
