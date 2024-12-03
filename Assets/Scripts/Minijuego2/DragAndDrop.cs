using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.PlayerSettings;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
     [SerializeField] Canvas canvas;

    [SerializeField] private GameObject prefabToCreate; // Prefab a instanciar al soltar
    private Vector2 originalPosition; // Posición inicial del botón
    private Vector2 dragOffset;

    [SerializeField] GameObject spawner1, spawner2;

    [SerializeField] GameObject padreEscudero, padreAsesino, padreArquero, padreMago;
    private int[] posRR;
    private int pRR;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        spawner1.SetActive(false);
        spawner2.SetActive(false);
    }

    private void Start()
    {
        // Guardar la posición inicial del botón
        originalPosition = rectTransform.anchoredPosition;
        posRR = new int[4];
        for (int i = 0; i < padreEscudero.transform.childCount; i++)
        {
            padreEscudero.transform.GetChild(i).gameObject.GetComponent<Escudero>().enabled = false;
            padreAsesino.transform.GetChild(i).gameObject.GetComponent<Asesino>().enabled = false;
            padreArquero.transform.GetChild(i).gameObject.GetComponent<Arquero>().enabled = false;
            padreMago.transform.GetChild(i).gameObject.GetComponent<Mago>().enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Hacer semitransparente y permitir que clics pasen a través
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        // Calculate the initial offset
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            null,
            out Vector2 inputPosition);

        dragOffset = rectTransform.anchoredPosition - inputPosition;
        spawner1.SetActive(true);
        spawner2.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the object's position with the offset
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            null,
            out Vector2 inputPosition);

        rectTransform.anchoredPosition = inputPosition + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restaurar opacidad y bloquear raycasts de nuevo
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        spawner1.SetActive(false);
        spawner2.SetActive(false);

        // Verificar si se soltó en una zona válida (DropZone)
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropZone"))
        {
            // Crear el prefab en la posición del cursor
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f; // Ajustar al plano 2D

            if (this.gameObject.name == "Mago")
            {
                if (VariablesGlobales.contadorMonedas >= 40)
                {
                    posRR[3]++;
                    if (posRR[3] >= padreMago.transform.childCount)
                    {
                        posRR[3] = 0;
                    }
                    pRR = posRR[3];
                    padreMago.transform.GetChild(pRR).gameObject.transform.position = worldPosition;
                    padreMago.transform.GetChild(pRR).gameObject.GetComponent<Mago>().enabled = true;

                    //Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 40;
                }
                
            }
            else if (this.gameObject.name == "Asesino")
            {
                if (VariablesGlobales.contadorMonedas >= 30)
                {
                    posRR[1]++;
                    if (posRR[1] >= padreAsesino.transform.childCount)
                    {
                        posRR[1] = 0;
                    }
                    pRR = posRR[1];
                    padreAsesino.transform.GetChild(pRR).gameObject.transform.position = worldPosition;
                    padreAsesino.transform.GetChild(pRR).gameObject.GetComponent<Asesino>().enabled = true;

                    //Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 30;
                }

            }
            else if (this.gameObject.name == "Arquero")
            {
                if (VariablesGlobales.contadorMonedas >= 20)
                {
                    posRR[2]++;
                    if (posRR[2] >= padreArquero.transform.childCount)
                    {
                        posRR[2] = 0;
                    }
                    pRR = posRR[2];
                    padreArquero.transform.GetChild(pRR).gameObject.transform.position = worldPosition;
                    padreArquero.transform.GetChild(pRR).gameObject.GetComponent<Arquero>().enabled = true;

                    //Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 20;
                }
            }
            else if (this.gameObject.name == "Escudero")
            {
                if (VariablesGlobales.contadorMonedas >= 10)
                {
                    posRR[0]++;
                    if (posRR[0] >= padreEscudero.transform.childCount)
                    {
                        posRR[0] = 0;
                    }
                    pRR = posRR[0];
                    padreEscudero.transform.GetChild(pRR).gameObject.transform.position = worldPosition;
                    padreEscudero.transform.GetChild(pRR).gameObject.GetComponent<Escudero>().enabled = true;

                    //Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 10;
                }
            }

        }

        // Regresar el botón a su posición inicial
        rectTransform.anchoredPosition = originalPosition;
    }
}

