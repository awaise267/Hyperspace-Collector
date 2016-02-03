using UnityEngine;
using System.Collections;

public class ExplosionBehaviour : MonoBehaviour {

	private SpriteIterator sp;
	// Use this for initialization
	void Start () {
		ImageRepoImplementation img = new ImageRepoImplementation();
		sp = img.createIterator();
	}

	void Update() {
		StartCoroutine (ChangeSprite ());
	}
	
	IEnumerator ChangeSprite(){
		yield return new WaitForSeconds(0.01f);
		if (sp.hasNext()) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = sp.next();
		}
	}
}
