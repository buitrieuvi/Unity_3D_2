using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public SC_DamageReceiver player;
    public Texture crosshairTexture;
    public float spawnInterval = 2;
    public int enemiesPerWave = 5; 
    public Transform[] spawnPoints;
    float nextSpawnTime = 0;
    public int waveNumber = 1;
    public int maxWaveNumber;
    public bool waitingForWave = true;
    public float newWaveTimer = 2;
    public int enemiesToEliminate;
    public int enemiesEliminated = 0;
    int totalEnemiesSpawned = 0;

    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        waitingForWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveNumber == maxWaveNumber) 
        {
            SC_GameCtrl.Instance.DiemLV();
            SC_UI.Instance.panel_over.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                SceneManager.LoadScene(scene + 1);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
            Time.timeScale = 0;
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
                    int randomNPC = Random.Range(0, enemyPrefab.Length);
                    GameObject enemy = Instantiate(enemyPrefab[randomNPC], randomPoint.position, Quaternion.identity);
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