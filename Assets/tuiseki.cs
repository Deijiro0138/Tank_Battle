using UnityEngine;
using System.Collections;

public class tuiseki : MonoBehaviour {
	public Transform sensya; // 追いかける対象
	public float rotMax; // 回転速度
	public float speed = 1; // 移動スピード
	/*public GameObject exprosion;
	public int aromorPoint;
	public int aromorPointMax=1000;
	int damage=100;*/
	// Use this for initialization
	void Start () {
		//aromorPoint = aromorPointMax;
	}

	// Update is called once per frame
	void Update () {
		
		Vector3 vec = sensya.position - transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3 (vec.x, 0, vec.z)), rotMax);
		transform.Translate (Vector3.forward * speed);
		}

	/*private void OnCollidionEnter(Collision collider){
		if(collider.gameObject.tag=="shot"){
			/*Destroy (gameObject);
			Instantiate (exprosion,transform.position,transform.rotation);*/
			/*aromorPoint -= damage;
			Debug.Log (aromorPoint);
			if(aromorPoint<=0){
				Destroy (gameObject);
				Instantiate (exprosion,transform.position,transform.rotation);
			}
		}
	}*/

}
