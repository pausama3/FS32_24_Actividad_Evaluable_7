using UnityEngine;

public class Escudero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private float velocidad = 0.5f;

    private bool morirse;
    void Start()
    {
        morirse=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!morirse)
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!morirse)
        {
            if (other.CompareTag("Enemigo"))
            {
                if (other.GetComponent<EnemigoEspadachin>() != null || other.GetComponent<EnemigoCaballero>() != null)
                {
                    morirse = true;
                    Invoke("Morir", 0.3f);
                    //animacion morir                
                }
            }
            if (other.CompareTag("FlechaEnemiga"))
            {
                morirse = true;
                Destroy(other.gameObject);
                Invoke("Morir", 0.3f);
                //animacion morir

            }
            if (other.CompareTag("BolaFuego"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                //animacion morir
            }
        }
    }
    private void Morir()
    {        
        Destroy(this.gameObject);
    }
}
