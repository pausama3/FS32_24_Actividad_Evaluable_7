using UnityEngine;

public class FlechaAliada : MonoBehaviour
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
        transform.Translate(Vector3.up * velocidad * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LimiteAliados"))
        {
            Destroy(this.gameObject);
        }
    }
}
