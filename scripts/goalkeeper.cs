using UnityEngine;
using System.Collections;

public class goalkeeper : MonoBehaviour {
	//
	public GameObject ball;
	[HideInInspector]
	public int reflexes=50;
	[HideInInspector]
	public int positioning=50;
	[HideInInspector]
	public int handling=50;
	[HideInInspector]
	public int diving=50;
	[HideInInspector]
	public int agility=50;
	[HideInInspector]
	public int speedy=50;
	public int control=50;
	public Transform spot;
	public Collider hands;
	public GameObject goal;
	public AudioSource strike;
	public AudioSource grab;
	public AudioSource pass;
	public GameObject player1;
	public GameObject player1op;  //to be added
	public GameObject ballshadow;
	public string playername;
	[HideInInspector]
	public int skin;
	//public Transform ballpoint;
	[HideInInspector]
	public string state;
	private bool realpos=false;
	[HideInInspector]
	public bool acting=false;
	private float savetimeout=0.0f;
	private bool inbox=true;
	private float walktimeout=0.0f;
	private bool kicked=false;//to let delayed animation play for kicking ball
	private int actingtimeout=0;  //for animations
	private float speed;
	private bool saved=false;
	private bool jumped=false;
	private int savedown=1000;
	private int kicking=0;
	private int lstime=0;
	[HideInInspector]
	public bool justkicked=false;  private float divespeed=0.0f; private float angle=0.0f;private float t=0.0f;
	[HideInInspector]
	public float timer=0.0f;
	private bool sos=false;
	public GameObject player10;
	public GameObject player9;
	public GameObject player8;
	//AI=GameObject.Find("AI").GetComponent.<AI>();

	void  Start (){
		if(speedy<30)
			speedy=30;
		state="idle";
		speed=(speedy/30*1.0f)*0.13f;
	}

	void  Update (){
		if(GameObject.Find("Canvas").transform.Find("Substitution").gameObject.activeSelf)return;
		if(savetimeout>0.0f && state=="idle")
			state="saving";
		if(lstime>0 && state=="idle")
			state="longsave";

		if(AI.shot>0 && acting==false && state!="saving" && state!="longsave" && Vector3.Distance(ball.transform.position,transform.position)<30)
		{state="saving";Save();acting=true;transform.rotation=Quaternion.LookRotation(Vector3.forward);
			GetComponent<Animation>().Play("save");GetComponent<Animation>()["save"].speed=1.0f;/*angle=transform.eulerAngles.z;*/} //p2
		else if(AI.shot>0 && acting==false && state!="saving" && state!="longsave" && Vector3.Distance(ball.transform.position,transform.position)>=30)// long save
		{var vector=Vector3.Normalize(new Vector3(ball.transform.position.x,0.0f,0));if(state!="longsave")lstime=60;
			GetComponent<Rigidbody>().MovePosition(transform.position-vector*0.1f);state="longsave";LongSave();acting=true;} //sidestep to ball
		//if(state!="saving"){
		if(state=="longsave")
			LongSave();

		if((Vector3.Distance(spot.position,ball.transform.position)>20 && acting==false && sos==false) ||   //ball out of range
			(Vector3.Distance(spot.position,ball.transform.position)<20 && AI.posession==1 && acting==false ) )  //p2 fix
		{state="idle";ReturnToPosition();}
		else
		{if(acting==false && state=="idle" && AI.posession!=5 &&  AI.posession!=6 && justkicked==false) 
			{state="attack";if(/*!animation.IsPlaying("run") && */kicking==0)GetComponent<Animation>().Play("run");/*GoForBall();*/}} //fix
		//  }
		/* if(state=="attack" && AI.shot>0)
    state="saving";*/

		if(state=="attack" &&  AI.posession!=5 &&  AI.posession!=6 && justkicked==false)
		{if(AI.shot>0)  //fix
			{if(Vector3.Distance(ball.transform.position,transform.position)<30)
				{state="saving";GetComponent<Animation>().Play("save");acting=true;transform.rotation=Quaternion.LookRotation(Vector3.forward);}
			else
			{state="longsave";acting=true;transform.rotation=Quaternion.LookRotation(Vector3.forward);}
		}
		else
		{if(justkicked==false)
			GoForBall();}}

		if(Ball.owner!=null){ //attacker passed all defence xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
			if(state=="idle"  && AI.posession==2 && Ball.owner.transform.position.z<player10.transform.position.z && 
				Ball.owner.transform.position.z<player9.transform.position.z && Ball.owner.transform.position.z<player8.transform.position.z &&
				Vector3.Distance(spot.position,ball.transform.position)>20 && ball.transform.position.z<-10 && Vector3.Distance(spot.position,ball.transform.position)<30)
			{state="attack";sos=true;}
			else
			{if(state=="attack")sos=false;}
		}
		else
		{sos=false;}
		if(AI.posession!=2 || transform.position.z>-23)
			sos=false;

		if(ball.transform.position.z>-10 && state=="attack")
		{state="idle";sos=false;}

		if(state=="withball" ){ //bug fixed on running after ball
			if(transform.eulerAngles.z!=0.0f)
				transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0.0f);
			if(transform.eulerAngles.x!=0.0f)
				transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);
		}

		if((AI.posession==7 || AI.posession==6 || AI.posession==5) && (AI.gktimeout<50 || AI.gktimeout>110) ){//foul or goal
			state="paused";if(state!="saving" && state!="busy")GetComponent<Animation>().Play("idle");}
		else{
			if(AI.posession<4 && state=="paused") //return to normal
				state="idle";}

		if(state=="withball"){
			walktimeout+=Time.deltaTime;
			Walk();}
		if(state=="saving")
		if(transform.position.y<0.83f)
			transform.position=new Vector3(transform.position.x,0.83f,transform.position.z);
		if(state!="saving"){
			if(transform.eulerAngles.x!=0.0f)
				transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);}

		if(state=="saving")
		{Save();/*save function wasnt called here unless it was also in upper statement*/;}

		if(actingtimeout>0)
			actingtimeout-=1;
		if(actingtimeout==1)  //long awaited bug
			acting=false;
		if(kicking>0)
			kicking-=1;
		//Debug.Log("acting "+acting+" state "+state);
		if(state=="idle" && acting==false && 
			ball.transform.position.y>transform.position.y+2.2f && Vector3.Distance(transform.position,ball.transform.position)<1
			&& transform.position.y<0.93f)
		{hands.enabled=true;GetComponent<Rigidbody>().AddForce(transform.up*4,ForceMode.Impulse);}
		else
		{if(state!="saving" && state!="longsave" && Vector3.Distance(ball.transform.position,transform.position)>5)
			hands.enabled=false;}

		if(GetComponent<Animation>().IsPlaying("run"))
			GetComponent<Animation>()["run"].speed=Mathf.Clamp(GetComponent<Animation>()["run"].speed,0.5f,2.5f);
		if(GetComponent<Animation>().IsPlaying("jog"))
			GetComponent<Animation>()["jog"].speed=Mathf.Clamp(GetComponent<Animation>()["jog"].speed,0.5f,2.5f);

		if(Mathf.Abs(BallPoint.saveangle)<45.0f && ball.transform.position.y>transform.position.y+2.4f && Vector3.Distance(ball.transform.position,transform.position)<2
			&& state=="saving")
			hands.enabled=true;
		else
		{if(Vector3.Distance(ball.transform.position,transform.position)>5 && state!="longsave" && state!="saving" && state!="attack")
			hands.enabled=false;}
		if(transform.position.y>2.2f)transform.position=new Vector3(transform.position.x,2.2f,transform.position.z);

		if(timer>0.0f)
			timer+=1.0f*Time.timeScale;
		if(timer>=60.0f*Time.timeScale)
		{timer=0.0f;justkicked=false;GetComponent<Rigidbody>().isKinematic=false;}
		if(state=="attack" && ball.transform.position.y>transform.position.y+2.0f && Vector3.Distance(ball.transform.position,transform.position)<5)
			hands.enabled=true;
		StayUpright();
	}// updatexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	void  StayUpright (){
		if(state!="saving" && (AI.posession==5 || AI.penalties==false) && state!="longsave"){  //long bug fix
			if(transform.eulerAngles.z!=0.0f)
				transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
			if(transform.eulerAngles.x!=0.0f)
				transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,transform.eulerAngles.z);;
		}
	}

	void  ReturnToPosition (){ if(AI.penalties)return;
		var num=90.0f/(positioning*1.0f);  
		float min=Mathf.Pow(num,2f); float max=Mathf.Pow(num,2f);
		var posx=Random.Range(-min,max);
		num=50.0f/(positioning*1.0f);
		min=Mathf.Pow(num,2f);max=Mathf.Pow(num,2f);//negation error forgot to normalize
		var posz=Random.Range(-min,max);
		var pos=new Vector3(spot.position.x+posx,0.76f,spot.position.z+posz);
		var dir=Vector3.Normalize(pos-transform.position); var dis=Vector3.Normalize(spot.position-transform.position);
		//if( Vector3.Angle(transform.forward,spot.transform.position-transform.position)<60) {
		if(Vector3.Distance(transform.position,spot.position)>5)
			RotateTo(spot.gameObject);
		else
			RotateTo(ballshadow);
		if(Random.Range(0,50)<=1) {
			if(realpos==false)
				realpos=true;
			else
				realpos=false;}
		if(realpos)
			GetComponent<Rigidbody>().MovePosition(transform.position+dir*(speed*3/4)*Time.timeScale);
		else
			GetComponent<Rigidbody>().MovePosition(transform.position+dis*(speed*3/4)*Time.timeScale); //straight to spot
		//else
		//rigidbody.MovePosition(transform.position+transform.forward*speed*3/4*Time.timeScale);
		if(state=="saving")return; 
		if(Vector3.Distance(transform.position,spot.transform.position)>0.5f){
			if(GetComponent<Rigidbody>().velocity.magnitude>0.01f) //fix
			{if(!GetComponent<Animation>().IsPlaying("jog") && kicking==0)
				GetComponent<Animation>().Play("jog");
				GetComponent<Animation>()["jog"].speed = GetComponent<Rigidbody>().velocity.magnitude*20.5f;}
			else
			{if(!GetComponent<Animation>().IsPlaying("idle"))
				GetComponent<Animation>().Play("idle");
				GetComponent<Animation>()["idle"].speed = 0.1f;}  
		}
		else
		{if(GetComponent<Rigidbody>().velocity.magnitude<0.01f) //long running bug fix
			GetComponent<Animation>().Play("idle");}
	}

	void  RotateTo ( GameObject target  ){
		var dir= target.transform.position - transform.position;
		var singleStep= agility * Time.deltaTime;
		var Direction= Vector3.RotateTowards(transform.forward, dir, singleStep, 0.0f);
		transform.rotation = Quaternion.LookRotation(Direction);
	}

	void  GoForBall (){  if(AI.penalties)return;//rigidbody.isKinematic=true;
		RotateTo(ball);//adjustment player doesnt run with a translated target
		if(Vector3.Distance(ball.transform.position,spot.transform.position)<7)
		{var ballpos= new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z);
			GetComponent<Rigidbody>().MovePosition(transform.position+(ballpos-transform.position)*speed*1.1f*Time.timeScale);}
		else
			GetComponent<Rigidbody>().MovePosition(transform.position+transform.forward*speed*Time.timeScale);
		if(GetComponent<Rigidbody>().velocity.magnitude>0.005f)
		{if(!GetComponent<Animation>().IsPlaying("run") && kicking==0)
			GetComponent<Animation>().Play("run");}
		else
		{if(!GetComponent<Animation>().IsPlaying("idle") && kicking==0)
			GetComponent<Animation>().Play("idle");}
		GetComponent<Animation>()["run"].speed = GetComponent<Rigidbody>().velocity.magnitude*2.0f;
		GetComponent<Animation>()["idle"].speed = 0.1f;
	}
	//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	void  OnCollisionEnter ( Collision other  ){ 
		if(other.gameObject.name=="ball" && ball.GetComponent<Rigidbody>().velocity.magnitude>20)strike.Play();
		if(other.gameObject.name=="ball")AI.SHOOT=false;
		if( AI.posession==5 ||  AI.posession==6 || AI.posession==7 || state=="withball" || AI.posession==4)return;
		if(other.gameObject.name=="ball")AI.cameoff="p1";  
		if(other.gameObject.name=="ball" && kicked==true)
			return;
		if(other.gameObject.name=="ball" && state=="saving" && saved==false)
		{saved=true; var deflect= Random.Range((handling/6.6f)-5.0f,handling/6.6f);
			if(Random.Range(0,3)<=1)ball.GetComponent<Rigidbody>().AddForce(Vector3.right*deflect);
			else
				ball.GetComponent<Rigidbody>().AddForce(-Vector3.right*deflect);
			if(Random.Range(0.0f,100.0f/handling)<=0.5f)
				ball.GetComponent<Rigidbody>().AddForce(Vector3.forward*deflect);
		}
		if(other.gameObject.name=="ball" && state=="attack" && AI.shot<=0 && global.penalties==false){ //p2 make sure grab from opponent
			if(inbox==true && ball.GetComponent<Rigidbody>().velocity.magnitude<300/control)
				Grab();
			else
			{if(ball.GetComponent<Rigidbody>().velocity.magnitude<300/control)
				{acting=true;Kick();actingtimeout=220;}}
		}
		if(AI.shot>0 && other.gameObject.name=="ball"){ //bullet bug fix
			if(ball.GetComponent<Rigidbody>().velocity.magnitude>1.0f)
			{strike.Play();acting=true;actingtimeout=120;}
			else
				pass.Play();
			if(Random.Range(0.0f,1.0f/ball.GetComponent<Rigidbody>().velocity.magnitude)<handling/100)
				Grab();
		}
		if(other.gameObject.name=="ball" && state=="longsave" && ball.GetComponent<Rigidbody>().velocity.magnitude<3000/handling)
		{ball.GetComponent<Rigidbody>().velocity=Vector3.zero;strike.Play();}
		else if(other.gameObject.name=="ball" && state=="longsave" && ball.GetComponent<Rigidbody>().velocity.magnitude>3000/handling)
		{ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(4,10),ForceMode.Impulse);strike.Play();}
		if(other.gameObject.name=="ball" && state=="longsave" && ball.GetComponent<Rigidbody>().velocity.magnitude<2000/handling)
		{lstime=1;acting=false;}
	}//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

	void  OnCollisionStay ( Collision other  ){ if(other.gameObject.name=="ball")AI.SHOOT=false;
		if( AI.posession==5 ||  AI.posession==6 || global.penalties==true || AI.posession==4)return;

		if(other.gameObject.name=="ball" && kicked==true)
			return;

		if(other.gameObject.name=="ball" && state=="attack" && AI.shot<=0 && global.penalties==false){ //p2 make sure grab from opponent
			if(inbox==true && ball.GetComponent<Rigidbody>().velocity.magnitude<300/control)
				Grab();

		}
		if(AI.shot>0 && other.gameObject.name=="ball"){ //bullet bug fix

			if(Random.Range(0.0f,1.0f/ball.GetComponent<Rigidbody>().velocity.magnitude)<handling/100)
				Grab();
		}
	}//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.name=="box")
			inbox=true;
	}

	void  OnTriggerStay ( Collider other  ){if(acting==false){
			if(other.gameObject.name=="box")
				inbox=true;
		} 
	}

	void  OnTriggerExit ( Collider other   ){
		if(other.gameObject.name=="box")
			inbox=false;
	}

	void  Grab (){  if(global.penalties)return;
		if( AI.posessor.tag!="Player" || Ball.state=="free"){  //p2  don't grab from fellow teammate
			if(AI.posessor!=null && Ball.state!="free"){
				if(AI.posessor.GetComponent<player2>().dribbling){
					if(Random.Range(0.0f,AI.posessor.GetComponent<player2>().dribble/10.0f)<=1){
						if(Ball.state=="posessed")
							grab.Play();
						Ball.state="posessed";  Ball.owner=gameObject;
						AI.posessor=gameObject;
						//if(!animation.IsPlaying("keeperwalk"))   fix
						GetComponent<Animation>().Play("keeperwalk");
						GetComponent<Animation>()["keeperwalk"].speed=0.0f;
						state="withball"; acting=true;
						ball.GetComponent<Rigidbody>().isKinematic=true;
						AI.posession=3;  //0=free ball 1= player 1 has it 2=player2 has it 3= keeper has it 4= throw in 5= corner/goalkick 5=goal 7=foul
						AllBack();
					}
				}
				else
				{if(Ball.state=="posessed")
					grab.Play();
					Ball.state="posessed";  Ball.owner=gameObject;
					AI.posessor=gameObject;
					//if(!animation.IsPlaying("keeperwalk"))   fix
					GetComponent<Animation>().Play("keeperwalk");
					GetComponent<Animation>()["keeperwalk"].speed=0.0f;
					state="withball"; acting=true;
					ball.GetComponent<Rigidbody>().isKinematic=true;
					AI.posession=3;  //0=free ball 1= player 1 has it 2=player2 has it 3= keeper has it 4= throw in 5= corner/goalkick 5=goal 7=foul
					AllBack();}
			}
			else
			{if(Ball.state=="posessed")
				grab.Play();
				Ball.state="posessed";  Ball.owner=gameObject;
				AI.posessor=gameObject;
				//if(!animation.IsPlaying("keeperwalk"))   fix
				GetComponent<Animation>().Play("keeperwalk");
				GetComponent<Animation>()["keeperwalk"].speed=0.0f;
				state="withball"; acting=true;
				ball.GetComponent<Rigidbody>().isKinematic=true;
				AI.posession=3;  //0=free ball 1= player 1 has it 2=player2 has it 3= keeper has it 4= throw in 5= corner/goalkick 5=goal 7=foul
				AllBack();}
		}
	}                // 8= offside 9=halt/timeup

	void  Kick (){  //clear ball even if in posession
		//if(!animation.IsPlaying("kick"))
		GetComponent<Animation>().Play("kick");GetComponent<Animation>()["kick"].speed=2.0f;
		ball.GetComponent<Rigidbody>().isKinematic=false; Ball.state="free";Ball.owner=null;
		AI.posession=0; kicking=70;
		strike.Play();  //soccerball kick
		ball.GetComponent<Rigidbody>().AddForce((Vector3.forward+Vector3.up*0.9f)*Random.Range(16.0f,29.0f),ForceMode.Impulse);  //p2
	}

	void  Throw (){   //adjust later to throw to player
		if(!GetComponent<Animation>().IsPlaying("throw"))
			GetComponent<Animation>().Play("throw");
		ball.GetComponent<Rigidbody>().isKinematic=false; Ball.state="free";Ball.owner=null;
		AI.posession=0;
		ball.GetComponent<Rigidbody>().AddForce((Vector3.forward+Vector3.up*0.6f)*Random.Range(12.0f,18.0f),ForceMode.Impulse);  //p2
	}
	//ppppppppppppppppppppppppppppppppppppppppp
	//ppppppppppppppppppppppppppppppppppppppppp
	void  Walk (){
		if(walktimeout<=2.0f && kicked==false){
			GetComponent<Animation>()["keeperwalk"].speed=0.0f;
		}
		if(walktimeout>2.0f && walktimeout<5.0f){  //bug fix
			GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.forward*speed*0.3f*Time.timeScale); //p2
			RotateTo(goal);
			if(!GetComponent<Animation>().IsPlaying("keeperwalk"))//fix
				GetComponent<Animation>().Play("keeperwalk");  //bug fix
			GetComponent<Animation>()["keeperwalk"].speed = GetComponent<Rigidbody>().velocity.magnitude*5.0f;
		}
		if(walktimeout>=5.0f && kicked==false){
			if(Random.Range(0,5)<=1)//adjust to tactics
				Kick();
			else
				Throw(); kicked=true; justkicked=true;
		}
		if(walktimeout>=5.0f  && walktimeout<5.1f)
		{ball.GetComponent<Rigidbody>().isKinematic=false;AI.posession=0;Ball.state="free";Ball.owner=null;}
		if(walktimeout>=5.5f  && savetimeout==0.0f)
		{state="idle";kicked=false;acting=false;GetComponent<Rigidbody>().isKinematic=false;timer+=1*Time.timeScale;}
		if(walktimeout>0.0f && walktimeout<5.0f)  //holding ball in arms
			ball.transform.position=transform.position+transform.forward*0.8f+Vector3.up*1.9f;  //p2

	}
	//oooooooooooooooooooooooooooooooooooooooooo
	void  Save (){ if(justkicked)return;
		/*if(!animation.IsPlaying("save"))  //bug fix
  animation.Play("save");GetComponent.<Animation>()["save"].speed=1.0f;*/
		savetimeout+=Time.deltaTime; float timeline=20/reflexes;
		if(savetimeout>=timeline && savetimeout<diving/50.0f && saved==false)//reaction to start saving
		{ //animation.Play("save");   
			transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, Mathf.Lerp(angle,BallPoint.saveangle,t));
			// transform.eulerAngles.z=BallPoint.saveangle;               
			t+=reflexes/30*Time.deltaTime;
			Mathf.Clamp(divespeed,0.0f,1.0f);
			 divespeed=BallPoint.D;
			Mathf.Clamp(divespeed,0.0f,1.0f);
			//transform.eulerAngles.z=-BallPoint.saveangle;
			hands.enabled=true;  savedown+=1;
			if(Ball.yvel>0.2f && Mathf.Abs(BallPoint.saveangle)<30.0f)
				GetComponent<Rigidbody>().MovePosition(transform.position+transform.up*diving/savedown);
			else
				GetComponent<Rigidbody>().MovePosition(transform.position+transform.up*divespeed*diving/5000); }
		//transform.rotation = Quaternion.LookRotation(BallPoint.savevector,Vector3.forward);  //p2
		if(savetimeout>=timeline && savetimeout<=10.0f/reflexes+0.5f && jumped==false)//jump
		{GetComponent<Rigidbody>().AddForce(transform.up*diving*0.1f,ForceMode.Impulse);
			jumped=true;}
		if(savetimeout>timeline && savetimeout<10/reflexes+0.5f && Vector3.Distance(ball.transform.position,spot.transform.position)<5){
			var ballx=ball.transform.position.x;var bally=ball.transform.position.y;
			//rigidbody.MovePosition(transform.position+Vector3.Normalize(Vector3(ballx,bally,transform.position.z))*diving/500);
			///*if(ball.transform.position.x>spot.position.x)   //side hop
			//  //shift towards ball trajectory

			//rigidbody.MovePosition(transform.position-Vector3.right*diving/1000); */ //p2
		}

		float end=90.0f/(agility*1.0f); 
		if(savetimeout>=end)//another float fix
		{state="idle";acting=false;hands.enabled=false;saved=false;savetimeout=0.0f;jumped=false;savedown=1000;t=0.0f;}
	}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////////////////
	void  AllBack (){
		player1.GetComponent<player>().state="idle";
		player1op.GetComponent<player2>().state="idle";
	}

	void  LongSave (){ if(justkicked)return;
		if(lstime>0)lstime--;
		var it=new Vector3(ball.transform.position.x,0.83f,transform.position.z);
		if(Ball.xtrajectory!=null)
			GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(new Vector3(Ball.xtrajectory-transform.position.x,0,0))*speed/2000 );
		//rigidbody.MovePosition(transform.position+vector*0.2f);
		if(lstime==1)
		{state="idle";hands.enabled=false;acting=false; }
		if(lstime==59)
			hands.enabled=true;
		if( Vector3.Distance(ball.transform.position,transform.position)<10 )
		{
			transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, BallPoint.saveangle);               

			if(!GetComponent<Animation>().IsPlaying("save"))
				GetComponent<Animation>().Play("save");}
		var ballpos= new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z);
		if( Vector3.Distance(ball.transform.position,transform.position)<5)
			GetComponent<Rigidbody>().MovePosition(transform.position+Vector3.Normalize(ballpos-transform.position)*speed*0.25f*Time.timeScale);
	}












}
