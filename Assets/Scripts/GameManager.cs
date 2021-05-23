using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool paused = false;
    public Transform coin;
    public Transform coinRespawnPoint;


    void Start()
    {
        Instantiate(coin, coinRespawnPoint.position, coinRespawnPoint.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Calling");
            if (paused)
            {
                paused = false;
                ResumeGame();
            } else
            {
                paused = true;
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
