using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBuilder : MonoBehaviour
{
    public GameObject prefab;

    public CatBuilder instance;

    public List<GameObject> catList = new List<GameObject>();

    public Cat createCat(CatType catType) {
        GameObject cat = Instantiate(prefab, new Vector3(0, 0, -1), Quaternion.identity);
        cat.SetActive(true);
        cat.GetComponent<Cat>().setCatType(catType);

        catList.Add(cat);

        return cat.GetComponent<Cat>();
    }

    public Cat createCat(CatInfo catInfo)
    {
        GameObject cat = Instantiate(prefab, new Vector3(catInfo.x, catInfo.y, catInfo.z), Quaternion.identity);
        cat.SetActive(true);
        cat.GetComponent<Cat>().setCatType(catInfo.catType);
        if (catInfo.roomNum > -1) {
            cat.GetComponent<CurrentRoom>().currentRoom = gameObject.GetComponent<BuildRoom>().rooms[catInfo.roomNum].getRoom();
        }

        catList.Add(cat);

        return cat.GetComponent<Cat>();
    }

}
