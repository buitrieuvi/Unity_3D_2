using UnityEngine;

public class SC_DamageReceiver : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public AudioSource aus;
    public AudioClip hit;
    public AudioClip heal;
    public AudioClip addBullet;
    public SC_CharacterController playerController;
    public SC_WeaponManager weaponManager;

    public void ApplyDamage(float points)
    {
        playerHP -= points;
        aus.PlayOneShot(hit);
        if (playerHP <= 0)
        {
            //Player is dead
            playerController.canMove = false;
            playerHP = 0;
        }
        
    }
    public void ApplyHeal(float points)
    {
        aus.PlayOneShot(heal);
        playerHP += points;
        
    }
    public void AddBulles()
    {
        aus.PlayOneShot(addBullet);

    }

}