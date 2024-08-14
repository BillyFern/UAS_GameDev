using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    PlayerHealth playerHealth;
    GameObject play;

    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;

    void Awake()
    {
        // Find the game object with tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
        play = GameObject.FindGameObjectWithTag("Player");
        playerHealth = play.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.currentHealth > 0)
        {
            ChasePlayer();
        }
        else
        {
            this.enabled = false;
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Rotate towards the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
