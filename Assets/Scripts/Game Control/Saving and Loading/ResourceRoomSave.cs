using System.Collections;
using System.Collections.Generic;

public class ResourceRoomSave
{
    public float roomInvent = 0;
    public float roomBoost;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public string name = "ResourceRoom";
    public ResourceRoom.ResourceType resourceType;

    public ResourceRoomSave(float roomInvent, RoomBoost roomBoost, float roomCapacity, float resourceGen, string name, ResourceRoom.ResourceType resourceType) {
        this.roomInvent = roomInvent;
        this.roomBoost = roomBoost.boostAmount;
        this.roomCapacity = roomCapacity;
        this.resourceGen = resourceGen;
        this.name = name;
        this.resourceType = resourceType;
    }

    public ResourceRoomSave() {

    }
}
