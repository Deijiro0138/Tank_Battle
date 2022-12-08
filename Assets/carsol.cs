using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class carsol : MonoBehaviour {
    public RawImage carso;
    public Vector2 offset;
    RawImage carsols;
    public float rotation;
    public float tasu;
    GameObject obj;
	// Use this for initialization
	void Start () {
        carsols = Instantiate(carso) as RawImage;
        carsols.transform.SetParent(GameObject.Find("Canvas").transform);
        obj = GameObject.Find("turret");
	}
	
	// Update is called once per frame
	void Update () {
        rotation = Look.RotationY*tasu;
        carsols.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position) + new Vector3(offset.x,offset.y+rotation);
	}
}
