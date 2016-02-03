using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ShipController : MonoBehaviour,Subject {

	public float speed;
	public Sprite blueShipSprite;
	public Sprite redShipSprite;
	public CircleCollider2D shipCollider;
	public GameObject shipGameObject;
	public Slider healthSlider;
	public float damageFromLaser;
	public GameObject explosion;
	public GameObject mainCamera;
	public GameObject GameOverCanvas;


	
	private Rigidbody2D rb;

	private static Vector2 movement = new Vector2(0f,0f) ;
	//private static Vector2 oldMovement = new Vector2(0f,0f) ;
	//define ship states

	private ShipState redState;
	private ShipState blueState;
	private ShipState currentShipState;

	//define observers list
	private List<HealthObserver> healthObservers;
	private float health;
	private GameObject collisions;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		//initialize ship health
		health = 100f;
		healthSlider.maxValue = 100f;
		healthSlider.minValue = 0f;
		healthSlider.value = 100f;

		//initialize healthObservers Array List
		healthObservers = new List<HealthObserver>();

		//initialize an instance of HealthSliderHealthObserver // this for attaching this obsever to ship controller subject 
		HealthSliderHealthObserver healthSliderHealthObserver = new HealthSliderHealthObserver(this);

		//intialize ship states
		redState = new RedShipState(this);
		blueState = new BlueShipState(this);

		//initialize currentShipState to blue
		currentShipState = blueState;
		// ignore collision for red laser
		Physics2D.IgnoreLayerCollision(8,10,true);
		Physics2D.IgnoreLayerCollision(8,9,false);
		rb = GetComponent<Rigidbody2D>();

	}


	void FixedUpdate() {


		movement = new Vector2(0f,0f);

		//implement controls 
		IControlHandler upControl = new UPControlHandler();
		IControlHandler downControl = new DOWNControlHandler();
		IControlHandler leftControl = new LEFTControlHandler();
		IControlHandler rightControl = new RIGHTControlHandler();

		upControl.setNextInput(downControl);
		downControl.setNextInput(leftControl);
		leftControl.setNextInput(rightControl);

		// set input to first control 
		upControl.handleInput(Input.inputString);

		//Vector2 movementDiff = Vector2.Lerp (oldMovement, movement, 0.75f);
		rb.AddForce (Mathf.Lerp(0.6f,.8f,Time.deltaTime) * movement * speed);
		//Vector2 movementDiff = Vector2.Lerp (oldMovement, movement, 0.75f);
		//rb.velocity = Vector2.MoveTowards (oldMovement, movementDiff, 40f) * 40;

		//Check for currentShipState, toggle when space bar is pressed

		if(Input.GetKeyDown("space"))
		{
		
			if(currentShipState is BlueShipState)
			{
				setCurrentShipState(redState);
				currentShipState.changeShipColor();
				currentShipState.changeShipColliderBehaviour();
				Debug.Log("Ship state changed to red");
			} else if(currentShipState is RedShipState)
			{
				setCurrentShipState(blueState);
				currentShipState.changeShipColor();
				currentShipState.changeShipColliderBehaviour();
				Debug.Log("Ship state changed to blue");
			}
		}


	}

	//set current ship state
	public void setCurrentShipState(ShipState shipState)
	{
		currentShipState = shipState;
	}

	//get current ship state
	public ShipState getCurrentShipState()
	{
		return currentShipState;
	}


	//set movement vector
	public static void setMovement(Vector2 m2)
	{
		movement = m2;
	}




	//Code for collision of ship with laser wihich will be called from LaserCollisonBehaviour

	public void OnCollisionWithLaser(String collTag) {
		if(currentShipState is RedShipState)
		{
			if (collTag == "bluelaser")
			{
				health = health - damageFromLaser;
				notifyHealthObservers();
			}
			if(health < 0) {
				AudioSource  aS =  GetComponent<AudioSource>();
				aS.Play();
				Instantiate(explosion,transform.position,Quaternion.identity);
				GameOverCanvas.SetActive(true);
				Time.timeScale = 0.2f;
				Destroy(gameObject);
			}
		}
		else if (currentShipState is BlueShipState)
		{
			if (collTag == "redlaser")
			{
				health = health - damageFromLaser;
				notifyHealthObservers();
			}
			if(health < 0) {
				AudioSource  aS =  GetComponent<AudioSource>();
				aS.Play();
				Instantiate(explosion,transform.position,Quaternion.identity);
				GameOverCanvas.SetActive(true);
				Time.timeScale = 0.2f;
				Destroy(gameObject);
			}
		}

	}


	//Collision Logic
	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.gameObject.tag == "garbage")
		{
			iTweenEvent shakeEvent =  mainCamera.GetComponent<iTweenEvent>();
			shakeEvent.Play();
		}
	}


	//Implementing Subject Interface methods
	public void attachHealthObserver(HealthObserver ho)
	{
		healthObservers.Add(ho);
	}

	public void detachHealthObserver(HealthObserver ho)
	{
		healthObservers.Remove(ho);
	}

	public void notifyHealthObservers()
	{
		foreach(HealthObserver ho in healthObservers)
		{
			ho.healthUpdate(health);
		}
	}

}
