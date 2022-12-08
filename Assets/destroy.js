#pragma strict
var exprolen:GameObject;
private var a:AudioSource;
function Start () {
a=GetComponent(AudioSource);
}

function Update () {

}
function OnCollisionEnter(obj:Collision){
if(obj.gameObject.tag=="Enemy"){
Destroy(gameObject);
}
if(obj.gameObject.tag=="Jimen"){
Instantiate (exprolen,transform.position,transform.rotation);
Destroy(gameObject);
a.PlayOneShot(a.clip);
}
if(obj.gameObject.tag=="Player"){
Destroy(gameObject);
}

}