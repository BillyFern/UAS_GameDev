using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public AudioClip hurtClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public GameOverScreen gameOverScreen;
    bool isDead = false;

    public float healthDecreaseInterval = 5f; // Interval in seconds
    public int healthDecreaseAmount = 10; // Amount of health to decrease every interval


    Animator anim;
    AudioSource playerAudio;
    PlayerController playerMovement;
    //PlayerShooting playerShooting;
    bool damaged;
    float timer;

    void Awake()
    {
        //Mendapatkan refernce komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerController>();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        timer = healthDecreaseInterval; // Initialize the timer
    }

    void Update()
    {
        if (isDead) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            currentHealth -= healthDecreaseAmount;
            healthSlider.value = currentHealth;
            timer = healthDecreaseInterval; // Reset the timer
        }

        //Jika terkena damaage
        if (damaged)
        {
            //Merubah warna gambar menjadi value dari flashColour
            damageImage.color = flashColour;
            anim.SetTrigger("isHurt");
        }
        else
        {
            //Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //Set damage to false
        damaged = false;
        if (currentHealth <= 0 && isDead == false)
        {
            Death();
            isDead = true;
        }
    }

    //fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        damaged = true;
        //mengurangi health
        currentHealth -= amount;
        //Merubah tampilan dari health slider
        healthSlider.value = currentHealth;
        //Memainkan suara ketika terkena damage
        playerAudio.clip = hurtClip;
        playerAudio.volume = 1f;
        playerAudio.Play();
        //Memanggil method Death() jika darahnya kurang dari sama dengan 10 dan belum mati
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //Memainkan suara ketika mati
        playerAudio.clip = deathClip;
        playerAudio.volume = 1f;
        playerAudio.Play();
        //mematikan script player movement
        playerMovement.enabled = false;
        gameOverScreen.Setup();

        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(2f);

        // Load the desired scene
        SceneManager.LoadScene("GameOver"); // Replace "YourSceneName" with the actual name of the scene you want to load
    }
}