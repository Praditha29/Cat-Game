using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    public FixedJoystick joystick;
    public float speed;

    // input from joystick
    float horizontalInput, verticalInput;

    int score = 0;
    public GameObject WinText;
    public GameObject LoseText;
    public int WinScore;

    //for animation
    public Animator animator;

    //to keep a count of fishes
    private int totalFishes;
    public TextMeshProUGUI fishNumber;


    //to play sound effects
    AudioManager audioManager;

    //to access audio and its components
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void FixedUpdate()
    {
        Debug.Log("Speed: " + speed);
        //gives movement from joystick and moves in that speed
        horizontalInput = joystick.Horizontal * speed;
        verticalInput = joystick.Vertical * speed;

        //to actually move the player
        transform.Translate(horizontalInput, verticalInput, 0);

        // Flip the cat based on horizontal movement
        if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Check if joystick is being moved
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            score++;
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.CatEat);

            UpdateFishCounter();

            if (totalFishes - score <= 0) {
                WinText.SetActive(true);
                Debug.Log("You win!");
                speed = 0;
                audioManager.PlaySFX(audioManager.WinMeow);

            }

        }
        if (collision.gameObject.tag == "Dog")
        {
            LoseText.SetActive(true);
            Debug.Log("Dog ate you!");
            animator.SetBool("isRunning", false );
            speed = 0;
            audioManager.PlaySFX(audioManager.LoseMeow);
            audioManager.PlaySFX(audioManager.DogBark);
        }

    }

    void UpdateFishCounter()
    {
        int remainingFishes = totalFishes - score;
        fishNumber.text = remainingFishes.ToString();

    }

    private void Start()
    {
        totalFishes = GameObject.FindGameObjectsWithTag("Fish").Length;

        UpdateFishCounter();
    }

    public bool IsGameOver()
    {
        return score >= totalFishes;
    }
}
    