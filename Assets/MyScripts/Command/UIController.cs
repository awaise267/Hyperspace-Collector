using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public void loadMainStage()
	{
		Application.LoadLevel (1);
	}

	public void restartStage()
	{
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void loadHelpMenu()
	{
		Application.LoadLevel (2);
	}

	public void goBackToMainMenu()
	{
		Application.LoadLevel(0);
	}


}