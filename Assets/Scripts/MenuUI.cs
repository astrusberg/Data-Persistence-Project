using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public MenuManager Manager;
    public TMP_InputField playerInputField;
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best score: " + MenuManager.Instance.best_player + " : " + MenuManager.Instance.high_score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Manager.SetPlayerName(playerInputField.text);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
