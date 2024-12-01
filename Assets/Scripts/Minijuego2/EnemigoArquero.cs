using UnityEngine;

public class EnemigoArquero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 2f;
    [SerializeField]
    private GameObject posicion;
    [SerializeField]
    private GameObject flecha;
    private GameObject clonFlecha;

    private bool move;
    private bool morirse;
    void Start()
    {
        move = true;
        morirse = false;
        InvokeRepeating("CrearFlecha", 0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move && !morirse)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }

    }
    public void CrearFlecha()
    {
        move = false;
        if (!morirse)
        {
            clonFlecha = Instantiate(flecha, posicion.transform.position, Quaternion.Euler(0f, 0f, 270f));
            Invoke("ActivarMove", 3f);
        }
    }
    public void ActivarMove()
    {
        move = true;
    }    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BolaAzul"))
        {
            morirse = true;
            Invoke("Morir", 0.3f);
            //animacion morir
        }
        if (other.CompareTag("Aliado"))
        {
            morirse = true;
            Invoke("Morir", 0.3f);
            //animacion morir
        }
        if (other.CompareTag("FlechaAliada"))
        {
            morirse = true;
            Destroy(other.gameObject);
            Invoke("Morir", 0.3f);
            //animacion morir
        }
    }
    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
