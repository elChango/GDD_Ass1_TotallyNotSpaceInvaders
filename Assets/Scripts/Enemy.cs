using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    private new SpriteRenderer renderer;

    public float xSpeed;
    public float ySpeed;

    public float speed;
    public float fireRate;
    public int health;
    public int points;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-xSpeed, -ySpeed);

        if(!renderer.isVisible)
        {
            Die(false);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().Damage();
            Die(true);
        }
    }

    void Die(bool updateScore)
    {
        Destroy(gameObject);

        if(updateScore)
        {
            GameObject obj = GameObject.FindWithTag("PointsHandler");
            if (obj != null)
            {
                PointsHandler pointsHandler = obj.GetComponent<PointsHandler>();
                if (pointsHandler != null)
                {
                    pointsHandler.AddScore(points);
                }

            }
        }
        
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Die(true);
        }
    }

}
