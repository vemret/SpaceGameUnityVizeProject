using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject,2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Ball ball = collision.GetComponent<Ball>();
        if(ball != null)
        {

            Destroy(gameObject);
        }

    }


}
