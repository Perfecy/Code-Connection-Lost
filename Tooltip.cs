using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;

    private static Tooltip instance;

    private TextMeshProUGUI tooltipText;
    private RectTransform backgroundRectTransform;

    private string newText;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        tooltipText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);
        newText = tooltipString.Replace("[n]", "\n");
        tooltipText.color = new Color32(255, 130, 0, 255);
        tooltipText.SetText(newText);
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 4f, tooltipText.preferredHeight + textPaddingSize * 4f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
        tooltipText.SetText("");
    }

    public void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }

    public void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}
