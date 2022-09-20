using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAfford : MonoBehaviour
{
    public int price;
    public PriceType priceType;
    public RoomSaveInfo.RoomType roomType;

    public enum PriceType {
        Food,
        Minerals,
        Catpower
    }
}
