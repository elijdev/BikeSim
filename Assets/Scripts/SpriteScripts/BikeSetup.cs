using UnityEngine;

public class BikeSetup : MonoBehaviour
{
    public BikePartsData bikePartsData;

    public SpriteRenderer frameRenderer;
    public SpriteRenderer wheelsRenderer;
    public SpriteRenderer crankshaftRenderer;

    void Start()
    {
        if (bikePartsData != null)
        {
            frameRenderer.sprite = bikePartsData.frameSprite;
            wheelsRenderer.sprite = bikePartsData.wheelsSprite;
            crankshaftRenderer.sprite = bikePartsData.crankshaftSprite;
        }
    }
}
