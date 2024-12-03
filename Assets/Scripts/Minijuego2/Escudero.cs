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
                    gameObject.GetComponent<Animator>().SetTrigger("Die");
                }
            }
            if (other.CompareTag("FlechaEnemiga"))
            {
                morirse = true;
                Destroy(other.gameObject);
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");

            }
            if (other.CompareTag("BolaFuego"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
            if (other.CompareTag("LimiteAliados"))
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
        this.gameObject.GetComponent<Escudero>().enabled = false;
    }
}
