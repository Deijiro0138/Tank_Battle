#pragma strict
var cameraA:Camera;
var cameraB:Camera;
var Imagetext1:UI.RawImage;
var Imagetext:UI.RawImage;
function Start () {
cameraA.enabled=false;
cameraB.enabled=true;
Imagetext.color=new Color(0,0,0,0);
}

function Update () {
/*if(Input.GetKey(KeyCode.Q)){
 if(cameraA.enabled==false){
cameraA.enabled=true;
cameraB.enabled=false;
}else{
cameraA.enabled=false;
cameraB.enabled=true;
}
}*/
if(Input.GetKey(KeyCode.Z)&&cameraA.enabled){
cameraA.enabled=false;
cameraB.enabled=true;
Imagetext.color = new Color (1,1,1,0);
Imagetext1.color=new Color(1,1,1,1);
}
if(Input.GetKey(KeyCode.X)&&cameraB.enabled){
cameraA.enabled=true;
cameraB.enabled=false;
Imagetext1.color = new Color (1,1,1,0);
Imagetext.color = new Color (1,1,1,1);
}

}