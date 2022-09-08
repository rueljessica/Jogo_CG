using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Transform pauseMenu;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(pauseMenu.gameObject.activeSelf) {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            } else {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void resume() {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void quit() {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void menu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
