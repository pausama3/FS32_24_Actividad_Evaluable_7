using TMPro;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public GameObject monedasActuales;
    [SerializeField]
    public GameObject tiempoActual;

    
    void Start()
    {
        VariablesGlobales.contadorMonedas = 100;
        InvokeRepeating("IncrementarMonedas", 0f, 2f);
        VariablesGlobales.tiempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        monedasActuales.gameObject.GetComponent<TMP_Text>().text = VariablesGlobales.contadorMonedas.ToString();

        if (VariablesGlobales.vida > 0)
        {
            VariablesGlobales.tiempo += Time.deltaTime; // Incremento del tiempo transcurrido

            // Mostrar el tiempo acumulado en el formato "00:00" (minutos y segundos)
            int minutos = Mathf.FloorToInt(VariablesGlobales.tiempo / 60); // Obtener minutos
            int segundos = Mathf.FloorToInt(VariablesGlobales.tiempo % 60); // Obtener segundos

            tiempoActual.gameObject.GetComponent<TMP_Text>().text = $"{minutos:00}:{segundos:00}";
        }
    }
    private void IncrementarMonedas()
    {
        // Incrementar en 10 el contador de monedas
        VariablesGlobales.contadorMonedas += 10;
    }
}
