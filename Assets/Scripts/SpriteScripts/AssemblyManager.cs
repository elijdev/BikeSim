using UnityEngine;

public class AssemblyManager : MonoBehaviour
{
    public BikePartsData bikePartsData;
    public SpriteRenderer frameRenderer;
    public SpriteRenderer frontWheelRenderer;
    public SpriteRenderer rearWheelRenderer;

    public void SetFrameSprite(Sprite frameSprite)
    {
        bikePartsData.frameSprite = frameSprite;
        frameRenderer.sprite = frameSprite;
    }

    public void SetFrontWheelSprite(Sprite frontWheelSprite)
    {
        bikePartsData.frontWheelSprite = frontWheelSprite;
        frontWheelRenderer.sprite = frontWheelSprite;
    }

    public void SetRearWheelSprite(Sprite rearWheelSprite)
    {
        bikePartsData.rearWheelSprite = rearWheelSprite;
        rearWheelRenderer.sprite = rearWheelSprite;
    }

    public void RevertToDefault()
    {
        bikePartsData.frameSprite = bikePartsData.defaultFrameSprite;
        bikePartsData.frontWheelSprite = bikePartsData.defaultFrontWheelSprite;
        bikePartsData.rearWheelSprite = bikePartsData.defaultRearWheelSprite;
        frontWheelRenderer.sprite = bikePartsData.defaultFrontWheelSprite;
        rearWheelRenderer.sprite = bikePartsData.defaultRearWheelSprite;
        frameRenderer.sprite = bikePartsData.defaultFrameSprite;

        Debug.Log("Reverted to default sprites");
    }
}
