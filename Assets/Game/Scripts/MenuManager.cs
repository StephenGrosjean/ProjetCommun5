using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore;



    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score : " + PlayerPrefs.GetInt("MaxScore").ToString();
    }

    public void Starting() {
        SceneManager.LoadScene("Main");
    }

    public void Clear() {
        PlayerPrefs.SetInt("MaxScore", 0);
        PlayerPrefs.SetInt("asHighScore", 0);
        PlayerPrefs.SetInt("CurrentScore", 0);
        highScore.text = "High Score : " + PlayerPrefs.GetInt("MaxScore").ToString();

    }
}
