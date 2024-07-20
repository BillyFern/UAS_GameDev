using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    bool inPlayerRange;
    public string mushroomColor;
    public FenceController fence;
    public AudioClip mushroomTouch;
    AudioSource mushAudio;
    bool playerInRange;

    void Awake()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        mushAudio = GetComponent<AudioSource>();
        mushAudio.clip = mushroomTouch;
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter(Collider other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    //Callback jika ada object yang keluar dari trigger

    void OnTriggerExit(Collider other)
    {
        //Set player not in range
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            mushAudio.Play();
            fence.mushroomUpdate(mushroomColor);
        }

    }
}
