using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldHealth : MonoBehaviour {
    [SerializeField] GameObject healthBar;
    int health = 5;
    private void Update() {
        VariablesGlobales.contadorMonedas = 0;
        if (health <= 0) {
            SceneManager.LoadScene("LosePlanetKeeper");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Meteor") health--;
        healthBar.GetComponent<Slider>().value = health;
    }
}
