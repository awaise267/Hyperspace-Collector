using UnityEngine;
using System.Collections;

public class ExitPortalController : MonoBehaviour {

	public GameObject StageCompletedCanvas;

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "redgarbage" || coll.gameObject.tag == "bluegarbage")
		{
			Time.timeScale = 0;
			StageCompletedCanvas.SetActive(true);
		} 
	}

}