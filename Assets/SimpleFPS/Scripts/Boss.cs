using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anitor;
    public SC_NPCEnemy npc;
    //public SC_DamageReceiver dr;

    void Start()
    {
        
        anitor.GetComponent<Animator>();
        npc.GetComponent<SC_NPCEnemy>();

    }

    // Update is called once per frame
    void Update()
    {
        if (npc.npcHP <= 9999)
        {
            ThucDay();
            npc.movementSpeed = 5f;
        }
        //if (anitor.GetBool("ThucDay") == false)
        //{
        //    npc.movementSpeed = 0;
        //}
        //else 
        //{
        //    npc.movementSpeed = 5;
        //}
        
    }

    public void Bay() 
    {
        
        anitor.SetBool("Bay", true);
    }
    public void Chay()
    {
        npc.movementSpeed = 3;
        anitor.SetBool("Chay", true);
    }
    public void DiBo()
    {
        npc.movementSpeed = 2;
        anitor.SetBool("DiBo", true);
    }
    public void ThucDay()
    {
        anitor.SetBool("ThucDay", true);
        npc.movementSpeed = 3;

    }




}
