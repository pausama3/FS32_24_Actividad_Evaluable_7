using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWorldRotation : MonoBehaviour {

    float current = 0;

    private void Start() {
        Input.gyro.enabled = true;
    }

    private void Update() {
        current = Input.acceleration.x;
        Debug.Log(Input.acceleration);
        if (current >= 0) {
            transform.Rotate(new Vector3(0, 0, -0.1f));
        } else {
            transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            SceneManager.LoadScene("MainMenu");
        }
    }
    /*Vector3 rot;
    float currentDir;
    private void Start() {
        rot = Vector3.zero;
        Input.gyro.enabled = true;
        currentDir = 0;
    }
    void Update() {
        //Input.gyro.attitude.z
        rot = Quaternion.ToEulerAngles(Input.gyro.attitude);
        //currentDir = Input.gyro.rotationRateUnbiased.z;
        rot.z = currentDir > 0 ? 0.3f : -0.3f;
        Debug.Log(rot.z);
        transform.Rotate(rot);
    }*/

}
