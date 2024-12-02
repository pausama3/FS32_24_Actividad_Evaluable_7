using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
     [SerializeField] Canvas canvas;

    [SerializeField] private GameObject prefabToCreate; // Prefab a instanciar al soltar
    private Vector2 originalPosition; // Posición inicial del botón
    private Vector2 dragOffset;

    [SerializeField] GameObject spawner1, spawner2;


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
                    Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 40;
                }
                
            }
            else if (this.gameObject.name == "Asesino")
            {
                if (VariablesGlobales.contadorMonedas >= 30)
                {
                    Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 30;
                }

            }
            else if (this.gameObject.name == "Arquero")
            {
                if (VariablesGlobales.contadorMonedas >= 20)
                {
                    Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 20;
                }
            }
            else if (this.gameObject.name == "Escudero")
            {
                if (VariablesGlobales.contadorMonedas >= 10)
                {
                    Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
                    VariablesGlobales.contadorMonedas = VariablesGlobales.contadorMonedas - 10;
                }
            }

        }

        // Regresar el botón a su posición inicial
        rectTransform.anchoredPosition = originalPosition;
    }
}

