using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FenceController : MonoBehaviour
{
    int checker = 1;
    int red, blue, yellow, purple = 0;
    AudioSource audioGate;
    public AudioClip OpenDoor;
    public float doorSpeed = 3.0f; // Speed at which the door will move down
    public float doorLowerLimit = -8.0f; // Lower limit for the door position
    public TextMeshProUGUI objective2, objective3;

    void Awake()
    {
        audioGate = GetComponent<AudioSource>();
    }

    public void mushroomUpdate(string color)
    {
        if (IsCorrectNextColor(color))
        {
            switch (color)
            {
                case "red":
                    red += 1;
                    break;
                case "blue":
                    blue += 1;
                    break;
                case "purple":
                    purple += 1;
                    break;
                case "yellow":
                    yellow += 1;
                    break;
            }
            checker += 1;
        }
        else
        {
            resetChecker();
        }

        if (checker == 5)
        {
            checkSolution();
        }
    }

    bool IsCorrectNextColor(string color)
    {
        switch (checker)
        {
            case 1:
                return color == "red";
            case 2:
                return color == "blue";
            case 3:
                return color == "purple";
            case 4:
                return color == "yellow";
            default:
                return false;
        }
    }

    void checkSolution()
    {
        if (red == 1 && blue == 1 && purple == 1 && yellow == 1)
        {
            openDoor();
        }
        else
        {
            resetChecker();
        }
    }

    void openDoor()
    {
        audioGate.clip = OpenDoor;
        audioGate.Play();
        StartCoroutine(LowerDoor()); // Start the coroutine to lower the door
        objective2.enabled = true;
        objective3.enabled = true;
    }

    void resetChecker()
    {
        red = 0;
        blue = 0;
        yellow = 0;
        purple = 0;
        checker = 1;
        // Optionally, you can play a "wrong" sound or show feedback to the player here
        audioGate.Play(); // Assuming you have a sound to play for the wrong sequence
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
