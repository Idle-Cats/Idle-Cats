using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAfford : MonoBehaviour
{
    public int basePrice;
    public int currentPrice;
    public PriceType priceType;
    public RoomSaveInfo.RoomType roomType;
    public ResourceRoom.ResourceType resourceType;

    public GameObject gameControl;

    void Start() {
        currentPrice = basePrice;
    }

    public enum PriceType {
        Food,
        Minerals,
        Catpower
    }

    public void RemoveResources() {
        if (priceType == PriceType.Minerals) {
            gameControl.GetComponent<User>().minerals -= currentPrice;
        }
        else if (priceType == PriceType.Catpower) {
            gameControl.GetComponent<User>().catPower -= currentPrice;
        }
        else if (priceType == PriceType.Food) {
            gameControl.GetComponent<User>().food -= currentPrice;
        }
    }
}
