using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cats;
using static CatList;

public class CatTest : MonoBehaviour
{
    CatList catList = CatList.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        catList.AddCat(new Cats(CatType.PINK));
        catList.AddCat(new Cats(CatType.GREEN));
        print("AMONGUS" + catList.PrintCats());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
