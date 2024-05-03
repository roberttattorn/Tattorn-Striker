using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class AI : MonoBehaviour {
	public static int posession;  //0=free ball 1= player 1 has it 2=player2 has it 3= keeper has it 4= throw in 5= corner/goalkick 6=goal 7=foul
	public static GameObject posessor;               // 8= free kick 9=penalty 10=corner 11=goal kick
	public static GameObject lastposessor;
	public static string cameoff;  //p1 p2
	public static int shot=0;
	public static string test="test";
	public static string state="pause";
	public static bool book=false; //to book a player
	public static float pausetimeout=0.0f;
	public static GameObject culprit;
	public static GameObject victim;
	public static GameObject nearest1;
	public static GameObject nearest2;
	private GameObject offsideline;
	private GameObject offsideline2;
	private int cornertimeout=0;
	public GameObject ball;
	public GameObject keeper;
	public GameObject keeper2;
	public GameObject player1;
	public GameObject player22;
	public GameObject player3;
	public GameObject player4;
	public GameObject player5;
	public GameObject player6;
	public GameObject player7;
	public GameObject player8;
	public GameObject player9;
	public GameObject player10;
	public GameObject player1opp;
	public GameObject player2opp;
	public GameObject player3opp;
	public GameObject player4opp;
	public GameObject player5opp;
	public GameObject player6opp;
	public GameObject player7opp;
	public GameObject player8opp;
	public GameObject player9opp;
	public GameObject player10opp;
	public static bool SHOOT=false;
	private float shoottimeout=0.0f;
	public static int whostarts=0;
	private int starttimeout=0;
	private int throwintimeout=0;
	public static bool throwingin=false;
	public static float throwinx;
	public static float throwinz;
	public static float freekickx;
	public static float freekickz;
	public AudioSource crowd;
	public static int outcome=0; //1=goalkick 2=corner
	public static int gktimeout=0;
	public GameObject spot;
	public GameObject spotopp;
	public AudioSource kick;
	public Transform corner;
	public Transform corneropp;
	private GameObject cornertaker;
	private GameObject cornertaker2;
	private GameObject penaltytaker;
	private GameObject penaltytaker2;
	private GameObject freekicktaker;
	private GameObject freekicktaker2;
	public static bool CORNER=false;
	private float timeout=0.0f;
	public GameObject kpos;
	public GameObject kposopp;
	public static GameObject furthest;
	public static GameObject furthest2;
	//public static FIXME_VAR_TYPE offside1=false;
	public static float timespeed=1.0f;
	public static bool potentialoffside1=false;  //for if player with ball is on an onside position otherwise it;s not flagged as offside
	public static bool potentialoffside2=false;
	public static bool offside=false;
	public static int minutes=0;
	public static int seconds=0;
	private float time;
	public GameObject clock;
	public GameObject p1score;
	public GameObject p2score;
	public AudioSource whistle;
	public static int p1goals;
	public static int p2goals;
	public Transform gizmo;
	private bool error=false;
	public GameObject gizmotext;
	public GameObject halftimetalk;
	public GameObject preteamtalk;
	public GameObject halftimeprompt;
	public GameObject finalwhistle;
	public GameObject offsideprompt;
	public GameObject bookedprompt;
	public GameObject sentoffprompt;
	private int menutimeout=0;
	public GameObject ET;
	public GameObject team1name;
	public GameObject team2name;
	public GameObject namepad1;
	public GameObject namepad2;
	public GameObject flag1;
	public GameObject flag2;
	public GameObject aggregate1;
	public GameObject aggregate2;
	private Vector3 op1pos;private Vector3 op2pos;private Vector3 op3pos;private Vector3 op4pos;private Vector3 op5pos;
	private Vector3 op6pos;private Vector3 op7pos;private Vector3 op8pos;private Vector3 op9pos;private Vector3 op10pos;
	private Vector3 op1oppos;private Vector3 op2oppos;private Vector3 op3oppos;private Vector3 op4oppos;private Vector3 op5oppos;
	private Vector3 op6oppos;private Vector3 op7oppos;private Vector3 op8oppos;private Vector3 op9oppos;private Vector3 op10oppos;
	public Material kitcro; 
	public Material kitbar;
	public Material kitarg;
	public Material kitnew;
	public Material kitast;
	public Material kitars;
	public Material kitsot;
	public Material kitint;
	public Material kitacm;
	public Material kitdep;
	public Material kittun;
	public Material kitval;
	public Material kitbrw;
	public Material kitblk;
	public Material kitgen;///////
	public Material daylight;
	public Material night;
	public GameObject MentalityDropDown;
	public GameObject FormationDropDown;
	public GameObject WidthDropDown;
	public GameObject TackleDropDown;
	public GameObject Substitution;
	/////////////////////////////
	public GameObject Penaltyscore;
	public static bool penalties=false;
	private bool extratime=false;
	public static int penaltyturn=1;  //whose turn is it in taking penalty
	public static int penaltyScore1=0;
	public static int penaltyScore2=0;
	private float penaltytimer=0.0f;
	private int penaltytimeout=0;
	private GameObject taker1;
	private GameObject taker2;
	public static int penaltyrotation=1;
	public static int[] penaltyscoregrid1=new int[6];
	public static int[] penaltyscoregrid2=new int[6];
	public static int suddendeath1=-1;
	public static int suddendeath2=-1;
	public static bool suddendeath=false;
	public static bool scored=false;  private bool preparingpenalties=false;
	private int postimeout=0;  //timeout not to load 442 formations at beginning
	////////////////////////
	public Transform p1pos;public Transform p2pos;public Transform p3pos;public Transform p4pos;public Transform p5pos;
	public Transform p6pos;public Transform p7pos;public Transform p8pos;public Transform p9pos;public Transform p10pos;
	public Transform p1posop;public Transform p2posop;public Transform p3posop;public Transform p4posop;public Transform p5posop;
	public Transform p6posop;public Transform p7posop;public Transform p8posop;public Transform p9posop;public Transform p10posop;
	public GameObject EndTeamTalk; public AudioSource cheer;

	class players{
		public int id;
		public string playername;
		//int Age;
		public int skin;
		public int acceleration;
		public int aggression;
		public int agility;
		public int balance;
		public int ballcontrol;
		public int composure;
		public int crossing;
		public int curve;
		public int dribbling;
		public int finishing;
		public int freekicks;
		public int diving;
		public int handling;
		public int kicking;
		public int reflexes;
		public int heading;
		public int interceptions;
		public int jumping;
		public int longshots;
		public int marking;
		public int penalties;
		public int positioning;
		public int reactions;
		public int passing;
		public int hotshot;
		public int tackle;
		public int speed;
		public int stamina;
		public int standingtackle;
		public int strength;
		public int determination;
		public string role;

	}
	players[] Player=new players[24];
	players[] Player2=new players[24];
	Control control = GameObject.Find("Control").GetComponent<Control>();
	//public static FIXME_VAR_TYPE footballer=new Players[24];
	//FIXME_VAR_TYPE footballer2=new Players[24];

	void  Start (){ //DontDestroyOnLoad(this.gameObject);
		penaltyscoregrid1[1]=-1;penaltyscoregrid1[2]=-1;penaltyscoregrid1[3]=-1;penaltyscoregrid1[4]=-1;
		penaltyscoregrid1[5]=-1;
		penaltyscoregrid2[1]=-1;penaltyscoregrid2[2]=-1;penaltyscoregrid2[3]=-1;penaltyscoregrid2[4]=-1;
		penaltyscoregrid2[5]=-1;
		if(Application.loadedLevelName=="match")
		{minutes=global.minutes;seconds=global.seconds;p1goals=global.p1goals;p2goals=global.p2goals;
			if(global.category=="clubs"){
				team1name.GetComponent<Text>().color=Control.clubtextcolour[global.team1];
				team2name.GetComponent<Text>().color=Control.clubtextcolour[global.team2];
				team1name.GetComponent<Text>().text=Control.clubname[global.team1];
				team2name.GetComponent<Text>().text=Control.clubname[global.team2];
				namepad1.GetComponent<Image>().color=Control.clubmaincolour[global.team1];
				namepad2.GetComponent<Image>().color=Control.clubmaincolour[global.team2];
				string FilePath= Application.dataPath+"/logos/"+Control.clubicon[global.team1]+".png";
				string FilePath2= Application.dataPath+"/logos/"+Control.clubicon[global.team2]+".png";
				flag1.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
				flag2.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath2,100.0f);
				if(global.isaggregate){
					aggregate1.SetActive(true);aggregate2.SetActive(true);
					aggregate1.GetComponent<Text>().text=global.team1aggregate.ToString();
					aggregate2.GetComponent<Text>().text=global.team2aggregate.ToString();} 
			}
			else{
				team1name.GetComponent<Text>().color=Control.textcolour[global.team1];
				team2name.GetComponent<Text>().color=Control.textcolour[global.team2];
				team1name.GetComponent<Text>().text=Control.countryname[global.team1];
				team2name.GetComponent<Text>().text=Control.countryname[global.team2];
				namepad1.GetComponent<Image>().color=Control.maincolour[global.team1];
				namepad2.GetComponent<Image>().color=Control.maincolour[global.team2];
				string FilePath = Application.dataPath+"/logos/"+Control.icon[global.team1]+".png";
				string FilePath2 = Application.dataPath+"/logos/"+Control.icon[global.team2]+".png";
				flag1.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
				flag2.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath2,100.0f);}

		} 
		posession=0;
		state="play";
		if(whostarts==0)
			whostarts=Random.Range(1,2);
		if(whostarts==1)
		{if(player1.GetComponent<player>().sentoff==false)
			player1.transform.position=new Vector3(0,0.8f,1.84f);
		else
			if(player22.GetComponent<player>().sentoff==false)
				player22.transform.position=new Vector3(0,0.8f,1.84f);
			else
				if(player3.GetComponent<player>().sentoff==false)
					player3.transform.position=new Vector3(0,0.8f,1.84f);
				else
					if(player4.GetComponent<player>().sentoff==false)
						player4.transform.position=new Vector3(0,0.8f,1.84f);}
		else
		{
			if(player1opp.GetComponent<player2>().sentoff==false)
				player1opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
			else
				if(player2opp.GetComponent<player2>().sentoff==false)
					player2opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
				else
					if(player3opp.GetComponent<player2>().sentoff==false)
						player3opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
					else
						if(player4opp.GetComponent<player2>().sentoff==false)
							player4opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
		}
		timespeed=Time.timeScale;if(global.kickedoff)Time.timeScale=1.0f;starttimeout=1;

		cornertaker=GameObject.Find("player"); //to be changed to assign player
		cornertaker2=GameObject.Find("playeropp");
		if(global.p1sentoff==false){
			penaltytaker=GameObject.Find("player2"); 
			freekicktaker=GameObject.Find("player2");}
		else
			if(global.p2sentoff==false){
				penaltytaker=GameObject.Find("player3"); 
				freekicktaker=GameObject.Find("player3");}
			else{
				penaltytaker=GameObject.Find("player4"); 
				freekicktaker=GameObject.Find("player4");}
		//////////////////////////////////////////////////
		if(global.p11sentoff==false){
			penaltytaker2=GameObject.Find("player2opp"); 
			freekicktaker2=GameObject.Find("player2opp");}
		else
			if(global.p22sentoff==false){
				penaltytaker2=GameObject.Find("player3opp"); 
				freekicktaker2=GameObject.Find("player3opp");}
			else
			{
				penaltytaker2=GameObject.Find("player4opp"); 
				freekicktaker2=GameObject.Find("player4opp");}
		/////////////////vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
		///////////////////////////////////////////////////////////
		if(global.cornertaker==9 && global.team1==global.id)
			cornertaker=GameObject.Find("player2");
		if(global.cornertaker==8 && global.team1==global.id)
			cornertaker=GameObject.Find("player3");
		if(global.cornertaker==7 && global.team1==global.id)
			cornertaker=GameObject.Find("player4");
		if(global.cornertaker==6 && global.team1==global.id)
			cornertaker=GameObject.Find("player5");
		if(global.cornertaker==5 && global.team1==global.id)
			cornertaker=GameObject.Find("player6");
		if(global.cornertaker==4 && global.team1==global.id)
			cornertaker=GameObject.Find("player7");
		if(global.cornertaker==3 && global.team1==global.id)
			cornertaker=GameObject.Find("player8");
		if(global.cornertaker==2 && global.team1==global.id)
			cornertaker=GameObject.Find("player9");
		if(global.cornertaker==1 && global.team1==global.id)
			cornertaker=GameObject.Find("player10");
		/////////////////////////////////////////////////////
		if(global.cornertaker==9 && global.team2==global.id)
			cornertaker2=GameObject.Find("player2opp");
		if(global.cornertaker==8 && global.team2==global.id)
			cornertaker2=GameObject.Find("player3opp");
		if(global.cornertaker==7 && global.team2==global.id)
			cornertaker2=GameObject.Find("player4opp");
		if(global.cornertaker==6 && global.team2==global.id)
			cornertaker2=GameObject.Find("player5opp");
		if(global.cornertaker==5 && global.team2==global.id)
			cornertaker2=GameObject.Find("player6opp");
		if(global.cornertaker==4 && global.team2==global.id)
			cornertaker2=GameObject.Find("player7opp");
		if(global.cornertaker==3 && global.team2==global.id)
			cornertaker2=GameObject.Find("player8opp");
		if(global.cornertaker==2 && global.team2==global.id)
			cornertaker2=GameObject.Find("player9opp");
		if(global.cornertaker==1 && global.team2==global.id)
			cornertaker2=GameObject.Find("player10opp");
		/////////////////////////////////
		////////////////////////////////////////
		if(global.penaltytaker==10 && global.team1==global.id)
			penaltytaker=GameObject.Find("player");
		if(global.penaltytaker==10 && global.team2==global.id)
			penaltytaker2=GameObject.Find("playeropp");
		if(global.penaltytaker==9 && global.team1==global.id)
			penaltytaker=GameObject.Find("player2");
		if(global.penaltytaker==9 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player2opp");
		if(global.penaltytaker==8 && global.team1==global.id)
			penaltytaker=GameObject.Find("player3");
		if(global.penaltytaker==8 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player3opp");
		if(global.penaltytaker==7 && global.team1==global.id)
			penaltytaker=GameObject.Find("player4");
		if(global.penaltytaker==7 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player4opp");
		if(global.penaltytaker==6 && global.team1==global.id)
			penaltytaker=GameObject.Find("player5");
		if(global.penaltytaker==6 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player5opp");
		if(global.penaltytaker==5 && global.team1==global.id)
			penaltytaker=GameObject.Find("player6");
		if(global.penaltytaker==5 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player6opp");
		if(global.penaltytaker==4 && global.team1==global.id)
			penaltytaker=GameObject.Find("player7");
		if(global.penaltytaker==4 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player7opp");
		if(global.penaltytaker==3 && global.team1==global.id)
			penaltytaker=GameObject.Find("player8");
		if(global.penaltytaker==3 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player8opp");
		if(global.penaltytaker==2 && global.team1==global.id)
			penaltytaker=GameObject.Find("player9");
		if(global.penaltytaker==2 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player9opp");
		if(global.penaltytaker==1 && global.team1==global.id)
			penaltytaker=GameObject.Find("player10");
		if(global.penaltytaker==1 && global.team2==global.id)
			penaltytaker2=GameObject.Find("player10opp");
		///////////////////////////////////////////////////////
		/////////////////////////////////////////////////
		if(global.freekicktaker==10){
			if(global.team1==global.id && global.p1sentoff==false)
				freekicktaker=GameObject.Find("player");
			if(global.team2==global.id && global.p11sentoff==false)
				freekicktaker2=GameObject.Find("playeropp");
		}
		if(global.freekicktaker==9){
			if(global.team1==global.id && global.p2sentoff==false)
				freekicktaker=GameObject.Find("player2");
			if(global.team2==global.id && global.p22sentoff==false)
				freekicktaker2=GameObject.Find("player2opp");
		}
		if(global.freekicktaker==8){
			if(global.team1==global.id && global.p3sentoff==false)
				freekicktaker=GameObject.Find("player3");
			if(global.team2==global.id && global.p33sentoff==false)
				freekicktaker2=GameObject.Find("player3opp");
		}
		if(global.freekicktaker==7){
			if(global.team1==global.id && global.p4sentoff==false)
				freekicktaker=GameObject.Find("player4");
			if(global.team2==global.id && global.p44sentoff==false)
				freekicktaker2=GameObject.Find("player4opp");
		}
		if(global.freekicktaker==6){
			if(global.team1==global.id && global.p5sentoff==false)
				freekicktaker=GameObject.Find("player5");
			if(global.team2==global.id && global.p55sentoff==false)
				freekicktaker2=GameObject.Find("player5opp");
		}
		if(global.freekicktaker==5){
			if(global.team1==global.id && global.p6sentoff==false)
				freekicktaker=GameObject.Find("player6");
			if(global.team2==global.id && global.p66sentoff==false)
				freekicktaker2=GameObject.Find("player6opp");
		}
		if(global.freekicktaker==4){
			if(global.team1==global.id && global.p7sentoff==false)
				freekicktaker=GameObject.Find("player7");
			if(global.team2==global.id && global.p77sentoff==false)
				freekicktaker2=GameObject.Find("player7opp");
		}
		if(global.freekicktaker==3){
			if(global.team1==global.id && global.p8sentoff==false)
				freekicktaker=GameObject.Find("player8");
			if(global.team2==global.id && global.p88sentoff==false)
				freekicktaker2=GameObject.Find("player8opp");
		}
		if(global.freekicktaker==2){
			if(global.team1==global.id && global.p9sentoff==false)
				freekicktaker=GameObject.Find("player9");
			if(global.team2==global.id && global.p99sentoff==false)
				freekicktaker2=GameObject.Find("player9opp");
		}
		if(global.freekicktaker==1){
			if(global.team1==global.id && global.p10sentoff==false)
				freekicktaker=GameObject.Find("player10");
			if(global.team2==global.id && global.p1010sentoff==false)
				freekicktaker2=GameObject.Find("player10opp");
		}
		time=0.0f;minutes=0;seconds=0;

		if((global.team1==global.id || global.team2==global.id )&& global.kickedoff==false) //if own team start with team talk
		{preteamtalk.SetActive(true);Time.timeScale=0.0f;global.kickedoff=true;}

		op1pos=player1.transform.position;op2pos=player22.transform.position;op3pos=player3.transform.position;op4pos=player4.transform.position;
		op5pos=player5.transform.position;op6pos=player6.transform.position;op7pos=player7.transform.position;op8pos=player8.transform.position;
		op9pos=player9.transform.position;op10pos=player10.transform.position;
		op1oppos=player1opp.transform.position;op2oppos=player2opp.transform.position;op3oppos=player3opp.transform.position;op4oppos=player4opp.transform.position;
		op5oppos=player5opp.transform.position;op6oppos=player6opp.transform.position;op7oppos=player7opp.transform.position;op8oppos=player8opp.transform.position;
		op9oppos=player9opp.transform.position;op10oppos=player10opp.transform.position;
		offsideline=GameObject.Find("offsideline");
		offsideline2=GameObject.Find("offsideline2");
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}  //start

	void  OnLevelWasLoaded (){
		if(Application.loadedLevelName=="dashboard")
			Destroy(gameObject);
		if(global.category=="clubs"){
			team1name.GetComponent<Text>().color=Control.clubtextcolour[global.team1];
			team2name.GetComponent<Text>().color=Control.clubtextcolour[global.team2];
			team1name.GetComponent<Text>().text=Control.clubname[global.team1];
			team2name.GetComponent<Text>().text=Control.clubname[global.team2];
			namepad1.GetComponent<Image>().color=Control.clubmaincolour[global.team1];
			namepad2.GetComponent<Image>().color=Control.clubmaincolour[global.team2];
			string FilePath= Application.dataPath+"/logos/"+Control.clubicon[global.team1]+".png";
			string FilePath2= Application.dataPath+"/logos/"+Control.clubicon[global.team2]+".png";
			flag1.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
			flag2.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath2,100.0f);
			if(global.isaggregate){
				aggregate1.SetActive(true);aggregate2.SetActive(true);
				aggregate1.GetComponent<Text>().text=global.team1aggregate.ToString();
				aggregate2.GetComponent<Text>().text=global.team2aggregate.ToString();} 
		}
		else{
			team1name.GetComponent<Text>().color=Control.textcolour[global.team1];
			team2name.GetComponent<Text>().color=Control.textcolour[global.team2];
			team1name.GetComponent<Text>().text=Control.countryname[global.team1];
			team2name.GetComponent<Text>().text=Control.countryname[global.team2];
			namepad1.GetComponent<Image>().color=Control.maincolour[global.team1];
			namepad2.GetComponent<Image>().color=Control.maincolour[global.team2];
			string FilePath = Application.dataPath+"/logos/"+Control.icon[global.team1]+".png";
			string FilePath2 = Application.dataPath+"/logos/"+Control.icon[global.team2]+".png";
			flag1.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
			flag2.GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath2,100.0f);}

		minutes=global.minutes;seconds=global.seconds;p1goals=global.p1goals;p2goals=global.p2goals;
		p1score.GetComponent<Text>().text=p1goals.ToString();
		p2score.GetComponent<Text>().text=p2goals.ToString();
		crowd.Play();SHOOT=false;
		posession=0;
		if(whostarts==0)
			whostarts=Random.Range(1,2);
		if(whostarts==1)
		{if(player1.GetComponent<player>().sentoff==false)
			player1.transform.position=new Vector3(0,0.8f,1.84f);
		else
			if(player22.GetComponent<player>().sentoff==false)
				player22.transform.position=new Vector3(0,0.8f,1.84f);
			else
				if(player3.GetComponent<player>().sentoff==false)
					player3.transform.position=new Vector3(0,0.8f,1.84f);
				else
					if(player4.GetComponent<player>().sentoff==false)
						player4.transform.position=new Vector3(0,0.8f,1.84f);}
		else
		{
			if(player1opp.GetComponent<player2>().sentoff==false)
				player1opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
			else
				if(player2opp.GetComponent<player2>().sentoff==false)
					player2opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
				else
					if(player3opp.GetComponent<player2>().sentoff==false)
						player3opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
					else
						if(player4opp.GetComponent<player2>().sentoff==false)
							player4opp.transform.position=new Vector3(0.7f,0.8f,4.5f);
		}
		if(global.kickedoff==false)Time.timeScale=0.0f;starttimeout=1;
		////////////////////////////////////////////////////////////////////////
		if(global.team1==global.id)  //own team
		{LoadOwnPlayerAtts("player1");
			SetOwnFormation();
			SetWidth("player1");
			SetOwnMentality();}        //set own player formation
		else
		{LoadPlayerAtts("player1");
			SetFormation("player1");}

		if(global.team2==global.id)
		{LoadOwnPlayerAtts("player2");
			SetOwnFormation();
			SetWidth("player2");
			SetOwnMentality();}
		else
		{LoadPlayerAtts("player2");
			SetFormation("player2");}

		LoadPlayerSkins();
		///////////////////////////////////////////////////////////////
		if(global.Event=="championsleague" || global.Event=="uefacup" || global.Event=="worldcup" || global.Event=="euro" ||
			global.Event=="asiancup" || global.Event=="goldcup")
			RenderSettings.skybox=night;
		else
			RenderSettings.skybox=daylight;

		if(global.team1!=global.id && global.team2!=global.id){ //hide dropdowns in a watch not own team match
			MentalityDropDown.SetActive(false);
			FormationDropDown.SetActive(false);
			WidthDropDown.SetActive(false);
			TackleDropDown.SetActive(false);
			Substitution.SetActive(false);
		}
		CheckSentoffs();
		LoadRatings();
	}////start////////////////

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	void  Update (){  //Debug.Log("posession "+posession+""+" ballstate "+Ball.state);
		if(GameObject.Find("Canvas").transform.Find("Substitution").gameObject.activeSelf)return;
		if(minutes==45){
			if(menutimeout==0){timespeed=Time.timeScale;
				Time.timeScale=0.0f;whistle.Play();
				halftimeprompt.SetActive(true);player1.GetComponent<player>().foulprompt.SetActive(false);
			}
			if(menutimeout==50){Time.timeScale=0.0f;
				halftimeprompt.SetActive(false);
				halftimetalk.SetActive(true);
			}
			if(menutimeout<51)
				menutimeout+=1;
		}

		if(error){
			if(global.team1!=global.id)
				LoadPlayerAtts("player1");
			else
				LoadPlayerAtts("player2");
		}

		if(posessor!=null){
			gizmo.position=posessor.transform.position+Vector3.up*3.8f;
			if(posessor.tag=="Player"){
				gizmotext.GetComponent<Text>().text=posessor.GetComponent<player>().playername.ToString();
				if(posessor.GetComponent<player>().booked)
					gizmotext.GetComponent<Text>().color=Color.yellow;
				else
					gizmotext.GetComponent<Text>().color=Color.white;}
			if(posessor.tag=="Player2"){
				gizmotext.GetComponent<Text>().text=posessor.GetComponent<player2>().playername.ToString();
				if(posessor.GetComponent<player2>().booked)
					gizmotext.GetComponent<Text>().color=Color.yellow;
				else
					gizmotext.GetComponent<Text>().color=Color.white;}
			if(posessor.tag=="keeper"){
				gizmotext.GetComponent<Text>().text=posessor.GetComponent<goalkeeper>().playername.ToString();gizmotext.GetComponent<Text>().color=Color.white;}  //glitch fix
			if(posessor.tag=="keeper2"){
				gizmotext.GetComponent<Text>().text=posessor.GetComponent<goalkeeper2>().playername.ToString();gizmotext.GetComponent<Text>().color=Color.white;}}
		if(shot>0)
			shot-=1;
		time+=Time.deltaTime;
		if(time>=0.1f && time<=0.1f+Time.deltaTime){
			seconds+=1;time=0.0f;clock.GetComponent<Text>().text=minutes.ToString()+":"+seconds.ToString();}
		if(seconds==60){ p1score.GetComponent<Text>().text=p1goals.ToString();p2score.GetComponent<Text>().text=p2goals.ToString();
			if(minutes<120)
				minutes+=1;seconds=0;clock.GetComponent<Text>().text=minutes.ToString()+":"+seconds.ToString();}
		if(minutes>=90 && global.extratime==false && global.penalties==false && preparingpenalties==false){  //end match
			if(Random.Range(1,1000)<=1){
				whistle.Play();timespeed=Time.timeScale;Time.timeScale=0.0f;
				menutimeout+=1;}
			if(menutimeout>0 && menutimeout<120)
				menutimeout+=1;
			if(menutimeout==29){
				finalwhistle.SetActive(true);
				if(global.isknockout && global.team1goals==global.team2goals)
					ET.SetActive(true);}
			if(menutimeout==119 && global.isknockout)  //if knockout match go to extra time
			{if(global.team1goals==global.team2goals)
				{global.extratime=true;finalwhistle.SetActive(false);Time.timeScale=timespeed;Application.LoadLevel(Application.loadedLevel);ET.SetActive(false);}
			else
			{if(global.team1goals>global.team2goals)global.winner=global.team1;
			else
				global.winner=global.team2;global.kickedoff=false;
			if(global.team1==global.id || global.team2==global.id)
				EndTeamTalk.SetActive(true);
			else
				Application.LoadLevel("dashboard");}
			menutimeout=0;}//ko
			else if(menutimeout==119 && global.isknockout==false && global.isaggregate==false) // end match
			{ if(global.team1goals>global.team2goals)
				global.winner=global.team1;
				if(global.team1goals<global.team2goals)
					global.winner=global.team2;
				if(global.team1goals==global.team2goals)
					global.winner=0; global.kickedoff=false;
				if(global.team1==global.id || global.team2==global.id)
					EndTeamTalk.SetActive(true);
				else
					Application.LoadLevel("dashboard");}//not ko
			else if(menutimeout==119 && global.isaggregate==true){  //aggregate 
				if(global.issecondleg){//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvlast leg
					if(global.Event=="championsleague"){
						if(global.team1aggregate==global.team2aggregate){
							if(Control.clubawaygoals[global.team1]>Control.clubawaygoals[global.team2])
							{global.kickedoff=false;;global.winner=global.team1;if(global.team1==global.id || global.team2==global.id)
								EndTeamTalk.SetActive(true);
							else
								Application.LoadLevel("dashboard");}
							if(Control.clubawaygoals[global.team2]>Control.clubawaygoals[global.team1])
							{global.kickedoff=false;;global.winner=global.team2;if(global.team1==global.id || global.team2==global.id)
								EndTeamTalk.SetActive(true);
							else
								Application.LoadLevel("dashboard");}
							if(Control.clubawaygoals[global.team2]==Control.clubawaygoals[global.team1])
							{finalwhistle.SetActive(false);global.penalties=true;global.extratime=false;Time.timeScale=1.0f;
								SetupPenalties();Penaltyscore.SetActive(true);}  //straight to penalties
						}
						else{ //not same aggregate
							if(global.team1aggregate>global.team2aggregate)
							{global.winner=global.team1;}
							if(global.team1aggregate<global.team2aggregate)
							{global.winner=global.team2;}global.kickedoff=false;
							if(global.team1==global.id || global.team2==global.id)
								EndTeamTalk.SetActive(true);
							else
								Application.LoadLevel("dashboard");
						}
					}
					else{  //not ucl
						if(global.team1aggregate==global.team2aggregate)
						{finalwhistle.SetActive(false);global.penalties=true;global.extratime=false;Time.timeScale=1.0f;
							SetupPenalties();Penaltyscore.SetActive(true);} //to penalties
						else
						{if(global.team1aggregate>global.team2aggregate)
							{global.winner=global.team1;}
							if(global.team1aggregate<global.team2aggregate)
							{global.winner=global.team2;}global.kickedoff=false;
							if(global.team1==global.id || global.team2==global.id)
								EndTeamTalk.SetActive(true);
							else
								Application.LoadLevel("dashboard");}
					}
				}//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
				else{  //not second leg yet
					if(global.team1goals>global.team2goals)
						global.winner=global.team1;
					if(global.team1goals<global.team2goals)
						global.winner=global.team2;
					if(global.team1goals==global.team2goals)
						global.winner=0;global.kickedoff=false;
					if(global.team1==global.id || global.team2==global.id)
						EndTeamTalk.SetActive(true);
					else
						Application.LoadLevel("dashboard");
				}
			}//agg

		}///////////////
		if(minutes>90 && global.extratime==true && global.penalties==false){  //keep clocking extra time
			if(minutes==105){  //half time in extra time
				whistle.Play();timespeed=Time.timeScale;Time.timeScale=0.0f;menutimeout++;minutes=106;
			} 
			if(minutes==106 && Time.timeScale==0.0f) 
				menutimeout++;
			if(menutimeout>=30 && preparingpenalties==false){  //fix
				menutimeout=0;Time.timeScale=timespeed;Application.LoadLevel(Application.loadedLevel);}//continue

			if(minutes==120 && global.penalties==false){//end of extra time xxxxxxxxxto penaltiesxxxxxxxxxxxxxx bug fix
				if(menutimeout==0)
				{whistle.Play();timespeed=Time.timeScale;Time.timeScale=0.0f;menutimeout++;finalwhistle.SetActive(true);minutes=121; preparingpenalties=true;}}
			if(minutes==121){
				if(menutimeout<60)
					menutimeout++;
				if(menutimeout==59){
					if(global.team1goals==global.team2goals)
					{finalwhistle.SetActive(false);global.penalties=true;global.extratime=false;Time.timeScale=1.0f;
						SetupPenalties();Penaltyscore.SetActive(true);finalwhistle.SetActive(false);}  //prepare for penalties
					else
					{ if(global.team1goals>global.team2goals)global.winner=global.team1;
					else
						global.winner=global.team2;global.kickedoff=false;
					if(global.team1==global.id || global.team2==global.id)
						EndTeamTalk.SetActive(true);
					else
						Application.LoadLevel("dashboard");}
				} 
			}
		}
		if(global.penalties)
			SetupPenalties();

		CheckOffside();
		if(state=="penaltytop2" || state=="penaltytop1"){
			pausetimeout+=Time.deltaTime;
			if(pausetimeout>=4.0f && pausetimeout<=4.0f+Time.deltaTime && book==true)
			{BookPlayer();if(state=="penaltytop1")victim.GetComponent<player>().foulprompt.SetActive(false);
			else
				victim.GetComponent<player2>().foulprompt.SetActive(false);CloseFoul();Debug.Log("penalty!");}
			if(pausetimeout>=6.5f && pausetimeout<=6.5f+Time.deltaTime){  //single step / frame
				if(state=="penaltytop2")
					SetupPenaltyToP2();
				else
					SetupPenaltyToP1();}
			if(pausetimeout>=8.0f && pausetimeout<=8.0f+Time.deltaTime)  //fix
			{posession=9;
				if(state=="penaltytop1")
				{ penaltytaker.GetComponent<player>().GetComponent<Animation>().Play("kick");//kick.Play();
					penaltytaker.GetComponent<player>().state="shooting";
					penaltytaker.GetComponent<player>().shottimeout=31; state="play";
					penaltytaker.GetComponent<player>().acting=true;posession=0;ball.GetComponent<Rigidbody>().isKinematic=false;Ball.state="free";Ball.owner=null;}
				if(state=="penaltytop2")
				{penaltytaker2.GetComponent<player2>().GetComponent<Animation>().Play("kick");
					penaltytaker2.GetComponent<player2>().state="shooting";
					penaltytaker2.GetComponent<player2>().shottimeout=31; state="play";
					penaltytaker2.GetComponent<player2>().acting=true;posession=0;ball.GetComponent<Rigidbody>().isKinematic=false;Ball.state="free";Ball.owner=null;}
			}    //penalty taker given trigger to kick penalty
			if(pausetimeout>=9.0f)
			{posession=0;book=false;pausetimeout=0.0f;}
		}

		if(state=="freekicktop2" || state=="freekicktop1"){if(posession==0 && pausetimeout>0.1f && pausetimeout<8.0f)posession=7;
			pausetimeout+=Time.deltaTime;
			if(pausetimeout>=4.0f && pausetimeout<=4.0f+Time.deltaTime*1.5f)
			{if(book==true)
				BookPlayer();
				if(state=="freekicktop1" && victim!=null)victim.GetComponent<player>().foulprompt.SetActive(false);
				else{if(victim!=null)
					{if(victim.tag=="Player")
						victim.GetComponent<player>().foulprompt.SetActive(false);CloseFoul();offsideprompt.SetActive(false);}}}//bug fix

			if(pausetimeout>=5.0f && pausetimeout<=5.0f+Time.deltaTime && offside==false)
			{culprit.transform.position+=new Vector3(7,0,0);
				victim.transform.position-=new Vector3(7,0,0);
				culprit.GetComponent<Animation>().Play("idle");victim.GetComponent<Animation>().Play("idle");ResetAnimations();}
			if(pausetimeout>=6.5f && pausetimeout<=6.5f+Time.deltaTime){  //single step / frame
				if(state=="freekicktop2")
					SetupFreeKickToP2();
				else
					SetupFreeKickToP1();}
			if(pausetimeout>=8.0f && pausetimeout<=8.0f+Time.deltaTime*1.5f)
			{if(state=="freekicktop2"){
					freekicktaker2.GetComponent<player2>().freekicktimeout=0.0f;
					freekicktaker2.GetComponent<player2>().state="freekick";

				}
				if(state=="freekicktop1"){
					freekicktaker.GetComponent<player>().freekicktimeout=0.0f;
					freekicktaker.GetComponent<player>().state="freekick";

				}
				posession=0;Ball.state="free";}    //freekick taker given trigger to kick freekick
			if(pausetimeout>=9.0f)
			{posession=0;state="play";book=false;pausetimeout=0.0f;offside=false;ResetPlayers();offsideprompt.SetActive(false);
			}
		}
		//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		nearest1=null;   //determine nearest players to the ball
		if(player1!=null)   //remember to null player on sending off
			nearest1=player1;
		if(player22!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player22)<DistanceToBall(nearest1) && player22.GetComponent<player>().acting==false)
				nearest1=player22;}
		else
			nearest1=player22;
	}
		if(player3!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player3)<DistanceToBall(nearest1) && player3.GetComponent<player>().acting==false)
				nearest1=player3;}
		else
			nearest1=player3;
	}
		if(player4!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player4)<DistanceToBall(nearest1) && player4.GetComponent<player>().acting==false)
				nearest1=player4;}
		else
			nearest1=player4;
	}
		if(player5!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player5)<DistanceToBall(nearest1) && player5.GetComponent<player>().acting==false)
				nearest1=player5;}
		else
			nearest1=player5;
	}
		if(player6!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player6)<DistanceToBall(nearest1) && player6.GetComponent<player>().acting==false)
				nearest1=player6;}
		else
			nearest1=player6;
	}
		if(player7!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player7)<DistanceToBall(nearest1) && player7.GetComponent<player>().acting==false)
				nearest1=player7;}
		else
			nearest1=player7;
	}
		if(player8!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player8)<DistanceToBall(nearest1) && player8.GetComponent<player>().acting==false)
				nearest1=player8;}
		else
			nearest1=player8;
	}
		if(player9!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player9)<DistanceToBall(nearest1) && player9.GetComponent<player>().acting==false)
				nearest1=player9;}
		else
			nearest1=player9;
	}
		if(player10!=null)
		{if(nearest1!=null)
			{if(DistanceToBall(player10)<DistanceToBall(nearest1) && player10.GetComponent<player>().acting==false)
				nearest1=player10;}
		else
			nearest1=player10;
	}
		//player two  i am angry
		nearest2=null;   //determine nearest players to the ball
		if(player1opp!=null)   //remember to null player on sending off
			nearest2=player1opp;
		if(player2opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player2opp)<DistanceToBall(nearest2) && player2opp.GetComponent<player2>().acting==false)
				nearest2=player2opp;}
		else
			nearest2=player2opp;
	}
		if(player3opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player3opp)<DistanceToBall(nearest2) && player3opp.GetComponent<player2>().acting==false)
				nearest2=player3opp;}
		else
			nearest2=player3opp;
	}
		if(player4opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player4opp)<DistanceToBall(nearest2) && player4opp.GetComponent<player2>().acting==false)
				nearest2=player4opp;}
		else
			nearest2=player4opp;
	}
		if(player5opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player5opp)<DistanceToBall(nearest2) && player5opp.GetComponent<player2>().acting==false)
				nearest2=player5opp;}
		else
			nearest2=player5opp;
	}
		if(player6opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player6opp)<DistanceToBall(nearest2) && player6opp.GetComponent<player2>().acting==false)
				nearest2=player6opp;}
		else
			nearest2=player6opp;
	}
		if(player7opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player7opp)<DistanceToBall(nearest2) && player7opp.GetComponent<player2>().acting==false)
				nearest2=player7opp;}
		else
			nearest2=player7opp;
	}
		if(player8opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player8opp)<DistanceToBall(nearest2) && player8opp.GetComponent<player2>().acting==false)
				nearest2=player8opp;}
		else
			nearest2=player8opp;
	}
		if(player9opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player9opp)<DistanceToBall(nearest2) && player9opp.GetComponent<player2>().acting==false)
				nearest2=player9opp;}
		else
			nearest2=player9opp;
	}
		if(player10opp!=null)
		{if(nearest2!=null)
			{if(DistanceToBall(player10opp)<DistanceToBall(nearest2) && player10opp.GetComponent<player2>().acting==false)
				nearest2=player10opp;}
		else
			nearest2=player10opp;
	}
		if(SHOOT==true){ 
			shoottimeout+=Time.deltaTime;
			if(shoottimeout>=1.5f)
			{shoottimeout=0.0f;}}
		//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		if(starttimeout>0)
			starttimeout+=1;
		if(starttimeout>=60)
		{starttimeout=0;if(global.fromdashboard==false)Time.timeScale=1.0f;}
		if(throwingin==true){
			throwingin=false;ThrowIn();}
		if(throwintimeout>0)
		{throwintimeout+=1; }
		if(throwintimeout==60){ Time.timeScale=timespeed;//throw in mechanism
			ball.GetComponent<Rigidbody>().isKinematic=false; bookedprompt.SetActive(false);player1.GetComponent<player>().foulprompt.SetActive(false);
			if(ball.transform.position.x<0)
				ball.GetComponent<Rigidbody>().AddForce(Vector3.right*10,ForceMode.Impulse);
			else
				ball.GetComponent<Rigidbody>().AddForce(-Vector3.right*10,ForceMode.Impulse);
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*5,ForceMode.Impulse);}
		if(throwintimeout>=66)
		{posession=0;throwintimeout=0;ball.GetComponent<Ball>().outed=false;ball.GetComponent<Rigidbody>().isKinematic=false;}
		if(outcome==1)//goal kick
			GoalKick();
		if(outcome==2)
			Corner();
		if(CORNER)
		{timeout+=Time.deltaTime;  }
		if(timeout>=3.7f){
			CORNER=false;timeout=0.0f;}

		CheckSentoffs();
		DoTactics();    //AI team mentality according to scores

		//SetMentality();  
		if((posession==1 && Ball.state=="free") ||(posession==2 && Ball.state=="free"))
			posession=0;
		CheckErrors();
		//Debug.Log("AIpos "+posession+" ballstate "+Ball.state+" owner "+Ball.owner);
		if(postimeout<2)
			postimeout++;
		///////////////////////////////////////////////////////////
	}///////////////update/////////////////////////////////

	void  BookPlayer (){ book=false;
		if(culprit.tag=="Player"){
			if(culprit.GetComponent<player>().booked==false)
			{bookedprompt.SetActive(true);bookedprompt.transform.Find("Text").GetComponent<Text>().text="Yellow card to "+culprit.GetComponent<player>().playername;
				culprit.GetComponent<player>().booked=true;}
			else if(culprit.GetComponent<player>().booked==true){
				sentoffprompt.SetActive(true);
				sentoffprompt.transform.Find("Text").GetComponent<Text>().text=culprit.GetComponent<player>().playername+" sent off!";
				culprit.GetComponent<player>().state="inactive";culprit.transform.position=new Vector3(-100,0,0);culprit.GetComponent<Rigidbody>().isKinematic=true;
				if(culprit.name=="player")
					global.p1sentoff=true;
				if(culprit.name=="player2")
					global.p2sentoff=true;
				if(culprit.name=="player3")
					global.p3sentoff=true;
				if(culprit.name=="player4")
					global.p4sentoff=true;
				if(culprit.name=="player5")
					global.p5sentoff=true;
				if(culprit.name=="player6")
					global.p6sentoff=true;
				if(culprit.name=="player7")
					global.p7sentoff=true;
				if(culprit.name=="player8")
					global.p8sentoff=true;
				if(culprit.name=="player9")
					global.p9sentoff=true;
				if(culprit.name=="player10")
					global.p10sentoff=true;global.number1sentoff++;}///
		}
		if(culprit.tag=="Player2"){
			if(culprit.GetComponent<player2>().booked==false)
			{bookedprompt.SetActive(true);bookedprompt.transform.Find("Text").GetComponent<Text>().text="Yellow card to "+culprit.GetComponent<player2>().playername;
				culprit.GetComponent<player2>().booked=true;}
			else
				if(culprit.GetComponent<player2>().booked==true){
					sentoffprompt.SetActive(true);
					sentoffprompt.transform.Find("Text").GetComponent<Text>().text=culprit.GetComponent<player2>().playername+" sent off!";
					culprit.GetComponent<player2>().state="inactive";culprit.transform.position=new Vector3(-100,0,0);culprit.GetComponent<Rigidbody>().isKinematic=true;
					if(culprit.name=="playeropp")
						global.p11sentoff=true;
					if(culprit.name=="player2opp")
						global.p22sentoff=true;
					if(culprit.name=="player3opp")
						global.p33sentoff=true;
					if(culprit.name=="player4op")
						global.p44sentoff=true;
					if(culprit.name=="player5opp")
						global.p55sentoff=true;
					if(culprit.name=="player6opp")
						global.p66sentoff=true;
					if(culprit.name=="player7opp")
						global.p77sentoff=true;
					if(culprit.name=="player8opp")
						global.p88sentoff=true;
					if(culprit.name=="player9opp")
						global.p99sentoff=true;
					if(culprit.name=="player10opp")
						global.p1010sentoff=true;global.number2sentoff++;}///
		}
		// pop up booked dialog
		//if player was already booked, popup other dialog  and send him off
	}
	void  SetupFreeKickToP2 (){
		if(offside)
			ball.transform.position=new Vector3(freekickx,0.8f,offsideline2.transform.position.z);
		else
			ball.transform.position=new Vector3(freekickx,0.8f,freekickz);//set up ball position 
		if(Vector3.Distance(ball.transform.position,kpos.transform.position)<35)//depending on distance to goal, setup player positions and orientations for free kick
		{
			if(player3.GetComponent<player>().sentoff==false)
				player3.transform.position=new Vector3(freekickx-2.0f,0.8f,freekickz-8.0f);
			if(player4.GetComponent<player>().sentoff==false)
				player4.transform.position=new Vector3(freekickx+0.0f,0.8f,freekickz-8.0f);
			if(player5.GetComponent<player>().sentoff==false)
				player5.transform.position=new Vector3(freekickx+2.0f,0.8f,freekickz-8.0f);
			if(player6.GetComponent<player>().sentoff==false)
				player6.transform.position=new Vector3(freekickx+4.0f,0.8f,freekickz-8.0f);
			if(Vector3.Distance(player7.transform.position,ball.transform.position)<4)
				player7.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player8.transform.position,ball.transform.position)<4)
				player8.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player9.transform.position,ball.transform.position)<4)
				player9.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player10.transform.position,ball.transform.position)<4)
				player10.transform.position+=new Vector3(2.0f,0,0);
		}//x
		keeper.transform.position=kpos.transform.position;
		keeper.transform.LookAt(spotopp.transform);
		if(offside)
			freekicktaker2.transform.position=new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z+1.2f);
		else
			freekicktaker2.transform.position=new Vector3(freekickx,0.8f,freekickz+1.2f);// position free kick taker according to tactics
		freekicktaker2.transform.LookAt(new Vector3(freekickx,0.8f,freekickz));
	}
	void  SetupFreeKickToP1 (){
		if(offside)
			ball.transform.position=new Vector3(freekickx,0.8f,offsideline.transform.position.z);
		else
			ball.transform.position=new Vector3(freekickx,0.8f,freekickz);//set up ball position 
		if(Vector3.Distance(ball.transform.position,kposopp.transform.position)<35)//depending on distance to goal, setup player positions and orientations for free kick
		{
			if(player3opp.GetComponent<player2>().sentoff==false)
				player3opp.transform.position=new Vector3(freekickx-2.0f,0.8f,freekickz+8.0f);
			if(player4opp.GetComponent<player2>().sentoff==false)
				player4opp.transform.position=new Vector3(freekickx+0.0f,0.8f,freekickz+8.0f);
			if(player5opp.GetComponent<player2>().sentoff==false)
				player5opp.transform.position=new Vector3(freekickx+2.0f,0.8f,freekickz+8.0f);
			if(player6opp.GetComponent<player2>().sentoff==false)
				player6opp.transform.position=new Vector3(freekickx+4.0f,0.8f,freekickz+8.0f);
			if(Vector3.Distance(player7opp.transform.position,ball.transform.position)<4)
				player7opp.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player8opp.transform.position,ball.transform.position)<4)
				player8opp.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player9opp.transform.position,ball.transform.position)<4)
				player9opp.transform.position+=new Vector3(2.0f,0,0);
			if(Vector3.Distance(player10opp.transform.position,ball.transform.position)<4)
				player10opp.transform.position+=new Vector3(2.0f,0,0);
		}//x
		keeper2.transform.position=kposopp.transform.position;
		keeper2.transform.LookAt(spot.transform);
		if(offside)
			freekicktaker.transform.position=new Vector3(ball.transform.position.x,0.8f,ball.transform.position.z-1.2f);
		else
			freekicktaker.transform.position=new Vector3(freekickx,0.8f,freekickz-1.2f);// position free kick taker according to tactics
		freekicktaker.transform.LookAt(new Vector3(freekickx,0.8f,freekickz));
	}

	void  SetupPenaltyToP2 (){
		ball.transform.position=spotopp.transform.position;//put ball on spot and position all players , 
		penaltytaker2.transform.position=spotopp.transform.position+Vector3.forward;//put penalty kicker in the spot according to settings in tactics
		penaltytaker2.transform.LookAt(spotopp.transform);
		keeper.transform.position=kpos.transform.position;
		keeper.transform.LookAt(spotopp.transform);
	}

	void  SetupPenaltyToP1 (){
		ball.transform.position=spot.transform.position;//put ball on spot and position all players , 
		penaltytaker.transform.position=spot.transform.position-Vector3.forward;//put penalty kicker in the spot according to settings in tactics
		penaltytaker.transform.LookAt(spot.transform);
		keeper2.transform.position=kposopp.transform.position;
		keeper2.transform.LookAt(spot.transform);
	}

	void  Corner (){
		cornertimeout+=1;
		if(cornertimeout==1){timespeed=Time.timeScale;Time.timeScale=0.0f;bookedprompt.SetActive(false);player1.GetComponent<player>().foulprompt.SetActive(false);
			if(ball.transform.position.z>0){//left
				ball.transform.position=corneropp.position+Vector3.up*0.1f;;
				cornertaker.transform.position=corneropp.position-Vector3.right; //change cornertaker when this cornertaker is sent off
				cornertaker.transform.LookAt(corneropp);
				PositionPlayers();
			}
			else{//right
				ball.transform.position=corner.position+Vector3.up*0.1f;
				cornertaker2.transform.position=corner.position-Vector3.right; //change cornertaker when this cornertaker is sent off
				cornertaker2.transform.LookAt(corner);
				PositionPlayers2();
			}
		}
		if(cornertimeout==59)
			ball.GetComponent<Rigidbody>().isKinematic=false;
		if(cornertimeout==60){ //corner taker kicks ball
			Time.timeScale=timespeed;
			if(ball.transform.position.z>0){
				cornertaker.GetComponent<Animation>().Play("kick"); var corners=cornertaker.GetComponent<player>().crossing;ball.GetComponent<Rigidbody>().isKinematic=false;kick.Play();
				if(Random.Range(0,200)<=corners)
					ball.GetComponent<Rigidbody>().AddForce(Vector3.right*Random.Range(15,23)-Vector3.forward*5,ForceMode.Impulse);
				else
					ball.GetComponent<Rigidbody>().AddForce(Vector3.right*Random.Range(24,28)-Vector3.forward*5,ForceMode.Impulse);
				ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(9,15),ForceMode.Impulse);
			}
			else
			{
				cornertaker2.GetComponent<Animation>().Play("kick");var  corners=cornertaker2.GetComponent<player2>().crossing;ball.GetComponent<Rigidbody>().isKinematic=false;kick.Play();
				if(Random.Range(0,200)<=corners)
					ball.GetComponent<Rigidbody>().AddForce(Vector3.right*Random.Range(15,23)+Vector3.forward*5,ForceMode.Impulse);
				else
					ball.GetComponent<Rigidbody>().AddForce(Vector3.right*Random.Range(24,28)+Vector3.forward*5,ForceMode.Impulse);
				ball.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(9,15),ForceMode.Impulse);
			}
		}
		if(cornertimeout==66)
		{cornertimeout=0;outcome=0;posession=0;CORNER=true;ball.GetComponent<Ball>().outed=false;}
	}


	void  GoalKick (){
		gktimeout+=1;
		if(gktimeout==1){timespeed=Time.timeScale;ball.GetComponent<Rigidbody>().velocity=Vector3.zero;Time.timeScale=0.0f;RepositionPlayers();
			if(bookedprompt.activeSelf)bookedprompt.SetActive(false);
			if(ball.transform.position.z>0){//left
				ball.transform.position=spot.transform.position+Vector3.up*0.3f;
				keeper2.transform.position=kposopp.transform.position;keeper2.transform.LookAt(spotopp.transform);
				keeper2.GetComponent<Rigidbody>().isKinematic=true;}
			else
			{//right
				ball.transform.position=spotopp.transform.position+Vector3.up*0.3f;
				keeper.transform.position=kpos.transform.position;keeper.transform.LookAt(spot.transform);
				keeper.GetComponent<Rigidbody>().isKinematic=true;}
		}//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		if(gktimeout>=60 && gktimeout<120 && ball.transform.position.z>0){//keeper 2 runs and kicks ball
			Time.timeScale=timespeed;ball.GetComponent<Rigidbody>().isKinematic=true;keeper2.GetComponent<goalkeeper2>().state="busy";
			keeper2.GetComponent<Rigidbody>().MovePosition(keeper2.transform.position+keeper2.transform.forward*0.15f);
			if(!keeper2.GetComponent<Animation>().IsPlaying("run"))keeper2.GetComponent<Animation>().Play("run");keeper2.GetComponent<Animation>()["run"].speed=2.0f;
		}
		if(gktimeout>=60 && gktimeout<120 && ball.transform.position.z<0){//keeper runs and kicks ball
			Time.timeScale=timespeed;ball.GetComponent<Rigidbody>().isKinematic=true;keeper.GetComponent<goalkeeper>().state="busy";
			keeper.GetComponent<Rigidbody>().MovePosition(keeper.transform.position+keeper.transform.forward*0.15f);
			if(!keeper.GetComponent<Animation>().IsPlaying("run"))keeper.GetComponent<Animation>().Play("run");keeper.GetComponent<Animation>()["run"].speed=2.0f;
		}//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		if(gktimeout==120 && ball.transform.position.z>0){  keeper2.GetComponent<goalkeeper2>().timer+=1*Time.timeScale;
			keeper2.GetComponent<Animation>().Play("kick");ball.GetComponent<Rigidbody>().isKinematic=false;ball.GetComponent<Rigidbody>().AddForce(-Vector3.forward*16,ForceMode.Impulse);
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*10,ForceMode.Impulse);kick.Play();  keeper2.GetComponent<goalkeeper2>().state="idle";
			keeper2.GetComponent<goalkeeper2>().justkicked=true;Ball.state="free";Ball.owner=null;
		}
		if(gktimeout==120 && ball.transform.position.z<0){  keeper.GetComponent<goalkeeper>().timer+=1*Time.timeScale;
			keeper.GetComponent<Animation>().Play("kick");ball.GetComponent<Rigidbody>().isKinematic=false;ball.GetComponent<Rigidbody>().AddForce(Vector3.forward*16,ForceMode.Impulse);
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up*10,ForceMode.Impulse);kick.Play(); keeper.GetComponent<goalkeeper>().state="idle";
			keeper.GetComponent<goalkeeper>().justkicked=true;Ball.state="free";Ball.owner=null;keeper.GetComponent<Rigidbody>().isKinematic=true;
		}
		if(gktimeout==140)
		{outcome=0;gktimeout=0;posession=0;ball.GetComponent<Ball>().outed=false;keeper.GetComponent<Rigidbody>().isKinematic=false;keeper2.GetComponent<Rigidbody>().isKinematic=false;}
	}

	void  ThrowIn (){

		if(cameoff=="p2")
		{
			if(player1.GetComponent<player>().sentoff==false)
			{player1.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player1.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player22.GetComponent<player>().sentoff==false)
			{player22.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player22.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player3.GetComponent<player>().sentoff==false)
			{player3.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player3.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player4.GetComponent<player>().sentoff==false)
			{player4.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player4.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			ball.transform.position=new Vector3(throwinx,3.7f,throwinz);
			if(ball.transform.position.x<0){
				if(player5.GetComponent<player>().sentoff==false)
					player5.transform.position=new Vector3(throwinx,0.8f,throwinz)+Vector3.right*12;}
			else
			{if(player5.GetComponent<player>().sentoff==false)
				player5.transform.position=new Vector3(throwinx,0.8f,throwinz)-Vector3.right*12;}
			player5.transform.LookAt(new Vector3(throwinx,0.8f,throwinz));//contd

		}
		if(cameoff=="p1")
		{
			if(player1opp.GetComponent<player2>().sentoff==false)
			{player1opp.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player1opp.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player2opp.GetComponent<player2>().sentoff==false)
			{player2opp.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player2opp.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player3opp.GetComponent<player2>().sentoff==false)
			{player3opp.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player3opp.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			else if(player4opp.GetComponent<player2>().sentoff==false)
			{player4opp.transform.position=new Vector3(throwinx,0.8f,throwinz);
				player4opp.transform.LookAt(new Vector3(0,0.8f,transform.position.z));}
			ball.transform.position=new Vector3(throwinx,3.7f,throwinz);
			if(ball.transform.position.x<0){
				if(player5opp.GetComponent<player2>().sentoff==false)
					player5opp.transform.position=new Vector3(throwinx,0.8f,throwinz)+Vector3.right*7;}
			else
			{if(player5opp.GetComponent<player2>().sentoff==false)
				player5opp.transform.position=new Vector3(throwinx,0.8f,throwinz)-Vector3.right*7;}
			player5opp.transform.LookAt(new Vector3(throwinx,0.8f,throwinz));
		}
		timespeed=Time.timeScale;Time.timeScale=0.0f; throwintimeout=1;throwingin=false;
	}

	float  DistanceToBall ( GameObject obj  ){
		float dist= Vector3.Distance(ball.transform.position,obj.transform.position);
		return dist;
	}

	void  PositionPlayers (){
		keeper2.transform.position=new Vector3( 0, 0.8f, 56);  //all x -5 now
		if(player8!=cornertaker && player8.GetComponent<player>().sentoff==false)
			player8.transform.position=new Vector3(-3.31f,0.8f,50);  //will change player positions later
		if(player8opp!=cornertaker && player8opp.GetComponent<player2>().sentoff==false)
			player8opp.transform.position=new Vector3(-4.51f,0.8f,50.2f);//xxxxxxxxxxxxxxxxxxxxxxx
		if(player22!=cornertaker && player22.GetComponent<player>().sentoff==false)
			player22.transform.position=new Vector3(4.0f,0.8f,49.5f);
		if(player9opp!=cornertaker && player9opp.GetComponent<player2>().sentoff==false)
			player9opp.transform.position=new Vector3(2.0f,0.8f,49.9f);//xxxxxxxxxxxxxxxxxxxxxxxx
		if(player4!=cornertaker && player4.GetComponent<player>().sentoff==false)
			player4.transform.position=new Vector3(13.0f,0.8f,45.9f);
		if(player4opp!=cornertaker && player4opp.GetComponent<player2>().sentoff==false)
			player4opp.transform.position=new Vector3(5.0f,0.8f,42.9f);//xxxxxxxxxxxxxxxxxxxxxxxx
		if(player10!=cornertaker && player10.GetComponent<player>().sentoff==false)
			player10.transform.position=new Vector3(1.0f,0.8f,42.5f);
		if(player5opp!=cornertaker && player5opp.GetComponent<player2>().sentoff==false)
			player5opp.transform.position=new Vector3(-7.5f,0.8f,43.9f);
	}

	void  PositionPlayers2 (){
		keeper.transform.position=new Vector3( 0, 0.8f, -51.8f);
		if(player8opp!=cornertaker && player8opp.GetComponent<player2>().sentoff==false)
			player8opp.transform.position=new Vector3(-3.31f,0.8f,-44.7f);  //will change player positions later
		if(player8!=cornertaker && player8.GetComponent<player>().sentoff==false)
			player8.transform.position=new Vector3(-4.51f,0.8f,-44.9f);//xxxxxxxxxxxxxxxxxxxxxxx
		if(player2opp!=cornertaker && player2opp.GetComponent<player2>().sentoff==false)
			player2opp.transform.position=new Vector3(4.0f,0.8f,-44.5f);
		if(player9!=cornertaker && player9.GetComponent<player>().sentoff==false)
			player9.transform.position=new Vector3(2.0f,0.8f,-45.9f);//xxxxxxxxxxxxxxxxxxxxxxxx
		if(player4opp!=cornertaker && player4opp.GetComponent<player2>().sentoff==false)
			player4opp.transform.position=new Vector3(13.0f,0.8f,44.9f);
		if(player4!=cornertaker && player4.GetComponent<player>().sentoff==false)
			player4.transform.position=new Vector3(5.0f,0.8f,-37.9f);//xxxxxxxxxxxxxxxxxxxxxxxx
		if(player10opp!=cornertaker && player10opp.GetComponent<player2>().sentoff==false)
			player10opp.transform.position=new Vector3(1.0f,0.8f,42.5f);
		if(player5!=cornertaker && player5.GetComponent<player>().sentoff==false)
			player5.transform.position=new Vector3(-7.5f,0.8f,-37.9f);
	}


	void  CheckOffside (){
		/*furthest=player10opp;  //to the left
if(furthest.transform.position.z>player9opp.transform.position.z)
 furthest=player9opp;
 if(furthest.transform.position.z>player8opp.transform.position.z)
 furthest=player8opp;
 if(furthest.transform.position.z>player7opp.transform.position.z)
 furthest=player7opp;
 if(furthest.transform.position.z>player6opp.transform.position.z)
 furthest=player6opp;
 if(furthest.transform.position.z>player5opp.transform.position.z)
 furthest=player5opp;
 if(furthest.transform.position.z>player4opp.transform.position.z)
 furthest=player4opp;
 if(furthest.transform.position.z>player3opp.transform.position.z)
 furthest=player3opp;
 if(furthest.transform.position.z>player2opp.transform.position.z)
 furthest=player2opp;
 if(furthest.transform.position.z>player1opp.transform.position.z)
 furthest=player1opp;
 
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
furthest2=player10;
if(furthest2.transform.position.z<player9.transform.position.z)
 furthest2=player9;
 if(furthest2.transform.position.z<player8.transform.position.z)
 furthest2=player8;
 if(furthest2.transform.position.z<player7.transform.position.z)
 furthest2=player7;
 if(furthest2.transform.position.z<player6.transform.position.z)
 furthest2=player6;
 if(furthest2.transform.position.z<player5.transform.position.z)
 furthest2=player5;
 if(furthest2.transform.position.z<player4.transform.position.z)
 furthest2=player4;
 if(furthest2.transform.position.z<player3.transform.position.z)
 furthest2=player3;
 if(furthest2.transform.position.z<player22.transform.position.z)
 furthest2=player22;
 if(furthest2.transform.position.z<player1.transform.position.z)
 furthest2=player1;*/

	}

	void  ResetAnimations (){
		player1.GetComponent<Animation>().Play("idle");player22.GetComponent<Animation>().Play("idle");player3.GetComponent<Animation>().Play("idle");player4.GetComponent<Animation>().Play("idle");
		player5.GetComponent<Animation>().Play("idle");player6.GetComponent<Animation>().Play("idle");player7.GetComponent<Animation>().Play("idle");player8.GetComponent<Animation>().Play("idle");
		player9.GetComponent<Animation>().Play("idle");player10.GetComponent<Animation>().Play("idle");
		player1opp.GetComponent<Animation>().Play("idle");player2opp.GetComponent<Animation>().Play("idle");player3opp.GetComponent<Animation>().Play("idle");player4opp.GetComponent<Animation>().Play("idle");
		player5opp.GetComponent<Animation>().Play("idle");player6opp.GetComponent<Animation>().Play("idle");player7opp.GetComponent<Animation>().Play("idle");player8opp.GetComponent<Animation>().Play("idle");
		player9opp.GetComponent<Animation>().Play("idle");player10opp.GetComponent<Animation>().Play("idle");
	}

	void  ResetPlayers (){
		player1.GetComponent<player>().state="idle";player22.GetComponent<player>().state="idle";player3.GetComponent<player>().state="idle";
		player4.GetComponent<player>().state="idle";player5.GetComponent<player>().state="idle";player6.GetComponent<player>().state="idle";
		player7.GetComponent<player>().state="idle";player8.GetComponent<player>().state="idle";player9.GetComponent<player>().state="idle";
		player10.GetComponent<player>().state="idle";
		player1opp.GetComponent<player2>().state="idle";player2opp.GetComponent<player2>().state="idle";player3opp.GetComponent<player2>().state="idle";
		player4opp.GetComponent<player2>().state="idle";player5opp.GetComponent<player2>().state="idle";player6opp.GetComponent<player2>().state="idle";
		player7opp.GetComponent<player2>().state="idle";player8opp.GetComponent<player2>().state="idle";player9opp.GetComponent<player2>().state="idle";
		player10opp.GetComponent<player2>().state="idle";Ball.state="free";
	}

	public void  p1Goal (){
		global.p1goals+=1;p1goals=global.p1goals;p1score.GetComponent<Text>().text=p1goals.ToString();global.team1goals=global.p1goals;
		if(global.isaggregate)
		{global.team1aggregate+=1;Control.clubaggregate[global.team1]++;}
	}

	public void  p2Goal (){
		global.p2goals+=1;p2goals=global.p2goals;p2score.GetComponent<Text>().text=p2goals.ToString();global.team2goals=global.p2goals;
		if(global.isaggregate)
		{global.team2aggregate+=1;Control.clubaggregate[global.team2]++;
			if(global.Event=="championsleague")
			{global.awaygoals++;Control.clubawaygoals[global.team2]=global.awaygoals;}}
	}

	void  SecondHalf (){
		Time.timeScale=1.0f;
		menutimeout=0;
		minutes=46;
		halftimetalk.SetActive(false);
		Application.LoadLevel(Application.loadedLevel);
	}

	void  EndMatch (){
		Application.LoadLevel("dashboard");
	}

	void  CloseFoul (){
		player1.GetComponent<player>().foulprompt.SetActive(false);
		player22.GetComponent<player>().foulprompt.SetActive(false);
		player3.GetComponent<player>().foulprompt.SetActive(false);
		player4.GetComponent<player>().foulprompt.SetActive(false);
		player5.GetComponent<player>().foulprompt.SetActive(false);
		player6.GetComponent<player>().foulprompt.SetActive(false);
		player7.GetComponent<player>().foulprompt.SetActive(false);
		player8.GetComponent<player>().foulprompt.SetActive(false);
		player9.GetComponent<player>().foulprompt.SetActive(false);
		player10.GetComponent<player>().foulprompt.SetActive(false);
		bookedprompt.SetActive(false);
		sentoffprompt.SetActive(false);

		player1opp.GetComponent<player2>().foulprompt.SetActive(false);
		player2opp.GetComponent<player2>().foulprompt.SetActive(false);
		player3opp.GetComponent<player2>().foulprompt.SetActive(false);
		player4opp.GetComponent<player2>().foulprompt.SetActive(false);
		player5opp.GetComponent<player2>().foulprompt.SetActive(false);
		player6opp.GetComponent<player2>().foulprompt.SetActive(false);
		player7opp.GetComponent<player2>().foulprompt.SetActive(false);
		player8opp.GetComponent<player2>().foulprompt.SetActive(false);
		player9opp.GetComponent<player2>().foulprompt.SetActive(false);
		player10opp.GetComponent<player2>().foulprompt.SetActive(false);
	}

	void  LoadPlayerSkins (){

		if(keeper.GetComponent<goalkeeper>().skin==1)
		{keeper.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material.color=new Color(1.0f,0.6f,0.172f);}
		if(keeper.GetComponent<goalkeeper>().skin==2)
		{keeper.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material.color=new Color(0.5f,0.25f,0.0f);}

		if(keeper2.GetComponent<goalkeeper2>().skin==1)
		{keeper2.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material.color=new Color(1.0f,0.6f,0.172f);}
		if(keeper2.GetComponent<goalkeeper2>().skin==2)
		{keeper2.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material.color=new Color(0.5f,0.25f,0.0f);}
		GameObject playr=null;
		for(int i=1;i<=10;i++){ if(i==1){ playr=player1;} if(i==2) playr=player22; if(i==3) playr=player3;
			if(i==4) playr=player4; if(i==5) playr=player5; if(i==6) playr=player6; if(i==7) playr=player7;
			if(i==8) playr=player8; if(i==9) playr=player9; if(i==10) playr=player10;

			if(playr.GetComponent<player>().skin==1)
			{playr.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material=kitbrw;}
			if(playr.GetComponent<player>().skin==2)
			{playr.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material=kitblk;}
			if(global.category=="clubs"){
				if(Control.clubshirtpattern[global.team1]==1)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitcro;
				if(Control.clubshirtpattern[global.team1]==2)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitbar;
				if(Control.clubshirtpattern[global.team1]==3)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitarg;
				if(Control.clubshirtpattern[global.team1]==4)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitnew;
				if(Control.clubshirtpattern[global.team1]==5)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitast;
				if(Control.clubshirtpattern[global.team1]==6)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitars;
				if(Control.clubshirtpattern[global.team1]==7)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitsot;
				if(Control.clubshirtpattern[global.team1]==8)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitint;
				if(Control.clubshirtpattern[global.team1]==9)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitacm;
				if(Control.clubshirtpattern[global.team1]==10)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitdep;
				if(Control.clubshirtpattern[global.team1]==11)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kittun;
				if(Control.clubshirtpattern[global.team1]==12)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitval;///////////////////////////
				playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubshirt[global.team1];
				playr.transform.Find("shorts").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubshorts[global.team1];
				playr.transform.Find("socks").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubsocks[global.team1];
			}
			else{
				if(Control.shirtpattern[global.team1]==1)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitcro;
				if(Control.shirtpattern[global.team1]==2)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitbar;
				if(Control.shirtpattern[global.team1]==3)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitarg;
				if(Control.shirtpattern[global.team1]==4)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitnew;
				if(Control.shirtpattern[global.team1]==5)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitast;
				if(Control.shirtpattern[global.team1]==6)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitars;
				if(Control.shirtpattern[global.team1]==7)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitsot;
				if(Control.shirtpattern[global.team1]==8)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitint;
				if(Control.shirtpattern[global.team1]==9)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitacm;
				if(Control.shirtpattern[global.team1]==10)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitdep;
				if(Control.shirtpattern[global.team1]==11)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kittun;
				if(Control.shirtpattern[global.team1]==12)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitval;
				playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.shirt[global.team1];
				playr.transform.Find("shorts").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.shorts[global.team1];
				playr.transform.Find("socks").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.socks[global.team1];
			}

		}

		for(int i=1;i<=10;i++){ if(i==1) playr=player1opp; if(i==2) playr=player2opp; if(i==3) playr=player3opp;
			if(i==4) playr=player4opp; if(i==5) playr=player5opp; if(i==6) playr=player6opp; if(i==7) playr=player7opp;
			if(i==8) playr=player8opp; if(i==9) playr=player9opp; if(i==10) playr=player10opp;

			if(playr.GetComponent<player2>().skin==1)
			{playr.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material=kitbrw;}
			if(playr.GetComponent<player2>().skin==2)
			{playr.transform.Find("skin").GetComponent<SkinnedMeshRenderer>().material=kitblk;}
			if(global.category=="clubs"){
				if(Control.clubshirtpattern[global.team2]==1)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitcro;
				if(Control.clubshirtpattern[global.team2]==2)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitbar;
				if(Control.clubshirtpattern[global.team2]==3)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitarg;
				if(Control.clubshirtpattern[global.team2]==4)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitnew;
				if(Control.clubshirtpattern[global.team2]==5)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitast;
				if(Control.clubshirtpattern[global.team2]==6)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitars;
				if(Control.clubshirtpattern[global.team2]==7)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitsot;
				if(Control.clubshirtpattern[global.team2]==8)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitint;
				if(Control.clubshirtpattern[global.team2]==9)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitacm;
				if(Control.clubshirtpattern[global.team2]==10)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitdep;
				if(Control.clubshirtpattern[global.team2]==11)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kittun;
				if(Control.clubshirtpattern[global.team2]==12)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitval;///////////////////////////
				playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubshirt[global.team2];
				playr.transform.Find("shorts").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubshorts[global.team2];
				playr.transform.Find("socks").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.clubsocks[global.team2];
			}
			else{
				if(Control.shirtpattern[global.team2]==1)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitcro;
				if(Control.shirtpattern[global.team2]==2)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitbar;
				if(Control.shirtpattern[global.team2]==3)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitarg;
				if(Control.shirtpattern[global.team2]==4)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitnew;
				if(Control.shirtpattern[global.team2]==5)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitast;
				if(Control.shirtpattern[global.team2]==6)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitars;
				if(Control.shirtpattern[global.team2]==7)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitsot;
				if(Control.shirtpattern[global.team2]==8)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitint;
				if(Control.shirtpattern[global.team2]==9)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitacm;
				if(Control.shirtpattern[global.team2]==10)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitdep;
				if(Control.shirtpattern[global.team2]==11)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kittun;
				if(Control.shirtpattern[global.team2]==12)
					playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().material=kitval;
				playr.transform.Find("shirt").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.shirt[global.team2];
				playr.transform.Find("shorts").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.shorts[global.team2];
				playr.transform.Find("socks").GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().material.color=Control.socks[global.team2];
			}

		}  

	}

	void  LoadOwnPlayerAtts ( string team  ){
		var control=GameObject.Find("Control").GetComponent<Control>(); GameObject player0=null;
		if(team=="player1"){
			for(int i=11;i>=2;i--){
				if(i==2)
				{ player0=player10;}
				if(i==3)
					player0=player9;
				if(i==4)
					player0=player8;
				if(i==5)
					player0=player7;
				if(i==6)
					player0=player6;
				if(i==7)
					player0=player5;
				if(i==8)
					player0=player4;
				if(i==9)
					player0=player3;
				if(i==10)
					player0=player22;
				if(i==11)
					player0=player1;
				//control.player[i]=new Players();
				//player0.GetComponent<player>().id=control.player[i].id;
				player0.GetComponent<player>().playername=control.player[i].playername;
				player0.GetComponent<player>().skin=control.player[i].skin;
				player0.GetComponent<player>().accelerate=control.player[i].acceleration;
				player0.GetComponent<player>().aggression=control.player[i].aggression;
				player0.GetComponent<player>().agile=control.player[i].agility;
				player0.GetComponent<player>().balance=control.player[i].balance;
				player0.GetComponent<player>().control=control.player[i].ballcontrol;
				player0.GetComponent<player>().composure=control.player[i].composure;
				player0.GetComponent<player>().crossing=control.player[i].crossing;
				player0.GetComponent<player>().curve=control.player[i].curve;
				player0.GetComponent<player>().dribble=control.player[i].dribbling;
				player0.GetComponent<player>().accuracy=control.player[i].finishing;
				player0.GetComponent<player>().freekicks=control.player[i].freekicks;
				player0.GetComponent<player>().heading=control.player[i].heading;
				player0.GetComponent<player>().longshots=control.player[i].longshots;
				player0.GetComponent<player>().marking=control.player[i].marking;
				player0.GetComponent<player>().penalties=control.player[i].penalties;
				player0.GetComponent<player>().positioning=control.player[i].positioning;
				player0.GetComponent<player>().reaction=control.player[i].reactions;
				player0.GetComponent<player>().passes=control.player[i].passing;   //kisses mwah
				player0.GetComponent<player>().hotshot=control.player[i].hotshot;  //hot shit hot thing
				player0.GetComponent<player>().tackle=control.player[i].tackle;
				player0.GetComponent<player>().speedy=control.player[i].speed;
				player0.GetComponent<player>().stamina=control.player[i].stamina;
				player0.GetComponent<player>().strength=control.player[i].strength;
				player0.GetComponent<player>().jumping=control.player[i].jumping;
				player0.GetComponent<player>().vskeeper=control.player[i].vskeeper;
				player0.GetComponent<player>().play=control.player[i].play;
				player0.GetComponent<player>().wings=control.player[i].wings;
				player0.GetComponent<player>().longshoot=control.player[i].longshoot;
				player0.GetComponent<player>().tackles=control.player[i].tackling;
				player0.GetComponent<player>().passheight=control.player[i].passheight;
				player0.GetComponent<player>().rating=control.player[i].rating;
				player0.GetComponent<player>().determination=control.player[i].determination;
				player0.GetComponent<player>().consistency=control.player[i].consistency;
				//footballer[i].role;
				keeper.GetComponent<goalkeeper>().reflexes=control.player[1].reflexes;
				keeper.GetComponent<goalkeeper>().positioning=control.player[1].positioning;
				keeper.GetComponent<goalkeeper>().handling=control.player[1].handling;
				keeper.GetComponent<goalkeeper>().diving=control.player[1].diving;
				keeper.GetComponent<goalkeeper>().agility=control.player[1].agility;
				keeper.GetComponent<goalkeeper>().speedy=control.player[1].speed;
				keeper.GetComponent<goalkeeper>().control=control.player[1].ballcontrol;
				keeper.GetComponent<goalkeeper>().playername=control.player[1].playername;
				keeper.GetComponent<goalkeeper>().skin=control.player[1].skin;
			}
		}
		else{
			for(int i=11;i>=2;i--){
				if(i==2)
					player0=player10opp;
				if(i==3)
					player0=player9opp;
				if(i==4)
					player0=player8opp;
				if(i==5)
					player0=player7opp;
				if(i==6)
					player0=player6opp;
				if(i==7)
					player0=player5opp;
				if(i==8)
					player0=player4opp;
				if(i==9)
					player0=player3opp;
				if(i==10)
					player0=player2opp;
				if(i==11)
					player0=player1opp;
				//control.player[i]=new Players();
				//player0.GetComponent<player>().id=control.player[i].id;
				player0.GetComponent<player2>().playername=control.player[i].playername;
				player0.GetComponent<player2>().skin=control.player[i].skin;
				player0.GetComponent<player2>().accelerate=control.player[i].acceleration;
				player0.GetComponent<player2>().aggression=control.player[i].aggression;
				player0.GetComponent<player2>().agile=control.player[i].agility;
				player0.GetComponent<player2>().balance=control.player[i].balance;
				player0.GetComponent<player2>().control=control.player[i].ballcontrol;
				player0.GetComponent<player2>().composure=control.player[i].composure;
				player0.GetComponent<player2>().crossing=control.player[i].crossing;
				player0.GetComponent<player2>().curve=control.player[i].curve;
				player0.GetComponent<player2>().dribble=control.player[i].dribbling;
				player0.GetComponent<player2>().accuracy=control.player[i].finishing;
				player0.GetComponent<player2>().freekicks=control.player[i].freekicks;
				player0.GetComponent<player2>().heading=control.player[i].heading;
				player0.GetComponent<player2>().longshots=control.player[i].longshots;
				player0.GetComponent<player2>().marking=control.player[i].marking;
				player0.GetComponent<player2>().penalties=control.player[i].penalties;
				player0.GetComponent<player2>().positioning=control.player[i].positioning;
				player0.GetComponent<player2>().reaction=control.player[i].reactions;
				player0.GetComponent<player2>().passes=control.player[i].passing;   //kisses mwah
				player0.GetComponent<player2>().hotshot=control.player[i].hotshot;  //hot shit hot thing
				player0.GetComponent<player2>().tackle=control.player[i].tackle;
				player0.GetComponent<player2>().speedy=control.player[i].speed;
				player0.GetComponent<player2>().stamina=control.player[i].stamina;
				player0.GetComponent<player2>().strength=control.player[i].strength;
				player0.GetComponent<player2>().jumping=control.player[i].jumping;
				player0.GetComponent<player2>().vskeeper=control.player[i].vskeeper;
				player0.GetComponent<player2>().play=control.player[i].play;
				player0.GetComponent<player2>().wings=control.player[i].wings;
				player0.GetComponent<player2>().longshoot=control.player[i].longshoot;
				player0.GetComponent<player2>().tackles=control.player[i].tackling;
				player0.GetComponent<player2>().passheight=control.player[i].passheight;
				player0.GetComponent<player2>().rating=control.player[i].rating;
				player0.GetComponent<player2>().determination=control.player[i].determination;
				player0.GetComponent<player2>().consistency=control.player[i].consistency;
				//footballer[i].role;
				keeper2.GetComponent<goalkeeper2>().reflexes=control.player[1].reflexes;
				keeper2.GetComponent<goalkeeper2>().positioning=control.player[1].positioning;
				keeper2.GetComponent<goalkeeper2>().handling=control.player[1].handling;
				keeper2.GetComponent<goalkeeper2>().diving=control.player[1].diving;
				keeper2.GetComponent<goalkeeper2>().agility=control.player[1].agility;
				keeper2.GetComponent<goalkeeper2>().speedy=control.player[1].speed;
				keeper2.GetComponent<goalkeeper2>().control=control.player[1].ballcontrol;
				keeper2.GetComponent<goalkeeper2>().playername=control.player[1].playername;
				keeper2.GetComponent<goalkeeper2>().skin=control.player[1].skin;
			}
		}

	}

	void  LoadPlayerAtts ( string team  ){ var teamid=0;var max=0; var id=0; int[,] players;
		var control=GameObject.Find("Control").GetComponent<Control>();
		if(team=="player1")
		{ teamid=global.team1;}
		if(team=="player2")
		{ teamid=global.team2;}
		if(global.category=="clubs")
		{ players=Control.clubplayers; max=23;}
		else
		{players=Control.players;max=23;}
		int err=0;
		int i=0;bool stop=false; int k=1;
		string file = Application.dataPath + "/players";
		StreamReader reader = new StreamReader(file);
		reader.ReadLine();reader.ReadLine();
		while(i<18541 || stop==false){
			if(k>=24){reader.Close();return;}
			string piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxx
			if(piece==null && i==0){Debug.Log("read error ");i=0;k=1;reader.Close();file= Application.dataPath + "/players";reader = new StreamReader(file);error=true;
				reader.ReadLine();reader.ReadLine();err++;if(err>5)return;continue;}
			for(int j= 0;j < piece.Length; j++){
				if(piece[j]==':'){ id=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;   }     }
			bool has=false;
			for(int man=0;man<=22;man++)  
			{if(global.category=="clubs"){
					if(id==Control.clubplayers[teamid,man] && id!=0){has=true;break;}}
			else
			{if(id==Control.players[teamid,man] && id!=0){has=true;break;}}
		}
			if(has)   // id==players[teamid,k-1]
			{ if(team=="player1")
				{Player[k]=new players();Player[k].id=id;}
			else
			{Player2[k]=new players();Player2[k].id=id;}
			piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxx
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].playername=piece.Substring(j+4,piece.Length-(j+4)-2);
					else
						Player2[k].playername=piece.Substring(j+4,piece.Length-(j+4)-2);
					break;  }
					else
					{if(team=="player1")
						Player[k].playername=piece.Substring(j+3,piece.Length-(j+3)-2);
					else
						Player2[k].playername=piece.Substring(j+3,piece.Length-(j+3)-2);
					break;}   }     }
			reader.ReadLine();reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxx
			reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx

			reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxx
			reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx

			reader.ReadLine();
			reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx

			reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx

			reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
			reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx

			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxSKIN
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].skin=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].skin=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].skin=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].skin=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxacceleration
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].acceleration=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].acceleration=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].acceleration=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].acceleration=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxaggression
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].aggression=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].aggression=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].aggression=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].aggression=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxagility
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].agility=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].agility=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].agility=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].agility=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxbalance
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].balance=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].balance=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].balance=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].balance=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxballcontrol
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].ballcontrol=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].ballcontrol=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].ballcontrol=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].ballcontrol=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcomposure
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].composure=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].composure=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].composure=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].composure=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcrossing
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].crossing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].crossing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].crossing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].crossing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcurve
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].curve=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].curve=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].curve=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].curve=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdribbling
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].dribbling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].dribbling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].dribbling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].dribbling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfinishing
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].finishing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].finishing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].finishing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].finishing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfreekicks
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].freekicks=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].freekicks=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].freekicks=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].freekicks=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdiving
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].diving=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].diving=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].diving=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].diving=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhandling
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].handling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].handling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].handling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].handling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxkicking
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].kicking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].kicking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].kicking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].kicking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			reader.ReadLine();//xxxxxxxxxxxx
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreflexes
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].reflexes=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].reflexes=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].reflexes=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].reflexes=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxHEADER
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].heading=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].heading=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].heading=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].heading=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			reader.ReadLine();//skip interceptions
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxjumping
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].jumping=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].jumping=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].jumping=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].jumping=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			reader.ReadLine();
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxlongshots
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].longshots=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].longshots=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].longshots=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].longshots=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxmarking
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].marking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].marking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].marking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].marking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpenalties
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].penalties=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].penalties=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].penalties=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].penalties=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpositioning
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].positioning=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].positioning=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].positioning=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].positioning=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreactions
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].reactions=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].reactions=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].reactions=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].reactions=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpassing
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].passing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].passing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].passing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].passing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhotshot
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].hotshot=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].hotshot=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].hotshot=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
					{Player2[k].hotshot=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));}
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxtackle
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].tackle=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].tackle=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].tackle=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].tackle=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxspeed
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].speed=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].speed=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].speed=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].speed=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstamina
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].stamina=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].stamina=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].stamina=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].stamina=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			reader.ReadLine();
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstrength
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].strength=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].strength=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].strength=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].strength=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxDETERMINATION
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].determination=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					else
						Player2[k].determination=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));
					break;  }
					else
					{if(team=="player1")
						Player[k].determination=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					else
						Player2[k].determination=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));
					break;}   }     }
			for(int o=1;o<=17;o++)
				reader.ReadLine();//xxxxxxxxxxxxxxxxxxx
			piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxrole
			for(int j = 0;j < piece.Length; j++){
				if(piece[j]==':'){
					if(piece[j+2]==' ')
					{if(team=="player1")
						Player[k].role=piece.Substring(j+4,piece.Length-(j+4)-2);
					else
						Player2[k].role=piece.Substring(j+4,piece.Length-(j+4)-2);
					break;  } //position "CF" "GK"
					else
					{if(team=="player1")
						Player[k].role=piece.Substring(j+3,piece.Length-(j+3)-2);
					else
						Player2[k].role=piece.Substring(j+3,piece.Length-(j+3)-2);
					break;}   }     }
			if(k==23){stop=true;reader.Close();break;}
			;k++;if(players[teamid,k-1]==-1 || k>max){stop=true;reader.Close();break;}
			for(int o=1;o<=13;o++)
			{ reader.ReadLine();if(reader.EndOfStream || i==18540)stop=true;}}//correct id
			else
			{for(int o=1;o<=76;o++)
				{reader.ReadLine();if(reader.EndOfStream || i==18540)stop=true;}} //search on to next id
			i++;                    
		}
		reader.Close();

		if(team=="player1"){
			int[] men=new int[23];
			if(global.category=="clubs"){
				for(int o=0;o<max;o++)
					men[o]=Control.clubplayers[teamid,o];}
			else{
				for(int o=0;o<max;o++)
					men[o]=Control.players[teamid,o];}

			GameObject player0=null;
			for(int j=0;j<11;j++ )//position
			{ 
				if(j==1)
				{ player0=player10;}
				if(j==2)
					player0=player9;
				if(j==3)
					player0=player8;
				if(j==4)
					player0=player7;
				if(j==5)
					player0=player6;
				if(j==6)
					player0=player5;
				if(j==7)
					player0=player4;
				if(j==8)
					player0=player3;
				if(j==9)
					player0=player22;
				if(j==10)
					player0=player1;

				for(int l=1;l<=max;l++){ //iterate unordered players

					if(Player[l].id==men[j] && j!=0)  //reorder player in orderly fashion
					{
						player0.GetComponent<player>().playername=Player[l].playername;
						player0.GetComponent<player>().skin=Player[l].skin;
						player0.GetComponent<player>().accelerate=Player[l].acceleration;
						player0.GetComponent<player>().aggression=Player[l].aggression;
						player0.GetComponent<player>().agile=Player[l].agility;
						player0.GetComponent<player>().balance=Player[l].balance;
						player0.GetComponent<player>().control=Player[l].ballcontrol;
						player0.GetComponent<player>().composure=Player[l].composure;
						player0.GetComponent<player>().crossing=Player[l].crossing;
						player0.GetComponent<player>().curve=Player[l].curve;
						player0.GetComponent<player>().dribble=Player[l].dribbling;
						player0.GetComponent<player>().accuracy=Player[l].finishing;
						player0.GetComponent<player>().freekicks=Player[l].freekicks;
						player0.GetComponent<player>().heading=Player[l].heading;
						player0.GetComponent<player>().longshots=Player[l].longshots;
						player0.GetComponent<player>().marking=Player[l].marking;
						player0.GetComponent<player>().penalties=Player[l].penalties;
						player0.GetComponent<player>().positioning=Player[l].positioning;
						player0.GetComponent<player>().reaction=Player[l].reactions;
						player0.GetComponent<player>().passes=Player[l].passing;   //kisses mwah
						player0.GetComponent<player>().hotshot=Player[l].hotshot;  //hot shit hot thing
						player0.GetComponent<player>().tackle=Player[l].tackle;
						player0.GetComponent<player>().speedy=Player[l].speed;
						player0.GetComponent<player>().stamina=Player[l].stamina;
						player0.GetComponent<player>().strength=Player[l].strength;
						player0.GetComponent<player>().jumping=Player[l].jumping;
						//footballer[i].role;
					}
					if(Player[l].id==men[0])  //reorder player in orderly fashion
					{  
						keeper.GetComponent<goalkeeper>().playername=Player[l].playername;
						keeper.GetComponent<goalkeeper>().reflexes=Player[l].reflexes;
						keeper.GetComponent<goalkeeper>().positioning=Player[l].positioning;
						keeper.GetComponent<goalkeeper>().handling=Player[l].handling;
						keeper.GetComponent<goalkeeper>().diving=Player[l].diving;
						keeper.GetComponent<goalkeeper>().agility=Player[l].agility;
						keeper.GetComponent<goalkeeper>().speedy=Player[l].speed;
						keeper.GetComponent<goalkeeper>().control=Player[l].ballcontrol;
						keeper.GetComponent<goalkeeper>().skin=Player[l].skin;
					}
				} 

			}


		}
		else{ //player2
			GameObject player0=null;
			int[] men=new int[23];
			if(global.category=="clubs"){
				for(int o=0;o<max;o++)
					men[o]=Control.clubplayers[teamid,o];}
			else{
				for(int o=0;o<max;o++)
				{men[o]=Control.players[teamid,o];}}

			for(int j=0;j<11;j++ )//position
			{
				if(j==1)
					player0=player10opp;
				if(j==2)
					player0=player9opp;
				if(j==3)
					player0=player8opp;
				if(j==4)
					player0=player7opp;
				if(j==5)
					player0=player6opp;
				if(j==6)
					player0=player5opp;
				if(j==7)
					player0=player4opp;
				if(j==8)
					player0=player3opp;
				if(j==9)
					player0=player2opp;
				if(j==10)
					player0=player1opp;

				for(int l=1;l<=max;l++){ //iterate unordered players

					if(Player2[l].id==men[j] && j!=0)  //reorder player in orderly fashion
					{
						player0.GetComponent<player2>().playername=Player2[l].playername;
						player0.GetComponent<player2>().skin=Player2[l].skin;
						player0.GetComponent<player2>().accelerate=Player2[l].acceleration;
						player0.GetComponent<player2>().aggression=Player2[l].aggression;
						player0.GetComponent<player2>().agile=Player2[l].agility;
						player0.GetComponent<player2>().balance=Player2[l].balance;
						player0.GetComponent<player2>().control=Player2[l].ballcontrol;
						player0.GetComponent<player2>().composure=Player2[l].composure;
						player0.GetComponent<player2>().crossing=Player2[l].crossing;
						player0.GetComponent<player2>().curve=Player2[l].curve;
						player0.GetComponent<player2>().dribble=Player2[l].dribbling;
						player0.GetComponent<player2>().accuracy=Player2[l].finishing;
						player0.GetComponent<player2>().freekicks=Player2[l].freekicks;
						player0.GetComponent<player2>().heading=Player2[l].heading;
						player0.GetComponent<player2>().longshots=Player2[l].longshots;
						player0.GetComponent<player2>().marking=Player2[l].marking;
						player0.GetComponent<player2>().penalties=Player2[l].penalties;
						player0.GetComponent<player2>().positioning=Player2[l].positioning;
						player0.GetComponent<player2>().reaction=Player2[l].reactions;
						player0.GetComponent<player2>().passes=Player2[l].passing;   //kisses mwah
						player0.GetComponent<player2>().hotshot=Player2[l].hotshot;  //hot shit hot thing
						player0.GetComponent<player2>().tackle=Player2[l].tackle;
						player0.GetComponent<player2>().speedy=Player2[l].speed;
						player0.GetComponent<player2>().stamina=Player2[l].stamina;
						player0.GetComponent<player2>().strength=Player2[l].strength;
						player0.GetComponent<player2>().jumping=Player2[l].jumping;}
					//footballer[i].role;
					if(Player2[l].id==men[0])  //reorder player in orderly fashion
					{ 
						keeper2.GetComponent<goalkeeper2>().playername=Player2[l].playername;
						keeper2.GetComponent<goalkeeper2>().reflexes=Player2[l].reflexes;
						keeper2.GetComponent<goalkeeper2>().positioning=Player2[l].positioning;
						keeper2.GetComponent<goalkeeper2>().handling=Player2[l].handling;
						keeper2.GetComponent<goalkeeper2>().diving=Player2[l].diving;
						keeper2.GetComponent<goalkeeper2>().agility=Player2[l].agility;
						keeper2.GetComponent<goalkeeper2>().speedy=Player2[l].speed;
						keeper2.GetComponent<goalkeeper2>().control=Player2[l].ballcontrol; 
						keeper2.GetComponent<goalkeeper2>().skin=Player2[l].skin;
					}
				}
			}
		}//else
	}

	void  CheckSentoffs (){
		if(global.p1sentoff)
		{player1.GetComponent<player>().state="inactive";player1.transform.position=new Vector3(-100,0,0);}
		if(global.p2sentoff)
		{player22.GetComponent<player>().state="inactive";player22.transform.position=new Vector3(-100,0,0);}
		if(global.p3sentoff)
		{player3.GetComponent<player>().state="inactive";player3.transform.position=new Vector3(-100,0,0);}
		if(global.p4sentoff)
		{player4.GetComponent<player>().state="inactive";player4.transform.position=new Vector3(-100,0,0);}
		if(global.p5sentoff)
		{player5.GetComponent<player>().state="inactive";player5.transform.position=new Vector3(-100,0,0);}
		if(global.p6sentoff)
		{player6.GetComponent<player>().state="inactive";player6.transform.position=new Vector3(-100,0,0);}
		if(global.p7sentoff)
		{player7.GetComponent<player>().state="inactive";player7.transform.position=new Vector3(-100,0,0);}
		if(global.p8sentoff)
		{player8.GetComponent<player>().state="inactive";player8.transform.position=new Vector3(-100,0,0);}
		if(global.p9sentoff)
		{player9.GetComponent<player>().state="inactive";player9.transform.position=new Vector3(-100,0,0);}
		if(global.p10sentoff)
		{player10.GetComponent<player>().state="inactive";player10.transform.position=new Vector3(-100,0,0);}
		if(global.p11sentoff)
		{player1opp.GetComponent<player2>().state="inactive";player1opp.transform.position=new Vector3(-100,0,0);}
		if(global.p22sentoff)
		{player2opp.GetComponent<player2>().state="inactive";player2opp.transform.position=new Vector3(-100,0,0);}
		if(global.p33sentoff)
		{player3opp.GetComponent<player2>().state="inactive";player3opp.transform.position=new Vector3(-100,0,0);}
		if(global.p44sentoff)
		{player4opp.GetComponent<player2>().state="inactive";player4opp.transform.position=new Vector3(-100,0,0);}
		if(global.p55sentoff)
		{player5opp.GetComponent<player2>().state="inactive";player5opp.transform.position=new Vector3(-100,0,0);}
		if(global.p66sentoff)
		{player6opp.GetComponent<player2>().state="inactive";player6opp.transform.position=new Vector3(-100,0,0);}
		if(global.p77sentoff)
		{player7opp.GetComponent<player2>().state="inactive";player7opp.transform.position=new Vector3(-100,0,0);}
		if(global.p88sentoff)
		{player8opp.GetComponent<player2>().state="inactive";player8opp.transform.position=new Vector3(-100,0,0);}
		if(global.p99sentoff)
		{player9opp.GetComponent<player2>().state="inactive";player9opp.transform.position=new Vector3(-100,0,0);}
		if(global.p1010sentoff)
		{player10opp.GetComponent<player2>().state="inactive";player10opp.transform.position=new Vector3(-100,0,0);}
	}

	void  SetupPenalties (){
		if(penaltytimeout==0){ penaltyturn=1;
			global.p1sentoff=false;
			global. p2sentoff=false;
			global.p3sentoff=false;
			global.p4sentoff=false;
			global. p5sentoff=false;
			global. p6sentoff=false;
			global. p7sentoff=false;
			global. p8sentoff=false;
			global. p9sentoff=false;
			global. p10sentoff=false;
			global. p11sentoff=false;
			global. p22sentoff=false;
			global.p33sentoff=false;
			global.p44sentoff=false;
			global. p55sentoff=false;
			global. p66sentoff=false;
			global.p77sentoff=false;
			global. p88sentoff=false;
			global. p99sentoff=false;
			global. p1010sentoff=false;
			if(global.category=="clubs"){
				Penaltyscore.transform.Find("penateam1").GetComponent<Text>().text=Control.clubname[global.team1];
				Penaltyscore.transform.Find("penateam2").GetComponent<Text>().text=Control.clubname[global.team2];}
			else{
				Penaltyscore.transform.Find("penateam1").GetComponent<Text>().text=Control.countryname[global.team1];
				Penaltyscore.transform.Find("penateam2").GetComponent<Text>().text=Control.countryname[global.team2];}
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
			ball.transform.position=spot.transform.position;Time.timeScale=0.0f;penaltytimeout++;
			GameObject.Find("Main Camera").transform.LookAt(ball.transform);
			keeper2.transform.position=kposopp.transform.position;
			keeper2.transform.LookAt(ball.transform);
			player1.transform.position=spot.transform.position-Vector3.forward*3;
			player1.transform.LookAt(ball.transform) ;
			keeper2.GetComponent<Animation>().Play("idle");
			keeper.GetComponent<goalkeeper>().state="idle";keeper.GetComponent<goalkeeper>().acting=false;
			keeper2.GetComponent<goalkeeper2>().state="idle";keeper2.GetComponent<goalkeeper2>().acting=false;
			player1.GetComponent<Animation>().Play("idle");
			player22.transform.position=new Vector3(-5,0.8f,23);//set up other players to line up on field
			var ortx=transform.eulerAngles.x; var ortz=transform.eulerAngles.z;
			player22.GetComponent<Animation>().Play("idle");player22.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player3.transform.position=new Vector3(-4,0.8f,23);
			player3.GetComponent<Animation>().Play("idle");player3.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player4.transform.position=new Vector3(-3,0.8f,23);
			player4.GetComponent<Animation>().Play("idle");player4.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player5.transform.position=new Vector3(-2,0.8f,23);
			player5.GetComponent<Animation>().Play("idle");player5.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player6.transform.position=new Vector3(-1,0.8f,23);
			player6.GetComponent<Animation>().Play("idle");player6.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player7.transform.position=new Vector3(0,0.8f,23);
			player7.GetComponent<Animation>().Play("idle");player7.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player8.transform.position=new Vector3(1,0.8f,23);
			player8.GetComponent<Animation>().Play("idle");player8.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player9.transform.position=new Vector3(2,0.8f,23);
			player9.GetComponent<Animation>().Play("idle");player9.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player10.transform.position=new Vector3(3,0.8f,23);
			player10.GetComponent<Animation>().Play("idle");player10.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player1opp.transform.position=new Vector3(4,0.8f,23);
			player1opp.GetComponent<Animation>().Play("idle");player1opp.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player2opp.transform.position=new Vector3(5,0.8f,23);
			player2opp.GetComponent<Animation>().Play("idle");player2opp.transform.eulerAngles=new Vector3(ortx,0,ortz);
			player3opp.transform.position=new Vector3(6,0.8f,23);player3opp.GetComponent<Animation>().Play("idle");player3opp.transform.eulerAngles=new Vector3(player3opp.transform.eulerAngles.x,0,player3opp.transform.eulerAngles.z);
			player4opp.transform.position=new Vector3(7,0.8f,23);player4opp.GetComponent<Animation>().Play("idle");player4opp.transform.eulerAngles=new Vector3(player3opp.transform.eulerAngles.x,0,player3opp.transform.eulerAngles.z);;
			player5opp.transform.position=new Vector3(8,0.8f,23);player5opp.GetComponent<Animation>().Play("idle");player5opp.transform.eulerAngles=new Vector3(player3opp.transform.eulerAngles.x,0,player3opp.transform.eulerAngles.z);;
			player6opp.transform.position=new Vector3(9,0.8f,23);player6opp.GetComponent<Animation>().Play("idle");player6opp.transform.eulerAngles=new Vector3(player3opp.transform.eulerAngles.x,0,player3opp.transform.eulerAngles.z);;
			player7opp.transform.position=new Vector3(10,0.8f,23);player7opp.GetComponent<Animation>().Play("idle");
			player8opp.transform.position=new Vector3(11,0.8f,23);player8opp.GetComponent<Animation>().Play("idle");
			player9opp.transform.position=new Vector3(12,0.8f,23);player9opp.GetComponent<Animation>().Play("idle");
			player10opp.transform.position=new Vector3(13,0.8f,23);player10opp.GetComponent<Animation>().Play("idle");
		}//0
		if(penaltytimeout<120)
			penaltytimeout++;
		if(penaltytimeout==119){
			penaltytimer+=Time.deltaTime;Time.timeScale=1.0f;  //run
			player1.transform.Translate(Vector3.forward*0.05f);

		}
		if(penaltytimeout==120){  //player run
			penaltytimer+=Time.deltaTime;
			if(penaltytimer<0.4f){
				player1.transform.Translate(Vector3.forward*0.05f);
				if(!player1.GetComponent<Animation>().IsPlaying("run"))player1.GetComponent<Animation>().Play("run");}

			if(penaltytimer>=0.4f && penaltytimer<=0.4f+Time.deltaTime){
				player1.GetComponent<Animation>().Play("kick");kick.Play();player1.GetComponent<player>().PenaltyShoot(); }//kick
			if(penaltytimer>=1.0f && penaltytimer<=1.0f+Time.deltaTime)
				player1.GetComponent<Animation>().Play("idle");

			if(penaltytimer>=3.0f){
				Time.timeScale=0.0f;penaltytimer=0.0f;penaltytimeout++;//proceed to check score
				player1.transform.position=new Vector3(-6,0.8f,23);
			}
		}
		//if(penaltytimeout==122) 
		// Debug.Log("scored1? "+scored);
		//Debug.Log(penaltytimeout+" s "+scored);
		if(penaltytimeout>120 && penaltytimeout<123) //timeout until next taker 
			penaltytimeout++;
		if(penaltytimeout==122){//check scores
			if(suddendeath==false){ 
				if(scored==true)
					penaltyscoregrid1[penaltyrotation]=1;
				else
					penaltyscoregrid1[penaltyrotation]=0;} }
		//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
		//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		//Debug.Log(penaltytimeout);

		if(penaltytimeout==123){ //   next taker swap side wait a bit

			cheer.Stop();
			if(penaltyrotation==1)
			{taker1=player22;
				taker2=player1opp;}
			if(penaltyrotation==2)
			{taker1=player3;
				taker2=player2opp;}
			if(penaltyrotation==3)
			{taker1=player4;
				taker2=player3opp;}
			if(penaltyrotation==4)
			{taker1=player5;
				taker2=player4opp;}
			if(penaltyrotation==5)
			{taker2=player5opp;
				taker1=player1;} 

			penaltyturn=2;  //Time.timeScale=0.0f;
			keeper2.transform.position=new Vector3(0,0.8f,-50);
			keeper2.GetComponent<goalkeeper2>().state="idle";keeper2.GetComponent<goalkeeper2>().acting=false;
			Ball.hit=false;
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;  penaltytimer=0.0f; //reset timer
			ball.transform.position=spot.transform.position; scored=false;
			keeper.transform.position=kposopp.transform.position;
			keeper.transform.LookAt(ball.transform);
			taker2.transform.position=spot.transform.position-Vector3.forward*3.5f;
			taker2.transform.LookAt(ball.transform) ;
			keeper.GetComponent<Animation>().Play("idle");
			taker2.GetComponent<Animation>().Play("idle"); penaltytimeout++;
		}//123
		if(penaltytimeout>123 && penaltytimeout<200)
			penaltytimeout++;

		if(penaltytimeout==199)
			Time.timeScale=1.0f;

		if(penaltytimeout==200){  //f219    
			penaltytimer+=Time.deltaTime;  //taker 2 RUN to shoot
			if(penaltytimer<=0.4f){
				taker2.transform.Translate(Vector3.forward*0.05f);
				if(!player1.GetComponent<Animation>().IsPlaying("run"))
					taker2.GetComponent<Animation>().Play("run");}

			if(penaltytimer>=0.4f && penaltytimer<=0.4f+Time.deltaTime){   //KICK
				taker2.GetComponent<Animation>().Play("kick");kick.Play();taker2.GetComponent<player2>().PenaltyShoot();  }

			if(penaltytimer>=1.0f && penaltytimer<=1.0f+Time.deltaTime)
				taker2.GetComponent<Animation>().Play("idle");
			if(penaltytimer>=3.0f){
				Time.timeScale=0.0f;penaltytimer=0.0f;penaltytimeout++;//wait then proceed to check score
			}
		}//200

		//if(penaltytimeout>300 && penaltytimeout<380){  //wait a bit

		//}//301
		/* if(penaltytimeout==301){//check scores
       if(suddendeath==false ){
       if(scorred==true)
         penaltyscoregrid1[penaltyrotation]=1;
         else
         penaltyscoregrid1[penaltyrotation]=0;} }*/       
		if(penaltytimeout>200 && penaltytimeout<270) //timeout until next taker
			penaltytimeout++;
		//if(penaltytimeout==202) 
		//Debug.Log("scored2? "+scored);
		if(penaltytimeout==202){ //check scores
			cheer.Stop();
			if(suddendeath==false ){
				if(scored==true)
					penaltyscoregrid2[penaltyrotation]=1;
				else
					penaltyscoregrid2[penaltyrotation]=0;}
			else{  //check sudden death scored
				if(suddendeath1>suddendeath2){global.kickedoff=false; global.penalties=false;
					global.winner=global.team1;Application.LoadLevel("dashboard");
				}
				if(suddendeath1<suddendeath2){global.kickedoff=false; global.penalties=false;
					global.winner=global.team2;Application.LoadLevel("dashboard");
				}
				if(suddendeath1==suddendeath2){
					suddendeath1=0;suddendeath2=0;
				}
			}//sd
		}
		//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

		if(penaltytimeout==270){ //   next taker swap side wait a bit
			penaltyrotation++;
			if(penaltyrotation==6)  //reached full round of normat 5 shootouts
			{
				if(penaltyScore1>penaltyScore2){ global.kickedoff=false;   global.penalties=false;                //check final scores
					global.winner=global.team1;Application.LoadLevel("dashboard");}
				if(penaltyScore1<penaltyScore2){  global.kickedoff=false;  global.penalties=false;                //check final scores
					global.winner=global.team2;Application.LoadLevel("dashboard");}
				if(penaltyScore1==penaltyScore2){
					penaltyrotation=1;suddendeath=true;}}

			penaltyturn=1;  Time.timeScale=0.0f; int v=0;
			keeper.transform.position=new Vector3(0,0.8f,-50);
			keeper.GetComponent<goalkeeper>().state="idle";keeper.GetComponent<goalkeeper>().acting=false;
			if(taker2.name=="playeropp"){ v=4;}if(taker2.name=="player2opp"){ v=5;}if(taker2.name=="player3opp"){ v=6;}
			if(taker2.name=="player4opp"){ v=7;}if(taker2.name=="player5opp"){ v=8;}if(taker2.name=="player6opp"){ v=9;}if(taker2.name=="player7opp"){ v=10;}
			taker2.transform.position=new Vector3(v,0.8f,23);
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;  penaltytimer=0.0f; //reset timer
			ball.transform.position=spot.transform.position;Time.timeScale=0.0f;
			Ball.hit=false; scored=false;
			keeper2.transform.position=kposopp.transform.position;
			keeper2.transform.LookAt(ball.transform);
			taker1.transform.position=spot.transform.position-Vector3.forward*3.5f;
			taker1.transform.LookAt(ball.transform) ; penaltytimeout++;
			keeper2.GetComponent<Animation>().Play("idle");
			taker1.GetComponent<Animation>().Play("idle");
		}//270

		if(penaltytimeout>270 && penaltytimeout<300)
			penaltytimeout++;

		if(penaltytimeout==299){    
			Time.timeScale=1.0f;penaltytimer+=Time.deltaTime;
			taker1.transform.Translate(Vector3.forward*0.05f);taker1.GetComponent<Animation>().Play("run");}

		if(penaltytimeout==300){
			penaltytimer+=Time.deltaTime;

			if(penaltytimer<0.5f )
				taker1.transform.Translate(Vector3.forward*0.05f);

			if(penaltytimer>=0.5f && penaltytimer<=0.5f+Time.deltaTime){
				taker1.GetComponent<Animation>().Play("kick");kick.Play();taker1.GetComponent<player>().PenaltyShoot();}

			if(penaltytimer>=1.0f && penaltytimer<=1.0f+Time.deltaTime)
				taker1.GetComponent<Animation>().Play("idle");

			if(penaltytimer>=3.0f){
				Time.timeScale=0.0f;penaltytimer=0.0f;penaltytimeout++;}     
		}//300

		if(penaltytimeout>300 && penaltytimeout<360) //timeout until next taker
			penaltytimeout++;

		//if(penaltytimeout==302) 
		//Debug.Log("scored1? "+scored);
		if(penaltytimeout==302){ //check scores
			if(suddendeath==false ){
				if(scored==true)
					penaltyscoregrid1[penaltyrotation]=1;
				else
					penaltyscoregrid1[penaltyrotation]=0;}
		}
		if(penaltytimeout==360)
		{var v=0; if(taker1.name=="player"){ v=-6;}if(taker1.name=="player2"){ v=-5;}if(taker1.name=="player3"){ v=-4;}
			if(taker1.name=="player4"){ v=-3;}if(taker1.name=="player5"){ v=-2;}if(taker1.name=="player6"){ v=-1;}if(taker1.name=="player7"){ v=0;}
			taker1.transform.position=new Vector3(v,0.8f,23);
			penaltytimeout=123;}//back to the start loop

	}
	/////xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	void  RepositionPlayers (){
		player1.transform.position=op1pos;player22.transform.position=op2pos;player3.transform.position=op3pos;player4.transform.position=op4pos;
		player5.transform.position=op5pos;player6.transform.position=op6pos;player7.transform.position=op7pos;player8.transform.position=op8pos;
		player9.transform.position=op9pos;player10.transform.position=op10pos;
		player1opp.transform.position=op1oppos;player2opp.transform.position=op2oppos;player3opp.transform.position=op3oppos;player4opp.transform.position=op4oppos;
		player5opp.transform.position=op5oppos;player6opp.transform.position=op6oppos;player7opp.transform.position=op7oppos;player8opp.transform.position=op8oppos;
		player9opp.transform.position=op9oppos;player10opp.transform.position=op10oppos;
	}

	void  CheckErrors (){
		if(posession==1 && Ball.state=="posessed" && player1.GetComponent<player>().state=="idle" && player22.GetComponent<player>().state=="idle" &&
			player3.GetComponent<player>().state=="idle" && player4.GetComponent<player>().state=="idle" &&player5.GetComponent<player>().state=="idle" && 
			player6.GetComponent<player>().state=="idle" && player7.GetComponent<player>().state=="idle" && player8.GetComponent<player>().state=="idle" &&
			player9.GetComponent<player>().state=="idle" && player10.GetComponent<player>().state=="idle" )
		{posession=0;Ball.state="free";}
		if(posession==2 && Ball.state=="posessed" && player1opp.GetComponent<player2>().state=="idle" && player2opp.GetComponent<player2>().state=="idle" &&
			player3opp.GetComponent<player2>().state=="idle" && player4opp.GetComponent<player2>().state=="idle" &&player5opp.GetComponent<player2>().state=="idle" && 
			player6opp.GetComponent<player2>().state=="idle" && player7opp.GetComponent<player2>().state=="idle" && player8opp.GetComponent<player2>().state=="idle" &&
			player9opp.GetComponent<player2>().state=="idle" && player10opp.GetComponent<player2>().state=="idle" )
		{posession=0;Ball.state="free";}
	}

	void  SetFormation ( string team  ){  //set AI team formations

		if(team=="player1"){
			if(global.category=="clubs"){
				if(Control.clubformation[global.team1]==433){
					p1pos.position=GameObject.Find("p1pos433").transform.position;
					p2pos.position=GameObject.Find("p2pos433").transform.position;
					p3pos.position=GameObject.Find("p3pos433").transform.position;
					p4pos.position=GameObject.Find("p4pos433").transform.position;
					p5pos.position=GameObject.Find("p5pos433").transform.position;
					p6pos.position=GameObject.Find("p6pos433").transform.position;
					p7pos.position=GameObject.Find("p7pos433").transform.position;
					p8pos.position=GameObject.Find("p8pos433").transform.position;
					p9pos.position=GameObject.Find("p9pos433").transform.position;
					p10pos.position=GameObject.Find("p10pos433").transform.position;
				}//433
				if(Control.clubformation[global.team1]==541){
					p1pos.position=GameObject.Find("p1pos541").transform.position;
					p2pos.position=GameObject.Find("p2pos541").transform.position;
					p3pos.position=GameObject.Find("p3pos541").transform.position;
					p4pos.position=GameObject.Find("p4pos541").transform.position;
					p5pos.position=GameObject.Find("p5pos541").transform.position;
					p6pos.position=GameObject.Find("p6pos541").transform.position;
					p7pos.position=GameObject.Find("p7pos541").transform.position;
					p8pos.position=GameObject.Find("p8pos541").transform.position;
					p9pos.position=GameObject.Find("p9pos541").transform.position;
					p10pos.position=GameObject.Find("p10pos541").transform.position;
				}//541
				if(Control.clubformation[global.team1]==352){
					p1pos.position=GameObject.Find("p1pos352").transform.position;
					p2pos.position=GameObject.Find("p2pos352").transform.position;
					p3pos.position=GameObject.Find("p3pos352").transform.position;
					p4pos.position=GameObject.Find("p4pos352").transform.position;
					p5pos.position=GameObject.Find("p5pos352").transform.position;
					p6pos.position=GameObject.Find("p6pos352").transform.position;
					p7pos.position=GameObject.Find("p7pos352").transform.position;
					p8pos.position=GameObject.Find("p8pos352").transform.position;
					p9pos.position=GameObject.Find("p9pos352").transform.position;
					p10pos.position=GameObject.Find("p10pos352").transform.position;
				}//352

			}
			else{
				if(Control.formation[global.team2]==433){
					p1pos.position=GameObject.Find("p1pos433").transform.position;
					p2pos.position=GameObject.Find("p2pos433").transform.position;
					p3pos.position=GameObject.Find("p3pos433").transform.position;
					p4pos.position=GameObject.Find("p4pos433").transform.position;
					p5pos.position=GameObject.Find("p5pos433").transform.position;
					p6pos.position=GameObject.Find("p6pos433").transform.position;
					p7pos.position=GameObject.Find("p7pos433").transform.position;
					p8pos.position=GameObject.Find("p8pos433").transform.position;
					p9pos.position=GameObject.Find("p9pos433").transform.position;
					p10pos.position=GameObject.Find("p10pos433").transform.position;
				}//433
				if(Control.formation[global.team2]==541){
					p1pos.position=GameObject.Find("p1pos541").transform.position;
					p2pos.position=GameObject.Find("p2pos541").transform.position;
					p3pos.position=GameObject.Find("p3pos541").transform.position;
					p4pos.position=GameObject.Find("p4pos541").transform.position;
					p5pos.position=GameObject.Find("p5pos541").transform.position;
					p6pos.position=GameObject.Find("p6pos541").transform.position;
					p7pos.position=GameObject.Find("p7pos541").transform.position;
					p8pos.position=GameObject.Find("p8pos541").transform.position;
					p9pos.position=GameObject.Find("p9pos541").transform.position;
					p10pos.position=GameObject.Find("p10pos541").transform.position;
				}//541
				if(Control.formation[global.team2]==352){
					p1pos.position=GameObject.Find("p1pos352").transform.position;
					p2pos.position=GameObject.Find("p2pos352").transform.position;
					p3pos.position=GameObject.Find("p3pos352").transform.position;
					p4pos.position=GameObject.Find("p4pos352").transform.position;
					p5pos.position=GameObject.Find("p5pos352").transform.position;
					p6pos.position=GameObject.Find("p6pos352").transform.position;
					p7pos.position=GameObject.Find("p7pos352").transform.position;
					p8pos.position=GameObject.Find("p8pos352").transform.position;
					p9pos.position=GameObject.Find("p9pos352").transform.position;
					p10pos.position=GameObject.Find("p10pos352").transform.position;
				}//352

			}
		}
		else   //player 2
		{
			if(global.category=="clubs"){
				if(Control.clubformation[global.team2]==433){
					p1posop.position=GameObject.Find("p1posop433").transform.position;
					p2posop.position=GameObject.Find("p2posop433").transform.position;
					p3posop.position=GameObject.Find("p3posop433").transform.position;
					p4posop.position=GameObject.Find("p4posop433").transform.position;
					p5posop.position=GameObject.Find("p5posop433").transform.position;
					p6posop.position=GameObject.Find("p6posop433").transform.position;
					p7posop.position=GameObject.Find("p7posop433").transform.position;
					p8posop.position=GameObject.Find("p8posop433").transform.position;
					p9posop.position=GameObject.Find("p9posop433").transform.position;
					p10posop.position=GameObject.Find("p10posop433").transform.position;
				}//433
				if(Control.clubformation[global.team2]==541){
					p1posop.position=GameObject.Find("p1posop541").transform.position;
					p2posop.position=GameObject.Find("p2posop541").transform.position;
					p3posop.position=GameObject.Find("p3posop541").transform.position;
					p4posop.position=GameObject.Find("p4posop541").transform.position;
					p5posop.position=GameObject.Find("p5posop541").transform.position;
					p6posop.position=GameObject.Find("p6posop541").transform.position;
					p7posop.position=GameObject.Find("p7posop541").transform.position;
					p8posop.position=GameObject.Find("p8posop541").transform.position;
					p9posop.position=GameObject.Find("p9posop541").transform.position;
					p10posop.position=GameObject.Find("p10posop541").transform.position;
				}//541
				if(Control.clubformation[global.team2]==352){
					p1posop.position=GameObject.Find("p1posop352").transform.position;
					p2posop.position=GameObject.Find("p2posop352").transform.position;
					p3posop.position=GameObject.Find("p3posop352").transform.position;
					p4posop.position=GameObject.Find("p4posop352").transform.position;
					p5posop.position=GameObject.Find("p5posop352").transform.position;
					p6posop.position=GameObject.Find("p6posop352").transform.position;
					p7posop.position=GameObject.Find("p7posop352").transform.position;
					p8posop.position=GameObject.Find("p8posop352").transform.position;
					p9posop.position=GameObject.Find("p9posop352").transform.position;
					p10posop.position=GameObject.Find("p10posop352").transform.position;
				}//352
			}
			else{
				if(Control.formation[global.team2]==433){
					p1posop.position=GameObject.Find("p1posop433").transform.position;
					p2posop.position=GameObject.Find("p2posop433").transform.position;
					p3posop.position=GameObject.Find("p3posop433").transform.position;
					p4posop.position=GameObject.Find("p4posop433").transform.position;
					p5posop.position=GameObject.Find("p5posop433").transform.position;
					p6posop.position=GameObject.Find("p6posop433").transform.position;
					p7posop.position=GameObject.Find("p7posop433").transform.position;
					p8posop.position=GameObject.Find("p8posop433").transform.position;
					p9posop.position=GameObject.Find("p9posop433").transform.position;
					p10posop.position=GameObject.Find("p10posop433").transform.position;
				}//433
				if(Control.formation[global.team2]==541){
					p1posop.position=GameObject.Find("p1posop541").transform.position;
					p2posop.position=GameObject.Find("p2posop541").transform.position;
					p3posop.position=GameObject.Find("p3posop541").transform.position;
					p4posop.position=GameObject.Find("p4posop541").transform.position;
					p5posop.position=GameObject.Find("p5posop541").transform.position;
					p6posop.position=GameObject.Find("p6posop541").transform.position;
					p7posop.position=GameObject.Find("p7posop541").transform.position;
					p8posop.position=GameObject.Find("p8posop541").transform.position;
					p9posop.position=GameObject.Find("p9posop541").transform.position;
					p10posop.position=GameObject.Find("p10posop541").transform.position;
				}//541
				if(Control.formation[global.team2]==352){
					p1posop.position=GameObject.Find("p1posop352").transform.position;
					p2posop.position=GameObject.Find("p2posop352").transform.position;
					p3posop.position=GameObject.Find("p3posop352").transform.position;
					p4posop.position=GameObject.Find("p4posop352").transform.position;
					p5posop.position=GameObject.Find("p5posop352").transform.position;
					p6posop.position=GameObject.Find("p6posop352").transform.position;
					p7posop.position=GameObject.Find("p7posop352").transform.position;
					p8posop.position=GameObject.Find("p8posop352").transform.position;
					p9posop.position=GameObject.Find("p9posop352").transform.position;
					p10posop.position=GameObject.Find("p10posop352").transform.position;
				}//352
			}
		}
	}

	void  DoTactics (){
		if(global.team1!=global.id){ //team1
			if(global.team1goals==global.team2goals) //draw
				global.t1mentality="normal";
			if(global.team1goals>global.team2goals && minutes>50)  //winning
				global.t1mentality="defensive";
			if(global.team1goals<global.team2goals)  //losing
				global.t1mentality="attacking";
		}
		if(global.team2!=global.id){ //team2
			if(global.team2goals==global.team1goals) //draw
				global.t2mentality="normal";
			if(global.team2goals>global.team1goals && minutes>50)  //winning
				global.t2mentality="defensive";
			if(global.team2goals<global.team1goals)  //losing
				global.t2mentality="attacking";
		}
	}

	void  SetOwnFormation (){ 
		if(global.team1==global.id){
			if(global.formation==433){
				p1pos.position=GameObject.Find("p1pos433").transform.position;
				p2pos.position=GameObject.Find("p2pos433").transform.position;
				p3pos.position=GameObject.Find("p3pos433").transform.position;
				p4pos.position=GameObject.Find("p4pos433").transform.position;
				p5pos.position=GameObject.Find("p5pos433").transform.position;
				p6pos.position=GameObject.Find("p6pos433").transform.position;
				p7pos.position=GameObject.Find("p7pos433").transform.position;
				p8pos.position=GameObject.Find("p8pos433").transform.position;
				p9pos.position=GameObject.Find("p9pos433").transform.position;
				p10pos.position=GameObject.Find("p10pos433").transform.position;
			}
			if(global.formation==541){
				p1pos.position=GameObject.Find("p1pos541").transform.position;
				p2pos.position=GameObject.Find("p2pos541").transform.position;
				p3pos.position=GameObject.Find("p3pos541").transform.position;
				p4pos.position=GameObject.Find("p4pos541").transform.position;
				p5pos.position=GameObject.Find("p5pos541").transform.position;
				p6pos.position=GameObject.Find("p6pos541").transform.position;
				p7pos.position=GameObject.Find("p7pos541").transform.position;
				p8pos.position=GameObject.Find("p8pos541").transform.position;
				p9pos.position=GameObject.Find("p9pos541").transform.position;
				p10pos.position=GameObject.Find("p10pos541").transform.position;
			}
			if(global.formation==352){
				p1pos.position=GameObject.Find("p1pos352").transform.position;
				p2pos.position=GameObject.Find("p2pos352").transform.position;
				p3pos.position=GameObject.Find("p3pos352").transform.position;
				p4pos.position=GameObject.Find("p4pos352").transform.position;
				p5pos.position=GameObject.Find("p5pos352").transform.position;
				p6pos.position=GameObject.Find("p6pos352").transform.position;
				p7pos.position=GameObject.Find("p7pos352").transform.position;
				p8pos.position=GameObject.Find("p8pos352").transform.position;
				p9pos.position=GameObject.Find("p9pos352").transform.position;
				p10pos.position=GameObject.Find("p10pos352").transform.position;
			}
			if(global.category=="clubs"){
				if(Control.clubformation[global.team1]==442 && postimeout==2){
					p1pos.position=op1pos;p2pos.position=op2pos;p3pos.position=op3pos;p4pos.position=op4pos;
					p5pos.position=op5pos;p6pos.position=op6pos;p7pos.position=op7pos;p8pos.position=op8pos;
					p9pos.position=op9pos;p10pos.position=op10pos;
				}  }
			p1pos.GetComponent<position1>().ResetPos();p2pos.GetComponent<position1>().ResetPos();p3pos.GetComponent<position1>().ResetPos();
			p4pos.GetComponent<position1>().ResetPos();p5pos.GetComponent<position1>().ResetPos();p6pos.GetComponent<position1>().ResetPos();
			p7pos.GetComponent<position1>().ResetPos();p8pos.GetComponent<position1>().ResetPos();p9pos.GetComponent<position1>().ResetPos();
			p10pos.GetComponent<position1>().ResetPos();
		}
		else if(global.team2==global.id){ //team 2
			if(global.formation==433){
				p1posop.position=GameObject.Find("p1posop433").transform.position;
				p2posop.position=GameObject.Find("p2posop433").transform.position;
				p3posop.position=GameObject.Find("p3posop433").transform.position;
				p4posop.position=GameObject.Find("p4posop433").transform.position;
				p5posop.position=GameObject.Find("p5posop433").transform.position;
				p6posop.position=GameObject.Find("p6posop433").transform.position;
				p7posop.position=GameObject.Find("p7posop433").transform.position;
				p8posop.position=GameObject.Find("p8posop433").transform.position;
				p9posop.position=GameObject.Find("p9posop433").transform.position;
				p10posop.position=GameObject.Find("p10posop433").transform.position;
			}
			if(global.formation==541){
				p1posop.position=GameObject.Find("p1posop541").transform.position;
				p2posop.position=GameObject.Find("p2posop541").transform.position;
				p3posop.position=GameObject.Find("p3posop541").transform.position;
				p4posop.position=GameObject.Find("p4posop541").transform.position;
				p5posop.position=GameObject.Find("p5posop541").transform.position;
				p6posop.position=GameObject.Find("p6posop541").transform.position;
				p7posop.position=GameObject.Find("p7posop541").transform.position;
				p8posop.position=GameObject.Find("p8posop541").transform.position;
				p9posop.position=GameObject.Find("p9posop541").transform.position;
				p10posop.position=GameObject.Find("p10posop541").transform.position;
			}
			if(global.formation==352){
				p1posop.position=GameObject.Find("p1posop352").transform.position;
				p2posop.position=GameObject.Find("p2posop352").transform.position;
				p3posop.position=GameObject.Find("p3posop352").transform.position;
				p4posop.position=GameObject.Find("p4posop352").transform.position;
				p5posop.position=GameObject.Find("p5posop352").transform.position;
				p6posop.position=GameObject.Find("p6posop352").transform.position;
				p7posop.position=GameObject.Find("p7posop352").transform.position;
				p8posop.position=GameObject.Find("p8posop352").transform.position;
				p9posop.position=GameObject.Find("p9posop352").transform.position;
				p10posop.position=GameObject.Find("p10posop352").transform.position;
			}
			if(global.category=="clubs"){
				if(Control.clubformation[global.team2]==442 && postimeout==2){
					p1pos.position=op1oppos;p2pos.position=op2oppos;p3pos.position=op3oppos;p4pos.position=op4oppos;
					p5pos.position=op5oppos;p6pos.position=op6oppos;p7pos.position=op7oppos;p8pos.position=op8oppos;
					p9pos.position=op9oppos;p10pos.position=op10oppos;
				}   }
			p1posop.GetComponent<position2>().ResetPos();p2posop.GetComponent<position2>().ResetPos();p3posop.GetComponent<position2>().ResetPos();
			p4posop.GetComponent<position2>().ResetPos();p5posop.GetComponent<position2>().ResetPos();p6posop.GetComponent<position2>().ResetPos();
			p7posop.GetComponent<position2>().ResetPos();p8posop.GetComponent<position2>().ResetPos();p9posop.GetComponent<position2>().ResetPos();
			p10posop.GetComponent<position2>().ResetPos();
		}
	}

	void  SetWidth ( string team  ){
		if(team=="player1"){
			p1pos.GetComponent<position1>().SetWidth();
			p2pos.GetComponent<position1>().SetWidth();
			p3pos.GetComponent<position1>().SetWidth();
			p4pos.GetComponent<position1>().SetWidth();
			p5pos.GetComponent<position1>().SetWidth();
			p6pos.GetComponent<position1>().SetWidth();
			p7pos.GetComponent<position1>().SetWidth();
			p8pos.GetComponent<position1>().SetWidth();
			p9pos.GetComponent<position1>().SetWidth();
			p10pos.GetComponent<position1>().SetWidth();
		}
		else
		{
			p1posop.GetComponent<position2>().SetWidth();
			p2posop.GetComponent<position2>().SetWidth();
			p3posop.GetComponent<position2>().SetWidth();
			p4posop.GetComponent<position2>().SetWidth();
			p5posop.GetComponent<position2>().SetWidth();
			p6posop.GetComponent<position2>().SetWidth();
			p7posop.GetComponent<position2>().SetWidth();
			p8posop.GetComponent<position2>().SetWidth();
			p9posop.GetComponent<position2>().SetWidth();
			p10posop.GetComponent<position2>().SetWidth();
		}
	}

	void  SetOwnMentality (){    // set team mentality to controlled player's set mentality
		if(global.team1==global.id)
			global.t1mentality=global.mentality;
		if(global.team2==global.id)
			global.t2mentality=global.mentality;
	}

	void  LoadRatings (){

		if(global.team1==global.id){

			var baller=player1.GetComponent<player>();baller.rating=global.rating1;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}


			baller=player22.GetComponent<player>();baller.rating=global.rating2;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player3.GetComponent<player>();baller.rating=global.rating3;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player4.GetComponent<player>();baller.rating=global.rating4;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player5.GetComponent<player>();baller.rating=global.rating5;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player6.GetComponent<player>();baller.rating=global.rating6;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player7.GetComponent<player>();baller.rating=global.rating7;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player8.GetComponent<player>();baller.rating=global.rating8;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player9.GetComponent<player>();baller.rating=global.rating9;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
			baller=player10.GetComponent<player>();baller.rating=global.rating10;
			if(baller.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{baller.control-=5;baller.crossing-=5;baller.curve-=5;baller.dribble-=5;baller.accuracy-=5;
				baller.freekicks-=5;baller.heading-=5;baller.longshots-=5;baller.passes-=5;baller.hotshot-=5;baller.tackle-=5;
			}
			if(baller.rating==6) // set this rating again upon room restart
			{baller.control-=10;baller.crossing-=10;baller.curve-=10;baller.dribble-=10;baller.accuracy-=10;
				baller.freekicks-=10;baller.heading-=10;baller.longshots-=10;baller.passes-=10;baller.hotshot-=10;baller.tackle-=10;
			}
		}
		if(global.team2==global.id){

			var fballer=player1opp.GetComponent<player2>();fballer.rating=global.rating21;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}

			fballer=player2opp.GetComponent<player2>();fballer.rating=global.rating22;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player3opp.GetComponent<player2>();fballer.rating=global.rating23;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player4opp.GetComponent<player2>();fballer.rating=global.rating24;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player5opp.GetComponent<player2>();fballer.rating=global.rating25;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player6opp.GetComponent<player2>();fballer.rating=global.rating26;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player7opp.GetComponent<player2>();fballer.rating=global.rating27;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player8opp.GetComponent<player2>();fballer.rating=global.rating28;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player9opp.GetComponent<player2>();fballer.rating=global.rating29;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
			fballer=player10opp.GetComponent<player2>();fballer.rating=global.rating210;
			if(fballer.rating==7) // rating affects accelerate, agile, control, crossing curve dribble , accuracy freekicks heading longshots passes hotshot tackle
			{fballer.control-=5;fballer.crossing-=5;fballer.curve-=5;fballer.dribble-=5;fballer.accuracy-=5;
				fballer.freekicks-=5;fballer.heading-=5;fballer.longshots-=5;fballer.passes-=5;fballer.hotshot-=5;fballer.tackle-=5;
			}
			if(fballer.rating==6) // set this rating again upon room restart
			{fballer.control-=10;fballer.crossing-=10;fballer.curve-=10;fballer.dribble-=10;fballer.accuracy-=10;
				fballer.freekicks-=10;fballer.heading-=10;fballer.longshots-=10;fballer.passes-=10;fballer.hotshot-=10;fballer.tackle-=10;
			}
		}

	}
}
