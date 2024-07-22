using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public Button interactionButton; // Reference to the UI Button
    private MushroomController currentMushroom; // Reference to the current MushroomController

    private void Start()
    {
        if (interactionButton != null)
        {
            interactionButton.onClick.AddListener(OnInteractionButtonClicked);
        }
    }

    private void OnInteractionButtonClicked()
    {
        // Call the interaction method if the current mushroom is set and the player is in range
        if (currentMushroom != null && currentMushroom.IsPlayerInRange())
        {
            currentMushroom.Interact();
        }
    }

    public void SetCurrentMushroom(MushroomController mushroom)
    {
        currentMushroom = mushroom;
    }

    public MushroomController GetCurrentMushroom()
    {
        return currentMushroom;
    }

}
