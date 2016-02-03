using UnityEngine;
using System.Collections;

abstract class PlayCommand {
	  

	protected PlayGame playObj;

	public PlayCommand(PlayGame playObj)
	{

		this.playObj = playObj;
	}	

	public abstract void executeCommand();
			

}
