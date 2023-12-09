using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickController : MonoBehaviour
{
    private Transform startposition;
    private bool ismovement = true;

    [SerializeField]
    GameManager gameManager;


    private void Start()
    {
        startposition= this.transform;

    }
    private void OnMouseDrag()
    {
        if (ismovement)
        {
            transform.position = GetMousePos();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cup")
        {
            ismovement = false;
            this.transform.SetParent(collision.transform);
            gameManager.score=gameManager.score+1;
            gameManager.cafeisready = true;
        }
    }
    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

}
