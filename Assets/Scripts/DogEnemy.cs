using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DogEnemy : MonoBehaviour
{
    public Transform player;
    public float speed;

    public Player playerScript;

    //for animation
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        // Keep chasing until the game is over
        if (!playerScript.IsGameOver())
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * 0.01f
            );

            //running animation for dog
            animator.SetBool("isRunning", true);
        }
        if (playerScript.IsGameOver())
        { 
            animator.SetBool("isRunning", false);
        }

        // Flip dog based on player's position
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            speed = 0;
            animator.SetBool("isRunning", false);
            animator.Play("Dog_idle");
            Debug.Log("He ate them!");
        }
    }
}
