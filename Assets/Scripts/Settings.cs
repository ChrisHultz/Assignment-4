using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
    public static float addedSpeed = 0f;
    public static float addedSpawn = 0f;
    public Slider carSpeedSlider;
    public Slider spawnSpeedSlider;
    public Text carSpeedTxt;
    public Text spawnSpeedTxt;

    public void calcAddedSpeed() {
        carSpeedTxt.text = "Added Car Speed: " + carSpeedSlider.value.ToString();
        addedSpeed = carSpeedSlider.value;
    }

    public void calcAddedSpawnSpeed() {
        spawnSpeedTxt.text = "Spawn Speed: " + spawnSpeedSlider.value.ToString("F2");
        addedSpawn = spawnSpeedSlider.value;
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

}
