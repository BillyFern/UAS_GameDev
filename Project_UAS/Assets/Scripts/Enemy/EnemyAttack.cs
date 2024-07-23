using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 25;
    public GameObject attackSoundPlayerPrefab; // Prefab with AudioSource for playing sound

    private GameObject player;
    private PlayerHealth playerHealth;
    private bool playerInRange;
    private float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);

            // Instantiate the sound player and play the attack sound
            GameObject soundPlayer = Instantiate(attackSoundPlayerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();
            audioSource.Play();

            // Destroy the sound player after the clip length
            Destroy(soundPlayer, audioSource.clip.length);

            // Destroy the enemy object immediately
            Destroy(gameObject);
        }
    }
}
