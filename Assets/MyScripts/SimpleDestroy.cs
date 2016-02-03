using UnityEngine;
using System.Collections;

public class SimpleDestroy : MonoBehaviour {

	public float timeDelay;
	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyAfterSomeTime());
	}
	
	IEnumerator DestroyAfterSomeTime(){
		yield return new WaitForSeconds(timeDelay);
		Destroy(gameObject);
	}
}
