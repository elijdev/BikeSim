using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PartPlacement : MonoBehaviour
{
    public BikePart bikePart;
    private float rayDistence = 1;
    private Vector2 boxCast_Size = new Vector2(1, 1);
    private void Update()
    {
        RaycastHit2D hitUp = Physics2D.BoxCast(transform.position, boxCast_Size,0,Vector2.up,rayDistence);
        if (hitUp.collider != null)
        {
            if (hitUp.transform.tag == bikePart.ToString())
            {
                hitUp.transform.position = transform.position;

                Debug.DrawRay(transform.position, Vector2.up * rayDistence, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.up * rayDistence, Color.green);
        }
    }




}

