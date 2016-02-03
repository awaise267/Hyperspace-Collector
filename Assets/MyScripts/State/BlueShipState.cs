using UnityEngine;
using System.Collections;

public class BlueShipState : ShipState {

	ShipController shipController;

	public BlueShipState(ShipController sc)
	{
		shipController = sc;
	}

	public void changeShipColor()
	{
		shipController.shipGameObject.GetComponent<SpriteRenderer>().sprite = shipController.blueShipSprite;
	}

	// 8 - ship, 9 - red laser, 10 - blue laser
	public void changeShipColliderBehaviour()
	{
		Physics2D.IgnoreLayerCollision(8,10,true);
		Physics2D.IgnoreLayerCollision(8,9,false);
	}
}
