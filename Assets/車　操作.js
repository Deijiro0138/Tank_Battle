#pragma strict
var WheelFL : WheelCollider;
var WheelFR : WheelCollider;
var WheelRL : WheelCollider;
var WheelRR : WheelCollider;
var lamp : GameObject;
var back : GameObject;
var smoke : GameObject;
var Breaking : float;
var Power : float;
var Speed : float;
var MaxSpeed : float;
var BackSpeed : float;
var Turning : float;
var MassY : float;
var MassZ : float;
var localvelocity : Vector3;


function Start () {
GetComponent.<Rigidbody>().centerOfMass.y = MassY;
	GetComponent.<Rigidbody>().centerOfMass.z = MassZ;

}

function Update () {
localvelocity = this.transform.InverseTransformDirection(this.gameObject.GetComponent.<Rigidbody>().velocity);
	Controll();

}
function Controll(){
//　トルク
if(localvelocity.x<=MaxSpeed){
	WheelRR.motorTorque = Input.GetAxis("Vertical")*Power;
	WheelRL.motorTorque = Input.GetAxis("Vertical")*Power;
	}else{
	WheelRR.motorTorque = 0;
	WheelRL.motorTorque = 0;
}
if(localvelocity.x<=BackSpeed*-1){
	WheelRR.motorTorque = 0;
	WheelRL.motorTorque = 0;
}
if(localvelocity.x<=-0.1){
	back.SetActive(true);
}else{
	back.SetActive(false);
}

//  ステア
if(localvelocity.x>=5){
	WheelFL.steerAngle = Input.GetAxis("Horizontal")*Turning/localvelocity.x;
	WheelFR.steerAngle = Input.GetAxis("Horizontal")*Turning/localvelocity.x;
	}else{
	WheelFL.steerAngle = Input.GetAxis("Horizontal")*Turning/2;
	WheelFR.steerAngle = Input.GetAxis("Horizontal")*Turning/2;
}

//　ブレーキ
	if (Input.GetKey(KeyCode.Space)) {
		lamp.SetActive(true);
		WheelRL.brakeTorque = Breaking;
		WheelRR.brakeTorque = Breaking;
		WheelFL.brakeTorque = Breaking;
		WheelFR.brakeTorque = Breaking;
	}else{
		lamp.SetActive(false);
		WheelRL.brakeTorque = 0;
		WheelRR.brakeTorque = 0;
		WheelFL.brakeTorque = 0;
		WheelFR.brakeTorque = 0;
	}

}