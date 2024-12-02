using UnityEngine;
using TMPro;

public class PKPoints : MonoBehaviour
{
    [SerializeField] GameObject yo;
    private void Start() {
       yo.gameObject.GetComponent<TMP_Text>().text = VariablesGlobales.contadorMonedas.ToString();
    }
}
