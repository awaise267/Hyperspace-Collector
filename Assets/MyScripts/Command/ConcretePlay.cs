using UnityEngine;
using System.Collections;

class ConcretePlay : PlayCommand{


	public ConcretePlay(PlayGame playObj) : base (playObj)
	{

	  
	}

	public override void executeCommand()
	{
		playObj.StartGame ();
	   
	}
}
