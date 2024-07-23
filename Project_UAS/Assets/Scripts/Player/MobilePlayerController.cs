using UnityEngine;

public class MobilePlayerController : MonoBehaviour
{
    public float speed = 6f;
    public AudioClip walking;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private AudioSource audioSource;

    public Joystick joystick; // Reference to the Joystick script

    private float footstepInterval = 0.5f; // Interval between footstep sounds
    private float footstepTimer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Use the joystick input for movement
        float h = joystick.Horizontal();
        float v = joystick.Vertical();

        Move(h, v);
        Turning(h, v);
        Animating(h, v);

        // Handle footstep sounds
        if (h != 0f || v != 0f)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                PlayFootstepSound();
                footstepTimer = footstepInterval; // Reset the timer
            }
        }
        else
        {
            footstepTimer = 0f; // Reset the timer when not walking
        }
    }

    public void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    public void Turning(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            Vector3 direction = new Vector3(v, 0f, -h);
            Quaternion newRotation = Quaternion.LookRotation(direction);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool running = h != 0f || v != 0f;
        anim.SetBool("isRunning", running);
    }

    private void PlayFootstepSound()
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(walking);
    }
}
