using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;
	public static int lives = 3;
	public int num_scores = 10;
	public Text livesTxt;
	public Camera myCam;
	public GameObject objectToDisable;
	public GameObject objectToDisable2;
	private int count;
	

	void Start() {
		livesTxt.text = "Lives: " + lives.ToString();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
			rb.MovePosition(rb.position + Vector2.right);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			rb.MovePosition(rb.position + Vector2.left);
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			rb.MovePosition(rb.position + Vector2.up);
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			rb.MovePosition(rb.position + Vector2.down);
	}

	void OnTriggerEnter2D (Collider2D col) {
		string path = "Assets/StoredScores/Scores.txt";
        string line;
        string[] fields;
        int scores_written = 0;
        string newName = Menu.pass;
        string newScore = Score.CurrentScore.ToString();
        string[] writeNames = new string[10];
        string[] writeScores = new string[10];
        bool newScoreWritten = false;
		if (col.tag == "Car") {
			myCam.GetComponent<AudioSource>().Play();
			objectToDisable.SetActive(false);
			objectToDisable2.SetActive(false);
			count = lives;
			if (lives > 1) {
				count--;
				lives = count;
				Invoke("Respawn", 1.5f);
			}
			else {
				StreamReader reader = new StreamReader(path);
				while (!reader.EndOfStream ) {
            		line = reader.ReadLine();
            		fields = line.Split(',');
					if (!newScoreWritten && scores_written < num_scores) {
						if(Convert.ToInt32(newScore) > Convert.ToInt32(fields[1])) {
							writeNames[scores_written] = newName;
                    		writeScores[scores_written] = newScore;
                    		newScoreWritten = true;
                    		scores_written += 1;
						}
					}
					if(scores_written < num_scores) { // we have not written enough lines yet
                		writeNames[scores_written] = fields[0];
                		writeScores[scores_written] = fields[1];
                		scores_written += 1;
					}
				}
				reader.Close();
				StreamWriter writer = new StreamWriter(path);
				for(int x = 0; x < scores_written; x++) {
					writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
				}
				writer.Close();
        		AssetDatabase.ImportAsset(path);
        		TextAsset asset = (TextAsset)Resources.Load("scores");
				Invoke("ToExit", 1.5f);
			}
		}
	}

	void Respawn() {
		objectToDisable.SetActive(true);
		objectToDisable2.SetActive(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}

	void ToExit() {
		objectToDisable.SetActive(true);
		objectToDisable2.SetActive(true);
		SceneManager.LoadScene("GameFinished");
		lives = 3;
	}

	
}
