using UnityEngine;

public class MushroomController : MonoBehaviour
{
    GameObject player;
    public string mushroomColor;
    public FenceController fence;
    public AudioClip mushroomTouch;
    AudioSource mushAudio;
    bool playerInRange;

    private InteractionController interactionController;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mushAudio = GetComponent<AudioSource>();
        mushAudio.clip = mushroomTouch;
    }

    void Start()
    {
        interactionController = FindObjectOfType<InteractionController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            if (interactionController != null)
            {
                interactionController.SetCurrentMushroom(this);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            if (interactionController != null && interactionController.GetCurrentMushroom() == this)
            {
                interactionController.SetCurrentMushroom(null);
            }
        }
    }

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }

    public void Interact()
    {
        if (playerInRange)
        {
            mushAudio.Play();
            fence.mushroomUpdate(mushroomColor);
        }
    }
}
