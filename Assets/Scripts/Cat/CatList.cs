using System;
using System.Collections.Generic;   // for Set<>
using static Cats;

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
    public HashSet<Cats> discoveredCats = new HashSet<Cats>();

    // add cat to list
    public void AddCat(Cats cat) {
        if(!catTypeExists(cat.GetCatType())) {
            discoveredCats.Add(cat);
        }
    }
    // print list from set
    public string PrintCats() {
        string output = "";
        foreach (Cats cat in discoveredCats) {
            output += cat.PrintCat() + " ";
        }
        return output;
    }

    // check if cat type exists in list for catlist
    public bool catTypeExists(CatType type) {
        foreach (Cats cat in discoveredCats) {
            if (cat.GetCatType() == type) {
                return true;
            }
        }
        return false;
    }
}
