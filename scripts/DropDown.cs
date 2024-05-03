using UnityEngine;
using System.Collections;

public class DropDown : MonoBehaviour {

	private Vector2 scrollViewVector = Vector2.zero;
	private string[] countries = {"Any country","Afghanistan", "Albania", "Algeria"};//add the rest
	int n,i,wichcountry;
	int x,y;
	void Start () {
		n=0;i=0;wichcountry=0;
		x=20;
		y=200;
	}
	
	void OnGUI () {

		if(GUI.Button(new Rect(x,y,100,25)," ")){
			if(n==0)n=1;
			else n=0;        
		}
		
		if(n==1){
			scrollViewVector = GUI.BeginScrollView (new Rect (x, y, 100, 115), scrollViewVector, new Rect (0, 0, 300, 500));
			GUI.Box(new Rect(0,0,300,500), ""); 
			for(i=0;i<4;i++){
				if(GUI.Button(new Rect(0,i*25,300,25), "")){
					n=0;wichcountry=i;        
				}              
				GUI.Label(new Rect(5,i*25,300,25), countries[i]);           
			}
			GUI.EndScrollView();        
		}else{
			GUI.Label(new Rect(x,y,300,25), countries[wichcountry]);
		}            
	}
}
