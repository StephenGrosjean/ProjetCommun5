using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
