using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public GameObject imagePrefab; // 预设的图片对象，已包含DraggableImage组件
    private Canvas canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>(); // 确保找到Canvas
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
