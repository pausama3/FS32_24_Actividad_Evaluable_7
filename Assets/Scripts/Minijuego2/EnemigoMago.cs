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
    private bool morirse;
    void Start()
    {
        move = true;
        morirse = false;
        InvokeRepeating("CrearBola", 0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(move && !morirse)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }              
    }
    public void CrearBola()
    {
        move=false;
        if (!morirse)
        {
            clonBola = Instantiate(Bola, posicion.transform.position, Quaternion.Euler(0f, 0f, 90f));
            Destroy(clonBola, 3f);
            Invoke("ActivarMove", 3f);
        }
    }
    public void ActivarMove()
    { 
        move=true; 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BolaAzul"))
        {
            morirse = true;
            Invoke("Morir", 0.3f);
            gameObject.GetComponent<Animator>().SetTrigger("Die");
        }
        if (other.CompareTag("Aliado"))
        {
            morirse = true;
            Invoke("Morir", 0.3f);
            gameObject.GetComponent<Animator>().SetTrigger("Die");
        }
        if (other.CompareTag("FlechaAliada"))
        {
            morirse = true;
            Destroy(other.gameObject);
            Invoke("Morir", 0.3f);
            gameObject.GetComponent<Animator>().SetTrigger("Die");
        }
        if (other.CompareTag("Castillo"))
        {
            VariablesGlobales.vida--;
            Destroy(this.gameObject);
        }
    }
    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
