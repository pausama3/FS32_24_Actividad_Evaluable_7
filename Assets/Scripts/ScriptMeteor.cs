using UnityEngine;

public class ScriptMeteor : MonoBehaviour {
    [SerializeField] [Range(1, 10)] float speed = 5;
    private Camera mainCamera;
    bool onCamera = false;
    void Start() {
        mainCamera = Camera.main; // Obtener referencia a la cámara principal.
    }
    void Update() {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);

        NotifyMeteorPosition();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Shield" || collision.tag == "Earth") {
            transform.position = new Vector2(Random.Range(10, 15), 10);
        }
    }
    private void NotifyMeteorPosition() {
        // Convertir la posición del meteorito a coordenadas de la pantalla.
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Obtener el centro de la pantalla.
        float screenCenterX = Screen.width / 2;

        if (screenPosition.x > screenCenterX && !onCamera) {
            Debug.Log("El meteorito está a la DERECHA de la pantalla.");
        }
        else if (screenPosition.x < screenCenterX && !onCamera) {
            Debug.Log("El meteorito está a la IZQUIERDA de la pantalla.");
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "MainCamera") {
            onCamera = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "MainCamera") {
            onCamera = false;
        }
    }
}
