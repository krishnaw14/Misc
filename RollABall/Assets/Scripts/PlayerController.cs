using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count_red;
	public int count_blue;
	public Text countText1;
	public Text countText2;
	public Text winText;
	public GameObject obj;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count_red = 0;
		count_blue = 0;
		SetCountText ();
		winText.text=" ";
	}

	void Update() //Before any physics operation
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);

		if(Input.GetKeyDown("p"))
		{
				//count_blue = count_blue - 1;
				create (new Vector3 (transform.position.x + 1, 0.5f, transform.position.z + 1));

	}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup_red")) {
			other.gameObject.SetActive(false);
			count_red = count_red + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("pickup_blue")) {
			other.gameObject.SetActive(false);
			count_blue = count_blue + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText1.text = "Count_red: " + count_red.ToString ();
		countText2.text = "Count_blue: " + count_blue.ToString ();
		if (count_red >= 6) {
			winText.text = "Red Wins";
		}
		if (count_blue >= 6) {
			winText.text = "Blue Wins";
		}
	}
		
	void create(Vector3 m)
	{
			Instantiate (obj, m, Quaternion.identity); 
			SetCountText();
	}
}

