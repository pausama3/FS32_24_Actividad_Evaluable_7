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
        Instantiate(escudero, posicion1.transform.position, Quaternion.identity);
    }
    public void CrearArquero()
    {
        Instantiate(arquero, posicion2.transform.position, Quaternion.identity);
    }
    public void CrearMago()
    {
        Instantiate(mago, posicion1.transform.position, Quaternion.identity);
    }
    public void CrearAsesino()
    {
        Instantiate(asesino, posicion2.transform.position, Quaternion.identity);
    }
}
