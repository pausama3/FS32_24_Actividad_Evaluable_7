using UnityEngine;

public class EnemigoEspadachin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 0.5f;
    private bool morirse;
    void Start()
    {
        morirse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!morirse)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!morirse)
        {
            if (other.GetComponent<Escudero>() != null || other.GetComponent<Asesino>() != null)
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
            if (other.CompareTag("BolaAzul"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
            if (other.CompareTag("Castillo"))
            {
                VariablesGlobales.vida--;
                Destroy(this.gameObject);                               
            }
        }
    }
    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
