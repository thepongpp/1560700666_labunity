using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kadod : MonoBehaviour {
	public Rigidbody rb;
	public GameObject Button;
	public GameObject PlayerDeadPrefab;
	private int score;
	public Text scoreText;
	public void jump(){
		rb.velocity = new Vector3(0, 5, 0);
	}
	void Start() {
		rb = GetComponent<Rigidbody>();
		score = 0;
		scoreText.text = "score : " + score.ToString();
	}

	void Update(){
		if (rb.velocity.y < 0) {
			lastVelocity = rb.velocity.y;
		}
	}
	float lastVelocity;
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "floor") {
//			float currentvelocity = rb.velocity.y;
			Debug.LogFormat ("currentvelocity = {0}", lastVelocity);
			rb.velocity = new Vector3 (0, -lastVelocity, 0);
		} else if (collision.gameObject.tag == "ceil") {
			Instantiate(PlayerDeadPrefab,this.gameObject.transform.position,Quaternion.identity);
			Destroy (this.gameObject);
			Button.SetActive(true);
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "cyl") {
			rb.velocity = new Vector3 (0,rb.velocity.y,0);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("score")) {
			Debug.Log ("Check");
			score = score + 1;
			scoreText.text = "score : " + score.ToString();
		}
	}



}