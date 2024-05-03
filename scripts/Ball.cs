using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public static string state="free";
	public static GameObject owner;
	public AudioSource cheer;
	public AudioSource whistle;
	public AudioSource post;
	public static float yvel;
	public static string ownername;
	public bool outed=false;
	public AudioSource ohh;
	private Transform spot;
	private Transform spotopp;
	public GameObject ai;//////////////
	public static float xtrajectory;   //x spot where the ball will hit
	public float ztrajectory;
	private float zvector;
	private float xvector;
	private float xprev;
	private float zprev;
	private float z;
	private float x;//////////////////
	public static bool hit=false;
	public static float x2trajectory;
	public static float z2trajectory;
	private int unlock=0; private Vector3 prevpos;
	private int ticktock=0; private int posession;
	/////////////////////////////////
	private float restarttimeout=0.0f;
	private float timeout=0.0f;

	void  Start (){
		state="free";
		spot=GameObject.Find("kpos").transform;
		spotopp=GameObject.Find("kposopp").transform;
		x2trajectory=0.0f;
		z2trajectory=0.0f;
	}

	void  OnLevelWasLoaded (){
		state="free";
	}

	void  Update (){
		if(transform.position.x==xprev && transform.position.z==zprev && AI.posession<4)  //to fix a bug of ball gets stuck in play
			timeout+=Time.deltaTime;
		else
			timeout=0.0f;
		if(timeout>6.0f && AI.posession<4)
		{state="free";GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;owner=null;timeout=0.0f;}

		if(GameObject.Find("Canvas").transform.Find("Substitution").gameObject.activeSelf)return;
		if(ticktock==1){
			x=transform.position.x;
			z=transform.position.z;
			zvector=z-zprev;
			xvector=x-xprev;
			ztrajectory=spot.position.z-zprev;
			xtrajectory=ztrajectory*xvector/zvector;
			///////////////////////////////////
			z2trajectory=spotopp.position.z-zprev;
			x2trajectory=z2trajectory*xvector/(zvector+0.00001f);}

		if(owner!=null && state=="posessed"){
			if(owner.tag=="keeper")
			{} //position control in keeper
			else
			{}}
		if(state=="free" && GetComponent<Rigidbody>().isKinematic==true)
			GetComponent<Rigidbody>().isKinematic=false;
		if(state=="posessed" && GetComponent<Rigidbody>().isKinematic==false)
			GetComponent<Rigidbody>().isKinematic=true;
		StayAboveGround();

		if(restarttimeout>0.0f )
		{restarttimeout+=Time.deltaTime; GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity);} //try to stop ball
		if(restarttimeout>=5.0f)
		{cheer.Stop();
			if(AI.posession==6){//goal
				AI.posession=0;Application.LoadLevel(Application.loadedLevel);}
			if(AI.posession==4 || posession==4){//throw in
				AI.throwingin=true;restarttimeout=0.0f;AI.SHOOT=false;AI.CORNER=false;
				if(AI.posessor!=null)AI.posessor.transform.position=new Vector3(0.0f,AI.posessor.transform.position.y,AI.posessor.transform.position.z);
				posession=0;  //move culprit player out of the way of throw in
			}
			if(AI.posession==5 || posession==5){//goalkick/corner
				if(transform.position.z>0){  //left end
					if(AI.cameoff=="p1")
						AI.outcome=1;  //goal kick
					else
						AI.outcome=2;   //corner
				}
				else
				{  //right end
					if(AI.cameoff=="p1")
						AI.outcome=2;  //corner
					else
						AI.outcome=1;   //goal kick
				}
				restarttimeout=0.0f;posession=0;}
		}
		if(transform.position.y<0.75f)transform.position=new Vector3(transform.position.x,0.83f,transform.position.z);
		yvel=GetComponent<Rigidbody>().velocity.y;
		if(GetComponent<Rigidbody>().velocity.magnitude>50.0f)GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity*19.0f);
		ticktock++;
		if(ticktock==2)
			ticktock=0;
		//if(AI.posession==0 && state=="free" && rigidbody.isKinematic)rigidbody.isKinematic=false;


	}

	void  StayAboveGround (){if(owner!=null){
			if(transform.position.y<0.93f && state=="posessed" && owner.tag!=null){
				if(owner.tag!="keeper")
					transform.position=new Vector3(transform.position.x,0.93f,transform.position.z);} }
	}
	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	void  OnTriggerEnter ( Collider other  ){ if((AI.posession==6 && cheer.isPlaying) || (AI.posession==7 && cheer.isPlaying) || AI.posession==5)return;
		if(other.gameObject.name=="goal" && AI.posession<=3)  //found bug
		{if(global.penalties==false){  //bug fix
				AI.whostarts=2;Goal();ai.GetComponent<AI>().p1Goal();other.GetComponent<Collider>().enabled=false;;return;}
		else
		{ if(AI.scored==true)return;
			if(AI.penaltyturn==1 && AI.suddendeath==false)
				AI.penaltyScore1++;
			if(AI.penaltyturn==2 && AI.suddendeath==false)
				AI.penaltyScore2++;
			if(AI.suddendeath==true && AI.penaltyturn==1)
				AI.suddendeath1=1;
			if(AI.suddendeath==true && AI.penaltyturn==2)
				AI.suddendeath2=1;
			AI.scored=true; cheer.Play();
		}  //penalty rewarded according to global variable
	}///////////////////////////////////////////////////////////////////
		if(other.gameObject.name=="goal" && global.penalties){
			if(AI.scored==true)return;
			if(AI.penaltyturn==1 && AI.suddendeath==false)
				AI.penaltyScore1++;
			if(AI.penaltyturn==2 && AI.suddendeath==false)
				AI.penaltyScore2++;
			if(AI.suddendeath==true && AI.penaltyturn==1)
				AI.suddendeath1=1;
			if(AI.suddendeath==true && AI.penaltyturn==2)
				AI.suddendeath2=1;
			AI.scored=true; cheer.Play();
		}///////////////for penalties //////////////////////////////////////
		if(other.gameObject.name=="out" && AI.posession<=3 && AI.posession!=6 && AI.posession!=4 && hit==false )
		{if(global.penalties==false){AI.posession=5;}state="free";Out(); if(global.penalties)hit=true;
			if(Vector3.Distance(transform.position,spotopp.position)<10 && AI.shot>0)
				ohh.Play();AI.shot=0;return;}

		if(other.gameObject.name=="goalopp" && AI.posession<=3)
		{AI.whostarts=1;Goal();ai.GetComponent<AI>().p2Goal();other.GetComponent<Collider>().enabled=false;return;}
		if(other.gameObject.name=="outopp" && AI.posession<=3 && AI.posession!=6 && AI.posession!=4)
		{AI.posession=5;state="free";Out();
			if(Vector3.Distance(transform.position,spot.position)<10 && AI.shot>0)
				ohh.Play();AI.shot=0;}

		if(other.gameObject.name=="line" && AI.posession<=3 && outed==false  && AI.posession!=5)
		{AI.posession=4;state="free";Out();posession=AI.posession;}  //4=>throw in
	}
	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	void  OnTriggerStay ( Collider other  ){ if(AI.posession>3)return;
		if((other.gameObject.name=="out"  || other.gameObject.name=="outopp") && AI.posession==0)
		{if(global.penalties==false){AI.posession=5;state="free";}Out();AI.shot=0;}
	}
	//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	void  OnCollisionEnter ( Collision other  ){
		if(other.gameObject.name=="post" && GetComponent<Rigidbody>().velocity.magnitude>0.05f)
			post.Play();
	}

	void  Goal (){  if(AI.posession>3)return;
		//set celebration time for a timeout and then reset room
		cheer.Play();  
		restarttimeout+=Time.deltaTime;
		AI.posession=6;global.goal=true;
	}

	void  Out (){ if(AI.posession==6)return;
		//set chill timeout and teleport ball to corner and teleport set player to take corner
		if(AI.posession==4){
			AI.throwinx=transform.position.x;
			AI.throwinz=transform.position.z;
			outed=true;state="free";
		}
		if(AI.posession==5){   //throwin / goal kick

		}
		whistle.Play();  posession=AI.posession;
		if(Time.timeScale>0.0f && global.penalties==false)
			restarttimeout+=Time.deltaTime;
		else
		{if(global.penalties==false)
			restarttimeout+=0.1f;}
		//AI.posession=5;
	}

	void  LateUpdate (){

		xprev=transform.position.x;
		zprev=transform.position.z;
	}
}
