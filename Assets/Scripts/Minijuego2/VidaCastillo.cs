using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaCastillo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public GameObject vida;

    void Start()
    {
        VariablesGlobales.vida = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(VariablesGlobales.vida);
        switch (VariablesGlobales.vida)
        {
            case 0:
                vida.transform.GetChild(0).gameObject.SetActive(false);
                vida.transform.GetChild(1).gameObject.SetActive(false);
                vida.transform.GetChild(2).gameObject.SetActive(false);
                vida.transform.GetChild(3).gameObject.SetActive(false);
                vida.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 1:
                vida.transform.GetChild(0).gameObject.SetActive(true);
                vida.transform.GetChild(1).gameObject.SetActive(false);
                vida.transform.GetChild(2).gameObject.SetActive(false);
                vida.transform.GetChild(3).gameObject.SetActive(false);
                vida.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 2:
                vida.transform.GetChild(0).gameObject.SetActive(true);
                vida.transform.GetChild(1).gameObject.SetActive(true);
                vida.transform.GetChild(2).gameObject.SetActive(false);
                vida.transform.GetChild(3).gameObject.SetActive(false);
                vida.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 3:
                vida.transform.GetChild(0).gameObject.SetActive(true);
                vida.transform.GetChild(1).gameObject.SetActive(true);
                vida.transform.GetChild(2).gameObject.SetActive(true);
                vida.transform.GetChild(3).gameObject.SetActive(false);
                vida.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 4:
                vida.transform.GetChild(0).gameObject.SetActive(true);
                vida.transform.GetChild(1).gameObject.SetActive(true);
                vida.transform.GetChild(2).gameObject.SetActive(true);
                vida.transform.GetChild(3).gameObject.SetActive(true);
                vida.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 5:
                vida.transform.GetChild(0).gameObject.SetActive(true);
                vida.transform.GetChild(1).gameObject.SetActive(true);
                vida.transform.GetChild(2).gameObject.SetActive(true);
                vida.transform.GetChild(3).gameObject.SetActive(true);
                vida.transform.GetChild(4).gameObject.SetActive(true);
                break;

            default:
                Debug.LogWarning("Valor de contadorVida fuera del rango esperado.");
                break;
        }
        if(VariablesGlobales.vida==0)
        {
            SceneManager.LoadScene("LoseCastleStayer");
        }
    }
}
