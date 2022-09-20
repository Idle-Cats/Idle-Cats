using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAfford : MonoBehaviour
{
    public int price;
    public PriceType priceType;
    public RoomSaveInfo.RoomType roomType;

    public GameObject gameControl;

    public enum PriceType {
        Food,
        Minerals,
        Catpower
    }

    public void RemoveResources() {
        if (priceType == PriceType.Minerals) {
            gameControl.GetComponent<User>().minerals -= price;
        }
        else if (priceType == PriceType.Catpower) {
            gameControl.GetComponent<User>().catPower -= price;
        }
        else if (priceType == PriceType.Food) {
            gameControl.GetComponent<User>().food -= price;
        }
    }
}
