using UnityEngine;
using System.Collections;

public class UPControlHandler : IControlHandler {

	private IControlHandler successor = null;
	
	public void handleInput(string input)
	{
		if(input.ToLower().Equals("w"))
		{
			ShipController.setMovement(new Vector2(0f,1f));
		}
		else
		{
			if(successor != null)
			{
				successor.handleInput(input);
			}
		}
		
	}
	public void setNextInput(IControlHandler next)
	{
		this.successor = next;
	}
	
	
}
