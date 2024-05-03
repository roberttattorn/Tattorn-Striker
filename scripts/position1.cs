/*using UnityEngine;
using System.Collections;

public class position1 : MonoBehaviour {
	public Transform ball;
	[HideInInspector]
	float posz; //fixed starting position, changes when changing formation
	[HideInInspector]
	float posx; 
	float fixedposz;  //temporary new fixed pos for player to deviate positioning from
	float fixedposx;
	public bool  iswing; 
	private int timeout=0;
	private Transform line;

	void  Start (){
		posz=transform.position.z;
		fixedposx=transform.position.x;
		line=GameObject.Find("offsideline").transform;
	}

	void  Update (){
		if(timeout==1){
			posz=transform.position.z;fixedposz=transform.position.z;
			posx=transform.position.x;fixedposx=transform.position.x;
			if(global.category=="clubs")  //unset wing status if formation is other
			{if(Control.clubformation[global.team1]!=442)
				iswing=false;}
			else  
			{if(Control.formation[global.team1]!=442)
				iswing=false;}
		}
		////////////////////////////////////////////
		if(timeout==2){  //attacking
			if(ball.position.z>0 && ball.position.z<26){  //ball in midfield
				if(global.t1mentality=="attacking")
				{transform.position.z=posz+26;fixedposz=ball.position.z+26;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz+20;fixedposz=ball.position.z+20;}
				if(global.t1mentality=="defensive")
				{transform.position.z=posz+12;fixedposz=ball.position.z+12;}   
			}
			if(ball.position.z>26){   //ball in attack
				if(global.t1mentality=="attacking")
				{if(iswing)
					transform.position.z=posz+60;
				else
					transform.position.z=posz+46;fixedposz=transform.position.z;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz+34;fixedposz=transform.position.z;}
				if(global.t1mentality=="defensive")
				{transform.position.z=posz+20;fixedposz=transform.position.z;}
			}

			if(ball.position.z>-16 && ball.position.z<0)      //ball in defence midfield
			{if(global.t1mentality=="attacking")
				{transform.position.z=posz+6;fixedposz=posz+6;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz;fixedposz=posz;}
				if(global.t1mentality=="defensive")
				{transform.position.z=posz-6;fixedposz=posz-6;}
			}
			if(ball.position.z<-16 && ball.position.z>-32)
			{if(global.t1mentality=="attacking")
				{transform.position.z=posz;fixedposz=posz;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz-6;fixedposz=posz-6;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz-12;fixedposz=posz-12;}
			}

			if(ball.position.z<-32 )              //ball in own box
			{if(global.t1mentality=="attacking")
				{transform.position.z=posz-4;fixedposz=posz-4;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz-10;fixedposz=posz-10;}
				if(global.t1mentality=="defensive")
				{transform.position.z=posz-16;fixedposz=posz-16;}
			}
			if(ball.position.z<line.position.z){
				if(global.t1mentality=="attacking")
				{transform.position.z=posz-4;fixedposz=posz-4;}
				if(global.t1mentality=="normal")
				{transform.position.z=posz-10;fixedposz=posz-10;}
				if(global.t1mentality=="defensive")
				{transform.position.z=posz-16;fixedposz=posz-16;}
			}

			if(AI.posession==3 && ball.position.z<0) //reset of ball in own kepper hands
			{transform.position.z=posz+16;fixedposz=2;}
			// add positions for defensive and attacking mentality

		}//to
		if(timeout<2)
			timeout++;
	}

	public void  SetWidth (){   //set after setting formation
		if(global.team1==global.id){
			if(global.width==2) //normal
			{transform.position.x=posx;fixedposx=transform.position.x;}
			if(global.width==1){ //narrow
				if(transform.position.x<0)
					transform.position.x=posx*0.78f;
				else
					transform.position.x=posx*0.78f;fixedposx=transform.position.x;}
			if(global.width==0){ //very narrow
				if(transform.position.x<0)
					transform.position.x=posx*0.63f;
				else
					transform.position.x=posx*0.63f;fixedposx=transform.position.x;}
			if(global.width==3){ //wide
				if(transform.position.x<0)
					transform.position.x=posx*1.26f;
				else
					transform.position.x=posx*1.26f;fixedposx=transform.position.x;}
			if(global.width==4){ //very wide
				if(transform.position.x<0)
					transform.position.x=posx*2;
				else
					transform.position.x=posx*2;fixedposx=transform.position.x;}
		}
	}

	public void  ResetPos (){
		posz=transform.position.z;fixedposz=transform.position.z;
		posx=transform.position.x;fixedposx=transform.position.x;
	}
}
*/