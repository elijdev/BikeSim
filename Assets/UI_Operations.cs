using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Operations : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    public GameObject lvl1;
    public GameObject lvl2;

    public void Open_Close ()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Open");
        }
        else
        {
            isOpen = false;
            animator.SetTrigger("Close");
        }
    }
    public void LVL1_Open()
    {
        lvl1.SetActive(true);
        lvl2.SetActive(false);
    }

    public void LVL2_Open()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(true);
    }
}

