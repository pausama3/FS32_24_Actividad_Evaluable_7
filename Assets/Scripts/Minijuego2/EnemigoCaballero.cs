using UnityEngine;

public class EnemigoCaballero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 0.5f;
   
    private bool morirse;

    private GameObject sound;
    void Start()
    {
        morirse = false;
        sound = GameObject.Find("Cute_Grunt_2");
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
            if (other.CompareTag("Aliado"))
            {
                if (other.GetComponent<Escudero>() != null || other.GetComponent<Asesino>() != null)
                {
                    morirse = true;
                    Invoke("Morir", 0.3f);
                   // gameObject.GetComponent<Animator>().SetTrigger("Die");
                    sound.GetComponent<AudioSource>().Play();
                }
            }
            if (other.CompareTag("FlechaAliada"))
            {
                morirse = true;
                Destroy(other.gameObject);
                Invoke("Morir", 0.3f);
               // gameObject.GetComponent<Animator>().SetTrigger("Die");
                sound.GetComponent<AudioSource>().Play();
            }
            if (other.CompareTag("BolaAzul"))
            {
                morirse = true;
                Invoke("Morir", 0.3f);
                //gameObject.GetComponent<Animator>().SetTrigger("Die");
                sound.GetComponent<AudioSource>().Play();
            }
            if (other.CompareTag("Castillo"))
            {
                VariablesGlobales.vida--;
                Morir();

            }
        }
    }
    private void Morir()
    {
        this.transform.position = new Vector3(-6, 0, 0);
        morirse = false;
        //gameObject.GetComponent<Animator>().ResetTrigger("Die");
        this.gameObject.GetComponent<EnemigoCaballero>().enabled = false;
    }
}
