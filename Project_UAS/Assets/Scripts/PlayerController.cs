using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        //Mendapatkan komponen Animator
        anim = GetComponent<Animator>();

        //Mendapatkan komponen Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");

        //Mendapatkan nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning(v, -h);
        Animating(h, v);
    }
    //Method player dapat berjalan
    public void Move(float h, float v)
    {
        //Set nilai x dan y
        movement.Set(h, 0f, v);
        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;
        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    public void Turning(float h, float v)
    {
        // Check if the player is moving
        if (h != 0f || v != 0f)
        {
            // Set the movement direction
            Vector3 direction = new Vector3(h, 0f, v);

            // Calculate the rotation based on the movement direction
            Quaternion newRotation = Quaternion.LookRotation(direction);

            // Rotate the player
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool running = h != 0f || v != 0f;
        anim.SetBool("isRunning", running);
    }
}
