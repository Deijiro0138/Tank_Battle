using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class battlemanager : MonoBehaviour {
	public Text scoretext;
	int battlestatus;
	const int battle_start=0;
	const int battle_play=1;
	const int battle_end=2;
	float timer;
	public Image messagestart;
	public Image messagewin;
	public Image messagelose;
	public static int score;
	int clearscore;
	public  float time= 180f;
	public Text timetext;
	// Use this for initialization
	void Start () {
		battlestatus = battle_start;
		timer = 0;
		messagestart.enabled = true;
		messagewin.enabled = false;
		messagelose.enabled = false;
		score = 0;
		clearscore=7;
	}
	
	// Update is called once per frame
	void Update () {
		scoretext.text = "撃破:"+score + "/" + clearscore;
		switch (battlestatus) {
		case battle_start:
			timer += Time.deltaTime;
			if (timer > 3) {
				messagestart.enabled = false;
				battlestatus = battle_play;
				timer = 0;
			}
			break;
		case battle_play:
			if (time > 0) {
				time -= Time.deltaTime;
				timetext.text = "残り:"+time + "秒";
			}
			if (time < 0) {
				battlestatus = battle_end;
				messagelose.enabled = true;
				Destroy (timetext);
			}
				if (score >= clearscore) {
					battlestatus = battle_end;
					messagewin.enabled = true;
				}
				if (tairyokuhyouji.armorpoint <= 0) {
					battlestatus = battle_end;
					messagelose.enabled = true;
				}
			
			break;
		case battle_end:
			timer += Time.deltaTime;
			if (timer > 3) {
				Time.timeScale = 0;
				if (Input.GetButtonDown ("Fire1")) {
					Application.LoadLevel ("title");
					Time.timeScale = 1;
				}
			}
			break;

		default:
			break;
		}
	}
}
