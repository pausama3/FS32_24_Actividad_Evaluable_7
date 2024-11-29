using UnityEngine;

public class Escudero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private float velocidad = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }
}
