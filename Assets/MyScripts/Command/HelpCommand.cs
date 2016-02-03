using UnityEngine;
using System.Collections;

abstract class HelpCommand {
	
	
	protected HelpGame helpObj;
	
	public HelpCommand(HelpGame helpObj)
	{
		
		this.helpObj = helpObj;
	}	
	
	public abstract void executeCommand();
	
	
}

