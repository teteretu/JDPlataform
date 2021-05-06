using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed;
    public Animator animator;
    private bool moveRight = false;
    private float move = 1;
    private Vector3 m_Velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {

        // go to right
        if (player != null && player.position.x > transform.position.x)
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

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !moveRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && moveRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    public void Die()
    {
        if (animator.GetBool("IsDead"))
        {
            Destroy(gameObject);
        }
        else
        {
            animator.SetBool("IsDead", true);
        }
    }

    void OnTriggerEnter2D(Collider2D trigg)
    {
        PlayerMovement playerMovement = trigg.GetComponent<PlayerMovement>();
        Debug.Log("trigger player entered: " + playerMovement);

        if (playerMovement != null)
        {
            playerMovement.Die();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        moveRight = !moveRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
