using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    private bool moveRight = false;
    private float move = 1;
    private Vector3 m_Velocity = Vector3.zero;
    private int enemyLife = 3;
    private Transform target = null;
    private float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {

        if( target != null ) {
            transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime ) ;
            // go to right
            if (target != null && target.position.x > transform.position.x)
            {
                move = 1;
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector3(4, 4);
            }
            else // go to left
            {
                move = -1;
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector3(-4, 4);
            }
            // transform.LookAt(Camera.main.transform.position, -Vector3.up);

            if (move > 0 && !moveRight)
            {
                Flip();
            }
            else if (move < 0 && moveRight)
            {
                Flip();
            }
        }
    }

    public void SetTarget(GameObject newTarget, float speed)
    {
        target = newTarget.transform;
        this.speed = speed;
    }

    public void Die()
    {
        if (animator.GetBool("IsDead")) {
            Destroy(gameObject);
        } else {
            animator.SetBool("IsDead", true);
            enemyLife -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D trigg)
    {
        PlayerMovement playerMovement = trigg.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            Destroy(gameObject);
            playerMovement.Die();
        }
    }

    private void Flip()
    {
        moveRight = !moveRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
