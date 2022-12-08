using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gun : MonoBehaviour {
	public RawImage cursor;
	public GameObject shot;
	public static int count;
	public GameObject exprolen;
	int frame;
	AudioSource audiosource;
	// Use this for initialization
	void Start () {
		frame = 0;
		count = 20;
		audiosource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		if (Input.GetButton ("Fire1") && frame % count == 0) {
			Instantiate (shot, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			Instantiate (exprolen,transform.position, transform.rotation);
			audiosource.PlayOneShot (audiosource.clip);
		}
	
	}
	void Ray(){
		Ray ray = new Ray (transform.position,transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 10000f)) {
			
		}
		Debug.DrawRay(ray.origin, ray.direction *10000f, Color.black, 5, false);
	}
}
