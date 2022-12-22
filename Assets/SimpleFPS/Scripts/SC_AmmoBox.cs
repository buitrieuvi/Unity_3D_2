using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AmmoBox : MonoBehaviour
{

    public SC_Weapon[] Weapon;
    public SC_DamageReceiver scD;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i <= Weapon.Length - 1; i++) 
            {
                Weapon[i].bulletsPerMagazine = Weapon[i].fullBullet;
                Weapon[i].bulletsPerMagazineDefault = Weapon[i].fullBulletDefault;
            }
            scD.AddBulles();

        }
    }
}
