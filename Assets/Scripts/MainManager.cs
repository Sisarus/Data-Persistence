using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {
    public static MainManager Instance;
    public string playerName;
    public int hightScore;
    public string playerNameHight;

    private void Awake () {
        // start of new code
        if (Instance != null) {
            Destroy (gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad (gameObject);
        LoadHighScore ();
    }

    [System.Serializable]
    class SaveData {
        public int hightScore;
        public string playerNameHight;
    }

    public void SaveHighScore () {
        SaveData data = new SaveData ();
        data.hightScore = hightScore;
        data.playerNameHight = playerName;

        string json = JsonUtility.ToJson (data);

        File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
        Debug.Log ("Data saved");
        playerNameHight = playerName;
    }

    public void LoadHighScore () {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists (path)) {
            string json = File.ReadAllText (path);
            SaveData data = JsonUtility.FromJson<SaveData> (json);

            playerNameHight = data.playerNameHight;
            hightScore = data.hightScore;
        }
        Debug.Log ("Data load");
    }

}