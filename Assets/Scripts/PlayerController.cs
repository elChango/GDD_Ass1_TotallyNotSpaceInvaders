using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    GameObject shipGun;
    public float speed = 5.0f;
    Rigidbody2D rb;
    public int health { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
         health = ConstantsHelper.MAX_PLAYER_HEALTH;
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

        GameObject obj = GameObject.FindWithTag(ConstantsHelper.TAG_HEALTHBAR);
        if (obj != null)
        {
            HealthBarController healthBar = obj.GetComponent<HealthBarController>();
            if (healthBar != null)
            {
                healthBar.UpdateHealthBar(health);
            }
        }
        
        if(health==0)
        {
            EndGame();
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shipGun.transform.position, Quaternion.identity);
    }

    private void EndGame()
    {
        //disable UI for the end of the game
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(ConstantsHelper.TAG_GAME_OVER_UI))
        {
            obj.SetActive(true);
        }
    }
}
