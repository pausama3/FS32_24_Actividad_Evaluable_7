using UnityEngine;

public class CreadorDeEnemigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject mago,arquero,caballero,espadachin;

    [SerializeField]
    private GameObject posicion1,posicion2;
    // Lista para almacenar enemigos y posiciones
    private GameObject[] enemigos;
    private GameObject[] posiciones;

    void Start()
    {
        // Inicializar las listas
        enemigos = new GameObject[] { mago, arquero, caballero, espadachin };
        posiciones = new GameObject[] { posicion1, posicion2 };

        // Invocar la creación repetitiva de enemigos cada 10 segundos
        InvokeRepeating("InstanciarEnemigoAleatorio", 0f, 6f);
    }

    void InstanciarEnemigoAleatorio()
    {
        // Seleccionar un enemigo aleatorio
        int indiceEnemigo = Random.Range(0, enemigos.Length);
        GameObject enemigoSeleccionado = enemigos[indiceEnemigo];

        // Seleccionar una posición aleatoria
        int indicePosicion = Random.Range(0, posiciones.Length);
        GameObject posicionSeleccionada = posiciones[indicePosicion];

        // Instanciar el enemigo en la posición seleccionada
        if (enemigoSeleccionado != null && posicionSeleccionada != null)
        {
            Instantiate(enemigoSeleccionado, posicionSeleccionada.transform.position, Quaternion.identity);
        }
    }
}
