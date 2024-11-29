using UnityEngine;
using UnityEngine.SceneManagement;

public class Juegos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Botón Atrás presionado"); // Confirmar la detección
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Minijuego1()
    {
        SceneManager.LoadScene("Game1");
    }public void Minijuego2()
    {
        SceneManager.LoadScene("Game2");
    }
}
