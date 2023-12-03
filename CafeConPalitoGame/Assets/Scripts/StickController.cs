using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickController : MonoBehaviour
{
    private Transform startposition;


    private void Start()
    {
        startposition= this.transform;

    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cup")
        {
            this.transform.SetParent(collision.transform);
        }
    }
    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

}
