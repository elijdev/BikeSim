using UnityEngine;

public class Stoplight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;

    public GameObject[] animatedObjects;
    public float redLightDuration = 5f;
    public float greenLightDuration = 5f;

    private float timer;
    private bool isRedLightActive = true;

    void Start()
    {
        SwitchLights(isRedLightActive);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isRedLightActive && timer >= redLightDuration)
        {
            isRedLightActive = false;
            SwitchLights(isRedLightActive);
        }
        else if (!isRedLightActive && timer >= greenLightDuration)
        {
            isRedLightActive = true;
            SwitchLights(isRedLightActive);
        }
    }

    void SwitchLights(bool redLightOn)
    {
        redLight.SetActive(redLightOn);
        greenLight.SetActive(!redLightOn);
        timer = 0f;

        if (redLightOn)
        {
            ActivateObjects();
        }
        else
        {
            DeactivateObjects();
        }
    }

    void ActivateObjects()
    {
        foreach (GameObject obj in animatedObjects)
        {
            obj.SetActive(true);
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("CarLargetoSmall");
            }
        }
    }

    void DeactivateObjects()
    {
        foreach (GameObject obj in animatedObjects)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                StartCoroutine(WaitForAnimationEnd(animator, obj));
            }
        }
    }

    System.Collections.IEnumerator WaitForAnimationEnd(Animator animator, GameObject obj)
    {
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        obj.SetActive(false);
    }
}
