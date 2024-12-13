using UnityEngine;

public class BikeSetup : MonoBehaviour
{
    public BikePartsData bikePartsData;

    public SpriteRenderer frameRenderer;
    public SpriteRenderer frontWheelRenderer;
    public SpriteRenderer rearWheelRenderer;

    void Start()
    {
        if (bikePartsData != null)
        {
            frameRenderer.sprite = bikePartsData.frameSprite;
            frontWheelRenderer.sprite = bikePartsData.frontWheelSprite;
            rearWheelRenderer.sprite = bikePartsData.rearWheelSprite;
        }
    }

}
