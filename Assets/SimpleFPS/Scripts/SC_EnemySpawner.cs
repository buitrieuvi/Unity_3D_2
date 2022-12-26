using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public SC_DamageReceiver player;
    public Texture crosshairTexture;
    public float spawnInterval = 2;
    public int enemiesPerWave = 5; 
    public Transform[] spawnPoints;
    float nextSpawnTime = 0;
    public int waveNumber = 1;
    public bool waitingForWave = true;
    public float newWaveTimer = 2;
    public int enemiesToEliminate;
    public int enemiesEliminated = 0;
    int totalEnemiesSpawned = 0;

    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        waitingForWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveNumber == 7) 
        {
            //PlayerPrefs.SetInt("Score", SC_GameCtrl.Instance.Score);
            //PlayerPrefs.SetInt("Time", SC_GameCtrl.Instance.Time);
            SceneManager.LoadScene(scene + 1);
        }
        if (waitingForWave)
        {
            if(newWaveTimer >= 0)
            {
                newWaveTimer -= Time.deltaTime;
            }
            else
            {
                enemiesToEliminate = waveNumber * enemiesPerWave;
                enemiesEliminated = 0;
                totalEnemiesSpawned = 0;
                waitingForWave = false;
            }
        }
        else
        {
            if(Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnInterval;
                if(totalEnemiesSpawned < enemiesToEliminate)
                {
                    Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

                    GameObject enemy = Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
                    SC_NPCEnemy npc = enemy.GetComponent<SC_NPCEnemy>();
                    npc.playerTransform = player.transform;
                    npc.es = this;
                    totalEnemiesSpawned++;
                }
            }
        }

        if (player.playerHP <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }

       
    }

    void OnGUI()
    {
        if(player.playerHP <= 0)
        {
            GUI.Box(new Rect(Screen.width / 2 - 85, Screen.height / 2 - 20, 170, 40), "Game Over\n(Press 'Space' to Restart)");
        }
        else
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 3, Screen.height / 2 - 3, 6, 6), crosshairTexture);
        }

    }

    public void EnemyEliminated(SC_NPCEnemy enemy)
    {
        enemiesEliminated++;
        if(enemiesToEliminate - enemiesEliminated <= 0)
        {
            newWaveTimer = 10;
            waitingForWave = true;
            waveNumber++;
        }
    }
}