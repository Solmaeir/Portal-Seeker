using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isOpen;
    public float closedY = 5f;
    public float openedY = 9.5f;
    public float speed = 2f;

    private bool isMoving = false;
    private float targetY;


    void Update()
    {
        if (isMoving)
        {
           
            float newY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

          
            if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

    private void StartMoving()
    {
       
        targetY = isOpen ? openedY : closedY;
        isMoving = true;
    }

    public void OpenGate()
    {
        isOpen = true; 
        StartMoving();
    }

    public void CloseGate()
    {
        isOpen = false; 
        StartMoving();
    }
}
