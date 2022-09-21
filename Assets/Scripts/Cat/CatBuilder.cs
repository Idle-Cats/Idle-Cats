using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBuilder : MonoBehaviour
{
    public GameObject prefab;

    public CatBuilder instance;

    public Cat createCat(CatType catType) {
        GameObject cat = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        cat.SetActive(true);
        cat.GetComponent<Cat>().setCatType(catType);
        return cat.GetComponent<Cat>();
    }

}
