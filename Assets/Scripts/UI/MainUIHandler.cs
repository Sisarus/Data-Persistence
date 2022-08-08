using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour {
    public TextMeshProUGUI bestPlayerText;

    private string playerName;

    void Start () {
        if (MainManager.Instance.HighScore != null) {
            bestPlayerText.SetText ("Best Score: " + MainManager.Instance.HighScore.playerName + " " + MainManager.Instance.HighScore.score);
        } else {
            bestPlayerText.SetText ("Lets play!");
        }

    }

    public void StartGame () {
        SceneManager.LoadScene (1);
    }

    public void LoadHighScoreScene () {
        SceneManager.LoadScene (2);
    }

    public void ReadStringInput (string inputText) {
        MainManager.Instance.playerName = inputText;
    }

    public void Exit () {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode ();
#else
        Application.Quit (); // original code to quit Unity player
#endif
    }
}