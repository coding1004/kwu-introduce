using UnityEngine;
using UnityEngine.UI;

public class RulePopupScript : MonoBehaviour
{
    [SerializeField] private GameObject rulePanel;

    void Start()
    {
        rulePanel.SetActive(false);
    }

    public void OnRulePopupBtn()
    {
        rulePanel.SetActive(true);
    }

    public void OnCloseBtn()
    {
        rulePanel.SetActive(false);
    }
}
