using UnityEngine;
using TMPro;

public class PKPoints : MonoBehaviour
{
    [SerializeField] GameObject yo;
    private void Start() {
       yo.GetComponent<TextMeshProUGUI>().text = VariablesGlobales.contadorMonedas.ToString();
    }
}
