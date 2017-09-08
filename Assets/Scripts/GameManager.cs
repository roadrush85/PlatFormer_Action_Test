using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject[] Enemy;
	public GameObject[] Coin;
	public GameObject PlayerObj;
	public GameObject Button;

	public int CoinCount;

	private static GameManager Gm;

	public static GameManager GetInstance()
	{
		return Gm;
	}

	void Awake()
	{
		Gm = this;
	}

	/*public void GetCoin(){
		CoinCount--;
		if(CoinCount < 7)
	}*/


	public void StartGame()
	{
		Button.SetActive (false);
		List<int> RandomPos = new List<int>();
		RandomPos.Add (0);
		RandomPos.Add (1);
		RandomPos.Add (2);
		RandomPos.Add (3);
		int Max = 4;
		for (int i = 0; i < 4; i++) 
		{
			int random = Random.Range (0, Max);
			Enemy [i].GetComponent<Enemy> ().GameStart (v3[random]);
			RandomPos.RemoveAt (random);
			Max--;
		}
		PlayerObj.SetActive (true);
		PlayerObj.GetComponent<Player> ().GameStart();

	}

	public void GameOver()
	{
		for (int i = 0; i < 4; i++)
			Enemy [i].GetComponent<Enemy> ().GameOver ();

		PlayerObj.GetComponent<Player> ().GameOver ();

		Button.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector3[] v3 = {new Vector3(101f,60f,-100f),new Vector3(690f,60f,320f) ,new Vector3(900f,60f,-400f) ,new Vector3(478f,60f,36f)};
}
