using UnityEngine;

public class AssemblyManager : MonoBehaviour
{
    public BikePartsData bikePartsData;

    public void SetFrameSprite(Sprite newFrame)
    {
        bikePartsData.frameSprite = newFrame;
    }

    public void SetWheelsSprite(Sprite newWheels)
    {
        bikePartsData.wheelsSprite = newWheels;
    }

    public void SetCrankshaftSprite(Sprite newCrankshaft)
    {
        bikePartsData.crankshaftSprite = newCrankshaft;
    }
}
