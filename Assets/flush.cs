using UnityEngine;
using System.Collections;

public class flush : MonoBehaviour {
	public float destroyTime=0.1f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject,destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
