using UnityEngine;

public class ScriptMeteor : MonoBehaviour {
    [SerializeField] [Range(1, 10)] float speed = 5;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main; // Obtener referencia a la c�mara principal.
    }
    void Update() {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);

        NotifyMeteorPosition();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        transform.position = new Vector2(Random.Range(10, 15), 10);
    }
    private void NotifyMeteorPosition()
    {
        // Convertir la posici�n del meteorito a coordenadas de la pantalla.
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Obtener el centro de la pantalla.
        float screenCenterX = Screen.width / 2;

        if (screenPosition.x > screenCenterX)
        {
            Debug.Log("El meteorito est� a la DERECHA de la pantalla.");
        }
        else if (screenPosition.x < screenCenterX)
        {
            Debug.Log("El meteorito est� a la IZQUIERDA de la pantalla.");
        }
    }
}
