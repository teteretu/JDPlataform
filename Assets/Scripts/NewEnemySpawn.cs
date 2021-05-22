using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawn : MonoBehaviour
{
    public Transform enemyRespawnPoint;
    public EnemyMovement enemy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("repeater", 1f, 3f);
    }

    public void repeater()
    {
        Debug.Log("call instantiate");
        (Instantiate(enemy, enemyRespawnPoint.position, enemyRespawnPoint.rotation)).SetTarget(player);
    }
}
