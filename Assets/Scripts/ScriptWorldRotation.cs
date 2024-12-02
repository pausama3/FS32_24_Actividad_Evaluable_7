using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWorldRotation : MonoBehaviour {

    float current = 0;
    [SerializeField]
    float velocidad = 5;
    bool LimitL = false, LimitR = false;

    private void Start() {
        Input.gyro.enabled = true;
    }

    private void Update() {
        current = Input.acceleration.x;
        if (LimitL && current < 0) current = 0;
        if (LimitR && current > 0) current = 0;
        transform.Rotate(new Vector3(0, 0, -velocidad * current));

        if (Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene("MainMenu");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Limit") {
            if (collision.name == "LimitL") LimitL = true;
            if (collision.name == "LimitR") LimitR = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Limit") {
            if (collision.name == "LimitL") LimitL = false;
            if (collision.name == "LimitR") LimitR = false;
        }
    }
}
