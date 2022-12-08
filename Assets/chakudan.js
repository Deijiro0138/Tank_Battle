#pragma strict
var exprosion:GameObject;
var exprosion1:GameObject;
var armorPoint:int;
var armorPointMax:int=1000;
var damage:int=100;
var damage1:int=10;

function Start () {
armorPoint=armorPointMax;
}

function Update () {
}
function OnCollisionEnter(obj:Collision){

if(obj.gameObject.tag=="shotenemy"){
armorPoint-=damage;
Debug.Log(armorPoint);
/*Destroy(gameObject);
Instantiate(exprosion,transform.position,transform.rotation);*/
if(500<=armorPoint&&armorPoint>=1){
Instantiate(exprosion1,transform.position,transform.rotation);
}/*
if(200<=armorPoint&&armorPoint>=1){
Instantiate(exprosion2,transform.position,transform.rotation);
}*/
if(armorPoint<=0){

Destroy(gameObject);
Instantiate(exprosion,transform.position,transform.rotation);
}
}
if(obj.gameObject.tag=="Shotenemy"){
armorPoint-=damage1;
Debug.Log(armorPoint);
if(armorPoint<=0){
Destroy(gameObject);
Instantiate(exprosion,transform.position,transform.rotation);
}
}
}