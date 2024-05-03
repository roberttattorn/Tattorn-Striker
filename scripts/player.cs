using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class player : MonoBehaviour {
	
	public GameObject ball;
	public bool acting=false;
	public GameObject goal;
	public AudioSource kick;
	public AudioSource snatching;
	public AudioSource Tackling;
	public AudioSource pass;
	public GameObject opponent1;
	public GameObject goal2;
	public GameObject goal3;
	[HideInInspector]
	public string state="idle";
	[HideInInspector]
	public bool disposessing=false;
	[HideInInspector]
	public int dontcollide=0;   private float clampmin=0.0001f;private float clampmax=1.4f; private float animspeedmax=24.0f;private float animspeedmin=18.0f;
	[HideInInspector]
	public int consistency;                    private float xprev=0.0f;private float zprev=0.0f;
	public Transform position;
	public GameObject teammate1;
	public GameObject teammate2;
	public GameObject teammate3;
	public GameObject teammate4;
	public Transform keeper;
	public string role;
	public GameObject offsideline2;
	[HideInInspector]
	public bool dribbling=false;
	[HideInInspector]
	public string playername="player";
	//@HideInInspector  //for C# 
	[HideInInspector]
	public int agile=50,//read atts from file later
	speedy=50,
	accelerate=50, // attributes
	control=50,
	hotshot=50,
	accuracy=50,
	longshots=50,
	tackle=50,
	balance=50,
	reaction=50,
	dribble=50,//
	passes=50,
	heading=50,
	crossing=50,
	stamina=50,
	positioning=50,
	curve=50,
	freekicks=50,
	strength=50,
	jumping,
	aggression,
	composure,
	marking,
	penalties,
	skin=0; // 0= light 1=medium 2= dark
	[HideInInspector]
	public int determination;
	[HideInInspector]
	public string vskeeper;       //shoot, dribbleshoot, lob, passshoot, knockon   -> knockon slightly to the side
	[HideInInspector]
	public string play;        // mixed, runintotraffic, evade, pass, dribble, knockon
	[HideInInspector]
	public int ratio;          //1-> half half, 2-> twice as often 3-> very often 4-> always
	[HideInInspector]
	public string wings;      // mixed, cross, runtogoal, backpass   winger passes after some time if other options
	[HideInInspector]
	public string longshoot;  // normal, often, never
	[HideInInspector]
	public string tackles;          // hard, normal, soft
	[HideInInspector]
	public string passheight;    // mixed,lob,flat
	[HideInInspector]
	public int rating=7;
	int tempacc;int tempagy;int tempspeed;
	private int teamwork;
	private float agility;
	private float speed;
	private float acceleration;
	private float yprev;
	private int timeout=0;
	[HideInInspector]
	public int shottimeout=0;
	[HideInInspector]
	public bool run=false;
	private float vel=0.0f;
	private float disposesstimeout=0.0f;
	private float disposessedtimeout=0.0f;
	private float tackletimeout=0.0f;
	private float tackledtimeout=0;
	private float falltimeout=0.0f;
	private float tacklespeed=0.0f;
	private int boxtimeout=0;
	private bool inbox=false;
	private bool passing=false;
	[HideInInspector]
	public bool tackling=false;
	private bool headed=false;
	[HideInInspector]
	public bool booked=false;
	private int punish=0;
	private bool toggle=false;
	private int timeout2=0;
	[HideInInspector]
	 public bool evading=false;
	[HideInInspector]
	public bool knocking=false;
	[HideInInspector]
	 public bool runintotraffic=false;
	private int timeout1=0;
	[HideInInspector]
	Vector3 realpos;
	private Transform ownspot;
	private Transform spot;
	private int turn=1;
	private int readytoshoot=0;
	private int crosstimeout=0;
	public bool sentoff=false;
	public AudioSource ohh;
	public AudioSource whistle;
	[HideInInspector]
	public float freekicktimeout=0.0f;
	public Transform kposopp;
	private bool offside=false;
	public GameObject foulprompt;
	public GameObject bookedprompt;
	public GameObject bookedtext;
	public GameObject sentoffprompt;
	public GameObject sentofftext;
	AudioSource Dribbles;
	AudioSource Knock;
	AudioSource Evasion;
	AudioSource Barge;
	private int postimeout=0; private bool vkeeper=false; private int togoal=0; private int backpass=0; private int relax=0;
	int condition;
	private float condpoints=1200.0f; 
	[HideInInspector]
	Vector3 direction;
	[HideInInspector]
	float dist;
	[HideInInspector]
	int throughball=0;

	void  Start (){
		realpos=position.position;
		yprev=transform.position.y;
		GetComponent<Animation>().Play();
		agility=Mathf.Pow((agile*2.5f)/50,2);  //convert attributes
		speed=Mathf.Clamp(speed,0.12f,1.0f);
		speed=speedy/30*0.078f;
		speed=Mathf.Clamp(speed,0.12f,1.0f);
		acceleration=accelerate*0.001f;
		GetComponent<Animation>()["jog"].speed = 1.5f;
		GetComponent<Animation>()["idle"].speed = 0.1f;
		ownspot=GameObject.Find("kpos").transform;
		spot=GameObject.Find("kposopp").transform;
		GetComponent<Rigidbody>().mass=strength;

		if(global.p1booked && gameObject.name=="player")
			booked=true;
		if(global.p2booked && gameObject.name=="player2")
			booked=true;
		if(global.p3booked && gameObject.name=="player3")
			booked=true;
		if(global.p4booked && gameObject.name=="player4")
			booked=true;
		if(global.p5booked && gameObject.name=="player5")
			booked=true;
		if(global.p6booked && gameObject.name=="player6")
			booked=true;
		if(global.p7booked && gameObject.name=="player7")
			booked=true;
		if(global.p8booked && gameObject.name=="player8")
			booked=true;
		if(global.p9booked && gameObject.name=="player9")
			booked=true;
		if(global.p10booked && gameObject.name=="player10")
			booked=true;
		if( global.team1==global.id){
			if(global.p1condition==0)
			{condition=99; tempacc=accelerate; tempagy=agile; tempspeed=speedy;
				if(name=="player"){global.p1agile=tempagy;global.p1acc=tempacc;global.p1speed=tempspeed;}
				if(name=="player2"){global.p2agile=tempagy;global.p2acc=tempacc;global.p2speed=tempspeed;}
				if(name=="player3"){global.p3agile=tempagy;global.p3acc=tempacc;global.p3speed=tempspeed;}
				if(name=="player4"){global.p4agile=tempagy;global.p4acc=tempacc;global.p4speed=tempspeed;}
				if(name=="player5"){global.p5agile=tempagy;global.p5acc=tempacc;global.p5speed=tempspeed;}
				if(name=="player6"){global.p6agile=tempagy;global.p6acc=tempacc;global.p6speed=tempspeed;}
				if(name=="player7"){global.p7agile=tempagy;global.p7acc=tempacc;global.p7speed=tempspeed;}
				if(name=="player8"){global.p8agile=tempagy;global.p8acc=tempacc;global.p8speed=tempspeed;}
				if(name=="player9"){global.p9agile=tempagy;global.p9acc=tempacc;global.p9speed=tempspeed;}
				if(name=="player10"){global.p10agile=tempagy;global.p10acc=tempacc;global.p10speed=tempspeed;}
			}
			else{
				if(name=="player"){condition=global.p1condition;
					tempacc=global.p1acc; tempagy=global.p1agile; tempspeed=global.p1speed;}
				if(name=="player2"){ condition=global.p2condition;tempacc=global.p2acc; tempagy=global.p2agile; tempspeed=global.p2speed;}if(name=="player3"){
					condition=global.p3condition;tempacc=global.p3acc; tempagy=global.p3agile; tempspeed=global.p3speed;}
				if(name=="player4"){ condition=global.p4condition;tempacc=global.p4acc; tempagy=global.p4agile; tempspeed=global.p4speed;}
				if(name=="player5"){ condition=global.p5condition;tempacc=global.p5acc; tempagy=global.p5agile; tempspeed=global.p5speed;}
				if(name=="player6"){ condition=global.p6condition;tempacc=global.p6acc; tempagy=global.p6agile; tempspeed=global.p6speed;}
				if(name=="player7"){ condition=global.p7condition;tempacc=global.p7acc; tempagy=global.p7agile; tempspeed=global.p7speed;}
				if(name=="player8"){ condition=global.p8condition;tempacc=global.p8acc; tempagy=global.p8agile; tempspeed=global.p8speed;}
				if(name=="player9"){ condition=global.p9condition;tempacc=global.p9acc; tempagy=global.p9agile; tempspeed=global.p9speed;}
				if(name=="player10"){ condition=global.p10condition;tempacc=global.p10acc; tempagy=global.p10agile; tempspeed=global.p10speed;}
			}
		}
	}

	void  Update (){//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		if(GetComponent<Rigidbody>().velocity.magnitude<0.01f && GetComponent<Animation>().IsPlaying("jog"))
			GetComponent<Animation>().Play("idle");
		if(GameObject.Find("Canvas").transform.Find("Substitution").gameObject.activeSelf || Time.timeScale==0.0f || global.penalties)return;
		if(AI.posession==7){GetComponent<Animation>().Stop();return;}if(global.penalties)return;
		CheckOffside();
		if(acting==false && Ball.state=="free" && state=="idle" && AI.nearest1==gameObject) // free ball  adjust for person nearest to ball and not offside
			MoveTowardsBall();

		if(state=="idle" && (AI.posession==3 || AI.posession==1 || (AI.posession==0 && AI.nearest1!=gameObject)) 
			&& acting==false && AI.CORNER==false)  //[2  teammate has ball 
			MoveToPosition();
		if(acting==false && Ball.state=="posessed" && state=="idle" && AI.posession==2 && AI.nearest1==gameObject){//p2
			if((global.pressing=="laidback" && global.team1==global.id) || global.team1!=global.id)
				state="disposess";
		}
		if((acting==false && Ball.state=="posessed" &&  AI.posession==2 && global.pressing=="normal" && state=="idle" && 
			global.team1==global.id && Vector3.Distance(transform.position,ball.transform.position)<8
			&& Vector3.Distance(position.position,ball.transform.position)<10) || (acting==false && Ball.state=="posessed" && 
				state=="idle" && AI.posession==2 && AI.nearest1==gameObject) )
			state="disposess";
		if((acting==false && Ball.state=="posessed" && global.pressing=="pressure" && state=="idle" && global.team1==global.id && 
			Vector3.Distance(transform.position,ball.transform.position)<16
			&& Vector3.Distance(position.position,ball.transform.position)<18) || (acting==false && Ball.state=="posessed" && state=="idle" 
				&& AI.posession==2 && AI.nearest1==gameObject) )
			state="disposess";

		GameObject offsideline=GameObject.Find("offsideline");
		if(ball.transform.position.z<offsideline.transform.position.z)
			run=true;

		if(state=="disposess" && acting==false)  //move to disposess opponent
			Disposess();

		if(state=="snatching")
			Snatch();

		if(state=="tackling"){ 
			if(tacklespeed>0.0f)
				GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*tacklespeed*Time.timeScale);
			if(tacklespeed>0.0f)
				tacklespeed-=0.01f;
			Tackle(); //odds of successful tackle
			tackletimeout+=Time.deltaTime;
			if(tackletimeout>=1.5f)
			{state="idle";tacklespeed=0.0f;tackletimeout=0.0f;acting=false;}
		}

		if(state=="posessing" && dribbling==false && evading==false)  //teleporting ball problem?
			MoveToGoal();
		//////////vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
		if(state=="posessing"){
			if(DistanceToGoal()<25 && DistanceToGoal()>7 && acting==false && AI.posession==1 && Ball.state=="posessed"){ //close to goal
				if(Random.Range(0.0f,20.0f)<=1)
					Shoot();
				if(global.playstyle=="shoot on sight" && Random.Range(0.0f,10.0f)<=1 && global.team1==global.id)
					Shoot();
			}
			if(DistanceToGoal()<=7 && acting==false && AI.posession==1 && Ball.state=="posessed"){ //close to goal
				if(Random.Range(0.0f,10.0f)<=1)
					Shoot();
			}
			if(DistanceToGoal()>30 && DistanceToGoal()<50 && acting==false && AI.posession==1 && Ball.state=="posessed"){ //far from goal (long shots)
				if(longshoot=="normal"){
					if(Random.Range(0.0f,90.0f)<=1)
						Shoot();}
				if(longshoot=="often"){
					if(Random.Range(0.0f,45.0f)<=1)
						Shoot();}
				if(longshoot=="never"){
					if(Random.Range(0.0f,1000.0f)<=1)
						Shoot();}
			}
			if(ball.transform.position.z>keeper.transform.position.z)
				Shoot();

			GameObject opponent7=GameObject.Find("player7opp");
			GameObject opponent8=GameObject.Find("player8opp");  
			GameObject opponent9=GameObject.Find("player9opp");  
			GameObject opponent10=GameObject.Find("player10opp");
			if(Random.Range(0,180)<=1)
			{if((ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-5 && teammate2.transform.position.z<transform.position.z-5 &&
				teammate3.transform.position.z<transform.position.z-5 && teammate4.transform.position.z<transform.position.z-5 && global.team1!=global.id )|| play=="barge"
				|| (ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-5 && teammate2.transform.position.z<transform.position.z-5 &&
					teammate3.transform.position.z<transform.position.z-5 && teammate4.transform.position.z<transform.position.z-5 && global.team1==global.id &&
					global.mentality=="attacking"))
					return;
				if((ball.transform.position.z>opponent10.transform.position.z && ball.transform.position.z>opponent9.transform.position.z && 
					ball.transform.position.z>opponent8.transform.position.z && ball.transform.position.z>opponent7.transform.position.z)|| play=="barge")return;
				passing=true;timeout1=40;}

			if(Vector3.Distance(keeper.position,transform.position)<3.5f && acting==false){ //close to keeper
				if(vskeeper=="mixed" ){
					var dice=Random.Range(0,6);
					if(dice<=1)
						Shoot();
					if(dice==2)
						Lob();
					if(dice==3) //side dribble and score
					{dribbling=true;Dribble();readytoshoot=35;}
					if(dice==4) // pass to shoot
					{passing=true;Pass();AI.SHOOT=true;}
				}
				if(vskeeper=="shoot" )
					Shoot();
				if(vskeeper=="dribble-shoot" )
				{dribbling=true;Dribble();readytoshoot=35;}
				if(vskeeper=="cross-shot" )
				{passing=true;Pass();AI.SHOOT=true;}
				if(vskeeper=="knock-on" )
				{vkeeper=true;timeout1=40;knocking=true;KnockOn();}
			}
			if(Vector3.Distance(keeper.position,transform.position)<5.9f && acting==false && vskeeper=="lob")
				Lob();

			if(ball.transform.position.z<-30 )
			{GameObject opp1=GameObject.Find("playeropp");GameObject opp2=GameObject.Find("player2opp");GameObject opp3=GameObject.Find("player3opp");
				GameObject opp4=GameObject.Find("player4opp");GameObject opp5=GameObject.Find("player5opp");GameObject opp6=GameObject.Find("player6opp");
				if(Vector3.Distance(transform.position,opp1.transform.position)<6 || Vector3.Distance(transform.position,opp2.transform.position)<6 ||
					Vector3.Distance(transform.position,opp3.transform.position)<6||Vector3.Distance(transform.position,opp4.transform.position)<6||
					Vector3.Distance(transform.position,opp5.transform.position)<6||Vector3.Distance(transform.position,opp6.transform.position)<6)
				{state="clearing";}}
			// Clear();

			if(Vector3.Distance(transform.position,goal.transform.position)>20)
				run=true;
			else
			{run=false;vel=0.0f;} // also set timeout to stop run
			if(AI.posession==3)//keeper snatched it
			{disposessedtimeout+=0.1f;state="disposessed";vel=0.0f;GetComponent<Animation>().Play("trip");GetComponent<Animation>()["trip"].speed=1.0f;acting=true;dribbling=false;evading=false;
				runintotraffic=false;}
			if(turn==1)
				opponent1=GameObject.Find("playeropp");
			if(turn==2)
				opponent1=GameObject.Find("player2opp");
			if(turn==3)
				opponent1=GameObject.Find("player3opp");
			if(turn==4)
				opponent1=GameObject.Find("player4opp");
			if(turn==5)
				opponent1=GameObject.Find("player5opp");
			if(turn==6)
				opponent1=GameObject.Find("player6opp");
			if(turn==7)
				opponent1=GameObject.Find("player7opp");
			if(turn==8)
				opponent1=GameObject.Find("player8opp");
			if(turn==9)
				opponent1=GameObject.Find("player9opp");
			if(turn==10)
				opponent1=GameObject.Find("player10opp");
			turn+=1;if(turn==11)turn=1;
			if(Vector3.Distance(transform.position,opponent1.transform.position)<5 && Vector3.Angle(transform.forward,Vector3.forward)<60 &&
				Vector3.Angle(transform.forward,opponent1.transform.position-transform.position)<80){  //facing opponent
				var chance=Random.Range(0,6); //to be edited (0,5)
				if(dribbling==false && passing==false && evading==false && knocking==false && runintotraffic==false && state!="clearing"){
					if(play=="mixed"){
						if(chance<=1)              //tactics to be edited later chace<=1
						{dribbling=true;//AI.posession=1; 
							Dribble();}
						else if (chance>1 && chance<=2)
						{var cube=Random.Range(0,2);
							if(global.team1==global.id){
								if(global.playstyle=="normal" && cube==1)
								{passing=true;timeout1=40;}
								else if(global.playstyle=="onetwo" && cube==1)
								{passing=true;timeout1=40;global.p1onetwo=60;global.returnto=gameObject;}
								else if(global.playstyle=="through balls" && cube==1)
								{acting=true;timeout1=40;ThroughPass();}
								else
								{passing=true;timeout1=40;}
							}
							else
							{passing=true;timeout1=40;}}
						else if (chance==3 )
						{evading=true;timeout1=150;}
						else if (chance==4 )
						{knocking=true;timeout1=100;}
						else if (chance>=5)
						{runintotraffic=true;timeout1=100;RunIntoTraffic();}
					}//mixed ///////////////////////////////////////////////////////
					else{ var die=Random.Range(0.0f,1.0f); float limit=xprev;
						if(ratio==1){ limit=0.5f;} if(ratio==2) limit=0.6f;if(ratio==3) limit=0.8f;if(ratio==4) limit=1.0f;
						if(play=="barge"){//xxx
							if(die<limit)
							{runintotraffic=true;timeout1=100;RunIntoTraffic();}
							else{
								chance=Random.Range(0,5);
								if(chance<=1)
								{dribbling=true;Dribble();}
								if(chance==2)
									DoPass();
								if(chance==3)
								{evading=true;timeout1=150;}
								if (chance>=4 )
								{knocking=true;timeout1=100;}
							}
						}//xxx
						if(play=="evade"){//xxx
							if(die<limit)
							{evading=true;timeout1=150;}  
							else{
								chance=Random.Range(0,5);
								if(chance<=1)
								{dribbling=true;Dribble();}
								if(chance==2)
									DoPass();
								if(chance==3)
								{runintotraffic=true;timeout1=100;RunIntoTraffic();}
								if (chance>=4 )
								{knocking=true;timeout1=100;}
							}
						}//xxx
						if(play=="pass"){//xxx
							if(die<limit)
							{DoPass();}  
							else{
								chance=Random.Range(0,5);
								if(chance<=1)
								{dribbling=true;Dribble();}
								if(chance==2)
								{evading=true;timeout1=150;}
								if(chance==3)
								{runintotraffic=true;timeout1=100;RunIntoTraffic();}
								if (chance>=4 )
								{knocking=true;timeout1=100;}
							}
						}//xxx
						if(play=="dribble"){//xxx
							if(die<limit)
							{dribbling=true;Dribble();}  
							else{
								chance=Random.Range(0,5);
								if(chance<=1)
								{DoPass();}
								if(chance==2)
								{evading=true;timeout1=150;}
								if(chance==3)
								{runintotraffic=true;timeout1=100;RunIntoTraffic();}
								if (chance>=4 )
								{knocking=true;timeout1=100;}
							}
						}//xxx
						if(play=="knock-on"){//xxx
							if(die<limit)
							{knocking=true;timeout1=100;}
							else{
								chance=Random.Range(0,5);
								if(chance<=1)
								{DoPass();}
								if(chance==2)
								{evading=true;timeout1=150;}
								if(chance==3)
								{runintotraffic=true;timeout1=100;RunIntoTraffic();}
								if (chance>=4 )
								{dribbling=true;Dribble();}
							}
						}//xxx

					} /////else          
				}//play

			}
			if(dribbling)
				Dribble();
			//if(passing)
			//Pass();
			if(evading)
				Evade();
			//if(knocking)
			//KnockOn();
			if(runintotraffic)
				RunIntoTraffic();
			if(Ball.owner==gameObject && shottimeout==0)
				ball.transform.position=transform.position+transform.forward*Random.Range(0.7f,1.0f)+transform.up*0.1f;
		}//posessing
		//if(runintotraffic && state!="posession")
		//  RunIntoTraffic();
		if(postimeout<2)
			postimeout++;
		if(postimeout==1)
			realpos=position.position;

		if(dribbling && state!="posessing")


		if(runintotraffic && state!="posessing" && AI.posession>1 )
		{runintotraffic=false;timeout1=2;acting=false;headed=false;}

		//if((evading || dribbling ) && AI.posession>1 )
		//{evading=false;timeout1=2;acting=false;headed=false;state="idle";dribbling=false;}

		if(AI.posession==2 && acting==false && Vector3.Distance(transform.position,ball.transform.position)<12.0f && role=="defender"  
			&& Vector3.Distance(ball.transform.position,ownspot.position)<25.0f )
		{state="disposess";run=true;Disposess();}//bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
		if(AI.posession==2 && acting==false && Vector3.Distance(transform.position,ball.transform.position)<20.0f && role=="defender" 
			&& Vector3.Distance(ball.transform.position,ownspot.position)<38.0f && ball.transform.position.x>-1 && ball.transform.position.x<11)
		{if(global.marking=="zone" || (global.team1==global.id && global.marking=="zone")){
				if(ball.transform.position.x<transform.position.x) //get in way of ball
					GetComponent<Rigidbody>().MovePosition(transform.position-Vector3.right*0.2f);
				else
					GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.right*0.2f);}}

		if(state=="freekick")
			FreeKick();

		if(passing)
			Pass();
		if(knocking)
			KnockOn();

		if(state=="shooting")
			Shooting();
		if(state=="clearing")
			Clear();

		if(state=="kicking" && shottimeout<=0)
		{ if(!GetComponent<Animation>().IsPlaying("idle"))
			GetComponent<Animation>().CrossFade("idle"); acting=false; 
			state="idle"; 
		}

		if(AI.posession==7 && state!="freekick"){//foul
			state="paused";GetComponent<Animation>().Play("idle");}
		else if(AI.posession==6){ //goal
			state="paused";
			if(ball.transform.position.z>0)//p2
				Celebrate();
			else
				GetComponent<Animation>().Play("idle");}
		else
		{if(AI.posession<4 && state=="paused") //return to normal
			state="idle";
			if(AI.posession==4 || AI.posession==5)//out or throw in
			{GetComponent<Animation>().Play("idle");state="paused";}
		};

		if(global.goal && AI.whostarts==2 ){  /// rating increase on goal!
			if(Random.Range(0,2)==1 && rating<8)
			{ 
				if(rating==7){rating++;control+=5;crossing+=5;curve+=5;dribble+=5;accuracy+=5;
					freekicks+=5;heading+=5;longshots+=5;passes+=5;hotshot+=5;tackle+=5;}
				if(rating==6){rating++;control+=10;crossing+=10;curve+=10;dribble+=10;accuracy+=10;
					freekicks+=10;heading+=10;longshots+=10;passes+=10;hotshot+=10;tackle+=10;}
				if(gameObject.name=="player")global.rating1=rating;if(gameObject.name=="player2")global.rating2=rating;if(gameObject.name=="player3")global.rating3=rating;
				if(gameObject.name=="player4")global.rating4=rating;if(gameObject.name=="player5")global.rating5=rating;if(gameObject.name=="player6")global.rating6=rating;
				if(gameObject.name=="player7")global.rating7=rating;if(gameObject.name=="player8")global.rating8=rating;if(gameObject.name=="player9")global.rating9=rating;
				if(gameObject.name=="player10")global.rating10=rating;
			}
		}
		if(global.goal && AI.whostarts==1 && global.team1goals<global.team2goals){   //scored against and losing

			if(Random.Range(0,80)>determination && rating>6){
				if(rating==8){rating--;control-=5;crossing-=5;curve-=5;dribble-=5;accuracy-=5;
					freekicks-=5;heading-=5;longshots-=5;passes-=5;hotshot-=5;tackle-=5;}
				if(rating==7){rating--;control-=10;crossing-=10;curve-=10;dribble-=10;accuracy-=10;
					freekicks-=10;heading-=10;longshots-=10;passes-=10;hotshot-=10;tackle-=10;}
				if(gameObject.name=="player")global.rating1=rating;if(gameObject.name=="player2")global.rating2=rating;if(gameObject.name=="player3")global.rating3=rating;
				if(gameObject.name=="player4")global.rating4=rating;if(gameObject.name=="player5")global.rating5=rating;if(gameObject.name=="player6")global.rating6=rating;
				if(gameObject.name=="player7")global.rating7=rating;if(gameObject.name=="player8")global.rating8=rating;if(gameObject.name=="player9")global.rating9=rating;
				if(gameObject.name=="player10")global.rating10=rating;
			}
		}

		if(acting==false && GetComponent<Rigidbody>().velocity.magnitude<=0.01f && state=="idle" && evading==false)
		{if(!GetComponent<Animation>().IsPlaying("idle"))
			GetComponent<Animation>().CrossFade("idle");}//animation
		else
		{}

		if(AI.posession==3 && acting==false)  //keeper has
			state="idle";

		if(tackledtimeout>0) 
			tackledtimeout-=1;
		if(tackledtimeout==0)
		{tackling=false;acting=false;}

		if(shottimeout>0)
			shottimeout-=1;           //error: multiplying int with timescale converts it to float
		if(disposesstimeout>0.0f)
			disposesstimeout+=Time.deltaTime;
		if(disposesstimeout>=1.0f)
		{disposesstimeout=0.0f;if(state!="posessing")state="idle";disposessing=false;acting=false;}
		if(disposessedtimeout>0.0f) //ball taken away from you
		{disposessedtimeout+=Time.deltaTime;}
		if(disposessedtimeout>=50.0f/balance)
		{disposessedtimeout=0.0f;if(state=="disposessed"){state="idle";}runintotraffic=false;dribbling=false;evading=false;acting=false;}//to watch
		if(falltimeout>0.0f)
			falltimeout+=Time.deltaTime;
		if(falltimeout>=100/reaction)
		{acting=false;falltimeout=0.0f;state="idle";}
		if(crosstimeout>0)
			crosstimeout-=1;
		if(crosstimeout==1)
		{state="idle";}


		StayUpright();
		if(boxtimeout>0)
			boxtimeout-=1;
		if(boxtimeout==0)
			inbox=false;

		if(readytoshoot>0)
			readytoshoot-=1;
		if(readytoshoot==10)
			AI.SHOOT=true;
		if(readytoshoot==1)
			AI.SHOOT=false;
		GetComponent<Animation>()["jog"].speed=Mathf.Clamp(GetComponent<Animation>()["jog"].speed,clampmin,clampmax);
		GetComponent<Animation>()["run"].speed=Mathf.Clamp(GetComponent<Animation>()["run"].speed,0.01f,1.6f);


		if(Vector3.Distance(transform.position,ball.transform.position)<9 && AI.CORNER==true && acting==false && state!="posessing")
			Head();
		if(GetComponent<Animation>().IsPlaying("run"))
			GetComponent<Animation>()["run"].speed=Mathf.Clamp(GetComponent<Animation>()["run"].speed,0.01f,1.6f);
		if(GetComponent<Animation>().IsPlaying("jog"))
			GetComponent<Animation>()["jog"].speed=Mathf.Clamp(GetComponent<Animation>()["jog"].speed,clampmin,clampmax);
		if(AI.pausetimeout>4.0f )
			foulprompt.SetActive(false);

		if(dontcollide>0)
		{foreach(Collider collider in GetComponents<Collider>())
			collider.enabled=false;GetComponent<Rigidbody>().useGravity=false;dontcollide--;}
		else
		{foreach(Collider collider in GetComponents<Collider>())
			collider.GetComponent<Collider>().enabled=true;GetComponent<Rigidbody>().useGravity=true;}

		//if(booked && gameObject.name=="player") //def endian
     //global.p1booked=true;
     //if(booked && gameObject.name=="player2")
    // global.p2booked=true;
    // if(booked && gameObject.name=="player3")
    // global.p3booked=true;
    // if(booked && gameObject.name=="player4")
    // global.p4booked=true;
     //if(booked && gameObject.name=="player5")
     //global.p5booked=true;
     //if(booked && gameObject.name=="player6")
     //global.p6booked=true;
     //if(booked && gameObject.name=="player7")
    // global.p7booked=true;
    // if(booked && gameObject.name=="player8")
    // global.p8booked=true;
     //if(booked && gameObject.name=="player9")
     //global.p9booked=true;
    // if(booked && gameObject.name=="player10")
     //global.p10booked=true;

		if(timeout>0)
			timeout-=1;

		if(AI.posession==1 && Ball.owner!=null){  //if teammate running run
			if(Ball.owner.tag!="keeper" && Ball.owner.tag!="keeper2"){
				if(Ball.owner.GetComponent<player>().run)
					run=true;}}

		if(state=="onetwoing"){
			GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.forward*speed*Time.timeScale);
			if(!GetComponent<Animation>().IsPlaying("run"))
				GetComponent<Animation>().Play("run");GetComponent<Animation>()["run"].speed=GetComponent<Rigidbody>().velocity.magnitude*1.5f;
			if(global.p1onetwo==0){
				state="idle";acting=false;passing=false;}
		}

		if(togoal>0)
			togoal--;
		if(backpass>0)
			backpass--;
		if(relax>0)
			relax--;

		if(throughball>0){
			state="throughing";acting=true;
			GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.forward*speed*Time.timeScale);
			if(!GetComponent<Animation>().IsPlaying("run"))
				GetComponent<Animation>().Play("run");GetComponent<Animation>()["run"].speed=GetComponent<Rigidbody>().velocity.magnitude*1.5f;
			throughball--;
			if(throughball==0){
				state="idle";acting=false;}
		}

		if(timeout1>0)
			timeout1-=1;
		if(timeout1==1){
			evading=false;runintotraffic=false;knocking=false;acting=false;dribbling=false;passing=false;if(state=="posessing" && AI.posession!=1)state="idle";
			if(state=="passing" || state=="knocking")state="idle";}

		if(global.team1==global.id){////////////////////////////// 
			if(condition>30){
				condpoints-=(10000.0f/(stamina*stamina))*Time.timeScale;
				if(condpoints<=0.0f){
					condition--;
					if(name=="player")global.p1condition=condition;if(name=="player2") global.p2condition=condition;if(name=="player3") global.p3condition=condition;
					if(name=="player4") global.p4condition=condition;if(name=="player5")global.p5condition=condition;if(name=="player6") global.p6condition=condition;
					if(name=="player7") global.p7condition=condition;if(name=="player8") global.p8condition=condition;if(name=="player9") global.p9condition=condition;
					if(name=="player10") global.p10condition=condition;
					accelerate=(int)Mathf.Round(tempacc*condition/100.0f); agile=(int)Mathf.Round(tempagy*condition/100.0f);   // dont use math roundtoint
					speedy=Mathf.Clamp(speedy,30,tempspeed);
					speedy=(int)Mathf.Round(tempspeed*condition/80.0f);if(speedy<30)speedy=30; 
					speedy=Mathf.Clamp(speedy,30,tempspeed);
					if(agile>30)
						agility=Mathf.Pow((agile*2.5f)/50,2);  //convert attributes
					speed=Mathf.Clamp(speed,0.12f,1.0f);
					speed=speedy/30*0.078f;
					speed=Mathf.Clamp(speed,0.12f,1.0f);
					if(accelerate>30)
						acceleration=accelerate*0.001f; 
					condpoints=1300.0f;
				}
			} 
		}
		//Debug.Log("owner "+gameObject.name+" passing "+passing+" evading "+evading+" knock "+knocking+" state "+state+" traffic "+runintotraffic);
	}//xxxxxxxxxxxxxxxxxxxxxxUPDATExxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	//////////////////////////////////////////////////////////////////////////////////////////////


	void  RotateTo ( GameObject ball  ){
		var dir= ball.transform.position - transform.position;
		float singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	void  RotateToIntercept ( GameObject ball  ){  //change trajectory to intercept ball ahead
		var dir= ball.transform.position+Vector3.Normalize(ball.GetComponent<Rigidbody>().velocity) - transform.position;
		float singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	void  MoveTowardsBall (){
		if(!GetComponent<Animation>().IsPlaying("jog") && run==false)
			GetComponent<Animation>().Play("jog");
		if(!GetComponent<Animation>().IsPlaying("run") && run==true)
			GetComponent<Animation>().Play("run");
		GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*animspeedmax;
		GetComponent<Animation>()["run"].speed = GetComponent<Rigidbody>().velocity.magnitude*1.5f;
		if(run==true){
			if(vel<speed)
				vel+=acceleration;
			GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*(vel+0.01f)*Time.timeScale);}
		else
			GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*0.7f*Time.timeScale);
		RotateTo(ball);
		if(ball.transform.position.z<opponent1.transform.position.z && opponent1.transform.position.z<transform.position.z)
			run=true;

	}

	void  MoveToGoal (){
		if(togoal>0)
			RotateToRealGoal();
		else if(backpass>0)
			RotateBack();
		else
			RotateToGoal();
		if(run==true){
			if(vel<speed)
				vel+=acceleration;
			GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*vel*Time.timeScale);
			if(!GetComponent<Animation>().IsPlaying("run") && dribbling==false)
				GetComponent<Animation>().Play("run");}//vvvvvvvvvvvvvvvvvv
		else
		{ if(Vector3.Distance(transform.position,goal.transform.position)<25)
			GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*0.7f*Time.timeScale);
			if(!GetComponent<Animation>().IsPlaying("jog") && GetComponent<Rigidbody>().velocity.magnitude>0.001f && dribbling==false)
				GetComponent<Animation>().Play("jog");}

		GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*animspeedmax;
		GetComponent<Animation>()["run"].speed = GetComponent<Rigidbody>().velocity.magnitude*1.5f;
		var ctrl=Random.Range(0,control*2);
		if(ctrl<2 && evading==false && runintotraffic==false && dribbling==false)LoseBall(); // 
		if(Vector3.Angle(ball.transform.position-transform.position,goal.transform.position-transform.position)>90 && Ball.owner==gameObject)
			ball.transform.position=transform.position+Vector3.forward+transform.up*0.1f;
	}

	void  Shoot (){ 
		if(state=="posessing" && dribbling==false && passing==false && evading==false && knocking==false && runintotraffic==false)
		{state="shooting";shottimeout=31;acting=true;
			if(!GetComponent<Animation>().IsPlaying("kick"))
				GetComponent<Animation>().Play("kick");vel=0.0f;}
	}

	void  Shooting (){ 
		if(shottimeout==20  && state=="shooting"){ state="kicking";timeout=2; BallPoint.OrigPos=transform.position;
			kick.Play();ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;
			var acc=160/accuracy; var aim=Mathf.Pow(acc,2.2f);
			float randx= Random.Range(-aim,aim);
			float randy= Random.Range(0.5f,aim*5/6); Vector3 randpos= new Vector3();
			if(Random.Range(0,1)==1 && aim<10.0f){ 
				if(Random.Range(0,1)==1)
				{ randpos=new Vector3(goal2.transform.position.x+randx,goal2.transform.position.y+randy,goal2.transform.position.z);}
				else
					randpos=new Vector3(goal3.transform.position.x+randx,goal3.transform.position.y+randy,goal3.transform.position.z);
			}
			else
				randpos=new Vector3(goal.transform.position.x+randx,goal.transform.position.y+randy,goal.transform.position.z);
			var direction=Vector3.Normalize(randpos-ball.transform.position);Ball.state="free";

			ball.GetComponent<Rigidbody>().AddForce(direction*(hotshot*3/7),ForceMode.Impulse);  AI.shot=40;
			if(Vector3.Distance(ball.transform.position,goal.transform.position)>30 ){ //long range shot
				var longs=Mathf.Round(60000/(longshots*longshots));
				if(Random.Range(0,longs)>1)
				{
					ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(10,19),ForceMode.Impulse); } //skys it
				else
				{
					ball.GetComponent<Rigidbody>().AddForce(Vector3.up*300/longshots,ForceMode.Impulse);}}
			Ball.owner=null;
		}
		if(state=="kicking")
			ball.GetComponent<Rigidbody>().AddForce(-transform.right*curve/100);
	}

	public void  PenaltyShoot (){/////////////////////////////////
		//state="kicking";timeout=2; 
		ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;
		float acc=100/penalties; float aim=Mathf.Pow(acc,3);
		float randx= Random.Range(-aim,aim);
		float randy= Random.Range(0.5f,aim/2); Vector3 randpos = new Vector3();
		if(Random.Range(0.0f,Mathf.Pow(100/penalties,1.6f))<=1.0f){
			if(Random.Range(0,1)==1)
			{ randpos=new Vector3(goal2.transform.position.x+randx,goal2.transform.position.y+randy,goal2.transform.position.z);}
			else
				randpos=new Vector3(goal3.transform.position.x+randx,goal3.transform.position.y+randy,goal3.transform.position.z);
		}
		else
			randpos=new Vector3(goal.transform.position.x+randx,goal.transform.position.y+randy,goal.transform.position.z);
		var direction=Vector3.Normalize(randpos-ball.transform.position);Ball.state="free";
		BallPoint.OrigPos=transform.position;
		ball.GetComponent<Rigidbody>().AddForce(direction*(hotshot*2/3),ForceMode.Impulse);  AI.shot=30;
		if(Random.Range(0,penalties/10)<=1)
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(9,20),ForceMode.Impulse);
		Ball.owner=null;

	}//////////////////////////////////////////////////////

	void  OnCollisionEnter ( Collision other  ){   AI.potentialoffside2=false;if(other.gameObject.name=="ball")AI.cameoff="p1";//collide with ball or player
		if(other.gameObject.name=="ball" && (AI.posession==5 || passing==true || AI.posession==9))return;
		if(other.gameObject.name=="ball" && AI.SHOOT==true && state!="clearing" && gameObject.tag=="Player")  //age old bug fixed forgot to check which item colliding
			Shoot();

		if((other.gameObject.name=="ball" && AI.posession==3)||(other.gameObject.name=="ball" && AI.posession==4)
			||(other.gameObject.name=="ball" && AI.posession==7) || timeout>0)
			return;

		if(other.gameObject.name=="ball" && global.p1onetwo>0 && global.returnto!=null && global.returnto!=gameObject)
		{OneTwoPass();return;}

		if(other.gameObject.name=="ball" && AI.CORNER && state=="heading")
		{Header();return;}

		if(other.gameObject.name=="ball" && other.rigidbody.velocity.magnitude>300/control && state!="posessing"){
			pass.Play();return;}
		if(timeout<=0 && acting==false){  //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
			if(other.gameObject.name=="ball" && state=="idle" && AI.posession==0)//free ball
			{state="posessing";Ball.state="posessed";AI.posessor=gameObject;AI.posession=1;//p2
				Ball.owner=gameObject;Ball.ownername=gameObject.name;
				if(Ball.ownername==gameObject.name){
					ball.transform.position=transform.position+Vector3.forward*1.2f;
					ball.GetComponent<Rigidbody>().isKinematic=true;}}//p2  vvvvvvvvvvvvvvvvvvvvvvvvv

			if(other.gameObject.name=="ball"  && state=="idle"  //collided posessed ball or player p2
				&& AI.posession==2 && AI.posessor==other.gameObject)//p2
			{state="snatching";vel=0.0f;}
		}
		var ctrl=Random.Range(0,control*2);
		if(other.gameObject.name=="ball" && ctrl<2 && state=="posessing"  && runintotraffic==false && dribbling==false && evading==false)LoseBall();
		if(state!="posessing")run=false;

		if(other.gameObject.name=="box")
		{ inbox=true; boxtimeout=2;}

	}
	//cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc
	void  OnCollisionStay ( Collision other  ){   if(other.gameObject.name=="ball" &&  AI.CORNER){Header();return;} if(AI.posession==5)return;
		if(global.p1onetwo>0 && global.returnto!=gameObject)return;
		if((other.gameObject.name=="ball" && AI.posession==3)||(other.gameObject.name=="ball" && AI.posession==4)
			||(other.gameObject.name=="ball" && AI.posession==7) || (other.gameObject.name=="ball" && (timeout>0 || passing==true || AI.posession==9)))//keeper has ball
			return;
		if(acting==false){
			if(other.gameObject.name=="ball" && state=="idle" && Random.Range(1,10)<=1 && timeout==0  && AI.posession==0)//free ball
			{state="posessing";Ball.state="posessed";AI.posessor=gameObject;Ball.owner=gameObject;AI.posession=1;//p2
				Ball.ownername=gameObject.name;
				if(Ball.ownername==gameObject.name)
					ball.transform.position=transform.position+Vector3.forward*1.2f;ball.GetComponent<Rigidbody>().isKinematic=true;}
		}
		var ctrl=Random.Range(0,control*2);
		if(ctrl<1 && state=="posessing"  && runintotraffic==false  && dribbling==false && evading==false ){LoseBall();}
		if(timeout<=0 && AI.posessor!=null && acting==false){
			if(other.gameObject.name=="ball" && state!="idle"  //collided posessed ball or player p2
				&& AI.posession==2 && AI.posessor.GetComponent<player2>().state=="posessing")//p2
			{state="snatching";}    }
		if(other.gameObject.tag=="Player2" && state!="idle"  //collided posessing player p2
			&& AI.posession==2 && other.gameObject.GetComponent<player2>().state=="posessing" && acting==false)//p2
		{ if(Vector3.Angle(other.transform.position-transform.position,other.transform.forward)>110) //not from behind
			{if(global.team1!=global.id ||(global.team1==global.id && (global.tackling=="soft"||global.tackling=="normal"))){
					state="snatching";}
			else if(global.team1==global.id && (global.tackling=="hard" || tackles=="hard"))
			{if(Random.Range(0,200)<=1)
				SlidingTackle();
			else
				state="snatching";}
		}
		else
		{if(other.gameObject.GetComponent<player2>().run==true && (global.team1!=global.id || 
			(global.team1==global.id && (global.tackling=="hard"||global.tackling=="normal" || tackles=="normal" || tackles=="hard") )) ) //p2
				SlidingTackle();
		else{
			if(Random.Range(0,20)<=1 &&(global.team1!=global.id || (global.team1==global.id && (global.tackling=="hard" || tackles=="hard")  )) ) //tactics
				SlidingTackle();}}
	}

		if(state=="posessing" && other.gameObject.tag=="Player2" && other.gameObject.GetComponent<player2>().disposessing==true
			&& other.gameObject.GetComponent<player2>().tackling==false) //disposessed
		{if(dribbling==true )
			{if(Random.Range(0,dribble)<=1)
				{
					state="disposessed";vel=0.0f;GetComponent<Animation>().Play("trip");GetComponent<Animation>()["trip"].speed=1.0f;acting=true;disposessedtimeout+=0.1f;timeout1=2;
					Ball.state="free";ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;var culprit=other.gameObject;StandingFoul(culprit);
					evading=false;;timeout2=0;Ball.owner=null;dribbling=false;passing=false;knocking=false;}}
		else
		{
			state="disposessed";vel=0.0f;GetComponent<Animation>().Play("trip");GetComponent<Animation>()["trip"].speed=1.0f;acting=true;disposessedtimeout+=0.1f;timeout1=2;
			Ball.state="free";ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;timeout2=0;var culprit=other.gameObject;StandingFoul(culprit);
			evading=false;Ball.owner=null;dribbling=false;passing=false;knocking=false;}}

		if(other.gameObject.name=="ball" && state=="posessing" && AI.posessor==null)
			AI.posessor=gameObject;

		if(state=="posessing" && other.gameObject.tag=="Player2" ){
			if( other.gameObject.GetComponent<player2>().tackling==true && other.gameObject.GetComponent<player2>().disposessing==false)//tackled
			{if(dribbling==true )
				{if(Random.Range(0.0f,dribble/50)<=1.0f)
					{state="falling";acting=true;falltimeout+=0.1f;GetComponent<Animation>().Play("fall");Ball.state="free";Ball.owner=null;
						AI.posession=0;dribbling=false;evading=false;var culprit=other.gameObject;Foul(culprit);;
						timeout2=0;runintotraffic=false;timeout1=2;passing=false;knocking=false;}}
			else
			{if(Random.Range(0,200)<other.gameObject.GetComponent<player2>().tackle) // standing disposess ball kick
				{acting=true;falltimeout+=0.1f;Ball.state="free";Ball.owner=null;timeout1=2;GetComponent<Animation>().Play("idle");timeout=4;
					AI.posession=0;timeout2=0;evading=false;ball.GetComponent<Rigidbody>().AddForce(other.transform.forward*10,ForceMode.Impulse);
					runintotraffic=false;dribbling=false;passing=false;knocking=false;}
			else
			{state="falling";acting=true;falltimeout+=0.1f;GetComponent<Animation>().Play("fall");Ball.state="free";Ball.owner=null;timeout1=2;
				AI.posession=0;timeout2=0;evading=false;var culprit=other.gameObject;Foul(culprit);
				runintotraffic=false;dribbling=false;passing=false;knocking=false;}   }
		}
		}
		//if(other.gameObject.name=="ball" && AI.posession==1 && Ball.state=="posessed" && state=="idle" && AI.posessor==gameObject){
    //punish+=1;
    //if(punish>100)
    // {state="posessing";punish=0;}
   // }
	}//cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc

	void  OnTriggerStay ( Collider other  ){ //if(AI.posession==7)return;  hit the wings
		if(other.gameObject.name=="cross" && state=="posessing" && ball.transform.position.z>0 && acting==false){//p2
			if(wings=="cross"){
				if(Random.Range(1,50)==1)
					Cross();
				if(ball.transform.position.z>56)
					Cross();
			}
			if(wings=="run to goal"){
				togoal=30;
			}
			if(wings=="backpass" && backpass==0){
				backpass=15;
				if(Random.Range(0,150)<=1)
				{passing=true;timeout1=40;} //backpas
			}
			if(wings=="mixed"){
				if(relax==0){
					relax=60;
					var dice=Random.Range(1,4);
					if(dice==1)
						Cross();
					if(dice==2)
						togoal=30;
					if(dice>=3 && backpass==0)
					{backpass=15;
					}
				}//r
				if(backpass>0 && Random.Range(0,150)<=1)
				{passing=true;timeout1=40;}
			}
		}//p2
		if(other.gameObject.name=="box")  //for penalty
		{inbox=true; boxtimeout=2;}
	}

	void  OnCollisionExit ( Collision other   ){ if(AI.posession==9 || AI.posession==3 || global.p1onetwo>0 || AI.posession==7 || AI.posession==4)return;
		if(other.gameObject.name=="ball" && state=="posessing" && Random.Range(0,20000/control)<=1 && evading==false && runintotraffic==false && dribbling==false
			&& passing==false && knocking==false)//dont lose ball if evading
		{state="idle";Ball.state="free";AI.posession=0;ball.GetComponent<Rigidbody>().isKinematic=false;Ball.owner=null;
			ball.transform.position+=Vector3.up*0.15f;
			ball.GetComponent<Rigidbody>().AddForce(transform.forward*(450/control),ForceMode.Impulse);}
	}

	void  StayUpright (){
		transform.eulerAngles= new Vector3(-5,transform.eulerAngles.y,transform.eulerAngles.z);
		transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
		if(state!="jumping" && transform.position.y>yprev)
			transform.position=new Vector3(transform.position.x,yprev,transform.eulerAngles.z);
	}

	void  LoseBall (){ 
		state="idle";Ball.state="free";ball.GetComponent<Rigidbody>().isKinematic=false; ball.transform.position+=transform.forward+Vector3.up*0.2f;
		if(run==true)
		{if(Ball.owner!=null)
			{ball.GetComponent<Rigidbody>().AddForce(transform.forward*(750/control),ForceMode.Impulse);}}
		else
		{if(Ball.owner!=null)
			{if(ball.transform.position.y>0.8f)
				ball.transform.position= new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z);
				ball.GetComponent<Rigidbody>().AddForce(transform.forward*(450/control),ForceMode.Impulse);}}
		timeout=2;if(AI.posession<4)AI.posession=0;Ball.owner=null;//p2
	}

	void  RotateToGoal (){
		var dir= Vector3.forward;  //p2
		float singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	void  RotateToRealGoal (){
		var dir= (spot.position-Vector3.forward*3)-transform.position;  //p2
		float singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	void  RotateBack (){
		var dir= ownspot.position-transform.position;  //p2
		float singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	float  DistanceToGoal (){
		return Vector3.Distance(transform.position,goal.transform.position);
	}

	void  Disposess (){
		if(Vector3.Distance(transform.position,ball.transform.position)<30)
		{ 
			if(global.team1==global.id)
				RotateToIntercept(ball);
			else
				RotateTo(ball);
			if(AI.posessor!=null && AI.posessor.GetComponent<player2>()!=null){
				if(AI.posessor.GetComponent<player2>().run || run){//if opponent is running  p2
					if(vel<speed)
						vel+=acceleration;
					GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*(speed+0.04f)*Time.timeScale);} 
				else
				{GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*0.7f*Time.timeScale);vel=0.0f;}  }
		}
		else
		{if(AI.posession!=2)//p2  opponent has no ball
			MoveToPosition();} 
		if(!GetComponent<Animation>().IsPlaying("jog") && run==false && dribbling==false)
			GetComponent<Animation>().Play("jog");
		if(!GetComponent<Animation>().IsPlaying("run") && run==true && dribbling==false)
			GetComponent<Animation>().Play("run");
		GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*animspeedmax;
		GetComponent<Animation>()["run"].speed = GetComponent<Rigidbody>().velocity.magnitude*1.5f;
		if(Ball.state!="posessed" && AI.posession==0 && state=="disposess")
			state="idle";

	}

	void  MoveToPosition (){
		if(global.marking=="man" && global.team1==global.id && (name=="player7" || name=="player8"|| name=="player9"|| name=="player10")){
			ManMark();
		}
		else if(global.marking=="backup" && global.team1==global.id && (name=="player7" || name=="player8"|| name=="player9"))
			Backup();
		else if(global.marking=="cutoff" && global.team1==global.id && (name=="player7" || name=="player8"|| name=="player9" ||
			name=="player10" || name=="player4"|| name=="player5"))
			Cutoff();
		else if((name=="player" || name=="player2" || name=="player3" ) && global.team1==global.id && global.attacking=="move to channels"){
			MoveToChannel(); 
		}
		else if(global.attacking=="beat offside" && (name=="player" || name=="player2" || name=="player3" || name=="player6") && global.team1==global.id  ){
			HugLine(); 
		}
		else{
			GameObject offsideline=GameObject.Find("offsideline");
			if(ball.transform.position.z>offsideline.transform.position.z)
				run=false;
			RotateTo(position.gameObject);
			if(GetComponent<Rigidbody>().velocity.magnitude>0.01f)
			{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().CrossFade("jog");
				GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
			else
			{GetComponent<Animation>()["idle"].speed=0.0f;}

			if(Random.Range(0,50)<=1)
			{ position.position=new Vector3(position.gameObject.GetComponent<position1>().fixedposx+Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f)),transform.position.y,transform.position.z);
				position.position=new Vector3(transform.position.x,transform.position.y, position.gameObject.GetComponent<position1>().fixedposz+Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f)) );
				realpos=position.transform.position+new Vector3(Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f)),0.8f,
					Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f)))  ;}
			if(Vector3.Distance(transform.position,realpos)>0.0f){
				if(Vector3.Angle(transform.forward,position.transform.position-transform.position)<45){
					if(run)
						GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*Time.timeScale);
					else
						GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*0.7f*Time.timeScale);vel=0.0f;}}
			else
			{transform.LookAt(ball.transform);if(GetComponent<Rigidbody>().velocity.magnitude<0.01f)GetComponent<Animation>().Play("idle");GetComponent<Animation>()["idle"].speed=0.01f;} 

		}
	}

	void  Snatch (){
		if(AI.posessor.GetComponent<player2>().dribbling==false){ //p2
			var dice=Random.Range(0,2500/tackle); //successful tackle
			if(dice<=1)
			{ 
				snatching.Play();disposessing=true;vel=0.0f;disposesstimeout+=Time.deltaTime;
				//ball.rigidbody.isKinematic=false;Ball.owner=null;
				//snatch disposessing for other player to react accordingly
				//sliding tackle  use for high speed
			} 
		}
		else{  //chance against dribbling

		}
		if(Ball.state!="posessed" && AI.posession==0 )
			state="idle";
	}

	void  SlidingTackle (){
		if(state!="tackling"){
			state="tackling";acting=true; tackletimeout=0.1f;
			if(!GetComponent<Animation>().IsPlaying("tackle"))
				GetComponent<Animation>().Play("tackle");Tackling.Play();
			tacklespeed=Random.Range(0.2f,0.4f);vel=0.0f;
		}
	}

	void  Tackle (){
		var dice=Random.Range(0,1000/tackle);
		if(dice<=1){
			//tackled=true;
			tackledtimeout=2;
			if(Ball.owner!=null)
				ball.GetComponent<Rigidbody>().AddForce(transform.forward*Random.Range(0.5f,1.5f),ForceMode.Impulse);
			tackling=true;//Ball.owner=null;

		}
	}

	void  Celebrate (){
		GameObject point=GameObject.Find("celebraterun"); //p2
		transform.LookAt(point.transform);
		if(!GetComponent<Animation>().IsPlaying("celebrate"))
			GetComponent<Animation>().Play("celebrate");
		GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed);
	}

	void  Dribble (){ 
		if(timeout1==0 && dribbling)
		{if(toggle==true)
			toggle=false;
		else
			toggle=true;timeout1=50;Dribbles.Play();
		Quaternion.LookRotation(Vector3.forward);GetComponent<Animation>().Play("dribble");}
		//timeout1-=1;
		if(timeout1==2 ){ //infinite loop fix
			if(toggle==true)
				toggle=false;
			else
				toggle=true;
			timeout2++;
			timeout1=50;
			if(Random.Range(1,4)==1)
				timeout2=2;
			if(timeout2==2){
				timeout2=0;dribbling=false;acting=false;}
		}
		if(toggle==false)
		{if(timeout1>40)
			GetComponent<Rigidbody>().MovePosition(transform.position+(Vector3.forward+Vector3.right)*speed*1.0f*Time.timeScale);
		else
			GetComponent<Rigidbody>().MovePosition(transform.position+(Vector3.forward+Vector3.right)*speed*2/3*Time.timeScale);}  //p2
		else
		{if(timeout1>40)
			GetComponent<Rigidbody>().MovePosition(transform.position+(Vector3.forward-Vector3.right)*speed*1.0f*Time.timeScale); 
		else
			GetComponent<Rigidbody>().MovePosition(transform.position+(Vector3.forward-Vector3.right)*speed*2/3*Time.timeScale); } //p2

		if(!GetComponent<Animation>().IsPlaying("dribble"))
			GetComponent<Animation>().Play("dribble");
		GetComponent<Animation>()["dribble"].speed=1.5f;
	}


	void  Pass (){    int choice=new int();       // adjust later for passing or crossing

		if(timeout1==39)
		{
			if(ball.transform.position.y<0.8f)
				ball.transform.position= new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z);state="passing";
			float accuracy=Random.Range(Mathf.Pow(-100/passes,3),Mathf.Pow(100/passes,3));

			if(global.team1!=global.id){  
				 choice= Random.Range(0,5);
				if(choice<=1 ){ if(teammate1.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
					if(ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-10)direction=Vector3.zero;
					else                 //to be continued for tactics and to pass to opponents
					 direction=((teammate1.transform.position)+transform.forward*accuracy)-transform.position;}
				if(choice==2 ){ if(teammate2.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
					if(ball.transform.position.z>10 && teammate2.transform.position.z<transform.position.z-10)direction=Vector3.zero;
					else                 //to be continued for tactics and to pass to opponents
						direction=((teammate2.transform.position)+transform.forward*accuracy)-transform.position;}
				if(choice==3 ){ if(teammate3.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
					if(ball.transform.position.z>10 && teammate3.transform.position.z<transform.position.z-10)direction=Vector3.zero;
					else                 //to be continued for tactics and to pass to opponents
						direction=((teammate3.transform.position)+transform.forward*accuracy)-transform.position;}
				if(choice>=4 ){ if(teammate4.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
					if(ball.transform.position.z>10 && teammate4.transform.position.z<transform.position.z-10)direction=Vector3.zero;
					else                //to be continued for tactics and to pass to opponents
						direction=((teammate4.transform.position)+transform.forward*accuracy)-transform.position;}

			}
			else
				choice = Random.Range(0,5);
			if(global.passingstyle=="mixed" && global.team1==global.id){
				AIPass(choice);
			}
			else if(global.passingstyle=="short"  && global.team1==global.id){
				ShortPass();
			}
			else if(global.passingstyle=="long"  && global.team1==global.id){
				LongPass();
			}

		}
		if(timeout1<39){ Vector3 point=new Vector3(); //int choice=new int();
			if(choice<=1 ){ if((ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-10 && global.team1!=global.id)
				||(ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-10 && global.team1==global.id && global.mentality!="attacking")
				||(global.mentality=="attacking" && global.team1==global.id && teammate1.transform.position.z<transform.position.z-3 ))direction=Vector3.zero;
			else
			{ point= teammate1.transform.position+transform.forward*accuracy;}      //to be continued for tactics and to pass to opponents
			direction=point-transform.position;}
			if(choice==2 ){ 
				if((ball.transform.position.z>10 && teammate2.transform.position.z<transform.position.z-10 && global.team1!=global.id)
					||(ball.transform.position.z>10 && teammate2.transform.position.z<transform.position.z-10 && global.team1==global.id && global.mentality!="attacking")
					||(global.mentality=="attacking" && global.team1==global.id && teammate2.transform.position.z<transform.position.z-3 ))direction=Vector3.zero;
				else //to be continued for tactics and to pass to opponents
					direction=teammate2.transform.position+transform.forward*accuracy-transform.position;}
			if(choice==3 ){ 
				if((ball.transform.position.z>10 && teammate3.transform.position.z<transform.position.z-10 && global.team1!=global.id)
					||(ball.transform.position.z>10 && teammate3.transform.position.z<transform.position.z-10 && global.team1==global.id && global.mentality!="attacking")
					||(global.mentality=="attacking" && global.team1==global.id && teammate3.transform.position.z<transform.position.z-3 ))direction=Vector3.zero;
				else    //to be continued for tactics and to pass to opponents
					direction=teammate3.transform.position+transform.forward*accuracy-transform.position;}
			if(choice>=4 ){ 
				if((ball.transform.position.z>10 && teammate4.transform.position.z<transform.position.z-10 && global.team1!=global.id)
					||(ball.transform.position.z>10 && teammate4.transform.position.z<transform.position.z-10 && global.team1==global.id && global.mentality!="attacking")
					||(global.mentality=="attacking" && global.team1==global.id && teammate4.transform.position.z<transform.position.z-3 ))direction=Vector3.zero;
				else  //to be continued for tactics and to pass to opponents
					direction=teammate4.transform.position+transform.forward*accuracy-transform.position;}
		}
		//direction=teammate1.transform.position-transform.position;;
		if(timeout1==38){   

			//ball.transform.position=transform.position+transform.forward*0.5f;
			if(direction.magnitude>0.0f){
				timeout=4;ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;  
				Ball.state="free";dontcollide=5;
				pass.Play();
				var force=Random.Range(18,26);
				acting=true;

				transform.rotation=Quaternion.LookRotation(direction);
				Ball.owner=null;
				ball.GetComponent<Rigidbody>().AddForce(transform.forward*force,ForceMode.Impulse);
				if(dist>30 && passheight!="flat")
				{if(Random.Range(0.0f,1.0f)<(1.0f*crossing/100)*(1.0f*crossing/100))
					ball.GetComponent<Rigidbody>().AddForce(transform.up*Random.Range(7,10),ForceMode.Impulse);
				else
					ball.GetComponent<Rigidbody>().AddForce(transform.up*Random.Range(13,18),ForceMode.Impulse);}//lob at distant players
				else if(passheight=="lob" && dist<30)
				{if(Random.Range(0.0f,1.0f)<(1.0f*crossing/100)*(1.0f*crossing/100))
					ball.GetComponent<Rigidbody>().AddForce(transform.up*Random.Range(7,10),ForceMode.Impulse);
				else
					ball.GetComponent<Rigidbody>().AddForce(transform.up*Random.Range(13,18),ForceMode.Impulse);}

				if(!GetComponent<Animation>().IsPlaying("pass"))
					GetComponent<Animation>().Play("pass");
			}
			else
			{passing=false;acting=false;state="posessing";Ball.state="posessed";AI.posession=1;ball.GetComponent<Rigidbody>().isKinematic=true;Ball.owner=gameObject;}
			if(state=="passing" && global.p1onetwo>0)
				state="onetwoing";
		}//timeout39

		if(timeout1==1 && state=="passing"){
			acting=false;state="idle";passing=false;} 
	}
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void  Evade (){  Vector3 dir=new Vector3();
		//if(timeout1==0)
		//state="posessing";
		if(timeout1==150)
		{if(Random.Range(1,3)==1)
			{ dir=transform.forward+transform.right*0.5f;}
		else
			dir = transform.position-goal.transform.position;acting=true;}
		if(Random.Range(0,200)<=1){
			if(Random.Range(0,3)<=1)
 				dir = Vector3.right;
			else
				dir = -Vector3.right;}
		float singleStep= agility*0.25f * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
		GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*1/2*Time.timeScale);
		if(!GetComponent<Animation>().IsPlaying("jog"))
			GetComponent<Animation>().Play("jog");
		if(timeout1==1){
			evading=false;;acting=false;} //error found timeout instead of timeout1
	}

	void  KnockOn (){ 
		if(state=="clearing")
			return;
		if(timeout1==99)
		{timeout=5;ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;  
			Ball.state="free";  DontCollide();
			pass.Play(); acting=true;
			state="knocking"; ball.transform.position=transform.position+transform.forward*0.8f+Vector3.up*0.1f;
			if(Ball.owner!=null)
			{if(vkeeper)
				{if(Random.Range(0,2)==1)
					ball.GetComponent<Rigidbody>().AddForce((Vector3.forward+Vector3.right*0.5f)*(hotshot/6),ForceMode.Impulse);
				else
					ball.GetComponent<Rigidbody>().AddForce((Vector3.forward-Vector3.right*0.5f)*(hotshot/6),ForceMode.Impulse);Ball.owner=null;vkeeper=false;}
			else
				ball.GetComponent<Rigidbody>().AddForce(Vector3.forward*(hotshot/6),ForceMode.Impulse);Ball.owner=null;}}
		GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*Time.timeScale);
		if(!GetComponent<Animation>().IsPlaying("run"))
			GetComponent<Animation>().Play("run");
		if(timeout1==1 && state=="knocking"){
			knocking=false;state="idle";acting=false;}
	}
	//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	void  RunIntoTraffic (){   
		GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*Time.timeScale);
		if(!GetComponent<Animation>().IsPlaying("run"))
			GetComponent<Animation>().Play("run");GetComponent<Animation>()["run"].speed=GetComponent<Rigidbody>().velocity.magnitude*2.5f;
		if(timeout1==1){ 
			runintotraffic=false;acting=false;  //state= idle bug fixed
			}
	}

	void  Clear (){ 
		if(timeout>0)return;//
		if(dribbling==false && passing==false && evading==false && knocking==false && runintotraffic==false && acting==false && shottimeout==0)
		{shottimeout=31;acting=true;state="clearing";  //bug fix
			if(!GetComponent<Animation>().IsPlaying("kick"))
				GetComponent<Animation>().Play("kick");}
		if(shottimeout==30 && state=="clearing"){ state="kicking";timeout=10; 
			kick.Play();ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;
			Ball.state="free";
			ball.GetComponent<Rigidbody>().AddForce(Vector3.forward*hotshot*Random.Range(0.3f,0.6f),ForceMode.Impulse);    //p2

			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(15,20),ForceMode.Impulse);Ball.owner=null; } //skys it

	}


	void  Lob (){
		if(state=="posessing" && dribbling==false && passing==false && evading==false && knocking==false && runintotraffic==false){
			GetComponent<Animation>().Play("kick");
			pass.Play();ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;timeout=2;
			Ball.state="free";
			ball.GetComponent<Rigidbody>().AddForce(Vector3.forward*(hotshot*1/4),ForceMode.Impulse);    //p2
			state="idle";
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(8,12),ForceMode.Impulse);  //lob

			Ball.owner=null;}
	}

	void  Cross (){ Vector3 direction = new Vector3();
		pass.Play();ball.GetComponent<Rigidbody>().isKinematic=false;if(AI.posession<4)AI.posession=0;
		if(transform.position.x>0)
		{ direction=-Vector3.right+Vector3.forward*Random.Range(-5.0f/crossing,5.0f/crossing);}
		else
			direction=Vector3.right+Vector3.forward*Random.Range(-5.0f/crossing,5.0f/crossing); //p2
		Ball.state="free";timeout=2;state="crossing";crosstimeout=30;
		if(Random.Range(0,Mathf.RoundToInt(crossing/20))<1)
			ball.GetComponent<Rigidbody>().AddForce(direction*(hotshot*Random.Range(0.35f,0.6f)),ForceMode.Impulse);
		else
			ball.GetComponent<Rigidbody>().AddForce(direction*(hotshot*Random.Range(0.1f,0.35f)),ForceMode.Impulse); AI.CORNER=true; 
		if(Random.Range(0,Mathf.RoundToInt(500/crossing))<1)
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(7.0f,12.0f),ForceMode.Impulse);
		else
		{if(Random.Range(0,Mathf.RoundToInt(crossing/20))<1)
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(10.0f,16.0f),ForceMode.Impulse);}
		Ball.owner=null;
		GetComponent<Animation>().Play("pass");
	}

	void  Head (){
		if(state!="heading")
			timeout1=60;
		if(timeout1==59){  
			state="heading"; acting=true;
			GetComponent<Rigidbody>().AddForce(Vector3.up*jumping/5,ForceMode.Impulse);
			GetComponent<Animation>().Play("header");
		}
		if(timeout1==1)
		{state="idle";acting=false;}
		var pos=new Vector3(transform.position.x,transform.position.y,ball.transform.position.z);
		var you=transform.position;
		GetComponent<Rigidbody>().MovePosition(transform.position+(pos-you)*speed*0.25f*Time.timeScale);
	}

	void  Header (){
		if(headed==true)return;
		headed=true; BallPoint.OrigPos=transform.position;AI.shot=20;
		kick.Play();ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;
		float acc=100/heading; float aim=Mathf.Pow(acc,3);
		float randx= Random.Range(-aim,aim);
		float randy= Random.Range(0.5f,aim/2);
		var randpos=new Vector3(goal.transform.position.x+randx,goal.transform.position.y+randy,goal.transform.position.z);
		var direction=Vector3.Normalize(randpos-ball.transform.position);Ball.state="free";

		ball.GetComponent<Rigidbody>().AddForce(direction*(1.0f*hotshot*1/2),ForceMode.Impulse);  AI.shot=50;
		if(Random.Range(1.0f,200/heading)>1.0f)
		{
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(7,13),ForceMode.Impulse); }
		Ball.owner=null;

	}

	void  FreeKick (){ Vector3 aim=new Vector3(); int luck = new int();
		freekicktimeout+=Time.deltaTime;  AI.cameoff="p1";
		GetComponent<Animation>().Play("kick");
		if(freekicktimeout>0.0f && freekicktimeout<=0.0f+Time.deltaTime*2)
		{ball.GetComponent<Rigidbody>().isKinematic=false;Ball.state="free";Ball.owner=null;}
		if(freekicktimeout>Time.deltaTime*2 && freekicktimeout<=(Time.deltaTime*2)+Time.deltaTime*2){ luck=Random.Range(0,160); 
			//if(AI.posession!=5)
			AI.posession=0;
			float acc=-10000/(freekicks*freekicks);
			var dice=Random.Range(0,3);
			if(dice==3)
			{ aim=goal2.transform.position;}
			if(dice==2)
				aim=goal3.transform.position;
			else
				aim=kposopp.transform.position;
			if(Vector3.Distance(ball.transform.position,kposopp.position)<35){ 
				kick.Play();
				ball.GetComponent<Rigidbody>().AddForce(Vector3.Normalize((aim+Vector3.right*Random.Range(-acc,acc))-ball.transform.position)*hotshot*3/7*Random.Range(0.9f,1.5f),ForceMode.Impulse);
				ball.GetComponent<Rigidbody>().AddForce(Vector3.up*10,ForceMode.Impulse);
			}
			else
			{pass.Play();
				ball.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(teammate1.transform.position-ball.transform.position)*Random.Range(6,13),ForceMode.Impulse);
				ball.GetComponent<Rigidbody>().AddForce(Vector3.up*1,ForceMode.Impulse);}//pass to mate
			timeout1=20; }//o.0
		if(freekicktimeout>=0.0f+Time.deltaTime && freekicktimeout<=1.7f){  //add ball curvature
			if(Vector3.Distance(ball.transform.position,kposopp.position)<31)
			{if(luck<freekicks)
				ball.GetComponent<Rigidbody>().AddForce(-Vector3.up*freekicks/8);
			else
				ball.GetComponent<Rigidbody>().AddForce(-Vector3.up*freekicks/20);
			ball.GetComponent<Rigidbody>().AddForce(-Vector3.right*50/curve);}
		}
		if(freekicktimeout>=2.0f)
		{freekicktimeout=0.0f;state="idle";acting=false;}
	}

	void  Foul ( GameObject other  ){
		disposessing=false; other.GetComponent<player2>().disposessing=false;other.GetComponent<player2>().tackling=false;
		other.GetComponent<player2>().acting=false;
		var dice= Random.Range(0,other.gameObject.GetComponent<player2>().tackle/10); // foul chance
		if(dice<=1)
		{AI.posession=7; whistle.Play();dribbling=false; passing=false;evading=false;knocking=false;runintotraffic=false;//foul
			if(inbox && ball.transform.position.z>0.0f){  //p2
				AI.state="penaltytop1";                      //p2
				if(other.gameObject.GetComponent<player2>().booked)
					dice=Random.Range(0,600/other.gameObject.GetComponent<player2>().aggression);
				else
					dice=Random.Range(0,other.gameObject.GetComponent<player2>().tackle/5);
				if(dice<=1)
				{if(global.number2sentoff<4)
					{AI.culprit=other;AI.book=true;
						if(other.gameObject.GetComponent<player2>().booked)
						{bookedprompt.SetActive(false);sentoffprompt.SetActive(true);sentofftext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" sent off!.";
							BookPlayer(other);}
						else
						{bookedprompt.SetActive(true);foulprompt.SetActive(false);bookedtext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" has been booked.";
							other.GetComponent<player2>().booked=true;other.GetComponent<player2>().Book();}}  //booked
				}
			}
			else {
				//p2   out of box
				AI.state="freekicktop1";    GetComponent<Animation>().Play("idle");other.GetComponent<Animation>().Play("idle");                   //p2
				if(other.gameObject.GetComponent<player2>().booked)
					dice=Random.Range(0,500/other.gameObject.GetComponent<player2>().aggression);
				else
					dice=Random.Range(0,other.gameObject.GetComponent<player2>().tackle/5);
				if(dice<=1)
				{if(global.number2sentoff<4)
					{if(other.gameObject.GetComponent<player2>().booked)
						{AI.book=true;bookedprompt.SetActive(false);sentoffprompt.SetActive(true);sentofftext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" sent off!.";
							BookPlayer(other);}
					else
					{ bookedprompt.SetActive(true);foulprompt.SetActive(false);bookedtext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" has been booked." ;} }//booked
					AI.culprit=other;other.GetComponent<player2>().booked=true;other.GetComponent<player2>().Book();}
				AI.freekickx=transform.position.x;
				AI.freekickz=transform.position.z;                    
			}

			AI.culprit=other; 
			AI.victim=gameObject;     state="idle"; 
			foulprompt.SetActive(true);
		}//foul mechanism
	}

	void  StandingFoul ( GameObject other  ){
		disposessing=false; other.GetComponent<player2>().disposessing=false;other.GetComponent<player2>().tackling=false;
		other.GetComponent<player2>().acting=false;
		var dice= Random.Range(0,other.gameObject.GetComponent<player2>().tackle/5); // foul chance
		if(dice<=1)
		{AI.posession=7; whistle.Play();dribbling=false; passing=false;evading=false;knocking=false;runintotraffic=false;//foul
			if(inbox && ball.transform.position.z>0.0f){  //p2
				AI.state="penaltytop1";                      //p2
				dice=Random.Range(0,other.gameObject.GetComponent<player2>().tackle/2);
				if(dice<=1)
				{if(global.number2sentoff<4 && other.GetComponent<player2>().booked==false)
					{bookedprompt.SetActive(true);bookedtext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" has been booked."; 
						other.GetComponent<player2>().booked=true;other.GetComponent<player2>().Book(); } //booked
					AI.culprit=other;}
			}
			else {
				//p2   out of box
				AI.state="freekicktop1";   GetComponent<Animation>().Play("idle");                    //p2
				dice=Random.Range(0,other.gameObject.GetComponent<player2>().tackle/2);
				if(dice<=1)
				{if(global.number2sentoff<4 && other.GetComponent<player2>().booked==false)
					{bookedprompt.SetActive(true);bookedtext.GetComponent<Text>().text=other.GetComponent<player2>().playername+" has been booked."; 
						other.GetComponent<player2>().booked=true;other.GetComponent<player2>().Book(); }//booked
					AI.culprit=other;}
				AI.freekickx=transform.position.x;
				AI.freekickz=transform.position.z;                    
			}
			AI.culprit=other; ;
			AI.victim=gameObject;
			foulprompt.SetActive(true);
		}//foul mechanism


	}

	void  CheckOffside (){

		if(transform.position.z<offsideline2.transform.position.z && state=="posessing")
			AI.potentialoffside1=true;
		if(transform.position.z>offsideline2.transform.position.z && transform.position.z>0 && state!="posessing")
			offside=true;
		else
			offside=false;
	}

	void  Offside (){
		AI.posession=7; whistle.Play();//foul
		dribbling=false; passing=false;evading=false;knocking=false;runintotraffic=false;
		AI.offside=true;GameObject.Find("AI").GetComponent<AI>().offsideprompt.SetActive(true);
		//p2   out of box
		AI.state="freekicktop2";                       //p2

		AI.freekickx=transform.position.x;
		AI.freekickz=transform.position.z;                    

		// AI.culprit=other.gameObject; 
		// AI.victim=gameObject;
	}

	void  DontCollide (){
		GameObject.Find("player2opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("playeropp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player3opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player4opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player5opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player6opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player7opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player8opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player9opp").GetComponent<player2>().dontcollide=7;
		GameObject.Find("player10opp").GetComponent<player2>().dontcollide=7;
	}

	void  BookPlayer ( GameObject player  ){ //def endian
		if(player.name=="playeropp")
			global.p11sentoff=true;
		if(player.name=="player2opp")
			global.p22sentoff=true;
		if(player.name=="player3opp")
			global.p33sentoff=true;
		if(player.name=="player4opp")
			global.p44sentoff=true;
		if(player.name=="player5opp")
			global.p55sentoff=true;
		if(player.name=="player6opp")
			global.p66sentoff=true;
		if(player.name=="player7opp")
			global.p77sentoff=true;
		if(player.name=="player8opp")
			global.p88sentoff=true;
		if(player.name=="player9opp")
			global.p99sentoff=true;
		if(player.name=="player10opp")
			global.p1010sentoff=true;global.number1sentoff++;
		AI.book=false;
	}

	void  AIPass ( int choice  ){  //human player only

		if(choice<=1 && teammate1!=null){ if(teammate1.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
			if((ball.transform.position.z>10 && teammate1.transform.position.z<transform.position.z-10 && global.mentality!="attacking" &&global.team1==global.id)
				||(global.mentality=="attacking" && global.team1==global.id && teammate1.transform.position.z<transform.position.z-5 ))direction=Vector3.zero;
			else                //to be continued for tactics and to pass to opponents
				direction=((teammate1.transform.position)+transform.right*accuracy)-transform.position;}
		if(choice==2 && teammate2!=null){ if(teammate2.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
			if((ball.transform.position.z>10 && teammate2.transform.position.z<transform.position.z-10  && global.mentality!="attacking"&&global.team1==global.id)
				||(global.mentality=="attacking" && global.team1==global.id && teammate2.transform.position.z<transform.position.z-5 ))direction=Vector3.zero;
			else                 //to be continued for tactics and to pass to opponents
				direction=((teammate2.transform.position)+transform.right*accuracy)-transform.position;}
		if(choice==3 && teammate3!=null){ if(teammate3.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
			if((ball.transform.position.z>10 && teammate3.transform.position.z<transform.position.z-10 && global.mentality!="attacking"&&global.team1==global.id)
				||(global.mentality=="attacking" && global.team1==global.id && teammate3.transform.position.z<transform.position.z-5 ))direction=Vector3.zero;
			else                  //to be continued for tactics and to pass to opponents
				direction=((teammate3.transform.position)+transform.right*accuracy)-transform.position;}
		if(choice>=4 && teammate4!=null){ if(teammate4.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
			if((ball.transform.position.z>10 && teammate4.transform.position.z<transform.position.z-10 && global.mentality!="attacking"&&global.team1==global.id)
				||(global.mentality=="attacking" && global.team1==global.id && teammate4.transform.position.z<transform.position.z-5 ))direction=Vector3.zero;
			else                 //to be continued for tactics and to pass to opponents
				direction=((teammate4.transform.position)+transform.right*accuracy)-transform.position;}
	}

	void  ShortPass (){
		var options=new List<string>();
		if(Vector3.Distance(transform.position,teammate1.transform.position)<15)
			options.Add("one");
		if(Vector3.Distance(transform.position,teammate2.transform.position)<15)
			options.Add("two");
		if(Vector3.Distance(transform.position,teammate3.transform.position)<15)
			options.Add("three");
		if(Vector3.Distance(transform.position,teammate4.transform.position)<15)
			options.Add("four");
		if(options.Count>0){
			var choice= Random.Range(0,options.Count);
			if(options[choice]=="one" && teammate1!=null){ if(teammate1.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate1.transform.position);//transform.LookAt(teammate1.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate1.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="two" && teammate2!=null){ if(teammate2.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate2.transform.position);//transform.LookAt(teammate2.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate2.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="three" && teammate3!=null){ if(teammate3.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate3.transform.position);//transform.LookAt(teammate3.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate3.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="four" && teammate4!=null){ if(teammate4.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate4.transform.position);//transform.LookAt(teammate4.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate4.transform.position)+transform.right*accuracy-transform.position);}
		}
	}

	void  LongPass (){
		var options=new List<string>();
		if(Vector3.Distance(transform.position,teammate1.transform.position)>15)
			options.Add("one");
		if(Vector3.Distance(transform.position,teammate2.transform.position)>15)
			options.Add("two");
		if(Vector3.Distance(transform.position,teammate3.transform.position)>15)
			options.Add("three");
		if(Vector3.Distance(transform.position,teammate4.transform.position)>15)
			options.Add("four");
		if(options.Count>0){
			var choice= Random.Range(0,options.Count);
			if(options[choice]=="one" && teammate1!=null){ if(teammate1.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate1.transform.position);//transform.LookAt(teammate1.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate1.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="two" && teammate2!=null){ if(teammate2.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate2.transform.position);//transform.LookAt(teammate2.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate2.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="three" && teammate3!=null){ if(teammate3.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate3.transform.position);//transform.LookAt(teammate3.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate3.transform.position)+transform.right*accuracy-transform.position);}
			if(options[choice]=="four" && teammate4!=null){ if(teammate4.GetComponent<player>().offside && transform.position.z<offsideline2.transform.position.z){Offside();offside=false;AI.potentialoffside1=false;}
				//dist=Vector3.Distance(transform.position,teammate4.transform.position);//transform.LookAt(teammate4.transform);                  //to be continued for tactics and to pass to opponents
				direction=Vector3.Normalize((teammate4.transform.position)+transform.right*accuracy-transform.position);}
		}
	}

	void  OneTwoPass (){
		pass.Play();  var force=Vector3.Distance(global.returnto.transform.position,transform.position);
		GetComponent<Animation>().Play("kick");Ball.state="free";ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;Ball.owner=null; 
		ball.GetComponent<Rigidbody>().AddForce(((global.returnto.transform.position+global.returnto.transform.forward)-transform.position)*force,ForceMode.Impulse);
	}

	void  ThroughPass (){
		pass.Play();  var force=Random.Range(16,20);
		GetComponent<Animation>().Play("kick");
		if(Random.Range(0,1)==1)
		{ball.GetComponent<Rigidbody>().AddForce(((teammate1.transform.position+Vector3.forward*3)-transform.position)*force,ForceMode.Impulse);
			teammate1.GetComponent<player>().throughball=40;}
		else
		{ball.GetComponent<Rigidbody>().AddForce(((teammate2.transform.position+Vector3.forward*3)-transform.position)*force,ForceMode.Impulse);
			teammate2.GetComponent<player>().throughball=40;}
		Ball.state="free";ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;Ball.owner=null; 
	}

	void  ManMark (){ GameObject target;
		if(name=="player7" && global.p66sentoff==false)
		{ target=GameObject.Find("player6opp");}
		else if(name=="player8" && global.p11sentoff==false)
			target=GameObject.Find("player2opp");
		else if(name=="player9" && global.p22sentoff==false)
			target=GameObject.Find("playeropp");
		else if(name=="player10" && global.p22sentoff==false)
			target=GameObject.Find("player3opp");
		else
			target=position.gameObject;

		RotateTo(target);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.0051f)
		{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().CrossFade("jog");
			GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && dribbling==false)GetComponent<Animation>().Play("idle");}

		if(Random.Range(0,50)<=1)
		{ //position.position.x=position.gameObject.GetComponent<position1>().fixedposx+Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f));
			//position.position.z=position.gameObject.GetComponent<position1>().fixedposz+Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f));
			realpos=target.transform.position-Vector3.forward*Random.Range(1.5f,3.0f)+Vector3.right*(10000/(positioning*positioning))  ;}
		if(Vector3.Distance(transform.position,realpos)>0.0f){
			if(Vector3.Angle(transform.forward,target.transform.position-transform.position)<45)
				GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(realpos-transform.position)*speed*0.7f*Time.timeScale);vel=0.0f;}
		else
		{transform.LookAt(ball.transform);GetComponent<Animation>()["idle"].speed=0.01f;}
	}

	void  Backup (){ GameObject target;
		GameObject teammate8=GameObject.Find("player8");GameObject teammate9=GameObject.Find("player9");GameObject teammate10=GameObject.Find("player10");
		GameObject teammate7=GameObject.Find("player7");
		if(name=="player7" && AI.posession==2 && Vector3.Distance(teammate8.transform.position,ball.transform.position)<12 &&
			teammate8.GetComponent<player>().state=="disposess")
		{ target=teammate8;}
		else if(name=="player8" && AI.posession==2 && Vector3.Distance(teammate9.transform.position,ball.transform.position)<12 &&
			teammate9.GetComponent<player>().state=="disposess")
			target=teammate9;
		else if(name=="player9" && AI.posession==2 && Vector3.Distance(teammate10.transform.position,ball.transform.position)<12 &&
			teammate10.GetComponent<player>().state=="disposess")
			target=teammate10;
		else
			target=position.gameObject;

		RotateTo(target);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.01f)
		{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().CrossFade("jog");
			GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && dribbling==false)GetComponent<Animation>().Play("idle");}

		if(Random.Range(0,50)<=1)
		{ //position.position.x=position.gameObject.GetComponent<position1>().fixedposx+Random.Range(-Mathf.Pow(200.0f/(positioning*1.0f),1.5f),Mathf.Pow(200.0f/(positioning*1.0f),1.5f));
			if(target==position.gameObject)
				realpos=target.transform.position ;
			else
				realpos=target.transform.position-Vector3.forward*Random.Range(3.5f,6.0f)+Vector3.right*(10000/(positioning*positioning)) ;}
		if(Vector3.Distance(transform.position,realpos)>0.0f){
			if(Vector3.Angle(transform.forward,target.transform.position-transform.position)<45)
				GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(realpos-transform.position)*speed*0.7f*Time.timeScale);vel=0.0f;}
		else
		{transform.LookAt(ball.transform);GetComponent<Animation>()["idle"].speed=0.01f;}

	}

	void  Cutoff (){ GameObject target;
		if(AI.posession==2 && name=="player8")
		{ target=GameObject.Find("player2opp");}
		else if(AI.posession==2 && name=="player9")
			target=GameObject.Find("playeropp");
		else if(AI.posession==2 && name=="player4")
			target=GameObject.Find("player5opp");
		else if(AI.posession==2 && name=="player5")
			target=GameObject.Find("player4opp");
		else if(AI.posession==2 && name=="player10")
			target=GameObject.Find("player3opp");
		else if(AI.posession==2 && name=="player7")
			target=GameObject.Find("player6opp");
		else 
			target=position.gameObject;

		//RotateTo(target);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.01f)
		{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().CrossFade("jog");
			GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && dribbling==false)GetComponent<Animation>().Play("idle");}

		if(Random.Range(0,50)<=1)
		{ 
			realpos=ball.transform.position+(target.transform.position-ball.transform.position)*0.8f+Vector3.right*(100/positioning) ;
			RotateTo(target); ;}

		if(Vector3.Distance(transform.position,realpos)>0.0f){
			if(Vector3.Angle(transform.forward,target.transform.position-transform.position)<45)
				GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(realpos-transform.position)*speed*0.7f*Time.timeScale);vel=0.0f;}
		else
		{transform.LookAt(ball.transform);GetComponent<Animation>()["idle"].speed=0.01f;}
	}

	void  MoveToChannel (){ GameObject target,target1,target2;
		if(name=="player3")
		{ target1=GameObject.Find("player10opp");  target2=GameObject.Find("player9opp");}
		if(name=="player")
		{ target1=GameObject.Find("player9opp");  target2=GameObject.Find("player8opp");}
		if(name=="player2")
		{ target1=GameObject.Find("player8opp");  target2=GameObject.Find("player7opp");}

		else 
		{
			target1=position.gameObject;target2=position.gameObject; }
		RotateTo(target1);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.001f)
		{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().Play("jog");
			GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && dribbling==false)GetComponent<Animation>().Play("idle");}

		if(Random.Range(0,50)<=1)
		{  if(target2==target1)
			realpos=target1.transform.position;
		else
			realpos=new Vector3(target1.transform.position.x+(target2.transform.position.x-target1.transform.position.x)/2,0.83f,
				position.position.z)  ;}
		if(Vector3.Distance(transform.position,realpos)>0.0f){
			if(Vector3.Angle(transform.forward,target1.transform.position-transform.position)<45)
				GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(realpos-transform.position)*speed*0.7f*Time.timeScale);vel=0.0f;}
		else
		{transform.LookAt(ball.transform);GetComponent<Animation>()["idle"].speed=0.01f;}
	}

	void  HugLine (){
		GameObject line=GameObject.Find("offsideline2");
		RotateTo(position.gameObject);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.01f)
		{if(!GetComponent<Animation>().IsPlaying("jog"))GetComponent<Animation>().CrossFade("jog");
			GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*Random.Range(animspeedmin,animspeedmax);}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && dribbling==false)GetComponent<Animation>().Play("idle");}

		if(Random.Range(0,50)<=1)
		{  
			realpos=new Vector3(position.position.x,position.position.y,line.transform.position.z)-Vector3.forward*Random.Range(0.0f,1.0f)  ;}
		if(Vector3.Distance(transform.position,realpos)>0.0f){
			if(Vector3.Angle(transform.forward,position.position-transform.position)<45)
				GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(realpos-transform.position)*speed*0.7f*Time.timeScale);vel=0.0f;}
		else
		{transform.LookAt(ball.transform);GetComponent<Animation>()["idle"].speed=0.01f;}


	}

	void  DoPass (){
		{var cube=Random.Range(0,1);
			if(global.team1==global.id){
				if(global.playstyle=="normal" && cube==1)
				{passing=true;timeout1=40;}
				else if(global.playstyle=="onetwo" && cube==1)
				{passing=true;timeout1=40;global.p1onetwo=60;global.returnto=gameObject;}
				else if(global.playstyle=="through balls" && cube==1)
				{acting=true;timeout1=40;ThroughPass();}
				else
				{passing=true;timeout1=40;}
			}
			else
			{passing=true;timeout1=40;}}
	}


	void  LateUpdate (){
		var offsideline=GameObject.Find("offsideline");
		if(ball.transform.position.z<offsideline.transform.position.z)
			run=true;
		GetComponent<Animation>()["run"].speed=Mathf.Clamp(GetComponent<Animation>()["run"].speed,0.01f,1.6f);
		GetComponent<Animation>()["run"].speed = GetComponent<Rigidbody>().velocity.magnitude*1.5f;
		GetComponent<Animation>()["run"].speed=Mathf.Clamp(GetComponent<Animation>()["run"].speed,0.01f,1.6f);
		GetComponent<Animation>()["jog"].speed=Mathf.Clamp(GetComponent<Animation>()["jog"].speed,clampmin,clampmax);
		GetComponent<Animation>()["jog"].speed=GetComponent<Rigidbody>().velocity.magnitude*4.0f;
		GetComponent<Animation>()["jog"].speed=Mathf.Clamp(GetComponent<Animation>()["jog"].speed,clampmin,clampmax);



	}

	void  FixedUpdate (){
		var speed=Vector2.Distance(new Vector2(xprev,zprev),new Vector2(transform.position.x,transform.position.z));
		if((GetComponent<Rigidbody>().velocity.magnitude<0.01f && GetComponent<Animation>().IsPlaying("jog")) || (speed==0.0f && GetComponent<Animation>().IsPlaying("jog")) )
			GetComponent<Animation>().Play("idle");
		xprev=transform.position.x;
		zprev=transform.position.z;
	}

	public void  Book (){
		if(gameObject.name=="player")
		{booked=true;global.p1booked=true;}
		if(gameObject.name=="player2")
		{booked=true;global.p2booked=true;}
		if(gameObject.name=="player3")
		{booked=true;global.p3booked=true;}
		if(gameObject.name=="player4")
		{booked=true;global.p4booked=true;}
		if(gameObject.name=="player5")
		{booked=true;global.p5booked=true;}
		if(gameObject.name=="player6")
		{booked=true;global.p6booked=true;}
		if(gameObject.name=="player7")
		{booked=true;global.p7booked=true;}
		if(gameObject.name=="player8")
		{booked=true;global.p8booked=true;}
		if(gameObject.name=="player9")
		{booked=true;global.p9booked=true;}
		if(gameObject.name=="player10")
		{booked=true;global.p10booked=true;}
	}
}
