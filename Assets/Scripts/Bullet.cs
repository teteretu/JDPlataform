using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D hide;

    // Start is called before the first frame update
    void Start()
    {
        hide.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();

        if (enemy != null)
        {
            enemy.Die();
            Destroy(gameObject);
            // gameObject.transform.position = enemyRespawnPoint.transform.position;

        }
    }

}
