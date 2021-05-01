using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    // private Rigidbody2D rb;
    public float speed;
    private bool moveRight = false;
    private float move = 1;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;

    // void Start()
    // {
    //     rb = this.GetComponent<Rigidbody2D>();
    // }

    // Update is called once per frame
    void FixedUpdate()
    {

        // go to right
        if (player.position.x > transform.position.x)
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

    // void OnTriggerEnter2D(Collider2D trigg)
    // {
    //     if (trigg.gameObject.CompareTag("turn"))
    //     {
    //         moveRight = !moveRight;
    //     }
    // }

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
