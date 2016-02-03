using UnityEngine;
using System.Collections;

class PlayInvoker : MonoBehaviour {

	private PlayCommand _commandobj;
	
	public void SetCommand(PlayCommand playcmd)
	{
		this._commandobj = playcmd;
				
	} 
	
	public void Execute()     
	{     
		_commandobj.executeCommand();     
	}
}
