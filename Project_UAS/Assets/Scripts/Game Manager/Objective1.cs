using UnityEngine;
using TMPro;

public class Objective1 : MonoBehaviour
{
    public GameObject player;
    public GameObject gate;
    public float activationDistance = 5.0f; // Set the distance at which the UI will activate
    private TextMeshProUGUI uiText;

    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        uiText = GetComponent<TextMeshProUGUI>();

        // Ensure the UI Text is initially hidden
        uiText.enabled = false;
    }

    void Update()
    {
        // Calculate the distance between the player and the gate
        float distance = Vector3.Distance(player.transform.position, gate.transform.position);

        // If the player is within the activation distance, show the UI Text
        if (distance <= activationDistance)
        {
            uiText.enabled = true;

            // Once the text is enabled, disable this script
            this.enabled = false;
        }
    }
}
