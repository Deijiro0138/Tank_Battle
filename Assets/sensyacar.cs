using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Networking;
public class sensyacar : MonoBehaviour {
    public Image gaugeImage;
    int displayArmorPoint;
    public Text HPtext;
    public static int hitpoint;
	public WheelCollider WheelFL;
	public WheelCollider WheelFR;
	public WheelCollider WheelRL;
	public WheelCollider WheelRR;
	public GameObject lamp;
	public	GameObject back;
	public GameObject smoke;
	public float Breaking;
	public float Power;
	public float Speed;
   public float MaxSpeed;
	public float BackSpeed;
	public float Turning;
	public Vector3 MassY;
	Rigidbody xy;
	public Vector3 localvelocity;
	public Transform mycam;

	void  Start (){
        hitpoint = 1000;
        displayArmorPoint = hitpoint;
        
		/*if (!isLocalPlayer) {
			Destroy (this);
			Destroy (mycam.gameObject);
		}*/
		xy = GetComponent<Rigidbody> ();
			xy.centerOfMass = MassY;

	}

	void  Update (){
        if (displayArmorPoint != hitpoint)
        {
            displayArmorPoint = (int)Mathf.Lerp(displayArmorPoint, hitpoint, 0.1F);
            HPtext.text = string.Format("{0:0000}/{1:0000}",displayArmorPoint,1000);
        }
        float percentagehitpoint = (float)displayArmorPoint / 1000;
        if (percentagehitpoint > 0.5F)
        {
            HPtext.color = Color.white;
            gaugeImage.color = Color.green;
        }
        else if (percentagehitpoint > 0.3F)
        {
            HPtext.color = Color.yellow;
            gaugeImage.color = Color.yellow;
        }
        else {
            HPtext.color = Color.red;
            gaugeImage.color = Color.red;
        }
        gaugeImage.transform.localScale = new Vector3(percentagehitpoint,1,1);
		//if (isLocalPlayer) {
			localvelocity = this.transform.InverseTransformDirection (this.gameObject.GetComponent<Rigidbody> ().velocity);
			Controll ();
		//}
	}
    void Controll() {
        //　トルク
        if (localvelocity.x <= MaxSpeed) {
            WheelRR.motorTorque = Input.GetAxis("Vertical") * Power;
            WheelRL.motorTorque = Input.GetAxis("Vertical") * Power;
        } else {
            WheelRR.motorTorque = 0;
            WheelRL.motorTorque = 0;
        }
        if (localvelocity.x <= BackSpeed * -1) {
            WheelRR.motorTorque = 0;
            WheelRL.motorTorque = 0;
        }
        if (localvelocity.x <= -0.1f) {
            back.SetActive(true);
        } else {
            back.SetActive(false);
        }

        //  ステア
        if (localvelocity.x >= 5) {
            WheelFL.steerAngle = Input.GetAxis("Horizontal") * Turning / localvelocity.x;
            WheelFR.steerAngle = Input.GetAxis("Horizontal") * Turning / localvelocity.x;
        } else {
            WheelFL.steerAngle = Input.GetAxis("Horizontal") * Turning / 2;
            WheelFR.steerAngle = Input.GetAxis("Horizontal") * Turning / 2;
        }

        //　ブレーキ
        if (Input.GetKey(KeyCode.Space)) {
            lamp.SetActive(true);
            WheelRL.brakeTorque = Breaking;
            WheelRR.brakeTorque = Breaking;
            WheelFL.brakeTorque = Breaking;
            WheelFR.brakeTorque = Breaking;
        } else {
            lamp.SetActive(false);
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
        }
    }
        void OnCollisionEnter(Collision collider)
    {
            if (collider.gameObject.tag == "shotenemy")
            {
            hitpoint = hitpoint - 100;
            }
        }

    
}
