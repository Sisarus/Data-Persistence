using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainManager : MonoBehaviour {
    public static MainManager Instance;
    public string playerName;

    public List<HighScoresList> highScoresList = new List<HighScoresList> ();

    public HighScoresList HighScore => HighScoresList.FirstOrDefault ();

    public IReadOnlyList<HighScoresList> HighScoresList =>
        highScoresList.OrderByDescending (hs => hs.score).ToList ().AsReadOnly ();

    private int maxScores = 10;

    private void Awake () {
        if (Instance != null) {
            Destroy (gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad (gameObject);

        LoadData ();
    }

    [Serializable]
    class SaveData {
        public List<HighScoresList> HighScoresList;
    }

    public void SaveHighScore () {
        SaveData data = new SaveData ();
        data.HighScoresList = highScoresList;

        string json = JsonUtility.ToJson (data);

        File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData () {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists (path)) {
            string json = File.ReadAllText (path);
            SaveData data = JsonUtility.FromJson<SaveData> (json);
            highScoresList = data.HighScoresList;
        }
    }

    public void UpdateHighScoreList (int score) {

        if (highScoresList.Count >= maxScores) {
            if (highScoresList.Min (h => h.score) < score) {
                Debug.Log ("arvoja " + HighScoresList.Count);
                highScoresList.RemoveAt (HighScoresList.Count - 1);

            } else {
                return;
            }
        }
        highScoresList.Add (new HighScoresList {
            playerName = playerName, score = score
        });
        SaveHighScore ();
    }
}