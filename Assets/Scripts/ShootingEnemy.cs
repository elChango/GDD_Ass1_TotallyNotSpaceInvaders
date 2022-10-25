using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    Rigidbody2D rb;
    private new SpriteRenderer renderer;
    private GameObject gun;

    [SerializeField] private int fireRate;
    [SerializeField] private GameObject projectile;
    private int fireDelay;

    // Start is called before the first frame update
    void Start()
    {
        fireDelay = fireRate;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        gun = transform.Find(ConstantsHelper.ENEMY_GUN).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-xSpeed, -ySpeed);

        if(!renderer.isVisible)
        {
            base.Die(false);
        }

        if(fireRate > 0 && fireDelay == 0) 
        {
            Shoot();
            fireDelay = fireRate;
        } else if (fireRate > 0)
        {
            fireDelay--;
        }
    }

    void Shoot()
    {
        GameObject shotProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        shotProjectile.GetComponent<ProjectileController>().ChangeDirection();
    }

}
