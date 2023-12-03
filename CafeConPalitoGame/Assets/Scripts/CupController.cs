using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CupController : MonoBehaviour
{
    public bool isready =false;


    private void OnMouseDrag()
    {
        if (isready)
        {
            transform.position = GetMousePos();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isready && collision.gameObject.tag=="Table")
        {
            isready = false;
        }
    }
    private Vector2 GetMousePos() 
    { 
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
