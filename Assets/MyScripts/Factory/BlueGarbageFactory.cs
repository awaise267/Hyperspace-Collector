using UnityEngine;
using System.Collections;

public class BlueGarbageFactory : GarbageFactory {

	public GameObject getGarbage(){
		GameObject BlueGarbage = (GameObject)Resources.Load("BlueGarbage");
		return BlueGarbage;
	}

}
