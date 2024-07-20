using UnityEngine;
using System.Collections;
using System;
public class FireflyController : MonoBehaviour
{
    public int heal = 250;
    GameObject player;
    PlayerHealth playerHealth;
    void Awake()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        //mendapatkan komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter(Collider other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            Heal();
        }
    }
    //Callback jika ada object yang keluar dari trigger

    void Heal()
    {
        playerHealth.currentHealth = Math.Min(playerHealth.currentHealth + heal, 1000);
        Destroy(gameObject);
    }
}