using Unity.VisualScripting;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Castillo"))
        {
            Morir();
        }
        if (other.GetComponent<Escudero>() != null || other.GetComponent<Arquero>() != null || other.GetComponent<Mago>() != null)
        {
            Morir();
        }
    }
    private void Morir()
    {
        this.transform.position = new Vector3(-6, 0, 0);
    }
}
