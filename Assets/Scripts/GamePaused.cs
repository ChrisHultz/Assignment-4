using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePaused : MonoBehaviour {
    private bool isPaused = false;
    public Text pauseText;
    public Text scoreText;
    public Text PlayerName;
    public GameObject objectToDisable;

    public void Awake() {
        PlayerName.text = Menu.pass;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                pauseText.enabled = false;
                ResumeGame();
            }
            else {
                pauseText.enabled = true;
                Pause();
            }
        }
        if (!isPaused) {
            pauseText.text = "Game is paused";
        }
    }

    void Pause() {
        scoreText.enabled = false;
        Time.timeScale = 0;
        objectToDisable.SetActive(false);
        isPaused = true;
        pauseText.text = "Game is paused";
    }
    public void ResumeGame() {
        scoreText.enabled = true;
        Time.timeScale = 1;
        objectToDisable.SetActive(true);
        isPaused = false;
    }
}
