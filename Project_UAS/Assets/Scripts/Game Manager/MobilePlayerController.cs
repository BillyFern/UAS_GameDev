using UnityEngine;

public class MobilePlayerController : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;

    public Joystick joystick; // Reference to the Joystick script

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Use the joystick input for movement
        float h = joystick.Horizontal();
        float v = joystick.Vertical();

        Move(h, v);
        Turning(h, v);
        Animating(h, v);
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
}
