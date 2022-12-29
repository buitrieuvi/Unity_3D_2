using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Hp : MonoBehaviour
{
    SC_DamageReceiver player;

    void Start()
    {
        player = FindObjectOfType<SC_DamageReceiver>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject);
            player.ApplyHeal(25);
            MonoObjectPool.Instance.Spawn("Heal");

        }
    }
    void Update()
    {
        transform.Rotate(0, 0.5f, 0, Space.World);
    }
}
