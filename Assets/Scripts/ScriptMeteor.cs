using UnityEngine;

public class ScriptMeteor : MonoBehaviour {
    [SerializeField] [Range(1, 10)] float speed = 7;
    [SerializeField] GameObject explosion;
    void Update() {
        Vector2 newPosition = Vector2.MoveTowards(transform.position , new Vector2(0, 0), Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Shield") {
            transform.position = new Vector2(Random.Range(-10,10), 10);
            speed = Random.Range(5, 12);
            Debug.Log("tengo moneda " + VariablesGlobales.contadorMonedas);
            VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas +1;
            Debug.Log("tengo moneda " + VariablesGlobales.contadorMonedas);
            explosion.GetComponent<AudioSource>().Play();
        }
    }
}
