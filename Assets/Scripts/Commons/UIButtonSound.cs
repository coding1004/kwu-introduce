using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private Button targetButton;

    private void Awake()
    {
        targetButton = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetButton != null && !targetButton.interactable)
            return;

        UISoundManager.Instance.PlayHover();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (targetButton != null && !targetButton.interactable)
            return;

        UISoundManager.Instance.PlayClick();
    }
}