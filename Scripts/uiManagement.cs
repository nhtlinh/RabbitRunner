using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManagement : MonoBehaviour
{
    public Text scoreText;
    public GameObject isGameOverPanel;

    public void setScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void showGameOverPanel(bool isShow)
    {
        if (isGameOverPanel)
        {
            isGameOverPanel.SetActive(isShow);
        }
    }
}
