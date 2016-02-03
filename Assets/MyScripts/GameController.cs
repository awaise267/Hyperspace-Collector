using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public void restartStage() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void nextStage(int stage) {
		Application.LoadLevel(stage);
	}

	public void quitGame() {
		Application.Quit();
	}
}
