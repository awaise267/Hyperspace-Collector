using UnityEngine;
using System.Collections;

public class HealthSliderHealthObserver : HealthObserver {

	ShipController shipController;
	

	public HealthSliderHealthObserver(ShipController sc)
	{
		shipController = sc;
		shipController.attachHealthObserver(this);
	}

	public void healthUpdate(float health)
	{
		shipController.healthSlider.value = health;
	}
}
