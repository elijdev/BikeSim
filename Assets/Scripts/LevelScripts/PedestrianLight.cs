using UnityEngine;

public class PedestrianLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;
    public GameObject personObj;
    public Transform targetPoint;

    public float moveSpeed = 2f;
    private bool isRedLightActive = true;
    private bool objectReachedTarget = false;

    void Start()
    {
        SwitchToRedLight();
        Vector2 personTransform = personObj.transform.position;
    }

    void Update()
    {
        if (isRedLightActive && !objectReachedTarget)
        {
            MoveObjectTowardsTarget();
        }
    }

    void MoveObjectTowardsTarget()
    {
        personObj.transform.position = Vector2.MoveTowards(
            personObj.transform.position,
            targetPoint.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(personObj.transform.position, targetPoint.position) < 0.1f)
        {
            objectReachedTarget = true;
            SwitchToGreenLight();
        }
    }

    void SwitchToRedLight()
    {
        redLight.SetActive(true);
        greenLight.SetActive(false);
        personObj.SetActive(true);
        objectReachedTarget = false;
        isRedLightActive = true;
    }

    void SwitchToGreenLight()
    {
        redLight.SetActive(false);
        greenLight.SetActive(true);
        personObj.SetActive(false);
        isRedLightActive = false;

        Invoke("ResetAndSwitchToRed", 6f);
    }

    void ResetAndSwitchToRed()
    {
        personObj.transform.position = new Vector2(290.76f, -3.2f);
        SwitchToRedLight();
    }
}
