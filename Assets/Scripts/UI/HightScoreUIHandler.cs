using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HightScoreUIHandler : MonoBehaviour {
    public TextMeshProUGUI playerBoardText;
    // Start is called before the first frame update
    void Start () {
        var highScores = MainManager.Instance.HighScoresList;
        // LoadHighScoreBoard ();
        string lines = "";
        foreach (var row in highScores) {
            lines += row.playerName + " " + row.score + " <br>";
        }

        playerBoardText.SetText (lines);
    }

    public void ReturnMainMenu () {
        SceneManager.LoadScene (0);
    }
}