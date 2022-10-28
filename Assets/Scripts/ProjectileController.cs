using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    int dir = 1;
    [SerializeField] private float speed = 4;
    [SerializeField] private int damage = 1;
    Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * dir, 0);
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeDirection()
    {
        dir *= -1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (dir == 1)
        {
            if (col.gameObject.CompareTag(ConstantsHelper.TAG_ENEMY))
            {
                col.gameObject.GetComponent<Enemy>().Damage(damage);
                Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag(ConstantsHelper.TAG_SHOOTING_ENEMY))
            {
                col.gameObject.GetComponent<ShootingEnemy>().Damage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerController>().Damage();
                Destroy(gameObject);
            }
        }
    }
}
