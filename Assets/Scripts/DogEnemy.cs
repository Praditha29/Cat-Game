using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DogEnemy : MonoBehaviour
{
    public Transform player;
    private float speed = 0.40f;

    public Player playerScript;

    //for animation
    public Animator animator;


   
    private void FixedUpdate()
    {
        if (!playerScript.IsGameOver())
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.Translate(
                direction.x * speed,
                direction.y * speed,
                0
            );

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Flip dog
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
