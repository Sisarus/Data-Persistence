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
        bestPlayerText.SetText ("Best Score: " + MainManager.Instance.playerNameHight + " " + MainManager.Instance.hightScore);
    }

    public void StartGame () {
        MainManager.Instance.playerName = playerName;
        SceneManager.LoadScene (1);
    }

    public void ReadStringInput (string inputText) {
        playerName = inputText;
        Debug.Log (inputText);
    }

    public void Exit () {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode ();
#else
        Application.Quit (); // original code to quit Unity player
#endif
    }
}