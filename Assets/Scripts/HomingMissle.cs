using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    private Rigidbody2D missile;
    private Rigidbody2D targetedEnemy = null;

    // Start is called before the first frame update
    void Awake()
    {
        missile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy == null || !targetedEnemy.gameObject.activeSelf)
        {
            lockOntoEnemy();
        }

        if(targetedEnemy == null)
        {
            //no enemeies found, destroy itself
            Destroy(gameObject);
            return;
        }
             

        transform.position = Vector2.MoveTowards(missile.position, targetedEnemy.position, speed * Time.deltaTime);
    }

    private void lockOntoEnemy()
    {
        //already locked onto enmy
        if (targetedEnemy != null)
        {
            return;
        }

        List<GameObject> enemies = new(GameObject.FindGameObjectsWithTag(ConstantsHelper.TAG_ENEMY));
        enemies.AddRange(GameObject.FindGameObjectsWithTag(ConstantsHelper.TAG_SHOOTING_ENEMY));
        int length = enemies.Count;
        if (length > 0)
        {
            int randomEnemyIndex = Random.Range(0, length);
            targetedEnemy = enemies[randomEnemyIndex].GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("got collison with " + col);
        if (col.gameObject.CompareTag(ConstantsHelper.TAG_ENEMY))
        {
            col.gameObject.GetComponent<Enemy>().Damage(5);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag(ConstantsHelper.TAG_SHOOTING_ENEMY))
        {
            col.gameObject.GetComponent<ShootingEnemy>().Damage(5);
            Destroy(gameObject);
        }
    }


}
