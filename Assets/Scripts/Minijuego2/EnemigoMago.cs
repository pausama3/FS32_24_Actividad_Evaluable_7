using Unity.VisualScripting;
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
    private GameObject bolas;
    private GameObject bolaActual;
    

    private bool move;
    private bool morirse;
    private GameObject sound;
    void Start()
    {
        move = true;
        morirse = false;
        InvokeRepeating("CrearBola", 1f, 6f);
        sound = GameObject.Find("Cute_Grunt_2");
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
            VariablesGlobales.bolaRR++;
            if (VariablesGlobales.bolaRR >= bolas.transform.childCount)
            {
                VariablesGlobales.bolaRR = 0;
            }
            bolas.transform.GetChild(VariablesGlobales.bolaRR).gameObject.transform.position = this.transform.GetChild(0).transform.position;
            bolas.transform.GetChild(VariablesGlobales.bolaRR).gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            bolaActual = bolas.transform.GetChild(VariablesGlobales.bolaRR).gameObject;
            Invoke("MoverBola", 3f);
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
            sound.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("Aliado"))
        {
            morirse = true;
            Invoke("Morir", 0.3f);
            gameObject.GetComponent<Animator>().SetTrigger("Die");
            sound.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("FlechaAliada"))
        {
            morirse = true;
            Destroy(other.gameObject);
            Invoke("Morir", 0.3f);
            gameObject.GetComponent<Animator>().SetTrigger("Die");
            sound.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("Castillo"))
        {
            VariablesGlobales.vida--;
            Morir();
        }
    }
    private void Morir()
    {
        this.transform.position = new Vector3(-6, 0, 0);
        morirse = false;
        gameObject.GetComponent<Animator>().ResetTrigger("Die");
        this.gameObject.GetComponent<EnemigoMago>().enabled = false;
    }
    private void MoverBola()
    {
        bolaActual.transform.position = new Vector3(-6, 0, 0);
    }
}
