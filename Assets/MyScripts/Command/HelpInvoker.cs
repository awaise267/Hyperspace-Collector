using UnityEngine;
using System.Collections;

class HelpInvoker : MonoBehaviour {

	private HelpCommand _commandobj;
	
	public void SetCommand(HelpCommand helpcmd)
	{
		this._commandobj = helpcmd;
		
	} 
	
	public void Execute()     
	{     
		_commandobj.executeCommand();     
	}
}
