﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore, currentScore;
    [SerializeField] private GameObject highScoreToggle;



    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score : " + PlayerPrefs.GetInt("MaxScore").ToString();
        currentScore.text = "Current Score : " + PlayerPrefs.GetInt("CurrentScore").ToString();

        highScoreToggle.SetActive(PlayerPrefs.GetInt("asHighScore" ) > 0);
    }

    public void Restart() {
        SceneManager.LoadScene("Main");
    }

    public void Clear() {
        PlayerPrefs.SetInt("MaxScore", 0);
        PlayerPrefs.SetInt("asHighScore", 0);
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    public void ReturnMenu() {
        SceneManager.LoadScene("Menu");
    }
}
