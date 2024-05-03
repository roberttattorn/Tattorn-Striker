using UnityEngine;

public class Formation
	: MonoBehaviour
{
	private Vector2 scrollViewVector = Vector2.zero;
	public Rect dropDownRect = new Rect(80,100,60,100);
	public Rect dropDownRect2 = new Rect(80,100,60,100);
	public static string[] list = {"Normal","Attacking","Defensive"};
	public GUIStyle currentStyle ;
	int indexNumber;
	bool show = false;
	public int posx=122;
	public int posy=100;

	void OnGUI()
	{   //GUI.backgroundColor = Color.cyan;
		dropDownRect.y=posy;
		//GUI.color = new Color(1,1,1,1.0f);
		GUI.Label(new Rect((dropDownRect.x - posx+30), dropDownRect.y-20, 125, 25), "Mentality");
		GUI.Box (new Rect((dropDownRect.x - posx), dropDownRect.y, 125, 25),"",currentStyle);
		if(GUI.Button(new Rect((dropDownRect.x - posx), dropDownRect.y, 125, 25), ""))
		{
			if(!show)
			{
				show = true;
			}
			else
			{
				show = false;
			}
		}
		
		if(show)
		{
			scrollViewVector = GUI.BeginScrollView(new Rect((dropDownRect.x - posx), (dropDownRect.y + 25), 125, dropDownRect.height),scrollViewVector,new Rect(0, 0, 125, Mathf.Max(dropDownRect.height, (list.Length*25))));
			
			GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length*25))), "");
			GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length*25))), "",currentStyle);
			for(int index = 0; index < list.Length; index++)
			{
				
				if(GUI.Button(new Rect(0, (index*25), dropDownRect.height, 25), ""))
				{
					show = false;
					indexNumber = index;
				}
				
				GUI.Label(new Rect(5, (index*25), dropDownRect.height, 25), list[index]);
				
			}
			
			GUI.EndScrollView();   
		}
		else
		{
			GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y, 200, 25), list[indexNumber]);
		}
		
	}
	void Update(){
		//Debug.Log(indexNumber);
	}
} 