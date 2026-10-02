using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DogEnemy : MonoBehaviour
{
    public Transform player;
    public float speed;

    public Player playerScript;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            speed = 0;
        }
    }
}
