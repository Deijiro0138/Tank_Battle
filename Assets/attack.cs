using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public Transform turret;
	public Transform muzzle;
	public GameObject bulletPrefab;
	public GameObject exprolen;

	private float attackInterval = 3f;
	private float turretRotationSmooth = 0f;
	private float lastAttackTime;

	private Transform player;

	private void Start()
	{
		// 始めにプレイヤーの位置を取得できるようにする
		player = GameObject.FindWithTag("Player").transform;
	}

	private void Update()
	{
		// 砲台をプレイヤーの方向に向ける
		Quaternion playerRotation = Quaternion.LookRotation(player.position - turret.position);
		turret.rotation = Quaternion.Slerp(turret.rotation, playerRotation, Time.deltaTime * turretRotationSmooth);

		// 一定間隔で弾丸を発射する
		if (Time.time > lastAttackTime + attackInterval)
		{
			Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
			Instantiate (exprolen,transform.position,transform.rotation);
			lastAttackTime = Time.time;
		}
	}

}