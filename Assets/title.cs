using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class title : MonoBehaviour {
	public Text blinkText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("Select");
		}
		blinkText.color = new Color (1,1,1,Mathf.PingPong(Time.time,1));
	}
}
