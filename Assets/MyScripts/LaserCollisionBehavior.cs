using UnityEngine;
using System.Collections;

public class LaserCollisionBehavior : MonoBehaviour {

	public enum Orientations{Vertical, Horizontal};
	public Orientations orientation;
	public Vector2 origin;
	public Vector2 endPoint;
	public float distance;
	public LayerMask layerMask1;
	public LayerMask layerMask2;
	private LineRenderer laser;
	public GameObject spark;
	private AudioSource audioSource;
	public GameObject explosion;
	//public GameObject collisionObject;

	
	void Start () {
		//get associated line renderer
		laser = GetComponent<LineRenderer>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void FixedUpdate() {

		if(orientation == Orientations.Vertical) {
			laser.SetPosition(1, new Vector3(transform.position.x,endPoint.y,0.0f));
		} else if(orientation == Orientations.Horizontal) {
			laser.SetPosition(1, new Vector3(endPoint.x,transform.position.y,0.0f));
		}

	


		LayerMask finalLayerMask = layerMask1 | layerMask2;
		RaycastHit2D hit = Physics2D.Raycast(origin, -transform.up ,distance,finalLayerMask.value);

		if(hit != null && hit.collider != null && hit.collider.tag == "redgarbage") {

			if(gameObject.tag == "redlaser")
			{
				Vector3 hitPoint = new Vector3(hit.point.x,hit.point.y,0.0f);
				Destroy(hit.collider.gameObject);
				Instantiate(explosion,hitPoint,Quaternion.identity);
			}

		} else if(hit != null && hit.collider != null && hit.collider.tag == "bluegarbage") {
			
			if(gameObject.tag == "bluelaser")
			{
				Vector3 hitPoint = new Vector3(hit.point.x,hit.point.y,0.0f);
				Destroy(hit.collider.gameObject);
				Instantiate(explosion,hitPoint,Quaternion.identity);
			}

		}  else if(hit != null && hit.collider != null && hit.collider.tag == "Ship") {

			ShipController sc = hit.collider.gameObject.GetComponent<ShipController>();
			audioSource.enabled = true;

			if(sc.getCurrentShipState() is RedShipState) {
				 if (gameObject.tag == "bluelaser") {
					handleOrientationLogic(hit);
					sc.OnCollisionWithLaser("bluelaser");
				}
			} else if (sc.getCurrentShipState() is BlueShipState) {
				if (gameObject.tag == "redlaser") {
					handleOrientationLogic(hit);
					sc.OnCollisionWithLaser("redlaser");
				}
			}
		} else {
			audioSource.enabled = false;
		}

	}
	

	private void handleOrientationLogic(RaycastHit2D hit)
	{
		if(orientation == Orientations.Vertical){
			laser.SetPosition(1, new Vector3(transform.position.x,hit.point.y,0.0f));
			Instantiate(spark,new Vector3(transform.position.x,hit.point.y,0.0f),Quaternion.identity);
		} else if(orientation == Orientations.Horizontal) {
			laser.SetPosition(1, new Vector3(hit.point.x,transform.position.y,0.0f));
			Instantiate(spark,new Vector3(hit.point.x,transform.position.y,0.0f),Quaternion.identity);
		}
	}

}
