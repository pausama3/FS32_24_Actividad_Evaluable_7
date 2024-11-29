using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWorldRotation : MonoBehaviour {

    float current = 0;
    [SerializeField]
    float velocidad = 5;

    private void Start() {
        Input.gyro.enabled = true;
    }

    private void Update() {
        current = Input.acceleration.x;
   
        
            transform.Rotate(new Vector3(0, 0, -velocidad*current));
        
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
