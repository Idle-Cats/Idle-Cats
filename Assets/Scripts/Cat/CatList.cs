using System;
using System.Collections.Generic;   // for Set<>
using static Cats;

public class CatList{

// singleton pattern
private static CatList instance;

public static CatList getInstance() {
    if (instance == null) {
        instance = new CatList();
    }
    return instance;
}

   // hashset 
    private HashSet<Cats> discoveredCats = new HashSet<Cats>();

    public void AddCat(Cats cat) {
        if(!catTypeExists(cat.GetCatType())) {
            discoveredCats.Add(cat);
        }
    }

    public string PrintCats() {
        string output = "";
        foreach (Cats cat in discoveredCats) {
            output += cat.PrintCat() + " ";
        }
        return output;
    }

    public bool catTypeExists(CatType type) {
        foreach (Cats cat in discoveredCats) {
            if (cat.GetCatType() == type) {
                return true;
            }
        }
        return false;
    }
}
