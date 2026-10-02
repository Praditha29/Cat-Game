using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FixedJoystick joystick;
    public float speed;

    // input from joystick
    float horizontalInput, verticalInput;

    int score = 0;
    public GameObject WinText;
    public int WinScore;

    //for animation
    public Animator animator;

    private void FixedUpdate()
    {
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

            if (score >= WinScore) {
                WinText.SetActive(true);
                Debug.Log("You win!");
            }

        }
        if (collision.gameObject.tag == "Dog")
        {
            Debug.Log("Dog ate you!");
        }

    }


    public bool IsGameOver()
    {
        return score >= 2;
    }
}
    