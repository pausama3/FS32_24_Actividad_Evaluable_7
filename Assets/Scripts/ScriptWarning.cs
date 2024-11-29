using UnityEngine;
using UnityEngine.UI;

public class ScriptWarning : MonoBehaviour {
    public bool isActive = false, pastActive = false;

    void Update() {
        Debug.Log("meteorito");
        if (isActive != pastActive) {
            Debug.Log("diferente");
            if (isActive) gameObject.GetComponent<Image>().color = Color.white;
            else gameObject.GetComponent<Image>().color = new Color(255,255,255,0);
        }
        pastActive = isActive;
    }
}
