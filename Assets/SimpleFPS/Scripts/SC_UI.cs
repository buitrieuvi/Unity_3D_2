using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SC_UI : MonoSingleton<SC_UI>
{

    public TMP_Text bl;
    public TMP_Text hp;
    public SC_DamageReceiver player;
    public SC_EnemySpawner enemy;
    public GameObject panel_tab;
    public GameObject panel_paule;
    public GameObject panel_dame;
    public GameObject panel_over;
    public GameObject panel_gameover;
    public TMP_Text total;
    public TMP_Text time;
    public TMP_Text wave;
    public TMP_Text Score;
    public TMP_Text zomebies;
    public static bool pp = false;
    public bool pause = false;


    IEnumerator count() 
    {
        pp = true;
        time.text = SC_GameCtrl.Instance.Time++.ToString() +" S";
        yield return new WaitForSeconds(1f);
        pp = false;
    }


    void Start()
    {
        pp = false;
    }
    void Update()
    {

        if (!pp)
            StartCoroutine(count());

        bl.text = player.weaponManager.selectedWeapon.bulletsPerMagazine.ToString() + "/" + player.weaponManager.selectedWeapon.bulletsPerMagazineDefault.ToString();
        hp.text = player.playerHP.ToString() + " HP";

        zomebies.text = "Zombies: " + (enemy.enemiesToEliminate - enemy.enemiesEliminated).ToString();

        if (enemy.waitingForWave) 
        {
            wave.text = "Wave: " + enemy.waveNumber.ToString();
            
        }
        
        // tab
        if (Input.GetAxis("Tab") != 0) 
        {
            panel_tab.SetActive(true);
            Score.text = "Score: "+ SC_GameCtrl.Instance.Score.ToString();
        }
        else
            panel_tab.SetActive(false);

        // esc
        if (Input.GetKeyDown(KeyCode.Escape) && player.playerHP > 0)
        {
            if (!pause)
            {
                panel_paule.SetActive(true);
                pause = true;
                Time.timeScale = 0;
               
            }
            else 
            {
                panel_paule.SetActive(false);
                pause = false;
                Time.timeScale = 1;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Return) && pause)
        {
            SceneManager.LoadScene(0);
        }

        if (player.playerHP <= 20)
            panel_dame.SetActive(true);
        else 
            panel_dame.SetActive(false);

        if (player.playerHP <= 0) 
        {
            Time.timeScale = 0;
            panel_gameover.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
        total.text = "Total: " + PlayerPrefs.GetInt("score").ToString();
    }
}
