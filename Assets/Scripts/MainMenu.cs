using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameManeger gameManeger;
    [SerializeField] private float defaultVolume = 0.8f;

    void Start() {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong();
    }

    public void play() {
        GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f).setOnComplete(OnComplete);
    }

    private void OnComplete() {
        gameManeger.Enable();
        Destroy(gameObject);
    }

    #region Audio

    public void setVolume(float volume) {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    #endregion
}
