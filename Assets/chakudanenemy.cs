using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class chakudanenemy : MonoBehaviour {
	public GameObject exprosion;
 float armorPoint=700F;
	 float armorPointMax=700F;
	float damage=100F;
	public GameObject exprosion1;
	/*public Slider meterPrefab;
	public Vector2 offset;
	Slider meter;*/

	// Use this for initialization
	void Start () {
		/*meterPrefab.enabled = true;
		meter = Instantiate (meterPrefab) as Slider;
		meter.transform.SetParent (GameObject.Find("Canvas").transform);*/
	}
	
	// Update is called once per frame
	void Update () {
		/*meter.transform.position = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (offset.x,offset.y);
		meter.value = armorPoint / armorPointMax;*/
	}
	private void OnCollisionEnter(Collision collider){
		if (collider.gameObject.tag == "shot") {
			Instantiate (exprosion1,transform.position,transform.rotation);
			armorPoint -= damage;
			Debug.Log (armorPoint);
			if (armorPoint == 0F) {
				battlemanager.score++;
				//meterPrefab.enabled = false;
			}
			if (armorPoint <= 0F) {
				//meterPrefab.enabled = false;
				Destroy (gameObject);
				Instantiate (exprosion, transform.position, transform.rotation);

			}
		}
	}
}
