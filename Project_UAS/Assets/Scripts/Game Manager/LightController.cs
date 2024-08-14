using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light lightSource; // The light component to be modified

    int intensity;
    PlayerHealth playerHealth;
    public GameObject player;

    void Awake()
    {
        lightSource = GetComponent<Light>();
        //mendapatkan komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        intensity = playerHealth.currentHealth / 20;
        lightSource.intensity = intensity;
    }
}
