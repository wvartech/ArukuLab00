using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else {
            Destroy(this);
        }
    }
    public void OnPlayButton() {
        StartGame();
    }

    public void OnQuitButton() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level00");
    }

}
