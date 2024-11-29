using UnityEngine;

public class CreadorDeEnemigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject mago;

    [SerializeField]
    private GameObject posicion1;
    void Start()
    {
        Instantiate(mago, posicion1.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
