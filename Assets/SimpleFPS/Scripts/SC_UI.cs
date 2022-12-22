using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SC_UI : MonoBehaviour
{
    public TMP_Text bl;
    public TMP_Text hp;
    public SC_DamageReceiver player;
    public SC_EnemySpawner enemy;
    public GameObject panel_tab;
    public GameObject panel_paule;
    public GameObject panel_dame;
    public TMP_Text time;
    public TMP_Text wave;
    public TMP_Text zomebies;

    bool pp = false;

    void Update()
    {
        bl.text = player.weaponManager.selectedWeapon.bulletsPerMagazine.ToString() +"/"+player.weaponManager.selectedWeapon.bulletsPerMagazineDefault.ToString();
        hp.text = player.playerHP.ToString() + " HP";

        int t = (int)enemy.newWaveTimer;
        time.text = t.ToString();

        zomebies.text = "Zombies: " + (enemy.enemiesToEliminate - enemy.enemiesEliminated).ToString();

        if (enemy.waitingForWave) 
        {
            wave.text = "Wave: " + enemy.waveNumber.ToString();
            
        }

        // tab
        if (Input.GetAxis("Tab") != 0)
            panel_tab.SetActive(true);
        else
            panel_tab.SetActive(false);

        // esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pp)
            {
                panel_paule.SetActive(true);
                pp = true;
                Time.timeScale = 0;
            }
            else 
            {
                panel_paule.SetActive(false);
                pp = false;
                Time.timeScale = 1;
            }
        }
        

        if (player.playerHP <= 20)
            panel_dame.SetActive(true);
        else
            panel_dame.SetActive(false);

    }
    


}
