using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using static CatListDisplay;
using static CatList;

public class CatButtonManager : MonoBehaviour
{
    // [SerializeField] public GameObject button0;
    // [SerializeField] public GameObject button1;
    // [SerializeField] public GameObject button2;
    // [SerializeField] public GameObject button3;
    // [SerializeField] public GameObject button4;
    // [SerializeField] public GameObject button5;
    // [SerializeField] public GameObject button6;
    // [SerializeField] public GameObject button7;
    // [SerializeField] public GameObject button8;
    // [SerializeField] public GameObject button9;
    // [SerializeField] public GameObject button10;
    // [SerializeField] public GameObject button11;
    // [SerializeField] public GameObject button12;

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
