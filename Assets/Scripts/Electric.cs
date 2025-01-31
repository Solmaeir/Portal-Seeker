using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    Collider2D electricWire;
    public bool isPlayerIn=false;
    private void Start()
    {
        electricWire = GetComponent<Collider2D>();  

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerIn = true;
            ReloadScene.Reload();
        
        }
    }
}
