using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRespawn : MonoBehaviour
{
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TESTE");
    }

    void OnTriggerEnter2D(Collider2D trigg)
    {
        if (i == 0)
        {
            PlayerMovement playerMovement = trigg.GetComponent<PlayerMovement>();

            // if the player collider with Coin
            if (playerMovement != null)
            {
                respawnCoin();
                i++;
            }
        }
    }

    void OnTriggerExit2D(Collider2D trigg){
        PlayerMovement playerMovement = trigg.GetComponent<PlayerMovement>();
        if (i == 1) {
            // if the player collider with Coin
            if (playerMovement != null)
            {
                respawnCoin();
                i = 0;
            }
        }

    }

    void respawnCoin() 
    {
        Vector2 savedPosition = new Vector2(Random.Range(-12.0f, 20.0f), Random.Range(0.0f, 4.5f));

        gameObject.transform.position = savedPosition;
    }


}
