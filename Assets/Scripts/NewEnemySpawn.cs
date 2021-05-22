using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawn : MonoBehaviour
{
    public Transform enemyRespawnPoint;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator waiter()
    {
        yield return new WaitForSeconds(10);

        Instantiate(enemy, enemyRespawnPoint.position, enemyRespawnPoint.rotation);
    }
}
