using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class Bullet : MonoBehaviour {

	public GameObject Target;

	Vector3 OriginTarget_Pos;
	Vector3 v3;
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.name == "Player")
			this.gameObject.SetActive (false);  // 플레이와 충돌하면 총알 비활성화
	}

	float Speed;
	bool Check;

	public void Init(GameObject _target, int _index)
	{
		Speed = GameData.EnemyData.BulletSpeed [_index];
		Target = _target;
		OriginTarget_Pos = Target.transform.localPosition;
		transform.LookAt (Target.transform); // 타켓 바라보기
		v3 = Target.transform.localPosition - this.transform.localPosition; //타겟을 향하는 벡터구하기
		float dis = Vector3.Distance (Target.transform.localPosition, this.transform.localPosition); //타겟과 유도탄 사이의 거리가 달라
		v3 = v3 / dis;
		Check = true;
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Check) {
			if (this.transform.position.x < -960 || this.transform.position.x > 960 || this.transform.position.z > 540 || this.transform.position.z < -540)
				this.gameObject.SetActive (false);
			/*if (Target.GetComponent<Player> ().CurState == 0) {
				Check = false;
				Destroy (this.gameObject);
				return;

			transform.LookAt (Target.transform); //타겟 바라보기

			Vector3 v3 = Target.transform.localPosition - this.transform.localPosition; //타겟을 향하는 벡터구하기
			float dis = Vector3.Distance (Target.transform.localPosition, this.transform.localPosition); //타겟과 유도탄 사이의 거리가 달라도 일정한 속도로 움직이기 위해서 거리를 구함
			*/
			transform.localPosition += v3 * Time.deltaTime * Speed;  
		}
	}
}
