using UnityEngine;
using System.Collections;

class ConcerteHelp : HelpCommand {

	// Use this for initialization
	public ConcerteHelp(HelpGame helpObj) : base (helpObj)
	{
		
		
	}
	
	public override void executeCommand()
	{
		helpObj.SeeHelp();
		
	}
}

