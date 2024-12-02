using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    [SerializeField] private GameObject prefabToCreate; // Prefab a instanciar al soltar
    private Vector2 originalPosition; // Posición inicial del botón

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
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
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mover el botón con el cursor
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restaurar opacidad y bloquear raycasts de nuevo
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Verificar si se soltó en una zona válida (DropZone)
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropZone"))
        {
            // Crear el prefab en la posición del cursor
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f; // Ajustar al plano 2D

            Instantiate(prefabToCreate, worldPosition, Quaternion.identity);
        }

        // Regresar el botón a su posición inicial
        rectTransform.anchoredPosition = originalPosition;
    }
}

