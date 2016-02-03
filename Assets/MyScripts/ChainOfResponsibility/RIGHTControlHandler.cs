using UnityEngine;
using System.Collections;


public class RIGHTControlHandler : IControlHandler {

	private IControlHandler successor = null;
	
	public void handleInput(string input)
	{
		if(input.ToLower().Equals("d"))
		{
			ShipController.setMovement(new Vector2(1f,0f));
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
