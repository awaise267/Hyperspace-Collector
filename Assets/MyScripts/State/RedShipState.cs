using UnityEngine;
using System.Collections;

public class RedShipState : ShipState {

	ShipController shipController;

	public RedShipState(ShipController sc)
	{
		shipController = sc;
	}
	
	public void changeShipColor()
	{
		shipController.shipGameObject.GetComponent<SpriteRenderer>().sprite = shipController.redShipSprite;
	}

	// 8 - ship, 9 - red laser, 10 - blue laser
	public void changeShipColliderBehaviour()
	{
		Physics2D.IgnoreLayerCollision(8,9,true);
		Physics2D.IgnoreLayerCollision(8,10,false);
	}
	
}
