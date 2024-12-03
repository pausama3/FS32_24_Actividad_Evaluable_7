using UnityEngine;

public class Arquero : MonoBehaviour
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
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

    }
    public void CrearFlecha()
    {
        move = false;
        if(!morirse)
        {
            clonFlecha = Instantiate(flecha, posicion.transform.position, Quaternion.Euler(0f, 0f, 90f));
            Invoke("ActivarMove", 3f);
        }      
    }
    public void ActivarMove()
    {
        move = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!morirse)
        {
            if (other.CompareTag("BolaFuego"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
            if (other.CompareTag("Enemigo"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
            if (other.CompareTag("FlechaEnemiga"))
            {
                morirse = true;
                Destroy(other.gameObject);
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
            if(other.CompareTag("LimiteAliados"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
        }
    }
    private void Morir()
    {
        this.transform.position = new Vector3(6, 0, 0);
        gameObject.GetComponent<Animator>().ResetTrigger("Die");
        this.gameObject.GetComponent<Arquero>().enabled = false;
    }

}
