using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Grab : MonoBehaviour
{
    public bool dragging = false;
    private bool isClicked = false;
    private bool isAnimating = false;
    private Vector3 offset;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Grabbing Object");
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        Debug.Log("Dropped Object");
        dragging = false;
    }

    private void OnMouseOver()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            anim.Play("GrowBig");
            Debug.Log("Mouse is over GameObject.");
        }
    }

    private void OnMouseExit()
    {
        if (isAnimating)
        {
            isAnimating = false;
            anim.Play("GrowSmall");
            Debug.Log("Mouse is no longer on GameObject.");
        }
        
    }
}


