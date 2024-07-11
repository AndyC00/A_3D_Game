using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button NextButton;

    public List<string> contentList;
    private int contentIndex = 0;

    private void Start()
    {
        nameText = transform.Find("NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        NextButton = transform.Find("NextButton").GetComponent<Button>();
        NextButton.onClick.AddListener(this.OnNextButtonClick);

    }
    public void Show()
    { 
        gameObject.SetActive(true);
    }
    public void Show(string name, string[] content)
    { 
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0];
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
    }
    private void OnNextButtonClick()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }

}
