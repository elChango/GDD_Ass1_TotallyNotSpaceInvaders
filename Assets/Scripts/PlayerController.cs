using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int MAX_HEALTH = 3;
    public GameObject projectile;
    GameObject shipGun;
    public float speed = 5.0f;
    Rigidbody2D rb;
    public int health { get; private set; }

    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
         health = MAX_HEALTH;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shipGun = transform.Find("ShipGun").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Damage()
    {
        health--;
        healthBar.UpdateHealthBar();
        if(health==0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shipGun.transform.position, Quaternion.identity);
    }
}
