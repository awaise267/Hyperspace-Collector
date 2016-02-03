using UnityEngine;
using System.Collections;

public class RedGarbageFactory : GarbageFactory {
	
	public GameObject getGarbage(){
		GameObject RedGarbage = (GameObject)Resources.Load("RedGarbage");
		return RedGarbage;
	}

}
