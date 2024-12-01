using UnityEngine;
using UnityEngine.UIElements;

public class EnemigoMago : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 2f;
    [SerializeField]
    private GameObject posicion;
    [SerializeField]
    private GameObject Bola;
    private GameObject clonBola;

    private bool move;
    void Start()
    {
        move = true;
        InvokeRepeating("CrearBola", 0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
        
    }
    public void CrearBola()
    {
        move=false;
        
        clonBola =Instantiate(Bola, posicion.transform.position, Quaternion.Euler(0f, 0f, 90f));
        Destroy(clonBola, 3f);
        Invoke("ActivarMove",3f);

    }
    public void ActivarMove()
    { 
        move=true; 
    }
}
