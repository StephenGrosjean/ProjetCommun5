using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToHide, placesToHide, placesToHideBis;
    [SerializeField] private TextMeshProUGUI timer, missedText, objectFoundsText, scoreText;
    [SerializeField] private GameObject helpPanel, showHelp;

    private float time;
    private float sec, min;
    private int missed,found;

    private int maxItems = 3;
    private bool canCount = true;
    private int baseScore = 10000;


    private int score;

    private void Start() {
        GameObject[] placesToHideArray = GameObject.FindGameObjectsWithTag("Object");
        foreach(GameObject obj in placesToHideArray) {
            placesToHide.Add(obj);
        }

        foreach(GameObject obje in placesToHide) {
            placesToHideBis.Add(obje);
        }

        Distribute();
    }

    private void Update() {
        score = Mathf.RoundToInt(baseScore - (time * 100) - (missed * 50)); 

        if (canCount) {
            time = Time.time;
            scoreText.text = score.ToString();
            timer.text = FormatTime(Time.time);
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            helpPanel.SetActive(!helpPanel.active);
            showHelp.SetActive(!helpPanel.active);
        }
    }

    string FormatTime(float time) {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    public void AddMissed() {
        missed++;
        missedText.text = "Missed : " + missed.ToString();
    }

    public void AddObjectFound() {
        found++;
        objectFoundsText.text = "Found : " + found.ToString() + " / 3";
        if(found == maxItems) {
            CalculateScore();
        }
    }

    void Distribute() {
        foreach(GameObject obj in objectsToHide) {
            int RDMN = Random.Range(0, placesToHide.Count-1);
            placesToHide[RDMN].GetComponent<Object>().SetObject(obj);
            placesToHide[RDMN].tag = "Untagged";

            placesToHide.Clear();
            GameObject[] placesToHideArray = GameObject.FindGameObjectsWithTag("Object");
            foreach (GameObject obje in placesToHideArray) {
                placesToHide.Add(obje);
            }

        }

        foreach (GameObject obj in placesToHideBis) {
            obj.tag ="Object";
        }
    }

    void CalculateScore() {
        canCount = false;
        Finish(score);
    }

    void Finish(int score) {
        PlayerPrefs.SetInt("CurrentScore", score);
        if(PlayerPrefs.GetInt("MaxScore") < PlayerPrefs.GetInt("CurrentScore")) {
            PlayerPrefs.SetInt("MaxScore", score);
            PlayerPrefs.SetInt("asHighScore", 1);
        }
        else {
            PlayerPrefs.SetInt("asHighScore", 0);

        }

        SceneManager.LoadScene("EndGame");

    }
}
