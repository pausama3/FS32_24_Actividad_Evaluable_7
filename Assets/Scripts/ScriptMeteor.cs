using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMeteor : MonoBehaviour {
    [SerializeField] [Range(1, 10)] float speed = 5;
    void Update() {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Shield") {
            transform.position = new Vector2(Random.Range(-10,10), 10);
            speed = Random.Range(3, 8);
        }
        if (collision.tag == "Earth") {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
