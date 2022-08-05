using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour {
    public TextMeshProUGUI bestPlayerText;

    private string playerName;

    public void StartGame () {
        MainManager.Instance.playerName = playerName;
        SceneManager.LoadScene (1);
    }

    public void ReadStringInput (string inputText) {
        playerName = inputText;
        Debug.Log (inputText);
    }
}