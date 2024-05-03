using UnityEngine;

public class nationality
	: MonoBehaviour
{
	private Vector2 scrollViewVector = Vector2.zero;
	public GameObject global;
	public Rect dropDownRect = new Rect(80,100,60,100);
	public Rect dropDownRect2 = new Rect(80,100,60,100);
	public static string[] list = {"Albanian","Algerian","Armenian","Azerbaijani","Afghan","Angolan","Argentinian","Austrian",
		"Australian","bahaman","Bahraini","Bangladeshi","Barbadian","Belgian","Belizian","Beninese","Bolivian","Botswanan","Brazilian",
	"Bilgarian","Burundian","Ivorean","Cambodian","Cameroonian","Canadian","Chadian","Chilean","Chinese","Colombian","Congolese",
	"Costa Rican","Croatian","Cuban","Czech","Danish","Dominican","Ecuadorian","Egyptian","Salvadorian","Estonian","Ethiopian",
	"Fijian","Finnish","French","Gabonese","Gambian","Georgian","German","Ghanian","Greek","Guinean","Honduran","Hungarian","Icelandic",
	"Indian","Indonesian","Iranian","Iraqi","Irish","Israeli","Italian","Jamaican","Japanese","Jordanian","Kazakh","Kenyan","Kiribati",
	"Kuwaiti","Laotian","Latvian","Lebanese","Lithuanian","Madagascan","Malawian","Malaysian","Malian","Mauritian","Mexican","Moldovan",
	"Mongolian","Moroccan","Mozambican","Namibian","Dutch","New Zealander","Nicaraguan","Nigerian","Norwegian","Omani","Pakistani",
	"Panamanian","Paraguayan","Peruvian","Filipino","Polish","Portuguese","Qatari","Romanian","Russian","Rwandan","Samoan","Saudi",
	"Senegalese","Serbian","Singaporean","Slovakian","Slovenian","Solomon Islander","South African","South Korean","Spanish",
	"Sri Lankan","Swedish","Swiss","Tanzanian","Thai","Togolese","Trinidad","Tunisian","Turkish","Tuvaluan","Ugandan","Ukrainian","UAE",
	"English","Scottish","Northern Irish","Welsh","American","Uruguayan","Vanuatuan","Venezuelan","Vietnamese","Zambian","Zimbabwean"};
	public GUIStyle currentStyle ;
	int indexNumber;
	bool show = false;
	public int posx=-380;
	public int posy=346;
	
	void OnGUI()
	{   //GUI.backgroundColor = Color.cyan;
		dropDownRect.y=posy;
		//GUI.color = new Color(1,1,1,1.0f);
		GUI.Label(new Rect((dropDownRect.x - posx+10), dropDownRect.y-20, 125, 25), "select nationality");
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
			GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length*25))), "");
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
			GUI.Label(new Rect((dropDownRect.x - posx+20), dropDownRect.y, 200, 25), list[indexNumber]);
		}
		
	}
	void Update(){
		//global.GetComponent(global).managername=list[indexNumber];
	}
} 