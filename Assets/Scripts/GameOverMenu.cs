using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public void restart() {
        Invoke("loadScene", 1f);
    }

    public void quit() {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    void loadScene()
    {
        SceneManager.LoadScene("0");
    }
}
