using TMPro;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public GameObject monedasActuales;
    [SerializeField]
    public GameObject tiempoActual;

    private float contadorTiempo; 
    void Start()
    {
        VariablesGlobales.contadorMonedas = 100;
        InvokeRepeating("IncrementarMonedas", 0f, 10f);
        contadorTiempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        monedasActuales.gameObject.GetComponent<TMP_Text>().text = VariablesGlobales.contadorMonedas.ToString();

        if (VariablesGlobales.vida > 0)
        {
            contadorTiempo += Time.deltaTime; // Incremento del tiempo transcurrido

            // Mostrar el tiempo acumulado en el formato "00:00" (minutos y segundos)
            int minutos = Mathf.FloorToInt(contadorTiempo / 60); // Obtener minutos
            int segundos = Mathf.FloorToInt(contadorTiempo % 60); // Obtener segundos

            tiempoActual.gameObject.GetComponent<TMP_Text>().text = $"{minutos:00}:{segundos:00}";
        }
    }
    private void IncrementarMonedas()
    {
        // Incrementar en 10 el contador de monedas
        VariablesGlobales.contadorMonedas += 10;
    }
}
