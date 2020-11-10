using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public LayerMask ground;
	public Transform feet;

	private Vector3 direction;
	private Rigidbody rbody;
	private AudioSource audio;

	private float rotationSpeed = 1f;
	private float minY = -60f;
	private float maxY = 60f;
	private float rotationY = 10f;
	private float rotationX = 0f;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	//Jayson's Code
	string complete = "SORRY! ENEMIES CAPTURED YOU, YOU LOOSE...";

	private GUIStyle fontSize;
	bool lose = false;
	//Jayson's Code

	// Use this for initialization
	void Start () {
		speed = 5.0f;
		jumpHeight = 3.0f;
		rbody = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();

		fontSize = new GUIStyle();
		fontSize.fontSize = 24;
	}
	
	// Update is called once per frame
	void Update () {
		direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");
		direction = direction.normalized;
		if(direction.x != 0)
			rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
		if(direction.z != 0)
			rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);

		rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
		rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
		if(Input.GetButtonDown("Jump") && isGrounded) {
			audio.Play();
			rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}

		if(Input.GetButtonDown("Fire1")) {
			Fire();
		}
	}

	void Fire() {
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
	}

	void OnCollisionEnter(Collision whatHitMe)
	{
		if (whatHitMe.gameObject.tag == "enemy")
		{
			Debug.Log("You loose");
			lose = true;
		}
	}
	void OnGUI()
	{
		if (lose == true)
		{
			GUI.Box(new Rect(150, 150, 400, 200), complete, fontSize);
		}
	}
	
}
















