using UnityEngine;

public class CatAnimMainMenu : MonoBehaviour
{
    public Animator animator;

    public float idleTime = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= idleTime)
        {
            timer = 0f;

            int randomAnimation = Random.Range(0, 3);

            if (randomAnimation == 0)
            {
                animator.Play("Licking1");
            }
            else if (randomAnimation == 1)
            {
                animator.Play("Stretch");
            }
            else
            {
                animator.Play("Itch1");
            }
        }
    }
}