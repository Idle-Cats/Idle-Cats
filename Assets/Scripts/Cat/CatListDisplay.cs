using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cat;
using static CatList;
using UnityEngine.UI;
using TMPro;

public class CatListDisplay : MonoBehaviour
{
    public CatType catType;
    public CatList catList;

    public TextMeshProUGUI catListText;

    public Sprite catImage;
    public Sprite defaultCat;

    public GameObject AddCat;

    // public Cats getCat(){
    //     return new Cats(catType);
    // }

    public void click() {
        // if cat hasnt been unlocked yet dont update the text
        if (CatList.getInstance().catTypeExists(catType)) {
            // make button visible
            AddCat.SetActive(true);
            catListText.text = "Cats: " + catType + "\nPrimary Boost: " + Cat.GetPBoost(catType)+ "\nSecondary Boost: " + Cat.GetSBoost(catType);
            // currentCat.setCatType(catType);
            SceneControl.catTypeSpawn = catType;
        } else {
            // make button invisible
            AddCat.SetActive(false);
            catListText.text = "Cats: ????";
        }
    }

    void Start()
    {
        // CatList.getInstance().AddCat(new Cat(CatType.GREY));
        // CatList.getInstance().AddCat(new Cat(CatType.TEAL));
        CatList.getInstance().AddCatType(CatType.RAINBOW);
        CatList.getInstance().AddCatType(CatType.GREY);
        CatList.getInstance().AddCatType(CatType.TEAL);
        bool exists = CatList.getInstance().catTypeExists(catType);

        Sprite selected = null;

        if(exists) {
            selected = catImage;
        } else {
            selected = defaultCat;
        }
        
        // set colours regarding cats - can change
        switch (catType)
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
