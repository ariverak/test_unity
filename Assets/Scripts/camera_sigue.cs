using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_sigue : MonoBehaviour {

	public Transform target;
	public float suavizado= 5f;

	Vector3 desface;
	// Use this for initialization
	void Start () {
		desface =transform.position - target.position;
	}
	void FixedUpdate(){
		Vector3 positionTarget = target.position + desface;
		transform.position = 
		Vector3.Lerp(transform.position,positionTarget,suavizado * Time.deltaTime);
	}
}
