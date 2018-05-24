using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEndPanel : MonoBehaviour
{

    public Text scoreText;

    public void View()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("test");

    }

}
