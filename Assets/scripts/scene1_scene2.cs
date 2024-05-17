
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene1_scene2 : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Jugador"
        // Asegúrate de asignar la etiqueta "Jugador" a tu objeto jugador desde el editor de Unity
        if (col.gameObject.CompareTag("Player"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(nextScene);
        }
    }
}
