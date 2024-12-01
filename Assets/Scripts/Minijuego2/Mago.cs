using UnityEngine;

public class Mago : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float velocidad = 0.5f;
    [SerializeField]
    private GameObject posicion;
    [SerializeField]
    private GameObject Bola;
    private GameObject clonBola;

    private bool move;
    void Start()
    {
        move = true;
        InvokeRepeating("CrearBola", 0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

    }
    public void CrearBola()
    {
        move = false;

        clonBola = Instantiate(Bola, posicion.transform.position, Quaternion.Euler(0f, 0f, 270f));
        Destroy(clonBola, 3f);
        Invoke("ActivarMove", 3f);

    }
    public void ActivarMove()
    {
        move = true;
    }
}
