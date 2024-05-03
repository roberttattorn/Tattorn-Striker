/*using UnityEngine;
using System.Collections;

public class position2 : MonoBehaviour {
	public Transform ball;
	[HideInInspector]
	float posz;
	[HideInInspector]
	float posx;
	float fixedposz;
	float fixedposx;
	public bool  iswing; 
	private int timeout=0;
	private Transform line;

	void  Start (){
		posz=transform.position.z;
		fixedposx=transform.position.x;
		line=GameObject.Find("offsideline2").transform;
	}

	void  Update (){
		if(timeout==1){
			posz=transform.position.z;fixedposz=transform.position.z;
			posx=transform.position.x;fixedposx=transform.position.x;
			if(global.category=="clubs")  //unset wing status if formation is other
			{if(Control.clubformation[global.team2]!=442)
				iswing=false;}
			else  
			{if(Control.formation[global.team2]!=442)
				iswing=false;}
		}
		////////////////////////////////////////////
		if(timeout==2){
			if(ball.position.z>32 )  //ball in own half
			{if(global.t2mentality=="attacking")
				{transform.position.z=posz+6.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="normal")
				{transform.position.z=posz+11.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz+16.0f;fixedposz=transform.position.z;}
			}
			if(ball.position.z>16 && ball.position.z<32)  //ball in defence
			{if(global.t2mentality=="attacking")
				{transform.position.z=posz;fixedposz=transform.position.z;}
				if(global.t2mentality=="normal")
				{transform.position.z=posz+6.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz+12.0f;fixedposz=transform.position.z;}
			}

			if(ball.position.z>0 && ball.position.z<16) //defensive midfield
			{if(global.t2mentality=="attacking")
				{transform.position.z=posz-6.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="normal")
				{transform.position.z=posz+2.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz+8.0f;fixedposz=transform.position.z;}
			}

			if(ball.position.z>-24 && ball.position.z<0){ //attacking midfield
				if(global.t2mentality=="attacking")
				{transform.position.z=posz-24.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="normal")
				{transform.position.z=posz-16.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz-8.0f;fixedposz=transform.position.z;} }

			if(ball.position.z<-24 ){       //attack
				if(global.t2mentality=="attacking"){
					if(iswing)
					{transform.position.z=posz-60.0f;fixedposz=transform.position.z;}
					else
					{transform.position.z=posz-45.0f;fixedposz=transform.position.z;}}
				if(global.t2mentality=="normal")
				{transform.position.z=posz-34.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz-24.0f;fixedposz=transform.position.z;}
			}
			if(ball.position.z>line.position.z){
				if(global.t2mentality=="attacking")
				{transform.position.z=posz+6.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="normal")
				{transform.position.z=posz+11.0f;fixedposz=transform.position.z;}
				if(global.t2mentality=="defensive")
				{transform.position.z=posz+16.0f;fixedposz=transform.position.z;}
			}

			if(AI.posession==3 && ball.position.z>0)
			{transform.position.z=posz-16;fixedposz=transform.position.z;}

		}//t.o
		if(timeout<2)
			timeout++;
	}

	public void  SetWidth (){
		if(global.team2==global.id){
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