using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawn : MonoBehaviour
{
    public Transform enemyRespawnPoint;
    public EnemyMovement enemy;
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("repeater", 1f, 3f);
        InvokeRepeating("increaseSpeed", 1f, 8f);
    }

    public void repeater()
    {
        (Instantiate(enemy, enemyRespawnPoint.position, enemyRespawnPoint.rotation)).SetTarget(player, speed);
    }
    
    private void increaseSpeed() {
        speed += 0.2f;
    }
}
