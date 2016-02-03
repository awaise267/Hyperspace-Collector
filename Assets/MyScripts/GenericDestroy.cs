using UnityEngine;
using System.Collections;

public class GenericDestroy : MonoBehaviour {

	public float delay;


	// Use this for initialization
	void Start () {
		Destroy(gameObject,delay);
	}


	

}
