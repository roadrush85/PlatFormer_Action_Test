using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int CoinNum;
	float CoinPosition;

	Pooling CP;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			CoinNum++;
		//	GameManager.GetInstance ().GetCoin ();
			this.gameObject.SetActive (false);
		}
	}

	public void GameStart()
	{
		//this.transform.localPosition = new Vector3 (0f, 51f, 0f);
		//HP = 100;
		//CurState = 1;
	}

	public void GameOver()
	{
		this.gameObject.SetActive (false);
	}

	/*public void Init(GameObject _target, int _index)
	{
		CoinNum = GameData.EnemyData.BulletSpeed [_index];
		Target = _target;
		OriginTarget_Pos = Target.transform.localPosition;
		Check = true;
	}*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (CoinNum < 5) 
		{
			//GameObject Go = Instantiate (Bullet, transform.position, Quaternion.identity);
			GameObject Go = BP.NewItem();
			Go.transform.localPosition = transform.position;
			Go.GetComponent<Coin> ().Init (Target, EnemyIndex);
			timeCount = 0;
		
		}*/
	}
}