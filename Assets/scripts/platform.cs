using System.Collections;
using UnityEngine;

public class platform : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
 
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            

        }
        if (col.gameObject.CompareTag("solid") || col.gameObject.CompareTag("killer"))
        {
            //Cae al vacío
            boxCollider.enabled = false;
            //tras 2 segundos elimina al enemigo
            StartCoroutine(WaitAndDestroy(2, gameObject));
        }
    }
    IEnumerator WaitAndDestroy(float seconds, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        // Destruye este GameObject después de la espera
        Destroy(gameObject);
    }
}
