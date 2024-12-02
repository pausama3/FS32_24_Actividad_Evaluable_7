using UnityEngine;

public class CreadorDeEnemigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Lista para almacenar enemigos y posiciones
    
    [SerializeField] private GameObject[] posiciones;
    [SerializeField] private GameObject magos;
    [SerializeField] private GameObject arqueros;
    [SerializeField] private GameObject espadachines;
    [SerializeField] private GameObject caballeros;

    private int[] posRR;
    
    private int pRR;

    void Start()
    {        
        posRR= new int[4];
        for (int i = 0; i < magos.transform.childCount; i++)
        {
            magos.transform.GetChild(i).gameObject.GetComponent<EnemigoMago>().enabled = false;
            arqueros.transform.GetChild(i).gameObject.GetComponent<EnemigoArquero>().enabled = false;
            espadachines.transform.GetChild(i).gameObject.GetComponent<EnemigoEspadachin>().enabled = false;
            caballeros.transform.GetChild(i).gameObject.GetComponent<EnemigoCaballero>().enabled = false;
        }
        // Invocar la creación repetitiva de enemigos cada 10 segundos
        InvokeRepeating("InstanciarEnemigoAleatorio", 0f, 1f);
    }

    void InstanciarEnemigoAleatorio()
    {

        // Seleccionar un enemigo aleatorio
        int indiceEnemigo = Random.Range(0, magos.transform.childCount);
        //GameObject enemigoSeleccionado = enemigos[indiceEnemigo];

        // Seleccionar una posición aleatoria
        int indicePosicion = Random.Range(0, posiciones.Length);

        if (indiceEnemigo==0)
        {
            //magos
            /*magoRR++;
            if(magoRR>= magos.Length)
            {
                magoRR = 0;
            }
            magos[magoRR].gameObject.transform.position = posiciones[indicePosicion].transform.position;
            */
            posRR[indiceEnemigo]++;
            if (posRR[indiceEnemigo] >= magos.transform.childCount)
            {
                posRR[indiceEnemigo] = 0;
            }
            pRR= posRR[indiceEnemigo];
            magos.transform.GetChild(pRR).gameObject.transform.position = posiciones[indicePosicion].transform.position;
            magos.transform.GetChild(pRR).gameObject.GetComponent<EnemigoMago>().enabled = true;

        }
        else if (indiceEnemigo == 1)
        {
            //arqueros
            posRR[indiceEnemigo]++;
            if (posRR[indiceEnemigo] >= magos.transform.childCount)
            {
                posRR[indiceEnemigo] = 0;
            }
            pRR = posRR[indiceEnemigo];
            arqueros.transform.GetChild(pRR).gameObject.transform.position = posiciones[indicePosicion].transform.position;
            arqueros.transform.GetChild(pRR).gameObject.GetComponent<EnemigoArquero>().enabled = true;
        }
        else if (indiceEnemigo == 2)
        {
            //espadachines
            posRR[indiceEnemigo]++;
            if (posRR[indiceEnemigo] >= magos.transform.childCount)
            {
                posRR[indiceEnemigo] = 0;
            }
            pRR = posRR[indiceEnemigo];
            espadachines.transform.GetChild(pRR).gameObject.transform.position = posiciones[indicePosicion].transform.position;
            espadachines.transform.GetChild(pRR).gameObject.GetComponent<EnemigoEspadachin>().enabled = true;
        }
        else if (indiceEnemigo == 3)
        {
            //caballeros
            posRR[indiceEnemigo]++;
            if (posRR[indiceEnemigo] >= magos.transform.childCount)
            {
                posRR[indiceEnemigo] = 0;
            }
            pRR = posRR[indiceEnemigo];
            caballeros.transform.GetChild(pRR).gameObject.transform.position = posiciones[indicePosicion].transform.position;
            caballeros.transform.GetChild(pRR).gameObject.GetComponent<EnemigoCaballero>().enabled = true;

        }


        // Instanciar el enemigo en la posición seleccionada
        /*if (enemigoSeleccionado != null && posicionSeleccionada != null)
        {

            Instantiate(enemigoSeleccionado, posicionSeleccionada.transform.position, Quaternion.identity);
        }*/
    }
}
