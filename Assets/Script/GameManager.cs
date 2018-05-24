using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public UIInGame ui;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        ++score;
        ui.UpdateScore();
    }

    public void EndGame() {
        ui.ViewEndPanel();
    }

}
