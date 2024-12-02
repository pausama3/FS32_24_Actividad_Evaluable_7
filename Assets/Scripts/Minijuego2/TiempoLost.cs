using TMPro;
using UnityEngine;

public class TiempoLost : MonoBehaviour
{
    [SerializeField]
    private GameObject tiempo, tiempoRecord;

    private float tiempoConseguido;
    private float mejorTiempo;

    void Start()
    {
        // Cargar el tiempo conseguido y mostrarlo en formato mm:ss
        tiempoConseguido = VariablesGlobales.tiempo;
        tiempo.GetComponent<TMP_Text>().text = $"{Mathf.FloorToInt(tiempoConseguido / 60):00}:{Mathf.FloorToInt(tiempoConseguido % 60):00}";

        // Cargar el mejor tiempo desde PlayerPrefs
        mejorTiempo = PlayerPrefs.GetFloat("mejorTiempo", 0);

        // Si el tiempo conseguido es mayor al mejor tiempo, actualizar PlayerPrefs
        if (tiempoConseguido > mejorTiempo)
        {
            mejorTiempo = tiempoConseguido;
            PlayerPrefs.SetFloat("mejorTiempo", mejorTiempo);
            PlayerPrefs.Save();
        }

        // Mostrar el mejor tiempo en formato mm:ss
        tiempoRecord.GetComponent<TMP_Text>().text = $"{Mathf.FloorToInt(mejorTiempo / 60):00}:{Mathf.FloorToInt(mejorTiempo % 60):00}";
    }
}
