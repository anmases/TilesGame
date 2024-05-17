using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void RestartGame()
    {
        // Recarga la escena actual utilizando el �ndice de la escena actual.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {

#if UNITY_EDITOR
        // Si estamos en el editor de Unity, detenemos la reproducci�n.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si no estamos en el Editor, cierra la aplicaci�n.
        Application.Quit();
#endif

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
