using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject carObj;

	public float minSpeed = 8f + Settings.addedSpeed;
	public float maxSpeed = 12f + Settings.addedSpeed;

	float speed = 1f;

	void Start () {
		speed = Random.Range(minSpeed, maxSpeed);
		Invoke("Destroy", 2.0f);
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

	void Destroy() {
		Destroy(carObj);
	}

}