using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {

	List<GameObject> G_List;

	public void Init(GameObject _rootObj, GameObject _mainObj, int _count)
	{
		G_List = new List<GameObject> ();

		for (int i = 0; i < _count; i++) {
			GameObject Go = Instantiate (_mainObj as GameObject);
			G_List.Add (Go);
			G_List [i].transform.parent = _rootObj.transform;
			G_List [i].gameObject.SetActive (false);
		}
	}

	public GameObject NewItem()
	{
		for (int i = 0; i < G_List.Count; i++) {
			if (!G_List [i].gameObject.activeSelf) {
				G_List [i].gameObject.SetActive (true);
				return G_List [i];
			}
		}
		return null;
	}

	public void RemoveItem()
	{
		for (int i = 0; i < G_List.Count; i++) {
				G_List [i].gameObject.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
