using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour {

	public Text timeText;
	public Text scoreText;

	bool started = false;
	int score = 0;
	int targetsHitted = 0;
	float remainingSeconds = 20f;

	// Use this for initialization
	void Start () {
		showInstructions ();
		updateScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		remainingSeconds -= Time.deltaTime;
		if (remainingSeconds <= 0f) {
			inferGameResult ();
		} else {
			timeText.text = (int)remainingSeconds + "";
		}
	}

	public void addPoints(int howMany) {
		score += howMany;
		updateScoreText ();
	}

	public void newTargetHitted() {
		targetsHitted ++;
	}

	void inferGameResult() {
		if (targetsHitted == 3 && score >= 300) {
			showSuccess ();
		} else {
			showFailure ();
		}
	}

	void updateScoreText() {
		scoreText.text = "Score: " + score;
	}

	void showInstructions() {
	}

	void showSuccess() {
		SceneManager.LoadScene (0);
	}

	void showFailure() {
		SceneManager.LoadScene (0);
	}
}
