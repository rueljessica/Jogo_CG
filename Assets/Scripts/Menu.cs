using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField] private string scene;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;

    [Space(10)] [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] AudioClip uiClick;
    [SerializeField] AudioClip uiHover;
    [SerializeField] AudioClip uiSpecial;
    [Space(10)] [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSource;

    [Space(10)] [SerializeField] string sceneToLoad;

    #region Buttons

    public void play() {
        SceneManager.LoadScene(scene);
    }

    public void openSettings() {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void back() {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void quit() {
        Debug.Log("Quit game");
        Application.Quit();
    }

    #endregion


    #region Audio

    public void SetVolume(float volume)
    {
        // Adjust volume
        AudioListener.volume = volume;

        // Save volume
        PlayerPrefs.SetFloat("Volume", volume);
    }

    void SetStartVolume()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", defaultVolume);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void UIClick()
    {
        audioSource.PlayOneShot(uiClick);
    }

    public void UIHover()
    {
        audioSource.PlayOneShot(uiHover);
    }

    public void UISpecial()
    {
        audioSource.PlayOneShot(uiSpecial);
    }

    #endregion

}