using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldHealth : MonoBehaviour {
    [SerializeField] GameObject healthBar;
    int health = 5;

    void Start()
    {
        VariablesGlobales.contadorMonedas = 0;
    }
    private void Update() {
        
        if (health <= 0) {
            SceneManager.LoadScene("LosePlanetKeeper");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Meteor") health--;
        healthBar.GetComponent<Slider>().value = health;
    }
}
