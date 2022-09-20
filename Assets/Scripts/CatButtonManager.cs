using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using static CatListDisplay;
using static CatList;

public class CatButtonManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
//get the first buttons children
        // button0 = transform.GetChild(0).gameObject;
        Debug.Log(buttons[0].transform.GetChild(0).gameObject.GetComponent<Image>());
        // Debug.Log(buttons[0].GetComponent<CatListDisplay>().cat.GetCatType());
        

        foreach (Cats cat in CatList.getInstance().discoveredCats) {
            Debug.Log(buttons[(int)cat.GetCatType()]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
