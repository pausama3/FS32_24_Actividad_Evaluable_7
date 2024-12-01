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
    void Start()
    {
        move = true;
        InvokeRepeating("CrearFlecha", 0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }

    }
    public void CrearFlecha()
    {
        move = false;

        clonFlecha = Instantiate(flecha, posicion.transform.position, Quaternion.Euler(0f, 0f, 270f));        
        Invoke("ActivarMove", 3f);

    }
    public void ActivarMove()
    {
        move = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BolaAzul"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Aliado"))
        {
            Destroy(this.gameObject);
        }
    }
}
