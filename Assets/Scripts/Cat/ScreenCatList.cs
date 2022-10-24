using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCatList : MonoBehaviour
{
    public GameObject[] cats = new GameObject[5];
    public int catCount = 0;

    public GameObject catTest;

    public void addCat(GameObject cat) {
        if (catCount == cats.Length - 1) {
            ExpandCats();
        }
        cats[catCount] = cat;

        catCount++;
    }

    public CatInfo[] getCatInfo() {
        CatInfo[] catInfo = new CatInfo[catCount];

        for (int i = 0; i < catCount; i++) {
            catInfo[i] = new CatInfo(cats[i]);
        }

        return catInfo;
    }

    public void setFromCatInfo(CatInfo[] catInfo, int catCount) {
        this.catCount = catCount;

        for (int i = 0; i < catCount; i++) {
            GameObject cat = Instantiate(catTest, new Vector3(catInfo[i].x, catInfo[i].y, catInfo[i].z), Quaternion.identity);
            cat.GetComponent<CurrentRoom>().currentRoom = gameObject.GetComponent<BuildRoom>().rooms[catInfo[i].roomNum].getRoom();

            cats[i] = cat;
        }
    }

    private void ExpandCats()
    {
        GameObject[] newCats = new GameObject[cats.Length * 4];

        for (int i = 0; i < catCount; i++) {
            newCats[i] = cats[i];
        }

        cats = newCats;
    }
}
