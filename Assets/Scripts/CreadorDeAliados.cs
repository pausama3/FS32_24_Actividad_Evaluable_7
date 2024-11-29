using UnityEngine;

public class CreadorDeAliados : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject escudero, arquero, asesino, mago;

    [SerializeField]
    private GameObject posicion1, posicion2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CrearEscudero()
    {
        if (VariablesGlobales.contadorMonedas >= 10) 
        {
            Instantiate(escudero, posicion1.transform.position, Quaternion.identity);
            VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 10; 
        }             
    }
    public void CrearArquero()
    {
        if (VariablesGlobales.contadorMonedas >= 20)
        {
            Instantiate(arquero, posicion2.transform.position, Quaternion.identity);
            VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 20;
        }
    }
    public void CrearMago()
    {
        if (VariablesGlobales.contadorMonedas >= 40)
        {
            Instantiate(mago, posicion1.transform.position, Quaternion.identity);
            VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 40;
        }
    }
    public void CrearAsesino()
    {
        if (VariablesGlobales.contadorMonedas >= 30)
        {
            Instantiate(asesino, posicion2.transform.position, Quaternion.identity);
            VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 30;
        }
    }
}
