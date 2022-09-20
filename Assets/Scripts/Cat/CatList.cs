using System;
using System.Collections.Generic;   // for Set<>
using static Cat;

public class CatList{

private static CatList instance;

// list of discovered cats 
public static CatList getInstance() {
    if (instance == null) {
        instance = new CatList();
    }
    return instance;
}

   // hashset 
    public HashSet<CatType> discoveredCats = new HashSet<CatType>();

    // add cat to list
    public void AddCatType(CatType catType) {
        discoveredCats.Add(catType);
    }
    // // print list from set
    // public string PrintCats() {
    //     string output = "";
    //     foreach (Cat cat in discoveredCats) {
    //         output += cat.PrintCat() + " ";
    //     }
    //     return output;
    // }

    // check if cat type exists in list for catlist
    public bool catTypeExists(CatType type) {
        return discoveredCats.Contains(type);
    }
}
