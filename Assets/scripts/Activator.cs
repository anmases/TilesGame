using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject enemyGameObject;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy2 script = enemyGameObject.GetComponent<Enemy2>();
        if (other.gameObject.tag == "Player")
        {
            script.Activate();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Enemy2 script = enemyGameObject.GetComponent<Enemy2>();
        if (other.gameObject.tag == "Player")
        {
            script.Disactivate();
        }
    }
}
