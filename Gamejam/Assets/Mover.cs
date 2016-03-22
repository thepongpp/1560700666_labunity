using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speedX = 0;
	public float speedY = 1;
	public float speedZ = 0;
	public Rigidbody rb;
	void Start ()
	{
	}
	void Update ()
	{
		rb = GetComponent<Rigidbody>();
		rb.transform.Translate (new Vector3 (speedX, speedY, speedZ) * Time.deltaTime);
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "ceil"){
			Destroy (this.gameObject);
		}
	}
}﻿