using UnityEngine;

public class ScriptWorldRotation : MonoBehaviour {

    private void Start() {
        Input.gyro.enabled = true;
    }

    private void Update() {
        transform.rotation = Quaternion.Euler(0, 0, Input.gyro.attitude.x *180);
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
