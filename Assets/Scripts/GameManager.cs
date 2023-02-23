using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float curEnemySpawnDelay;
    public float nextEnemySpawnDelay;

    public float curItmeSpawnDelay;
    public float maxItmeSpawnDelay;

    public GameObject player;
    public float gameScore = 0f;

    public GameObject[] Items;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        curEnemySpawnDelay += Time.deltaTime;
        if (curEnemySpawnDelay > nextEnemySpawnDelay)
        {
            SpawnEnemy();

            nextEnemySpawnDelay = Random.Range(0.5f, 3.0f);
            curEnemySpawnDelay = 0;
        }

        curItmeSpawnDelay += Time.deltaTime;
        if (curItmeSpawnDelay > maxItmeSpawnDelay)
        {
            SpawnItem();

            maxItmeSpawnDelay = Random.Range(2.0f, 5.0f);
            curItmeSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranType = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 7);
        GameObject goEnemy = Instantiate(enemyPrefabs[ranType], 
            spawnPoints[ranPoint].position, Quaternion.identity);
        Enemy enemyLogic = goEnemy.GetComponent<Enemy>();
        enemyLogic.playerObject = player;
        enemyLogic.Move(ranPoint);
    }

    void SpawnItem()
    {
        int ranNum = Random.Range(0, Items.Length);
        int ranNumb = Random.Range(0, 2);
        GameObject item = Instantiate(Items[ranNum],
            spawnPoints[ranNumb].position, Quaternion.identity);

    }

    public void MakeItem(GameObject enemy)
    {
        int ranNum = Random.Range(0, Items.Length);
        GameObject item = Instantiate(Items[ranNum],
            enemy.transform.position, Quaternion.identity);

    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 1.0f);
    }

    void AlivePlayer()
    {
        player.transform.position = Vector3.down * 4.2f;
        player.SetActive(true);
        Player playrLogic = player.GetComponent<Player>();
        player.GetComponent<PolygonCollider2D>().enabled = false;
        Invoke("collider_turnon", 3.0f);
    }

    void collider_turnon()
    {
        player.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
