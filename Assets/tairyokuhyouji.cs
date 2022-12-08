using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tairyokuhyouji : MonoBehaviour {
	public static int armorpoint;
	int armorpointmax=1000;
	int damage=100;
	int damage1=10;
	public Text armortext;
	int displayarmorpoint;
	public Image gaugeImage;

	// Use this for initialization
	void Start () {
		armorpoint = armorpointmax;
		displayarmorpoint = armorpoint;
	}

	// Update is called once per frame
	void Update () {
		if (displayarmorpoint != armorpoint) {
			displayarmorpoint = (int)Mathf.Lerp (displayarmorpoint,armorpoint,0.1f);
		}
		float percentaagearmorpoint = (float)displayarmorpoint/armorpointmax;

		if (percentaagearmorpoint > 0.5f) {
			armortext.color = Color.white;
		} else if (percentaagearmorpoint > 0.3f) {
			armortext.color = Color.white;
			gaugeImage.color = Color.yellow;
		} else {
			armortext.color = Color.white;
			gaugeImage.color = Color.red;
		}
		gaugeImage.transform.localScale = new Vector3 (percentaagearmorpoint,1,1);
		armortext.text = string.Format("{0:0000}/{1:0000}",displayarmorpoint,armorpointmax);
	}
	private void OnCollisionEnter(Collision collider){
		if (collider.gameObject.tag == "shotenemy") {
			armorpoint -= damage;
			armorpoint = Mathf.Clamp (armorpoint,0,armorpointmax);
		}
		if (collider.gameObject.tag == "Shotenemy") {
			armorpoint -= damage1;
			armorpoint = Mathf.Clamp (armorpoint, 0, armorpointmax);
		}

}
}