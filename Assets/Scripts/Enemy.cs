using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;
public class Enemy : MonoBehaviour {

	public float EnemySpeed;
	public GameObject Target;
	public GameObject Bullet;
	public GameObject Root;
	public int EnemyIndex;
	public int BullerIndex;

	float timeCount = 0;
	public bool StartCheck;
	// Use this for initialization
	Pooling BP;
	public void GameStart(Vector3 _v3)
	{
		this.transform.localPosition = _v3;
		EnemySpeed = GameData.EnemyData.EnemySpeed [EnemyIndex];
		StartCheck = true;
	}

	public void GameOver()
	{
		BP.RemoveItem ();
		StartCheck = false;
	}

	void Start () {
		BP = new Pooling ();
		BP.Init (Root, Bullet, 50);
	}
	
	// Update is called once per frame
	void Update () {
		if (StartCheck) 
		{
			float newPositionX = transform.position.x - EnemySpeed * Time.deltaTime;
			float newPositionZ = transform.position.z - EnemySpeed / 3 * Time.deltaTime;
			transform.position = new Vector3 (newPositionX, transform.position.y, newPositionZ);

			if (newPositionX < -960 || newPositionZ < -540)
				EnemySpeed = -EnemySpeed;
			else if (newPositionX > 1000 || newPositionZ > 540)
				EnemySpeed = -EnemySpeed;

			timeCount += Time.deltaTime;
			if (timeCount > 1) {
				//GameObject Go = Instantiate (Bullet, transform.position, Quaternion.identity);
				GameObject Go = BP.NewItem();
				Go.transform.localPosition = transform.position;
				Go.GetComponent<Bullet> ().Init (Target, EnemyIndex);
				timeCount = 0;
			}  
		}

	}
}
