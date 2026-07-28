using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string player_name;
    public int high_score;
    public string best_player;
    public static MenuManager Instance;

    [System.Serializable]
    class SaveData
    {
        public string best_player;
        public int hight_score;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveHighScore(string player, int score)
    {
        if (score >= high_score)
        {
            SaveData data = new SaveData();
            data.best_player = player;
            data.hight_score = score;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            best_player = data.best_player;
            high_score = data.hight_score;
        }
    }

    public void SetPlayerName(string name)
    {
        player_name = name;
    }
}
