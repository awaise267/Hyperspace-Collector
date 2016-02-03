using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageRepoImplementation :ImageRepo {
	
	private static Sprite[] imagelist;

	public ImageRepoImplementation() {
		imagelist = Resources.LoadAll<Sprite> ("spritesheet1");
	}
	
	public SpriteIterator createIterator() {
		SpriteIteratorImpl siter = new SpriteIteratorImpl ();
		return siter;
	}

	
	private class SpriteIteratorImpl: SpriteIterator {
		private int index = 0;

		public bool hasNext() {
			if (index < imagelist.Length) {
				return true;
			}
			return false;
		}
		
		public Sprite next() {
			if (this.hasNext ()) {
				Sprite sp = imagelist [index];
				Debug.Log ("index is " + index);
				index = index + 1;
				return sp;
			} else {
				return null;
			}	
		}
	}

}
