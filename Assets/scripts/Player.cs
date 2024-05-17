using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int numBots;
    private bool jumping;
    private Rigidbody2D body;
    public float jumpForce = 0.10f;
    public float moveSpeed = 0.05f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject finish;
    public GameObject end;
    private bool canMove;
    // public AudioClip sonidoSaltar;
    // private AudioSource audioSource;


    void Start()
    {
        canMove = true;
        jumping = false;
        numBots = 0;
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        // audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canMove)
        {
            //Si se mueve, activa la animación.
            float horizontalInput = Input.GetAxis("Horizontal");
            bool isMoving = horizontalInput != 0;
            animator.SetBool("isMooving", isMoving);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (body != null && (!jumping || numBots < 2))
                {
                    jumping = true;
                    numBots++;
                    body.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            
            // Movimiento horizontal
            float move = 0.0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = false;
                move = -moveSpeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = true;
                move = moveSpeed;
            }
            transform.Translate(move, 0.0f, 0.0f);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Resetear saltos cuando toca una plataforma
        if (col.gameObject.CompareTag("solid") && col.contacts[0].normal.y > 0.5f) // Usar un umbral para la normal y
        {
            jumping = false;
            numBots = 0;
        }
        if(col.gameObject.CompareTag("killer") || col.gameObject.CompareTag("bullet"))
        {
            col.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetBool("isMooving", false);
            finish.SetActive(true);
            canMove = false;
            Debug.Log("GAME OVER");
        }
        if (col.gameObject.CompareTag("end"))
        {        
            animator.SetBool("isMooving", false);
            end.SetActive(true);
            canMove = false;
            Debug.Log("FINISH");
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            if (col.contacts[0].normal.y > 0.5f)
            {
                //Cae al vacío
                col.collider.enabled = false;
                //tras 2 segundos elimina al enemigo
                StartCoroutine(WaitAndDestroy(2, col.gameObject));
            }
            else
            {
                // si no, mata al player
                animator.SetBool("isMooving", false);
                finish.SetActive(true);
                canMove = false;
                Debug.Log("GAME OVER");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        // Resetear saltos cuando toca una plataforma
        if ((col.gameObject.CompareTag("solid") ||
            col.gameObject.CompareTag("obstacle") ||
            col.gameObject.CompareTag("platform")) &&
            col.contacts[0].normal.y > 0.5f) // Usar un umbral para la normal y
        {
            jumping = false;
            numBots = 0;
        }
    }
    IEnumerator WaitAndDestroy(float seconds, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        // Destruye este GameObject después de la espera
        Destroy(gameObject);
    }
}
