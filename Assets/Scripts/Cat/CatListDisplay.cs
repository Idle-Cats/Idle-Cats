using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;
using static CatList;
using UnityEngine.UI;
using TMPro;

public class CatListDisplay : MonoBehaviour
{
    private Cats cat;
    public CatType catType;
    public CatList catList;

    public TextMeshProUGUI catListText;

    public Sprite catImage;
    public Sprite defaultCat;

    public Cats getCat(){
        return new Cats(catType);
    }

    public void click() {
        // if cat hasnt been unlocked yet dont update the text
        if (CatList.getInstance().catTypeExists(cat.GetCatType())) {
            catListText.text = "Cats: " + cat.GetCatType() + "\nPrimary Boost: " + Cats.GetPBoost(cat.GetCatType())+ "\nSecondary Boost: " + Cats.GetSBoost(cat.GetCatType());
        } else {
            catListText.text = "Cats: ????";
        }
    }

    void Start()
    {
        CatList.getInstance().AddCat(new Cats(CatType.GREY));
        CatList.getInstance().AddCat(new Cats(CatType.TEAL));
        this.cat = new Cats(catType);
        bool exists = CatList.getInstance().catTypeExists(cat.GetCatType());

        Sprite selected = null;

        if(exists) {
            selected = catImage;
        } else {
            selected = defaultCat;
        }
        
        // set colours regarding cats - can change
        switch (cat.GetCatType())
        {
            case CatType.GREY:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.BROWN:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.WHITE:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.GINGER:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.TEAL:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.PINK:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.BLUE:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.GREEN:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.RED:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.RAINBOW:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.WELCOME:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
            case CatType.PARTY:
                this.transform.Find("Image").GetComponent<Image>().sprite = selected;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
