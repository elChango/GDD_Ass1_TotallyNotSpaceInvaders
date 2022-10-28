using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject homingMissile;
    GameObject shipGun;
    [SerializeField] private float speed = 5.0f;
    Rigidbody2D rb;
    public int health { get; private set; }
    private float fireDelay;

    // Start is called before the first frame update
    void Start()
    {
        health = ConstantsHelper.MAX_PLAYER_HEALTH;
        fireDelay = 5;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shipGun = transform.Find("ShipGun").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        fireDelay += Time.deltaTime;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && fireDelay > 2)
        {
            ShootMissile();
            fireDelay = 0;
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

    void ShootProjectile()
    {
        Instantiate(projectile, shipGun.transform.position, Quaternion.identity);
    }

    void ShootMissile()
    {
        Instantiate(homingMissile, shipGun.transform.position, Quaternion.identity);
    }

    private void EndGame()
    {
        SceneManager.LoadScene(ConstantsHelper.SCENE_GAME_OVER);
    }
}
