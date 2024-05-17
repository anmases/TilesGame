
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private float direction;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody;

    void Start()
    {
        direction = 0.010f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(direction > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }  
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector2(direction, 0.0f));
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            direction = -direction;
        }
        if (col.gameObject.CompareTag("killer"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            animator.speed = 0;
            direction = 0;
        }
    }
}