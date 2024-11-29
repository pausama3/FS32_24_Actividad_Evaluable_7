using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("CambiarEscena", 3f);
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
