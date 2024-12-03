using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class EnemigoArquero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 2f;
    
    [SerializeField]
    private GameObject flechas;
    

    private bool move;
    private bool morirse;
    private GameObject sound;
    void Start()
    {
        move = true;
        morirse = false;
        VariablesGlobales.flechaRR = -1;
        InvokeRepeating("CrearFlecha", 1f, 6f);
        sound = GameObject.Find("Cute_Grunt_2");
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
            VariablesGlobales.flechaRR++;
            if(VariablesGlobales.flechaRR >= flechas.transform.childCount)
            {
                VariablesGlobales.flechaRR = 0;
            }
            flechas.transform.GetChild(VariablesGlobales.flechaRR).gameObject.transform.position = this.transform.GetChild(0).transform.position;
            flechas.transform.GetChild(VariablesGlobales.flechaRR).gameObject.transform.rotation = Quaternion.Euler(0,0,270);
            
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
        this.gameObject.GetComponent<EnemigoArquero>().enabled = false;
    }
}
