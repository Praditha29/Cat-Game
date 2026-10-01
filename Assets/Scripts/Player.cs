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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //gives movement from joystick and moves in that speed
        horizontalInput = joystick.Horizontal * speed;
        verticalInput = joystick.Vertical * speed;

        //to actually move the player
        transform.Translate(horizontalInput, verticalInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            score++;
            Destroy(collision.gameObject);

            if (score >= 0) {
                WinText.SetActive(true);
                Debug.Log("You win!");
            }

        }
    }
}
    