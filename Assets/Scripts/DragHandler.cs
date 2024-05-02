using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public GameObject imagePrefab; // Ԥ���ͼƬ�����Ѱ���DraggableImage���
    private Canvas canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>(); // ȷ���ҵ�Canvas
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIController.Instance.ValidPositiveCount(gameObject.tag))
        {
            imagePrefab.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            imagePrefab.gameObject.SetActive(true);
        } else
        {
            
        }

    }
}
