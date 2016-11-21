using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject bossEnemy;
    public float timeBetweenSpawns;
    
	public int waveSize1;
    public int enemySpeed1;
    public int waveSize2;
    public int enemySpeed2;
    public int waveSize3;
    public int enemySpeed3;

    public int currentWave;

    public int enemyCount;

    private int currentSpeed;
    private GameObject bossEnemyClone;
    private GameObject enemyClone;
    private bool start;
    private GameController gameController;


    float timer;
    //bool spawned;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        currentWave = 1;
        gameController.SetCurrentWave(currentWave);
        enemyCount = 0;

        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenSpawns)
            {
                if (currentWave == 1)
                {
                    currentSpeed = enemySpeed1;
                    Spawn(waveSize1);
                } else if (currentWave == 2)
                {
                    currentSpeed = enemySpeed2;
                    Spawn(waveSize2);
                } else if (currentWave == 3)
                {
                    currentSpeed = enemySpeed3;
                    Spawn(waveSize3);

                } else if (currentWave == 4 && bossEnemyClone == null)
                {
                    gameController.Victory();
                }


            }
        }
    }

	void SpawnEnemy(int amount)
	{
		for (int i = 0; i < amount; i++) { 
		enemyClone = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
		NavMeshAgent enemyAgent = enemyClone.GetComponent<NavMeshAgent>();
		enemyAgent.speed = currentSpeed;
		
		}

		timer = 0f;
	}

    void SpawnBoss()
    {
        Debug.Log("Spawn boss");
        bossEnemyClone = (GameObject)Instantiate(bossEnemy, transform.position, transform.rotation);
        NavMeshAgent BossEnemyAgent = bossEnemyClone.GetComponent<NavMeshAgent>();
        BossEnemyAgent.speed = currentSpeed / 2;

        timer = 0f;
    }

    public void StartSpawn()
    {
        start = true;
    }


    void Spawn(int amount)
    {
        
        if ((enemyCount < amount) && bossEnemyClone == null)
        {
            SetCurrentWave();
            SpawnEnemy(amount);
            enemyCount++;
        }
        else if (bossEnemyClone == null && enemyClone == null)
        {
            SpawnBoss();
            currentWave += 1;
            enemyCount = 0;
        }
    }

    void SetCurrentWave()
    {
        gameController.SetCurrentWave(currentWave);
    }
}
