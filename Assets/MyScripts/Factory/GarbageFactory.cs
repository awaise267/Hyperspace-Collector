using UnityEngine;
using System;
public  class GarbageFactory : MonoBehaviour {


	private string garbageType;

	public void setGarbageType(String type) {
		garbageType = type;
	}

	public GameObject produceGarbage() {
		if(garbageType == "blue") {
			Debug.Log ("Blue garbage");
			BlueGarbageFactory bgf  = new BlueGarbageFactory();
			GameObject garbage =  bgf.getGarbage();
			return garbage;
		} else if (garbageType == "red") {
			Debug.Log ("Red garbage");
			RedGarbageFactory rgf = new RedGarbageFactory();
			GameObject garbage = rgf.getGarbage();
			return garbage;
		} else {
			return null;
		}
	}
}

