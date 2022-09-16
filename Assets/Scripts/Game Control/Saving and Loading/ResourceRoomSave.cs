using System.Collections;
using System.Collections.Generic;

public class ResourceRoomSave
{
    public float roomInvent = 0;
    public float upgradeModifier = 0;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public string name = "ResourceRoom";
    public float globalResource = 0; //TODO make this global

    public ResourceRoomSave(float roomInvent, float upgradeModifier, float roomCapacity, float resourceGen, string name, float globalResource) {
        this.roomInvent = roomInvent;
        this.upgradeModifier = upgradeModifier;
        this.roomCapacity = roomCapacity;
        this.resourceGen = resourceGen;
        this.name = name;
        this.globalResource = globalResource;
    }

    public ResourceRoomSave() {

    }
}
