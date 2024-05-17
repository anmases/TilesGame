using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Sprite moving;
    public Sprite idle;
    private SpriteRenderer spriteRenderer;

    public float fallSpeed; // Velocidad de caída
    public float riseSpeed; // Velocidad de ascenso

    private bool active;
    private bool goingUp;
    private Vector3 initialPosition;

    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Captura la posición inicial
        active = false;
        goingUp = false;
    }
    private void Update()
    {
        if (!active)
        {
            spriteRenderer.sprite = idle;
            if(transform.position != initialPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, initialPosition, riseSpeed * Time.deltaTime);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
           
        }
        else
        {
            spriteRenderer.sprite = moving;
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (!goingUp)
            {
                transform.Translate(new Vector3(0.0f, -fallSpeed * Time.deltaTime, 0.0f));
            }
            else
            {
                transform.Translate(new Vector3(0.0f, riseSpeed * Time.deltaTime, 0.0f));
                
                if (transform.position.y >= initialPosition.y)
                {
                    goingUp = false; // Llegó a la posición inicial, detiene el movimiento ascendente
                }
            }
        }
    }

    public void Activate()
    {
        if (!active)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            // Descongela la posición y
        }
 
        active = true;
        
    }
    public void Disactivate()
    {
        active = false;
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "solid")
        {
            goingUp = true;
            
        }
        if (other.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }
}
