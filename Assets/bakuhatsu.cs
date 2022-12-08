using UnityEngine;
using System.Collections;

public class bakuhatsu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ParticleSystem particleSystem = GetComponent<ParticleSystem> ();
		Destroy (gameObject,particleSystem.duration);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
