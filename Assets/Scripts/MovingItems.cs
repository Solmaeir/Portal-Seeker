using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItems : MonoBehaviour
{

    public float size = 5;
    public float speed=1;
    Vector2 target;
    Vector2 currentPos;
    bool isLeft=false;
    private void Start()
    {
        currentPos.x= transform.position.x;
    }
    private void Update()
    {
        if (isLeft)
        {
            target = new Vector2(-size, transform.position.y); 
        }
        else
        {
            target = new Vector2(size, transform.position.y); 
        }

        target += currentPos;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

       
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            isLeft = !isLeft; 
            
        }




    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.transform.SetParent(transform); 
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.transform.SetParent(null); 
        }
    }
}
