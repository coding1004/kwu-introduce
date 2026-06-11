using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonClickSound : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UISoundManager.Instance.PlayClick();
    }
}