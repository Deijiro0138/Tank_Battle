using UnityEngine;
using System.Collections;

public class atacck : MonoBehaviour {
	int armorpoint;
	int armormaxpoint=200;
	public GameObject baku;
	int damage=100;
	private float rotationsmooth = 0f;
	public GameObject exprolen1;
	private Vector3 targetposition;
	private float changetargetsqrdistance = 40f;
	public Transform turret;
	public Transform muzzle;
	GameObject sensya;
	public GameObject bulletPrefab;
	public GameObject exprolen;
	private Transform player;
	private float attackInterval = 3f;
	private float turretRotationSmooth = 15f;
	AudioSource audiosource;
	private float lastAttackTime;
	// Use this for initialization
	void Start () {
		sensya = GameObject.FindWithTag ("Player");
		audiosource = gameObject.GetComponent<AudioSource> ();
		//player= GameObject.FindWithTag("Player").transform;
		armorpoint=armormaxpoint;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (sensya.transform.position, transform.position) <=70) {
			

			Quaternion playerRotation = Quaternion.LookRotation(sensya.transform.position - turret.position);
			turret.rotation = Quaternion.Slerp(turret.rotation, playerRotation, Time.deltaTime * turretRotationSmooth);

			// 一定間隔で弾丸を発射する
			if (Time.time > lastAttackTime + attackInterval)
			{
				audiosource.PlayOneShot (audiosource.clip);
				Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
				Instantiate (exprolen,transform.position,transform.rotation);
				lastAttackTime = Time.time;
			}
		}
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="shot"){
			Instantiate (baku,transform.position,transform.rotation);
			armorpoint-=damage;
			Debug.Log(armorpoint);
			if (armorpoint == 0) {
				battlemanager.score++;
			}
			if (armorpoint <= 0) {
				Destroy (gameObject);
				Instantiate (exprolen1, transform.position, transform.rotation);

			}
		}
}
}