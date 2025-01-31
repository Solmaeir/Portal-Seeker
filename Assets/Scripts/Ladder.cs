using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
   
    [SerializeField] bool isPlayerOn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            collision.gameObject.GetComponent<PlayerInput>().onLadder = true;
            isPlayerOn = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInput>().onLadder = false;
            isPlayerOn = false;

        }
    }
}
