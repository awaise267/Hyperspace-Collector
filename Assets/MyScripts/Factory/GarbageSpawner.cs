using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GarbageSpawner : MonoBehaviour {	

	public enum GarbageType{Blue, Red};
	public GarbageType garbageType;
	private Vector3 position;
	public float timeDelay = 0.5f;
	public GameObject garbageFactoryObject;
	public Vector2 forceGarbage;

	// Use this for initialization
	void Start () {
		position = transform.position;
		InvokeRepeating("instantiateGarbage",1f,timeDelay);
	}
	
	void instantiateGarbage()
	{
		if(garbageType == GarbageType.Blue)
		{
			GarbageFactory gf = (GarbageFactory)garbageFactoryObject.GetComponent<GarbageFactory>();
			gf.setGarbageType("blue");
			GameObject go = gf.produceGarbage();
			GameObject go2 = (GameObject)Instantiate(go,position,Quaternion.identity);
			Rigidbody2D rb =(Rigidbody2D)go2.GetComponent<Rigidbody2D> ();
			rb.AddForce(forceGarbage);
		} else if (garbageType == GarbageType.Red)
		{
			GarbageFactory gf = (GarbageFactory)garbageFactoryObject.GetComponent<GarbageFactory>();
			gf.setGarbageType("red");
			GameObject go = gf.produceGarbage();
			GameObject go2 = (GameObject)Instantiate(go,position,Quaternion.identity);
			Rigidbody2D rb =(Rigidbody2D)go2.GetComponent<Rigidbody2D> ();
			rb.AddForce(forceGarbage);
		}
	}
	
}