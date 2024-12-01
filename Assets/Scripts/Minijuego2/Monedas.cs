using TMPro;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public GameObject monedasActuales;
    void Start()
    {
        VariablesGlobales.contadorMonedas = 100;
        InvokeRepeating("IncrementarMonedas", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        monedasActuales.gameObject.GetComponent<TMP_Text>().text = VariablesGlobales.contadorMonedas.ToString();
    }
    private void IncrementarMonedas()
    {
        // Incrementar en 10 el contador de monedas
        VariablesGlobales.contadorMonedas += 10;
    }
}
