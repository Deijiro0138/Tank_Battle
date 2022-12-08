using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public int power;
	public float dietime;
	public GameObject exprosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.up*speed);
		Destroy (this.gameObject, dietime);
	}
	/*private void OnCollisionEnter(Collision collider){
		if(GetComponent<Collider>().gameObject.tag=="Jimen"){
		Destroy (gameObject);
			Instantiate(exprosion,transform.position,transform.rotation);
		}
		if(GetComponent<Collider>().gameObject.tag=="Enemy"){
		Destroy (gameObject);
}
}*/
}