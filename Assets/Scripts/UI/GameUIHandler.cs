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
    public GameBehavior gameBehavior;
    // Start is called before the first frame update
    void Start () {
        LoadBestScore ();
    }

    // Update is called once per frame
    void Update () {
        scoreText.SetText ("Score : " + gameBehavior.m_Points);

        if (gameBehavior.m_GameOver) {
            if (gameBehavior.m_Points > hightScore) {
                MainManager.Instance.hightScore = gameBehavior.m_Points;
                MainManager.Instance.SaveHighScore ();
                LoadBestScore ();
            }
        }
    }

    private void LoadBestScore () {
        bestPlayerText = MainManager.Instance.playerNameHight;
        hightScore = MainManager.Instance.hightScore;
        bestScoreText.SetText ("Best Socre : " + bestPlayerText + " : " + hightScore);
    }

}