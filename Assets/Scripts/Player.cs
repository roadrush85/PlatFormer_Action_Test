using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed = 10f;
	public float jumpPower = 5f;  
	public int HP = 100;
	public float dashSpeed = 1.5f;


	Rigidbody rigidbody;
	Vector3 movement;
	float horizontalMove;
	float verticalMove;
	bool Jumping;
	bool DashStatus;

	public int CurState; //0 : gameover 1: gamestart

	private int playCount = 3;

	void Jump()  // 점프 동작
	{
		if (!Jumping)
			return;

		rigidbody.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
		Jumping = false;
	}

	void Dash()
	{
		if (!DashStatus)
			return;


	}


	public void GameStart()
	{
		this.transform.localPosition = new Vector3 (0f, 51f, 0f);
		HP = 100;
		CurState = 1;
	}

	public void GameOver()
	{
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter (Collider collider)
	{
		if (CurState == 0)
			return;
		
		if (collider.gameObject.name == "Bullet(Clone)")  // 데미지
			HP += -10;

		if (HP <= 0) 
		{
			CurState = 0;
			playCount--;
			this.transform.localPosition = new Vector3 (0f, 51f, 0f);
		}

		if(playCount < 1)
			GameManager.GetInstance ().GameOver (); // 게임오버
	}

	void Awake ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Run()
	{
		movement.Set (horizontalMove, 0, verticalMove);
		movement = movement.normalized * Speed * Time.deltaTime;

		rigidbody.MovePosition (transform.position + movement);
	}

	void FixedUpdate()
	{
		Run ();
		Jump ();
		Dash ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CurState == 0)
			return;
		horizontalMove = Input.GetAxisRaw ("Horizontal");
		verticalMove = Input.GetAxisRaw ("Vertical");

		if (Input.GetButtonDown("Jump"))
			Jumping = true;

		if (Input.GetKeyDown (KeyCode.LeftShift))
			DashStatus = true;




		/* if (Input.GetKey (KeyCode.W))
			this.transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.A))
			this.transform.Translate (Vector3.left * Speed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.D))
			this.transform.Translate (Vector3.right * Speed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.S))
			this.transform.Translate (Vector3.back * Speed * Time.deltaTime); */
	}
}
