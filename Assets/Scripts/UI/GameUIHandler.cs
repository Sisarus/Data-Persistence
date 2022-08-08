using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour {
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;
    private string bestPlayerText;
    private int hightScore;
    private string playerName;
    public GameBehavior gameBehavior;
    // Start is called before the first frame update
    void Start () {
        playerName = MainManager.Instance.playerName;
        LoadBestScore ();
    }

    // Update is called once per frame
    void Update () {
        scoreText.SetText (playerName + " Score : " + gameBehavior.m_Points);

        if (gameBehavior.m_GameOver) {
            LoadBestScore ();
        }
    }

    private void LoadBestScore () {
        if (MainManager.Instance.HighScore != null) {
            bestPlayerText = MainManager.Instance.HighScore.playerName;
            hightScore = MainManager.Instance.HighScore.score;
            bestScoreText.SetText ("Best Score: " + MainManager.Instance.HighScore.playerName + " " + MainManager.Instance.HighScore.score);
        } else {
            bestScoreText.SetText ("Best Score:  ");
        }

    }

}