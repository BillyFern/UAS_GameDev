using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{
    int checker = 1;
    int red, blue, yellow, purple = 0;
    AudioSource audioGate;
    public AudioClip OpenDoor;
    public float doorSpeed = 3.0f; // Speed at which the door will move down
    public float doorLowerLimit = -8.0f; // Lower limit for the door position

    void Awake()
    {
        audioGate = GetComponent<AudioSource>();
    }

    public void mushroomUpdate(string color)
    {
        switch (color)
        {
            case "red":
                red += checker;
                break;
            case "blue":
                blue += checker;
                break;
            case "purple":
                purple += checker;
                break;
            case "yellow":
                yellow += checker;
                break;
        }
        checker += 1;

        if (checker == 5)
        {
            openDoor();
        }
    }

    void openDoor()
    {
        if (red == 1 && blue == 2 && purple == 3 && yellow == 4)
        {
            audioGate.clip = OpenDoor;
            audioGate.Play();
            StartCoroutine(LowerDoor()); // Start the coroutine to lower the door
        }
        else
        {
            audioGate.Play();
            red = 0;
            blue = 0;
            yellow = 0;
            purple = 0;
            checker = 1;
        }
    }

    IEnumerator LowerDoor()
    {
        while (transform.position.y > doorLowerLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - doorSpeed * Time.deltaTime, transform.position.z);
            yield return null; // Wait for the next frame
        }
    }
}
