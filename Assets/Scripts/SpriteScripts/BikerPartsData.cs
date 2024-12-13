using UnityEngine;

[CreateAssetMenu(fileName = "BikePartsData", menuName = "Sprites/Bike")]
public class BikePartsData : ScriptableObject
{
    public Sprite frameSprite;
    public Sprite frontWheelSprite;
    public Sprite rearWheelSprite;

    public Sprite defaultFrameSprite;
    public Sprite defaultFrontWheelSprite;
    public Sprite defaultRearWheelSprite;
}
