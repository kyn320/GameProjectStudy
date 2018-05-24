using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public Text scoreText;
    public GameObject endPanel;

    public void UpdateScore()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }

    public void OnPause()
    {
        if (Time.timeScale != 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ViewEndPanel() {
        endPanel.SetActive(true);
    } 


}
