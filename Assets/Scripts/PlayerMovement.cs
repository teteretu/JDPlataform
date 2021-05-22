using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public Transform player;
    public Transform playerRespawnPoint;
    private int playerLife = 2;
    public Transform enemy;
    public Transform enemyRespawnPoint;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCroushing", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCroushing", false);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void Die()
    {
        StartCoroutine(waiter());
    }

    public IEnumerator waiter()
    {
        animator.SetBool("IsCroushing", true);

        yield return new WaitForSeconds(1);

        Debug.Log("life: " + playerLife);

        /*if (playerLife > 0)
        {*/
        playerLife -= 1;
        animator.SetBool("IsCroushing", false);
        player.transform.position = playerRespawnPoint.transform.position;
        enemy.transform.position = enemyRespawnPoint.transform.position;
        /*}
        else
        {
            Destroy(gameObject);
        }*/
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
