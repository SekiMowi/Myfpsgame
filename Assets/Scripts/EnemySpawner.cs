using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //variables
    public int enemyCount;
    public float spawnCoolDown = 3f;
    public float spawnCoolDownReduction = 25f;

    public Transform[] spawnPoints;
    public GameObject enemy;
    private IEnumerator spawnCorountine;//to stop coruntine
    
    // Start is called before the first frame update
    void Start()
    {
        //starts corountines
        spawnCorountine = FasterSpawns();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(spawnCorountine);
    }

    // Update is called once per frame
    void Update()
    {
        //if spawnCoolDown is less than 1 stop spawnCorountine
        if(spawnCoolDown <= 1f)
            StopCoroutine(spawnCorountine);
    }
    //instantiate enemy to one of 4 spawn points
    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, 4)].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnCoolDown);
        StartCoroutine(SpawnEnemy());
    }
    //every spawnCoolDownReductions value reduce spawnCoolDowns value by .5
    IEnumerator FasterSpawns()
    {
        yield return new WaitForSeconds(spawnCoolDownReduction);
        spawnCoolDown -= 0.5f;
        StartCoroutine(spawnCorountine);
    }
}
