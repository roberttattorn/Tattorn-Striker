using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;
using Random=UnityEngine.Random;

public class Control : MonoBehaviour {


	public GameObject TeamName;
	public GameObject ManagerName;
	public GameObject Money;
	public GameObject Dates;
	public GameObject colour;
	public GameObject Winner;
	public GameObject Winnertext;
	public GameObject fixturename;
	public GameObject fixture1;
	public GameObject fixture2;
	public GameObject fixture3;
	public GameObject fixture4;
	public GameObject fixture5;
	public GameObject fixture6;
	public GameObject fixture7;
	public GameObject fixture8;
	public GameObject fixture9;
	private string category;
	public GameObject fixturecolour;
	public GameObject next;
	//public GameObject databases;
	public databaseClubs Clubs;
	public database Countries;
	public GameObject loading;
	private int timeout=0;
	public static int week=1;
	public static string month="Jul";
	public static int year=2018;
	private bool timetosave=false;
	static int realweek=1;
	static int realfixture=0;
	static string state="news";
	private int communityshieldwinner;
	private int spanishsupercupwinner;
	private int italiansupercupwinner;
	private int germansupercupwinner;
	static bool match1played=false;
	static bool match2played=false;
	static bool match3played=false;
	static bool match4played=false;
	static bool match5played=false;
	static bool match6played=false;
	static bool match7played=false;
	static bool match8played=false;
	static bool match9played=false;
	static string news;
	public GameObject newspaper;
	public Color bluish=new Color(153/255,0.85f,234/255);  //friendly, qualifications
	public Color pinkish=new Color(1.0f,166/255,162/255);    //fa cup league cup
	public Color greenish=new Color(159/255,1.0f,159/255);  //world cup
	public Color yellowish=new Color(1.0f,1.0f,164/255);     //afcon euro etc
	public Color violet=new Color(1.0f,159/255,1.0f);         //champions league
	public Color generic=new Color(212/255,1.0f,205/255);  //league

	public static  int[] clubid=new int[97];
	public static  string[] clubname=new string[97];
	public static int[] clubreputation=new int[97];
	public static  string[] clubleague=new string[97];
	public static  string[] clubicon=new string[97];
	public static  Color[] clubmaincolour=new Color[97];
	public static  Color[] clubtextcolour=new Color[97];
	public static  Color[] clubshirt=new Color[97];
	public static  Color[] clubshorts=new Color[97];
	public static  Color[] clubsocks=new Color[97];
	public static  int[] clubshirtpattern=new int[97];
	public  static string[] qualifiedleague=new string[97];
	public static  bool[ ] communityshield=new bool[ 97];
	public static  int[] championsleaguewins=new int[97];
	public static  int[] uefacupwins=new int[97];
	public static  int[] money=new int[97];
	public static  int[] clubformation=new int[97];
	public  static string[] clubmentality=new string[97];
	public static  string[] clubmanager=new string[97];
	[HideInInspector]
	public static int[,] clubplayers=new int[97,23];
	public static  int[] clubaggregate=new int[97];///////////
	public static  int[] clubgoals=new int[97];///////////////
	public static  int[] clubeupoints=new int[97];////////////////european competition points
	public static  int[] clubeugoals=new int[97];
	public static  int[] clubleaguepoints=new int[97];///league points
	public static  int[] clubyellowcards=new int[97];///////////
	public static  int[] clubawaygoals=new int[97];///////////
	public static  bool[ ] clubleaguecup=new bool[ 97]; //in the league cup

	//static string state;
	public static  int[] id=new int[147];
	public static  string[] countryname=new string[147];
	public static  int[] reputation=new int[147];
	public static  string[] region=new string[147];
	public static  string[] icon=new string[147];
	public static  Color[] maincolour=new Color[147];
	public static  Color[] textcolour=new Color[147];
	public static  Color[] shirt=new Color[147];
	public static  Color[] shorts=new Color[147];
	public static  Color[] socks=new Color[147];
	public static  int[] skincolour=new int[147];
	public static  int[] shirtpattern=new int[147];
	public static  int[] wcwins=new int[147];
	public static  int[] rcwins=new int[147];
	public static  int[] lcwins=new int[147];
	public  static bool[ ] wcqualified=new bool[ 147];
	public static  int[] formation=new int[147];
	public static  string[] mentality=new string[147];
	public static  string[] manager=new string[147];
	[HideInInspector]
	public static int[,] players=new int[147,23];
	public static  int[] goals=new int[147];
	public  static int[] qualgoals=new int[147];  //remember to clean these stats after each competition
	public static  int[] qualpoints=new int[147];
	public static  int[] qualyellowcards=new int[147];
	public static  int[] points=new int[147];// major competition points
	public static  int[] yellowcards=new int[147];
	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	//static FIXME_VAR_TYPE fixture1=0;  //one of two fixtures a week
	//static FIXME_VAR_TYPE fixture2=1;
	static int match1=0;
	static int match2=1;
	static int match3=2;
	static int match4=3;
	static int match5=4;
	static int match6=5;
	static int match7=6;
	static int match8=7;
	static int match9=8;
	static int team1=0;
	static int team2=1;
	static int league=2;
	static int matchtype=3;
	static int isaggregate=4;
	static int isfinal=5;
	//match type
	static int premierleague=0;
	static int laliga=1;
	static int seriea=2;
	static int bundesliga=3;
	static int facup=4;
	static int leaguecup=5;
	static int Communityshield=6;
	static int spanishsupercup=7;
	static int italiansupercup=8;
	static int germansupercup=9;
	static int spanishcup=10;
	static int italiancup=11;
	static int germancup=12;
	static int championsleague=33;
	static int uefacup=34;
	static int friendly=13;//intl
	static int wceuquals=14;static int wcsaquals=15;static int wcafquals=16;static int wcasquals=17;static int wcnaquals=18;
	static int wcoquals=19;
	static int euquals=20;
	static int afconquals=21;
	static int copaamerica=22;
	static int goldcup=23;
	static int asiancup=24;
	static int ocncup=25;
	static int worldcup=26;
	static int afcon=27;
	static int euro=28;
	static int cecafa=29;
	static int cosafa=30;
	static int cabral=31;
	static int cwc=32;
	//stage
	static int League=0;
	static int knockout=1;
	static int thirdplace=3;
	private string fixture1score1;private string fixture1score2;private string fixture2score1;private string fixture2score2;
	private string fixture3score1;private string fixture3score2;private string fixture4score1;private string fixture4score2;
	private string fixture5score1;private string fixture5score2;private string fixture6score1;private string fixture6score2;
	private string fixture7score1;private string fixture7score2;private string fixture8score1;private string fixture8score2;
	//xxxxxxxxxxxxxxxxxxxxxxxx  set up fixtures   xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	public class weeks{

		public fixtures[] fixture=new fixtures[14];

	}
	public class fixtures{
		public Color colour;          //background colour of fixture
		public string name;           //name of fixture e.g champions league
		public string kind;        //short name for kind of fixture premierleague, laliga, seriea, bundesliga, championsleague
		public string stage;    //stage of match quarterfinal  semifinal final roundof16 thirdplace group determines placement of winner for next stage
		public string type;        //aggregate, knockout, final, league last . last determines end of group stage
		public string leg;            //determines leg number if aggregate leg1 leg2
		public matches[] match=new matches[10];
		public string category;
	}
	public class matches{
		public int team1;
		public int team2;
		public int group;      //number of next group of knockout stage, 0 if final.
		public int position;        // position of match if knockout position 1 progresses winner to slot 1 posiion 2 winner goes to slot 2 etc.
		public string stage;
	}
	weeks[] Week= new weeks[193];
	[HideInInspector]
	public Players[] player=new Players[24];
	/*FIXME_VAR_TYPE Week= new weeks[193];
//for(FIXME_VAR_TYPE i=1;i<=192;i++)
for(FIXME_VAR_TYPE i=1;i<=192;i++){
   Week[i] = new weeks();
     for(FIXME_VAR_TYPE j=1;j<=13;j++){
     Week[i].fixture[j]=new fixtures();
     for(FIXME_VAR_TYPE k=1;k<=9;k++)
     Week[i].fixture[j].match[k]=new matches();
     }
   }*/

	//first shuffle participating club teams
	//set them to a league table   /   if playing as a nation, pop up random friendly
	// uncertain fixtures will be set by assigning teams to other variables

	static List<int> plclubs=new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18};  //premier league clubs
	static List<int> llclubs=new List<int>{19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34};
	static List<int> saclubs=new List<int>{35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50};
	static List<int> blclubs=new List<int>{51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66};
	static List<int> relegated=new List<int>{67,68,69};
	static List<int> unplayableUCL=new List<int>{70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85};
	static List<int> unplayableUEFA=new List<int>{86,87,88,89,90,91,92,93};
	static List<int> unplayableCWC=new List<int>{94,95,96};

	static List<int> EUcountries=new List<int>{4,6,7,9,13,16,31,33,34,35,41,44,47,48,51,52,54,60,61,66,67,68,76,80,81,89,94,99,100,107,108,110,113,115,
		119,120,123,127,128,134,139,144};
	static List<int> SAcountries=new List<int>{3,12,15,24,26,38,103,104,140,142};
	static List<int> AFcountries=new List<int>{1,2,11,14,17,18,19,21,22,23,27,28,29,36,39,42,43,45,49,50,53,56,57,69,73,78,79,82,82,85,86,87,90,91,92,
		97,98,111,114,116,117,122,125,126,129,131,133,138,145,146};
	static List<int> AScountries=new List<int>{25,62,63,64,65,71,72,75,77,84,93,101,105,109,112,118,124,130,137,143};
	static List<int> NAcountries=new List<int>{8,10,20,30,32,37,40,55,58,59,70,88,96,102,132,136};
	static List<int> Ocountries=new List<int>{5,46,74,95,106,121,135,141};
	//match team storing data
	static int[,,] plmatches=new int[22,9,2]; //holds team index
	static int[,,] llmatches=new int[20,9,2];   //[week,pair,team]
	static int[,,] samatches=new int[20,9,2];
	static int[,,] blmatches=new int[20,9,2];
	static int[] plclub=new int[19];
	static int[] club=new int[17];
	static int[] PLcommunityshield=new int[3];
	static int[] LLcommunityshield=new int[3];
	static int[] SAcommunityshield=new int[3];
	static int[] BLcommunityshield=new int[3];

	static int[, ]FAcup_playoffs1=new int[3,3];  // overall last 2 pairs playoff then last 2 in pl play off 2 winners & 3rd last plays 17
	static int[ ,]FAcup_playoffs2=new int[4,3];  //3 instead of 2 so that digit 1 can be used
	static int[, ]FAcup_round1=new int[9,3];  //group of 16 after last 3 winners of last 3 playoffs
	static int[ ,]FAcup_quarterfinal=new int[5,3];
	static int[, ]FAcup_semifinal=new int[3,3];
	static int[] FAcup_final=new int[3];
	static int[,] Leaguecup_round1=new int[9,3];
	static int[, ]Leaguecup_semi=new int[3,3];//semi final
	static int[] Leaguecup_final=new int[3];//final
	static int[,] Championsleague_group=new int[9,5]; //group , team
	static int[ ,]Championsleague_round16=new int[9,3];
	static int[ ,]Championsleague_quarterfinal=new int[5,3];
	static int[ ,]Championsleague_semifinal=new int[3,3];
	static int[] Championsleague_final=new int[3];
	static int[, ]Uefacup_group=new int[5,5];
	static int[, ]Uefacup_quarterfinal=new int[5,3];
	static int[ ,]Uefacup_semifinal=new int[3,3];
	static int[] Uefacup_final=new int[3];
	static int[, ]Spanishcup_round1=new int[9,3];
	static int[ ,]Spanishcup_quarterfinal=new int[5,3];
	static int[,] Spanishcup_semifinal=new int[5,3];
	static int[] Spanishcup_final=new int[3];
	static int[,] Italiancup_round1=new int[9,3];
	static int[,] Italiancup_quarterfinal=new int[5,3];
	static int[,] Italiancup_semifinal=new int[3,3];
	static int[] Italiancup_final=new int[3];
	static int[,] Germancup_round1=new int[9,3];
	static int[,] Germancup_quarterfinal=new int[5,3];
	static int[,] Germancup_semifinal=new int[3,3];
	static int[] Germancup_final=new int[3];
	static int[,] Friendly=new int[15,3];
	static int[,] WCQualifier_eu_group=new int[8,7];  //7 groups of 6  all quals in 1 s start from 1 not 0
	static int[,] WCQualifier_as_group=new int[5,6]; 
	static int[,] WCQualifier_af_group=new int[6,6]; //5 groups of 5
	static int[] WCQualifier_oc_group=new int[9];   //10 teams in one league
	static int[] WCQualifier_na_group=new int[17];
	static int[] WCQualifier_sa_group=new int[11];
	static int[,] EUROqualifier_group=new int[9,6];  //8 groups of 5
	static int[,] WCQualifier_playoff=new int[26,3];  //first a playoff of all african teams is done
	static List<int> WCQAfrica_pool=new List<int>();
	static int[,] worldcup_group=new int[9,5];
	static int[,] worldcup_round16=new int[9,3];
	static int[,] worldcup_quarterfinal=new int[5,3];
	static int[,] worldcup_semifinal=new int[3,3];
	static int[] worldcup_third=new int[3];
	static int[] worldcup_final=new int[3];
	static int[,] AFCONQualifiers_playoff=new int[3,3];  //2 playoff of 4 teams
	static int[,] AFCONqualifier_group=new int[9,7];
	static int[,] EURO_group=new int[5,5];
	static int[,] EURO_quarterfinal=new int[5,3];
	static int[,] EURO_semifinal=new int[3,3];
	static int[] EURO_final=new int[3];
	static int[,] AFCON_group=new int[5,5];
	static int[,] AFCON_quarterfinal=new int[5,3];
	static int[,] AFCON_semifinal=new int[3,3];
	static int[] AFCON_final=new int[3];
	static int[,] CopaAmerica=new int[3,6];
	static int[,] Copa_semifinal=new int[3,3];
	static int[] Copa_final=new int[3];
	static int[,] Goldcup_group=new int[5,5];
	static int[,] Goldcup_quarterfinal=new int[5,3];
	static int[,] Goldcup_semifinal=new int[3,3];
	static int[] Goldcup_final=new int[3];
	static int[,] ONCcup_round1=new int[5,3];
	static int[,] ONCcup_semifinal=new int[3,3];
	static int[] ONCcup_final=new int[3];
	static int[,] ASIANcup_group=new int[5,6];
	static int[,] ASIANcup_quarterfinal=new int[5,3];
	static int[,] ASIANcup_semifinal=new int[3,3];
	static int[] ASIANcup_final=new int[3];
	static int[,] SEAgames_semifinal=new int[3,3];
	static int[] SEAgames_final=new int[3];
	static int[,] SEAgames_round1=new int[5,3];
	static int[,] CECAFAcup_round1=new int[5,3];
	static int[,] CECAFAcup_semifinal=new int[3,3];
	static int[] CECAFAcup_final=new int[3];
	static int[,] COSAFAcup_round1=new int[5,3];
	static int[,] COSAFAcup_semifinal=new int[3,3];
	static int[] COSAFAcup_final=new int[3];
	static int[,] CABRALcup_round1=new int[5,3];
	static int[,] CABRALcup_semifinal=new int[3,3];
	static int[] CABRALcup_final=new int[3];
	static int[,] CONFEDcup_round1=new int[5,5]; //2 extra teams in last 2 groups
	static int[,] CONFEDcup_semifinal=new int[3,3];
	static int[] CONFEDcup_final=new int[3];
	static int[,] CWC_semi=new int[3,3];
	static int[] CWC_final=new int[3];
	static int[] EUROVase=new int[3];
	static List<int> wcqafrica_pool=new List<int>();
	static int liga1=5;
	static int liga2=6;
	static int seriea1=7;
	static int seriea2=8;
	static int bundes1=9;
	static int bundes2=10;
	//static FIXME_VAR_TYPE africa1=5;
	static int africa2=11;
	//static FIXME_VAR_TYPE asia1=7;
	static int asia2=12;
	static List<int> worldcup_pool=new List<int>();  //former array
	//static FIXME_VAR_TYPE northamerica1=9;
	static int northamerica2=13;
	//int[][] match=new match[153][152];
	//int[][] match2=new match[120][120];
	GameObject Message;
	GameObject MessageText;
	private int[] FaCupPool=new int[17];
	private int[] winner_facupplayoff1=new int[4];
	private int[] winner_facupplayoff2=new int[4];

	public class Players{
		public int id;
		public string playername;
		//int Age;
		public string Photo;
		public string country;
		public int overall;
		public int potential;
		public string club;
		public float Value;
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
		public int GKpositioning;
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
		public string vskeeper;
		public string play;
		public int ratio; //playing style ratio to prioritize chosen over the others
		public string wings;
		public string longshoot;
		public string tackling;
		public string passheight;
		public int rating;
		public int[] ratings=new int[5];
		public int consistency;                //this improves as manager team talks correctly at end of match
		public int[] training_attack=new int[2];         //[0] is the amount to increase by and [1] is the points accumlated
		public int[] training_midfield=new int[2];  //points for attack training
		public int[] training_defence=new int[2];
		public int[] training_physical=new int[2];
		public int[] training_setpieces=new int[2];
		public int[] training_goalkeeper=new int[2];
	}

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	//public FIXME_VAR_TYPE club= new clubs[99];

	void  Start (){ 
		DontDestroyOnLoad(this.gameObject);
		//for(FIXME_VAR_TYPE i=1;i<=192;i++)
		for(int i=1;i<=192;i++){
			Week[i] = new weeks();
			for(int j=1;j<=13;j++){
				Week[i].fixture[j]=new fixtures();
				for(int k=1;k<=9;k++)
					Week[i].fixture[j].match[k]=new matches();
			}
		} 

		if(Application.loadedLevelName=="init"){
			if(global.load)  //load game if loading
				Load(); Debug.Log("loaded");
			Application.LoadLevel("dashboard");
		} 

		if(Application.loadedLevelName=="dashboard"){

			Clubs=gameObject.GetComponent<databaseClubs>();
			Countries=gameObject.GetComponent<database>();
			DontDestroyOnLoad(this.gameObject);
			//if( global.hasControl)
			TeamName=GameObject.Find("Canvas").transform.Find("teamname").gameObject;
			ManagerName=GameObject.Find("Canvas").transform.Find("ManagerName").gameObject; 
			//TeamName=GameObject.Find("Canvas").Find("team");
			Money=GameObject.Find("Canvas").transform.Find("money").gameObject; 
			if(global.category=="countries")
				Money.SetActive(false);
			Dates=GameObject.Find("Canvas").transform.Find("dates").gameObject;
			colour=GameObject.Find("Canvas").transform.Find("Colour").gameObject; 
			Winner=GameObject.Find("Canvas").transform.Find("Winner").gameObject;
			if(Winnertext==null)
				Winnertext=GameObject.Find("Canvas").transform.Find("Winner").Find("Text").gameObject; 
			fixturename=GameObject.Find("Canvas").transform.Find("fixturename").gameObject;
			fixturecolour=GameObject.Find("Canvas").transform.Find("fixturecolour").gameObject;
			next=GameObject.Find("Canvas").transform.Find("Next").gameObject;
			loading=GameObject.Find("Canvas").transform.Find("Loading").gameObject;
			//newspaper=GameObject.Find("News");
			fixture1=GameObject.Find("Canvas").transform.Find("fixture1").gameObject;
			fixture2=GameObject.Find("Canvas").transform.Find("fixture2").gameObject;
			fixture3=GameObject.Find("Canvas").transform.Find("fixture3").gameObject;
			fixture4=GameObject.Find("Canvas").transform.Find("fixture4").gameObject;
			fixture5=GameObject.Find("Canvas").transform.Find("fixture5").gameObject;
			fixture6=GameObject.Find("Canvas").transform.Find("fixture6").gameObject;
			fixture7=GameObject.Find("Canvas").transform.Find("fixture7").gameObject;
			fixture8=GameObject.Find("Canvas").transform.Find("fixture8").gameObject;
			fixture9=GameObject.Find("Canvas").transform.Find("fixture9").gameObject;
			newspaper=GameObject.Find("Canvas").transform.Find("Newspaper").gameObject;}
		//Destroy(gameObject);
	}

	void  Init (){
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////////////////aintit
		//Debug.Log(global.league+" "+WCQualifier_af_group[1,1]);//todo
		//fix matches
		if(global.load==false && global.reinit==false){
			plmatches=ShufflePLClubs();
			llmatches=ShuffleOtherClubs(llclubs,"laliga");
			samatches=ShuffleOtherClubs(saclubs,"seriea");
			blmatches=ShuffleOtherClubs(blclubs,"bundes");

			PLcommunityshield=GetCommunity(18,1,"PL");  //get communityshield teams  count , start
			LLcommunityshield=GetCommunity(16,19,"LL");
			SAcommunityshield=GetCommunity(16,35,"SA");
			BLcommunityshield=GetCommunity(16,51,"BL");
			//fill fa cup and league cup, ucl and euro wcq euq etc
			FAcup_playoffs1[1,1]=relegated[0];
			FAcup_playoffs1[1,2]=relegated[1];
			FAcup_playoffs1[2,1]=relegated[2];
			FAcup_playoffs1[2,2]=plclubs[17];
			//FAcup_playoffs1[3,1]=plclubs[17];
			//FAcup_playoffs1[3,2]=plclubs[16];

			FAcup_playoffs2=Fill_Facup_playoffs();
			//FAcup_round1=Fill_FAcup();
			Leaguecup_round1=Fill_Leaguecup();
			//FAcup_playoffs=Fill_FAcup_playoffs();
			Championsleague_group=Fill_championsleague();
			Uefacup_group=Fill_Uefacup();
			Spanishcup_round1=FillSpanishcup();
			Italiancup_round1=FillItaliancup();
			Germancup_round1=Fillgermancup();
			EUROVase[1]=21;
			EUROVase[2]=29;
			if(global.category=="countries")  //ocn final resets it after 2 years
				Friendly=MakeFriendlies();
			WCQualifier_playoff=FillWCQualifier_playoffAF();
			WCQualifier_eu_group=FillWCquals("europe");  //7 groups of 6
			WCQualifier_as_group=FillWCquals("asia");   //4 groups of 5
			//WCQualifier_af_group=FillWCqualifier_playoffAF("africa"); //set after playoff
			WCQualifier_oc_group=FillWCQuals2("oceania");   //8 teams in one league
			WCQualifier_na_group=FillWCQuals2("northamerica"); //1 group of 16
			WCQualifier_sa_group=FillWCQuals2("southamerica"); 
			EUROqualifier_group=FillEUROquals();
			AFCONqualifier_group=FillAfconquals();
			FillCups();   //fill minor regional cups
			fill_yearly_cups();
			CWC_semi[1,1]=cwc;
			CWC_semi[1,2]=94;
			CWC_semi[2,1]=95;
			CWC_semi[2,2]=96;
			CONFEDcup_round1[1,1]= 136;  // 3  groups of 6 teams  na
			CONFEDcup_round1[1,2]= 24;  //  sa
			CONFEDcup_round1[2,1]= 90;  // af
			CONFEDcup_round1[2,2]= 5;  //  oc  or 95
			CONFEDcup_semifinal[2,1]= 108;   //this group is in the semi final  eu
			CONFEDcup_semifinal[2,2]=71;   //as
			if(System.IO.File.Exists(Application.dataPath + "/fixtures"))
				File.Delete(Application.dataPath + "/fixtures");
			LoadPlayers();//load own team players from file and save to new file
			SavePlayers();}  //not global.load

		// time to set up the schedule
		/////////////////////////////////////////////////////////////////////////////////////////if( Contains({m,m+48,m+96,m+144},k)
		///////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//Week[1,fixture1,match1,team1]=PLcommunityshield[1];  //team id  community shields //3 and 4 are match type 
		for(int k=1;k<=192;k++){int m=1;int[] s={m,m+48,m+96,m+144}; if(Contains(s,k)){ 
				Week[k].fixture[1].colour=bluish;Week[k].fixture[1].category="clubs";
				Week[k].fixture[1].name="Community Shield";Week[k].fixture[1].kind="communityshield";
				Week[k].fixture[1].stage="final";Week[k].fixture[1].type="knockout";
				Week[k].fixture[1].category="clubs";
				Week[k].fixture[1].match[1].team1=PLcommunityshield[1];
				Week[k].fixture[1].match[1].team2=PLcommunityshield[2];

				Week[k].fixture[liga1].colour=bluish;
				Week[k].fixture[liga1].name="Spanish Super Cup";Week[k].fixture[liga1].kind="communityshield";
				Week[k].fixture[liga1].stage="final";Week[k].fixture[liga1].type="knockout";
				Week[k].fixture[liga1].match[1].team1=LLcommunityshield[1];
				Week[k].fixture[liga1].match[1].team2=LLcommunityshield[2];
				Week[k].fixture[liga1].category="clubs";
				Week[k].fixture[seriea1].colour=bluish;
				Week[k].fixture[seriea1].name="Italian Super Cup";Week[k].fixture[seriea1].kind="communityshield";
				Week[k].fixture[seriea1].stage="final";Week[k].fixture[seriea1].type="knockout";
				Week[k].fixture[seriea1].match[1].team1=SAcommunityshield[1];
				Week[k].fixture[seriea1].match[1].team2=SAcommunityshield[2];
				Week[k].fixture[seriea1].category="clubs";
				Week[k].fixture[bundes1].colour=bluish;
				Week[k].fixture[bundes1].name="German Super Cup";Week[k].fixture[bundes1].kind="communityshield";
				Week[k].fixture[bundes1].stage="final";Week[k].fixture[bundes1].type="knockout";
				Week[k].fixture[bundes1].match[1].team1=BLcommunityshield[1];
				Week[k].fixture[bundes1].match[1].team2=BLcommunityshield[2];
				Week[k].fixture[bundes1].category="clubs";}}
		//--------------------------------------------------------------------------------------------------
		if(global.category=="countries"){
			Week[1].fixture[2].colour=bluish;
			Week[1].fixture[2].name="Friendly";Week[1].fixture[2].kind="friendly";
			Week[1].fixture[2].match[1].team1=Friendly[1,1];  //14 friendlies in 4 years
			Week[1].fixture[2].match[1].team2=Friendly[1,2];
			Week[1].fixture[2].category="countries";}
		////////////////////////////euro vase/////////////////////////////////////////////////////////////////
		for(int k=1;k<=192;k++){int m=1;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[1].fixture[3].match[1].team1=EUROVase[1];
				Week[1].fixture[3].match[1].team2=EUROVase[2];
				Week[1].fixture[3].colour=greenish;Week[1].fixture[3].type="knockout";
				Week[1].fixture[3].name="Euro Vase";Week[1].fixture[3].kind="eurovase";
				Week[1].fixture[3].category="clubs";}}
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		// -------------premier league fixtures ------------------------------
		for(int k=2;k<=192;k++){int m=2;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[1].match[1].team1=plmatches[2,0,team1];  //[week,pair,team]
				Week[k].fixture[1].match[1].team2=plmatches[2,0,team2];
				Week[k].fixture[1].match[2].team1=plmatches[2,1,team1];
				Week[k].fixture[1].match[2].team2=plmatches[2,1,team2];
				Week[k].fixture[1].match[3].team1=plmatches[2,2,team1];
				Week[k].fixture[1].match[3].team2=plmatches[2,2,team2];
				Week[k].fixture[1].match[4].team1=plmatches[2,3,team1];
				Week[k].fixture[1].match[4].team2=plmatches[2,3,team2];
				Week[k].fixture[1].match[5].team1=plmatches[2,4,team1];
				Week[k].fixture[1].match[5].team2=plmatches[2,4,team2];
				Week[k].fixture[1].match[6].team1=plmatches[2,5,team1];
				Week[k].fixture[1].match[6].team2=plmatches[2,5,team2];
				Week[k].fixture[1].match[7].team1=plmatches[2,6,team1];
				Week[k].fixture[1].match[7].team2=plmatches[2,6,team2];
				Week[k].fixture[1].match[8].team1=plmatches[2,7,team1];
				Week[k].fixture[1].match[8].team2=plmatches[2,7,team2];
				Week[k].fixture[1].match[9].team1=plmatches[2,8,team1];
				Week[k].fixture[1].match[9].team2=plmatches[2,8,team2];
				Week[k].fixture[1].colour=generic;
				Week[k].fixture[1].name="Premier League";Week[k].fixture[1].kind="premierleague";
				Week[k].fixture[1].type="league"; Week[k].fixture[1].category="clubs";
				///////////////////////////////////////////la liga///////////////////////////////////////////////////////////////
				Week[k].fixture[liga1].match[1].team1=llmatches[2,0,team1];  //[week,pair,team]
				Week[k].fixture[liga1].match[1].team2=llmatches[2,0,team2];
				Week[k].fixture[liga1].match[2].team1=llmatches[2,1,team1];
				Week[k].fixture[liga1].match[2].team2=llmatches[2,1,team2];
				Week[k].fixture[liga1].match[3].team1=llmatches[2,2,team1];
				Week[k].fixture[liga1].match[3].team2=llmatches[2,2,team2];
				Week[k].fixture[liga1].match[4].team1=llmatches[2,3,team1];
				Week[k].fixture[liga1].match[4].team2=llmatches[2,3,team2];
				Week[k].fixture[liga1].match[5].team1=llmatches[2,4,team1];
				Week[k].fixture[liga1].match[5].team2=llmatches[2,4,team2];
				Week[k].fixture[liga1].match[6].team1=llmatches[2,5,team1];
				Week[k].fixture[liga1].match[6].team2=llmatches[2,5,team2];
				Week[k].fixture[liga1].match[7].team1=llmatches[2,6,team1];
				Week[k].fixture[liga1].match[7].team2=llmatches[2,6,team2];
				Week[k].fixture[liga1].match[8].team1=llmatches[2,7,team1];
				Week[k].fixture[liga1].match[8].team2=llmatches[2,7,team2];
				Week[k].fixture[liga1].colour=generic;
				Week[k].fixture[liga1].name="La Liga";Week[k].fixture[liga1].kind="laliga";
				Week[k].fixture[liga1].type="league";Week[k].fixture[liga1].category="clubs";
				//////////////////////liga/////////////////////serie a///////////////////////////////////////////////////////////////
				Week[k].fixture[seriea1].match[1].team1=samatches[2,0,team1];  //[week,pair,team]
				Week[k].fixture[seriea1].match[1].team2=samatches[2,0,team2];
				Week[k].fixture[seriea1].match[2].team1=samatches[2,1,team1];
				Week[k].fixture[seriea1].match[2].team2=samatches[2,1,team2];
				Week[k].fixture[seriea1].match[3].team1=samatches[2,2,team1];
				Week[k].fixture[seriea1].match[3].team2=samatches[2,2,team2];
				Week[k].fixture[seriea1].match[4].team1=samatches[2,3,team1];
				Week[k].fixture[seriea1].match[4].team2=samatches[2,3,team2];
				Week[k].fixture[seriea1].match[5].team1=samatches[2,4,team1];
				Week[k].fixture[seriea1].match[5].team2=samatches[2,4,team2];
				Week[k].fixture[seriea1].match[6].team1=samatches[2,5,team1];
				Week[k].fixture[seriea1].match[6].team2=samatches[2,5,team2];
				Week[k].fixture[seriea1].match[7].team1=samatches[2,6,team1];
				Week[k].fixture[seriea1].match[7].team2=samatches[2,6,team2];
				Week[k].fixture[seriea1].match[8].team1=samatches[2,7,team1];
				Week[k].fixture[seriea1].match[8].team2=samatches[2,7,team2];
				Week[k].fixture[seriea1].colour=generic;
				Week[k].fixture[seriea1].name="Serie A";Week[k].fixture[seriea1].kind="seriea";
				Week[k].fixture[seriea1].type="league";Week[k].fixture[seriea1].category="clubs";
				/////////////////////////////bundesliga///////////////////////////////////////////////////////////////
				Week[k].fixture[bundes1].match[1].team1=blmatches[2,0,team1];  //[week,pair,team]
				Week[k].fixture[bundes1].match[1].team2=blmatches[2,0,team2];
				Week[k].fixture[bundes1].match[2].team1=blmatches[2,1,team1];
				Week[k].fixture[bundes1].match[2].team2=blmatches[2,1,team2];
				Week[k].fixture[bundes1].match[3].team1=blmatches[2,2,team1];
				Week[k].fixture[bundes1].match[3].team2=blmatches[2,2,team2];
				Week[k].fixture[bundes1].match[4].team1=blmatches[2,3,team1];
				Week[k].fixture[bundes1].match[4].team2=blmatches[2,3,team2];
				Week[k].fixture[bundes1].match[5].team1=blmatches[2,4,team1];
				Week[k].fixture[bundes1].match[5].team2=blmatches[2,4,team2];
				Week[k].fixture[bundes1].match[6].team1=blmatches[2,5,team1];
				Week[k].fixture[bundes1].match[6].team2=blmatches[2,5,team2];
				Week[k].fixture[bundes1].match[7].team1=blmatches[2,6,team1];
				Week[k].fixture[bundes1].match[7].team2=blmatches[2,6,team2];
				Week[k].fixture[bundes1].match[8].team1=blmatches[2,7,team1];
				Week[k].fixture[bundes1].match[8].team2=blmatches[2,7,team2];
				Week[k].fixture[bundes1].colour=generic;
				Week[k].fixture[bundes1].name="Bundesliga";Week[k].fixture[bundes1].kind="bundesliga";
				Week[k].fixture[bundes1].type="league";Week[k].fixture[bundes1].category="clubs";}}
		/////////////////////////////////////league cip/////////////////////////////////////////////////////////////////
		for(int k=2;k<=192;k++){int m=2;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[2].match[1].team1=Leaguecup_round1[1,1];  //2 matches here 8 teams total
				Week[k].fixture[2].match[1].team2=Leaguecup_round1[1,2];
				Week[k].fixture[2].match[1].position=1;Week[k].fixture[2].match[1].group=1;
				Week[k].fixture[2].match[2].team1=Leaguecup_round1[2,1];
				Week[k].fixture[2].match[2].team2=Leaguecup_round1[2,2];
				Week[k].fixture[2].match[1].position=2;Week[k].fixture[2].match[1].group=1;
				Week[k].fixture[2].colour=pinkish;
				Week[k].fixture[2].name="League Cup";Week[k].fixture[2].kind="leaguecup";
				Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="quarterfinal";Week[k].fixture[2].category="clubs";}
		}
		/////////////////////////////////spanish cup/////////////////////////////////////////////////////////////////////
		for(int k=2;k<=192;k++){int m=2;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[liga2].match[1].team1=Spanishcup_round1[1,1];
				Week[k].fixture[liga2].match[1].team2=Spanishcup_round1[1,2];
				Week[k].fixture[liga2].match[1].position=1;Week[k].fixture[liga2].match[1].group=1;
				Week[k].fixture[liga2].match[2].team1=Spanishcup_round1[2,1];
				Week[k].fixture[liga2].match[2].team2=Spanishcup_round1[2,2];
				Week[k].fixture[liga2].match[2].position=2;Week[k].fixture[liga2].match[2].group=1;////////////////
				Week[k].fixture[liga2].match[3].team1=Spanishcup_round1[3,1];
				Week[k].fixture[liga2].match[3].team2=Spanishcup_round1[3,2];
				Week[k].fixture[liga2].match[3].position=1;Week[k].fixture[liga2].match[1].group=2;
				Week[k].fixture[liga2].match[4].team1=Spanishcup_round1[4,1];
				Week[k].fixture[liga2].match[4].team2=Spanishcup_round1[4,2];
				Week[k].fixture[liga2].match[4].position=2;Week[k].fixture[liga2].match[2].group=2;
				Week[k].fixture[liga2].colour=pinkish;
				Week[k].fixture[liga2].name="Spanish Cup";Week[k].fixture[liga2].kind="spanishcup";
				Week[k].fixture[liga2].type="knockout";Week[k].fixture[liga2].stage="roundof16";Week[k].fixture[liga2].category="clubs";}}
		//////////////////////////////////italian cup/////////////////////////////////////////////////////
		for(int k=2;k<=192;k++){int m=2;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[seriea2].match[1].team1=Italiancup_round1[1,1];
				Week[k].fixture[seriea2].match[1].team2=Italiancup_round1[1,2];
				Week[k].fixture[seriea2].match[1].position=1;Week[k].fixture[seriea2].match[1].group=1;
				Week[k].fixture[seriea2].match[2].team1=Italiancup_round1[2,1];
				Week[k].fixture[seriea2].match[2].team2=Italiancup_round1[2,2];
				Week[k].fixture[seriea2].match[2].position=2;Week[k].fixture[seriea2].match[2].group=1;
				Week[k].fixture[seriea2].match[3].team1=Italiancup_round1[3,1];
				Week[k].fixture[seriea2].match[3].team2=Italiancup_round1[3,2];
				Week[k].fixture[seriea2].match[3].position=1;Week[k].fixture[seriea2].match[3].group=2;
				Week[k].fixture[seriea2].match[4].team1=Italiancup_round1[4,1];
				Week[k].fixture[seriea2].match[4].team2=Italiancup_round1[4,2];
				Week[k].fixture[seriea2].match[4].position=2;Week[k].fixture[seriea2].match[4].group=2;
				Week[k].fixture[seriea2].colour=pinkish;
				Week[k].fixture[seriea2].name="Italian Cup";Week[k].fixture[seriea2].kind="italiancup";
				Week[k].fixture[seriea2].type="knockout";Week[k].fixture[seriea2].stage="roundof16";Week[k].fixture[seriea2].category="clubs";}}
		////////////////////////////German cup///////////////////////////////////////////////////////////
		for(int k=2;k<=192;k++){int m=2;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[bundes2].match[1].team1=Germancup_round1[1,1];
				Week[k].fixture[bundes2].match[1].team2=Germancup_round1[1,2];
				Week[k].fixture[bundes2].match[1].position=1;Week[k].fixture[bundes2].match[1].group=1;
				Week[k].fixture[bundes2].match[2].team1=Germancup_round1[2,1];
				Week[k].fixture[bundes2].match[2].team2=Germancup_round1[2,2];
				Week[k].fixture[bundes2].match[2].position=2;Week[k].fixture[bundes2].match[2].group=1;
				Week[k].fixture[bundes2].match[3].team1=Germancup_round1[3,1];
				Week[k].fixture[bundes2].match[3].team2=Germancup_round1[3,2];
				Week[k].fixture[bundes2].match[3].position=1;Week[k].fixture[bundes2].match[1].group=2;
				Week[k].fixture[bundes2].match[4].team1=Germancup_round1[4,1];
				Week[k].fixture[bundes2].match[4].team2=Germancup_round1[4,2];
				Week[k].fixture[bundes2].match[4].position=2;Week[k].fixture[bundes2].match[2].group=2;
				Week[k].fixture[bundes2].colour=pinkish;
				Week[k].fixture[bundes2].name="German Cup";Week[k].fixture[bundes2].kind="germancup";
				Week[k].fixture[bundes2].type="knockout";Week[k].fixture[bundes2].stage="roundof16";Week[k].fixture[bundes2].category="clubs";}}
		/////////////////////////////////////////////////////////////////////////////////////////////
		int j=3;  // matches now start from index 1
		for (int t=0;t<=3;t++){ if(t>0)j=3;   //j in sync with week
			for(int i=3+(48*t);i<=44+(48*t);i++){  if(i==25+(48*t))j=2; // now reset to replay same fixtures reversed after 22 j is out of sync
				int[] s={3+(48*t),4+(48*t),5+(48*t),7+(48*t),8+(48*t),9+(48*t),11+(48*t),12+(48*t),13+(48*t),14+(48*t),15+(48*t),16+(48*t),17+(48*t),19+(48*t),20+(48*t),21+(48*t)};
				if( Contains(s,i) ){
					// -------------premier league fixtures ------------------------------
					Week[i].fixture[1].match[1].team1=plmatches[j,0,team1];  //[week,pair,team]
					Week[i].fixture[1].match[1].team2=plmatches[j,0,team2];
					Week[i].fixture[1].match[2].team1=plmatches[j,1,team1];
					Week[i].fixture[1].match[2].team2=plmatches[j,1,team2];
					Week[i].fixture[1].match[3].team1=plmatches[j,2,team1];
					Week[i].fixture[1].match[3].team2=plmatches[j,2,team2];
					Week[i].fixture[1].match[4].team1=plmatches[j,3,team1];
					Week[i].fixture[1].match[4].team2=plmatches[j,3,team2];
					Week[i].fixture[1].match[5].team1=plmatches[j,4,team1];
					Week[i].fixture[1].match[5].team2=plmatches[j,4,team2];
					Week[i].fixture[1].match[6].team1=plmatches[j,5,team1];
					Week[i].fixture[1].match[6].team2=plmatches[j,5,team2];
					Week[i].fixture[1].match[7].team1=plmatches[j,6,team1];
					Week[i].fixture[1].match[7].team2=plmatches[j,6,team2];
					Week[i].fixture[1].match[8].team1=plmatches[j,7,team1];
					Week[i].fixture[1].match[8].team2=plmatches[j,7,team2];
					Week[i].fixture[1].match[9].team1=plmatches[j,8,team1];
					Week[i].fixture[1].match[9].team2=plmatches[j,8,team2];
					Week[i].fixture[1].colour=generic;
					Week[i].fixture[1].name="Premier League";Week[i].fixture[1].kind="premierleague";
					Week[i].fixture[1].type="league";Week[i].fixture[1].category="clubs";
					///////////////////////////////////////////la liga///////////////////////////////////////////////////////////////
					if(i>=3+(48*t) && i<=19+(48*t) ){ 
						Week[i].fixture[liga1].match[1].team1=llmatches[j,0,team1];  //[week,pair,team]
						Week[i].fixture[liga1].match[1].team2=llmatches[j,0,team2];
						Week[i].fixture[liga1].match[2].team1=llmatches[j,1,team1];
						Week[i].fixture[liga1].match[2].team2=llmatches[j,1,team2];
						Week[i].fixture[liga1].match[3].team1=llmatches[j,2,team1];
						Week[i].fixture[liga1].match[3].team2=llmatches[j,2,team2];
						Week[i].fixture[liga1].match[4].team1=llmatches[j,3,team1];
						Week[i].fixture[liga1].match[4].team2=llmatches[j,3,team2];
						Week[i].fixture[liga1].match[5].team1=llmatches[j,4,team1];
						Week[i].fixture[liga1].match[5].team2=llmatches[j,4,team2];
						Week[i].fixture[liga1].match[6].team1=llmatches[j,5,team1];
						Week[i].fixture[liga1].match[6].team2=llmatches[j,5,team2];
						Week[i].fixture[liga1].match[7].team1=llmatches[j,6,team1];
						Week[i].fixture[liga1].match[7].team2=llmatches[j,6,team2];
						Week[i].fixture[liga1].match[8].team1=llmatches[j,7,team1];
						Week[i].fixture[liga1].match[8].team2=llmatches[j,7,team2];
						Week[i].fixture[liga1].colour=generic;
						Week[i].fixture[liga1].name="La Liga";Week[i].fixture[liga1].kind="laliga";
						Week[i].fixture[liga1].type="league";Week[i].fixture[liga1].category="clubs";
						//////////////////////liga/////////////////////serie a///////////////////////////////////////////////////////////////
						Week[i].fixture[seriea1].match[1].team1=samatches[j,0,team1];  //[week,pair,team]
						Week[i].fixture[seriea1].match[1].team2=samatches[j,0,team2];
						Week[i].fixture[seriea1].match[2].team1=samatches[j,1,team1];
						Week[i].fixture[seriea1].match[2].team2=samatches[j,1,team2];
						Week[i].fixture[seriea1].match[3].team1=samatches[j,2,team1];
						Week[i].fixture[seriea1].match[3].team2=samatches[j,2,team2];
						Week[i].fixture[seriea1].match[4].team1=samatches[j,3,team1];
						Week[i].fixture[seriea1].match[4].team2=samatches[j,3,team2];
						Week[i].fixture[seriea1].match[5].team1=samatches[j,4,team1];
						Week[i].fixture[seriea1].match[5].team2=samatches[j,4,team2];
						Week[i].fixture[seriea1].match[6].team1=samatches[j,5,team1];
						Week[i].fixture[seriea1].match[6].team2=samatches[j,5,team2];
						Week[i].fixture[seriea1].match[7].team1=samatches[j,6,team1];
						Week[i].fixture[seriea1].match[7].team2=samatches[j,6,team2];
						Week[i].fixture[seriea1].match[8].team1=samatches[j,7,team1];
						Week[i].fixture[seriea1].match[8].team2=samatches[j,7,team2];
						Week[i].fixture[seriea1].colour=generic;
						Week[i].fixture[seriea1].name="Serie A";Week[i].fixture[seriea1].kind="seriea";
						Week[i].fixture[seriea1].type="league";Week[i].fixture[seriea1].category="clubs";
						/////////////////////////////bundesliga///////////////////////////////////////////////////////////////
						Week[i].fixture[bundes1].match[1].team1=blmatches[j,0,team1];  //[week,pair,team]
						Week[i].fixture[bundes1].match[1].team2=blmatches[j,0,team2];
						Week[i].fixture[bundes1].match[2].team1=blmatches[j,1,team1];
						Week[i].fixture[bundes1].match[2].team2=blmatches[j,1,team2];
						Week[i].fixture[bundes1].match[3].team1=blmatches[j,2,team1];
						Week[i].fixture[bundes1].match[3].team2=blmatches[j,2,team2];
						Week[i].fixture[bundes1].match[4].team1=blmatches[j,3,team1];
						Week[i].fixture[bundes1].match[4].team2=blmatches[j,3,team2];
						Week[i].fixture[bundes1].match[5].team1=blmatches[j,4,team1];
						Week[i].fixture[bundes1].match[5].team2=blmatches[j,4,team2];
						Week[i].fixture[bundes1].match[6].team1=blmatches[j,5,team1];
						Week[i].fixture[bundes1].match[6].team2=blmatches[j,5,team2];
						Week[i].fixture[bundes1].match[7].team1=blmatches[j,6,team1];
						Week[i].fixture[bundes1].match[7].team2=blmatches[j,6,team2];
						Week[i].fixture[bundes1].match[8].team1=blmatches[j,7,team1];
						Week[i].fixture[bundes1].match[8].team2=blmatches[j,7,team2];
						Week[i].fixture[bundes1].colour=generic;
						Week[i].fixture[bundes1].name="Bundesliga";Week[i].fixture[bundes1].kind="bundesliga";
						Week[i].fixture[bundes1].type="league";Week[i].fixture[bundes1].category="clubs";
					}   
					/////////////////////////////////////league matches/////////////////////////////////////////////////////////////////
				} //correct week index
				if(i>=3+(48*t) && i<25+(48*t)) j++;// j here to  sync with week index before 25
				 int[] ss={25+(48*t),26+(48*t),27+(48*t),28+(48*t),29+(48*t),31+(48*t),32+(48*t),33+(48*t),34+(48*t),35+(48*t),36+(48*t),37+(48*t),39+(48*t),40+(48*t),41+(48*t),42+(48*t),43+(48*t)};
				if( Contains(ss,i)){ int v;
					if(i==43+(48*t)){ v=2;}else
						 v=1;
					Week[i].fixture[v].match[1].team1=plmatches[j,0,team2];  //fixture reversed for replays
					Week[i].fixture[v].match[1].team2=plmatches[j,0,team1];
					Week[i].fixture[v].match[2].team1=plmatches[j,1,team2];
					Week[i].fixture[v].match[2].team2=plmatches[j,1,team1];
					Week[i].fixture[v].match[3].team1=plmatches[j,2,team2];
					Week[i].fixture[v].match[3].team2=plmatches[j,2,team1];
					Week[i].fixture[v].match[4].team1=plmatches[j,3,team2];
					Week[i].fixture[v].match[4].team2=plmatches[j,3,team1];
					Week[i].fixture[v].match[5].team1=plmatches[j,4,team2];
					Week[i].fixture[v].match[5].team2=plmatches[j,4,team1];
					Week[i].fixture[v].match[6].team1=plmatches[j,5,team2];
					Week[i].fixture[v].match[6].team2=plmatches[j,5,team1];
					Week[i].fixture[v].match[7].team1=plmatches[j,6,team2];
					Week[i].fixture[v].match[7].team2=plmatches[j,6,team1];
					Week[i].fixture[v].match[8].team1=plmatches[j,7,team2];
					Week[i].fixture[v].match[8].team2=plmatches[j,7,team1];
					Week[i].fixture[v].match[9].team1=plmatches[j,8,team2];
					Week[i].fixture[v].match[9].team2=plmatches[j,8,team1];
					Week[i].fixture[v].colour=generic; //if(i==43) bug here
					Week[i].fixture[v].name="Premier League";Week[i].fixture[v].kind="premierleague";Week[i].fixture[v].category="clubs";  //bug fix
					Week[i].fixture[v].type="league";if(i==43+(48*t)){Week[i].fixture[v].stage="final";Week[i].fixture[v].match[9].stage="last";}

					if(i>=3+(48*t) && i<42+(48*t)){

						Week[i].fixture[liga1].match[1].team1=llmatches[j,0,team2];  //league matches repeat reversed
						Week[i].fixture[liga1].match[1].team2=llmatches[j,0,team1];
						Week[i].fixture[liga1].match[2].team1=llmatches[j,1,team2];
						Week[i].fixture[liga1].match[2].team2=llmatches[j,1,team1];
						Week[i].fixture[liga1].match[3].team1=llmatches[j,2,team2];
						Week[i].fixture[liga1].match[3].team2=llmatches[j,2,team1];
						Week[i].fixture[liga1].match[4].team1=llmatches[j,3,team2];
						Week[i].fixture[liga1].match[4].team2=llmatches[j,3,team1];
						Week[i].fixture[liga1].match[5].team1=llmatches[j,4,team2];
						Week[i].fixture[liga1].match[5].team2=llmatches[j,4,team1];
						Week[i].fixture[liga1].match[6].team1=llmatches[j,5,team2];
						Week[i].fixture[liga1].match[6].team2=llmatches[j,5,team1];
						Week[i].fixture[liga1].match[7].team1=llmatches[j,6,team2];
						Week[i].fixture[liga1].match[7].team2=llmatches[j,6,team1];
						Week[i].fixture[liga1].match[8].team1=llmatches[j,7,team2];
						Week[i].fixture[liga1].match[8].team2=llmatches[j,7,team1];
						Week[i].fixture[liga1].colour=generic;
						Week[i].fixture[liga1].name="La Liga";Week[i].fixture[liga1].kind="laliga";Week[i].fixture[liga1].category="clubs";
						Week[i].fixture[liga1].type="league";if(i==39){Week[i].fixture[liga1].stage="final";Week[i].fixture[liga1].match[8].stage="last";}

						//////////////////////liga/////////////////////serie a///////////////////////////////////////////////////////////////
						Week[i].fixture[seriea1].match[1].team1=samatches[j,0,team2];  //[week,pair,team]
						Week[i].fixture[seriea1].match[1].team2=samatches[j,0,team1];
						Week[i].fixture[seriea1].match[2].team1=samatches[j,1,team2];
						Week[i].fixture[seriea1].match[2].team2=samatches[j,1,team1];
						Week[i].fixture[seriea1].match[3].team1=samatches[j,2,team2];
						Week[i].fixture[seriea1].match[3].team2=samatches[j,2,team1];
						Week[i].fixture[seriea1].match[4].team1=samatches[j,3,team2];
						Week[i].fixture[seriea1].match[4].team2=samatches[j,3,team1];
						Week[i].fixture[seriea1].match[5].team1=samatches[j,4,team2];
						Week[i].fixture[seriea1].match[5].team2=samatches[j,4,team1];
						Week[i].fixture[seriea1].match[6].team1=samatches[j,5,team2];
						Week[i].fixture[seriea1].match[6].team2=samatches[j,5,team1];
						Week[i].fixture[seriea1].match[7].team1=samatches[j,6,team2];
						Week[i].fixture[seriea1].match[7].team2=samatches[j,6,team1];
						Week[i].fixture[seriea1].match[8].team1=samatches[j,7,team2];
						Week[i].fixture[seriea1].match[8].team2=samatches[j,7,team1];
						Week[i].fixture[seriea1].colour=generic;
						Week[i].fixture[seriea1].name="Serie A";Week[i].fixture[seriea1].kind="seriea";Week[i].fixture[seriea1].category="clubs";
						Week[i].fixture[seriea1].type="league";if(i==39){Week[i].fixture[seriea1].stage="final";Week[i].fixture[seriea1].match[8].stage="last";}
						/////////////////////////////bundesliga///////////////////////////////////////////////////////////////
						Week[i].fixture[bundes1].match[1].team1=blmatches[j,0,team2];  //[week,pair,team]
						Week[i].fixture[bundes1].match[1].team2=blmatches[j,0,team1];
						Week[i].fixture[bundes1].match[2].team1=blmatches[j,1,team2];
						Week[i].fixture[bundes1].match[2].team2=blmatches[j,1,team1];
						Week[i].fixture[bundes1].match[3].team1=blmatches[j,2,team2];
						Week[i].fixture[bundes1].match[3].team2=blmatches[j,2,team1];
						Week[i].fixture[bundes1].match[4].team1=blmatches[j,3,team2];
						Week[i].fixture[bundes1].match[4].team2=blmatches[j,3,team1];
						Week[i].fixture[bundes1].match[5].team1=blmatches[j,4,team2];
						Week[i].fixture[bundes1].match[5].team2=blmatches[j,4,team1];
						Week[i].fixture[bundes1].match[6].team1=blmatches[j,5,team2];
						Week[i].fixture[bundes1].match[6].team2=blmatches[j,5,team1];
						Week[i].fixture[bundes1].match[7].team1=blmatches[j,6,team2];
						Week[i].fixture[bundes1].match[7].team2=blmatches[j,6,team1];
						Week[i].fixture[bundes1].match[8].team1=blmatches[j,7,team2];
						Week[i].fixture[bundes1].match[8].team2=blmatches[j,7,team1];
						Week[i].fixture[bundes1].colour=generic;
						Week[i].fixture[bundes1].name="Bundesliga";Week[i].fixture[bundes1].kind="bundesliga";Week[i].fixture[bundes1].category="clubs";
						Week[i].fixture[bundes1].type="league";if(i==39){Week[i].fixture[bundes1].stage="final";Week[i].fixture[bundes1].match[8].stage="last";} 
					}//loc array
					j++; if(j==6 || j==10 || j==18)j++;   //now that j is out of sync it should skip to 1st round indexes but reversed
				}//2nd array
				//if(j==6 || j==10 || j==18)j++;  <- not necessary
			}                                               }//t
		/////////////////////////////////week3////////////////////////////////////////////////////////////////////////
		if(global.category=="countries"){
			Week[3].fixture[2].match[1].team1=Friendly[2,1];  //14 friendlies in 4 years
			Week[3].fixture[2].match[1].team2=Friendly[2,2];
			Week[3].fixture[2].colour=bluish;Week[3].fixture[2].category="countries";
			Week[3].fixture[2].name="Friendly";Week[3].fixture[2].kind="friendly";}
		////////////////////////////champions league////////////////////////////////////////////////////////////////////////
		for(int k=3;k<=192;k++){int m=3;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].colour=violet;
				Week[k].fixture[3].match[1].team1=Championsleague_group[1,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[1,2];
				Week[k].fixture[3].match[2].team1=Championsleague_group[1,3];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[1,4];
				Week[k].fixture[3].match[3].team1=Championsleague_group[2,1];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[2,2];
				Week[k].fixture[3].match[4].team1=Championsleague_group[2,3];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[2,4];
				Week[k].fixture[3].match[5].team1=Championsleague_group[3,1];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[3,2];
				Week[k].fixture[3].match[6].team1=Championsleague_group[3,3];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[3,4];
				Week[k].fixture[3].match[7].team1=Championsleague_group[4,1];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[4,2];
				Week[k].fixture[3].match[8].team1=Championsleague_group[4,3];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[4,4];
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		/////////////////////////////////////league cip/////////////////////////////////////////////////////////////////
		for(int k=4;k<=192;k++){int m=4;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[2].match[1].team1=Leaguecup_round1[3,1];  //2 matches here 8 teams total
				Week[k].fixture[2].match[1].team2=Leaguecup_round1[3,2];  //8 groups of 4
				Week[k].fixture[2].match[3].position=1;Week[k].fixture[2].match[3].group=2;
				Week[k].fixture[2].match[2].team1=Leaguecup_round1[4,1];
				Week[k].fixture[2].match[2].team2=Leaguecup_round1[4,2];
				Week[k].fixture[2].match[4].position=2;Week[k].fixture[2].match[4].group=2;
				Week[k].fixture[2].colour=pinkish;
				Week[k].fixture[2].name="League Cup";Week[k].fixture[2].kind="leaguecup";Week[k].fixture[2].category="clubs";
				Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="quarterfinal";
				////////////////////////////////////////////////////////////////////////////////////////////////////////////
				Week[k].fixture[liga2].match[1].team1=Spanishcup_round1[5,1];
				Week[k].fixture[liga2].match[1].team2=Spanishcup_round1[5,2];
				Week[k].fixture[liga2].match[1].position=1;Week[k].fixture[liga2].match[3].group=3;
				Week[k].fixture[liga2].match[2].team1=Spanishcup_round1[6,1];
				Week[k].fixture[liga2].match[2].team2=Spanishcup_round1[6,2];
				Week[k].fixture[liga2].match[2].position=2;Week[k].fixture[liga2].match[4].group=3;
				Week[k].fixture[liga2].match[3].team1=Spanishcup_round1[7,1];
				Week[k].fixture[liga2].match[3].team2=Spanishcup_round1[7,2];
				Week[k].fixture[liga2].match[3].position=1;Week[k].fixture[liga2].match[1].group=4;
				Week[k].fixture[liga2].match[4].team1=Spanishcup_round1[8,1];
				Week[k].fixture[liga2].match[4].team2=Spanishcup_round1[8,2];
				Week[k].fixture[liga2].match[4].position=2;Week[k].fixture[liga2].match[2].group=4;
				Week[k].fixture[liga2].colour=pinkish;
				Week[k].fixture[liga2].name="Spanish Cup";Week[k].fixture[liga2].kind="spanishcup";
				Week[k].fixture[liga2].type="knockout";Week[k].fixture[liga2].stage="roundof16";Week[k].fixture[liga2].category="clubs";
				/////////////////////////////////////////////////////////////////////////////////////////////
				Week[k].fixture[seriea2].match[1].team1=Italiancup_round1[5,1];
				Week[k].fixture[seriea2].match[1].team2=Italiancup_round1[5,2];
				Week[k].fixture[seriea2].match[1].position=1;Week[k].fixture[seriea2].match[1].group=3;
				Week[k].fixture[seriea2].match[2].team1=Italiancup_round1[6,1];
				Week[k].fixture[seriea2].match[2].team2=Italiancup_round1[6,2];
				Week[k].fixture[seriea2].match[2].position=2;Week[k].fixture[seriea2].match[2].group=3;
				Week[k].fixture[seriea2].match[3].team1=Italiancup_round1[7,1];
				Week[k].fixture[seriea2].match[3].team2=Italiancup_round1[7,2];
				Week[k].fixture[seriea2].match[3].position=1;Week[k].fixture[seriea2].match[3].group=4;
				Week[k].fixture[seriea2].match[4].team1=Italiancup_round1[8,1];
				Week[k].fixture[seriea2].match[4].team2=Italiancup_round1[8,2];
				Week[k].fixture[seriea2].match[4].position=2;Week[k].fixture[seriea2].match[4].group=4;
				Week[k].fixture[seriea2].colour=pinkish;
				Week[k].fixture[seriea2].name="Italian Cup";Week[k].fixture[seriea2].kind="italiancup";
				Week[k].fixture[seriea2].type="knockout";Week[k].fixture[seriea2].stage="roundof16";Week[k].fixture[seriea2].category="clubs";
				/////////////////////////////////////////////////////////////////////////////////////////////
				Week[k].fixture[bundes2].match[1].team1=Germancup_round1[5,1];
				Week[k].fixture[bundes2].match[1].team2=Germancup_round1[5,2];
				Week[k].fixture[bundes2].match[1].position=1;Week[k].fixture[bundes2].match[1].group=3;
				Week[k].fixture[bundes2].match[2].team1=Germancup_round1[6,1];
				Week[k].fixture[bundes2].match[2].team2=Germancup_round1[6,2];
				Week[k].fixture[bundes2].match[2].position=2;Week[k].fixture[bundes2].match[2].group=3;
				Week[k].fixture[bundes2].match[3].team1=Germancup_round1[7,1];
				Week[k].fixture[bundes2].match[3].team2=Germancup_round1[7,2];
				Week[k].fixture[bundes2].match[3].position=1;Week[k].fixture[bundes2].match[3].group=4;
				Week[k].fixture[bundes2].match[4].team1=Germancup_round1[8,1];
				Week[k].fixture[bundes2].match[4].team2=Germancup_round1[8,2];
				Week[k].fixture[bundes2].match[4].position=2;Week[k].fixture[bundes2].match[4].group=4;
				Week[k].fixture[bundes2].colour=pinkish;
				Week[k].fixture[bundes2].name="German Cup";Week[k].fixture[bundes2].kind="germancup";
				Week[k].fixture[bundes2].type="knockout";Week[k].fixture[bundes2].stage="roundof16";Week[k].fixture[bundes2].category="clubs";
				//////////////////////////////uefa cup//////////////////////////////////////////////////////////
				Week[k].fixture[3].colour=yellowish;
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,2];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,4];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,2];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,4];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,2];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,4];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,2];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,4];
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";Week[k].fixture[3].category="clubs"; //error fix
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		//////////////////////////////////week5///////////////////////////////////////////////////////////[6]/////////////
		///////////////////////////////world cup qualifying africa////////////////////////////////////////////////////////////// 
		Week[5].fixture[africa2].colour=pinkish;Week[5].fixture[africa2].name="World Cup Qualifying";Week[5].fixture[africa2].kind="WCQafrica";
		Week[5].fixture[africa2].type="knockout";  //should tell simulator that a winner is needed
		Week[5].fixture[africa2].match[1].team1=WCQualifier_playoff[19,1];
		Week[5].fixture[africa2].match[1].team2=WCQualifier_playoff[19,2];
		Week[5].fixture[africa2].match[1].position=1;
		Week[5].fixture[africa2].match[2].team1=WCQualifier_playoff[20,1];
		Week[5].fixture[africa2].match[2].team2=WCQualifier_playoff[20,2];
		Week[5].fixture[africa2].match[2].position=2;
		Week[5].fixture[africa2].match[3].team1=WCQualifier_playoff[21,1];
		Week[5].fixture[africa2].match[3].team2=WCQualifier_playoff[21,2];
		Week[5].fixture[africa2].match[3].position=3;
		Week[5].fixture[africa2].match[4].team1=WCQualifier_playoff[22,1];
		Week[5].fixture[africa2].match[4].team2=WCQualifier_playoff[22,2];
		Week[5].fixture[africa2].match[4].position=4;
		Week[5].fixture[africa2].match[5].team1=WCQualifier_playoff[23,1];
		Week[5].fixture[africa2].match[5].team2=WCQualifier_playoff[23,2];
		Week[5].fixture[africa2].match[5].position=5;
		Week[5].fixture[africa2].match[6].team1=WCQualifier_playoff[24,1];
		Week[5].fixture[africa2].match[6].team2=WCQualifier_playoff[24,2];
		Week[5].fixture[africa2].match[6].position=6;
		Week[5].fixture[africa2].match[7].team1=WCQualifier_playoff[25,1];
		Week[5].fixture[africa2].match[7].team2=WCQualifier_playoff[25,2];
		Week[5].fixture[africa2].match[7].stage="notlast";Week[5].fixture[africa2].category="countries";
		//////////////////////////////world cup qualifying asia///////////////////////////////////////////////////////////////////////
		////////////////////////////////club world cup////////////////////////////////////////////////////////////////////////
		for(int k=5;k<=192;k++){ int m=5;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[2].colour=greenish;     //94 95 96
				Week[k].fixture[2].name="Club World Cup";Week[k].fixture[2].kind="cwc";
				Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="semifinal";
				Week[k].fixture[2].match[1].team1=CWC_semi[1,1];
				Week[k].fixture[2].match[1].team2=CWC_semi[1,2];
				Week[k].fixture[2].match[1].position=1;
				Week[k].fixture[2].match[2].team1=CWC_semi[2,1];
				Week[k].fixture[2].match[2].team2=CWC_semi[2,2];
				Week[k].fixture[2].match[2].position=2;Week[k].fixture[2].category="clubs";}}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////
		for(int k=6;k<=192;k++){int m=6;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[1].colour=greenish;     //94 95 96
				Week[k].fixture[1].name="Club World Cup";Week[k].fixture[1].kind="cwc";
				Week[k].fixture[1].type="knockout";Week[k].fixture[1].stage="final";
				Week[k].fixture[1].match[1].team1=CWC_final[1];
				Week[k].fixture[1].match[1].team2=CWC_final[2];Week[k].fixture[1].category="clubs";}}
		/////////////////////////////////////world cup qualifiers eu////////////////////////////////////////////////////////////////
		Week[6].fixture[2].colour=pinkish;Week[6].fixture[2].name="World Cup Qualifying";Week[6].fixture[2].kind="WCQeurope";
		Week[6].fixture[2].type="league";Week[6].fixture[2].colour=bluish;Week[6].fixture[2].category="countries"; Week[6].fixture[2].stage="group";                //7 groups of 6
		Week[6].fixture[2].match[1].team1=WCQualifier_eu_group[1,1]; //group 1 team 1
		Week[6].fixture[2].match[1].team2=WCQualifier_eu_group[1,2];
		Week[6].fixture[2].match[2].team1=WCQualifier_eu_group[1,3]; 
		Week[6].fixture[2].match[2].team2=WCQualifier_eu_group[1,4];
		Week[6].fixture[2].match[3].team1=WCQualifier_eu_group[1,5]; 
		Week[6].fixture[2].match[3].team2=WCQualifier_eu_group[1,6];
		Week[6].fixture[2].match[4].team1=WCQualifier_eu_group[2,1]; 
		Week[6].fixture[2].match[4].team2=WCQualifier_eu_group[2,2];
		Week[6].fixture[2].match[5].team1=WCQualifier_eu_group[2,3]; 
		Week[6].fixture[2].match[5].team2=WCQualifier_eu_group[2,4];
		Week[6].fixture[2].match[6].team1=WCQualifier_eu_group[2,5]; 
		Week[6].fixture[2].match[6].team2=WCQualifier_eu_group[2,6];
		Week[6].fixture[2].match[7].team1=WCQualifier_eu_group[3,1]; 
		Week[6].fixture[2].match[7].team2=WCQualifier_eu_group[3,2];
		Week[6].fixture[2].match[8].team1=WCQualifier_eu_group[3,3]; 
		Week[6].fixture[2].match[8].team2=WCQualifier_eu_group[3,4];
		Week[6].fixture[2].match[9].team1=WCQualifier_eu_group[3,5]; 
		Week[6].fixture[2].match[9].team2=WCQualifier_eu_group[3,6];
		///////////////////////////////world cup qualifying africa////////////////////////////////////////////////////////////// 
		Week[6].fixture[africa2].colour=pinkish;Week[6].fixture[africa2].name="World Cup Qualifying";Week[6].fixture[africa2].kind="WCQafrica";
		Week[6].fixture[africa2].type="knockout";
		Week[6].fixture[africa2].match[1].team1=WCQualifier_playoff[1,1];
		Week[6].fixture[africa2].match[1].team2=WCQualifier_playoff[1,2];
		Week[6].fixture[africa2].match[1].position=1;
		Week[6].fixture[africa2].match[2].team1=WCQualifier_playoff[2,1];
		Week[6].fixture[africa2].match[2].team2=WCQualifier_playoff[2,2];
		Week[6].fixture[africa2].match[2].position=2;
		Week[6].fixture[africa2].match[3].team1=WCQualifier_playoff[3,1];
		Week[6].fixture[africa2].match[3].team2=WCQualifier_playoff[3,2];
		Week[6].fixture[africa2].match[3].position=3;
		Week[6].fixture[africa2].match[4].team1=WCQualifier_playoff[4,1];
		Week[6].fixture[africa2].match[4].team2=WCQualifier_playoff[4,2];
		Week[6].fixture[africa2].match[4].position=4;
		Week[6].fixture[africa2].match[5].team1=WCQualifier_playoff[5,1];
		Week[6].fixture[africa2].match[5].team2=WCQualifier_playoff[5,2];
		Week[6].fixture[africa2].match[5].position=5;
		Week[6].fixture[africa2].match[6].team1=WCQualifier_playoff[6,1];
		Week[6].fixture[africa2].match[6].team2=WCQualifier_playoff[6,2];
		Week[6].fixture[africa2].match[6].position=6;
		Week[6].fixture[africa2].match[7].team1=WCQualifier_playoff[7,1];
		Week[6].fixture[africa2].match[7].team2=WCQualifier_playoff[7,2];
		Week[6].fixture[africa2].match[7].position=7;
		Week[6].fixture[africa2].match[8].team1=WCQualifier_playoff[8,1];
		Week[6].fixture[africa2].match[8].team2=WCQualifier_playoff[8,2];
		Week[6].fixture[africa2].match[8].position=8;
		Week[6].fixture[africa2].match[9].team1=WCQualifier_playoff[9,1];
		Week[6].fixture[africa2].match[9].team2=WCQualifier_playoff[9,2];
		Week[6].fixture[africa2].match[9].stage="notlast";Week[6].fixture[africa2].category="countries";
		//////////////////////////////world cup qualifying asia///////////////////////////////////////////////////////////////////////
		Week[6].fixture[asia2].colour=pinkish;Week[6].fixture[asia2].name="World Cup Qualifying";Week[6].fixture[asia2].kind="WCQasia";
		Week[6].fixture[asia2].type="group";Week[6].fixture[asia2].category="countries";Week[6].fixture[asia2].stage="group";
		Week[6].fixture[asia2].match[1].team1=WCQualifier_as_group[1,1];  //4 groups of 5
		Week[6].fixture[asia2].match[1].team2=WCQualifier_as_group[1,2]; 
		Week[6].fixture[asia2].match[2].team1=WCQualifier_as_group[1,3];  
		Week[6].fixture[asia2].match[2].team2=WCQualifier_as_group[1,4];
		Week[6].fixture[asia2].match[3].team1=WCQualifier_as_group[2,1];  
		Week[6].fixture[asia2].match[3].team2=WCQualifier_as_group[2,2];
		Week[6].fixture[asia2].match[4].team1=WCQualifier_as_group[2,3];  
		Week[6].fixture[asia2].match[4].team2=WCQualifier_as_group[2,4];
		Week[6].fixture[asia2].match[5].team1=WCQualifier_as_group[3,1];  
		Week[6].fixture[asia2].match[5].team2=WCQualifier_as_group[3,2];
		Week[6].fixture[asia2].match[6].team1=WCQualifier_as_group[3,3];  
		Week[6].fixture[asia2].match[6].team2=WCQualifier_as_group[3,4];
		Week[6].fixture[asia2].match[7].team1=WCQualifier_as_group[4,1];  
		Week[6].fixture[asia2].match[7].team2=WCQualifier_as_group[4,2];
		Week[6].fixture[asia2].match[8].team1=WCQualifier_as_group[4,3];  
		Week[6].fixture[asia2].match[8].team2=WCQualifier_as_group[4,4];
		//////////////////////////////////////world cup qualifying north america///////////////////////////////////////////////////////////////
		Week[6].fixture[northamerica2].colour=pinkish;Week[6].fixture[northamerica2].name="World Cup Qualifying";
		Week[6].fixture[northamerica2].kind="WCQnorthamerica";Week[6].fixture[northamerica2].category="countries";
		Week[6].fixture[northamerica2].type="league";
		Week[6].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
		Week[6].fixture[northamerica2].match[1].team2= WCQualifier_na_group[2];
		Week[6].fixture[northamerica2].match[2].team1= WCQualifier_na_group[3];
		Week[6].fixture[northamerica2].match[2].team2= WCQualifier_na_group[4];
		Week[6].fixture[northamerica2].match[3].team1= WCQualifier_na_group[5];
		Week[6].fixture[northamerica2].match[3].team2= WCQualifier_na_group[6];
		Week[6].fixture[northamerica2].match[4].team1= WCQualifier_na_group[7];
		Week[6].fixture[northamerica2].match[4].team2= WCQualifier_na_group[8];
		Week[6].fixture[northamerica2].match[5].team1= WCQualifier_na_group[9];
		Week[6].fixture[northamerica2].match[5].team2= WCQualifier_na_group[10];
		Week[6].fixture[northamerica2].match[6].team1= WCQualifier_na_group[11];
		Week[6].fixture[northamerica2].match[6].team2= WCQualifier_na_group[12];
		Week[6].fixture[northamerica2].match[7].team1= WCQualifier_na_group[12];
		Week[6].fixture[northamerica2].match[7].team2= WCQualifier_na_group[14];
		Week[6].fixture[northamerica2].match[8].team1= WCQualifier_na_group[15];
		Week[6].fixture[northamerica2].match[8].team2= WCQualifier_na_group[16];
		Week[6].fixture[northamerica2].stage="group";
		///////////////////////////////champions league group/////////////////////////////////////////////////////////////////////////
		for(int k=6;k<=192;k++){ int m=6;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";  //8 groups of 4
				Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].match[1].team1=Championsleague_group[5,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[5,2];
				Week[k].fixture[3].match[2].team1=Championsleague_group[5,3];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[5,4];
				Week[k].fixture[3].match[3].team1=Championsleague_group[6,1];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[6,2];
				Week[k].fixture[3].match[4].team1=Championsleague_group[6,3];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[6,4];
				Week[k].fixture[3].match[5].team1=Championsleague_group[7,1];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[7,2];
				Week[k].fixture[3].match[6].team1=Championsleague_group[7,3];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[7,4];
				Week[k].fixture[3].match[7].team1=Championsleague_group[8,1];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[8,2];
				Week[k].fixture[3].match[8].team1=Championsleague_group[8,3];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[8,4];}}
		///////////////////copa america///////////////////////////////////////////////////////////////////////////
		for(int k=6;k<=192;k++){ int m=6;int[] s={m,m+96}; if( Contains(s,k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,1];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,2];
				Week[k].fixture[4].match[2].team1=CopaAmerica[1,3];
				Week[k].fixture[4].match[2].team2=CopaAmerica[1,4];
				Week[k].fixture[4].match[3].team1=CopaAmerica[2,1];
				Week[k].fixture[4].match[3].team2=CopaAmerica[2,2];
				Week[k].fixture[4].match[4].team1=CopaAmerica[2,3];
				Week[k].fixture[4].match[4].team2=CopaAmerica[2,4]; }}
		////////////////////////////euro qualifier////////////////////////////////////////////////////////////////////////////
		Week[7].fixture[2].name="Euro Qualifier";Week[7].fixture[2].kind="euroquals";
		Week[7].fixture[2].type="league";Week[7].fixture[2].stage="group";  //8 groups of 5
		Week[7].fixture[2].colour=greenish;Week[7].fixture[2].category="countries";
		Week[7].fixture[2].match[1].team1=EUROqualifier_group[1,1];
		Week[7].fixture[2].match[1].team2=EUROqualifier_group[1,2];
		Week[7].fixture[2].match[2].team1=EUROqualifier_group[1,3];
		Week[7].fixture[2].match[2].team2=EUROqualifier_group[1,4];
		Week[7].fixture[2].match[3].team1=EUROqualifier_group[2,1];
		Week[7].fixture[2].match[3].team2=EUROqualifier_group[2,2];
		Week[7].fixture[2].match[4].team1=EUROqualifier_group[2,3];
		Week[7].fixture[2].match[4].team2=EUROqualifier_group[2,4];
		Week[7].fixture[2].match[5].team1=EUROqualifier_group[3,1];
		Week[7].fixture[2].match[5].team2=EUROqualifier_group[3,2];
		Week[7].fixture[2].match[6].team1=EUROqualifier_group[3,3];
		Week[7].fixture[2].match[6].team2=EUROqualifier_group[3,4];
		Week[7].fixture[2].match[7].team1=EUROqualifier_group[4,1];
		Week[7].fixture[2].match[7].team2=EUROqualifier_group[4,2];
		Week[7].fixture[2].match[8].team1=EUROqualifier_group[4,3];
		Week[7].fixture[2].match[8].team2=EUROqualifier_group[4,4];
		//////////////////////champions league group////////////////////////////////////////////////////////////////////////////////
		for(int k=7;k<=192;k++){ int m=7;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";  //8 groups of 4
				Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].match[1].team1=Championsleague_group[1,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[1,3];
				Week[k].fixture[3].match[2].team1=Championsleague_group[1,2];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[1,4];
				Week[k].fixture[3].match[3].team1=Championsleague_group[2,1];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[2,3];
				Week[k].fixture[3].match[4].team1=Championsleague_group[2,2];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[2,4];
				Week[k].fixture[3].match[5].team1=Championsleague_group[3,1];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[3,3];
				Week[k].fixture[3].match[6].team1=Championsleague_group[3,2];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[3,4];
				Week[k].fixture[3].match[7].team1=Championsleague_group[4,1];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[4,3];
				Week[k].fixture[3].match[8].team1=Championsleague_group[4,2];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[4,4];}}
		////////////////////////////copa america//////////////////////////////////////////////////////////////////////////
		for(int k=7;k<=192;k++){ int m=7;int[] s={m,m+96}; if( Contains(s,k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[7].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,1];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,5];
				Week[k].fixture[4].match[2].team1=CopaAmerica[2,1];
				Week[k].fixture[4].match[2].team2=CopaAmerica[2,5];
			}}
		///////////////////////////////world cup qualifying africa////////////////////////////////////////////////////////////// 
		Week[7].fixture[africa2].colour=pinkish;Week[7].fixture[africa2].name="World Cup Qualifying";Week[7].fixture[africa2].kind="WCQafrica";
		Week[7].fixture[africa2].type="knockout";
		Week[7].fixture[africa2].match[1].team1=WCQualifier_playoff[10,1];
		Week[7].fixture[africa2].match[1].team2=WCQualifier_playoff[10,2];
		Week[7].fixture[africa2].match[1].position=1;
		Week[7].fixture[africa2].match[2].team1=WCQualifier_playoff[11,1];
		Week[7].fixture[africa2].match[2].team2=WCQualifier_playoff[11,2];
		Week[7].fixture[africa2].match[2].position=2;
		Week[7].fixture[africa2].match[3].team1=WCQualifier_playoff[12,1];
		Week[7].fixture[africa2].match[3].team2=WCQualifier_playoff[12,2];
		Week[7].fixture[africa2].match[3].position=3;
		Week[7].fixture[africa2].match[4].team1=WCQualifier_playoff[13,1];
		Week[7].fixture[africa2].match[4].team2=WCQualifier_playoff[13,2];
		Week[7].fixture[africa2].match[4].position=4;
		Week[7].fixture[africa2].match[5].team1=WCQualifier_playoff[14,1];
		Week[7].fixture[africa2].match[5].team2=WCQualifier_playoff[14,2];
		Week[7].fixture[africa2].match[5].position=5;
		Week[7].fixture[africa2].match[6].team1=WCQualifier_playoff[15,1];
		Week[7].fixture[africa2].match[6].team2=WCQualifier_playoff[15,2];
		Week[7].fixture[africa2].match[6].position=6;
		Week[7].fixture[africa2].match[7].team1=WCQualifier_playoff[16,1];
		Week[7].fixture[africa2].match[7].team2=WCQualifier_playoff[16,2];
		Week[7].fixture[africa2].match[7].position=7;
		Week[7].fixture[africa2].match[8].team1=WCQualifier_playoff[17,1];
		Week[7].fixture[africa2].match[8].team2=WCQualifier_playoff[17,2];
		Week[7].fixture[africa2].match[8].position=8;
		Week[7].fixture[africa2].match[9].team1=WCQualifier_playoff[18,1];
		Week[7].fixture[africa2].match[9].team2=WCQualifier_playoff[18,2];
		Week[7].fixture[africa2].match[9].stage="last";Week[7].fixture[africa2].category="countries";
		//////////////////////////////world cup qualifying asia///////////////////////////////////////////////////////////////////////
		/////////////////////////////world cupp qualifications south america//////////////////////////////////////////////////////////////////////
		Week[8].fixture[2].colour=pinkish;Week[8].fixture[2].name="World Cup Qualifying";Week[8].fixture[2].kind="WCQsouthamerica";
		Week[8].fixture[2].type="league"; Week[8].fixture[2].colour=greenish; Week[8].fixture[2].category="countries";               //1 groups of 10
		Week[8].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
		Week[8].fixture[2].match[1].team2=WCQualifier_sa_group[2];
		Week[8].fixture[2].match[2].team1=WCQualifier_sa_group[3]; 
		Week[8].fixture[2].match[2].team2=WCQualifier_sa_group[4];
		Week[8].fixture[2].match[3].team1=WCQualifier_sa_group[5]; 
		Week[8].fixture[2].match[3].team2=WCQualifier_sa_group[6];
		Week[8].fixture[2].match[4].team1=WCQualifier_sa_group[7]; 
		Week[8].fixture[2].match[4].team2=WCQualifier_sa_group[8];
		Week[8].fixture[2].match[5].team1=WCQualifier_sa_group[9]; 
		Week[8].fixture[2].match[5].team2=WCQualifier_sa_group[10];Week[8].fixture[2].stage="group";
		///////////////world cup qualification africa ///////////////////////////////////////////////////////////////////
		Week[8].fixture[africa2].colour=pinkish;Week[8].fixture[africa2].name="World Cup Qualifying";Week[8].fixture[africa2].kind="WCQafrica";
		Week[8].fixture[africa2].type="group";  Week[8].fixture[africa2].category="countries";         //first group fixture
		Week[8].fixture[africa2].match[1].team1=WCQualifier_af_group[1,1];  //5 groups of 5
		Week[8].fixture[africa2].match[1].team2=WCQualifier_af_group[1,2];
		Week[8].fixture[africa2].match[2].team1=WCQualifier_af_group[1,3]; 
		Week[8].fixture[africa2].match[2].team2=WCQualifier_af_group[1,4];
		Week[8].fixture[africa2].match[3].team1=WCQualifier_af_group[2,1];  
		Week[8].fixture[africa2].match[3].team2=WCQualifier_af_group[2,2];
		Week[8].fixture[africa2].match[4].team1=WCQualifier_af_group[2,3]; 
		Week[8].fixture[africa2].match[4].team2=WCQualifier_af_group[2,4];
		Week[8].fixture[africa2].match[5].team1=WCQualifier_af_group[3,1]; 
		Week[8].fixture[africa2].match[5].team2=WCQualifier_af_group[3,2];
		Week[8].fixture[africa2].match[6].team1=WCQualifier_af_group[3,3]; 
		Week[8].fixture[africa2].match[6].team2=WCQualifier_af_group[3,4];
		Week[8].fixture[africa2].match[7].team1=WCQualifier_af_group[4,1];  
		Week[8].fixture[africa2].match[7].team2=WCQualifier_af_group[4,2];
		Week[8].fixture[africa2].match[8].team1=WCQualifier_af_group[4,3]; 
		Week[8].fixture[africa2].match[8].team2=WCQualifier_af_group[4,4];Week[8].fixture[africa2].stage="group";
		/////////////////////world cup qualifier asia/////////////////////////////////////////////////////////////////////
		Week[8].fixture[asia2].colour=pinkish;Week[8].fixture[asia2].name="World Cup Qualifying";Week[8].fixture[asia2].kind="WCQasia";
		Week[8].fixture[asia2].type="group";  Week[8].fixture[asia2].category="countries";             //2nd group round
		Week[8].fixture[asia2].match[1].team1=WCQualifier_as_group[1,1];  //4 groups of 5
		Week[8].fixture[asia2].match[1].team2=WCQualifier_as_group[1,5]; 
		Week[8].fixture[asia2].match[2].team1=WCQualifier_as_group[2,1];  
		Week[8].fixture[asia2].match[2].team2=WCQualifier_as_group[2,5];
		Week[8].fixture[asia2].match[3].team1=WCQualifier_as_group[3,1];  
		Week[8].fixture[asia2].match[3].team2=WCQualifier_as_group[3,5];
		Week[8].fixture[asia2].match[4].team1=WCQualifier_as_group[4,1];  
		Week[8].fixture[asia2].match[4].team2=WCQualifier_as_group[4,5];Week[8].fixture[asia2].stage="group";
		////////////////////////////world cup qualifying north america//////////////////////////////////////////////////
		Week[8].fixture[northamerica2].colour=pinkish;Week[8].fixture[northamerica2].name="World Cup Qualifying";
		Week[8].fixture[northamerica2].kind="WCQnorthamerica";Week[8].fixture[northamerica2].stage="group";
		Week[8].fixture[northamerica2].type="league";Week[8].fixture[northamerica2].category="countries"; 
		Week[8].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
		Week[8].fixture[northamerica2].match[1].team2= WCQualifier_na_group[3];
		Week[8].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
		Week[8].fixture[northamerica2].match[2].team2= WCQualifier_na_group[4];
		Week[8].fixture[northamerica2].match[3].team1= WCQualifier_na_group[5];
		Week[8].fixture[northamerica2].match[3].team2= WCQualifier_na_group[7];
		Week[8].fixture[northamerica2].match[4].team1= WCQualifier_na_group[6];
		Week[8].fixture[northamerica2].match[4].team2= WCQualifier_na_group[8];
		Week[8].fixture[northamerica2].match[5].team1= WCQualifier_na_group[9];
		Week[8].fixture[northamerica2].match[5].team2= WCQualifier_na_group[11];
		Week[8].fixture[northamerica2].match[6].team1= WCQualifier_na_group[10];
		Week[8].fixture[northamerica2].match[6].team2= WCQualifier_na_group[12];
		Week[8].fixture[northamerica2].match[7].team1= WCQualifier_na_group[13];
		Week[8].fixture[northamerica2].match[7].team2= WCQualifier_na_group[15];
		Week[8].fixture[northamerica2].match[8].team1= WCQualifier_na_group[14];
		Week[8].fixture[northamerica2].match[8].team2= WCQualifier_na_group[16];

		//////////////////////////uefa cup///////////////////////////////////////////////////////////////////////////////
		for(int k=8;k<=192;k++){ int m=8;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].colour=yellowish;Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,3];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,4];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,3];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,4];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,3];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,4];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,3];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,4];
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		/////////////////////copa america/////////////////////////////////////////////////////////////////////////////
		for(int k=8;k<=192;k++){ int m=8;int[] s={m,m+96}; if( Contains(s,k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,1];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,3];
				Week[k].fixture[4].match[2].team1=CopaAmerica[1,2];
				Week[k].fixture[4].match[2].team2=CopaAmerica[1,4];
				Week[k].fixture[4].match[3].team1=CopaAmerica[2,1];
				Week[k].fixture[4].match[3].team2=CopaAmerica[2,3];
				Week[k].fixture[4].match[4].team1=CopaAmerica[2,2];
				Week[k].fixture[4].match[4].team2=CopaAmerica[2,4];}}
		////////////////////////friendly////////////////////////////////////////////////////////////////////////////////
		if(global.category=="countries"){
			Week[9].fixture[2].match[1].team1=Friendly[3,1]; //<=always own country //14 friendlies in 4 years
			Week[9].fixture[2].match[1].team2=Friendly[3,2];
			Week[9].fixture[2].colour=bluish;Week[9].fixture[2].category="countries";
			Week[9].fixture[2].name="Friendly";Week[9].fixture[2].kind="friendly";}
		//////////////////world cup qualifications oceania////////////////////////////////////////////////////////////////////////////////////
		Week[9].fixture[3].colour=pinkish;Week[9].fixture[3].name="World Cup Qualifying";Week[9].fixture[3].kind="WCQoceania";
		Week[9].fixture[3].type="group";Week[9].fixture[3]. category="countries";                   //1 group of 8
		Week[9].fixture[3].match[1].team1=WCQualifier_oc_group[1];
		Week[9].fixture[3].match[1].team2=WCQualifier_oc_group[2];
		Week[9].fixture[3].match[2].team1=WCQualifier_oc_group[3];
		Week[9].fixture[3].match[2].team2=WCQualifier_oc_group[4];
		Week[9].fixture[3].match[3].team1=WCQualifier_oc_group[5];
		Week[9].fixture[3].match[3].team2=WCQualifier_oc_group[6];
		Week[9].fixture[3].match[4].team1=WCQualifier_oc_group[7];
		Week[9].fixture[3].match[4].team2=WCQualifier_oc_group[8];Week[9].fixture[3].stage="group";
		//////////////////////////////////////////////////////////////////////////////////////////////////

		/////////////////////copa america//////////////////////////////////////////////////////////////////////////
		for(int k=9;k<=192;k++){ int m=9;int[] s={m,m+96}; if( Contains(s,k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,1];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,5];
				Week[k].fixture[4].match[2].team1=CopaAmerica[2,1];
				Week[k].fixture[4].match[2].team2=CopaAmerica[2,5];}}
		///////////////////////league cup//////////////////////////////////////////////////////////////////////////////
		for(int k=10;k<=192;k++){ int m=10;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[1].match[1].team1=Leaguecup_semi[1,1];  //2 matches here 8 teams total
				Week[k].fixture[1].match[1].team2=Leaguecup_semi[1,2];
				Week[k].fixture[1].match[1].position=1;
				Week[k].fixture[1].match[2].team1=Leaguecup_semi[2,1];
				Week[k].fixture[1].match[2].team2=Leaguecup_semi[2,2];
				Week[k].fixture[1].match[2].position=2;
				Week[k].fixture[1].colour=pinkish;
				Week[k].fixture[1].name="League Cup";Week[k].fixture[1].kind="leaguecup";
				Week[k].fixture[1].type="knockout";Week[k].fixture[1].stage="semifinal";Week[k].fixture[1].category="clubs";}}
		////////////////////////world cup qualification europe//////////////////////////////////////////////////////////////
		Week[10].fixture[2].colour=pinkish;Week[10].fixture[2].name="World Cup Qualifying";Week[10].fixture[2].kind="WCQeurope";
		Week[10].fixture[2].type="league";Week[10].fixture[2].colour=bluish; Week[10].fixture[2].category="countries";                //7 groups of 6
		Week[10].fixture[2].match[1].team1=WCQualifier_eu_group[4,1]; //group 1 team 1
		Week[10].fixture[2].match[1].team2=WCQualifier_eu_group[4,2];
		Week[10].fixture[2].match[2].team1=WCQualifier_eu_group[4,3]; 
		Week[10].fixture[2].match[2].team2=WCQualifier_eu_group[4,4];
		Week[10].fixture[2].match[3].team1=WCQualifier_eu_group[4,5]; 
		Week[10].fixture[2].match[3].team2=WCQualifier_eu_group[4,6];
		Week[10].fixture[2].match[4].team1=WCQualifier_eu_group[5,1]; 
		Week[10].fixture[2].match[4].team2=WCQualifier_eu_group[5,2];
		Week[10].fixture[2].match[5].team1=WCQualifier_eu_group[5,3]; 
		Week[10].fixture[2].match[5].team2=WCQualifier_eu_group[5,4];
		Week[10].fixture[2].match[6].team1=WCQualifier_eu_group[5,5]; 
		Week[10].fixture[2].match[6].team2=WCQualifier_eu_group[5,5];
		Week[10].fixture[2].match[7].team1=WCQualifier_eu_group[6,1]; 
		Week[10].fixture[2].match[7].team2=WCQualifier_eu_group[6,2];
		Week[10].fixture[2].match[8].team1=WCQualifier_eu_group[6,3]; 
		Week[10].fixture[2].match[8].team2=WCQualifier_eu_group[6,4];
		Week[10].fixture[2].match[9].team1=WCQualifier_eu_group[6,5]; 
		Week[10].fixture[2].match[9].team2=WCQualifier_eu_group[6,6];Week[10].fixture[2].stage="group";
		////////////////////////////champions league///////////////////////////////////////////////////////////////////
		for(int k=10;k<=192;k++){ int m=10;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].match[1].team1=Championsleague_group[5,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[5,3];
				Week[k].fixture[3].match[2].team1=Championsleague_group[5,2];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[5,4];
				Week[k].fixture[3].match[3].team1=Championsleague_group[6,1];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[6,3];
				Week[k].fixture[3].match[4].team1=Championsleague_group[6,2];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[6,4];
				Week[k].fixture[3].match[5].team1=Championsleague_group[7,1];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[7,3];
				Week[k].fixture[3].match[6].team1=Championsleague_group[7,2];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[7,4];
				Week[k].fixture[3].match[7].team1=Championsleague_group[8,1];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[8,3];
				Week[k].fixture[3].match[8].team1=Championsleague_group[8,2];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[8,4];
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		///////////////////////copa//////////////////////////////////////////////////////////////////
		for(int k=10;k<=192;k++){ int m=10;int[] s={m,m+96}; if( Contains(s,k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries"; 
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,1];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,4];
				Week[k].fixture[4].match[2].team1=CopaAmerica[1,2];
				Week[k].fixture[4].match[2].team2=CopaAmerica[1,3];
				Week[k].fixture[4].match[3].team1=CopaAmerica[2,1];
				Week[k].fixture[4].match[3].team2=CopaAmerica[2,4];
				Week[k].fixture[4].match[4].team1=CopaAmerica[2,2];
				Week[k].fixture[4].match[4].team2=CopaAmerica[2,3];}}
		//////////////////////////friendly///////////////////////////////////////////////
		if(global.category=="countries"){
			Week[11].fixture[2].match[1].team1=Friendly[4,1]; //<=always own country //14 friendlies in 4 years
			Week[11].fixture[2].match[1].team2=Friendly[4,2];
			Week[11].fixture[2].colour=bluish;Week[11].fixture[2].category="countries"; 
			Week[11].fixture[2].name="Friendly";Week[11].fixture[2].kind="friendly";}
		///////////////////////uefa cup/////////////////////////////////////////////////////////////////
		for(int k=11;k<=192;k++){ int m=11;int[] s={m,m+48,m+96,m+144}; if( Contains(s,k) ){
				Week[k].fixture[3].colour=yellowish;
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,4];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,2];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,4];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,2];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,4];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,2];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,1];  //group,team  4 groups of 4
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,4];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,2];
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";Week[k].fixture[3].category="clubs";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		////////////////////////copa america//////////////////////////////////////////////////////////
		for(int k=11;k<=192;k++){ int m=11; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,2];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,5];
				Week[k].fixture[4].match[2].team1=CopaAmerica[2,2];
				Week[k].fixture[4].match[2].team2=CopaAmerica[2,5];}}
		//////////////////////////euro qualifiers////////////////////////////////////////////////////////////////
		Week[12].fixture[2].name="Euro Qualifier";Week[12].fixture[2].kind="euroquals";
		Week[12].fixture[2].type="league";Week[12].fixture[2].stage="group";  //8 groups of 5
		Week[12].fixture[2].colour=greenish;Week[12].fixture[2].category="countries";
		Week[12].fixture[2].match[1].team1=EUROqualifier_group[5,1];
		Week[12].fixture[2].match[1].team2=EUROqualifier_group[5,2];
		Week[12].fixture[2].match[2].team1=EUROqualifier_group[5,3];
		Week[12].fixture[2].match[2].team2=EUROqualifier_group[5,4];
		Week[12].fixture[2].match[3].team1=EUROqualifier_group[6,1];
		Week[12].fixture[2].match[3].team2=EUROqualifier_group[6,2];
		Week[12].fixture[2].match[4].team1=EUROqualifier_group[6,3];
		Week[12].fixture[2].match[4].team2=EUROqualifier_group[6,4];
		Week[12].fixture[2].match[5].team1=EUROqualifier_group[7,1];
		Week[12].fixture[2].match[5].team2=EUROqualifier_group[7,2];
		Week[12].fixture[2].match[6].team1=EUROqualifier_group[7,3];
		Week[12].fixture[2].match[6].team2=EUROqualifier_group[7,4];
		Week[12].fixture[2].match[7].team1=EUROqualifier_group[8,1];
		Week[12].fixture[2].match[7].team2=EUROqualifier_group[8,2];
		Week[12].fixture[2].match[8].team1=EUROqualifier_group[8,3];
		Week[12].fixture[2].match[8].team2=EUROqualifier_group[8,4];
		//////////////////////////////uefa cup////////////////////////////////////////////////////////
		for(int k=12;k<=192;k++){ int m=12; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].category="clubs"; //away(second) leg
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,1];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,3];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,1];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,3];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,1];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,3];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,2];  //group,team  4 groups of 4
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,1];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,3];
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		//////////////////////////copa america/////////////////////////////////////////////////////////////////
		for(int k=12;k<=192;k++){ int m=12; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,3];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,5];
				Week[k].fixture[4].match[2].team1=CopaAmerica[2,3];
				Week[k].fixture[4].match[2].team2=CopaAmerica[2,5];}}
		/////////////////////////////confederations cup//////////////////////////////////////////////////////////////
		Week[13].fixture[2].name="Confederations Cup";Week[13].fixture[2].kind="confed";Week[13].fixture[2].category="countries";
		Week[13].fixture[2].type="knockout";Week[13].fixture[2].stage="quarterfinal";Week[13].fixture[2].colour=greenish;
		Week[13].fixture[2].match[1].team1=CONFEDcup_round1[1,1];
		Week[13].fixture[2].match[1].team2=CONFEDcup_round1[1,2];
		Week[13].fixture[2].match[1].position=1;Week[13].fixture[2].match[1].group=1;
		Week[13].fixture[2].match[2].team1=CONFEDcup_round1[2,1];
		Week[13].fixture[2].match[2].team2=CONFEDcup_round1[2,2];
		Week[13].fixture[2].match[2].position=2;Week[13].fixture[2].match[2].group=1;
		////////////////////////confederations cup///////////////////////////////////////////////////////////////////
		Week[14].fixture[2].name="Confederations Cup semi";Week[14].fixture[2].kind="confed";Week[14].fixture[2].category="countries";
		Week[14].fixture[2].type="knockout";Week[14].fixture[2].stage="semifinal";Week[14].fixture[2].colour=greenish;
		Week[14].fixture[2].match[1].team1=CONFEDcup_semifinal[1,1];
		Week[14].fixture[2].match[1].team2=CONFEDcup_semifinal[1,2];
		Week[14].fixture[2].match[1].position=1;
		Week[14].fixture[2].match[2].team1=CONFEDcup_semifinal[2,1];
		Week[14].fixture[2].match[2].team2=CONFEDcup_semifinal[2,2];
		Week[14].fixture[2].match[2].position=2;
		//////////////////////////////champions league///////////////////////////////////////////////////////////
		for(int k=14;k<=192;k++){ int m=14; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[3].colour=violet;  Week[k].fixture[3].category="clubs"; 
				Week[k].fixture[3].match[1].team1=Championsleague_group[1,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[1,4];
				Week[k].fixture[3].match[2].team1=Championsleague_group[1,2];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[1,3];
				Week[k].fixture[3].match[3].team1=Championsleague_group[2,1];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[2,4];
				Week[k].fixture[3].match[4].team1=Championsleague_group[2,2];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[2,3];
				Week[k].fixture[3].match[5].team1=Championsleague_group[3,1];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[3,4];
				Week[k].fixture[3].match[6].team1=Championsleague_group[3,2];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[3,3];
				Week[k].fixture[3].match[7].team1=Championsleague_group[4,1];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[4,4];
				Week[k].fixture[3].match[8].team1=Championsleague_group[4,2];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[4,3];
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		/////////////////////////copa america semi///////////////////////////////////////////////////////////////
		for(int k=14;k<=192;k++){ int m=14; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Copa America";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //2 groups of 5
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=CopaAmerica[1,4];
				Week[k].fixture[4].match[1].team2=CopaAmerica[1,5];
				Week[k].fixture[4].match[2].team1=CopaAmerica[2,4];
				Week[k].fixture[4].match[2].team2=CopaAmerica[2,5];Week[k].fixture[4].match[2].stage="last";}}
		///////////////////////////////confederations cup final///////////////////////////////////////////
		Week[15].fixture[2].name="Confederations Cup final";Week[15].fixture[2].kind="confed";Week[15].fixture[2].category="countries";
		Week[15].fixture[2].type="knockout";Week[15].fixture[2].stage="final";Week[15].fixture[2].colour=greenish;
		Week[15].fixture[2].match[1].team1=CONFEDcup_final[1];
		Week[15].fixture[2].match[1].team2=CONFEDcup_final[2];
		//////////////////////////////copa america////////////////////////////////////////////////////////////
		for(int k=15;k<=192;k++){ int m=15; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[3].name="Copa America semifinal";Week[k].fixture[3].kind="copa";
				Week[k].fixture[3].type="knockout";Week[k].fixture[3].stage="semifinal";  //copa america semi final
				Week[k].fixture[3].colour=yellowish;Week[k].fixture[3].category="countries";
				Week[k].fixture[3].match[1].team1=Copa_semifinal[1,1];
				Week[k].fixture[3].match[1].team2=Copa_semifinal[1,2];
				Week[k].fixture[3].match[1].position=1;
				Week[k].fixture[3].match[2].team1=Copa_semifinal[2,1];
				Week[k].fixture[3].match[2].team2=Copa_semifinal[2,2];
				Week[k].fixture[3].match[2].position=2;
				/////////////////////copa america final////////////////////////////////////////////////////////////////////////
				Week[k].fixture[4].name="Copa America final";Week[k].fixture[4].kind="copa";
				Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";  //2 groups of 5 bug fix
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Copa_final[1];
				Week[k].fixture[4].match[1].team2=Copa_final[2];  }}
		///////////////////////////afcon quals//////////////////////////////////////////////////////////////////////
		for(int k=16;k<=192;k++){ int m=16; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
				Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6
				Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
				Week[k].fixture[2].match[1].team1=AFCONqualifier_group[1,1];
				Week[k].fixture[2].match[1].team2=AFCONqualifier_group[1,2];
				Week[k].fixture[2].match[2].team1=AFCONqualifier_group[1,3];
				Week[k].fixture[2].match[2].team2=AFCONqualifier_group[1,4];
				Week[k].fixture[2].match[3].team1=AFCONqualifier_group[1,5];
				Week[k].fixture[2].match[3].team2=AFCONqualifier_group[1,6];
				Week[k].fixture[2].match[4].team1=AFCONqualifier_group[2,1];
				Week[k].fixture[2].match[4].team2=AFCONqualifier_group[2,2];
				Week[k].fixture[2].match[5].team1=AFCONqualifier_group[2,3];
				Week[k].fixture[2].match[5].team2=AFCONqualifier_group[2,4];
				Week[k].fixture[2].match[6].team1=AFCONqualifier_group[2,5];
				Week[k].fixture[2].match[6].team2=AFCONqualifier_group[2,6];
				Week[k].fixture[2].match[7].team1=AFCONqualifier_group[3,1];
				Week[k].fixture[2].match[7].team2=AFCONqualifier_group[3,2];
				Week[k].fixture[2].match[8].team1=AFCONqualifier_group[3,3];
				Week[k].fixture[2].match[8].team2=AFCONqualifier_group[3,4];
				Week[k].fixture[2].match[9].team1=AFCONqualifier_group[3,5];
				Week[k].fixture[2].match[9].team2=AFCONqualifier_group[3,6];}}
		/////////////////////uefa cup/////////////////////////////////////////////////////////////////////////
		for(int k=16;k<=192;k++){ int m=16; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[3].colour=yellowish;Week[k].fixture[3].category="clubs";  //away(second) leg second last
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,1];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,2];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,1];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,2];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,1];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,2];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,3];  //group,team  4 groups of 4
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,1];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,2];
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		////////////////////////////gold cup///////////////////////////////////////////////////////////////////////
		for(int k=16;k<=192;k++){ int m=16; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup";Week[k].fixture[4].kind="goldcup";
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_group[1,1];  // 4 groups of 4
				Week[k].fixture[4].match[1].team2=Goldcup_group[1,2];
				Week[k].fixture[4].match[2].team1=Goldcup_group[1,3];  
				Week[k].fixture[4].match[2].team2=Goldcup_group[1,4];
				Week[k].fixture[4].match[3].team1=Goldcup_group[2,1];  
				Week[k].fixture[4].match[3].team2=Goldcup_group[2,2];
				Week[k].fixture[4].match[4].team1=Goldcup_group[2,3];  
				Week[k].fixture[4].match[4].team2=Goldcup_group[2,4];
				Week[k].fixture[4].match[5].team1=Goldcup_group[3,1];  
				Week[k].fixture[4].match[5].team2=Goldcup_group[3,2];
				Week[k].fixture[4].match[6].team1=Goldcup_group[3,3];  
				Week[k].fixture[4].match[6].team2=Goldcup_group[3,4];
				Week[k].fixture[4].match[7].team1=Goldcup_group[4,1];  
				Week[k].fixture[4].match[7].team2=Goldcup_group[4,2];
				Week[k].fixture[4].match[8].team1=Goldcup_group[4,3];  
				Week[k].fixture[4].match[8].team2=Goldcup_group[4,4]; }}
		///////////////////////////world cup qualification europe/////////////////////////////////////////////////////////////
		Week[17].fixture[2].colour=pinkish;Week[17].fixture[2].name="World Cup Qualifying";Week[17].fixture[2].kind="WCQeurope";
		Week[17].fixture[2].type="league";Week[17].fixture[2].colour=bluish;Week[17].fixture[2].category="countries";                 //7 groups of 6
		Week[17].fixture[2].match[1].team1=WCQualifier_eu_group[7,1]; //group 1 team 1
		Week[17].fixture[2].match[1].team2=WCQualifier_eu_group[7,2];
		Week[17].fixture[2].match[2].team1=WCQualifier_eu_group[7,3]; 
		Week[17].fixture[2].match[2].team2=WCQualifier_eu_group[7,4];
		Week[17].fixture[2].match[3].team1=WCQualifier_eu_group[7,5]; 
		Week[17].fixture[2].match[3].team2=WCQualifier_eu_group[7,6];
		Week[17].fixture[2].match[4].team1=WCQualifier_eu_group[1,1]; 
		Week[17].fixture[2].match[4].team2=WCQualifier_eu_group[1,3];
		Week[17].fixture[2].match[5].team1=WCQualifier_eu_group[1,2]; 
		Week[17].fixture[2].match[5].team2=WCQualifier_eu_group[1,5];
		Week[17].fixture[2].match[6].team1=WCQualifier_eu_group[1,4]; 
		Week[17].fixture[2].match[6].team2=WCQualifier_eu_group[1,6];
		Week[17].fixture[2].match[7].team1=WCQualifier_eu_group[2,1]; 
		Week[17].fixture[2].match[7].team2=WCQualifier_eu_group[2,3];
		Week[17].fixture[2].match[8].team1=WCQualifier_eu_group[2,2]; 
		Week[17].fixture[2].match[8].team2=WCQualifier_eu_group[2,5];
		Week[17].fixture[2].match[9].team1=WCQualifier_eu_group[2,4]; 
		Week[17].fixture[2].match[9].team2=WCQualifier_eu_group[2,6];Week[17].fixture[2].stage="group";
		///////////////////////////world cup qualification africa/////////////////////////////////////////////////////////////
		Week[17].fixture[africa2].colour=pinkish;Week[17].fixture[africa2].name="World Cup Qualifying";Week[17].fixture[africa2].kind="WCQafrica";
		Week[17].fixture[africa2].type="group"; Week[17].fixture[africa2].category="countries";         //first group fixture
		Week[17].fixture[africa2].match[1].team1=WCQualifier_af_group[5,1];  //5 groups of 5
		Week[17].fixture[africa2].match[1].team2=WCQualifier_af_group[5,2];
		Week[17].fixture[africa2].match[2].team1=WCQualifier_af_group[5,3]; 
		Week[17].fixture[africa2].match[2].team2=WCQualifier_af_group[5,4];
		Week[17].fixture[africa2].match[3].team1=WCQualifier_af_group[1,1];  
		Week[17].fixture[africa2].match[3].team2=WCQualifier_af_group[1,5];
		Week[17].fixture[africa2].match[4].team1=WCQualifier_af_group[2,1]; 
		Week[17].fixture[africa2].match[4].team2=WCQualifier_af_group[2,5];
		Week[17].fixture[africa2].match[5].team1=WCQualifier_af_group[3,1]; 
		Week[17].fixture[africa2].match[5].team2=WCQualifier_af_group[3,5];
		Week[17].fixture[africa2].match[6].team1=WCQualifier_af_group[4,1]; 
		Week[17].fixture[africa2].match[6].team2=WCQualifier_af_group[4,5];Week[17].fixture[africa2].stage="group";
		/////////////////////world cup qualifier asia/////////////////////////////////////////////////////////////////////
		Week[17].fixture[asia2].colour=pinkish;Week[17].fixture[asia2].name="World Cup Qualifying";Week[17].fixture[asia2].kind="WCQasia";
		Week[17].fixture[asia2].type="group"; Week[17].fixture[asia2].category="countries";              //2nd group round
		Week[17].fixture[asia2].match[1].team1=WCQualifier_as_group[1,1];  //4 groups of 5
		Week[17].fixture[asia2].match[1].team2=WCQualifier_as_group[1,3]; 
		Week[17].fixture[asia2].match[2].team1=WCQualifier_as_group[1,2];  
		Week[17].fixture[asia2].match[2].team2=WCQualifier_as_group[1,4];
		Week[17].fixture[asia2].match[3].team1=WCQualifier_as_group[2,1];  
		Week[17].fixture[asia2].match[3].team2=WCQualifier_as_group[2,3];
		Week[17].fixture[asia2].match[4].team1=WCQualifier_as_group[2,2];  
		Week[17].fixture[asia2].match[4].team2=WCQualifier_as_group[2,4];
		Week[17].fixture[asia2].match[5].team1=WCQualifier_as_group[3,1];  
		Week[17].fixture[asia2].match[5].team2=WCQualifier_as_group[3,3];
		Week[17].fixture[asia2].match[6].team1=WCQualifier_as_group[3,2];  
		Week[17].fixture[asia2].match[6].team2=WCQualifier_as_group[3,4];
		Week[17].fixture[asia2].match[7].team1=WCQualifier_as_group[4,1];  
		Week[17].fixture[asia2].match[7].team2=WCQualifier_as_group[4,3];
		Week[17].fixture[asia2].match[8].team1=WCQualifier_as_group[4,2];  
		Week[17].fixture[asia2].match[8].team2=WCQualifier_as_group[4,4];Week[17].fixture[asia2].stage="group";
		////////////////////////////world cup qualifying north america//////////////////////////////////////////////////
		Week[17].fixture[northamerica2].colour=pinkish;Week[17].fixture[northamerica2].name="World Cup Qualifying";
		Week[17].fixture[northamerica2].kind="WCQnorthamerica";Week[17].fixture[northamerica2].category="countries";
		Week[17].fixture[northamerica2].type="league";
		Week[17].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
		Week[17].fixture[northamerica2].match[1].team2= WCQualifier_na_group[4];
		Week[17].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
		Week[17].fixture[northamerica2].match[2].team2= WCQualifier_na_group[5];
		Week[17].fixture[northamerica2].match[3].team1= WCQualifier_na_group[4];
		Week[17].fixture[northamerica2].match[3].team2= WCQualifier_na_group[6];
		Week[17].fixture[northamerica2].match[4].team1= WCQualifier_na_group[7];
		Week[17].fixture[northamerica2].match[4].team2= WCQualifier_na_group[9];
		Week[17].fixture[northamerica2].match[5].team1= WCQualifier_na_group[8];
		Week[17].fixture[northamerica2].match[5].team2= WCQualifier_na_group[10];
		Week[17].fixture[northamerica2].match[6].team1= WCQualifier_na_group[11];
		Week[17].fixture[northamerica2].match[6].team2= WCQualifier_na_group[16];
		Week[17].fixture[northamerica2].match[7].team1= WCQualifier_na_group[12];
		Week[17].fixture[northamerica2].match[7].team2= WCQualifier_na_group[13];
		Week[17].fixture[northamerica2].match[8].team1= WCQualifier_na_group[14];
		Week[17].fixture[northamerica2].match[8].team2= WCQualifier_na_group[15];Week[17].fixture[northamerica2].stage="group";
		/////////////////////////euro qualifier////////////////////////////////////////////////////////////////////
		Week[17].fixture[3].name="Euro Qualifier";Week[17].fixture[3].kind="euroquals";  //no 2
		Week[17].fixture[3].type="league";Week[17].fixture[3].stage="group";  //8 groups of 5
		Week[17].fixture[3].colour=greenish;Week[17].fixture[3].category="countries";
		Week[17].fixture[3].match[1].team1=EUROqualifier_group[1,1];
		Week[17].fixture[3].match[1].team2=EUROqualifier_group[1,5];
		Week[17].fixture[3].match[2].team1=EUROqualifier_group[2,1];
		Week[17].fixture[3].match[2].team2=EUROqualifier_group[2,5];
		Week[17].fixture[3].match[3].team1=EUROqualifier_group[3,1];
		Week[17].fixture[3].match[3].team2=EUROqualifier_group[3,5];
		Week[17].fixture[3].match[4].team1=EUROqualifier_group[4,1];
		Week[17].fixture[3].match[4].team2=EUROqualifier_group[4,5];
		Week[17].fixture[3].match[5].team1=EUROqualifier_group[5,1];
		Week[17].fixture[3].match[5].team2=EUROqualifier_group[5,5];
		Week[17].fixture[3].match[6].team1=EUROqualifier_group[6,1];
		Week[17].fixture[3].match[6].team2=EUROqualifier_group[6,5];
		Week[17].fixture[3].match[7].team1=EUROqualifier_group[7,1];
		Week[17].fixture[3].match[7].team2=EUROqualifier_group[7,5];
		Week[17].fixture[3].match[8].team1=EUROqualifier_group[8,1];
		Week[17].fixture[3].match[8].team2=EUROqualifier_group[8,5];
		//////////////////////gold cup/////////////////////////////////////////////////////////////////////////
		for(int k=17;k<=192;k++){ int m=17; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup";Week[k].fixture[4].kind="goldcup";  //no 2 
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_group[1,1];  // 4 groups of 4
				Week[k].fixture[4].match[1].team2=Goldcup_group[1,3];
				Week[k].fixture[4].match[2].team1=Goldcup_group[1,2];  
				Week[k].fixture[4].match[2].team2=Goldcup_group[1,4];
				Week[k].fixture[4].match[3].team1=Goldcup_group[2,1];  
				Week[k].fixture[4].match[3].team2=Goldcup_group[2,3];
				Week[k].fixture[4].match[4].team1=Goldcup_group[2,2];  
				Week[k].fixture[4].match[4].team2=Goldcup_group[2,4];
				Week[k].fixture[4].match[5].team1=Goldcup_group[3,1];  
				Week[k].fixture[4].match[5].team2=Goldcup_group[3,3];
				Week[k].fixture[4].match[6].team1=Goldcup_group[3,2];  
				Week[k].fixture[4].match[6].team2=Goldcup_group[3,4];
				Week[k].fixture[4].match[7].team1=Goldcup_group[4,1];  
				Week[k].fixture[4].match[7].team2=Goldcup_group[4,3];
				Week[k].fixture[4].match[8].team1=Goldcup_group[4,2];  
				Week[k].fixture[4].match[8].team2=Goldcup_group[4,4]; }}
		//////////////////////afcon quals/////////////////////////////////////////////////////////////////////////////
		for(int k=18;k<=192;k++){ int m=18; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[1].name="AFCON Qualifiers";Week[k].fixture[1].kind="afconquals";
				Week[k].fixture[1].type="league";Week[k].fixture[1].stage="group";  //8 groups of 6
				Week[k].fixture[1].colour=bluish;Week[k].fixture[1].category="countries";
				Week[k].fixture[1].match[1].team1=AFCONqualifier_group[4,1];
				Week[k].fixture[1].match[1].team2=AFCONqualifier_group[4,2];
				Week[k].fixture[1].match[2].team1=AFCONqualifier_group[4,3];
				Week[k].fixture[1].match[2].team2=AFCONqualifier_group[4,4];
				Week[k].fixture[1].match[3].team1=AFCONqualifier_group[4,5];
				Week[k].fixture[1].match[3].team2=AFCONqualifier_group[4,6];
				Week[k].fixture[1].match[4].team1=AFCONqualifier_group[5,1];
				Week[k].fixture[1].match[4].team2=AFCONqualifier_group[5,2];
				Week[k].fixture[1].match[5].team1=AFCONqualifier_group[5,3];
				Week[k].fixture[1].match[5].team2=AFCONqualifier_group[5,4];
				Week[k].fixture[1].match[6].team1=AFCONqualifier_group[5,5];
				Week[k].fixture[1].match[6].team2=AFCONqualifier_group[5,6];
				Week[k].fixture[1].match[7].team1=AFCONqualifier_group[6,1];
				Week[k].fixture[1].match[7].team2=AFCONqualifier_group[6,2];
				Week[k].fixture[1].match[8].team1=AFCONqualifier_group[6,3];
				Week[k].fixture[1].match[8].team2=AFCONqualifier_group[6,4];
				Week[k].fixture[1].match[9].team1=AFCONqualifier_group[6,5];
				Week[k].fixture[1].match[9].team2=AFCONqualifier_group[6,6];}}
		///////////////////////////fa cup////////////////////////////////////////////////////////////////////
		for(int k=18;k<=192;k++){ int m=18; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[2].colour=pinkish;Week[k].fixture[2].category="clubs";  //playoffs
				Week[k].fixture[2].name="FA Cup";Week[k].fixture[2].kind="facup";
				Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="playoffs";
				Week[k].fixture[2].match[1].team1=FAcup_playoffs1[1,1];
				Week[k].fixture[2].match[1].team2=FAcup_playoffs1[1,2];
				Week[k].fixture[2].match[1].position=1;
				Week[k].fixture[2].match[2].team1=FAcup_playoffs1[2,1];
				Week[k].fixture[2].match[2].team2=FAcup_playoffs1[2,2];
				Week[k].fixture[2].match[2].position=2;
				/////////////////////////////champions league////////////////////////////////////////////////////////////////////
				Week[k].fixture[3].colour=violet;   
				Week[k].fixture[3].match[1].team1=Championsleague_group[5,1];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[5,4];
				Week[k].fixture[3].match[2].team1=Championsleague_group[5,2];  //
				Week[k].fixture[3].match[2].team2=Championsleague_group[5,3];
				Week[k].fixture[3].match[3].team1=Championsleague_group[6,1];  //
				Week[k].fixture[3].match[3].team2=Championsleague_group[6,4];
				Week[k].fixture[3].match[4].team1=Championsleague_group[6,2];  
				Week[k].fixture[3].match[4].team2=Championsleague_group[6,3];
				Week[k].fixture[3].match[5].team1=Championsleague_group[7,1];  
				Week[k].fixture[3].match[5].team2=Championsleague_group[7,4];
				Week[k].fixture[3].match[6].team1=Championsleague_group[7,2];  //
				Week[k].fixture[3].match[6].team2=Championsleague_group[7,3];
				Week[k].fixture[3].match[7].team1=Championsleague_group[8,1];  
				Week[k].fixture[3].match[7].team2=Championsleague_group[8,4];
				Week[k].fixture[3].match[8].team1=Championsleague_group[8,2];  
				Week[k].fixture[3].match[8].team2=Championsleague_group[8,3];
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";Week[k].fixture[3].category="clubs";}}
		////////////////////////gold cup///////////////////////////////////////////////////////////////////////////
		for(int k=18;k<=192;k++){ int m=18; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup";Week[k].fixture[4].kind="goldcup";  //no 2 
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_group[1,1];  // 4 groups of 4
				Week[k].fixture[4].match[1].team2=Goldcup_group[1,4];
				Week[k].fixture[4].match[2].team1=Goldcup_group[1,2];  
				Week[k].fixture[4].match[2].team2=Goldcup_group[1,3];
				Week[k].fixture[4].match[3].team1=Goldcup_group[2,1];  
				Week[k].fixture[4].match[3].team2=Goldcup_group[2,4];
				Week[k].fixture[4].match[4].team1=Goldcup_group[2,2];  
				Week[k].fixture[4].match[4].team2=Goldcup_group[2,3];
				Week[k].fixture[4].match[5].team1=Goldcup_group[3,1];  
				Week[k].fixture[4].match[5].team2=Goldcup_group[3,4];
				Week[k].fixture[4].match[6].team1=Goldcup_group[3,2];  
				Week[k].fixture[4].match[6].team2=Goldcup_group[3,3];
				Week[k].fixture[4].match[7].team1=Goldcup_group[4,1];  
				Week[k].fixture[4].match[7].team2=Goldcup_group[4,4];
				Week[k].fixture[4].match[8].team1=Goldcup_group[4,2];  
				Week[k].fixture[4].match[8].team2=Goldcup_group[4,3];Week[k].fixture[4].match[8].stage="last" ;}}
		//////////////////////////euro quals//////////////////////////////////////////////////////////////////////
		Week[19].fixture[2].name="Euro Qualifier";Week[19].fixture[2].kind="euroquals";
		Week[19].fixture[2].type="league";Week[19].fixture[2].stage="group";  //8 groups of 5
		Week[19].fixture[2].colour=greenish;Week[19].fixture[2].category="countries";
		Week[19].fixture[2].match[1].team1=EUROqualifier_group[1,1];
		Week[19].fixture[2].match[1].team2=EUROqualifier_group[1,3];
		Week[19].fixture[2].match[2].team1=EUROqualifier_group[1,2];
		Week[19].fixture[2].match[2].team2=EUROqualifier_group[1,4];
		Week[19].fixture[2].match[3].team1=EUROqualifier_group[2,1];
		Week[19].fixture[2].match[3].team2=EUROqualifier_group[2,3];
		Week[19].fixture[2].match[4].team1=EUROqualifier_group[2,2];
		Week[19].fixture[2].match[4].team2=EUROqualifier_group[2,4];
		Week[19].fixture[2].match[5].team1=EUROqualifier_group[3,1];
		Week[19].fixture[2].match[5].team2=EUROqualifier_group[3,3];
		Week[19].fixture[2].match[6].team1=EUROqualifier_group[3,2];
		Week[19].fixture[2].match[6].team2=EUROqualifier_group[3,4];
		Week[19].fixture[2].match[7].team1=EUROqualifier_group[4,1];
		Week[19].fixture[2].match[7].team2=EUROqualifier_group[4,3];
		Week[19].fixture[2].match[8].team1=EUROqualifier_group[4,2];
		Week[19].fixture[2].match[8].team2=EUROqualifier_group[4,4];
		/////////////////////////////gold cup/////////////////////////////////////////////////////////////
		for(int k=19;k<=192;k++){ int m=19; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup Quarter final";Week[k].fixture[4].kind="goldcup";  //no 2 
				Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_quarterfinal[1,1];
				Week[k].fixture[4].match[1].team2=Goldcup_quarterfinal[1,2];
				Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
				Week[k].fixture[4].match[2].team1=Goldcup_quarterfinal[2,1];
				Week[k].fixture[4].match[2].team2=Goldcup_quarterfinal[2,2];
				Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
				Week[k].fixture[4].match[3].team1=Goldcup_quarterfinal[3,1];
				Week[k].fixture[4].match[3].team2=Goldcup_quarterfinal[3,2];
				Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
				Week[k].fixture[4].match[4].team1=Goldcup_quarterfinal[4,1];
				Week[k].fixture[4].match[4].team2=Goldcup_quarterfinal[4,2];
				Week[k].fixture[4].match[4].position=2;  Week[k].fixture[4].match[4].group=2;                       }}  //bug fixes here
		//////////////////////////afcon quals////////////////////////////////////////////////////////////////
		for(int k=20;k<=192;k++){ int m=20; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
				Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6
				Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
				Week[k].fixture[2].match[1].team1=AFCONqualifier_group[7,1];
				Week[k].fixture[2].match[1].team2=AFCONqualifier_group[7,2];
				Week[k].fixture[2].match[2].team1=AFCONqualifier_group[7,3];
				Week[k].fixture[2].match[2].team2=AFCONqualifier_group[7,4];
				Week[k].fixture[2].match[3].team1=AFCONqualifier_group[7,5];
				Week[k].fixture[2].match[3].team2=AFCONqualifier_group[7,6];
				Week[k].fixture[2].match[4].team1=AFCONqualifier_group[8,1];
				Week[k].fixture[2].match[4].team2=AFCONqualifier_group[8,2];
				Week[k].fixture[2].match[5].team1=AFCONqualifier_group[8,3];
				Week[k].fixture[2].match[5].team2=AFCONqualifier_group[8,4];
				Week[k].fixture[2].match[6].team1=AFCONqualifier_group[8,5];
				Week[k].fixture[2].match[6].team2=AFCONqualifier_group[8,6];}}
		/////////////////////////uefa cup///////////////////////////////////////////////////////////////////////
		for(int k=20;k<=192;k++){ int m=20; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[3].colour=yellowish;Week[k].fixture[3].category="clubs";  //away(second) leg  last
				Week[k].fixture[3].match[1].team1=Uefacup_group[1,4];  //group,team  4 groups of 4
				Week[k].fixture[3].match[1].team2=Uefacup_group[1,1];
				Week[k].fixture[3].match[2].team1=Uefacup_group[1,2];  
				Week[k].fixture[3].match[2].team2=Uefacup_group[1,3];
				Week[k].fixture[3].match[3].team1=Uefacup_group[2,4];  
				Week[k].fixture[3].match[3].team2=Uefacup_group[2,1];
				Week[k].fixture[3].match[4].team1=Uefacup_group[2,2];  
				Week[k].fixture[3].match[4].team2=Uefacup_group[2,3];
				Week[k].fixture[3].match[5].team1=Uefacup_group[3,4];  
				Week[k].fixture[3].match[5].team2=Uefacup_group[3,1];
				Week[k].fixture[3].match[6].team1=Uefacup_group[3,2];  
				Week[k].fixture[3].match[6].team2=Uefacup_group[3,3];
				Week[k].fixture[3].match[7].team1=Uefacup_group[4,4];  
				Week[k].fixture[3].match[7].team2=Uefacup_group[4,1];
				Week[k].fixture[3].match[8].team1=Uefacup_group[4,2];  
				Week[k].fixture[3].match[8].team2=Uefacup_group[4,3];
				Week[k].fixture[3].match[8].stage="last";
				Week[k].fixture[3].name="European Cup";Week[k].fixture[3].kind="uefacup";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		////////////////////gold cup semi//////////////////////////////////////////////////////////////////////
		for(int k=20;k<=192;k++){ int m=20; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup Semi final";Week[k].fixture[4].kind="goldcup";  //no 2 
				Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_semifinal[1,1];
				Week[k].fixture[4].match[1].team2=Goldcup_semifinal[1,2];
				Week[k].fixture[4].match[1].position=1;
				Week[k].fixture[4].match[2].team1=Goldcup_semifinal[2,1];
				Week[k].fixture[4].match[2].team2=Goldcup_semifinal[2,2];
				Week[k].fixture[4].match[2].position=2;                       }}
		////////////////////////world cup qualification//////////////////////////////////////////////////////////////////
		Week[21].fixture[2].colour=pinkish;Week[21].fixture[2].name="World Cup Qualifying";Week[21].fixture[2].kind="WCQsouthamerica";
		Week[21].fixture[2].type="league"; Week[21].fixture[2].colour=greenish;Week[21].fixture[2].category="countries";               //1 groups of 10  no 2
		Week[21].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
		Week[21].fixture[2].match[1].team2=WCQualifier_sa_group[3];
		Week[21].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
		Week[21].fixture[2].match[2].team2=WCQualifier_sa_group[4];
		Week[21].fixture[2].match[3].team1=WCQualifier_sa_group[5]; 
		Week[21].fixture[2].match[3].team2=WCQualifier_sa_group[7];
		Week[21].fixture[2].match[4].team1=WCQualifier_sa_group[6]; 
		Week[21].fixture[2].match[4].team2=WCQualifier_sa_group[9];
		Week[21].fixture[2].match[5].team1=WCQualifier_sa_group[8]; 
		Week[21].fixture[2].match[5].team2=WCQualifier_sa_group[10];Week[21].fixture[2].stage="group";
		///////////////////////world cup qualifier africa////////////////////////////////////////////////////////////////////////////////////
		Week[21].fixture[africa2].colour=pinkish;Week[21].fixture[africa2].name="World Cup Qualifying";Week[21].fixture[africa2].kind="WCQafrica";
		Week[21].fixture[africa2].type="group";Week[21].fixture[africa2].category="countries";           //first group fixture
		Week[21].fixture[africa2].match[1].team1=WCQualifier_af_group[1,1];  //5 groups of 5
		Week[21].fixture[africa2].match[1].team2=WCQualifier_af_group[1,3];
		Week[21].fixture[africa2].match[2].team1=WCQualifier_af_group[1,2]; 
		Week[21].fixture[africa2].match[2].team2=WCQualifier_af_group[1,4];
		Week[21].fixture[africa2].match[3].team1=WCQualifier_af_group[2,1];  
		Week[21].fixture[africa2].match[3].team2=WCQualifier_af_group[2,3];
		Week[21].fixture[africa2].match[4].team1=WCQualifier_af_group[2,2]; 
		Week[21].fixture[africa2].match[4].team2=WCQualifier_af_group[2,4];
		Week[21].fixture[africa2].match[5].team1=WCQualifier_af_group[3,1]; 
		Week[21].fixture[africa2].match[5].team2=WCQualifier_af_group[3,3];
		Week[21].fixture[africa2].match[6].team1=WCQualifier_af_group[3,2]; 
		Week[21].fixture[africa2].match[6].team2=WCQualifier_af_group[3,4];
		Week[21].fixture[africa2].match[7].team1=WCQualifier_af_group[4,1];  
		Week[21].fixture[africa2].match[7].team2=WCQualifier_af_group[4,3];
		Week[21].fixture[africa2].match[8].team1=WCQualifier_af_group[4,2]; 
		Week[21].fixture[africa2].match[8].team2=WCQualifier_af_group[4,4];
		Week[21].fixture[africa2].match[9].team1=WCQualifier_af_group[5,1]; 
		Week[21].fixture[africa2].match[9].team2=WCQualifier_af_group[5,5];Week[21].fixture[africa2].stage="group";
		///////////////////////world cup qualifier asia/////////////////////////////////////////////////////////////////////////////////////////////
		Week[21].fixture[asia2].colour=pinkish;Week[21].fixture[asia2].name="World Cup Qualifying";Week[21].fixture[asia2].kind="WCQasia";
		Week[21].fixture[asia2].type="group";Week[21].fixture[asia2].category="countries";               //2nd group round
		Week[21].fixture[asia2].match[1].team1=WCQualifier_as_group[1,2];  //4 groups of 5
		Week[21].fixture[asia2].match[1].team2=WCQualifier_as_group[1,5]; 
		Week[21].fixture[asia2].match[2].team1=WCQualifier_as_group[2,2];  
		Week[21].fixture[asia2].match[2].team2=WCQualifier_as_group[2,5];
		Week[21].fixture[asia2].match[3].team1=WCQualifier_as_group[3,2];  
		Week[21].fixture[asia2].match[3].team2=WCQualifier_as_group[3,5];
		Week[21].fixture[asia2].match[4].team1=WCQualifier_as_group[4,2];  
		Week[21].fixture[asia2].match[4].team2=WCQualifier_as_group[4,5];Week[21].fixture[asia2].stage="group";
		///////////////////////world cup qualifier northamerica//////////////////////////////////////////////////////////////////////////////////////
		Week[21].fixture[northamerica2].colour=pinkish;Week[21].fixture[northamerica2].name="World Cup Qualifying";
		Week[21].fixture[northamerica2].kind="WCQnorthamerica";    
		Week[21].fixture[northamerica2].type="league";Week[21].fixture[northamerica2].category="countries"; 
		Week[21].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
		Week[21].fixture[northamerica2].match[1].team2= WCQualifier_na_group[5];
		Week[21].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
		Week[21].fixture[northamerica2].match[2].team2= WCQualifier_na_group[7];
		Week[21].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
		Week[21].fixture[northamerica2].match[3].team2= WCQualifier_na_group[6];
		Week[21].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
		Week[21].fixture[northamerica2].match[4].team2= WCQualifier_na_group[8];
		Week[21].fixture[northamerica2].match[5].team1= WCQualifier_na_group[14];
		Week[21].fixture[northamerica2].match[5].team2= WCQualifier_na_group[12];
		Week[21].fixture[northamerica2].match[6].team1= WCQualifier_na_group[10];
		Week[21].fixture[northamerica2].match[6].team2= WCQualifier_na_group[16];
		Week[21].fixture[northamerica2].match[7].team1= WCQualifier_na_group[11];
		Week[21].fixture[northamerica2].match[7].team2= WCQualifier_na_group[16];
		Week[21].fixture[northamerica2].match[8].team1= WCQualifier_na_group[9];
		Week[21].fixture[northamerica2].match[8].team2= WCQualifier_na_group[13];Week[21].fixture[northamerica2].stage="group";
		/////////////////////////euro qualification///////////////////////////////////////////////////////////////////////////
		Week[21].fixture[3].name="Euro Qualifier";Week[21].fixture[3].kind="euroquals";
		Week[21].fixture[3].type="league";Week[21].fixture[3].stage="group";  //8 groups of 5
		Week[21].fixture[3].colour=greenish;Week[21].fixture[3].category="countries"; 
		Week[21].fixture[3].match[1].team1=EUROqualifier_group[5,1];
		Week[21].fixture[3].match[1].team2=EUROqualifier_group[5,3];
		Week[21].fixture[3].match[2].team1=EUROqualifier_group[5,2];
		Week[21].fixture[3].match[2].team2=EUROqualifier_group[5,4];
		Week[21].fixture[3].match[3].team1=EUROqualifier_group[6,1];
		Week[21].fixture[3].match[3].team2=EUROqualifier_group[6,3];
		Week[21].fixture[3].match[4].team1=EUROqualifier_group[6,2];
		Week[21].fixture[3].match[4].team2=EUROqualifier_group[6,4];
		Week[21].fixture[3].match[5].team1=EUROqualifier_group[7,1];
		Week[21].fixture[3].match[5].team2=EUROqualifier_group[7,3];
		Week[21].fixture[3].match[6].team1=EUROqualifier_group[7,2];
		Week[21].fixture[3].match[6].team2=EUROqualifier_group[7,4];
		Week[21].fixture[3].match[7].team1=EUROqualifier_group[8,1];
		Week[21].fixture[3].match[7].team2=EUROqualifier_group[8,3];
		Week[21].fixture[3].match[8].team1=EUROqualifier_group[8,2];
		Week[21].fixture[3].match[8].team2=EUROqualifier_group[8,4];
		///////////////////gold cup final/////////////////////////////////////////////////////////////////////////////////
		for(int k=21;k<=192;k++){ int m=21; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Gold Cup final";Week[k].fixture[4].kind="goldcup";  //no 2 
				Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=Goldcup_final[1];
				Week[k].fixture[4].match[1].team2=Goldcup_final[2];  }}
		///////////////////spanish cup/////////////////////////////////////////////////////////////////////////////
		for(int k=21;k<=192;k++){ int m=21; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[liga2].match[1].team1=Spanishcup_quarterfinal[1,1];
				Week[k].fixture[liga2].match[1].team2=Spanishcup_quarterfinal[1,2];
				Week[k].fixture[liga2].match[1].position=1;Week[k].fixture[liga2].match[1].group=1;
				Week[k].fixture[liga2].match[2].team1=Spanishcup_quarterfinal[2,1];
				Week[k].fixture[liga2].match[2].team2=Spanishcup_quarterfinal[2,2];
				Week[k].fixture[liga2].match[2].position=2;Week[k].fixture[liga2].match[2].group=1;
				Week[k].fixture[liga2].match[3].team1=Spanishcup_quarterfinal[3,1];
				Week[k].fixture[liga2].match[3].team2=Spanishcup_quarterfinal[3,2];
				Week[k].fixture[liga2].match[3].position=1;Week[k].fixture[liga2].match[1].group=2;
				Week[k].fixture[liga2].match[4].team1=Spanishcup_quarterfinal[4,1];
				Week[k].fixture[liga2].match[4].team2=Spanishcup_quarterfinal[4,2];
				Week[k].fixture[liga2].match[4].position=2;Week[k].fixture[liga2].match[2].group=2;
				Week[k].fixture[liga2].colour=pinkish;Week[k].fixture[liga2].category="clubs";
				Week[k].fixture[liga2].name="Spanish Cup quarter final";Week[k].fixture[liga2].kind="spanishcup";
				Week[k].fixture[liga2].type="knockout";Week[k].fixture[liga2].stage="quarterfinal";}}
		//////////////////////italian cup////////////////////////////////////////////////////////////////////////////////
		for(int k=22;k<=192;k++){ int m=22; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[seriea2].match[1].team1=Italiancup_quarterfinal[1,1];
				Week[k].fixture[seriea2].match[1].team2=Italiancup_quarterfinal[1,2];
				Week[k].fixture[seriea2].match[1].position=1;Week[k].fixture[seriea2].match[1].group=1;
				Week[k].fixture[seriea2].match[2].team1=Italiancup_quarterfinal[2,1];
				Week[k].fixture[seriea2].match[2].team2=Italiancup_quarterfinal[2,2];
				Week[k].fixture[seriea2].match[2].position=2;Week[k].fixture[seriea2].match[2].group=1;
				Week[k].fixture[seriea2].match[3].team1=Italiancup_quarterfinal[3,1];
				Week[k].fixture[seriea2].match[3].team2=Italiancup_quarterfinal[3,2];
				Week[k].fixture[seriea2].match[3].position=1;Week[k].fixture[seriea2].match[3].group=2;
				Week[k].fixture[seriea2].match[4].team1=Italiancup_quarterfinal[4,1];
				Week[k].fixture[seriea2].match[4].team2=Italiancup_quarterfinal[4,2];
				Week[k].fixture[seriea2].match[4].position=2;Week[k].fixture[seriea2].match[4].group=2;
				Week[k].fixture[seriea2].colour=pinkish;Week[k].fixture[seriea2].category="clubs";
				Week[k].fixture[seriea2].name="Italian Cup quarter final";Week[k].fixture[seriea2].kind="italiancup";
				Week[k].fixture[seriea2].type="knockout";Week[k].fixture[seriea2].stage="quarterfinal";
				///////////////////////german cup//////////////////////////////////////////////////////////////////////////////
				Week[k].fixture[bundes2].match[1].team1=Germancup_quarterfinal[1,1];
				Week[k].fixture[bundes2].match[1].team2=Germancup_quarterfinal[1,2];
				Week[k].fixture[bundes2].match[1].position=1;Week[k].fixture[bundes2].match[1].group=1;
				Week[k].fixture[bundes2].match[2].team1=Germancup_quarterfinal[2,1];
				Week[k].fixture[bundes2].match[2].team2=Germancup_quarterfinal[2,2];
				Week[k].fixture[bundes2].match[2].position=2;Week[k].fixture[bundes2].match[2].group=1;
				Week[k].fixture[bundes2].match[3].team1=Germancup_quarterfinal[3,1];
				Week[k].fixture[bundes2].match[3].team2=Germancup_quarterfinal[3,2];
				Week[k].fixture[bundes2].match[3].position=1;Week[k].fixture[bundes2].match[3].group=2;
				Week[k].fixture[bundes2].match[4].team1=Germancup_quarterfinal[4,1];
				Week[k].fixture[bundes2].match[4].team2=Germancup_quarterfinal[4,2];
				Week[k].fixture[bundes2].match[4].position=2;Week[k].fixture[bundes2].match[4].group=2;
				Week[k].fixture[bundes2].colour=pinkish;Week[k].fixture[bundes2].category="clubs";
				Week[k].fixture[bundes2].name="German Cup quarter final";Week[k].fixture[bundes2].kind="germancup";
				Week[k].fixture[bundes2].type="knockout";Week[k].fixture[bundes2].stage="quarterfinal";}}
		////////////////////////////////asian cup//////////////////////////////////////////////////////////////
		for(int k=22;k<=192;k++){ int m=22; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no 1
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=ASIANcup_group[1,1];
				Week[k].fixture[4].match[1].team2=ASIANcup_group[1,2];
				Week[k].fixture[4].match[2].team1=ASIANcup_group[1,3];
				Week[k].fixture[4].match[2].team2=ASIANcup_group[1,4];
				Week[k].fixture[4].match[3].team1=ASIANcup_group[2,1];
				Week[k].fixture[4].match[3].team2=ASIANcup_group[2,2];
				Week[k].fixture[4].match[4].team1=ASIANcup_group[2,3];
				Week[k].fixture[4].match[4].team2=ASIANcup_group[2,4];
				Week[k].fixture[4].match[5].team1=ASIANcup_group[3,1];
				Week[k].fixture[4].match[5].team2=ASIANcup_group[3,2];
				Week[k].fixture[4].match[6].team1=ASIANcup_group[3,3];
				Week[k].fixture[4].match[6].team2=ASIANcup_group[3,4];
				Week[k].fixture[4].match[7].team1=ASIANcup_group[4,1];
				Week[k].fixture[4].match[7].team2=ASIANcup_group[4,2];
				Week[k].fixture[4].match[8].team1=ASIANcup_group[4,3];
				Week[k].fixture[4].match[8].team2=ASIANcup_group[4,4];  }}
		///////////////////////fa cup/////////////////////////////////////////////////////////////////////////////////////////////////
		for(int k=23;k<=192;k++){ int m=23; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[1].colour=pinkish;  //playoffs
				Week[k].fixture[1].name="FA Cup playoffs";Week[k].fixture[1].kind="facup";Week[k].fixture[1].category="clubs";
				Week[k].fixture[1].type="knockout";Week[k].fixture[1].stage="playoffs2";
				Week[k].fixture[1].match[1].team1=FAcup_playoffs2[1,1];
				Week[k].fixture[1].match[1].team2=FAcup_playoffs2[1,2];
				Week[k].fixture[1].match[1].position=1;
				Week[k].fixture[1].match[2].team1=FAcup_playoffs2[2,1];
				Week[k].fixture[1].match[2].team2=FAcup_playoffs2[2,2];
				Week[k].fixture[1].match[2].position=2;
				Week[k].fixture[1].match[3].team1=FAcup_playoffs2[3,1];
				Week[k].fixture[1].match[3].team2=FAcup_playoffs2[3,2];  //bug fix
				Week[k].fixture[1].match[3].position=3;
			}}
		//////////////////////////euro qualifiers////////////////////////////////////////////////////////////////////////////////////
		Week[23].fixture[2].name="Euro Qualifier";Week[23].fixture[2].kind="euroquals";
		Week[23].fixture[2].type="league";Week[23].fixture[2].stage="group";  //8 groups of 5
		Week[23].fixture[2].colour=greenish;Week[23].fixture[2].category="countries";
		Week[23].fixture[2].match[1].team1=EUROqualifier_group[1,1];
		Week[23].fixture[2].match[1].team2=EUROqualifier_group[1,4];
		Week[23].fixture[2].match[2].team1=EUROqualifier_group[1,2];
		Week[23].fixture[2].match[2].team2=EUROqualifier_group[1,3];
		Week[23].fixture[2].match[3].team1=EUROqualifier_group[2,1];
		Week[23].fixture[2].match[3].team2=EUROqualifier_group[2,3];
		Week[23].fixture[2].match[4].team1=EUROqualifier_group[2,2];
		Week[23].fixture[2].match[4].team2=EUROqualifier_group[2,3];
		Week[23].fixture[2].match[5].team1=EUROqualifier_group[3,1];
		Week[23].fixture[2].match[5].team2=EUROqualifier_group[3,4];
		Week[23].fixture[2].match[6].team1=EUROqualifier_group[3,2];
		Week[23].fixture[2].match[6].team2=EUROqualifier_group[3,3];
		Week[23].fixture[2].match[7].team1=EUROqualifier_group[4,1];
		Week[23].fixture[2].match[7].team2=EUROqualifier_group[4,4];
		Week[23].fixture[2].match[8].team1=EUROqualifier_group[4,2];
		Week[23].fixture[2].match[8].team2=EUROqualifier_group[4,3];
		//////////////////////asian cup/////////////////////////////////////////////////////////////////////////
		for(int k=23;k<=192;k++){ int m=23; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
				Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no 2
				Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
				Week[k].fixture[4].match[1].team1=ASIANcup_group[1,1];
				Week[k].fixture[4].match[1].team2=ASIANcup_group[1,5];
				Week[k].fixture[4].match[2].team1=ASIANcup_group[2,1];
				Week[k].fixture[4].match[2].team2=ASIANcup_group[2,5];
				Week[k].fixture[4].match[3].team1=ASIANcup_group[3,1];
				Week[k].fixture[4].match[3].team2=ASIANcup_group[3,5];
				Week[k].fixture[4].match[4].team1=ASIANcup_group[4,1];
				Week[k].fixture[4].match[4].team2=ASIANcup_group[4,5]; }}
		////////////////////////////afcon quals/////////////////////////////////////////////////////////////////////////
		for(int k=24;k<=192;k++){ int m=24; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
				Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6
				Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
				Week[k].fixture[2].match[1].team1=AFCONqualifier_group[1,1];
				Week[k].fixture[2].match[1].team2=AFCONqualifier_group[1,3];
				Week[k].fixture[2].match[2].team1=AFCONqualifier_group[1,2];
				Week[k].fixture[2].match[2].team2=AFCONqualifier_group[1,5];
				Week[k].fixture[2].match[3].team1=AFCONqualifier_group[1,4];
				Week[k].fixture[2].match[3].team2=AFCONqualifier_group[1,6];
				Week[k].fixture[2].match[4].team1=AFCONqualifier_group[2,1];
				Week[k].fixture[2].match[4].team2=AFCONqualifier_group[2,3];
				Week[k].fixture[2].match[5].team1=AFCONqualifier_group[2,2];
				Week[k].fixture[2].match[5].team2=AFCONqualifier_group[2,5];
				Week[k].fixture[2].match[6].team1=AFCONqualifier_group[2,4];
				Week[k].fixture[2].match[6].team2=AFCONqualifier_group[2,6];
				Week[k].fixture[2].match[7].team1=AFCONqualifier_group[3,1];
				Week[k].fixture[2].match[7].team2=AFCONqualifier_group[3,3];
				Week[k].fixture[2].match[8].team1=AFCONqualifier_group[3,2];
				Week[k].fixture[2].match[8].team2=AFCONqualifier_group[3,5];
				Week[k].fixture[2].match[9].team1=AFCONqualifier_group[3,4];
				Week[k].fixture[2].match[9].team2=AFCONqualifier_group[3,6];}}
		////////////////////////friendly////////////////////////////////////////////////////////////////////////////////////////
		if(global.category=="countries"){
			Week[25].fixture[2].match[1].team1=Friendly[5,1]; //<=always own country //14 friendlies in 4 years
			Week[25].fixture[2].match[1].team2=Friendly[5,2];
			Week[25].fixture[2].colour=bluish;Week[25].fixture[2].category="countries";
			Week[25].fixture[2].name="Friendly";Week[25].fixture[2].kind="friendly";}
		//////////////////////afcon quals///////////////////////////////////////////////////////////////////////////////////////////////
		for(int k=25;k<=192;k++){ int m=25; if( Contains(new int[]{m,m+96},k) ){
				Week[k].fixture[3].name="AFCON Qualifiers";Week[k].fixture[3].kind="afconquals";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";  //8 groups of 6
				Week[k].fixture[3].colour=bluish;Week[k].fixture[3].category="countries";
				Week[k].fixture[3].match[1].team1=AFCONqualifier_group[4,1];
				Week[k].fixture[3].match[1].team2=AFCONqualifier_group[4,3];
				Week[k].fixture[3].match[2].team1=AFCONqualifier_group[4,2];
				Week[k].fixture[3].match[2].team2=AFCONqualifier_group[4,5];
				Week[k].fixture[3].match[3].team1=AFCONqualifier_group[4,4];
				Week[k].fixture[3].match[3].team2=AFCONqualifier_group[4,6];
				Week[k].fixture[3].match[4].team1=AFCONqualifier_group[5,1];
				Week[k].fixture[3].match[4].team2=AFCONqualifier_group[5,3];
				Week[k].fixture[3].match[5].team1=AFCONqualifier_group[5,2];
				Week[k].fixture[3].match[5].team2=AFCONqualifier_group[5,5];
				Week[k].fixture[3].match[6].team1=AFCONqualifier_group[5,4];
				Week[k].fixture[3].match[6].team2=AFCONqualifier_group[5,6];
				Week[k].fixture[3].match[7].team1=AFCONqualifier_group[6,1];
				Week[k].fixture[3].match[7].team2=AFCONqualifier_group[6,3];
				Week[k].fixture[3].match[8].team1=AFCONqualifier_group[6,2];
				Week[k].fixture[3].match[8].team2=AFCONqualifier_group[6,5];
				Week[k].fixture[3].match[9].team1=AFCONqualifier_group[6,4];
				Week[k].fixture[3].match[9].team2=AFCONqualifier_group[6,6]; }}
		////////////////////fa cup////////////////////////////////////////////////////////////////////////////////////
		for(int k=26;k<=192;k++){ int m=26; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
				Week[k].fixture[2].colour=pinkish;  //playoffs
				Week[k].fixture[2].name="FA Cup";Week[k].fixture[2].kind="facup";Week[k].fixture[2].category="clubs";
				Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="roundof16";
				Week[k].fixture[2].match[1].team1=FAcup_round1[1,1];
				Week[k].fixture[2].match[1].team2=FAcup_round1[1,2];
				Week[k].fixture[2].match[1].position=1;Week[k].fixture[2].match[1].group=1;
				Week[k].fixture[2].match[2].team1=FAcup_round1[2,1];
				Week[k].fixture[2].match[2].team2=FAcup_round1[2,2];
				Week[k].fixture[2].match[2].position=2;Week[k].fixture[2].match[2].group=1;
				Week[k].fixture[2].match[3].team1=FAcup_round1[3,1];
				Week[k].fixture[2].match[3].team2=FAcup_round1[3,2];
				Week[k].fixture[2].match[3].position=1;Week[k].fixture[2].match[3].group=2;
				Week[k].fixture[2].match[4].team1=FAcup_round1[4,1];
				Week[k].fixture[2].match[4].team2=FAcup_round1[4,2];
				Week[k].fixture[2].match[4].position=2;Week[k].fixture[2].match[4].group=2;
				Week[k].fixture[2].match[5].team1=FAcup_round1[5,1];
				Week[k].fixture[2].match[5].team2=FAcup_round1[5,2];
				Week[k].fixture[2].match[5].position=1;Week[k].fixture[2].match[5].group=3;
				Week[k].fixture[2].match[6].team1=FAcup_round1[6,1];
				Week[k].fixture[2].match[6].team2=FAcup_round1[6,2];
				Week[k].fixture[2].match[6].position=2;Week[k].fixture[2].match[6].group=3;
				Week[k].fixture[2].match[7].team1=FAcup_round1[7,1];
				Week[k].fixture[2].match[7].team2=FAcup_round1[7,2];
				Week[k].fixture[2].match[7].position=1;Week[k].fixture[2].match[7].group=4;
				Week[k].fixture[2].match[8].team1=FAcup_round1[8,1];
				Week[k].fixture[2].match[8].team2=FAcup_round1[8,2];
				Week[k].fixture[2].match[8].position=2;Week[k].fixture[2].match[8].group=4;
				///////////////////champions league////////////////////////////////////////////////////////////////////////////
				Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";    //second leg no 1
				Week[k].fixture[3].match[1].team1=Championsleague_group[1,2];  //group,team
				Week[k].fixture[3].match[1].team2=Championsleague_group[1,1];
				Week[k].fixture[3].match[2].team1=Championsleague_group[1,4];  //group,team
				Week[k].fixture[3].match[2].team2=Championsleague_group[1,3];
				Week[k].fixture[3].match[3].team1=Championsleague_group[2,2];  //group,team
				Week[k].fixture[3].match[3].team2=Championsleague_group[2,1];
				Week[k].fixture[3].match[4].team1=Championsleague_group[2,4];  //group,team
				Week[k].fixture[3].match[4].team2=Championsleague_group[2,3];
				Week[k].fixture[3].match[5].team1=Championsleague_group[3,2];  //group,team
				Week[k].fixture[3].match[5].team2=Championsleague_group[3,1];
				Week[k].fixture[3].match[6].team1=Championsleague_group[3,4];  //group,team
				Week[k].fixture[3].match[6].team2=Championsleague_group[3,3];
				Week[k].fixture[3].match[7].team1=Championsleague_group[4,2];  //group,team
				Week[k].fixture[3].match[7].team2=Championsleague_group[4,1];
				Week[k].fixture[3].match[8].team1=Championsleague_group[4,4];  //group,team
				Week[k].fixture[3].match[8].team2=Championsleague_group[4,3];
				Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
				Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
		////////////////friendly////////////////////////////////////////////////////////////////////////////////////////
		/*if(global.category=="countries"){
		Week[27].fixture[2].match[1].team1=Friendly[6,1]; //<=always own country //14 friendlies in 4 years
		Week[27].fixture[2].match[1].team2=Friendly[6,2];
		Week[27].fixture[2].colour=bluish;
		Week[27].fixture[2].name="Friendly";Week[27].fixture[2].kind="friendly";}*/
	//////////////////////champions league/////////////////////////////////////////////////////////////////////////
	for(int k=27;k<=192;k++){ int m=27; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";     //second leg no 1          //8 groups of 4
			Week[k].fixture[3].match[1].team1=Championsleague_group[5,2];  //group,team
			Week[k].fixture[3].match[1].team2=Championsleague_group[5,1];
			Week[k].fixture[3].match[2].team1=Championsleague_group[5,4];  //group,team
			Week[k].fixture[3].match[2].team2=Championsleague_group[5,3];
			Week[k].fixture[3].match[3].team1=Championsleague_group[6,2];  //group,team
			Week[k].fixture[3].match[3].team2=Championsleague_group[6,1];
			Week[k].fixture[3].match[4].team1=Championsleague_group[6,4];  //group,team
			Week[k].fixture[3].match[4].team2=Championsleague_group[6,3];
			Week[k].fixture[3].match[5].team1=Championsleague_group[7,2];  //group,team
			Week[k].fixture[3].match[5].team2=Championsleague_group[7,1];
			Week[k].fixture[3].match[6].team1=Championsleague_group[7,4];  //group,team
			Week[k].fixture[3].match[6].team2=Championsleague_group[7,3];
			Week[k].fixture[3].match[7].team1=Championsleague_group[8,2];  //group,team
			Week[k].fixture[3].match[7].team2=Championsleague_group[8,1];
			Week[k].fixture[3].match[8].team1=Championsleague_group[8,4];  //group,team
			Week[k].fixture[3].match[8].team2=Championsleague_group[8,3];
			Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
	//////////////////afcon quals//////////////////////////////////////////////////////////////////////////////////////
	for(int k=28;k<=192;k++){ int m=28; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
			Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6
			Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
			Week[k].fixture[2].match[1].team1=AFCONqualifier_group[7,1];
			Week[k].fixture[2].match[1].team2=AFCONqualifier_group[7,3];
			Week[k].fixture[2].match[2].team1=AFCONqualifier_group[7,2];
			Week[k].fixture[2].match[2].team2=AFCONqualifier_group[7,5];
			Week[k].fixture[2].match[3].team1=AFCONqualifier_group[7,4];
			Week[k].fixture[2].match[3].team2=AFCONqualifier_group[7,6];
			Week[k].fixture[2].match[4].team1=AFCONqualifier_group[8,1];
			Week[k].fixture[2].match[4].team2=AFCONqualifier_group[8,3];
			Week[k].fixture[2].match[5].team1=AFCONqualifier_group[8,2];
			Week[k].fixture[2].match[5].team2=AFCONqualifier_group[8,5];
			Week[k].fixture[2].match[6].team1=AFCONqualifier_group[8,4];
			Week[k].fixture[2].match[6].team2=AFCONqualifier_group[8,6]; }}
	///////////////////////////uefa cup//////////////////////////////////////////////////////////////////////////////////
	for(int k=28;k<=192;k++){ int m=28; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[3].match[1].team1=Uefacup_quarterfinal[1,1];  //leg 1
			Week[k].fixture[3].match[1].team2=Uefacup_quarterfinal[1,2];
			Week[k].fixture[3].match[1].position=1;Week[k].fixture[3].match[1].group=1;
			Week[k].fixture[3].match[2].team1=Uefacup_quarterfinal[2,1];  
			Week[k].fixture[3].match[2].team2=Uefacup_quarterfinal[2,2];
			Week[k].fixture[3].match[2].position=2;Week[k].fixture[3].match[2].group=1;
			Week[k].fixture[3].match[3].team1=Uefacup_quarterfinal[3,1];  
			Week[k].fixture[3].match[3].team2=Uefacup_quarterfinal[3,2];
			Week[k].fixture[3].match[3].position=1;Week[k].fixture[3].match[3].group=2;
			Week[k].fixture[3].match[4].team1=Uefacup_quarterfinal[4,1];  
			Week[k].fixture[3].match[4].team2=Uefacup_quarterfinal[4,2];
			Week[k].fixture[3].match[4].position=2;Week[k].fixture[3].match[4].group=2;
			Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].category="clubs"; 
			Week[k].fixture[3].name="European Cup quarter final";Week[k].fixture[3].kind="uefacup";
			Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="quarterfinal";}}
	/////////////////////////euro qualifier//////////////////////////////////////////////////////////////////////
	Week[29].fixture[2].name="Euro Qualifier";Week[29].fixture[2].kind="euroquals";
	Week[29].fixture[2].type="league";Week[29].fixture[2].stage="group";  //8 groups of 5
	Week[29].fixture[2].colour=greenish;Week[29].fixture[2].category="countries";
	Week[29].fixture[2].match[1].team1=EUROqualifier_group[5,1];
	Week[29].fixture[2].match[1].team2=EUROqualifier_group[5,4];
	Week[29].fixture[2].match[2].team1=EUROqualifier_group[5,2];
	Week[29].fixture[2].match[2].team2=EUROqualifier_group[5,3];
	Week[29].fixture[2].match[3].team1=EUROqualifier_group[6,1];
	Week[29].fixture[2].match[3].team2=EUROqualifier_group[6,4];
	Week[29].fixture[2].match[4].team1=EUROqualifier_group[6,2];
	Week[29].fixture[2].match[4].team2=EUROqualifier_group[6,3];
	Week[29].fixture[2].match[5].team1=EUROqualifier_group[7,1];
	Week[29].fixture[2].match[5].team2=EUROqualifier_group[7,4];
	Week[29].fixture[2].match[6].team1=EUROqualifier_group[7,2];
	Week[29].fixture[2].match[6].team2=EUROqualifier_group[7,3];
	Week[29].fixture[2].match[7].team1=EUROqualifier_group[8,1];
	Week[29].fixture[2].match[7].team2=EUROqualifier_group[8,4];
	Week[29].fixture[2].match[8].team1=EUROqualifier_group[8,2];
	Week[29].fixture[2].match[8].team2=EUROqualifier_group[8,3];
	////////////////////afcon quals////////////////////////////////////////////////////////////////////////////////////
	for(int k=29;k<=192;k++){ int m=29; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[3].name="AFCON Qualifiers";Week[k].fixture[3].kind="afconquals";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";  //8 groups of 6 second last of first half
			Week[k].fixture[3].colour=bluish;Week[k].fixture[3].category="countries";
			Week[k].fixture[3].match[1].team1=AFCONqualifier_group[1,1];
			Week[k].fixture[3].match[1].team2=AFCONqualifier_group[1,4];
			Week[k].fixture[3].match[2].team1=AFCONqualifier_group[1,2];
			Week[k].fixture[3].match[2].team2=AFCONqualifier_group[1,6];
			Week[k].fixture[3].match[3].team1=AFCONqualifier_group[1,3];
			Week[k].fixture[3].match[3].team2=AFCONqualifier_group[1,5];
			Week[k].fixture[3].match[4].team1=AFCONqualifier_group[2,1];
			Week[k].fixture[3].match[4].team2=AFCONqualifier_group[2,4];
			Week[k].fixture[3].match[5].team1=AFCONqualifier_group[2,2];
			Week[k].fixture[3].match[5].team2=AFCONqualifier_group[2,6];
			Week[k].fixture[3].match[6].team1=AFCONqualifier_group[2,3];
			Week[k].fixture[3].match[6].team2=AFCONqualifier_group[2,5];
			Week[k].fixture[3].match[7].team1=AFCONqualifier_group[3,1];
			Week[k].fixture[3].match[7].team2=AFCONqualifier_group[3,4];
			Week[k].fixture[3].match[8].team1=AFCONqualifier_group[3,2];
			Week[k].fixture[3].match[8].team2=AFCONqualifier_group[3,6];
			Week[k].fixture[3].match[9].team1=AFCONqualifier_group[3,3];
			Week[k].fixture[3].match[9].team2=AFCONqualifier_group[3,5]; }}
	///////////////////fa cup//////////////////////////////////////////////////////////////////////////////////////////
	for(int k=30;k<=192;k++){ int m=30; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[1].colour=pinkish;  //playoffs
			Week[k].fixture[1].name="FA Cup";Week[k].fixture[1].kind="facup";Week[k].fixture[1].category="clubs"; 
			Week[k].fixture[1].type="knockout";Week[k].fixture[1].stage="quarterfinal";
			Week[k].fixture[1].match[1].team1=FAcup_quarterfinal[1,1];
			Week[k].fixture[1].match[1].team2=FAcup_quarterfinal[1,2];
			Week[k].fixture[1].match[1].position=1;Week[k].fixture[1].match[1].group=1;
			Week[k].fixture[1].match[2].team1=FAcup_quarterfinal[2,1];
			Week[k].fixture[1].match[2].team2=FAcup_quarterfinal[2,2];
			Week[k].fixture[1].match[2].position=2;Week[k].fixture[1].match[2].group=1;
			Week[k].fixture[1].match[3].team1=FAcup_quarterfinal[3,1];
			Week[k].fixture[1].match[3].team2=FAcup_quarterfinal[3,2];
			Week[k].fixture[1].match[3].position=1;Week[k].fixture[1].match[3].group=2;
			Week[k].fixture[1].match[4].team1=FAcup_quarterfinal[4,1];
			Week[k].fixture[1].match[4].team2=FAcup_quarterfinal[4,2];
			Week[k].fixture[1].match[4].position=2;Week[k].fixture[1].match[4].group=2;
			///////////////////////////league cup////////////////////////////////////////////////////////////////
			Week[k].fixture[2].match[1].team1=Leaguecup_final[1];
			Week[k].fixture[2].match[1].team2=Leaguecup_final[2];
			Week[k].fixture[2].colour=pinkish;
			Week[k].fixture[2].name="League Cup final";Week[k].fixture[2].kind="leaguecup";
			Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="final";Week[k].fixture[2].category="clubs";
			/////////////////////////champions league///////////////////////////////////////////////////////////////////////////////
			Week[k].fixture[3].colour=violet;    //second leg no 2
			Week[k].fixture[3].match[1].team1=Championsleague_group[1,3];  //group,team
			Week[k].fixture[3].match[1].team2=Championsleague_group[1,1];
			Week[k].fixture[3].match[2].team1=Championsleague_group[1,4];  //group,team
			Week[k].fixture[3].match[2].team2=Championsleague_group[1,2];
			Week[k].fixture[3].match[3].team1=Championsleague_group[2,3];  //group,team
			Week[k].fixture[3].match[3].team2=Championsleague_group[2,1];
			Week[k].fixture[3].match[4].team1=Championsleague_group[2,4];  //group,team
			Week[k].fixture[3].match[4].team2=Championsleague_group[2,2];
			Week[k].fixture[3].match[5].team1=Championsleague_group[3,3];  //group,team
			Week[k].fixture[3].match[5].team2=Championsleague_group[3,1];
			Week[k].fixture[3].match[6].team1=Championsleague_group[3,4];  //group,team
			Week[k].fixture[3].match[6].team2=Championsleague_group[3,2];
			Week[k].fixture[3].match[7].team1=Championsleague_group[4,3];  //group,team
			Week[k].fixture[3].match[7].team2=Championsleague_group[4,1];
			Week[k].fixture[3].match[8].team1=Championsleague_group[4,4];  //group,team
			Week[k].fixture[3].match[8].team2=Championsleague_group[4,2];
			Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";Week[k].fixture[3].category="clubs";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
	////////////////////world cup qualification//////////////////////////////////////////////////////////////////////////////
	Week[31].fixture[2].colour=pinkish;Week[31].fixture[2].name="World Cup Qualifying";Week[31].fixture[2].kind="WCQoceania";
	Week[31].fixture[2].type="group"; Week[31].fixture[2].category="countries";                   //1 group of 8 no 2
	Week[31].fixture[2].match[1].team1=WCQualifier_oc_group[1];
	Week[31].fixture[2].match[1].team2=WCQualifier_oc_group[3];
	Week[31].fixture[2].match[2].team1=WCQualifier_oc_group[2];
	Week[31].fixture[2].match[2].team2=WCQualifier_oc_group[4];
	Week[31].fixture[2].match[3].team1=WCQualifier_oc_group[5];
	Week[31].fixture[2].match[3].team2=WCQualifier_oc_group[7];
	Week[31].fixture[2].match[4].team1=WCQualifier_oc_group[6];
	Week[31].fixture[2].match[4].team2=WCQualifier_oc_group[8];Week[31].fixture[2].stage="group";
	///////////////////////spanish cup////////////////////////////////////////////////////////////////////////
	for(int k=31;k<=192;k++){ int m=31; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[liga2].match[1].team1=Spanishcup_semifinal[1,1];
			Week[k].fixture[liga2].match[1].team2=Spanishcup_semifinal[1,2];
			Week[k].fixture[liga2].match[1].position=1;
			Week[k].fixture[liga2].match[2].team1=Spanishcup_semifinal[2,1];
			Week[k].fixture[liga2].match[2].team2=Spanishcup_semifinal[2,2];
			Week[k].fixture[liga2].match[2].position=2;
			Week[k].fixture[liga2].colour=pinkish;Week[k].fixture[liga2].category="clubs";
			Week[k].fixture[liga2].name="Spanish Cup semi";Week[k].fixture[liga2].kind="spanishcup";
			Week[k].fixture[liga2].type="knockout";Week[k].fixture[liga2].stage="semifinal";
			///////////////////////////Italian cup////////////////////////////////////////////////////////////////////////////
			Week[k].fixture[seriea2].match[1].team1=Italiancup_semifinal[1,1];
			Week[k].fixture[seriea2].match[1].team2=Italiancup_semifinal[1,2];
			Week[k].fixture[seriea2].match[1].position=1;
			Week[k].fixture[seriea2].match[2].team1=Italiancup_semifinal[2,1];
			Week[k].fixture[seriea2].match[2].team2=Italiancup_semifinal[2,2];
			Week[k].fixture[seriea2].match[2].position=2;
			Week[k].fixture[seriea2].colour=pinkish;Week[k].fixture[seriea2].category="clubs";
			Week[k].fixture[seriea2].name="Italian Cup semi";Week[k].fixture[seriea2].kind="italiancup";
			Week[k].fixture[seriea2].type="knockout";Week[k].fixture[seriea2].stage="semifinal";
			////////////////////////////german cup///////////////////////////////////////////////////////////////////
			Week[k].fixture[bundes2].match[1].team1=Germancup_semifinal[1,1];
			Week[k].fixture[bundes2].match[1].team2=Germancup_semifinal[1,2];
			Week[k].fixture[bundes2].match[1].position=1;
			Week[k].fixture[bundes2].match[2].team1=Germancup_semifinal[2,1];
			Week[k].fixture[bundes2].match[2].team2=Germancup_semifinal[2,2];
			Week[k].fixture[bundes2].match[2].position=2;
			Week[k].fixture[bundes2].colour=pinkish;Week[k].fixture[bundes2].category="clubs";
			Week[k].fixture[bundes2].name="German Cup semi";Week[k].fixture[bundes2].kind="germancup";
			Week[k].fixture[bundes2].type="knockout";Week[k].fixture[bundes2].stage="semifinal";
			////////////////////champions league////////////////////////////////////////////////////////////////////////////////////
			Week[k].fixture[3].colour=violet;    //second leg no 2
			Week[k].fixture[3].match[1].team1=Championsleague_group[5,3];  //group,team
			Week[k].fixture[3].match[1].team2=Championsleague_group[5,1];
			Week[k].fixture[3].match[2].team1=Championsleague_group[5,4];  //group,team
			Week[k].fixture[3].match[2].team2=Championsleague_group[5,2];
			Week[k].fixture[3].match[3].team1=Championsleague_group[6,3];  //group,team
			Week[k].fixture[3].match[3].team2=Championsleague_group[6,1];
			Week[k].fixture[3].match[4].team1=Championsleague_group[6,4];  //group,team
			Week[k].fixture[3].match[4].team2=Championsleague_group[6,2];
			Week[k].fixture[3].match[5].team1=Championsleague_group[7,3];  //group,team
			Week[k].fixture[3].match[5].team2=Championsleague_group[7,1];
			Week[k].fixture[3].match[6].team1=Championsleague_group[7,4];  //group,team
			Week[k].fixture[3].match[6].team2=Championsleague_group[7,2];
			Week[k].fixture[3].match[7].team1=Championsleague_group[8,3];  //group,team
			Week[k].fixture[3].match[7].team2=Championsleague_group[8,1];
			Week[k].fixture[3].match[8].team1=Championsleague_group[8,4];  //group,team
			Week[k].fixture[3].match[8].team2=Championsleague_group[8,2];
			Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";Week[k].fixture[3].category="clubs";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
	///////////////////afcon quals////////////////////////////////////////////////////////////////////////////////
	for(int k=32;k<=192;k++){ int m=32; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
			Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6 second last of first half
			Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
			Week[k].fixture[2].match[1].team1=AFCONqualifier_group[4,1];
			Week[k].fixture[2].match[1].team2=AFCONqualifier_group[4,4];
			Week[k].fixture[2].match[2].team1=AFCONqualifier_group[4,2];
			Week[k].fixture[2].match[2].team2=AFCONqualifier_group[4,6];
			Week[k].fixture[2].match[3].team1=AFCONqualifier_group[4,3];
			Week[k].fixture[2].match[3].team2=AFCONqualifier_group[4,5];
			Week[k].fixture[2].match[4].team1=AFCONqualifier_group[5,1];
			Week[k].fixture[2].match[4].team2=AFCONqualifier_group[5,4];
			Week[k].fixture[2].match[5].team1=AFCONqualifier_group[5,2];
			Week[k].fixture[2].match[5].team2=AFCONqualifier_group[5,6];
			Week[k].fixture[2].match[6].team1=AFCONqualifier_group[5,3];
			Week[k].fixture[2].match[6].team2=AFCONqualifier_group[5,5];
			Week[k].fixture[2].match[7].team1=AFCONqualifier_group[6,1];
			Week[k].fixture[2].match[7].team2=AFCONqualifier_group[6,4];
			Week[k].fixture[2].match[8].team1=AFCONqualifier_group[6,2];
			Week[k].fixture[2].match[8].team2=AFCONqualifier_group[6,6];
			Week[k].fixture[2].match[9].team1=AFCONqualifier_group[6,3];
			Week[k].fixture[2].match[9].team2=AFCONqualifier_group[6,5]; }}
	//////////////////////uefa cup/////////////////////////////////////////////////////////////////////////
	for(int k=32;k<=192;k++){ int m=32; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[3].match[1].team1=Uefacup_quarterfinal[1,2];  //leg 2
			Week[k].fixture[3].match[1].team2=Uefacup_quarterfinal[1,1];
			Week[k].fixture[3].match[1].position=1;Week[k].fixture[3].match[1].group=1;
			Week[k].fixture[3].match[2].team1=Uefacup_quarterfinal[2,2];  
			Week[k].fixture[3].match[2].team2=Uefacup_quarterfinal[2,1];
			Week[k].fixture[3].match[2].position=2;Week[k].fixture[3].match[2].group=1;
			Week[k].fixture[3].match[3].team1=Uefacup_quarterfinal[3,2];  
			Week[k].fixture[3].match[3].team2=Uefacup_quarterfinal[3,1];
			Week[k].fixture[3].match[3].position=1;Week[k].fixture[3].match[3].group=2;
			Week[k].fixture[3].match[4].team1=Uefacup_quarterfinal[4,2];  
			Week[k].fixture[3].match[4].team2=Uefacup_quarterfinal[4,1];
			Week[k].fixture[3].match[4].position=2;Week[k].fixture[3].match[4].group=2;
			Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].leg="second";Week[k].fixture[3].category="clubs";
			Week[k].fixture[3].name="European Cup quarter final";Week[k].fixture[3].kind="uefacup";
			Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="quarterfinal";}}
	////////////////////asian cup////////////////////////////////////////////////////////////////////////////////////
	for(int k=32;k<=192;k++){ int m=32; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
			Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no 2
			Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
			Week[k].fixture[4].match[1].team1=ASIANcup_group[1,1];
			Week[k].fixture[4].match[1].team2=ASIANcup_group[1,3];
			Week[k].fixture[4].match[2].team1=ASIANcup_group[1,2];
			Week[k].fixture[4].match[2].team2=ASIANcup_group[1,4];
			Week[k].fixture[4].match[3].team1=ASIANcup_group[2,1];
			Week[k].fixture[4].match[3].team2=ASIANcup_group[2,3];
			Week[k].fixture[4].match[4].team1=ASIANcup_group[2,2];
			Week[k].fixture[4].match[4].team2=ASIANcup_group[2,4];
			Week[k].fixture[4].match[5].team1=ASIANcup_group[3,1];
			Week[k].fixture[4].match[5].team2=ASIANcup_group[3,3];
			Week[k].fixture[4].match[6].team1=ASIANcup_group[3,2];
			Week[k].fixture[4].match[6].team2=ASIANcup_group[3,4];
			Week[k].fixture[4].match[7].team1=ASIANcup_group[4,1];
			Week[k].fixture[4].match[7].team2=ASIANcup_group[4,3];
			Week[k].fixture[4].match[8].team1=ASIANcup_group[4,2];
			Week[k].fixture[4].match[8].team2=ASIANcup_group[4,4];  }}
	//////////////////////////champions league/////////////////////////////////////////////////////////////////////////////
	for(int k=33;k<=192;k++){ int m=33; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[2].colour=violet;    //second leg last
			Week[k].fixture[2].match[1].team1=Championsleague_group[1,4];  //group,team
			Week[k].fixture[2].match[1].team2=Championsleague_group[1,1];
			Week[k].fixture[2].match[2].team1=Championsleague_group[1,3];  //group,team
			Week[k].fixture[2].match[2].team2=Championsleague_group[1,2];
			Week[k].fixture[2].match[3].team1=Championsleague_group[2,4];  //group,team
			Week[k].fixture[2].match[3].team2=Championsleague_group[2,1];
			Week[k].fixture[2].match[4].team1=Championsleague_group[2,3];  //group,team
			Week[k].fixture[2].match[4].team2=Championsleague_group[2,2];
			Week[k].fixture[2].match[5].team1=Championsleague_group[3,4];  //group,team
			Week[k].fixture[2].match[5].team2=Championsleague_group[3,1];
			Week[k].fixture[2].match[6].team1=Championsleague_group[3,3];  //group,team
			Week[k].fixture[2].match[6].team2=Championsleague_group[3,2];
			Week[k].fixture[2].match[7].team1=Championsleague_group[4,4];  //group,team
			Week[k].fixture[2].match[7].team2=Championsleague_group[4,1];
			Week[k].fixture[2].match[8].team1=Championsleague_group[4,3];  //group,team
			Week[k].fixture[2].match[8].team2=Championsleague_group[4,2];
			Week[k].fixture[2].name="Champions League";Week[k].fixture[2].kind="championsleague";Week[k].fixture[2].category="clubs";
			Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";}}
	////////////////////////afcon quals////////////////////////////////////////////////////////////////////////////////
	for(int k=33;k<=192;k++){ int m=33; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[3].name="AFCON Qualifiers";Week[k].fixture[3].kind="afconquals";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";  //8 groups of 6 second last of first half
			Week[k].fixture[3].colour=bluish;Week[k].fixture[3].category="countries";
			Week[k].fixture[3].match[1].team1=AFCONqualifier_group[7,1];
			Week[k].fixture[3].match[1].team2=AFCONqualifier_group[7,4];
			Week[k].fixture[3].match[2].team1=AFCONqualifier_group[7,2];
			Week[k].fixture[3].match[2].team2=AFCONqualifier_group[7,6];
			Week[k].fixture[3].match[3].team1=AFCONqualifier_group[7,3];
			Week[k].fixture[3].match[3].team2=AFCONqualifier_group[7,5];
			Week[k].fixture[3].match[4].team1=AFCONqualifier_group[8,1];
			Week[k].fixture[3].match[4].team2=AFCONqualifier_group[8,4];
			Week[k].fixture[3].match[5].team1=AFCONqualifier_group[8,2];
			Week[k].fixture[3].match[5].team2=AFCONqualifier_group[8,6];
			Week[k].fixture[3].match[6].team1=AFCONqualifier_group[8,3];
			Week[k].fixture[3].match[6].team2=AFCONqualifier_group[8,5]; }}
	/////////////////asian cup//////////////////////////////////////////////////////////////////////////////////
	for(int k=33;k<=192;k++){ int m=33; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
			Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no 2
			Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
			Week[k].fixture[4].match[1].team1=ASIANcup_group[1,2];
			Week[k].fixture[4].match[1].team2=ASIANcup_group[1,5];
			Week[k].fixture[4].match[2].team1=ASIANcup_group[2,2];
			Week[k].fixture[4].match[2].team2=ASIANcup_group[2,5];
			Week[k].fixture[4].match[3].team1=ASIANcup_group[3,2];
			Week[k].fixture[4].match[3].team2=ASIANcup_group[3,5];
			Week[k].fixture[4].match[4].team1=ASIANcup_group[4,2];
			Week[k].fixture[4].match[4].team2=ASIANcup_group[4,5];  }}
	////////////////////fa cup///////////////////////////////////////////////////////////////////////////
	for(int k=34;k<=192;k++){ int m=34; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
			Week[k].fixture[2].colour=pinkish;  //playoffs
			Week[k].fixture[2].name="FA Cup semi";Week[k].fixture[2].kind="facup";Week[k].fixture[2].category="clubs";
			Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="semifinal";
			Week[k].fixture[2].match[1].team1=FAcup_semifinal[1,1];
			Week[k].fixture[2].match[1].team2=FAcup_semifinal[1,2];
			Week[k].fixture[2].match[1].position=1;
			Week[k].fixture[2].match[2].team1=FAcup_semifinal[2,1];
			Week[k].fixture[2].match[2].team2=FAcup_semifinal[2,2];
			Week[k].fixture[2].match[2].position=2;
			/////////////////champions league///////////////////////////////////////////////////////////////////////////////////////
			Week[k].fixture[3].colour=violet;    //second leg last last
			Week[k].fixture[3].match[1].team1=Championsleague_group[5,4];  //group,team
			Week[k].fixture[3].match[1].team2=Championsleague_group[5,1];
			Week[k].fixture[3].match[2].team1=Championsleague_group[5,3];  //group,team
			Week[k].fixture[3].match[2].team2=Championsleague_group[5,2];
			Week[k].fixture[3].match[3].team1=Championsleague_group[6,4];  //group,team
			Week[k].fixture[3].match[3].team2=Championsleague_group[6,1];
			Week[k].fixture[3].match[4].team1=Championsleague_group[6,3];  //group,team
			Week[k].fixture[3].match[4].team2=Championsleague_group[6,2];
			Week[k].fixture[3].match[5].team1=Championsleague_group[7,4];  //group,team
			Week[k].fixture[3].match[5].team2=Championsleague_group[7,1];
			Week[k].fixture[3].match[6].team1=Championsleague_group[7,3];  //group,team
			Week[k].fixture[3].match[6].team2=Championsleague_group[7,2];
			Week[k].fixture[3].match[7].team1=Championsleague_group[8,4];  //group,team
			Week[k].fixture[3].match[7].team2=Championsleague_group[8,1];
			Week[k].fixture[3].match[8].team1=Championsleague_group[8,3];  //group,team
			Week[k].fixture[3].match[8].team2=Championsleague_group[8,2];
			Week[k].fixture[3].match[8].stage="last";Week[k].fixture[3].category="clubs"; //last ucl
			Week[k].fixture[3].name="Champions League";Week[k].fixture[3].kind="championsleague";
			Week[k].fixture[3].type="league";Week[k].fixture[3].stage="group";}}
	///////////////////asian cup/////////////////////////////////////////////////////////////////////////////////////
	for(int k=34;k<=192;k++){ int m=34; if( Contains(new int[]{m,m+96},k) ){
			Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
			Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no last
			Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
			Week[k].fixture[4].match[1].team1=ASIANcup_group[1,1];
			Week[k].fixture[4].match[1].team2=ASIANcup_group[1,4];
			Week[k].fixture[4].match[2].team1=ASIANcup_group[1,2];
			Week[k].fixture[4].match[2].team2=ASIANcup_group[1,3];
			Week[k].fixture[4].match[3].team1=ASIANcup_group[2,1];
			Week[k].fixture[4].match[3].team2=ASIANcup_group[2,4];
			Week[k].fixture[4].match[4].team1=ASIANcup_group[2,2];
			Week[k].fixture[4].match[4].team2=ASIANcup_group[2,3];
			Week[k].fixture[4].match[5].team1=ASIANcup_group[3,1];
			Week[k].fixture[4].match[5].team2=ASIANcup_group[3,4];
			Week[k].fixture[4].match[6].team1=ASIANcup_group[3,2];
			Week[k].fixture[4].match[6].team2=ASIANcup_group[3,3];
			Week[k].fixture[4].match[7].team1=ASIANcup_group[4,1];
			Week[k].fixture[4].match[7].team2=ASIANcup_group[4,4];
			Week[k].fixture[4].match[8].team1=ASIANcup_group[4,2];
			Week[k].fixture[4].match[8].team2=ASIANcup_group[4,3];  }}
	////////////////////friendly///////////////////////////////////////////////////////////////////////////////
	/*if(global.category=="countries"){
	Week[35].fixture[2].match[1].team1=Friendly[7,1]; //<=always own country //14 friendlies in 4 years
	Week[35].fixture[2].match[1].team2=Friendly[7,2];
	Week[35].fixture[2].colour=bluish;
	Week[35].fixture[2].name="Friendly";Week[35].fixture[2].kind="friendly";}*/
///////////////////////champions league////////////////////////////////////////////////////////////////////////////
for(int k=35;k<=192;k++){ int m=35; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].colour=violet;  Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League 16";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="roundof16"; //first leg
		Week[k].fixture[3].match[1].team1=Championsleague_round16[1,1];  
		Week[k].fixture[3].match[1].team2=Championsleague_round16[1,2];
		Week[k].fixture[3].match[1].position=1;Week[k].fixture[3].match[1].group=1;
		Week[k].fixture[3].match[2].team1=Championsleague_round16[2,1];  
		Week[k].fixture[3].match[2].team2=Championsleague_round16[2,2];
		Week[k].fixture[3].match[2].position=2;Week[k].fixture[3].match[1].group=1;
		Week[k].fixture[3].match[3].team1=Championsleague_round16[3,1];  
		Week[k].fixture[3].match[3].team2=Championsleague_round16[3,2];
		Week[k].fixture[3].match[3].position=1;Week[k].fixture[3].match[1].group=2;
		Week[k].fixture[3].match[4].team1=Championsleague_round16[4,1];  
		Week[k].fixture[3].match[4].team2=Championsleague_round16[4,2];
		Week[k].fixture[3].match[4].position=2;Week[k].fixture[3].match[1].group=2;
		Week[k].fixture[3].match[5].team1=Championsleague_round16[5,1];  
		Week[k].fixture[3].match[5].team2=Championsleague_round16[5,2];
		Week[k].fixture[3].match[5].position=1;Week[k].fixture[3].match[1].group=3;
		Week[k].fixture[3].match[6].team1=Championsleague_round16[6,1];  
		Week[k].fixture[3].match[6].team2=Championsleague_round16[6,2];
		Week[k].fixture[3].match[6].position=2;Week[k].fixture[3].match[1].group=3;
		Week[k].fixture[3].match[7].team1=Championsleague_round16[7,1];  
		Week[k].fixture[3].match[7].team2=Championsleague_round16[7,2];
		Week[k].fixture[3].match[7].position=1;Week[k].fixture[3].match[1].group=4;
		Week[k].fixture[3].match[8].team1=Championsleague_round16[8,1];  
		Week[k].fixture[3].match[8].team2=Championsleague_round16[8,2];
		Week[k].fixture[3].match[8].position=2;Week[k].fixture[3].match[1].group=4;}}
////////////////asian cup////////////////////////////////////////////////////////////////////////////////////////
for(int k=35;k<=192;k++){ int m=35; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
		Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  //no 2
		Week[k].fixture[4].colour=yellowish;  Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=ASIANcup_group[1,3];
		Week[k].fixture[4].match[1].team2=ASIANcup_group[1,5];
		Week[k].fixture[4].match[2].team1=ASIANcup_group[2,3];
		Week[k].fixture[4].match[2].team2=ASIANcup_group[2,5];
		Week[k].fixture[4].match[3].team1=ASIANcup_group[3,3];
		Week[k].fixture[4].match[3].team2=ASIANcup_group[3,5];
		Week[k].fixture[4].match[4].team1=ASIANcup_group[4,3];
		Week[k].fixture[4].match[4].team2=ASIANcup_group[4,5];  }}
////////////////////////afcon quals////////////////////////////////////////////////////////////////////////////////
for(int k=36;k<=192;k++){ int m=36; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
		Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6 second last 
		Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
		Week[k].fixture[2].match[1].team1=AFCONqualifier_group[1,1];
		Week[k].fixture[2].match[1].team2=AFCONqualifier_group[1,5];
		Week[k].fixture[2].match[2].team1=AFCONqualifier_group[1,2];
		Week[k].fixture[2].match[2].team2=AFCONqualifier_group[1,4];
		Week[k].fixture[2].match[3].team1=AFCONqualifier_group[1,6];
		Week[k].fixture[2].match[3].team2=AFCONqualifier_group[1,3];
		Week[k].fixture[2].match[4].team1=AFCONqualifier_group[2,1];
		Week[k].fixture[2].match[4].team2=AFCONqualifier_group[2,5];
		Week[k].fixture[2].match[5].team1=AFCONqualifier_group[2,2];
		Week[k].fixture[2].match[5].team2=AFCONqualifier_group[2,4];
		Week[k].fixture[2].match[6].team1=AFCONqualifier_group[2,6];
		Week[k].fixture[2].match[6].team2=AFCONqualifier_group[2,3];
		Week[k].fixture[2].match[7].team1=AFCONqualifier_group[3,1];
		Week[k].fixture[2].match[7].team2=AFCONqualifier_group[3,5];
		Week[k].fixture[2].match[8].team1=AFCONqualifier_group[3,2];
		Week[k].fixture[2].match[8].team2=AFCONqualifier_group[3,4];
		Week[k].fixture[2].match[9].team1=AFCONqualifier_group[3,6];
		Week[k].fixture[2].match[9].team2=AFCONqualifier_group[3,3]; }}
//////////////uefa cup/////////////////////////////////////////////////////////////////////////////////////
for(int k=36;k<=192;k++){ int m=36; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].match[1].team1=Uefacup_semifinal[1,1];  //semi leg 1
		Week[k].fixture[3].match[1].team2=Uefacup_semifinal[1,2];
		Week[k].fixture[3].match[1].position=1;
		Week[k].fixture[3].match[2].team1=Uefacup_semifinal[2,1];  
		Week[k].fixture[3].match[2].team2=Uefacup_semifinal[2,2];
		Week[k].fixture[3].match[2].position=2;
		Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="European Cup semi";Week[k].fixture[3].kind="uefacup";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="semifinal";}}
//////////////////asian cup/////////////////////////////////////////////////////////////////////////////
for(int k=36;k<=192;k++){ int m=36; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].name="Asian cup";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
		Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";  // last group fixture
		Week[k].fixture[4].colour=yellowish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=ASIANcup_group[1,4];
		Week[k].fixture[4].match[1].team2=ASIANcup_group[1,5];
		Week[k].fixture[4].match[2].team1=ASIANcup_group[2,4];
		Week[k].fixture[4].match[2].team2=ASIANcup_group[2,5];
		Week[k].fixture[4].match[3].team1=ASIANcup_group[3,4];
		Week[k].fixture[4].match[3].team2=ASIANcup_group[3,5];
		Week[k].fixture[4].match[4].team1=ASIANcup_group[4,4];
		Week[k].fixture[4].match[4].team2=ASIANcup_group[4,5]; 
		Week[k].fixture[4].match[4].stage="last"; }}
/////////////////////champions league///////////////////////////////////////////////////////////////////////////////////
for(int k=37;k<=192;k++){ int m=37; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[2].colour=violet; Week[k].fixture[2].category="clubs";
		Week[k].fixture[2].name="Champions League 16";Week[k].fixture[2].kind="championsleague";
		Week[k].fixture[2].type="aggregate";Week[k].fixture[2].stage="roundof16"; //second leg
		Week[k].fixture[2].match[1].team1=Championsleague_round16[1,2];  
		Week[k].fixture[2].match[1].team2=Championsleague_round16[1,1];
		Week[k].fixture[2].match[1].position=1;Week[k].fixture[2].match[1].group=1;  //bug fixes
		Week[k].fixture[2].match[2].team1=Championsleague_round16[2,2];  
		Week[k].fixture[2].match[2].team2=Championsleague_round16[2,1];
		Week[k].fixture[2].match[2].position=2;Week[k].fixture[2].match[2].group=1;
		Week[k].fixture[2].match[3].team1=Championsleague_round16[3,2];  
		Week[k].fixture[2].match[3].team2=Championsleague_round16[3,1];
		Week[k].fixture[2].match[3].position=1;Week[k].fixture[2].match[3].group=2;
		Week[k].fixture[2].match[4].team1=Championsleague_round16[4,2];  
		Week[k].fixture[2].match[4].team2=Championsleague_round16[4,1];
		Week[k].fixture[2].match[4].position=2;Week[k].fixture[2].match[4].group=2;
		Week[k].fixture[2].match[5].team1=Championsleague_round16[5,2];  
		Week[k].fixture[2].match[5].team2=Championsleague_round16[5,1];
		Week[k].fixture[2].match[5].position=1;Week[k].fixture[2].match[5].group=3;
		Week[k].fixture[2].match[6].team1=Championsleague_round16[6,2];  
		Week[k].fixture[2].match[6].team2=Championsleague_round16[6,1];
		Week[k].fixture[2].match[6].position=2;Week[k].fixture[2].match[6].group=3;
		Week[k].fixture[2].match[7].team1=Championsleague_round16[7,2];  
		Week[k].fixture[2].match[7].team2=Championsleague_round16[7,1];
		Week[k].fixture[2].match[7].position=1;Week[k].fixture[2].match[7].group=4;
		Week[k].fixture[2].match[8].team1=Championsleague_round16[8,2];  
		Week[k].fixture[2].match[8].team2=Championsleague_round16[8,1];
		Week[k].fixture[2].match[8].position=2;Week[k].fixture[2].match[8].group=4;
		Week[k].fixture[2].leg="second";
		/////////////////////////champions league///////////////////////////////////////////////////////////////////////////
		Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League quarter final";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="quarterfinal"; //firstleg
		Week[k].fixture[3].match[1].team1=Championsleague_quarterfinal[1,1];  
		Week[k].fixture[3].match[1].team2=Championsleague_quarterfinal[1,2];
		Week[k].fixture[3].match[1].position=1;Week[k].fixture[3].match[1].group=1;
		Week[k].fixture[3].match[2].team1=Championsleague_quarterfinal[2,1];  
		Week[k].fixture[3].match[2].team2=Championsleague_quarterfinal[2,2];
		Week[k].fixture[3].match[2].position=2;Week[k].fixture[3].match[2].group=1;
		Week[k].fixture[3].match[3].team1=Championsleague_quarterfinal[3,1];  
		Week[k].fixture[3].match[3].team2=Championsleague_quarterfinal[3,2];
		Week[k].fixture[3].match[3].position=1;Week[k].fixture[3].match[3].group=2;
		Week[k].fixture[3].match[4].team1=Championsleague_quarterfinal[4,1];  
		Week[k].fixture[3].match[4].team2=Championsleague_quarterfinal[4,2];
		Week[k].fixture[3].match[4].position=2;Week[k].fixture[3].match[4].group=2;}}
/////////////////////////////asian cup//////////////////////////////////////////////////////////////////////
for(int k=37;k<=192;k++){ int m=37; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].name="Asian cup quarter final";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";  
		Week[k].fixture[4].colour=yellowish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=ASIANcup_quarterfinal[1,1];
		Week[k].fixture[4].match[1].team2=ASIANcup_quarterfinal[1,2];
		Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
		Week[k].fixture[4].match[2].team1=ASIANcup_quarterfinal[2,1];
		Week[k].fixture[4].match[2].team2=ASIANcup_quarterfinal[2,2];
		Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
		Week[k].fixture[4].match[3].team1=ASIANcup_quarterfinal[3,1];
		Week[k].fixture[4].match[3].team2=ASIANcup_quarterfinal[3,2];
		Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
		Week[k].fixture[4].match[4].team1=ASIANcup_quarterfinal[4,1];
		Week[k].fixture[4].match[4].team2=ASIANcup_quarterfinal[4,2];
		Week[k].fixture[4].match[4].position=2;Week[k].fixture[4].match[4].group=2;  }}
/////////////////////////champions league//////////////////////////////////////////////////////////////////////
for(int k=38;k<=192;k++){ int m=38; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].colour=violet; Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League quarter final";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="quarterfinal"; //second leg
		Week[k].fixture[3].match[1].team1=Championsleague_quarterfinal[1,2];  
		Week[k].fixture[3].match[1].team2=Championsleague_quarterfinal[1,1];
		Week[k].fixture[3].match[1].position=1;Week[k].fixture[3].match[1].group=1;
		Week[k].fixture[3].match[2].team1=Championsleague_quarterfinal[2,2];  
		Week[k].fixture[3].match[2].team2=Championsleague_quarterfinal[2,1];
		Week[k].fixture[3].match[2].position=2;Week[k].fixture[3].match[2].group=1;
		Week[k].fixture[3].match[3].team1=Championsleague_quarterfinal[3,2];  
		Week[k].fixture[3].match[3].team2=Championsleague_quarterfinal[3,1];
		Week[k].fixture[3].match[3].position=1;Week[k].fixture[3].match[3].group=2;
		Week[k].fixture[3].match[4].team1=Championsleague_quarterfinal[4,2];  
		Week[k].fixture[3].match[4].team2=Championsleague_quarterfinal[4,1];
		Week[k].fixture[3].match[4].position=2;Week[k].fixture[3].match[4].group=2;
		Week[k].fixture[3].leg="second";}}

/////////////////////////asian cup///////////////////////////////////////////////////////////////////////////////
for(int k=38;k<=192;k++){ int m=38; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].name="Asian cup semifinal";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal";  
		Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=ASIANcup_semifinal[1,1];
		Week[k].fixture[4].match[1].team2=ASIANcup_semifinal[1,2];
		Week[k].fixture[4].match[1].position=1;
		Week[k].fixture[4].match[2].team1=ASIANcup_semifinal[2,1];
		Week[k].fixture[4].match[2].team2=ASIANcup_semifinal[2,2];
		Week[k].fixture[4].match[2].position=2;  }}
//////////////////////fa cup/////////////////////////////////////////////////////////////////////////////////////////
for(int k=39;k<=192;k++){ int m=39; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[2].colour=pinkish; Week[k].fixture[2].category="clubs";
		Week[k].fixture[2].name="FA Cup final";Week[k].fixture[2].kind="facup";
		Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="final";
		Week[k].fixture[2].match[1].team1=FAcup_final[1];
		Week[k].fixture[2].match[1].team2=FAcup_final[2];
		/////////////////champions league/////////////////////////////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League semifinal";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="semifinal"; //first leg
		Week[k].fixture[3].match[1].team1=Championsleague_semifinal[1,1];  
		Week[k].fixture[3].match[1].team2=Championsleague_semifinal[1,2];
		Week[k].fixture[3].match[1].position=1;
		Week[k].fixture[3].match[2].team1=Championsleague_semifinal[2,1];  
		Week[k].fixture[3].match[2].team2=Championsleague_semifinal[2,2];
		Week[k].fixture[3].match[2].position=2;}}
///////////////////asian cup/////////////////////////////////////////////////////////////////////////////////////
for(int k=39;k<=192;k++){ int m=39; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].name="Asian cup final";Week[k].fixture[4].kind="asiancup";  //4 groups of 5
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";  
		Week[k].fixture[4].colour=yellowish;Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=ASIANcup_final[1];
		Week[k].fixture[4].match[1].team2=ASIANcup_final[2]; }}
///////////////////////afcon quals/////////////////////////////////////////////////////////////////////////////////
for(int k=40;k<=192;k++){ int m=40; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
		Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6 second last 
		Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
		Week[k].fixture[2].match[1].team1=AFCONqualifier_group[4,1];
		Week[k].fixture[2].match[1].team2=AFCONqualifier_group[4,5];
		Week[k].fixture[2].match[2].team1=AFCONqualifier_group[4,2];
		Week[k].fixture[2].match[2].team2=AFCONqualifier_group[4,4];
		Week[k].fixture[2].match[3].team1=AFCONqualifier_group[4,6];
		Week[k].fixture[2].match[3].team2=AFCONqualifier_group[4,3];
		Week[k].fixture[2].match[4].team1=AFCONqualifier_group[5,1];
		Week[k].fixture[2].match[4].team2=AFCONqualifier_group[5,5];
		Week[k].fixture[2].match[5].team1=AFCONqualifier_group[5,2];
		Week[k].fixture[2].match[5].team2=AFCONqualifier_group[5,4];
		Week[k].fixture[2].match[6].team1=AFCONqualifier_group[5,6];
		Week[k].fixture[2].match[6].team2=AFCONqualifier_group[5,3];
		Week[k].fixture[2].match[7].team1=AFCONqualifier_group[6,1];
		Week[k].fixture[2].match[7].team2=AFCONqualifier_group[6,5];
		Week[k].fixture[2].match[8].team1=AFCONqualifier_group[6,2];
		Week[k].fixture[2].match[8].team2=AFCONqualifier_group[6,4];
		Week[k].fixture[2].match[9].team1=AFCONqualifier_group[6,6];
		Week[k].fixture[2].match[9].team2=AFCONqualifier_group[6,3]; }}
//////////////////uefa cup/////////////////////////////////////////////////////////////////////////////////
for(int k=40;k<=192;k++){ int m=40; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].match[1].team1=Uefacup_semifinal[1,2];  //semi leg 2
		Week[k].fixture[3].match[1].team2=Uefacup_semifinal[1,1];
		Week[k].fixture[3].match[1].position=1;
		Week[k].fixture[3].match[2].team1=Uefacup_semifinal[2,2];  
		Week[k].fixture[3].match[2].team2=Uefacup_semifinal[2,1];
		Week[k].fixture[3].match[2].position=2;
		Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].leg="second";Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="European Cup semi";Week[k].fixture[3].kind="uefacup";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="semifinal";}}
///////////////////////ocean nations cup/////////////////////////////////////////////////////////////////////////////////////
for(int k=40;k<=192;k++){ int m=40; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="Ocean nations Cup";Week[k].fixture[4].kind="ocncup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";
		Week[k].fixture[4].match[1].team1=ONCcup_round1[1,1];  
		Week[k].fixture[4].match[1].team2=ONCcup_round1[1,2];
		Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
		Week[k].fixture[4].match[2].team1=ONCcup_round1[2,1];  
		Week[k].fixture[4].match[2].team2=ONCcup_round1[2,2];
		Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
		Week[k].fixture[4].match[3].team1=ONCcup_round1[3,1];  
		Week[k].fixture[4].match[3].team2=ONCcup_round1[3,2];
		Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
		Week[k].fixture[4].match[4].team1=ONCcup_round1[4,1];  
		Week[k].fixture[4].match[4].team2=ONCcup_round1[4,2];
		Week[k].fixture[4].match[4].position=2;Week[k].fixture[4].match[4].group=2;  }}
/////////////////////spanish cup//////////////////////////////////////////////////////////////////////////////////////////////
for(int k=41;k<=192;k++){ int m=41; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[2].match[1].team1=Spanishcup_final[1];
		Week[k].fixture[2].match[1].team2=Spanishcup_final[2];
		Week[k].fixture[2].colour=pinkish;Week[k].fixture[2].category="clubs";
		Week[k].fixture[2].name="Spanish Cup final";Week[k].fixture[2].kind="spanishcup";
		Week[k].fixture[2].type="knockout";Week[k].fixture[2].stage="final";
		///////////////////////italian cup//////////////////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[seriea2].match[1].team1=Italiancup_final[1];
		Week[k].fixture[seriea2].match[1].team2=Italiancup_final[2];
		Week[k].fixture[seriea2].colour=pinkish;Week[k].fixture[seriea2].category="clubs";
		Week[k].fixture[seriea2].name="Italian Cup final";Week[k].fixture[seriea2].kind="italiancup";
		Week[k].fixture[seriea2].type="knockout";Week[k].fixture[seriea2].stage="final";
		///////////////////////german cup//////////////////////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[bundes2].match[1].team1=Germancup_final[1];
		Week[k].fixture[bundes2].match[1].team2=Germancup_final[2];
		Week[k].fixture[bundes2].colour=pinkish;Week[k].fixture[bundes2].category="clubs";
		Week[k].fixture[bundes2].name="Germanan Cup final";Week[k].fixture[bundes2].kind="germancup";
		Week[k].fixture[bundes2].type="knockout";Week[k].fixture[bundes2].stage="final";
		//////////////////champions league//////////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League semi";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="aggregate";Week[k].fixture[3].stage="semifinal"; //second leg
		Week[k].fixture[3].match[1].team1=Championsleague_semifinal[1,2];  
		Week[k].fixture[3].match[1].team2=Championsleague_semifinal[1,1];
		Week[k].fixture[3].match[1].position=1;
		Week[k].fixture[3].match[2].team1=Championsleague_semifinal[2,2];  
		Week[k].fixture[3].match[2].team2=Championsleague_semifinal[2,1];
		Week[k].fixture[3].match[2].position=2;  Week[k].fixture[3].leg="second";                                 }}
//////////////////ocean nations cup/////////////////////////////////////////////////////////////////////////////////
for(int k=41;k<=192;k++){ int m=41; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=bluish;Week[k].fixture[4].category="countries"; 
		Week[k].fixture[4].name="Ocean nations Cup semi";Week[k].fixture[4].kind="ocncup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal";
		Week[k].fixture[4].match[1].team1=ONCcup_semifinal[1,1];  
		Week[k].fixture[4].match[1].team2=ONCcup_semifinal[1,2];
		Week[k].fixture[4].match[1].position=1;
		Week[k].fixture[4].match[2].team1=ONCcup_semifinal[2,1];  
		Week[k].fixture[4].match[2].team2=ONCcup_semifinal[2,2];
		Week[k].fixture[4].match[2].position=2;            }}
////////////////////////////champions league final///////////////////////////////////////////////////////////////////
for(int k=42;k<=192;k++){ int m=42; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].colour=violet;Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="Champions League final";Week[k].fixture[3].kind="championsleague";
		Week[k].fixture[3].type="knockout";Week[k].fixture[3].stage="final"; 
		Week[k].fixture[3].match[1].team1=Championsleague_final[1];  
		Week[k].fixture[3].match[1].team2=Championsleague_final[2];}}
///////////////////ocean cup/////////////////////////////////////////////////////////////////////////////////////
for(int k=42;k<=192;k++){ int m=42; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries"; 
		Week[k].fixture[4].name="Ocean nations Cup final";Week[k].fixture[4].kind="ocncup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";
		Week[k].fixture[4].match[1].team1=ONCcup_final[1];  
		Week[k].fixture[4].match[1].team2=ONCcup_final[2];  }}
/////////////////////afcon quals//////////////////////////////////////////////////////////////////////////////
for(int k=43;k<=192;k++){ int m=43; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[1].name="AFCON Qualifiers";Week[k].fixture[1].kind="afconquals";
		Week[k].fixture[1].type="league";Week[k].fixture[1].stage="group";  //8 groups of 6 second last 
		Week[k].fixture[1].colour=bluish;Week[k].fixture[1].category="countries";
		Week[k].fixture[1].match[1].team1=AFCONqualifier_group[7,1];
		Week[k].fixture[1].match[1].team2=AFCONqualifier_group[7,5];
		Week[k].fixture[1].match[2].team1=AFCONqualifier_group[7,2];
		Week[k].fixture[1].match[2].team2=AFCONqualifier_group[7,4];
		Week[k].fixture[1].match[3].team1=AFCONqualifier_group[7,6];
		Week[k].fixture[1].match[3].team2=AFCONqualifier_group[7,3];
		Week[k].fixture[1].match[4].team1=AFCONqualifier_group[8,1];
		Week[k].fixture[1].match[4].team2=AFCONqualifier_group[8,5];
		Week[k].fixture[1].match[5].team1=AFCONqualifier_group[8,2];
		Week[k].fixture[1].match[5].team2=AFCONqualifier_group[8,4];
		Week[k].fixture[1].match[6].team1=AFCONqualifier_group[8,6];
		Week[k].fixture[1].match[6].team2=AFCONqualifier_group[8,3]; }}
///////////////uefa cup final////////////////////////////////////////////////////////////////////////////////
for(int k=43;k<=192;k++){ int m=43; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[3].colour=yellowish; Week[k].fixture[3].category="clubs";
		Week[k].fixture[3].name="European Cup final";Week[k].fixture[3].kind="uefacup";
		Week[k].fixture[3].type="knockout";Week[k].fixture[3].stage="final";
		Week[k].fixture[3].match[1].team1=Uefacup_final[1];  //semi leg 2
		Week[k].fixture[3].match[1].team2=Uefacup_final[2];
		/////////////////////cecafacup///////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[4].colour=bluish; 
		Week[k].fixture[4].name="CECAFA Cup";Week[k].fixture[4].kind="cecafacup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=CECAFAcup_round1[1,1];  
		Week[k].fixture[4].match[1].team2=CECAFAcup_round1[1,2];
		Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
		Week[k].fixture[4].match[2].team1=CECAFAcup_round1[2,1];  
		Week[k].fixture[4].match[2].team2=CECAFAcup_round1[2,2];
		Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
		Week[k].fixture[4].match[3].team1=CECAFAcup_round1[3,1];  
		Week[k].fixture[4].match[3].team2=CECAFAcup_round1[3,2];
		Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
		Week[k].fixture[4].match[4].team1=CECAFAcup_round1[4,1];  
		Week[k].fixture[4].match[4].team2=CECAFAcup_round1[4,2];
		Week[k].fixture[4].match[4].position=2;Week[k].fixture[4].match[4].group=2;
		/////////////////////cosafa cup//////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[11].colour=bluish; 
		Week[k].fixture[11].name="COSAFA Cup";Week[k].fixture[11].kind="cosafacup";  //bug fix
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="quarterfinal";Week[k].fixture[11].category="countries";
		Week[k].fixture[11].match[1].team1=COSAFAcup_round1[1,1];  
		Week[k].fixture[11].match[1].team2=COSAFAcup_round1[1,2];
		Week[k].fixture[11].match[1].position=1;Week[k].fixture[11].match[1].group=1;
		Week[k].fixture[11].match[2].team1=COSAFAcup_round1[2,1];  
		Week[k].fixture[11].match[2].team2=COSAFAcup_round1[2,2];
		Week[k].fixture[11].match[2].position=2;Week[k].fixture[11].match[2].group=1;
		Week[k].fixture[11].match[3].team1=COSAFAcup_round1[3,1];  
		Week[k].fixture[11].match[3].team2=COSAFAcup_round1[3,2];
		Week[k].fixture[11].match[3].position=1;Week[k].fixture[11].match[3].group=2;
		Week[k].fixture[11].match[4].team1=COSAFAcup_round1[4,1];  
		Week[k].fixture[11].match[4].team2=COSAFAcup_round1[4,2];
		Week[k].fixture[11].match[4].position=2;Week[k].fixture[11].match[4].group=2;}}
///////////////////cecafa cup////////////////////////////////////////////////////////////////////////////
for(int k=44;k<=192;k++){ int m=44; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="CECAFA Cup semi";Week[k].fixture[4].kind="cecafacup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal";
		Week[k].fixture[4].match[1].team1=CECAFAcup_semifinal[1,1];  
		Week[k].fixture[4].match[1].team2=CECAFAcup_semifinal[1,2];
		Week[k].fixture[4].match[1].position=1;
		Week[k].fixture[4].match[2].team1=CECAFAcup_semifinal[2,1];  
		Week[k].fixture[4].match[2].team2=CECAFAcup_semifinal[2,2];
		Week[k].fixture[4].match[2].position=2;
		////////////////////cosafa cup///////////////////////////////////////////////////////////////////////////////////
		Week[k].fixture[11].colour=bluish; Week[k].fixture[11].category="countries";
		Week[k].fixture[11].name="COSAFA Cup";Week[k].fixture[11].kind="cosafacup";
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="semifinal";
		Week[k].fixture[11].match[1].team1=COSAFAcup_semifinal[1,1];  
		Week[k].fixture[11].match[1].team2=COSAFAcup_semifinal[1,2];
		Week[k].fixture[11].match[1].position=1;
		Week[k].fixture[11].match[2].team1=COSAFAcup_semifinal[2,1];  
		Week[k].fixture[11].match[2].team2=COSAFAcup_semifinal[2,2];
		Week[k].fixture[11].match[2].position=2;}}
///////////////////////cecafa cup////////////////////////////////////////////////////////////////////////////
for(int k=45;k<=192;k++){ int m=45; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="CECAFA Cup final";Week[k].fixture[4].kind="cecafacup";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";
		Week[k].fixture[4].match[1].team1=CECAFAcup_final[1];  
		Week[k].fixture[4].match[1].team2=CECAFAcup_final[2];
		////////////////////////cosafa cup///////////////////////////////////////////////////////////////////////
		Week[k].fixture[11].colour=bluish; Week[k].fixture[11].category="countries";
		Week[k].fixture[11].name="COSAFA Cup final";Week[k].fixture[11].kind="cosafacup";
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="final";
		Week[k].fixture[11].match[1].team1=COSAFAcup_final[1];  
		Week[k].fixture[11].match[1].team2=COSAFAcup_final[2];}}
//////////////////sea games//////////////////////////////////////////////////////////////////////////////////////
for(int k=46;k<=192;k++){ int m=46; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="SEA Games";Week[k].fixture[4].kind="seagames";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";
		Week[k].fixture[4].match[1].team1=SEAgames_round1[1,1];  
		Week[k].fixture[4].match[1].team2=SEAgames_round1[1,2];
		Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
		Week[k].fixture[4].match[2].team1=SEAgames_round1[2,1];  
		Week[k].fixture[4].match[2].team2=SEAgames_round1[2,2];
		Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
		Week[k].fixture[4].match[3].team1=SEAgames_round1[3,1];  
		Week[k].fixture[4].match[3].team2=SEAgames_round1[3,2];
		Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
		Week[k].fixture[4].match[4].team1=SEAgames_round1[4,1];  
		Week[k].fixture[4].match[4].team2=SEAgames_round1[4,2];
		Week[k].fixture[4].match[4].position=2;Week[k].fixture[4].match[4].group=2;}}
///////////////////////sea games////////////////////////////////////////////////////////////////////////////
for(int k=47;k<=192;k++){ int m=47; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="SEA Games semi";Week[k].fixture[4].kind="seagames";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal";
		Week[k].fixture[4].match[1].team1=SEAgames_semifinal[1,1];  
		Week[k].fixture[4].match[1].team2=SEAgames_semifinal[1,2];
		Week[k].fixture[4].match[1].position=1;
		Week[k].fixture[4].match[2].team1=SEAgames_semifinal[2,1];  
		Week[k].fixture[4].match[2].team2=SEAgames_semifinal[2,2];
		Week[k].fixture[4].match[2].position=2;}}
//////////////////////sea games/////////////////////////////////////////////////////////////////////////
for(int k=48;k<=192;k++){ int m=48; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[4].colour=bluish; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].name="SEA Games final";Week[k].fixture[4].kind="seagames";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final";
		Week[k].fixture[4].match[1].team1=SEAgames_final[1];  
		Week[k].fixture[4].match[1].team2=SEAgames_final[2];}}
/////////////////year 2////////////////////////////////////////////////////////////////////////////////////////
/////////////////////west african cup///////////////////////////////////////////////////////////////////////////////////
for(int k=1;k<=192;k++){ int m=1; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){  //fixture is in 5 due to clash with euro cup
		Week[k].fixture[11].colour=bluish; Week[k].fixture[11].category="countries";
		Week[k].fixture[11].name="West Africa Cup";Week[k].fixture[11].kind="cabralcup";
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="quarterfinal";
		Week[k].fixture[11].match[1].team1=CABRALcup_round1[1,1];  
		Week[k].fixture[11].match[1].team2=CABRALcup_round1[1,2];
		Week[k].fixture[11].match[1].position=1;Week[k].fixture[11].match[1].group=1;
		Week[k].fixture[11].match[2].team1=CABRALcup_round1[2,1];  
		Week[k].fixture[11].match[2].team2=CABRALcup_round1[2,2];
		Week[k].fixture[11].match[2].position=2;Week[k].fixture[11].match[2].group=1;
		Week[k].fixture[11].match[3].team1=CABRALcup_round1[3,1];  
		Week[k].fixture[11].match[3].team2=CABRALcup_round1[3,2];
		Week[k].fixture[11].match[3].position=1;Week[k].fixture[11].match[3].group=2;
		Week[k].fixture[11].match[4].team1=CABRALcup_round1[4,1];  
		Week[k].fixture[11].match[4].team2=CABRALcup_round1[4,2];
		Week[k].fixture[11].match[4].position=2;Week[k].fixture[11].match[4].group=2;}}
//////////////////////west african cup//////////////////////////////////////////////////////////////////////////////////
for(int k=2;k<=192;k++){ int m=2; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[11].colour=bluish; Week[k].fixture[11].category="countries";
		Week[k].fixture[11].name="West Africa Cup semi";Week[k].fixture[11].kind="cabralcup";
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="semifinal";
		Week[k].fixture[11].match[1].team1=CABRALcup_semifinal[1,1];  
		Week[k].fixture[11].match[1].team2=CABRALcup_semifinal[1,2];
		Week[k].fixture[11].match[1].position=1;
		Week[k].fixture[11].match[2].team1=CABRALcup_semifinal[2,1];  
		Week[k].fixture[11].match[2].team2=CABRALcup_semifinal[2,2];
		Week[k].fixture[11].match[2].position=2;}}
///////////////////////west african cup////////////////////////////////////////////////////////////////////////////
for(int k=3;k<=192;k++){ int m=3; if( Contains(new int[]{m,m+48,m+96,m+144},k) ){
		Week[k].fixture[11].colour=bluish; Week[k].fixture[11].category="countries";
		Week[k].fixture[11].name="West Africa Cup final";Week[k].fixture[11].kind="cabralcup";
		Week[k].fixture[11].type="knockout";Week[k].fixture[11].stage="final";
		Week[k].fixture[11].match[1].team1=CABRALcup_final[1];  
		Week[k].fixture[11].match[1].team2=CABRALcup_final[2];}}
///////////////////////////friendly////////////////////////////////////////////////////////////////////
/*if(global.category=="countries"){
Week[49].fixture[2].match[1].team1=Friendly[8,1]; //<=always own country //14 friendlies in 4 years
Week[49].fixture[2].match[1].team2=Friendly[8,2];
Week[49].fixture[2].colour=bluish;
Week[49].fixture[2].name="Friendly";Week[49].fixture[2].kind="friendly";}*/
////////////////////friendly///////////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[51].fixture[2].match[1].team1=Friendly[9,1]; //<=always own country //14 friendlies in 4 years
	Week[51].fixture[2].match[1].team2=Friendly[9,2];
	Week[51].fixture[2].colour=bluish;Week[51].fixture[2].category="countries";
	Week[51].fixture[2].name="Friendly";Week[51].fixture[2].kind="friendly";}
//////////////////////world cup qualification europe/////////////////////////////////////////////////////////////////////////
Week[54].fixture[2].colour=pinkish;Week[54].fixture[2].name="World Cup Qualifying";Week[54].fixture[2].kind="WCQeurope";
Week[54].fixture[2].type="league";Week[54].fixture[2].colour=bluish; Week[54].fixture[2].category="countries";                //7 groups of 6
Week[54].fixture[2].match[1].team1=WCQualifier_eu_group[3,1]; //group 1 team 1
Week[54].fixture[2].match[1].team2=WCQualifier_eu_group[3,3];
Week[54].fixture[2].match[2].team1=WCQualifier_eu_group[3,2]; 
Week[54].fixture[2].match[2].team2=WCQualifier_eu_group[3,5];
Week[54].fixture[2].match[3].team1=WCQualifier_eu_group[3,4]; 
Week[54].fixture[2].match[3].team2=WCQualifier_eu_group[3,6];
Week[54].fixture[2].match[4].team1=WCQualifier_eu_group[4,1]; 
Week[54].fixture[2].match[4].team2=WCQualifier_eu_group[4,3];
Week[54].fixture[2].match[5].team1=WCQualifier_eu_group[4,2]; 
Week[54].fixture[2].match[5].team2=WCQualifier_eu_group[4,5];
Week[54].fixture[2].match[6].team1=WCQualifier_eu_group[4,4]; 
Week[54].fixture[2].match[6].team2=WCQualifier_eu_group[4,6];
Week[54].fixture[2].match[7].team1=WCQualifier_eu_group[5,1]; 
Week[54].fixture[2].match[7].team2=WCQualifier_eu_group[5,3];
Week[54].fixture[2].match[8].team1=WCQualifier_eu_group[5,2]; 
Week[54].fixture[2].match[8].team2=WCQualifier_eu_group[5,5];
Week[54].fixture[2].match[9].team1=WCQualifier_eu_group[5,4]; 
Week[54].fixture[2].match[9].team2=WCQualifier_eu_group[5,6];Week[54].fixture[2].stage="group";
///////////////////world cup qualifications africa/////////////////////////////////////////////////////////////////////////////////////
Week[54].fixture[africa2].colour=pinkish;Week[54].fixture[africa2].name="World Cup Qualifying";Week[54].fixture[africa2].kind="WCQafrica";
Week[54].fixture[africa2].type="group"; Week[54].fixture[africa2].category="countries";          //first group fixture
Week[54].fixture[africa2].match[1].team1=WCQualifier_af_group[1,1];  //5 groups of 5  2 legs
Week[54].fixture[africa2].match[1].team2=WCQualifier_af_group[1,4];
Week[54].fixture[africa2].match[2].team1=WCQualifier_af_group[1,2]; 
Week[54].fixture[africa2].match[2].team2=WCQualifier_af_group[1,3];
Week[54].fixture[africa2].match[3].team1=WCQualifier_af_group[2,1];  
Week[54].fixture[africa2].match[3].team2=WCQualifier_af_group[2,4];
Week[54].fixture[africa2].match[4].team1=WCQualifier_af_group[2,2]; 
Week[54].fixture[africa2].match[4].team2=WCQualifier_af_group[2,3];
Week[54].fixture[africa2].match[5].team1=WCQualifier_af_group[3,1]; 
Week[54].fixture[africa2].match[5].team2=WCQualifier_af_group[3,4];
Week[54].fixture[africa2].match[6].team1=WCQualifier_af_group[3,2]; 
Week[54].fixture[africa2].match[6].team2=WCQualifier_af_group[3,3];
Week[54].fixture[africa2].match[7].team1=WCQualifier_af_group[4,1];  
Week[54].fixture[africa2].match[7].team2=WCQualifier_af_group[4,4];
Week[54].fixture[africa2].match[8].team1=WCQualifier_af_group[4,2]; 
Week[54].fixture[africa2].match[8].team2=WCQualifier_af_group[4,3];Week[54].fixture[africa2].stage="group";
///////////////////////world cup qualifier asia/////////////////////////////////////////////////////////////////////////////////////////////
Week[54].fixture[asia2].colour=pinkish;Week[54].fixture[asia2].name="World Cup Qualifying";Week[54].fixture[asia2].kind="WCQasia";
Week[54].fixture[asia2].type="group"; Week[54].fixture[asia2].category="countries";              //2nd group round last 
Week[54].fixture[asia2].match[1].team1=WCQualifier_as_group[1,1];  //4 groups of 5
Week[54].fixture[asia2].match[1].team2=WCQualifier_as_group[1,4]; 
Week[54].fixture[asia2].match[2].team1=WCQualifier_as_group[1,2];  
Week[54].fixture[asia2].match[2].team2=WCQualifier_as_group[1,3];
Week[54].fixture[asia2].match[3].team1=WCQualifier_as_group[2,1];  
Week[54].fixture[asia2].match[3].team2=WCQualifier_as_group[2,4];
Week[54].fixture[asia2].match[4].team1=WCQualifier_as_group[2,2];  
Week[54].fixture[asia2].match[4].team2=WCQualifier_as_group[2,3];
Week[54].fixture[asia2].match[5].team1=WCQualifier_as_group[3,1];  
Week[54].fixture[asia2].match[5].team2=WCQualifier_as_group[3,4];
Week[54].fixture[asia2].match[6].team1=WCQualifier_as_group[3,2];  
Week[54].fixture[asia2].match[6].team2=WCQualifier_as_group[3,3];
Week[54].fixture[asia2].match[7].team1=WCQualifier_as_group[4,1];  
Week[54].fixture[asia2].match[7].team2=WCQualifier_as_group[4,4];
Week[54].fixture[asia2].match[8].team1=WCQualifier_as_group[4,2];  
Week[54].fixture[asia2].match[8].team2=WCQualifier_as_group[4,3];Week[54].fixture[asia2].stage="group";
///////////////////////world cup qualifier northamerica//////////////////////////////////////////////////////////////////////////////////////
Week[54].fixture[northamerica2].colour=pinkish;Week[54].fixture[northamerica2].name="World Cup Qualifying";
Week[54].fixture[northamerica2].kind="WCQnorthamerica";    
Week[54].fixture[northamerica2].type="league";Week[54].fixture[northamerica2].category="countries";
Week[54].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[54].fixture[northamerica2].match[1].team2= WCQualifier_na_group[16];
Week[54].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[54].fixture[northamerica2].match[2].team2= WCQualifier_na_group[15];
Week[54].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[54].fixture[northamerica2].match[3].team2= WCQualifier_na_group[14];
Week[54].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[54].fixture[northamerica2].match[4].team2= WCQualifier_na_group[13];
Week[54].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[54].fixture[northamerica2].match[5].team2= WCQualifier_na_group[12];
Week[54].fixture[northamerica2].match[6].team1= WCQualifier_na_group[6];
Week[54].fixture[northamerica2].match[6].team2= WCQualifier_na_group[11];
Week[54].fixture[northamerica2].match[7].team1= WCQualifier_na_group[7];
Week[54].fixture[northamerica2].match[7].team2= WCQualifier_na_group[10];
Week[54].fixture[northamerica2].match[8].team1= WCQualifier_na_group[8];
Week[54].fixture[northamerica2].match[8].team2= WCQualifier_na_group[9];
/////////////////euro qualifier///////////////////////////////////////////////////////////////////////////////////////
Week[55].fixture[2].name="Euro Qualifier";Week[55].fixture[2].kind="euroquals";
Week[55].fixture[2].type="league";Week[55].fixture[2].stage="group";  //8 groups of 5 
Week[55].fixture[2].colour=greenish;Week[55].fixture[2].category="countries";
Week[55].fixture[2].match[1].team1=EUROqualifier_group[1,2];
Week[55].fixture[2].match[1].team2=EUROqualifier_group[1,5];
Week[55].fixture[2].match[2].team1=EUROqualifier_group[2,2];
Week[55].fixture[2].match[2].team2=EUROqualifier_group[2,5];
Week[55].fixture[2].match[3].team1=EUROqualifier_group[3,2];
Week[55].fixture[2].match[3].team2=EUROqualifier_group[3,5];
Week[55].fixture[2].match[4].team1=EUROqualifier_group[4,2];
Week[55].fixture[2].match[4].team2=EUROqualifier_group[4,5];
Week[55].fixture[2].match[5].team1=EUROqualifier_group[5,2];
Week[55].fixture[2].match[5].team2=EUROqualifier_group[5,5];
Week[55].fixture[2].match[6].team1=EUROqualifier_group[6,2];
Week[55].fixture[2].match[6].team2=EUROqualifier_group[6,5];
Week[55].fixture[2].match[7].team1=EUROqualifier_group[7,2];
Week[55].fixture[2].match[7].team2=EUROqualifier_group[7,5];
Week[55].fixture[2].match[8].team1=EUROqualifier_group[8,2];
Week[55].fixture[2].match[8].team2=EUROqualifier_group[8,5];
/////////////////////world cup qualifications//////////////////////////////////////////////////////////////////////////
Week[56].fixture[2].colour=pinkish;Week[56].fixture[2].name="World Cup Qualifying";Week[56].fixture[2].kind="WCQsouthamerica";
Week[56].fixture[2].type="league"; Week[56].fixture[2].colour=greenish;Week[56].fixture[2].category="countries";                //1 groups of 10  no 3
Week[56].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[56].fixture[2].match[1].team2=WCQualifier_sa_group[5];
Week[56].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
Week[56].fixture[2].match[2].team2=WCQualifier_sa_group[9];
Week[56].fixture[2].match[3].team1=WCQualifier_sa_group[3]; 
Week[56].fixture[2].match[3].team2=WCQualifier_sa_group[8];
Week[56].fixture[2].match[4].team1=WCQualifier_sa_group[4]; 
Week[56].fixture[2].match[4].team2=WCQualifier_sa_group[7];
Week[56].fixture[2].match[5].team1=WCQualifier_sa_group[10]; 
Week[56].fixture[2].match[5].team2=WCQualifier_sa_group[6];
/////////////////////////friendly///////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[57].fixture[2].match[1].team1=Friendly[10,1]; //<=always own country //14 friendlies in 4 years
	Week[57].fixture[2].match[1].team2=Friendly[10,2];
	Week[57].fixture[2].colour=bluish;
	Week[57].fixture[2].name="Friendly";Week[57].fixture[2].kind="friendly";}
/////////////////world cup qualifier///////////////////////////////////////////////////////////////////////////////////////
Week[57].fixture[2].colour=pinkish;Week[57].fixture[2].name="World Cup Qualifying";Week[57].fixture[2].kind="WCQoceania";
Week[57].fixture[2].type="group"; Week[57].fixture[2].category="countries";                    //1 group of 8 no 2
Week[57].fixture[2].match[1].team1=WCQualifier_oc_group[1];
Week[57].fixture[2].match[1].team2=WCQualifier_oc_group[4];
Week[57].fixture[2].match[2].team1=WCQualifier_oc_group[2];
Week[57].fixture[2].match[2].team2=WCQualifier_oc_group[3];
Week[57].fixture[2].match[3].team1=WCQualifier_oc_group[5];
Week[57].fixture[2].match[3].team2=WCQualifier_oc_group[8];
Week[57].fixture[2].match[4].team1=WCQualifier_oc_group[6];
Week[57].fixture[2].match[4].team2=WCQualifier_oc_group[7];
///////////////world cup qualification europe////////////////////////////////////////////////////////////////////////////////
Week[58].fixture[2].colour=pinkish;Week[58].fixture[2].name="World Cup Qualifying";Week[58].fixture[2].kind="WCQeurope";
Week[58].fixture[2].type="league";Week[58].fixture[2].colour=bluish; Week[58].fixture[2].category="countries";                //7 groups of 6
Week[58].fixture[2].match[1].team1=WCQualifier_eu_group[6,1]; //group 1 team 1
Week[58].fixture[2].match[1].team2=WCQualifier_eu_group[6,3];
Week[58].fixture[2].match[2].team1=WCQualifier_eu_group[6,2]; 
Week[58].fixture[2].match[2].team2=WCQualifier_eu_group[6,5];
Week[58].fixture[2].match[3].team1=WCQualifier_eu_group[6,4]; 
Week[58].fixture[2].match[3].team2=WCQualifier_eu_group[6,6];
Week[58].fixture[2].match[4].team1=WCQualifier_eu_group[7,1]; 
Week[58].fixture[2].match[4].team2=WCQualifier_eu_group[7,3];
Week[58].fixture[2].match[5].team1=WCQualifier_eu_group[7,2]; 
Week[58].fixture[2].match[5].team2=WCQualifier_eu_group[7,5];
Week[58].fixture[2].match[6].team1=WCQualifier_eu_group[7,4]; 
Week[58].fixture[2].match[6].team2=WCQualifier_eu_group[7,6];Week[58].fixture[2].stage="group";
//////////////////////world cup qualifier africa//////////////////////////////////////////////////////////////////////////////////
Week[58].fixture[africa2].colour=pinkish;Week[58].fixture[africa2].name="World Cup Qualifying";Week[58].fixture[africa2].kind="WCQafrica";
Week[58].fixture[africa2].type="group";Week[58].fixture[africa2].category="countries";          //first group fixture
Week[58].fixture[africa2].match[1].team1=WCQualifier_af_group[5,1];  //5 groups of 5  2 legs this leg is done
Week[58].fixture[africa2].match[1].team2=WCQualifier_af_group[5,3];
Week[58].fixture[africa2].match[2].team1=WCQualifier_af_group[5,2]; 
Week[58].fixture[africa2].match[2].team2=WCQualifier_af_group[5,4]; //next 1 4 2 3 group 5
///////////////////////world cup qualifier asia/////////////////////////////////////////////////////////////////////////////////////////////
Week[58].fixture[asia2].colour=pinkish;Week[58].fixture[asia2].name="World Cup Qualifying";Week[58].fixture[asia2].kind="WCQasia";
Week[58].fixture[asia2].type="group"; Week[58].fixture[asia2].category="countries";               //2nd round
Week[58].fixture[asia2].match[1].team1=WCQualifier_as_group[1,2];  //4 groups of 5
Week[58].fixture[asia2].match[1].team2=WCQualifier_as_group[1,1]; 
Week[58].fixture[asia2].match[2].team1=WCQualifier_as_group[1,4];  
Week[58].fixture[asia2].match[2].team2=WCQualifier_as_group[1,3];
Week[58].fixture[asia2].match[3].team1=WCQualifier_as_group[2,2];  
Week[58].fixture[asia2].match[3].team2=WCQualifier_as_group[2,1];
Week[58].fixture[asia2].match[4].team1=WCQualifier_as_group[2,4];  
Week[58].fixture[asia2].match[4].team2=WCQualifier_as_group[2,3];
Week[58].fixture[asia2].match[5].team1=WCQualifier_as_group[3,2];  
Week[58].fixture[asia2].match[5].team2=WCQualifier_as_group[3,1];
Week[58].fixture[asia2].match[6].team1=WCQualifier_as_group[3,4];  
Week[58].fixture[asia2].match[6].team2=WCQualifier_as_group[3,3];
Week[58].fixture[asia2].match[7].team1=WCQualifier_as_group[4,2];  
Week[58].fixture[asia2].match[7].team2=WCQualifier_as_group[4,1];
Week[58].fixture[asia2].match[8].team1=WCQualifier_as_group[4,4];  
Week[58].fixture[asia2].match[8].team2=WCQualifier_as_group[4,3];Week[58].fixture[asia2].stage="group";
///////////////////////world cup qualifier northamerica//////////////////////////////////////////////////////////////////////////////////////
Week[58].fixture[northamerica2].colour=pinkish;Week[58].fixture[northamerica2].name="World Cup Qualifying";
Week[58].fixture[northamerica2].kind="WCQnorthamerica";    
Week[58].fixture[northamerica2].type="league";Week[58].fixture[northamerica2].category="countries"; 
Week[58].fixture[northamerica2].match[1].team1= WCQualifier_na_group[10];
Week[58].fixture[northamerica2].match[1].team2= WCQualifier_na_group[13];
Week[58].fixture[northamerica2].match[2].team1= WCQualifier_na_group[9];
Week[58].fixture[northamerica2].match[2].team2= WCQualifier_na_group[12];
Week[58].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[58].fixture[northamerica2].match[3].team2= WCQualifier_na_group[5];
Week[58].fixture[northamerica2].match[4].team1= WCQualifier_na_group[6];
Week[58].fixture[northamerica2].match[4].team2= WCQualifier_na_group[14];
Week[58].fixture[northamerica2].match[5].team1= WCQualifier_na_group[1];
Week[58].fixture[northamerica2].match[5].team2= WCQualifier_na_group[7];
Week[58].fixture[northamerica2].match[6].team1= WCQualifier_na_group[2];
Week[58].fixture[northamerica2].match[6].team2= WCQualifier_na_group[8];
Week[58].fixture[northamerica2].match[7].team1= WCQualifier_na_group[4];
Week[58].fixture[northamerica2].match[7].team2= WCQualifier_na_group[11];Week[58].fixture[northamerica2].stage="group";
////////////////////////friendly////////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[59].fixture[2].match[1].team1=Friendly[11,1]; //<=always own country //14 friendlies in 4 years
	Week[59].fixture[2].match[1].team2=Friendly[11,2];
	Week[59].fixture[2].colour=bluish;
	Week[59].fixture[2].name="Friendly";Week[59].fixture[2].kind="friendly";}
////////////////////////euro qualifiers////////////////////////////////////////////////////////////////////////////////
Week[60].fixture[2].name="Euro Qualifier";Week[60].fixture[2].kind="euroquals";
Week[60].fixture[2].type="league";Week[60].fixture[2].stage="group";  //8 groups of 5 
Week[60].fixture[2].colour=greenish;Week[60].fixture[2].category="countries"; 
Week[60].fixture[2].match[1].team1=EUROqualifier_group[1,3];
Week[60].fixture[2].match[1].team2=EUROqualifier_group[1,5];
Week[60].fixture[2].match[2].team1=EUROqualifier_group[2,3];
Week[60].fixture[2].match[2].team2=EUROqualifier_group[2,5];
Week[60].fixture[2].match[3].team1=EUROqualifier_group[3,3];
Week[60].fixture[2].match[3].team2=EUROqualifier_group[3,5];
Week[60].fixture[2].match[4].team1=EUROqualifier_group[4,3];
Week[60].fixture[2].match[4].team2=EUROqualifier_group[4,5];
Week[60].fixture[2].match[5].team1=EUROqualifier_group[5,3];
Week[60].fixture[2].match[5].team2=EUROqualifier_group[5,5];
Week[60].fixture[2].match[6].team1=EUROqualifier_group[6,3];
Week[60].fixture[2].match[6].team2=EUROqualifier_group[6,5];
Week[60].fixture[2].match[7].team1=EUROqualifier_group[7,3];
Week[60].fixture[2].match[7].team2=EUROqualifier_group[7,5];
Week[60].fixture[2].match[8].team1=EUROqualifier_group[8,3];
Week[60].fixture[2].match[8].team2=EUROqualifier_group[8,5];
///////////////////////afcon quals////////////////////////////////////////////////////////////////////////
for(int k=64;k<=192;k++){ int m=64; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
		Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6  last round
		Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries"; 
		Week[k].fixture[2].match[1].team1=AFCONqualifier_group[1,1];
		Week[k].fixture[2].match[1].team2=AFCONqualifier_group[1,6];
		Week[k].fixture[2].match[2].team1=AFCONqualifier_group[1,2];
		Week[k].fixture[2].match[2].team2=AFCONqualifier_group[1,3];
		Week[k].fixture[2].match[3].team1=AFCONqualifier_group[1,4];
		Week[k].fixture[2].match[3].team2=AFCONqualifier_group[1,5];
		Week[k].fixture[2].match[4].team1=AFCONqualifier_group[2,1];
		Week[k].fixture[2].match[4].team2=AFCONqualifier_group[2,6];
		Week[k].fixture[2].match[5].team1=AFCONqualifier_group[2,2];
		Week[k].fixture[2].match[5].team2=AFCONqualifier_group[2,3];
		Week[k].fixture[2].match[6].team1=AFCONqualifier_group[2,4];
		Week[k].fixture[2].match[6].team2=AFCONqualifier_group[2,5];
		Week[k].fixture[2].match[7].team1=AFCONqualifier_group[3,1];
		Week[k].fixture[2].match[7].team2=AFCONqualifier_group[3,6];
		Week[k].fixture[2].match[8].team1=AFCONqualifier_group[3,2];
		Week[k].fixture[2].match[8].team2=AFCONqualifier_group[3,3];
		Week[k].fixture[2].match[9].team1=AFCONqualifier_group[3,4];
		Week[k].fixture[2].match[9].team2=AFCONqualifier_group[3,5]; }}
////////////////////////world cup qualifications europe////////////////////////////////////////////////////////////////////////////////
Week[65].fixture[2].colour=pinkish;Week[65].fixture[2].name="World Cup Qualifying";Week[65].fixture[2].kind="WCQeurope";
Week[65].fixture[2].type="league";Week[65].fixture[2].colour=bluish;Week[65].fixture[2].category="countries";                 //7 groups of 6
Week[65].fixture[2].match[1].team1=WCQualifier_eu_group[1,1]; //group 1 team 1
Week[65].fixture[2].match[1].team2=WCQualifier_eu_group[1,4];
Week[65].fixture[2].match[2].team1=WCQualifier_eu_group[1,2]; 
Week[65].fixture[2].match[2].team2=WCQualifier_eu_group[1,6];
Week[65].fixture[2].match[3].team1=WCQualifier_eu_group[1,3]; 
Week[65].fixture[2].match[3].team2=WCQualifier_eu_group[1,5];
Week[65].fixture[2].match[4].team1=WCQualifier_eu_group[2,1]; 
Week[65].fixture[2].match[4].team2=WCQualifier_eu_group[2,4];
Week[65].fixture[2].match[5].team1=WCQualifier_eu_group[2,2]; 
Week[65].fixture[2].match[5].team2=WCQualifier_eu_group[2,6];
Week[65].fixture[2].match[6].team1=WCQualifier_eu_group[2,3]; 
Week[65].fixture[2].match[6].team2=WCQualifier_eu_group[2,5];
Week[65].fixture[2].match[7].team1=WCQualifier_eu_group[3,1]; 
Week[65].fixture[2].match[7].team2=WCQualifier_eu_group[3,4];
Week[65].fixture[2].match[8].team1=WCQualifier_eu_group[3,2]; 
Week[65].fixture[2].match[8].team2=WCQualifier_eu_group[3,6];
Week[65].fixture[2].match[9].team1=WCQualifier_eu_group[3,3]; 
Week[65].fixture[2].match[9].team2=WCQualifier_eu_group[3,5];Week[65].fixture[2].stage="group";
/////////////////////euro qualifying///////////////////////////////////////////////////////////////////////////////////
Week[65].fixture[3].name="Euro Qualifier";Week[65].fixture[3].kind="euroquals";
Week[65].fixture[3].type="league";Week[65].fixture[3].stage="group";  //8 groups of 5  last
Week[65].fixture[3].colour=greenish;Week[65].fixture[3].category="countries";
Week[65].fixture[3].match[1].team1=EUROqualifier_group[1,4];
Week[65].fixture[3].match[1].team2=EUROqualifier_group[1,5];
Week[65].fixture[3].match[2].team1=EUROqualifier_group[2,4];
Week[65].fixture[3].match[2].team2=EUROqualifier_group[2,5];
Week[65].fixture[3].match[3].team1=EUROqualifier_group[3,4];
Week[65].fixture[3].match[3].team2=EUROqualifier_group[3,5];
Week[65].fixture[3].match[4].team1=EUROqualifier_group[4,4];
Week[65].fixture[3].match[4].team2=EUROqualifier_group[4,5];
Week[65].fixture[3].match[5].team1=EUROqualifier_group[5,4];
Week[65].fixture[3].match[5].team2=EUROqualifier_group[5,5];
Week[65].fixture[3].match[6].team1=EUROqualifier_group[6,4];
Week[65].fixture[3].match[6].team2=EUROqualifier_group[6,5];
Week[65].fixture[3].match[7].team1=EUROqualifier_group[7,4];
Week[65].fixture[3].match[7].team2=EUROqualifier_group[7,5];
Week[65].fixture[3].match[8].team1=EUROqualifier_group[8,4];
Week[65].fixture[3].match[8].team2=EUROqualifier_group[8,5];Week[65].fixture[3].match[8].stage="last";
/////////////////////afcon quals///////////////////////////////////////////////////////////////////////////////////
for(int k=66;k<=192;k++){ int m=66; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[1].name="AFCON Qualifiers";Week[k].fixture[1].kind="afconquals";
		Week[k].fixture[1].type="league";Week[k].fixture[1].stage="group";  //8 groups of 6  last round
		Week[k].fixture[1].colour=bluish;Week[k].fixture[1].category="countries";
		Week[k].fixture[1].match[1].team1=AFCONqualifier_group[4,1];
		Week[k].fixture[1].match[1].team2=AFCONqualifier_group[4,6];
		Week[k].fixture[1].match[2].team1=AFCONqualifier_group[4,2];
		Week[k].fixture[1].match[2].team2=AFCONqualifier_group[4,3];
		Week[k].fixture[1].match[3].team1=AFCONqualifier_group[4,4];
		Week[k].fixture[1].match[3].team2=AFCONqualifier_group[4,5];
		Week[k].fixture[1].match[4].team1=AFCONqualifier_group[5,1];
		Week[k].fixture[1].match[4].team2=AFCONqualifier_group[5,6];
		Week[k].fixture[1].match[5].team1=AFCONqualifier_group[5,2];
		Week[k].fixture[1].match[5].team2=AFCONqualifier_group[5,3];
		Week[k].fixture[1].match[6].team1=AFCONqualifier_group[5,4];
		Week[k].fixture[1].match[6].team2=AFCONqualifier_group[5,5];
		Week[k].fixture[1].match[7].team1=AFCONqualifier_group[6,1];
		Week[k].fixture[1].match[7].team2=AFCONqualifier_group[6,6];
		Week[k].fixture[1].match[8].team1=AFCONqualifier_group[6,2];
		Week[k].fixture[1].match[8].team2=AFCONqualifier_group[6,3];
		Week[k].fixture[1].match[9].team1=AFCONqualifier_group[6,4];
		Week[k].fixture[1].match[9].team2=AFCONqualifier_group[6,5]; }}
////////////////////////euro qualifiers///////////////////////////////////////////////////////////////////////
for(int k=68;k<=192;k++){ int m=68; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[2].name="AFCON Qualifiers";Week[k].fixture[2].kind="afconquals";
		Week[k].fixture[2].type="league";Week[k].fixture[2].stage="group";  //8 groups of 6  end
		Week[k].fixture[2].colour=bluish;Week[k].fixture[2].category="countries";
		Week[k].fixture[2].match[1].team1=AFCONqualifier_group[7,1];
		Week[k].fixture[2].match[1].team2=AFCONqualifier_group[7,6];
		Week[k].fixture[2].match[2].team1=AFCONqualifier_group[7,2];
		Week[k].fixture[2].match[2].team2=AFCONqualifier_group[7,3];
		Week[k].fixture[2].match[3].team1=AFCONqualifier_group[7,4];
		Week[k].fixture[2].match[3].team2=AFCONqualifier_group[7,5];
		Week[k].fixture[2].match[4].team1=AFCONqualifier_group[8,1];
		Week[k].fixture[2].match[4].team2=AFCONqualifier_group[8,6];
		Week[k].fixture[2].match[5].team1=AFCONqualifier_group[8,2];
		Week[k].fixture[2].match[5].team2=AFCONqualifier_group[8,3];
		Week[k].fixture[2].match[6].team1=AFCONqualifier_group[8,4];
		Week[k].fixture[2].match[6].team2=AFCONqualifier_group[8,5];Week[k].fixture[2].match[6].stage="last"; }}
///////////////////world cup qualifications/////////////////////////////////////////////////////////////////////////////////////
Week[69].fixture[2].colour=pinkish;Week[69].fixture[2].name="World Cup Qualifying";Week[69].fixture[2].kind="WCQoceania";
Week[69].fixture[2].type="group";Week[69].fixture[2].category="countries";                    //1 group of 8 no 2
Week[69].fixture[2].match[1].team1=WCQualifier_oc_group[1];
Week[69].fixture[2].match[1].team2=WCQualifier_oc_group[5];
Week[69].fixture[2].match[2].team1=WCQualifier_oc_group[2];
Week[69].fixture[2].match[2].team2=WCQualifier_oc_group[6];
Week[69].fixture[2].match[3].team1=WCQualifier_oc_group[3];
Week[69].fixture[2].match[3].team2=WCQualifier_oc_group[7];
Week[69].fixture[2].match[4].team1=WCQualifier_oc_group[4];
Week[69].fixture[2].match[4].team2=WCQualifier_oc_group[8];
//////////////////////friendly//////////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[73].fixture[2].match[1].team1=Friendly[12,1]; //<=always own country //14 friendlies in 4 years
	Week[73].fixture[2].match[1].team2=Friendly[12,2];
	Week[73].fixture[2].colour=bluish;
	Week[73].fixture[2].name="Friendly";Week[73].fixture[2].kind="friendly";}
///////////////////////////////////////////////////////////////////////////////////////////////
////////////////////afcon////////////////////////////////////////////////////////////////////////////////////
for(int k=73;k<=192;k++){ int m=73; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";Week[k].fixture[4].category="countries";  // 4 groups of 16
		Week[k].fixture[4].match[1].team1=AFCON_group[1,1];
		Week[k].fixture[4].match[1].team2=AFCON_group[1,2];
		Week[k].fixture[4].match[2].team1=AFCON_group[1,3];
		Week[k].fixture[4].match[2].team2=AFCON_group[1,4];
		Week[k].fixture[4].match[3].team1=AFCON_group[2,1];
		Week[k].fixture[4].match[3].team2=AFCON_group[2,2];
		Week[k].fixture[4].match[4].team1=AFCON_group[2,3];
		Week[k].fixture[4].match[4].team2=AFCON_group[2,4];
		Week[k].fixture[4].match[5].team1=AFCON_group[3,1];
		Week[k].fixture[4].match[5].team2=AFCON_group[3,2];
		Week[k].fixture[4].match[6].team1=AFCON_group[3,3];
		Week[k].fixture[4].match[6].team2=AFCON_group[3,4];
		Week[k].fixture[4].match[7].team1=AFCON_group[4,1];
		Week[k].fixture[4].match[7].team2=AFCON_group[4,2];
		Week[k].fixture[4].match[8].team1=AFCON_group[4,3];
		Week[k].fixture[4].match[8].team2=AFCON_group[4,4]; }}
////////////////////////////////////////////////////////////////////////////////////////////////////////
for(int k=74;k<=192;k++){ int m=74; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";Week[k].fixture[4].category="countries";  // 4 groups of 16
		Week[k].fixture[4].match[1].team1=AFCON_group[1,1];
		Week[k].fixture[4].match[1].team2=AFCON_group[1,3];
		Week[k].fixture[4].match[2].team1=AFCON_group[1,2];
		Week[k].fixture[4].match[2].team2=AFCON_group[1,4];
		Week[k].fixture[4].match[3].team1=AFCON_group[2,1];
		Week[k].fixture[4].match[3].team2=AFCON_group[2,3];
		Week[k].fixture[4].match[4].team1=AFCON_group[2,2];
		Week[k].fixture[4].match[4].team2=AFCON_group[2,4];
		Week[k].fixture[4].match[5].team1=AFCON_group[3,1];
		Week[k].fixture[4].match[5].team2=AFCON_group[3,3];
		Week[k].fixture[4].match[6].team1=AFCON_group[3,2];
		Week[k].fixture[4].match[6].team2=AFCON_group[3,4];
		Week[k].fixture[4].match[7].team1=AFCON_group[4,1];
		Week[k].fixture[4].match[7].team2=AFCON_group[4,3];
		Week[k].fixture[4].match[8].team1=AFCON_group[4,2];
		Week[k].fixture[4].match[8].team2=AFCON_group[4,4];  }}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
for(int k=75;k<=192;k++){ int m=75; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="league";Week[k].fixture[4].stage="group";Week[k].fixture[4].category="countries";  // 4 groups of 16
		Week[k].fixture[4].match[1].team1=AFCON_group[1,1];
		Week[k].fixture[4].match[1].team2=AFCON_group[1,4];
		Week[k].fixture[4].match[2].team1=AFCON_group[1,2];
		Week[k].fixture[4].match[2].team2=AFCON_group[1,3];
		Week[k].fixture[4].match[3].team1=AFCON_group[2,1];
		Week[k].fixture[4].match[3].team2=AFCON_group[2,4];
		Week[k].fixture[4].match[4].team1=AFCON_group[2,2];
		Week[k].fixture[4].match[4].team2=AFCON_group[2,3];
		Week[k].fixture[4].match[5].team1=AFCON_group[3,1];
		Week[k].fixture[4].match[5].team2=AFCON_group[3,4];
		Week[k].fixture[4].match[6].team1=AFCON_group[3,2];
		Week[k].fixture[4].match[6].team2=AFCON_group[3,3];
		Week[k].fixture[4].match[7].team1=AFCON_group[4,1];
		Week[k].fixture[4].match[7].team2=AFCON_group[4,4];
		Week[k].fixture[4].match[8].team1=AFCON_group[4,2];
		Week[k].fixture[4].match[8].team2=AFCON_group[4,3];
		Week[k].fixture[4].match[8].stage="last"; }}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
for(int k=76;k<=192;k++){ int m=76; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations qf";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="quarterfinal";Week[k].fixture[4].category="countries";  
		Week[k].fixture[4].match[1].team1=AFCON_quarterfinal[1,1];
		Week[k].fixture[4].match[1].team2=AFCON_quarterfinal[1,2];
		Week[k].fixture[4].match[1].position=1;Week[k].fixture[4].match[1].group=1;
		Week[k].fixture[4].match[2].team1=AFCON_quarterfinal[2,1];
		Week[k].fixture[4].match[2].team2=AFCON_quarterfinal[2,2];
		Week[k].fixture[4].match[2].position=2;Week[k].fixture[4].match[2].group=1;
		Week[k].fixture[4].match[3].team1=AFCON_quarterfinal[3,1];
		Week[k].fixture[4].match[3].team2=AFCON_quarterfinal[3,2];
		Week[k].fixture[4].match[3].position=1;Week[k].fixture[4].match[3].group=2;
		Week[k].fixture[4].match[4].team1=AFCON_quarterfinal[4,1];
		Week[k].fixture[4].match[4].team2=AFCON_quarterfinal[4,2];
		Week[k].fixture[4].match[4].position=2;Week[k].fixture[4].match[4].group=2;  }}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
for(int k=77;k<=192;k++){ int m=77; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations sf";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="semifinal"; Week[k].fixture[4].category="countries";
		Week[k].fixture[4].match[1].team1=AFCON_semifinal[1,1];
		Week[k].fixture[4].match[1].team2=AFCON_semifinal[1,2];
		Week[k].fixture[4].match[1].position=1;;
		Week[k].fixture[4].match[2].team1=AFCON_semifinal[2,1];
		Week[k].fixture[4].match[2].team2=AFCON_semifinal[2,2];
		Week[k].fixture[4].match[2].position=2; }}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
for(int k=78;k<=192;k++){ int m=78; if( Contains(new int[]{m,m+96},k) ){
		Week[k].fixture[4].colour=greenish;Week[k].fixture[4].name="Africa cup of Nations final";Week[k].fixture[4].kind="afcon";
		Week[k].fixture[4].type="knockout";Week[k].fixture[4].stage="final"; Week[k].fixture[4].category="countries"; 
		Week[k].fixture[4].match[1].team1=AFCON_final[1];
		Week[k].fixture[4].match[1].team2=AFCON_final[2];  }}
////////////////friendly////////////////////////////////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[75].fixture[2].match[1].team1=Friendly[13,1]; //<=always own country //14 friendlies in 4 years
	Week[75].fixture[2].match[1].team2=Friendly[13,2];
	Week[75].fixture[2].colour=bluish;
	Week[75].fixture[2].name="Friendly";Week[75].fixture[2].kind="friendly";}
////////////////last//friendly//////////////////////////////////////////////////////////////////////////////////////
if(global.category=="countries"){
	Week[83].fixture[2].match[1].team1=Friendly[14,1]; //<=always own country //14 friendlies in 4 years
	Week[83].fixture[2].match[1].team2=Friendly[14,2];
	Week[83].fixture[2].colour=bluish;
	Week[83].fixture[2].name="Friendly";Week[83].fixture[2].kind="friendly";}
////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////euro/////////////////////////////////////////////////////////////////////////////////////////////////////
Week[93].fixture[1].colour=greenish;Week[93].fixture[1].name="Euro";Week[93].fixture[1].kind="euro";
Week[93].fixture[1].type="league";Week[93].fixture[1].stage="group";Week[93].fixture[1].category="countries";  // 4 groups of 16
Week[93].fixture[1].match[1].team1=EURO_group[1,1];
Week[93].fixture[1].match[1].team2=EURO_group[1,2];
Week[93].fixture[1].match[2].team1=EURO_group[1,3];
Week[93].fixture[1].match[2].team2=EURO_group[1,4];
Week[93].fixture[1].match[3].team1=EURO_group[2,1];
Week[93].fixture[1].match[3].team2=EURO_group[2,2];
Week[93].fixture[1].match[4].team1=EURO_group[2,3];
Week[93].fixture[1].match[4].team2=EURO_group[2,4];
Week[93].fixture[1].match[5].team1=EURO_group[3,1];
Week[93].fixture[1].match[5].team2=EURO_group[3,2];
Week[93].fixture[1].match[6].team1=EURO_group[3,3];
Week[93].fixture[1].match[6].team2=EURO_group[3,4];
Week[93].fixture[1].match[7].team1=EURO_group[4,1];
Week[93].fixture[1].match[7].team2=EURO_group[4,2];
Week[93].fixture[1].match[8].team1=EURO_group[4,3];
Week[93].fixture[1].match[8].team2=EURO_group[4,4];
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////euro/////////////////////////////////////////////////////////////////////////////////////////////////////
Week[94].fixture[1].colour=greenish;Week[94].fixture[1].name="Euro";Week[94].fixture[1].kind="euro";
Week[94].fixture[1].type="league";Week[94].fixture[1].stage="group";Week[94].fixture[1].category="countries";  // 4 groups of 16
Week[94].fixture[1].match[1].team1=EURO_group[1,1];
Week[94].fixture[1].match[1].team2=EURO_group[1,3];
Week[94].fixture[1].match[2].team1=EURO_group[1,2];
Week[94].fixture[1].match[2].team2=EURO_group[1,4];
Week[94].fixture[1].match[3].team1=EURO_group[2,1];
Week[94].fixture[1].match[3].team2=EURO_group[2,3];
Week[94].fixture[1].match[4].team1=EURO_group[2,2];
Week[94].fixture[1].match[4].team2=EURO_group[2,4];
Week[94].fixture[1].match[5].team1=EURO_group[3,1];
Week[94].fixture[1].match[5].team2=EURO_group[3,3];
Week[94].fixture[1].match[6].team1=EURO_group[3,2];
Week[94].fixture[1].match[6].team2=EURO_group[3,4];
Week[94].fixture[1].match[7].team1=EURO_group[4,1];
Week[94].fixture[1].match[7].team2=EURO_group[4,3];
Week[94].fixture[1].match[8].team1=EURO_group[4,2];
Week[94].fixture[1].match[8].team2=EURO_group[4,4];
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////euro/////////////////////////////////////////////////////////////////////////////////////////////////////
Week[95].fixture[1].colour=greenish;Week[95].fixture[1].name="Euro";Week[95].fixture[1].kind="euro";
Week[95].fixture[1].type="league";Week[95].fixture[1].stage="group";Week[95].fixture[1].category="countries";  // 4 groups of 16
Week[95].fixture[1].match[1].team1=EURO_group[1,1];
Week[95].fixture[1].match[1].team2=EURO_group[1,4];
Week[95].fixture[1].match[2].team1=EURO_group[1,2];
Week[95].fixture[1].match[2].team2=EURO_group[1,3];
Week[95].fixture[1].match[3].team1=EURO_group[2,1];
Week[95].fixture[1].match[3].team2=EURO_group[2,4];
Week[95].fixture[1].match[4].team1=EURO_group[2,2];
Week[95].fixture[1].match[4].team2=EURO_group[2,3];
Week[95].fixture[1].match[5].team1=EURO_group[3,1];
Week[95].fixture[1].match[5].team2=EURO_group[3,4];
Week[95].fixture[1].match[6].team1=EURO_group[3,2];
Week[95].fixture[1].match[6].team2=EURO_group[3,3];
Week[95].fixture[1].match[7].team1=EURO_group[4,1];
Week[95].fixture[1].match[7].team2=EURO_group[4,4];
Week[95].fixture[1].match[8].team1=EURO_group[4,2];
Week[95].fixture[1].match[8].team2=EURO_group[4,3];
Week[95].fixture[1].match[8].stage="last";
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[96].fixture[1].colour=greenish;Week[96].fixture[1].name="Euro quarter final";Week[96].fixture[1].kind="euro";
Week[96].fixture[1].type="knockout";Week[96].fixture[1].stage="quarterfinal";Week[96].fixture[1].category="countries";   
Week[96].fixture[1].match[1].team1=EURO_quarterfinal[1,1];
Week[96].fixture[1].match[1].team2=EURO_quarterfinal[1,2];
Week[96].fixture[1].match[1].position=1;Week[96].fixture[1].match[1].group=1;
Week[96].fixture[1].match[2].team1=EURO_quarterfinal[2,1];
Week[96].fixture[1].match[2].team2=EURO_quarterfinal[2,2];
Week[96].fixture[1].match[2].position=2;Week[96].fixture[1].match[2].group=1;
Week[96].fixture[1].match[3].team1=EURO_quarterfinal[3,1];
Week[96].fixture[1].match[3].team2=EURO_quarterfinal[3,2];
Week[96].fixture[1].match[3].position=1;Week[96].fixture[1].match[3].group=2;
Week[96].fixture[1].match[4].team1=EURO_quarterfinal[4,1];
Week[96].fixture[1].match[4].team2=EURO_quarterfinal[4,2];
Week[96].fixture[1].match[4].position=2;Week[96].fixture[1].match[4].group=2;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[97].fixture[4].colour=greenish;Week[97].fixture[4].name="Euro semi final";Week[97].fixture[4].kind="euro";
Week[97].fixture[4].type="knockout";Week[97].fixture[4].stage="semifinal"; Week[97].fixture[4].category="countries";  
Week[97].fixture[4].match[1].team1=EURO_semifinal[1,1];
Week[97].fixture[4].match[1].team2=EURO_semifinal[1,2];
Week[97].fixture[4].match[1].position=1;
Week[97].fixture[4].match[2].team1=EURO_semifinal[2,1];
Week[97].fixture[4].match[2].team2=EURO_semifinal[2,2];
Week[97].fixture[4].match[2].position=2;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[98].fixture[4].colour=greenish;Week[98].fixture[4].name="Euro final";Week[98].fixture[4].kind="euro";
Week[98].fixture[4].type="knockout";Week[98].fixture[4].stage="final";Week[98].fixture[4].category="countries";  
Week[98].fixture[4].match[1].team1=EURO_final[1];
Week[98].fixture[4].match[1].team2=EURO_final[2];
////////////////104 world cup qualifications/////third year///////////////////////////////////////////////////////////////////
Week[104].fixture[2].colour=pinkish;Week[104].fixture[2].name="World Cup Qualifying";Week[104].fixture[2].kind="WCQeurope";
Week[104].fixture[2].type="league";Week[104].fixture[2].colour=bluish; Week[104].fixture[2].category="countries";                //7 groups of 6
Week[104].fixture[2].match[1].team1=WCQualifier_eu_group[4,1]; //group 1 team 1
Week[104].fixture[2].match[1].team2=WCQualifier_eu_group[4,4];
Week[104].fixture[2].match[2].team1=WCQualifier_eu_group[4,2]; 
Week[104].fixture[2].match[2].team2=WCQualifier_eu_group[4,6];
Week[104].fixture[2].match[3].team1=WCQualifier_eu_group[4,3]; 
Week[104].fixture[2].match[3].team2=WCQualifier_eu_group[4,5];
Week[104].fixture[2].match[4].team1=WCQualifier_eu_group[5,1]; 
Week[104].fixture[2].match[4].team2=WCQualifier_eu_group[5,4];
Week[104].fixture[2].match[5].team1=WCQualifier_eu_group[5,2]; 
Week[104].fixture[2].match[5].team2=WCQualifier_eu_group[5,6];
Week[104].fixture[2].match[6].team1=WCQualifier_eu_group[5,3]; 
Week[104].fixture[2].match[6].team2=WCQualifier_eu_group[5,5];
Week[104].fixture[2].match[7].team1=WCQualifier_eu_group[6,1]; 
Week[104].fixture[2].match[7].team2=WCQualifier_eu_group[6,4];
Week[104].fixture[2].match[8].team1=WCQualifier_eu_group[6,2]; 
Week[104].fixture[2].match[8].team2=WCQualifier_eu_group[6,6];
Week[104].fixture[2].match[9].team1=WCQualifier_eu_group[6,3]; 
Week[104].fixture[2].match[9].team2=WCQualifier_eu_group[6,5];
///////////////////world cup qualification africa/////////////////////////////////////////////////////////////////////////////////////
Week[104].fixture[africa2].colour=pinkish;Week[104].fixture[africa2].name="World Cup Qualifying";Week[104].fixture[africa2].kind="WCQafrica";
Week[104].fixture[africa2].type="group";Week[104].fixture[africa2].category="countries";          //first group fixture
Week[104].fixture[africa2].match[1].team1=WCQualifier_af_group[5,1];  //5 groups of 5  2 legs this leg is done
Week[104].fixture[africa2].match[1].team2=WCQualifier_af_group[5,4];
Week[104].fixture[africa2].match[2].team1=WCQualifier_af_group[5,2]; 
Week[104].fixture[africa2].match[2].team2=WCQualifier_af_group[5,3];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[104].fixture[asia2].colour=pinkish;Week[104].fixture[asia2].name="World Cup Qualifying";Week[104].fixture[asia2].kind="WCQasia";
Week[104].fixture[asia2].type="group"; Week[104].fixture[asia2].category="countries";              //2nd round 2 fixtures to go
Week[104].fixture[asia2].match[1].team1=WCQualifier_as_group[1,3];  //4 groups of 5
Week[104].fixture[asia2].match[1].team2=WCQualifier_as_group[1,1]; 
Week[104].fixture[asia2].match[2].team1=WCQualifier_as_group[1,4];  
Week[104].fixture[asia2].match[2].team2=WCQualifier_as_group[1,2];
Week[104].fixture[asia2].match[3].team1=WCQualifier_as_group[2,3];  
Week[104].fixture[asia2].match[3].team2=WCQualifier_as_group[2,1];
Week[104].fixture[asia2].match[4].team1=WCQualifier_as_group[2,4];  
Week[104].fixture[asia2].match[4].team2=WCQualifier_as_group[2,2];
Week[104].fixture[asia2].match[5].team1=WCQualifier_as_group[3,3];  
Week[104].fixture[asia2].match[5].team2=WCQualifier_as_group[3,1];
Week[104].fixture[asia2].match[6].team1=WCQualifier_as_group[3,4];  
Week[104].fixture[asia2].match[6].team2=WCQualifier_as_group[3,2];
Week[104].fixture[asia2].match[7].team1=WCQualifier_as_group[4,3];  
Week[104].fixture[asia2].match[7].team2=WCQualifier_as_group[4,1];
Week[104].fixture[asia2].match[8].team1=WCQualifier_as_group[4,4];  
Week[104].fixture[asia2].match[8].team2=WCQualifier_as_group[4,2];
//////////////////world cup qualifying north america///////////////////////////////////////////////////////////////////////////////////
Week[104].fixture[northamerica2].colour=pinkish;Week[104].fixture[northamerica2].name="World Cup Qualifying";
Week[104].fixture[northamerica2].kind="WCQnorthamerica";    
Week[104].fixture[northamerica2].type="league";Week[104].fixture[northamerica2].category="countries";
Week[104].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[104].fixture[northamerica2].match[1].team2= WCQualifier_na_group[6];
Week[104].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[104].fixture[northamerica2].match[2].team2= WCQualifier_na_group[3];
Week[104].fixture[northamerica2].match[3].team1= WCQualifier_na_group[4];
Week[104].fixture[northamerica2].match[3].team2= WCQualifier_na_group[5];
Week[104].fixture[northamerica2].match[4].team1= WCQualifier_na_group[7];
Week[104].fixture[northamerica2].match[4].team2= WCQualifier_na_group[16];
Week[104].fixture[northamerica2].match[5].team1= WCQualifier_na_group[8];
Week[104].fixture[northamerica2].match[5].team2= WCQualifier_na_group[15];
Week[104].fixture[northamerica2].match[6].team1= WCQualifier_na_group[9];
Week[104].fixture[northamerica2].match[6].team2= WCQualifier_na_group[13];
Week[104].fixture[northamerica2].match[7].team1= WCQualifier_na_group[10];
Week[104].fixture[northamerica2].match[7].team2= WCQualifier_na_group[11];
///////////////world cup qualifications/////106///////////////////////////////////////////////////////////////////////////
Week[106].fixture[2].colour=pinkish;Week[106].fixture[2].name="World Cup Qualifying";Week[106].fixture[2].kind="WCQoceania";
Week[106].fixture[2].type="group"; Week[106].fixture[2].category="countries";                   //1 group of 8 no 2  2 left
Week[106].fixture[2].match[1].team1=WCQualifier_oc_group[1];
Week[106].fixture[2].match[1].team2=WCQualifier_oc_group[8];
Week[106].fixture[2].match[2].team1=WCQualifier_oc_group[2];
Week[106].fixture[2].match[2].team2=WCQualifier_oc_group[7];
Week[106].fixture[2].match[3].team1=WCQualifier_oc_group[3];
Week[106].fixture[2].match[3].team2=WCQualifier_oc_group[6];
Week[106].fixture[2].match[4].team1=WCQualifier_oc_group[4];
Week[106].fixture[2].match[4].team2=WCQualifier_oc_group[5];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[106].fixture[africa2].colour=pinkish;Week[106].fixture[africa2].name="World Cup Qualifying";Week[106].fixture[africa2].kind="WCQafrica";
Week[106].fixture[africa2].type="group"; Week[106].fixture[africa2].category="countries";         //
Week[106].fixture[africa2].match[1].team1=WCQualifier_af_group[1,2];  //5 groups of 5  2nd round
Week[106].fixture[africa2].match[1].team2=WCQualifier_af_group[1,1];
Week[106].fixture[africa2].match[2].team1=WCQualifier_af_group[1,4]; 
Week[106].fixture[africa2].match[2].team2=WCQualifier_af_group[1,3];
Week[106].fixture[africa2].match[3].team1=WCQualifier_af_group[2,2];  
Week[106].fixture[africa2].match[3].team2=WCQualifier_af_group[2,1];
Week[106].fixture[africa2].match[4].team1=WCQualifier_af_group[2,4]; 
Week[106].fixture[africa2].match[4].team2=WCQualifier_af_group[2,3];
Week[106].fixture[africa2].match[5].team1=WCQualifier_af_group[3,2]; 
Week[106].fixture[africa2].match[5].team2=WCQualifier_af_group[3,1];
Week[106].fixture[africa2].match[6].team1=WCQualifier_af_group[3,4]; 
Week[106].fixture[africa2].match[6].team2=WCQualifier_af_group[3,3];
Week[106].fixture[africa2].match[7].team1=WCQualifier_af_group[4,2];  
Week[106].fixture[africa2].match[7].team2=WCQualifier_af_group[4,1];
Week[106].fixture[africa2].match[8].team1=WCQualifier_af_group[4,4]; 
Week[106].fixture[africa2].match[8].team2=WCQualifier_af_group[4,3];
//////////////////////world cup qualification//europe///////////////////////////////////////////////////////////////////////
Week[113].fixture[2].colour=pinkish;Week[113].fixture[2].name="World Cup Qualifying";Week[113].fixture[2].kind="WCQeurope";
Week[113].fixture[2].type="league";Week[113].fixture[2].colour=bluish;Week[113].fixture[2].category="countries";                  //7 groups of 6
Week[113].fixture[2].match[1].team1=WCQualifier_eu_group[7,1]; //last of first round
Week[113].fixture[2].match[1].team2=WCQualifier_eu_group[7,4];
Week[113].fixture[2].match[2].team1=WCQualifier_eu_group[7,2]; 
Week[113].fixture[2].match[2].team2=WCQualifier_eu_group[7,6];
Week[113].fixture[2].match[3].team1=WCQualifier_eu_group[7,3]; 
Week[113].fixture[2].match[3].team2=WCQualifier_eu_group[7,5];
///////////////////world cup qualifying north america/////////////////////////////////////////////////////////////////////////////////////
Week[113].fixture[northamerica2].colour=pinkish;Week[113].fixture[northamerica2].name="World Cup Qualifying";
Week[113].fixture[northamerica2].kind="WCQnorthamerica"; Week[113].fixture[northamerica2].category="countries";    
Week[113].fixture[northamerica2].type="league";
Week[113].fixture[northamerica2].match[1].team1= WCQualifier_na_group[6];
Week[113].fixture[northamerica2].match[1].team2= WCQualifier_na_group[16];
Week[113].fixture[northamerica2].match[2].team1= WCQualifier_na_group[3];
Week[113].fixture[northamerica2].match[2].team2= WCQualifier_na_group[10];
Week[113].fixture[northamerica2].match[3].team1= WCQualifier_na_group[1];
Week[113].fixture[northamerica2].match[3].team2= WCQualifier_na_group[9];
Week[113].fixture[northamerica2].match[4].team1= WCQualifier_na_group[7];
Week[113].fixture[northamerica2].match[4].team2= WCQualifier_na_group[14];
Week[113].fixture[northamerica2].match[5].team1= WCQualifier_na_group[4];
Week[113].fixture[northamerica2].match[5].team2= WCQualifier_na_group[12];
Week[113].fixture[northamerica2].match[6].team1= WCQualifier_na_group[11];
Week[113].fixture[northamerica2].match[6].team2= WCQualifier_na_group[2];
Week[113].fixture[northamerica2].match[7].team1= WCQualifier_na_group[5];
Week[113].fixture[northamerica2].match[7].team2= WCQualifier_na_group[13];
/////////////////////world cup qualifying 117//////////////////////////////////////////////////////////////////////////
Week[117].fixture[2].colour=pinkish;Week[117].fixture[2].name="World Cup Qualifying";Week[117].fixture[2].kind="WCQeurope";
Week[117].fixture[2].type="league";Week[117].fixture[2].colour=bluish; Week[117].fixture[2].category="countries";                 //7 groups of 6
Week[117].fixture[2].match[1].team1=WCQualifier_eu_group[1,2]; //second round
Week[117].fixture[2].match[1].team2=WCQualifier_eu_group[1,1];
Week[117].fixture[2].match[2].team1=WCQualifier_eu_group[1,4]; 
Week[117].fixture[2].match[2].team2=WCQualifier_eu_group[1,3];
Week[117].fixture[2].match[3].team1=WCQualifier_eu_group[1,6]; 
Week[117].fixture[2].match[3].team2=WCQualifier_eu_group[1,5];
Week[117].fixture[2].match[4].team1=WCQualifier_eu_group[2,2]; 
Week[117].fixture[2].match[4].team2=WCQualifier_eu_group[2,1];
Week[117].fixture[2].match[5].team1=WCQualifier_eu_group[2,4]; 
Week[117].fixture[2].match[5].team2=WCQualifier_eu_group[2,3];
Week[117].fixture[2].match[6].team1=WCQualifier_eu_group[2,6]; 
Week[117].fixture[2].match[6].team2=WCQualifier_eu_group[2,5];
Week[117].fixture[2].match[7].team1=WCQualifier_eu_group[3,2]; 
Week[117].fixture[2].match[7].team2=WCQualifier_eu_group[3,1];
Week[117].fixture[2].match[8].team1=WCQualifier_eu_group[3,4]; 
Week[117].fixture[2].match[8].team2=WCQualifier_eu_group[3,3];
Week[117].fixture[2].match[9].team1=WCQualifier_eu_group[3,6]; 
Week[117].fixture[2].match[9].team2=WCQualifier_eu_group[3,5];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[117].fixture[africa2].colour=pinkish;Week[117].fixture[africa2].name="World Cup Qualifying";Week[117].fixture[africa2].kind="WCQafrica";
Week[117].fixture[africa2].type="group"; Week[117].fixture[africa2].category="countries";          //
Week[117].fixture[africa2].match[1].team1=WCQualifier_af_group[5,2];  //5 groups of 5  2nd round
Week[117].fixture[africa2].match[1].team2=WCQualifier_af_group[5,1];
Week[117].fixture[africa2].match[2].team1=WCQualifier_af_group[5,4]; 
Week[117].fixture[africa2].match[2].team2=WCQualifier_af_group[5,3];
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[117].fixture[northamerica2].colour=pinkish;Week[117].fixture[northamerica2].name="World Cup Qualifying";
Week[117].fixture[northamerica2].kind="WCQnorthamerica"; Week[117].fixture[northamerica2].category="countries";    
Week[117].fixture[northamerica2].type="league";
Week[117].fixture[northamerica2].match[1].team1= WCQualifier_na_group[12];
Week[117].fixture[northamerica2].match[1].team2= WCQualifier_na_group[6];
Week[117].fixture[northamerica2].match[2].team1= WCQualifier_na_group[1];
Week[117].fixture[northamerica2].match[2].team2= WCQualifier_na_group[14];
Week[117].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[117].fixture[northamerica2].match[3].team2= WCQualifier_na_group[15];
Week[117].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[117].fixture[northamerica2].match[4].team2= WCQualifier_na_group[16];
Week[117].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[117].fixture[northamerica2].match[5].team2= WCQualifier_na_group[11];
Week[117].fixture[northamerica2].match[6].team1= WCQualifier_na_group[7];
Week[117].fixture[northamerica2].match[6].team2= WCQualifier_na_group[13];
Week[117].fixture[northamerica2].match[7].team1= WCQualifier_na_group[10];
Week[117].fixture[northamerica2].match[7].team2= WCQualifier_na_group[2];
//////////////world cup qualifying south america//118///////////////////////////////////////////////////////////////////////////////
Week[118].fixture[1].colour=pinkish;Week[118].fixture[1].name="World Cup Qualifying";Week[118].fixture[1].kind="WCQsouthamerica";
Week[118].fixture[1].type="league"; Week[118].fixture[1].colour=greenish;Week[118].fixture[1].category="countries";                 //1 groups of 10  no 4
Week[118].fixture[1].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[118].fixture[1].match[1].team2=WCQualifier_sa_group[6];
Week[118].fixture[1].match[2].team1=WCQualifier_sa_group[2]; 
Week[118].fixture[1].match[2].team2=WCQualifier_sa_group[7];
Week[118].fixture[1].match[3].team1=WCQualifier_sa_group[3]; 
Week[118].fixture[1].match[3].team2=WCQualifier_sa_group[5];
Week[118].fixture[1].match[4].team1=WCQualifier_sa_group[4]; 
Week[118].fixture[1].match[4].team2=WCQualifier_sa_group[9];
/////////////////world cup qualification///////////////////////////////////////////////////////////////////////////////////////
Week[118].fixture[africa2].colour=pinkish;Week[118].fixture[africa2].name="World Cup Qualifying";Week[118].fixture[africa2].kind="WCQafrica";
Week[118].fixture[africa2].type="group";   Week[118].fixture[africa2].category="countries";        //
Week[118].fixture[africa2].match[1].team1=WCQualifier_af_group[1,3];  //5 groups of 5  2nd round
Week[118].fixture[africa2].match[1].team2=WCQualifier_af_group[1,1];
Week[118].fixture[africa2].match[2].team1=WCQualifier_af_group[1,4]; 
Week[118].fixture[africa2].match[2].team2=WCQualifier_af_group[1,2];
Week[118].fixture[africa2].match[3].team1=WCQualifier_af_group[2,3];  
Week[118].fixture[africa2].match[3].team2=WCQualifier_af_group[2,1];
Week[118].fixture[africa2].match[4].team1=WCQualifier_af_group[2,4]; 
Week[118].fixture[africa2].match[4].team2=WCQualifier_af_group[2,2];
Week[118].fixture[africa2].match[5].team1=WCQualifier_af_group[3,3]; 
Week[118].fixture[africa2].match[5].team2=WCQualifier_af_group[3,1];
Week[118].fixture[africa2].match[6].team1=WCQualifier_af_group[3,4]; 
Week[118].fixture[africa2].match[6].team2=WCQualifier_af_group[3,2];
Week[118].fixture[africa2].match[7].team1=WCQualifier_af_group[4,3];  
Week[118].fixture[africa2].match[7].team2=WCQualifier_af_group[4,1];
Week[118].fixture[africa2].match[8].team1=WCQualifier_af_group[4,4]; 
Week[118].fixture[africa2].match[8].team2=WCQualifier_af_group[4,2];
///////////////world cup qualification 119////////////////////////////////////////////////////////////////////////////////
Week[119].fixture[2].colour=pinkish;Week[119].fixture[2].name="World Cup Qualifying";Week[119].fixture[2].kind="WCQeurope";
Week[119].fixture[2].type="league";Week[119].fixture[2].colour=bluish; Week[119].fixture[2].category="countries";                 //7 groups of 6
Week[119].fixture[2].match[1].team1=WCQualifier_eu_group[4,2]; //second round
Week[119].fixture[2].match[1].team2=WCQualifier_eu_group[4,1];
Week[119].fixture[2].match[2].team1=WCQualifier_eu_group[4,4]; 
Week[119].fixture[2].match[2].team2=WCQualifier_eu_group[4,3];
Week[119].fixture[2].match[3].team1=WCQualifier_eu_group[4,6]; 
Week[119].fixture[2].match[3].team2=WCQualifier_eu_group[4,5];
Week[119].fixture[2].match[4].team1=WCQualifier_eu_group[5,2]; 
Week[119].fixture[2].match[4].team2=WCQualifier_eu_group[5,1];
Week[119].fixture[2].match[5].team1=WCQualifier_eu_group[5,4]; 
Week[119].fixture[2].match[5].team2=WCQualifier_eu_group[5,3];
Week[119].fixture[2].match[6].team1=WCQualifier_eu_group[5,6]; 
Week[119].fixture[2].match[6].team2=WCQualifier_eu_group[5,5];
Week[119].fixture[2].match[7].team1=WCQualifier_eu_group[6,2]; 
Week[119].fixture[2].match[7].team2=WCQualifier_eu_group[6,1];
Week[119].fixture[2].match[8].team1=WCQualifier_eu_group[6,4]; 
Week[119].fixture[2].match[8].team2=WCQualifier_eu_group[6,3];
Week[119].fixture[2].match[9].team1=WCQualifier_eu_group[6,6]; 
Week[119].fixture[2].match[9].team2=WCQualifier_eu_group[6,5];
///////////////////world cup qualifier///150//////////////////////////////////////////////////////////////////////////////////
Week[150].fixture[2].colour=pinkish;Week[150].fixture[2].name="World Cup Qualifying";Week[150].fixture[2].kind="WCQeurope";
Week[150].fixture[2].type="league";Week[150].fixture[2].colour=bluish; Week[150].fixture[2].category="countries";                 //7 groups of 6
Week[150].fixture[2].match[1].team1=WCQualifier_eu_group[7,2]; //second round
Week[150].fixture[2].match[1].team2=WCQualifier_eu_group[7,1];
Week[150].fixture[2].match[2].team1=WCQualifier_eu_group[7,4]; 
Week[150].fixture[2].match[2].team2=WCQualifier_eu_group[7,3];
Week[150].fixture[2].match[3].team1=WCQualifier_eu_group[7,6]; 
Week[150].fixture[2].match[3].team2=WCQualifier_eu_group[7,5];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[150].fixture[africa2].colour=pinkish;Week[150].fixture[africa2].name="World Cup Qualifying";Week[150].fixture[africa2].kind="WCQafrica";
Week[150].fixture[africa2].type="group"; Week[150].fixture[africa2].category="countries";          //
Week[150].fixture[africa2].match[1].team1=WCQualifier_af_group[5,3];  //5 groups of 5  2nd round
Week[150].fixture[africa2].match[1].team2=WCQualifier_af_group[5,1];
Week[150].fixture[africa2].match[2].team1=WCQualifier_af_group[5,4]; 
Week[150].fixture[africa2].match[2].team2=WCQualifier_af_group[5,2];
Week[150].fixture[africa2].match[3].team1=WCQualifier_af_group[1,5];  
Week[150].fixture[africa2].match[3].team2=WCQualifier_af_group[1,1];
Week[150].fixture[africa2].match[4].team1=WCQualifier_af_group[2,5]; 
Week[150].fixture[africa2].match[4].team2=WCQualifier_af_group[2,1];
Week[150].fixture[africa2].match[5].team1=WCQualifier_af_group[3,5]; 
Week[150].fixture[africa2].match[5].team2=WCQualifier_af_group[3,1];
Week[150].fixture[africa2].match[6].team1=WCQualifier_af_group[4,5]; 
Week[150].fixture[africa2].match[6].team2=WCQualifier_af_group[4,1];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[150].fixture[northamerica2].colour=pinkish;Week[150].fixture[northamerica2].name="World Cup Qualifying";
Week[150].fixture[northamerica2].kind="WCQnorthamerica"; Week[150].fixture[northamerica2].category="countries";    
Week[150].fixture[northamerica2].type="league";
Week[150].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[150].fixture[northamerica2].match[1].team2= WCQualifier_na_group[15];
Week[150].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[150].fixture[northamerica2].match[2].team2= WCQualifier_na_group[6];
Week[150].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[150].fixture[northamerica2].match[3].team2= WCQualifier_na_group[8];
Week[150].fixture[northamerica2].match[4].team1= WCQualifier_na_group[7];
Week[150].fixture[northamerica2].match[4].team2= WCQualifier_na_group[11];
Week[150].fixture[northamerica2].match[5].team1= WCQualifier_na_group[4];
Week[150].fixture[northamerica2].match[5].team2= WCQualifier_na_group[14];
Week[150].fixture[northamerica2].match[6].team1= WCQualifier_na_group[5];
Week[150].fixture[northamerica2].match[6].team2= WCQualifier_na_group[9];
//////////////////////world cup qualification//151////////////////////////////////////////////////////////////////////////////////
Week[151].fixture[1].colour=pinkish;Week[151].fixture[1].name="World Cup Qualifying";Week[151].fixture[1].kind="WCQsouthamerica";
Week[151].fixture[1].type="league"; Week[151].fixture[1].colour=greenish; Week[151].fixture[1].category="countries";                //1 groups of 10  no 5
Week[151].fixture[1].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[151].fixture[1].match[1].team2=WCQualifier_sa_group[4];
Week[151].fixture[1].match[2].team1=WCQualifier_sa_group[2]; 
Week[151].fixture[1].match[2].team2=WCQualifier_sa_group[3];
Week[151].fixture[1].match[3].team1=WCQualifier_sa_group[5]; 
Week[151].fixture[1].match[3].team2=WCQualifier_sa_group[8];
Week[151].fixture[1].match[4].team1=WCQualifier_sa_group[9]; 
Week[151].fixture[1].match[4].team2=WCQualifier_sa_group[7];
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[151].fixture[africa2].colour=pinkish;Week[151].fixture[africa2].name="World Cup Qualifying";Week[151].fixture[africa2].kind="WCQafrica";
Week[151].fixture[africa2].type="group";  Week[151].fixture[africa2].category="countries";         //
Week[151].fixture[africa2].match[1].team1=WCQualifier_af_group[5,5];  //5 groups of 5  next 4132 on 5 and 5,2 5,3 5,4 and 2,5 3,5 4,5
Week[151].fixture[africa2].match[1].team2=WCQualifier_af_group[5,1];
Week[151].fixture[africa2].match[2].team1=WCQualifier_af_group[1,4]; 
Week[151].fixture[africa2].match[2].team2=WCQualifier_af_group[1,1];
Week[151].fixture[africa2].match[3].team1=WCQualifier_af_group[1,3];  
Week[151].fixture[africa2].match[3].team2=WCQualifier_af_group[1,2];
Week[151].fixture[africa2].match[4].team1=WCQualifier_af_group[2,4]; 
Week[151].fixture[africa2].match[4].team2=WCQualifier_af_group[2,1];
Week[151].fixture[africa2].match[5].team1=WCQualifier_af_group[2,3]; 
Week[151].fixture[africa2].match[5].team2=WCQualifier_af_group[2,2];
Week[151].fixture[africa2].match[6].team1=WCQualifier_af_group[3,4]; 
Week[151].fixture[africa2].match[6].team2=WCQualifier_af_group[3,1];
Week[151].fixture[africa2].match[7].team1=WCQualifier_af_group[3,3]; 
Week[151].fixture[africa2].match[7].team2=WCQualifier_af_group[3,2];
Week[151].fixture[africa2].match[8].team1=WCQualifier_af_group[4,4]; 
Week[151].fixture[africa2].match[8].team2=WCQualifier_af_group[4,1];
Week[151].fixture[africa2].match[9].team1=WCQualifier_af_group[4,3]; 
Week[151].fixture[africa2].match[9].team2=WCQualifier_af_group[4,2];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[151].fixture[northamerica2].colour=pinkish;Week[151].fixture[northamerica2].name="World Cup Qualifying";
Week[151].fixture[northamerica2].kind="WCQnorthamerica"; Week[151].fixture[northamerica2].category="countries";    
Week[151].fixture[northamerica2].type="league";
Week[151].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[151].fixture[northamerica2].match[1].team2= WCQualifier_na_group[11];
Week[151].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[151].fixture[northamerica2].match[2].team2= WCQualifier_na_group[9];
Week[151].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[151].fixture[northamerica2].match[3].team2= WCQualifier_na_group[12];
Week[151].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[151].fixture[northamerica2].match[4].team2= WCQualifier_na_group[7];
Week[151].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[151].fixture[northamerica2].match[5].team2= WCQualifier_na_group[15];
Week[151].fixture[northamerica2].match[6].team1= WCQualifier_na_group[6];
Week[151].fixture[northamerica2].match[6].team2= WCQualifier_na_group[13];
Week[151].fixture[northamerica2].match[7].team1= WCQualifier_na_group[8];
Week[151].fixture[northamerica2].match[7].team2= WCQualifier_na_group[16];
Week[151].fixture[northamerica2].match[8].team1= WCQualifier_na_group[14];
Week[151].fixture[northamerica2].match[8].team2= WCQualifier_na_group[10];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[151].fixture[asia2].colour=pinkish;Week[151].fixture[asia2].name="World Cup Qualifying";Week[151].fixture[asia2].kind="WCQasia";
Week[151].fixture[asia2].type="group";Week[151].fixture[asia2].category="countries";                //2nd round 1 fixture to go
Week[151].fixture[asia2].match[1].team1=WCQualifier_as_group[1,4];  //4 groups of 5
Week[151].fixture[asia2].match[1].team2=WCQualifier_as_group[1,1]; 
Week[151].fixture[asia2].match[2].team1=WCQualifier_as_group[1,3];  
Week[151].fixture[asia2].match[2].team2=WCQualifier_as_group[1,2];
Week[151].fixture[asia2].match[3].team1=WCQualifier_as_group[2,4];  
Week[151].fixture[asia2].match[3].team2=WCQualifier_as_group[2,1];
Week[151].fixture[asia2].match[4].team1=WCQualifier_as_group[2,3];  
Week[151].fixture[asia2].match[4].team2=WCQualifier_as_group[2,2];
Week[151].fixture[asia2].match[5].team1=WCQualifier_as_group[3,4];  
Week[151].fixture[asia2].match[5].team2=WCQualifier_as_group[3,1];
Week[151].fixture[asia2].match[6].team1=WCQualifier_as_group[3,3];  
Week[151].fixture[asia2].match[6].team2=WCQualifier_as_group[3,2];
Week[151].fixture[asia2].match[7].team1=WCQualifier_as_group[4,4];  
Week[151].fixture[asia2].match[7].team2=WCQualifier_as_group[4,1];
Week[151].fixture[asia2].match[8].team1=WCQualifier_as_group[4,3];  
Week[151].fixture[asia2].match[8].team2=WCQualifier_as_group[4,2];
/////////////////world cup qualifier//152////////////////////////////////////////////////////////////////////////////
Week[152].fixture[2].colour=pinkish;Week[152].fixture[2].name="World Cup Qualifying";Week[152].fixture[2].kind="WCQeurope";
Week[152].fixture[2].type="league";Week[152].fixture[2].colour=bluish;Week[152].fixture[2].category="countries";                  //7 groups of 6
Week[152].fixture[2].match[1].team1=WCQualifier_eu_group[1,3]; //second round
Week[152].fixture[2].match[1].team2=WCQualifier_eu_group[1,1];
Week[152].fixture[2].match[2].team1=WCQualifier_eu_group[1,5]; 
Week[152].fixture[2].match[2].team2=WCQualifier_eu_group[1,2];
Week[152].fixture[2].match[3].team1=WCQualifier_eu_group[1,6]; 
Week[152].fixture[2].match[3].team2=WCQualifier_eu_group[1,4];
Week[152].fixture[2].match[4].team1=WCQualifier_eu_group[2,3]; 
Week[152].fixture[2].match[4].team2=WCQualifier_eu_group[2,1];
Week[152].fixture[2].match[5].team1=WCQualifier_eu_group[2,5]; 
Week[152].fixture[2].match[5].team2=WCQualifier_eu_group[2,2];
Week[152].fixture[2].match[6].team1=WCQualifier_eu_group[2,6]; 
Week[152].fixture[2].match[6].team2=WCQualifier_eu_group[2,4];
Week[152].fixture[2].match[7].team1=WCQualifier_eu_group[3,3]; 
Week[152].fixture[2].match[7].team2=WCQualifier_eu_group[3,1];
Week[152].fixture[2].match[8].team1=WCQualifier_eu_group[3,5]; 
Week[152].fixture[2].match[8].team2=WCQualifier_eu_group[3,2];
Week[152].fixture[2].match[9].team1=WCQualifier_eu_group[3,6]; 
Week[152].fixture[2].match[9].team2=WCQualifier_eu_group[3,4];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[152].fixture[africa2].colour=pinkish;Week[152].fixture[africa2].name="World Cup Qualifying";Week[152].fixture[africa2].kind="WCQafrica";
Week[152].fixture[africa2].type="group"; Week[152].fixture[africa2].category="countries";          //
Week[152].fixture[africa2].match[1].team1=WCQualifier_af_group[5,4];  //5 groups of 5  
Week[152].fixture[africa2].match[1].team2=WCQualifier_af_group[5,1];
Week[152].fixture[africa2].match[2].team1=WCQualifier_af_group[5,3]; 
Week[152].fixture[africa2].match[2].team2=WCQualifier_af_group[5,2];
Week[152].fixture[africa2].match[3].team1=WCQualifier_af_group[1,5];  
Week[152].fixture[africa2].match[3].team2=WCQualifier_af_group[1,2];
Week[152].fixture[africa2].match[4].team1=WCQualifier_af_group[2,5]; 
Week[152].fixture[africa2].match[4].team2=WCQualifier_af_group[2,2];
Week[152].fixture[africa2].match[5].team1=WCQualifier_af_group[3,5]; 
Week[152].fixture[africa2].match[5].team2=WCQualifier_af_group[3,2];
Week[152].fixture[africa2].match[6].team1=WCQualifier_af_group[4,5]; 
Week[152].fixture[africa2].match[6].team2=WCQualifier_af_group[4,2];
/////////////world cup qualifier 153//////////////////////////////////////////////////////////////////////////////////
Week[153].fixture[3].colour=pinkish;Week[153].fixture[3].name="World Cup Qualifying";Week[153].fixture[3].kind="WCQoceania";
Week[153].fixture[3].type="group";Week[153].fixture[3].category="countries";                     //1 group of 8 no 2  1 left
Week[153].fixture[3].match[1].team1=WCQualifier_oc_group[1];
Week[153].fixture[3].match[1].team2=WCQualifier_oc_group[6];
Week[153].fixture[3].match[2].team1=WCQualifier_oc_group[2];
Week[153].fixture[3].match[2].team2=WCQualifier_oc_group[5];
Week[153].fixture[3].match[3].team1=WCQualifier_oc_group[3];
Week[153].fixture[3].match[3].team2=WCQualifier_oc_group[8];
Week[153].fixture[3].match[4].team1=WCQualifier_oc_group[4];
Week[153].fixture[3].match[4].team2=WCQualifier_oc_group[7];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[153].fixture[africa2].colour=pinkish;Week[153].fixture[africa2].name="World Cup Qualifying";Week[153].fixture[africa2].kind="WCQafrica";
Week[153].fixture[africa2].type="group"; Week[153].fixture[africa2].category="countries";          //
Week[153].fixture[africa2].match[1].team1=WCQualifier_af_group[5,5];  //5 groups of 5  
Week[153].fixture[africa2].match[1].team2=WCQualifier_af_group[5,2];
Week[153].fixture[africa2].match[2].team1=WCQualifier_af_group[1,5]; 
Week[153].fixture[africa2].match[2].team2=WCQualifier_af_group[1,3];
Week[153].fixture[africa2].match[3].team1=WCQualifier_af_group[2,5];  
Week[153].fixture[africa2].match[3].team2=WCQualifier_af_group[2,3];
Week[153].fixture[africa2].match[4].team1=WCQualifier_af_group[3,5]; 
Week[153].fixture[africa2].match[4].team2=WCQualifier_af_group[3,3];
Week[153].fixture[africa2].match[5].team1=WCQualifier_af_group[4,5]; 
Week[153].fixture[africa2].match[5].team2=WCQualifier_af_group[4,3];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[153].fixture[asia2].colour=pinkish;Week[153].fixture[asia2].name="World Cup Qualifying";Week[153].fixture[asia2].kind="WCQasia";
Week[153].fixture[asia2].type="group"; Week[153].fixture[asia2].category="countries";               //2nd round also 3,5 4,5 and 5,2 5,3 5,4
Week[153].fixture[asia2].match[1].team1=WCQualifier_as_group[1,5];  //4 groups of 5
Week[153].fixture[asia2].match[1].team2=WCQualifier_as_group[1,1]; 
Week[153].fixture[asia2].match[2].team1=WCQualifier_as_group[2,5];  
Week[153].fixture[asia2].match[2].team2=WCQualifier_as_group[2,1];
Week[153].fixture[asia2].match[3].team1=WCQualifier_as_group[3,5];  
Week[153].fixture[asia2].match[3].team2=WCQualifier_as_group[3,1];
Week[153].fixture[asia2].match[4].team1=WCQualifier_as_group[4,5];  
Week[153].fixture[asia2].match[4].team2=WCQualifier_as_group[4,1];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[153].fixture[northamerica2].colour=pinkish;Week[153].fixture[northamerica2].name="World Cup Qualifying";
Week[153].fixture[northamerica2].kind="WCQnorthamerica";Week[153].fixture[northamerica2].category="countries";     
Week[153].fixture[northamerica2].type="league";
Week[153].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[153].fixture[northamerica2].match[1].team2= WCQualifier_na_group[8];
Week[153].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[153].fixture[northamerica2].match[2].team2= WCQualifier_na_group[12];
Week[153].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[153].fixture[northamerica2].match[3].team2= WCQualifier_na_group[7];
Week[153].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[153].fixture[northamerica2].match[4].team2= WCQualifier_na_group[9];
Week[153].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[153].fixture[northamerica2].match[5].team2= WCQualifier_na_group[14];
Week[153].fixture[northamerica2].match[6].team1= WCQualifier_na_group[6];
Week[153].fixture[northamerica2].match[6].team2= WCQualifier_na_group[10];
Week[153].fixture[northamerica2].match[7].team1= WCQualifier_na_group[11];
Week[153].fixture[northamerica2].match[7].team2= WCQualifier_na_group[13];
//////////////world cup qualifiers/////////////////////////////////////////////////////////////////////////////////
Week[154].fixture[2].colour=pinkish;Week[154].fixture[2].name="World Cup Qualifying";Week[154].fixture[2].kind="WCQeurope";
Week[154].fixture[2].type="league";Week[154].fixture[2].colour=bluish; Week[154].fixture[2].category="countries";                 //7 groups of 6
Week[154].fixture[2].match[1].team1=WCQualifier_eu_group[4,3]; //second round
Week[154].fixture[2].match[1].team2=WCQualifier_eu_group[4,1];
Week[154].fixture[2].match[2].team1=WCQualifier_eu_group[4,5]; 
Week[154].fixture[2].match[2].team2=WCQualifier_eu_group[4,2];
Week[154].fixture[2].match[3].team1=WCQualifier_eu_group[4,6]; 
Week[154].fixture[2].match[3].team2=WCQualifier_eu_group[4,4];
Week[154].fixture[2].match[4].team1=WCQualifier_eu_group[5,3]; 
Week[154].fixture[2].match[4].team2=WCQualifier_eu_group[5,1];
Week[154].fixture[2].match[5].team1=WCQualifier_eu_group[5,5]; 
Week[154].fixture[2].match[5].team2=WCQualifier_eu_group[5,2];
Week[154].fixture[2].match[6].team1=WCQualifier_eu_group[5,6]; 
Week[154].fixture[2].match[6].team2=WCQualifier_eu_group[5,4];
Week[154].fixture[2].match[7].team1=WCQualifier_eu_group[6,3]; 
Week[154].fixture[2].match[7].team2=WCQualifier_eu_group[6,1];
Week[154].fixture[2].match[8].team1=WCQualifier_eu_group[6,5]; 
Week[154].fixture[2].match[8].team2=WCQualifier_eu_group[6,2];
Week[154].fixture[2].match[9].team1=WCQualifier_eu_group[6,6]; 
Week[154].fixture[2].match[9].team2=WCQualifier_eu_group[6,4];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[154].fixture[africa2].colour=pinkish;Week[154].fixture[africa2].name="World Cup Qualifying";Week[154].fixture[africa2].kind="WCQafrica";
Week[154].fixture[africa2].type="group"; Week[154].fixture[africa2].category="countries";          //
Week[154].fixture[africa2].match[1].team1=WCQualifier_af_group[5,5];  //5 groups of 5  
Week[154].fixture[africa2].match[1].team2=WCQualifier_af_group[5,3];
Week[154].fixture[africa2].match[2].team1=WCQualifier_af_group[1,5]; 
Week[154].fixture[africa2].match[2].team2=WCQualifier_af_group[1,4];
Week[154].fixture[africa2].match[3].team1=WCQualifier_af_group[2,5];  
Week[154].fixture[africa2].match[3].team2=WCQualifier_af_group[2,4];
Week[154].fixture[africa2].match[4].team1=WCQualifier_af_group[3,5]; 
Week[154].fixture[africa2].match[4].team2=WCQualifier_af_group[3,4];
Week[154].fixture[africa2].match[5].team1=WCQualifier_af_group[4,5]; 
Week[154].fixture[africa2].match[5].team2=WCQualifier_af_group[4,4];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[154].fixture[asia2].colour=pinkish;Week[154].fixture[asia2].name="World Cup Qualifying";Week[154].fixture[asia2].kind="WCQasia";
Week[154].fixture[asia2].type="group";Week[154].fixture[asia2].category="countries";               //2nd round also 3,5 4,5 and 5,2 5,3 5,4
Week[154].fixture[asia2].match[1].team1=WCQualifier_as_group[1,3];  //4 groups of 5
Week[154].fixture[asia2].match[1].team2=WCQualifier_as_group[1,5]; 
Week[154].fixture[asia2].match[2].team1=WCQualifier_as_group[2,3];  
Week[154].fixture[asia2].match[2].team2=WCQualifier_as_group[2,5];
Week[154].fixture[asia2].match[3].team1=WCQualifier_as_group[3,3];  
Week[154].fixture[asia2].match[3].team2=WCQualifier_as_group[3,5];
Week[154].fixture[asia2].match[4].team1=WCQualifier_as_group[4,3];  
Week[154].fixture[asia2].match[4].team2=WCQualifier_as_group[4,5];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[154].fixture[northamerica2].colour=pinkish;Week[154].fixture[northamerica2].name="World Cup Qualifying";
Week[154].fixture[northamerica2].kind="WCQnorthamerica";    
Week[154].fixture[northamerica2].type="league";Week[154].fixture[northamerica2].category="countries"; 
Week[154].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[154].fixture[northamerica2].match[1].team2= WCQualifier_na_group[10];
Week[154].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[154].fixture[northamerica2].match[2].team2= WCQualifier_na_group[13];
Week[154].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[154].fixture[northamerica2].match[3].team2= WCQualifier_na_group[9];
Week[154].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[154].fixture[northamerica2].match[4].team2= WCQualifier_na_group[15];
Week[154].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[154].fixture[northamerica2].match[5].team2= WCQualifier_na_group[16];
Week[154].fixture[northamerica2].match[6].team1= WCQualifier_na_group[6];
Week[154].fixture[northamerica2].match[6].team2= WCQualifier_na_group[7];
Week[154].fixture[northamerica2].match[7].team1= WCQualifier_na_group[8];
Week[154].fixture[northamerica2].match[7].team2= WCQualifier_na_group[11];
/////////////////world cup qualifier///156////////////////////////////////////////////////////////////////////////////////////
Week[156].fixture[2].colour=pinkish;Week[156].fixture[2].name="World Cup Qualifying";Week[156].fixture[2].kind="WCQeurope";
Week[156].fixture[2].type="league";Week[156].fixture[2].colour=bluish;Week[156].fixture[2].category="countries";                  //7 groups of 6
Week[156].fixture[2].match[1].team1=WCQualifier_eu_group[7,3]; //second round
Week[156].fixture[2].match[1].team2=WCQualifier_eu_group[7,1];
Week[156].fixture[2].match[2].team1=WCQualifier_eu_group[7,5]; 
Week[156].fixture[2].match[2].team2=WCQualifier_eu_group[7,2];
Week[156].fixture[2].match[3].team1=WCQualifier_eu_group[7,6]; 
Week[156].fixture[2].match[3].team2=WCQualifier_eu_group[7,4];
Week[156].fixture[2].match[4].team1=WCQualifier_eu_group[1,4]; //second last combi
Week[156].fixture[2].match[4].team2=WCQualifier_eu_group[1,1];
Week[156].fixture[2].match[5].team1=WCQualifier_eu_group[1,6]; 
Week[156].fixture[2].match[5].team2=WCQualifier_eu_group[1,2];
Week[156].fixture[2].match[6].team1=WCQualifier_eu_group[1,5]; 
Week[156].fixture[2].match[6].team2=WCQualifier_eu_group[1,3];
Week[156].fixture[2].match[7].team1=WCQualifier_eu_group[2,4]; 
Week[156].fixture[2].match[7].team2=WCQualifier_eu_group[2,1];
Week[156].fixture[2].match[8].team1=WCQualifier_eu_group[2,6]; 
Week[156].fixture[2].match[8].team2=WCQualifier_eu_group[2,2];
Week[156].fixture[2].match[9].team1=WCQualifier_eu_group[2,5]; 
Week[156].fixture[2].match[9].team2=WCQualifier_eu_group[2,3];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[156].fixture[africa2].colour=pinkish;Week[156].fixture[africa2].name="World Cup Qualifying";Week[156].fixture[africa2].kind="WCQafrica";
Week[156].fixture[africa2].type="group"; Week[156].fixture[africa2].category="countries";          //
Week[156].fixture[africa2].match[1].team1=WCQualifier_af_group[5,5];  //5 groups of 5  
Week[156].fixture[africa2].match[1].team2=WCQualifier_af_group[5,4];
Week[156].fixture[africa2].match[2].team1=WCQualifier_af_group[1,2]; 
Week[156].fixture[africa2].match[2].team2=WCQualifier_af_group[1,5];
Week[156].fixture[africa2].match[3].team1=WCQualifier_af_group[2,2];  
Week[156].fixture[africa2].match[3].team2=WCQualifier_af_group[2,5];
Week[156].fixture[africa2].match[4].team1=WCQualifier_af_group[3,2]; 
Week[156].fixture[africa2].match[4].team2=WCQualifier_af_group[3,5];
Week[156].fixture[africa2].match[5].team1=WCQualifier_af_group[4,2]; 
Week[156].fixture[africa2].match[5].team2=WCQualifier_af_group[4,5];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[156].fixture[asia2].colour=pinkish;Week[156].fixture[asia2].name="World Cup Qualifying";Week[156].fixture[asia2].kind="WCQasia";
Week[156].fixture[asia2].type="group"; Week[156].fixture[asia2].category="countries";               //2nd round also  4,5 and 5,2 5,3 5,4
Week[156].fixture[asia2].match[1].team1=WCQualifier_as_group[1,4];  //4 groups of 5
Week[156].fixture[asia2].match[1].team2=WCQualifier_as_group[1,5]; 
Week[156].fixture[asia2].match[2].team1=WCQualifier_as_group[2,4];  
Week[156].fixture[asia2].match[2].team2=WCQualifier_as_group[2,5];
Week[156].fixture[asia2].match[3].team1=WCQualifier_as_group[3,4];  
Week[156].fixture[asia2].match[3].team2=WCQualifier_as_group[3,5];
Week[156].fixture[asia2].match[4].team1=WCQualifier_as_group[4,4];  
Week[156].fixture[asia2].match[4].team2=WCQualifier_as_group[4,5];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[156].fixture[northamerica2].colour=pinkish;Week[156].fixture[northamerica2].name="World Cup Qualifying";
Week[156].fixture[northamerica2].kind="WCQnorthamerica";    
Week[156].fixture[northamerica2].type="league";Week[156].fixture[northamerica2].category="countries"; 
Week[156].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[156].fixture[northamerica2].match[1].team2= WCQualifier_na_group[13];
Week[156].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[156].fixture[northamerica2].match[2].team2= WCQualifier_na_group[14];
Week[156].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[156].fixture[northamerica2].match[3].team2= WCQualifier_na_group[11];
Week[156].fixture[northamerica2].match[4].team1= WCQualifier_na_group[4];
Week[156].fixture[northamerica2].match[4].team2= WCQualifier_na_group[10];
Week[156].fixture[northamerica2].match[5].team1= WCQualifier_na_group[5];
Week[156].fixture[northamerica2].match[5].team2= WCQualifier_na_group[8];
Week[156].fixture[northamerica2].match[6].team1= WCQualifier_na_group[6];
Week[156].fixture[northamerica2].match[6].team2= WCQualifier_na_group[15];
Week[156].fixture[northamerica2].match[7].team1= WCQualifier_na_group[7];
Week[156].fixture[northamerica2].match[7].team2= WCQualifier_na_group[12];
Week[156].fixture[northamerica2].match[8].team1= WCQualifier_na_group[9];
Week[156].fixture[northamerica2].match[8].team2= WCQualifier_na_group[16];
/////////////////world cup qualifier 161///////////////////////////////////////////////////////////////////////////////////////
Week[161].fixture[2].colour=pinkish;Week[161].fixture[2].name="World Cup Qualifying";Week[161].fixture[2].kind="WCQeurope";
Week[161].fixture[2].type="league";Week[161].fixture[2].colour=bluish;Week[161].fixture[2].category="countries";                  //7 groups of 6
Week[161].fixture[2].match[1].team1=WCQualifier_eu_group[3,4]; //second round
Week[161].fixture[2].match[1].team2=WCQualifier_eu_group[3,1];
Week[161].fixture[2].match[2].team1=WCQualifier_eu_group[3,6]; 
Week[161].fixture[2].match[2].team2=WCQualifier_eu_group[3,2];
Week[161].fixture[2].match[3].team1=WCQualifier_eu_group[3,5]; 
Week[161].fixture[2].match[3].team2=WCQualifier_eu_group[3,3];
Week[161].fixture[2].match[4].team1=WCQualifier_eu_group[4,4]; //second last combi
Week[161].fixture[2].match[4].team2=WCQualifier_eu_group[4,1];
Week[161].fixture[2].match[5].team1=WCQualifier_eu_group[4,6]; 
Week[161].fixture[2].match[5].team2=WCQualifier_eu_group[4,2];
Week[161].fixture[2].match[6].team1=WCQualifier_eu_group[4,5]; 
Week[161].fixture[2].match[6].team2=WCQualifier_eu_group[4,3];
Week[161].fixture[2].match[7].team1=WCQualifier_eu_group[5,4]; 
Week[161].fixture[2].match[7].team2=WCQualifier_eu_group[5,1];
Week[161].fixture[2].match[8].team1=WCQualifier_eu_group[5,6]; 
Week[161].fixture[2].match[8].team2=WCQualifier_eu_group[5,2];
Week[161].fixture[2].match[9].team1=WCQualifier_eu_group[5,5]; 
Week[161].fixture[2].match[9].team2=WCQualifier_eu_group[5,3];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[161].fixture[africa2].colour=pinkish;Week[161].fixture[africa2].name="World Cup Qualifying";Week[161].fixture[africa2].kind="WCQafrica";
Week[161].fixture[africa2].type="group"; Week[161].fixture[africa2].category="countries";          //
Week[161].fixture[africa2].match[1].team1=WCQualifier_af_group[5,2];  //5 groups of 5  
Week[161].fixture[africa2].match[1].team2=WCQualifier_af_group[5,5];
Week[161].fixture[africa2].match[2].team1=WCQualifier_af_group[1,3]; 
Week[161].fixture[africa2].match[2].team2=WCQualifier_af_group[1,5];
Week[161].fixture[africa2].match[3].team1=WCQualifier_af_group[2,3];  
Week[161].fixture[africa2].match[3].team2=WCQualifier_af_group[2,5];
Week[161].fixture[africa2].match[4].team1=WCQualifier_af_group[3,3]; 
Week[161].fixture[africa2].match[4].team2=WCQualifier_af_group[3,5];
Week[161].fixture[africa2].match[5].team1=WCQualifier_af_group[4,3]; 
Week[161].fixture[africa2].match[5].team2=WCQualifier_af_group[4,5];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[161].fixture[asia2].colour=pinkish;Week[161].fixture[asia2].name="World Cup Qualifying";Week[161].fixture[asia2].kind="WCQasia";
Week[161].fixture[asia2].type="group"; Week[161].fixture[asia2].category="countries";               //2nd round also  and 5,2 5,3 5,4
Week[161].fixture[asia2].match[1].team1=WCQualifier_as_group[1,5];  //4 groups of 5
Week[161].fixture[asia2].match[1].team2=WCQualifier_as_group[1,2]; 
Week[161].fixture[asia2].match[2].team1=WCQualifier_as_group[2,5];  
Week[161].fixture[asia2].match[2].team2=WCQualifier_as_group[2,2];
Week[161].fixture[asia2].match[3].team1=WCQualifier_as_group[3,5];  
Week[161].fixture[asia2].match[3].team2=WCQualifier_as_group[3,2];
Week[161].fixture[asia2].match[4].team1=WCQualifier_as_group[4,5];  
Week[161].fixture[asia2].match[4].team2=WCQualifier_as_group[4,2];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[161].fixture[northamerica2].colour=pinkish;Week[161].fixture[northamerica2].name="World Cup Qualifying";
Week[161].fixture[northamerica2].kind="WCQnorthamerica";    
Week[161].fixture[northamerica2].type="league";Week[161].fixture[northamerica2].category="countries"; 
Week[161].fixture[northamerica2].match[1].team1= WCQualifier_na_group[1];
Week[161].fixture[northamerica2].match[1].team2= WCQualifier_na_group[12];
Week[161].fixture[northamerica2].match[2].team1= WCQualifier_na_group[2];
Week[161].fixture[northamerica2].match[2].team2= WCQualifier_na_group[16];
Week[161].fixture[northamerica2].match[3].team1= WCQualifier_na_group[3];
Week[161].fixture[northamerica2].match[3].team2= WCQualifier_na_group[13];
Week[161].fixture[northamerica2].match[4].team1= WCQualifier_na_group[5];
Week[161].fixture[northamerica2].match[4].team2= WCQualifier_na_group[10];
Week[161].fixture[northamerica2].match[5].team1= WCQualifier_na_group[6];
Week[161].fixture[northamerica2].match[5].team2= WCQualifier_na_group[9];
Week[161].fixture[northamerica2].match[6].team1= WCQualifier_na_group[7];
Week[161].fixture[northamerica2].match[6].team2= WCQualifier_na_group[15];
Week[161].fixture[northamerica2].match[7].team1= WCQualifier_na_group[8];
Week[161].fixture[northamerica2].match[7].team2= WCQualifier_na_group[14];
////////////world cup qualifier 163///////////////////////////////////////////////////////////////////////////////////
Week[163].fixture[2].colour=pinkish;Week[163].fixture[2].name="World Cup Qualifying";Week[163].fixture[2].kind="WCQeurope";
Week[163].fixture[2].type="league";Week[163].fixture[2].colour=bluish;Week[163].fixture[2].category="countries";                  //7 groups of 6
Week[163].fixture[2].match[1].team1=WCQualifier_eu_group[6,4]; //second round
Week[163].fixture[2].match[1].team2=WCQualifier_eu_group[6,1];
Week[163].fixture[2].match[2].team1=WCQualifier_eu_group[6,6]; 
Week[163].fixture[2].match[2].team2=WCQualifier_eu_group[6,2];
Week[163].fixture[2].match[3].team1=WCQualifier_eu_group[6,5]; 
Week[163].fixture[2].match[3].team2=WCQualifier_eu_group[6,3];
Week[163].fixture[2].match[4].team1=WCQualifier_eu_group[7,4]; 
Week[163].fixture[2].match[4].team2=WCQualifier_eu_group[7,1];
Week[163].fixture[2].match[5].team1=WCQualifier_eu_group[7,6]; 
Week[163].fixture[2].match[5].team2=WCQualifier_eu_group[7,2];
Week[163].fixture[2].match[6].team1=WCQualifier_eu_group[7,5]; 
Week[163].fixture[2].match[6].team2=WCQualifier_eu_group[7,3];
Week[163].fixture[2].match[7].team1=WCQualifier_eu_group[1,5]; //last combi
Week[163].fixture[2].match[7].team2=WCQualifier_eu_group[1,1];
Week[163].fixture[2].match[8].team1=WCQualifier_eu_group[1,4]; 
Week[163].fixture[2].match[8].team2=WCQualifier_eu_group[1,2];
Week[163].fixture[2].match[9].team1=WCQualifier_eu_group[1,3]; 
Week[163].fixture[2].match[9].team2=WCQualifier_eu_group[1,6];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[163].fixture[africa2].colour=pinkish;Week[163].fixture[africa2].name="World Cup Qualifying";Week[163].fixture[africa2].kind="WCQafrica";
Week[163].fixture[africa2].type="group";  Week[163].fixture[africa2].category="countries";         //
Week[163].fixture[africa2].match[1].team1=WCQualifier_af_group[5,3];  //5 groups of 5  last
Week[163].fixture[africa2].match[1].team2=WCQualifier_af_group[5,5];
Week[163].fixture[africa2].match[2].team1=WCQualifier_af_group[1,4]; 
Week[163].fixture[africa2].match[2].team2=WCQualifier_af_group[1,5];
Week[163].fixture[africa2].match[3].team1=WCQualifier_af_group[2,4];  
Week[163].fixture[africa2].match[3].team2=WCQualifier_af_group[2,5];
Week[163].fixture[africa2].match[4].team1=WCQualifier_af_group[3,4]; 
Week[163].fixture[africa2].match[4].team2=WCQualifier_af_group[3,5];
Week[163].fixture[africa2].match[5].team1=WCQualifier_af_group[4,4]; 
Week[163].fixture[africa2].match[5].team2=WCQualifier_af_group[4,5];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[163].fixture[asia2].colour=pinkish;Week[163].fixture[asia2].name="World Cup Qualifying";Week[163].fixture[asia2].kind="WCQasia";
Week[163].fixture[asia2].type="group"; Week[163].fixture[asia2].category="countries";               //2nd round also  and  5,3 5,4
Week[163].fixture[asia2].match[1].team1=WCQualifier_as_group[1,5];  //4 groups of 5
Week[163].fixture[asia2].match[1].team2=WCQualifier_as_group[1,3]; 
Week[163].fixture[asia2].match[2].team1=WCQualifier_as_group[2,5];  
Week[163].fixture[asia2].match[2].team2=WCQualifier_as_group[2,3];
Week[163].fixture[asia2].match[3].team1=WCQualifier_as_group[3,5];  
Week[163].fixture[asia2].match[3].team2=WCQualifier_as_group[3,3];
Week[163].fixture[asia2].match[4].team1=WCQualifier_as_group[4,5];  
Week[163].fixture[asia2].match[4].team2=WCQualifier_as_group[4,3];
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[163].fixture[northamerica2].colour=pinkish;Week[163].fixture[northamerica2].name="World Cup Qualifying";
Week[163].fixture[northamerica2].kind="WCQnorthamerica";    
Week[163].fixture[northamerica2].type="league";Week[163].fixture[northamerica2].category="countries"; 
Week[163].fixture[northamerica2].match[1].team1= WCQualifier_na_group[3];
Week[163].fixture[northamerica2].match[1].team2= WCQualifier_na_group[16];
Week[163].fixture[northamerica2].match[2].team1= WCQualifier_na_group[8];
Week[163].fixture[northamerica2].match[2].team2= WCQualifier_na_group[13];
Week[163].fixture[northamerica2].match[3].team1= WCQualifier_na_group[10];
Week[163].fixture[northamerica2].match[3].team2= WCQualifier_na_group[15];
Week[163].fixture[northamerica2].match[4].team1= WCQualifier_na_group[11];
Week[163].fixture[northamerica2].match[4].team2= WCQualifier_na_group[14];  //bug fix
///////////////world cup quals 165/////////////////////////////////////////////////////////////////////////////////////////
Week[165].fixture[2].colour=pinkish;Week[165].fixture[2].name="World Cup Qualifying";Week[165].fixture[2].kind="WCQeurope";
Week[165].fixture[2].type="league";Week[165].fixture[2].colour=bluish;Week[165].fixture[2].category="countries";                  //7 groups of 6
Week[165].fixture[2].match[1].team1=WCQualifier_eu_group[2,5]; //second last
Week[165].fixture[2].match[1].team2=WCQualifier_eu_group[2,1];
Week[165].fixture[2].match[2].team1=WCQualifier_eu_group[2,4]; 
Week[165].fixture[2].match[2].team2=WCQualifier_eu_group[2,2];
Week[165].fixture[2].match[3].team1=WCQualifier_eu_group[2,3]; 
Week[165].fixture[2].match[3].team2=WCQualifier_eu_group[2,6];
Week[165].fixture[2].match[4].team1=WCQualifier_eu_group[3,5]; 
Week[165].fixture[2].match[4].team2=WCQualifier_eu_group[3,1];
Week[165].fixture[2].match[5].team1=WCQualifier_eu_group[3,4]; 
Week[165].fixture[2].match[5].team2=WCQualifier_eu_group[3,2];
Week[165].fixture[2].match[6].team1=WCQualifier_eu_group[3,3]; 
Week[165].fixture[2].match[6].team2=WCQualifier_eu_group[3,6];
Week[165].fixture[2].match[7].team1=WCQualifier_eu_group[4,5]; 
Week[165].fixture[2].match[7].team2=WCQualifier_eu_group[4,1];
Week[165].fixture[2].match[8].team1=WCQualifier_eu_group[4,4]; 
Week[165].fixture[2].match[8].team2=WCQualifier_eu_group[4,2];
Week[165].fixture[2].match[9].team1=WCQualifier_eu_group[4,3]; 
Week[165].fixture[2].match[9].team2=WCQualifier_eu_group[4,6];
///////////////////////////////////////////////////////////////////////////////////////////////
Week[165].fixture[africa2].colour=pinkish;Week[165].fixture[africa2].name="World Cup Qualifying";Week[165].fixture[africa2].kind="WCQafrica";
Week[165].fixture[africa2].type="group"; Week[165].fixture[africa2].category="countries";          //
Week[165].fixture[africa2].match[1].team1=WCQualifier_af_group[5,4];  //5 groups of 5  last
Week[165].fixture[africa2].match[1].team2=WCQualifier_af_group[5,5];Week[165].fixture[africa2].match[1].stage="last";
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[165].fixture[asia2].colour=pinkish;Week[165].fixture[asia2].name="World Cup Qualifying";Week[165].fixture[asia2].kind="WCQasia";
Week[165].fixture[asia2].type="group"; Week[165].fixture[asia2].category="countries";               //2nd round also  and  5,4
Week[165].fixture[asia2].match[1].team1=WCQualifier_as_group[1,5];  //4 groups of 5  last
Week[165].fixture[asia2].match[1].team2=WCQualifier_as_group[1,4]; 
Week[165].fixture[asia2].match[2].team1=WCQualifier_as_group[2,5];  
Week[165].fixture[asia2].match[2].team2=WCQualifier_as_group[2,4];
Week[165].fixture[asia2].match[3].team1=WCQualifier_as_group[3,5];  
Week[165].fixture[asia2].match[3].team2=WCQualifier_as_group[3,4];
Week[165].fixture[asia2].match[4].team1=WCQualifier_as_group[4,5];  
Week[165].fixture[asia2].match[4].team2=WCQualifier_as_group[4,4];Week[165].fixture[asia2].match[4].stage="last";
///////////////////////////////////////////////////////////////////////////////////////////////
Week[165].fixture[northamerica2].colour=pinkish;Week[165].fixture[northamerica2].name="World Cup Qualifying";
Week[165].fixture[northamerica2].kind="WCQnorthamerica";    
Week[165].fixture[northamerica2].type="league";Week[165].fixture[northamerica2].category="countries"; 
Week[165].fixture[northamerica2].match[1].team1= WCQualifier_na_group[9];
Week[165].fixture[northamerica2].match[1].team2= WCQualifier_na_group[15];
Week[165].fixture[northamerica2].match[2].team1= WCQualifier_na_group[12];
Week[165].fixture[northamerica2].match[2].team2= WCQualifier_na_group[16];
//////////////world cup quals/ 166/////////////////////////////////////////////////////////////////////////////////////////
Week[166].fixture[1].colour=pinkish;Week[166].fixture[1].name="World Cup Qualifying";Week[166].fixture[1].kind="WCQeurope";
Week[166].fixture[1].type="league";Week[166].fixture[1].colour=bluish; Week[166].fixture[1].category="countries";                 //7 groups of 6 fix
Week[166].fixture[1].match[1].team1=WCQualifier_eu_group[5,5]; // last
Week[166].fixture[1].match[1].team2=WCQualifier_eu_group[5,1];
Week[166].fixture[1].match[2].team1=WCQualifier_eu_group[5,4]; 
Week[166].fixture[1].match[2].team2=WCQualifier_eu_group[5,2];
Week[166].fixture[1].match[3].team1=WCQualifier_eu_group[5,3]; 
Week[166].fixture[1].match[3].team2=WCQualifier_eu_group[5,6];
Week[166].fixture[1].match[4].team1=WCQualifier_eu_group[6,5]; 
Week[166].fixture[1].match[4].team2=WCQualifier_eu_group[6,1];
Week[166].fixture[1].match[5].team1=WCQualifier_eu_group[6,4]; 
Week[166].fixture[1].match[5].team2=WCQualifier_eu_group[6,2];
Week[166].fixture[1].match[6].team1=WCQualifier_eu_group[6,3]; 
Week[166].fixture[1].match[6].team2=WCQualifier_eu_group[6,6];
Week[166].fixture[1].match[7].team1=WCQualifier_eu_group[7,5]; 
Week[166].fixture[1].match[7].team2=WCQualifier_eu_group[7,1];
Week[166].fixture[1].match[8].team1=WCQualifier_eu_group[7,4]; 
Week[166].fixture[1].match[8].team2=WCQualifier_eu_group[7,2];
Week[166].fixture[1].match[9].team1=WCQualifier_eu_group[7,3]; 
Week[166].fixture[1].match[9].team2=WCQualifier_eu_group[7,6];Week[166].fixture[1].match[9].stage="last";
////////////////////////////////////////////////////////////////////////////////////////////////////////
Week[166].fixture[northamerica2].colour=pinkish;Week[166].fixture[northamerica2].name="World Cup Qualifying";
Week[166].fixture[northamerica2].kind="WCQnorthamerica";  Week[166].fixture[northamerica2].category="countries";   
Week[166].fixture[northamerica2].type="league"; //last
Week[166].fixture[northamerica2].match[1].team1= WCQualifier_na_group[12];
Week[166].fixture[northamerica2].match[1].team2= WCQualifier_na_group[15];
Week[166].fixture[northamerica2].match[2].team1= WCQualifier_na_group[13];
Week[166].fixture[northamerica2].match[2].team2= WCQualifier_na_group[16];Week[166].fixture[northamerica2].match[2].stage="last";
/////////////world cup quals 167/////////////////////////////////////////////////////////////////////////////////
Week[167].fixture[2].colour=pinkish;Week[167].fixture[2].name="World Cup Qualifying";Week[167].fixture[2].kind="WCQsouthamerica";
Week[167].fixture[2].type="league"; Week[167].fixture[2].colour=greenish; Week[167].fixture[2].category="countries";                //1 groups of 10  no 5
Week[167].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[167].fixture[2].match[1].team2=WCQualifier_sa_group[7];
Week[167].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
Week[167].fixture[2].match[2].team2=WCQualifier_sa_group[10];
Week[167].fixture[2].match[3].team1=WCQualifier_sa_group[3]; 
Week[167].fixture[2].match[3].team2=WCQualifier_sa_group[6];
Week[167].fixture[2].match[4].team1=WCQualifier_sa_group[4]; 
Week[167].fixture[2].match[4].team2=WCQualifier_sa_group[8];
Week[167].fixture[2].match[5].team1=WCQualifier_sa_group[5]; 
Week[167].fixture[2].match[5].team2=WCQualifier_sa_group[9];  //FIXTURE CLASHING
/////////////world cup quals 169///////////////////////////////////////////////////////////////////////////////////////////
Week[169].fixture[2].colour=pinkish;Week[169].fixture[2].name="World Cup Qualifying";Week[169].fixture[2].kind="WCQoceania";
Week[169].fixture[2].type="group"; Week[169].fixture[2].category="countries"; Week[169].fixture[2].stage="group";                   //1 group of 8 no 2  last
Week[169].fixture[2].match[1].team1=WCQualifier_oc_group[1];
Week[169].fixture[2].match[1].team2=WCQualifier_oc_group[7];
Week[169].fixture[2].match[2].team1=WCQualifier_oc_group[2];
Week[169].fixture[2].match[2].team2=WCQualifier_oc_group[8];
Week[169].fixture[2].match[3].team1=WCQualifier_oc_group[3];
Week[169].fixture[2].match[3].team2=WCQualifier_oc_group[5];
Week[169].fixture[2].match[4].team1=WCQualifier_oc_group[4];
Week[169].fixture[2].match[4].team2=WCQualifier_oc_group[2];Week[169].fixture[2].match[4].stage="last";
//////////////wcq 171/////////////////////////////////////////////////////////////////////////////////
Week[171].fixture[2].colour=pinkish;Week[171].fixture[2].name="World Cup Qualifying";Week[171].fixture[2].kind="WCQsouthamerica";
Week[171].fixture[2].type="league"; Week[171].fixture[2].colour=greenish;Week[171].fixture[2].category="countries";                 //1 groups of 10  no 5
Week[171].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[171].fixture[2].match[1].team2=WCQualifier_sa_group[8];
Week[171].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
Week[171].fixture[2].match[2].team2=WCQualifier_sa_group[5];
Week[171].fixture[2].match[3].team1=WCQualifier_sa_group[3]; 
Week[171].fixture[2].match[3].team2=WCQualifier_sa_group[7];
Week[171].fixture[2].match[4].team1=WCQualifier_sa_group[4]; 
Week[171].fixture[2].match[4].team2=WCQualifier_sa_group[6];Week[171].fixture[2].stage="group";
/////////////////wcq 173///////////////////////////////////////////////////////////////////////////////////////
Week[173].fixture[2].colour=pinkish;Week[173].fixture[2].name="World Cup Qualifying";Week[173].fixture[2].kind="WCQsouthamerica";
Week[173].fixture[2].type="league"; Week[173].fixture[2].colour=greenish; Week[173].fixture[2].category="countries";                //1 groups of 10  no 5
Week[173].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[173].fixture[2].match[1].team2=WCQualifier_sa_group[10];
Week[173].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
Week[173].fixture[2].match[2].team2=WCQualifier_sa_group[6];
Week[173].fixture[2].match[3].team1=WCQualifier_sa_group[4]; 
Week[173].fixture[2].match[3].team2=WCQualifier_sa_group[5];
Week[173].fixture[2].match[4].team1=WCQualifier_sa_group[8]; 
Week[173].fixture[2].match[4].team2=WCQualifier_sa_group[9];
/////////////wcq 179///////////////////////////////////////////////////////////////////////////////////////////
Week[179].fixture[2].colour=pinkish;Week[179].fixture[2].name="World Cup Qualifying";Week[179].fixture[2].kind="WCQsouthamerica";
Week[179].fixture[2].type="league"; Week[179].fixture[2].colour=greenish;Week[179].fixture[2].category="countries";                 //1 groups of 10  no 5
Week[179].fixture[2].match[1].team1=WCQualifier_sa_group[1]; //group 1 team 1
Week[179].fixture[2].match[1].team2=WCQualifier_sa_group[9];
Week[179].fixture[2].match[2].team1=WCQualifier_sa_group[2]; 
Week[179].fixture[2].match[2].team2=WCQualifier_sa_group[8];
Week[179].fixture[2].match[3].team1=WCQualifier_sa_group[5]; 
Week[179].fixture[2].match[3].team2=WCQualifier_sa_group[10];
///////////////wcq 182/////////////////////////////////////////////////////////////////////////////////////////
Week[182].fixture[1].colour=pinkish;Week[182].fixture[1].name="World Cup Qualifying";Week[182].fixture[1].kind="WCQsouthamerica";
Week[182].fixture[1].type="league"; Week[182].fixture[1].colour=greenish;Week[182].fixture[1].category="countries";                 //1 groups of 10  no 5
Week[182].fixture[1].match[1].team1=WCQualifier_sa_group[3]; //group 1 team 1
Week[182].fixture[1].match[1].team2=WCQualifier_sa_group[9];
Week[182].fixture[1].match[2].team1=WCQualifier_sa_group[4]; 
Week[182].fixture[1].match[2].team2=WCQualifier_sa_group[10];
/////////////////wcq 182//////////////////////////////////////////////////////////////////////////////
Week[182].fixture[2].colour=pinkish;Week[182].fixture[2].name="World Cup Qualifying";Week[182].fixture[2].kind="WCQsouthamerica";
Week[182].fixture[2].type="league"; Week[182].fixture[2].colour=greenish;Week[182].fixture[2].category="countries";                 //1 groups of 10  no 5
Week[182].fixture[2].match[1].team1=WCQualifier_sa_group[3]; //group 1 team 1
Week[182].fixture[2].match[1].team2=WCQualifier_sa_group[10];
///////////////wcq 186/////////////////////////////////////////////////////////////////////////////////////////
Week[186].fixture[2].colour=pinkish;Week[186].fixture[2].name="World Cup Qualifying";Week[186].fixture[2].kind="WCQsouthamerica";
Week[186].fixture[2].type="league"; Week[186].fixture[2].colour=greenish; Week[186].fixture[2].category="countries";                //1 groups of 10  no 5
Week[186].fixture[2].match[1].team1=WCQualifier_sa_group[7]; //group 1 team 1  
Week[186].fixture[2].match[1].team2=WCQualifier_sa_group[10];Week[186].fixture[2].match[1].stage="last";
////////////////////world cup///////////////////////////////////////////////////////////////////////////
Week[188].fixture[1].colour=greenish;Week[188].fixture[1].name="World Cup";Week[188].fixture[1].kind="worldcup";
Week[188].fixture[1].type="league";Week[188].fixture[1].stage="group";Week[188].fixture[1].category="countries";   // 8 groups of 32
Week[188].fixture[1].match[1].team1=worldcup_group[1,1];
Week[188].fixture[1].match[1].team2=worldcup_group[1,2];
Week[188].fixture[1].match[2].team1=worldcup_group[1,3];
Week[188].fixture[1].match[2].team2=worldcup_group[1,4];
Week[188].fixture[1].match[3].team1=worldcup_group[2,1];
Week[188].fixture[1].match[3].team2=worldcup_group[2,2];
Week[188].fixture[1].match[4].team1=worldcup_group[2,3];
Week[188].fixture[1].match[4].team2=worldcup_group[2,4];
Week[188].fixture[1].match[5].team1=worldcup_group[3,1];
Week[188].fixture[1].match[5].team2=worldcup_group[3,2];
Week[188].fixture[1].match[6].team1=worldcup_group[3,3];
Week[188].fixture[1].match[6].team2=worldcup_group[3,4];
Week[188].fixture[1].match[7].team1=worldcup_group[4,1];
Week[188].fixture[1].match[7].team2=worldcup_group[4,2];
Week[188].fixture[1].match[8].team1=worldcup_group[4,3];
Week[188].fixture[1].match[8].team2=worldcup_group[4,4];
////////////////world cup////////////////////////////////////////////////////////////////////////////////////////
Week[188].fixture[2].colour=greenish;Week[188].fixture[2].name="World Cup";Week[188].fixture[2].kind="worldcup";
Week[188].fixture[2].type="league";Week[188].fixture[2].stage="group";Week[188].fixture[2].category="countries";   // 8 groups of 32
Week[188].fixture[2].match[1].team1=worldcup_group[5,1];
Week[188].fixture[2].match[1].team2=worldcup_group[5,2];
Week[188].fixture[2].match[2].team1=worldcup_group[5,3];
Week[188].fixture[2].match[2].team2=worldcup_group[5,4];
Week[188].fixture[2].match[3].team1=worldcup_group[6,1];
Week[188].fixture[2].match[3].team2=worldcup_group[6,2];
Week[188].fixture[2].match[4].team1=worldcup_group[6,3];
Week[188].fixture[2].match[4].team2=worldcup_group[6,4];
Week[188].fixture[2].match[5].team1=worldcup_group[7,1];
Week[188].fixture[2].match[5].team2=worldcup_group[7,2];
Week[188].fixture[2].match[6].team1=worldcup_group[7,3];
Week[188].fixture[2].match[6].team2=worldcup_group[7,4];
Week[188].fixture[2].match[7].team1=worldcup_group[8,1];
Week[188].fixture[2].match[7].team2=worldcup_group[8,2];
Week[188].fixture[2].match[8].team1=worldcup_group[8,3];
Week[188].fixture[2].match[8].team2=worldcup_group[8,4];
////////////////world cup////////////////////////////////////////////////////////////////////////////////////////
Week[188].fixture[3].colour=greenish;Week[188].fixture[3].name="World Cup";Week[188].fixture[3].kind="worldcup";
Week[188].fixture[3].type="league";Week[188].fixture[3].stage="group";Week[188].fixture[3].category="countries";   // 8 groups of 32
Week[188].fixture[3].match[1].team1=worldcup_group[1,1];
Week[188].fixture[3].match[1].team2=worldcup_group[1,3];
Week[188].fixture[3].match[2].team1=worldcup_group[1,2];
Week[188].fixture[3].match[2].team2=worldcup_group[1,4];
Week[188].fixture[3].match[3].team1=worldcup_group[2,1];
Week[188].fixture[3].match[3].team2=worldcup_group[2,3];
Week[188].fixture[3].match[4].team1=worldcup_group[2,2];
Week[188].fixture[3].match[4].team2=worldcup_group[2,4];
Week[188].fixture[3].match[5].team1=worldcup_group[3,1];
Week[188].fixture[3].match[5].team2=worldcup_group[3,3];
Week[188].fixture[3].match[6].team1=worldcup_group[3,2];
Week[188].fixture[3].match[6].team2=worldcup_group[3,4];
Week[188].fixture[3].match[7].team1=worldcup_group[4,1];
Week[188].fixture[3].match[7].team2=worldcup_group[4,3];
Week[188].fixture[3].match[8].team1=worldcup_group[4,2];
Week[188].fixture[3].match[8].team2=worldcup_group[4,4];
////////////////world cup///////////////////////////////////////////////////////////////////////////////
Week[189].fixture[1].colour=greenish;Week[189].fixture[1].name="World Cup";Week[189].fixture[1].kind="worldcup";
Week[189].fixture[1].type="league";Week[189].fixture[1].stage="group";Week[189].fixture[1].category="countries";   // 8 groups of 32
Week[189].fixture[1].match[1].team1=worldcup_group[5,1];
Week[189].fixture[1].match[1].team2=worldcup_group[5,3];
Week[189].fixture[1].match[2].team1=worldcup_group[5,2];
Week[189].fixture[1].match[2].team2=worldcup_group[5,4];
Week[189].fixture[1].match[3].team1=worldcup_group[6,1];
Week[189].fixture[1].match[3].team2=worldcup_group[6,3];
Week[189].fixture[1].match[4].team1=worldcup_group[6,2];
Week[189].fixture[1].match[4].team2=worldcup_group[6,4];
Week[189].fixture[1].match[5].team1=worldcup_group[7,1];
Week[189].fixture[1].match[5].team2=worldcup_group[7,3];
Week[189].fixture[1].match[6].team1=worldcup_group[7,2];
Week[189].fixture[1].match[6].team2=worldcup_group[7,4];
Week[189].fixture[1].match[7].team1=worldcup_group[8,1];
Week[189].fixture[1].match[7].team2=worldcup_group[8,3];
Week[189].fixture[1].match[8].team1=worldcup_group[8,2];
Week[189].fixture[1].match[8].team2=worldcup_group[8,4];
////////////////world cup////////////////////////////////////////////////////////////////////////////////////////
Week[189].fixture[2].colour=greenish;Week[189].fixture[2].name="World Cup";Week[189].fixture[2].kind="worldcup";
Week[189].fixture[2].type="league";Week[189].fixture[2].stage="group";Week[189].fixture[2].category="countries";   // 8 groups of 32
Week[189].fixture[2].match[1].team1=worldcup_group[1,1];
Week[189].fixture[2].match[1].team2=worldcup_group[1,4];
Week[189].fixture[2].match[2].team1=worldcup_group[1,2];
Week[189].fixture[2].match[2].team2=worldcup_group[1,3];
Week[189].fixture[2].match[3].team1=worldcup_group[2,1];
Week[189].fixture[2].match[3].team2=worldcup_group[2,4];
Week[189].fixture[2].match[4].team1=worldcup_group[2,2];
Week[189].fixture[2].match[4].team2=worldcup_group[2,3];
Week[189].fixture[2].match[5].team1=worldcup_group[3,1];
Week[189].fixture[2].match[5].team2=worldcup_group[3,4];
Week[189].fixture[2].match[6].team1=worldcup_group[3,2];
Week[189].fixture[2].match[6].team2=worldcup_group[3,3];
Week[189].fixture[2].match[7].team1=worldcup_group[4,1];
Week[189].fixture[2].match[7].team2=worldcup_group[4,4];
Week[189].fixture[2].match[8].team1=worldcup_group[4,2];
Week[189].fixture[2].match[8].team2=worldcup_group[4,3];
/////////////////world cuo//////////////////////////////////////////////////////////////////////////////
Week[189].fixture[3].colour=greenish;Week[189].fixture[3].name="World Cup";Week[189].fixture[3].kind="worldcup";
Week[189].fixture[3].type="league";Week[189].fixture[3].stage="group";Week[189].fixture[3].category="countries";   // 8 groups of 32
Week[189].fixture[3].match[1].team1=worldcup_group[5,1];
Week[189].fixture[3].match[1].team2=worldcup_group[5,4];
Week[189].fixture[3].match[2].team1=worldcup_group[5,2];
Week[189].fixture[3].match[2].team2=worldcup_group[5,3];
Week[189].fixture[3].match[3].team1=worldcup_group[6,1];
Week[189].fixture[3].match[3].team2=worldcup_group[6,4];
Week[189].fixture[3].match[4].team1=worldcup_group[6,2];
Week[189].fixture[3].match[4].team2=worldcup_group[6,3];
Week[189].fixture[3].match[5].team1=worldcup_group[7,1];
Week[189].fixture[3].match[5].team2=worldcup_group[7,4];
Week[189].fixture[3].match[6].team1=worldcup_group[7,2];
Week[189].fixture[3].match[6].team2=worldcup_group[7,3];
Week[189].fixture[3].match[7].team1=worldcup_group[8,1];
Week[189].fixture[3].match[7].team2=worldcup_group[8,4];
Week[189].fixture[3].match[8].team1=worldcup_group[8,2];
Week[189].fixture[3].match[8].team2=worldcup_group[8,3];Week[189].fixture[3].match[8].stage="last";
//////////////////world cip round of 18//////////////////////////////////////////////////////////////////////////////////////
Week[190].fixture[1].colour=greenish;Week[190].fixture[1].name="World Cup round of 16";Week[190].fixture[1].kind="worldcup";
Week[190].fixture[1].type="knockout";Week[190].fixture[1].stage="roundof16"; Week[190].fixture[1].category="countries";  
Week[190].fixture[1].match[1].team1=worldcup_round16[1,1];
Week[190].fixture[1].match[1].team2=worldcup_round16[1,2];
Week[190].fixture[1].match[1].position=1; Week[190].fixture[1].match[1].group=1;
Week[190].fixture[1].match[2].team1=worldcup_round16[2,1];
Week[190].fixture[1].match[2].team2=worldcup_round16[2,2];
Week[190].fixture[1].match[2].position=2; Week[190].fixture[1].match[2].group=1;
Week[190].fixture[1].match[3].team1=worldcup_round16[3,1];
Week[190].fixture[1].match[3].team2=worldcup_round16[3,2];
Week[190].fixture[1].match[3].position=1; Week[190].fixture[1].match[3].group=2;
Week[190].fixture[1].match[4].team1=worldcup_round16[4,1];
Week[190].fixture[1].match[4].team2=worldcup_round16[4,2];
Week[190].fixture[1].match[4].position=2; Week[190].fixture[1].match[4].group=2;
Week[190].fixture[1].match[5].team1=worldcup_round16[5,1];
Week[190].fixture[1].match[5].team2=worldcup_round16[5,2];
Week[190].fixture[1].match[5].position=1; Week[190].fixture[1].match[5].group=3;
Week[190].fixture[1].match[6].team1=worldcup_round16[6,1];
Week[190].fixture[1].match[6].team2=worldcup_round16[6,2];
Week[190].fixture[1].match[6].position=2; Week[190].fixture[1].match[6].group=3;
Week[190].fixture[1].match[7].team1=worldcup_round16[7,1];
Week[190].fixture[1].match[7].team2=worldcup_round16[7,2];
Week[190].fixture[1].match[7].position=1; Week[190].fixture[1].match[7].group=4;
Week[190].fixture[1].match[8].team1=worldcup_round16[8,1];
Week[190].fixture[1].match[8].team2=worldcup_round16[8,2];
Week[190].fixture[1].match[8].position=2; Week[190].fixture[1].match[8].group=4;
////////////////world cup quarter final////////////////////////////////////////////////////////////////////////////////////////
Week[190].fixture[2].colour=greenish;Week[190].fixture[2].name="World Cup quarter final";Week[190].fixture[2].kind="worldcup";
Week[190].fixture[2].type="knockout";Week[190].fixture[2].stage="quarterfinal";  Week[190].fixture[2].category="countries"; 
Week[190].fixture[2].match[1].team1=worldcup_quarterfinal[1,1];
Week[190].fixture[2].match[1].team2=worldcup_quarterfinal[1,2];
Week[190].fixture[2].match[1].position=1; Week[190].fixture[2].match[1].group=1;
Week[190].fixture[2].match[2].team1=worldcup_quarterfinal[2,1];
Week[190].fixture[2].match[2].team2=worldcup_quarterfinal[2,2];
Week[190].fixture[2].match[2].position=2; Week[190].fixture[2].match[2].group=1;
Week[190].fixture[2].match[3].team1=worldcup_quarterfinal[3,1];
Week[190].fixture[2].match[3].team2=worldcup_quarterfinal[3,2];
Week[190].fixture[2].match[3].position=1; Week[190].fixture[2].match[3].group=2;
Week[190].fixture[2].match[4].team1=worldcup_quarterfinal[4,1];
Week[190].fixture[2].match[4].team2=worldcup_quarterfinal[4,2];
Week[190].fixture[2].match[4].position=2; Week[190].fixture[2].match[4].group=2;  //error fix
//////////////////world cup semi final/////////////////////////////////////////////////////////////////////////////
Week[191].fixture[1].colour=greenish;Week[191].fixture[1].name="World Cup semi final";Week[191].fixture[1].kind="worldcup";
Week[191].fixture[1].type="knockout";Week[191].fixture[1].stage="semifinal"; Week[191].fixture[1].category="countries";  
Week[191].fixture[1].match[1].team1=worldcup_semifinal[1,1];
Week[191].fixture[1].match[1].team2=worldcup_semifinal[1,2];
Week[191].fixture[1].match[1].position=1; 
Week[191].fixture[1].match[2].team1=worldcup_semifinal[2,1];
Week[191].fixture[1].match[2].team2=worldcup_semifinal[2,2];
Week[191].fixture[1].match[2].position=2; 
//////////////////world cup 3r place//////////////////////////////////////////////////////////////////////////////////////
Week[191].fixture[2].colour=greenish;Week[191].fixture[2].name="World Cup 3rd place";Week[191].fixture[2].kind="worldcup";
Week[191].fixture[2].type="knockout";Week[191].fixture[2].stage="3rdplace";  Week[191].fixture[2].category="countries"; 
Week[191].fixture[2].match[1].team1=worldcup_third[1];
Week[191].fixture[2].match[1].team2=worldcup_third[2];
////////////////world cup final////////////////////////////////////////////////////////////////////////////////////////
Week[192].fixture[1].colour=greenish;Week[192].fixture[1].name="World Cup final";Week[192].fixture[1].kind="worldcup";
Week[192].fixture[1].type="knockout";Week[192].fixture[1].stage="final"; Week[192].fixture[1].category="countries";  
Week[192].fixture[1].match[1].team1=worldcup_final[1];      
Week[192].fixture[1].match[1].team2=worldcup_final[2]; global.inited=true; global.load=false; global.reinit=true;
///////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
}
///////////////////////////////////////////////////////////////////////////////////////////////
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


void  Update (){
	if(timeout<3)
		timeout+=1;
	if(timeout==2){   //NOTE: all logo and text loading has to be delayed at start
		if(Application.loadedLevelName=="dashboard" && global.frommatch==false){            //set text and colour of club and manager name on dashboard
			TeamName.GetComponent<Text>().text=global.team; 

			ManagerName.GetComponent<Text>().text="Manager: "+global.managername;
			if(global.category=="clubs")
			{ TeamName.GetComponent<Text>().color=clubtextcolour[global.id];
				ManagerName.GetComponent<Text>().color=clubtextcolour[global.id];
				Money.GetComponent<Text>().text="$"+money[global.id].ToString();
				colour.GetComponent<Image>().color=clubmaincolour[global.id];}
			else
			{Money.SetActive(false);
				colour.GetComponent<Image>().color=maincolour[global.id];
				TeamName.GetComponent<Text>().color=textcolour[global.id];
				ManagerName.GetComponent<Text>().color=textcolour[global.id];}
			Dates.GetComponent<Text>().text=week.ToString()+" "+month+" "+year.ToString(); string expectations="";
			if(global.inited==false){
				if(global.load==false){
					if(global.category=="clubs")
					{if(clubreputation[global.id]>187)
						{ expectations="win the league this season.";}
						if(clubreputation[global.id]>178 && clubreputation[global.id]<=187)
							expectations="challenge for the league title this season.";
						if(clubreputation[global.id]>168 && clubreputation[global.id]<=178)
							expectations="qualify for the champions league this season.";
						if(clubreputation[global.id]>160 && clubreputation[global.id]<=168)
							expectations="qualify for european competition this season.";
						if(clubreputation[global.id]>150 && clubreputation[global.id]<=160)
							expectations="finish in the top half of the league table.";
						if(clubreputation[global.id]<=150)
							expectations="avoid relegation.";
					}
					else
					{if(reputation[global.id]>187 || countryname[global.id]=="Brazil")
						expectations="win the world cup.";
					else if(reputation[global.id]>178 && reputation[global.id]<=187)
						expectations="reach the semi final of the world cup.";
					else if(reputation[global.id]>160 && reputation[global.id]<=178)
						expectations="qualify for the world cup.";
					if(reputation[global.id]>140 && reputation[global.id]<=160)
						expectations="make a good performance of the team in competitions.";
					if(reputation[global.id]<=140 )
						expectations="uphold the country's pride during competitions.";
				}
					news="Welcome "+global.managername+". The board would like to welcome you as manager of "+global.team+". The board expects that "+
						"you "+expectations;
				}//load
				if(newspaper==null)
					newspaper=GameObject.Find("Canvas").transform.Find("Newspaper").gameObject;
				newspaper.SetActive(true);
				newspaper.GetComponent<Text>().text=news;
				//if(global.load==false)         // if loading game, don't init
				Init();  //big fix of preventing initting when already loaded/started game
				//UPDATE  I REALIZED YOU HAVE TO REINIT THIS
			}//not inited
		}//db
		//if(Application.loadedLevelName=="init" && global.load)        //alternative to init from init room when loading game
		//Init();

	}//timeout 1


	/////////////////
	if(global.sacked==false){
		if(global.toldsuccess==false && global.matcheswon>=10 && global.matcheswon/(global.matcheslost+1)>=2){  //prompt of ten matches won
			global.toldsuccess=true;
			news=global.managername+" enjoying life at "+global.team+". it may still be early days but "+global.managername+" has "+
				"already captivated the hearts of fans by winning more than 10 matches, and soon they will expect more success.";
		}//

		if(global.boardopinioned==false&&(realweek==11|| realweek==23 || realweek==35 || realweek==47 || realweek==59 || realweek==71 || realweek==83 || realweek==95
			|| realweek==107 || realweek==119 || realweek==121 || realweek==133 || realweek==145 || realweek==157 || realweek==170 || realweek==181 )&& realfixture==4){
			Message.SetActive(true); var rep=0; int matcheslost;
			if(global.category=="clubs"){rep=clubreputation[global.id];}else{rep=reputation[global.id];}
			if(rep>=175){  matcheslost=global.matcheslost+1;
				if(global.matcheswon/(matcheslost)>=2)
					MessageText.GetComponent<Text>().text="To summarize, the board is satisfied with your management of the team. Keep it up.";
				if(global.matcheswon/(matcheslost)<2 && global.matcheswon/(global.matcheslost+1)>=0.6f)
					MessageText.GetComponent<Text>().text="To summarize, the board feels you should be performing better than this, They suggest you pull up your socks.";
				if(global.matcheswon/(matcheslost)<0.6f )
					MessageText.GetComponent<Text>().text="To summarize, the board are disappointed with your management of the team. They demand improvement.";
			}//rep
			if(rep<175 && rep>=145){ matcheslost=global.matcheslost+1;
				if(global.matcheswon/(matcheslost)>=1)
					MessageText.GetComponent<Text>().text="To summarize, the board is satisfied with your management of the team. Keep it up.";
				if(global.matcheswon/(matcheslost)<1 && global.matcheswon/(global.matcheslost+1)>=0.5f)
					MessageText.GetComponent<Text>().text="To summarize, the board feels you should be performing better than this, They suggest you pull up your socks.";
				if(global.matcheswon/(matcheslost)<0.5f )
					MessageText.GetComponent<Text>().text="To summarize, the board are disappointed with your management of the team. They demand improvement.";
			}//rep
			if(rep<145){ matcheslost=global.matcheslost+1;
				if(global.matcheswon/(matcheslost)>=0.6f)
					MessageText.GetComponent<Text>().text="To summarize, the board is pleased with your management of the team. Keep it up.";
				if(global.matcheswon/(matcheslost)<0.5f && global.matcheswon/(global.matcheslost+1)>=0.3f)
					MessageText.GetComponent<Text>().text="To summarize, the board feels you should be performing better than this, They suggest you pull up your socks.";
				if(global.matcheswon/(matcheslost)<0.3f )
					MessageText.GetComponent<Text>().text="To summarize, the board are disappointed with your management of the team. They demand improvement.";
			}//rep
			global.boardopinioned=true;                
		}

		if((realweek==15|| realweek==27 || realweek==39 || realweek==51 || realweek==63 || realweek==75 || realweek==87 || realweek==99
			|| realweek==111 || realweek==123 || realweek==125 || realweek==137 || realweek==149 || realweek==161 || realweek==173 || realweek==185)&&
			realfixture==4)
			global.boardopinioned=false;

	}//not sacked

}//

void  OnLevelWasLoaded (){

	if(Application.loadedLevelName=="intro")
		Destroy(gameObject);
	timeout=0;
	if(Application.loadedLevelName=="dashboard"){            //set text and colour of club and manager name on dashboard
		Message=GameObject.Find("Canvas").transform.Find("Message").gameObject;
		MessageText=GameObject.Find("Canvas").transform.Find("Message").transform.Find("Text").gameObject;
		if(TeamName==null){
			TeamName=GameObject.Find("Canvas").transform.Find("teamname").gameObject;
			ManagerName=GameObject.Find("Canvas").transform.Find("ManagerName").gameObject; 
			//TeamName=GameObject.Find("Canvas").Find("team");
			Money=GameObject.Find("Canvas").transform.Find("money").gameObject; 
			if(global.category=="countries")
				Money.SetActive(false);
			Dates=GameObject.Find("Canvas").transform.Find("dates").gameObject;
			colour=GameObject.Find("Canvas").transform.Find("Colour").gameObject; 
			Winner=GameObject.Find("Canvas").transform.Find("Winner").gameObject;
			if(Winnertext==null)
				Winnertext=GameObject.Find("Canvas").transform.Find("Winner").Find("Text").gameObject; 
			fixturename=GameObject.Find("Canvas").transform.Find("fixturename").gameObject;
			fixturecolour=GameObject.Find("Canvas").transform.Find("fixturecolour").gameObject;
			next=GameObject.Find("Canvas").transform.Find("Next").gameObject;
			loading=GameObject.Find("Canvas").transform.Find("Loading").gameObject;
			//newspaper=GameObject.Find("News");
			fixture1=GameObject.Find("Canvas").transform.Find("fixture1").gameObject;
			fixture2=GameObject.Find("Canvas").transform.Find("fixture2").gameObject;
			fixture3=GameObject.Find("Canvas").transform.Find("fixture3").gameObject;
			fixture4=GameObject.Find("Canvas").transform.Find("fixture4").gameObject;
			fixture5=GameObject.Find("Canvas").transform.Find("fixture5").gameObject;
			fixture6=GameObject.Find("Canvas").transform.Find("fixture6").gameObject;
			fixture7=GameObject.Find("Canvas").transform.Find("fixture7").gameObject;
			fixture8=GameObject.Find("Canvas").transform.Find("fixture8").gameObject;
			fixture9=GameObject.Find("Canvas").transform.Find("fixture9").gameObject;
			newspaper=GameObject.Find("Canvas").transform.Find("Newspaper").gameObject;}  

		TeamName.GetComponent<Text>().text=global.team;          
		ManagerName.GetComponent<Text>().text="Manager: "+global.managername;
		if(global.category=="clubs")
		{
			Money.GetComponent<Text>().text=money[global.id].ToString();
			colour.GetComponent<Image>().color=clubmaincolour[global.id];}
		else
		{Money.SetActive(false);
			colour.GetComponent<Image>().color=maincolour[global.id];}
		Dates.GetComponent<Text>().text=week.ToString()+" "+month+" "+year.ToString();

		if(global.frommatch==true)////////////////////////////vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv/////returned from match
		{ ResetConditions(); timetosave=true;
			global.minutes=0;global.seconds=0;
			SetDashboard();//update dashboard to display current state
			if(global.team1goals==global.team2goals)//draw
			{global.team1points=1;global.team2points=1;}
			if(global.team1goals>global.team2goals)//p1wins
			{global.team1points=3;global.team2points=0;
				if(global.team1==global.id)global.matcheswon++;
				else
					global.matcheslost++;}
			if(global.team1goals<global.team2goals)//p2wins
			{global.team1points=0;global.team2points=3;
				if(global.team2==global.id)global.matcheswon++;
				else
					global.matcheslost++;}

			GameObject.Find("Canvas").transform.Find(global.fixture).transform.Find("score1").GetComponent<Text>().text=global.team1goals.ToString();//also set for match engine
			GameObject.Find("Canvas").transform.Find(global.fixture).transform.Find("score2").GetComponent<Text>().text=global.team2goals.ToString();

			FixResults(global.team1,global.team2,global.realfixture,global.i);//fix all results to league

			if(global.i==1)
				match1played=true;
			if(global.i==2)
				match2played=true;
			if(global.i==3)
				match3played=true;
			if(global.i==4)
				match4played=true;
			if(global.i==5)
				match5played=true;
			if(global.i==6)
				match6played=true;
			if(global.i==7)
				match7played=true;
			if(global.i==8)
				match8played=true;
			if(global.i==9)
			{match9played=true;state="advance";}

			global.fixture=null;
			global.i=0;
			global.realfixture=0;
			global.issecondleg=false;
			global.isaggregate=false;
			global.isknockout=false;
			global.Event="";
			global.team1aggregate=0;
			global.team2aggregate=0;
			global.awaygoals=0;
			global.homeawaygoals=0;
			global.frommatch=false;
			global.p1goals=0;global.p2goals=0;
			SaveOwnPlayers();
		}
	}//db

}//on level was loaded

void  AdvanceTime (){  //next button
	if(state=="advance")   // states-> advance advances time, news opens news tab and shows any news on news variable fixture shows ficture
	{if(timetosave){Save();timetosave=false;}
		realfixture++;  HideFixtures(); 
		match1played=false;
		match2played=false;
		match3played=false;
		match4played=false;
		match5played=false;
		match6played=false;
		match7played=false;
		match8played=false;
		match9played=false;
		if(Dates==null)
			Dates=GameObject.Find("Canvas").transform.Find("dates").gameObject;
		Dates.GetComponent<Text>().text=week.ToString()+" "+month+" "+year.ToString();
		if(realfixture==5){
			if(Week[realweek].fixture[5].match[1].team1==0 )//liga1
				realfixture++;}
		if(realfixture==6){
			if(Week[realweek].fixture[6].match[1].team1==0)//liga2
				realfixture++;}
		if(realfixture==7){
			if(Week[realweek].fixture[7].match[1].team1==0)//seriea1
				realfixture++;}
		if(realfixture==8){
			if(Week[realweek].fixture[8].match[1].team1==0)//seriea2
				realfixture++;}
		if(realfixture==9){
			if(Week[realweek].fixture[9].match[1].team1==0)//bundes1
				realfixture++;}
		if(realfixture==10){
			if(Week[realweek].fixture[10].match[1].team1==0)//bundes2
				realfixture++;}
		if(realfixture==11){
			if(Week[realweek].fixture[11].match[1].team1==0)//africa
				realfixture++;}
		if(realfixture==12){
			if(Week[realweek].fixture[12].match[1].team1==0)//asia
				realfixture++;}
		if(realfixture==13){
			if(Week[realweek].fixture[13].match[1].team1==0)//na
				realfixture++;}
		if(realfixture==14)
		{ realfixture=0;
			GameObject.Find("Messenger").GetComponent<messenger>().DoTraining();
			realweek+=1;
			if(realweek==193)
				realweek=1;
			state="news";ShowNews();
			week++;
			if(week==5)
			{week=1;
				if(month=="jan")
					month="feb";
				else if(month=="feb")
					month="mar";
				else if(month=="mar")
					month="apr";
				else if(month=="apr")
					month="may";
				else if(month=="may")
					month="jun";
				else if(month=="jun")
					month="Jul";
				else if(month=="Jul")  //long bug fix
					month="aug";
				else if(month=="aug")
					month="sep";
				else if(month=="sep")
					month="oct";
				else if(month=="oct")
					month="nov";
				else if(month=="nov")
					month="dec";
				else if(month=="dec")
				{month="jan";year++;global.age++;}}
			Save();
		}
		else
		{state="fixture";ShowFixtures();
			if((realfixture==liga1 || realfixture==liga2) && global.league!="La Liga")  //skip fixtures you are not a part of
				SimulateMatches();
			if((realfixture==seriea1 || realfixture==seriea2) && global.league!="Serie A")  //skip fixtures you are not a part of
				SimulateMatches();
			if((realfixture==bundes1 || realfixture==bundes2) && global.league!="Bundesliga")  //skip fixtures you are not a part of
				SimulateMatches();
			if(realfixture==africa2 && global.league!="Africa")  //skip fixtures you are not a part of
				SimulateMatches();
			//if(realfixture==asia2 && global.league!="Asia")  //skip fixtures you are not a part of
			//SimulateMatches();
			if(realfixture==northamerica2 && global.league!="North America")  //skip fixtures you are not a part of
				SimulateMatches();Debug.Log(realweek+" "+realfixture);
			return;/*news="";*/} //if own fixture, change next button text   
	}
	else if(state=="news")
	{state="advance";HideNews();news="";return;}
	else if(state=="fixture")
	{SimulateMatches(); }
}

void  ShowFixtures (){
	/*for(FIXME_VAR_TYPE m=1;m<=8;m++){  
 for(FIXME_VAR_TYPE j=1;j<=5;j++)
 Debug.Log("group "+m+" team "+EUROqualifier_group[m,j]);
}*/      string k;
	fixturename.SetActive(true);  GameObject fixture=null;
	for(int i=1;i<=9;i++){ 
		if(realfixture<5){     
			if(i==1 && Week[realweek].fixture[realfixture].match[1].team1!=0)
			{fixture1.SetActive(true);  fixture= fixture1;fixture1.transform.Find("score1").GetComponent<Text>().text="";fixture1.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==2 && Week[realweek].fixture[realfixture].match[2].team1!=0)
			{fixture2.SetActive(true); fixture = fixture2;fixture2.transform.Find("score1").GetComponent<Text>().text="";fixture2.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==3 && Week[realweek].fixture[realfixture].match[3].team1!=0)
			{fixture3.SetActive(true); fixture = fixture3;fixture3.transform.Find("score1").GetComponent<Text>().text="";fixture3.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==4 && Week[realweek].fixture[realfixture].match[4].team1!=0)
			{fixture4.SetActive(true); fixture = fixture4;fixture4.transform.Find("score1").GetComponent<Text>().text="";fixture4.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==5 && Week[realweek].fixture[realfixture].match[5].team1!=0)
			{fixture5.SetActive(true); fixture = fixture5;fixture5.transform.Find("score1").GetComponent<Text>().text="";fixture5.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==6 && Week[realweek].fixture[realfixture].match[6].team1!=0)
			{fixture6.SetActive(true); fixture = fixture6;fixture6.transform.Find("score1").GetComponent<Text>().text="";fixture6.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==7 && Week[realweek].fixture[realfixture].match[7].team1!=0)
			{fixture7.SetActive(true); fixture = fixture7;fixture7.transform.Find("score1").GetComponent<Text>().text="";fixture7.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==8 && Week[realweek].fixture[realfixture].match[8].team1!=0)
			{fixture8.SetActive(true); fixture = fixture8;fixture8.transform.Find("score1").GetComponent<Text>().text="";fixture8.transform.Find("score2").GetComponent<Text>().text="";}
			if(i==9 && Week[realweek].fixture[realfixture].match[9].team1!=0)
			{fixture9.SetActive(true); fixture = fixture9;fixture9.transform.Find("score1").GetComponent<Text>().text="";fixture9.transform.Find("score2").GetComponent<Text>().text="";}
		}
		else if(global.league=="La Liga" && realfixture==liga1 ){
			if(i==1 && Week[realweek].fixture[liga1].match[1].team1!=0)
			{fixture1.SetActive(true);  fixture = fixture1;}
			if(i==2 && Week[realweek].fixture[liga1].match[2].team1!=0)
			{fixture2.SetActive(true); fixture = fixture2;}
			if(i==3 && Week[realweek].fixture[liga1].match[3].team1!=0)
			{fixture3.SetActive(true); fixture = fixture3;}
			if(i==4 && Week[realweek].fixture[liga1].match[4].team1!=0)
			{fixture4.SetActive(true); fixture = fixture4;}
			if(i==5 && Week[realweek].fixture[liga1].match[5].team1!=0)
			{fixture5.SetActive(true); fixture = fixture5;}
			if(i==6 && Week[realweek].fixture[liga1].match[6].team1!=0)
			{fixture6.SetActive(true); fixture = fixture6;}
			if(i==7 && Week[realweek].fixture[liga1].match[7].team1!=0)
			{fixture7.SetActive(true); fixture = fixture7;}
			if(i==8 && Week[realweek].fixture[liga1].match[8].team1!=0)
			{fixture8.SetActive(true); fixture = fixture8;}  }
		else if(global.league=="La Liga" && realfixture==liga2){
			if(i==1 && Week[realweek].fixture[liga2].match[1].team1!=0)
			{fixture1.SetActive(true);  fixture = fixture1;}
			if(i==2 && Week[realweek].fixture[liga2].match[2].team1!=0)
			{fixture2.SetActive(true); fixture = fixture2;}
			if(i==3 && Week[realweek].fixture[liga2].match[3].team1!=0)
			{fixture3.SetActive(true); fixture = fixture3;}
			if(i==4 && Week[realweek].fixture[liga2].match[4].team1!=0)
			{fixture4.SetActive(true); fixture = fixture4;}
		}
		else
			if(global.league=="Serie A" && realfixture==seriea1 ){
				if(i==1 && Week[realweek].fixture[seriea1].match[1].team1!=0)
				{fixture1.SetActive(true);  fixture = fixture1;}
				if(i==2 && Week[realweek].fixture[seriea1].match[2].team1!=0)
				{fixture2.SetActive(true); fixture = fixture2;}
				if(i==3 && Week[realweek].fixture[seriea1].match[3].team1!=0)
				{fixture3.SetActive(true); fixture = fixture3;}
				if(i==4 && Week[realweek].fixture[seriea1].match[4].team1!=0)
				{fixture4.SetActive(true); fixture = fixture4;}
				if(i==5 && Week[realweek].fixture[seriea1].match[5].team1!=0)
				{fixture5.SetActive(true); fixture = fixture5;}
				if(i==6 && Week[realweek].fixture[seriea1].match[6].team1!=0)
				{fixture6.SetActive(true); fixture = fixture6;}
				if(i==7 && Week[realweek].fixture[seriea1].match[7].team1!=0)
				{fixture7.SetActive(true); fixture = fixture7;}
				if(i==8 && Week[realweek].fixture[seriea1].match[8].team1!=0)
				{fixture8.SetActive(true); fixture = fixture8;}  }
			else if(global.league=="Serie A" && realfixture==seriea2){////////////////////////////////
				if(i==1 && Week[realweek].fixture[seriea2].match[1].team1!=0)
				{fixture1.SetActive(true);  fixture = fixture1;}
				if(i==2 && Week[realweek].fixture[seriea2].match[2].team1!=0)
				{fixture2.SetActive(true); fixture = fixture2;}
				if(i==3 && Week[realweek].fixture[seriea2].match[3].team1!=0)
				{fixture3.SetActive(true); fixture = fixture3;}
				if(i==4 && Week[realweek].fixture[seriea2].match[4].team1!=0)
				{fixture4.SetActive(true); fixture = fixture4;} }
			else
				if(global.league=="Bundesliga" && realfixture==bundes1 ){
					if(i==1 && Week[realweek].fixture[bundes1].match[1].team1!=0)
					{fixture1.SetActive(true);  fixture = fixture1;}
					if(i==2 && Week[realweek].fixture[bundes1].match[2].team1!=0)
					{fixture2.SetActive(true); fixture = fixture2;}
					if(i==3 && Week[realweek].fixture[bundes1].match[3].team1!=0)
					{fixture3.SetActive(true); fixture = fixture3;}
					if(i==4 && Week[realweek].fixture[bundes1].match[4].team1!=0)
					{fixture4.SetActive(true); fixture = fixture4;}
					if(i==5 && Week[realweek].fixture[bundes1].match[5].team1!=0)
					{fixture5.SetActive(true); fixture = fixture5;}
					if(i==6 && Week[realweek].fixture[bundes1].match[6].team1!=0)
					{fixture6.SetActive(true); fixture = fixture6;}
					if(i==7 && Week[realweek].fixture[bundes1].match[7].team1!=0)
					{fixture7.SetActive(true); fixture = fixture7;}
					if(i==8 && Week[realweek].fixture[bundes1].match[8].team1!=0)
					{fixture8.SetActive(true); fixture = fixture8;}  }
				else if(global.league=="Bundesliga" && realfixture==bundes2){
					if(i==1 && Week[realweek].fixture[bundes2].match[1].team1!=0)
					{fixture1.SetActive(true);  fixture = fixture1;}
					if(i==2 && Week[realweek].fixture[bundes2].match[2].team1!=0)
					{fixture2.SetActive(true); fixture = fixture2;}
					if(i==3 && Week[realweek].fixture[bundes2].match[3].team1!=0)
					{fixture3.SetActive(true); fixture = fixture3;}
					if(i==4 && Week[realweek].fixture[bundes2].match[4].team1!=0)
					{fixture4.SetActive(true); fixture = fixture4;} }

		if(global.category=="countries" ){
			if(realfixture==northamerica2 ){
				if(i==1 && Week[realweek].fixture[northamerica2].match[1].team1!=0)
				{fixture1.SetActive(true);  fixture = fixture1;}
				if(i==2 && Week[realweek].fixture[northamerica2].match[2].team1!=0)
				{fixture2.SetActive(true); fixture = fixture2;}
				if(i==3 && Week[realweek].fixture[northamerica2].match[3].team1!=0)
				{fixture3.SetActive(true); fixture = fixture3;}
				if(i==4 && Week[realweek].fixture[northamerica2].match[4].team1!=0)
				{fixture4.SetActive(true); fixture = fixture4;}
				if(i==5 && Week[realweek].fixture[northamerica2].match[5].team1!=0)
				{fixture5.SetActive(true); fixture = fixture5;}
				if(i==6 && Week[realweek].fixture[northamerica2].match[6].team1!=0)
				{fixture6.SetActive(true); fixture = fixture6;}
				if(i==7 && Week[realweek].fixture[northamerica2].match[7].team1!=0)
				{fixture7.SetActive(true); fixture = fixture7;}
				if(i==8 && Week[realweek].fixture[northamerica2].match[8].team1!=0)
				{fixture8.SetActive(true); fixture = fixture8;}
				if(i==9 && Week[realweek].fixture[northamerica2].match[9].team1!=0)
				{fixture9.SetActive(true); fixture = fixture9;}   }
			else if(realfixture==africa2 ){
				if(i==1 && Week[realweek].fixture[africa2].match[1].team1!=0)
				{fixture1.SetActive(true);  fixture = fixture1;}
				if(i==2 && Week[realweek].fixture[africa2].match[2].team1!=0)
				{fixture2.SetActive(true); fixture = fixture2;}
				if(i==3 && Week[realweek].fixture[africa2].match[3].team1!=0)
				{fixture3.SetActive(true); fixture = fixture3;}
				if(i==4 && Week[realweek].fixture[africa2].match[4].team1!=0)
				{fixture4.SetActive(true); fixture = fixture4;}
				if(i==5 && Week[realweek].fixture[africa2].match[5].team1!=0)
				{fixture5.SetActive(true); fixture = fixture5;}
				if(i==6 && Week[realweek].fixture[africa2].match[6].team1!=0)
				{fixture6.SetActive(true); fixture = fixture6;}
				if(i==7 && Week[realweek].fixture[africa2].match[7].team1!=0)
				{fixture7.SetActive(true); fixture = fixture7;}
				if(i==8 && Week[realweek].fixture[africa2].match[8].team1!=0)
				{fixture8.SetActive(true); fixture = fixture8;}
				if(i==9 && Week[realweek].fixture[africa2].match[9].team1!=0)
				{fixture9.SetActive(true); fixture = fixture9;}       }
			else if(realfixture==asia2 ){
				if(i==1 && Week[realweek].fixture[asia2].match[1].team1!=0)
				{fixture1.SetActive(true);  fixture = fixture1;}
				if(i==2 && Week[realweek].fixture[asia2].match[2].team1!=0)
				{fixture2.SetActive(true); fixture = fixture2;}
				if(i==3 && Week[realweek].fixture[asia2].match[3].team1!=0)
				{fixture3.SetActive(true); fixture = fixture3;}
				if(i==4 && Week[realweek].fixture[asia2].match[4].team1!=0)
				{fixture4.SetActive(true); fixture = fixture4;}
				if(i==5 && Week[realweek].fixture[asia2].match[5].team1!=0)
				{fixture5.SetActive(true); fixture = fixture5;}
				if(i==6 && Week[realweek].fixture[asia2].match[6].team1!=0)
				{fixture6.SetActive(true); fixture = fixture6;}
				if(i==7 && Week[realweek].fixture[asia2].match[7].team1!=0)
				{fixture7.SetActive(true); fixture = fixture7;}
				if(i==8 && Week[realweek].fixture[asia2].match[8].team1!=0)
				{fixture8.SetActive(true); fixture = fixture8;}
				if(i==9 && Week[realweek].fixture[asia2].match[9].team1!=0)
				{fixture9.SetActive(true); fixture = fixture9;}   }
		}//countries

		if(global.frommatch==true){
			if(i==1 && Week[realweek].fixture[realfixture].match[1].team1!=0)
			{fixture1.SetActive(true); fixture = fixture1;fixture1.transform.Find("score1").GetComponent<Text>().text=fixture1score1;fixture1.transform.Find("score2").GetComponent<Text>().text=fixture1score2;}
			if(i==2 && Week[realweek].fixture[realfixture].match[2].team1!=0)
			{fixture2.SetActive(true); fixture = fixture2;fixture2.transform.Find("score1").GetComponent<Text>().text=fixture2score1;fixture2.transform.Find("score2").GetComponent<Text>().text=fixture2score2;}
			if(i==3 && Week[realweek].fixture[realfixture].match[3].team1!=0)
			{fixture3.SetActive(true); fixture = fixture3;fixture3.transform.Find("score1").GetComponent<Text>().text=fixture3score1;fixture3.transform.Find("score2").GetComponent<Text>().text=fixture3score2;}
			if(i==4 && Week[realweek].fixture[realfixture].match[4].team1!=0)
			{fixture4.SetActive(true); fixture = fixture4;fixture4.transform.Find("score1").GetComponent<Text>().text=fixture4score1;fixture4.transform.Find("score2").GetComponent<Text>().text=fixture4score2;}
			if(i==5 && Week[realweek].fixture[realfixture].match[5].team1!=0)
			{fixture5.SetActive(true); fixture = fixture5;fixture5.transform.Find("score1").GetComponent<Text>().text=fixture5score1;fixture5.transform.Find("score2").GetComponent<Text>().text=fixture5score2;}
			if(i==6 && Week[realweek].fixture[realfixture].match[6].team1!=0)
			{fixture6.SetActive(true); fixture = fixture6;fixture6.transform.Find("score1").GetComponent<Text>().text=fixture6score1;fixture6.transform.Find("score2").GetComponent<Text>().text=fixture6score2;}
			if(i==7 && Week[realweek].fixture[realfixture].match[7].team1!=0)
			{fixture7.SetActive(true); fixture = fixture7;fixture7.transform.Find("score1").GetComponent<Text>().text=fixture7score1;fixture7.transform.Find("score2").GetComponent<Text>().text=fixture7score2;}
			if(i==8 && Week[realweek].fixture[realfixture].match[8].team1!=0)
			{fixture8.SetActive(true); fixture = fixture8;fixture8.transform.Find("score1").GetComponent<Text>().text=fixture8score1;fixture8.transform.Find("score2").GetComponent<Text>().text=fixture8score2;}
		}
		else
		{fixture1score1="";fixture1score2="";fixture2score1="";fixture2score2="";fixture3score1="";fixture3score2="";fixture4score1="";fixture4score2="";
			fixture5score1="";fixture5score2="";fixture6score1="";fixture6score2="";fixture7score1="";fixture7score2="";fixture8score1="";fixture8score2="";}



		if(fixture!=null){  
			if(Week[realweek].fixture[realfixture].match[i].team1!=global.id && Week[realweek].fixture[realfixture].match[i].team2!=global.id 
				&&((Week[realweek].fixture[realfixture].category=="clubs" && global.category=="clubs")||(Week[realweek].fixture[realfixture].category=="countries" && global.category=="countries")) )
				fixture.transform.Find("watch").gameObject.SetActive(true);
			else{
				if(((Week[realweek].fixture[realfixture].category=="clubs" && global.category=="clubs") || (Week[realweek].fixture[realfixture].category=="countries" && global.category=="countries"))
					&&(Week[realweek].fixture[realfixture].match[i].team1==global.id || Week[realweek].fixture[realfixture].match[i].team2==global.id))
					fixture.transform.Find("watch").gameObject.SetActive(false);}

			//if(global.frommatch==false){

			if( Week[realweek].fixture[liga2].match[i].team1!=0 && global.league=="La Liga" && realfixture==liga2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[liga2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[liga2].match[i].team2]; category="clubs";
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[liga2].name;
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[liga2].colour; 
				if((Week[realweek].fixture[liga2].match[i].team1==global.id || 
					Week[realweek].fixture[liga2].match[i].team2==global.id)  && global.category=="clubs" )//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}
			}
			else if( Week[realweek].fixture[liga1].match[i].team1!=0 && global.league=="La Liga" && realfixture==liga1)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[liga1].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[liga1].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[liga1].name;  category="clubs"; 
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[liga1].colour;
				if((Week[realweek].fixture[liga1].match[i].team1==global.id || 
					Week[realweek].fixture[liga1].match[i].team2==global.id )  && global.category=="clubs")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			else if(Week[realweek].fixture[seriea2].match[i].team1!=0 && global.league=="Serie A" && realfixture==seriea2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[seriea2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[seriea2].match[i].team2]; category="clubs";
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[seriea2].name;  
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[seriea2].colour;
				if((Week[realweek].fixture[seriea2].match[i].team1==global.id || 
					Week[realweek].fixture[seriea2].match[i].team2==global.id) && global.category=="clubs")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			else if(Week[realweek].fixture[seriea1].match[i].team1!=0 && global.league=="Serie A" && realfixture==seriea1)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[seriea1].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[seriea1].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[seriea1].name; category="clubs";  
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[seriea1].colour;
				if((Week[realweek].fixture[seriea1].match[i].team1==global.id || 
					Week[realweek].fixture[seriea1].match[i].team2==global.id )&& global.category=="clubs")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			else if(Week[realweek].fixture[bundes1].match[i].team1!=0 && global.league=="Bundesliga" && realfixture==bundes1)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[bundes1].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[bundes1].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[bundes1].name; category="clubs"; 
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[bundes1].colour;
				if((Week[realweek].fixture[bundes1].match[i].team1==global.id || 
					Week[realweek].fixture[bundes1].match[i].team2==global.id) && global.category=="clubs")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			else if(Week[realweek].fixture[bundes2].match[i].team1!=0 && global.league=="Bundesliga" && realfixture==bundes2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[bundes2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[bundes2].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[bundes2].name; category="clubs";  
				fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[bundes2].colour;
				if((Week[realweek].fixture[bundes2].match[i].team1==global.id || 
					Week[realweek].fixture[bundes2].match[i].team2==global.id) && global.category=="clubs")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			/////////////////////////

			else if(Week[realweek].fixture[africa2].match[i].team1!=0 && global.league=="Africa"  && realfixture==africa2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=countryname[Week[realweek].fixture[africa2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=countryname[Week[realweek].fixture[africa2].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[africa2].name; category="countries"; 
				if((Week[realweek].fixture[africa2].match[i].team1==global.id || 
					Week[realweek].fixture[africa2].match[i].team2==global.id) && global.category=="countries")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			//////////////////////////////////////////////////////////////////////////////////////////////////
			else if(Week[realweek].fixture[asia2].match[i].team1!=0 && global.league=="Asia" && realfixture==asia2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=countryname[Week[realweek].fixture[asia2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=countryname[Week[realweek].fixture[asia2].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[asia2].name;  category="countries"; 
				if((Week[realweek].fixture[asia2].match[i].team1==global.id || 
					Week[realweek].fixture[asia2].match[i].team2==global.id ) && global.category=="countries")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			/////////////////////////////////////////////////////////////////////////////////////////////////
			else if(Week[realweek].fixture[northamerica2].match[i].team1!=0 && global.league=="North America" && realfixture==northamerica2)
			{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=countryname[Week[realweek].fixture[northamerica2].match[i].team1];
				fixture.transform.Find("team2").GetComponent<Text>().text=countryname[Week[realweek].fixture[northamerica2].match[i].team2];
				fixturename.GetComponent<Text>().text=Week[realweek].fixture[northamerica2].name;  category="countries";  
				if((Week[realweek].fixture[northamerica2].match[i].team1==global.id || 
					Week[realweek].fixture[northamerica2].match[i].team2==global.id) && global.category=="countries")//same id as own
				{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}
			/////////////////
			//fixture 1
			else if(Week[realweek].fixture[realfixture].match[i].team1!=0 )
			{
				/*if(Week[realweek].fixture[realfixture].kind=="premierleague" && global.league!="La Liga" && global.league!="Serie A"
  && global.league!="Bundesliga")    //PREMIER LEAGUE
  {fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[realfixture].match[i].team1];
 fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[realfixture].match[i].team2];
  fixturename.GetComponent<Text>().text=Week[realweek].fixture[realfixture].name;  category="clubs";
  fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[realfixture].colour;
  if((Week[realweek].fixture[realfixture].match[i].team1==global.id || 
   Week[realweek].fixture[realfixture].match[i].team2==global.id) && global.category=="clubs")//same id as own
    {fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";}}*/
				if((Week[realweek].fixture[realfixture].kind=="WCQeurope" || Week[realweek].fixture[realfixture].kind=="WCQsouthamerica" ||
					Week[realweek].fixture[realfixture].kind=="WCQoceania")
					&& global.league!="Africa" && global.league!="Asia" && global.league!="North America")  //error fix
				{fixture.SetActive(true);fixture.transform.Find("team1").GetComponent<Text>().text=countryname[Week[realweek].fixture[realfixture].match[i].team1];
					fixture.transform.Find("team2").GetComponent<Text>().text=countryname[Week[realweek].fixture[realfixture].match[i].team2];
					fixturename.GetComponent<Text>().text=Week[realweek].fixture[realfixture].name;fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[realfixture].colour;
					fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[realfixture].colour;  category="countries"; 
					if((Week[realweek].fixture[realfixture].match[i].team1==global.id || 
						Week[realweek].fixture[realfixture].match[i].team2==global.id) && global.category=="countries")//same id as own
						fixture.transform.Find("watch").gameObject.SetActive(false);}

				else //if((Week[realweek].fixture[realfixture].kind!="laliga" && global.league=="Premier League") || global.category=="countries")
				{
					 k=Week[realweek].fixture[realfixture].kind; 
					string[] ss={"communityshield","premierleague","facup","leaguecup","championsleague","uefacup","cwc","eurovase"};
					if(ContainsStr(ss,k) ){
						fixture.SetActive(true); 
						fixturename.GetComponent<Text>().text=Week[realweek].fixture[realfixture].name;
						fixture.transform.Find("team1").GetComponent<Text>().text=clubname[Week[realweek].fixture[realfixture].match[i].team1]; category="clubs";
						fixture.transform.Find("team2").GetComponent<Text>().text=clubname[Week[realweek].fixture[realfixture].match[i].team2];
						fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[realfixture].colour; 
						if((Week[realweek].fixture[realfixture].match[i].team1==global.id || 
							Week[realweek].fixture[realfixture].match[i].team2==global.id )&& global.category=="clubs")//same id as own
							fixture.transform.Find("watch").gameObject.SetActive(false);}  
					else  //all other countries
					{ //if(global.category=="countries" && Week[realweek].fixture[realfixture].category=="countries" ){
						fixturename.GetComponent<Text>().text=Week[realweek].fixture[realfixture].name; 
						fixture.transform.Find("team1").GetComponent<Text>().text=countryname[Week[realweek].fixture[realfixture].match[i].team1]; category="countries";
						fixture.transform.Find("team2").GetComponent<Text>().text=countryname[Week[realweek].fixture[realfixture].match[i].team2];
						fixturecolour.GetComponent<Image>().color=Week[realweek].fixture[realfixture].colour; //Debug.Log("week "+realweek+" fix "+realfixture+" team "+" i "+i+" "+Week[realweek].fixture[realfixture].match[i].team2);
						if((Week[realweek].fixture[realfixture].match[i].team1==global.id || 
							Week[realweek].fixture[realfixture].match[i].team2==global.id )&& global.category=="countries")//same id as own
						{fixture.transform.Find("watch").gameObject.SetActive(false);next.transform.Find("Text").GetComponent<Text>().text="Play";} }
				}

			}//team not 0
			//wcq northamerica

			//wcqafrica

			//wcqasia
			 k=Week[realweek].fixture[realfixture].kind;
			///////////////////FLAGS/////////////////////////////
			string[] s={"friendly","worldcup","euro","euroquals","goldcup","copa","afcon","cecafacup","cosafacup","afconquals","confed","seagames",
				"ocncup","asiancup","cabralcup","WCQeurope","WCQoceania","WCQafrica","WCQasia","WCQnorthamerica","WCQsouthamerica"};
			if(ContainsStr(s,k)){
				fixture.transform.Find("flag2").GetComponent<Image>().enabled=true;
				fixture.transform.Find("flag1").GetComponent<Image>().enabled=true;

				//if(Week[realweek].fixture[realfixture].match[i].team1!=0){
				var FilePath= Application.dataPath+"/flags/"+icon[Week[realweek].fixture[realfixture].match[i].team1]+".png";
				if(System.IO.File.Exists(FilePath))
					fixture.transform.Find("flag1").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
				//}
				FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[realfixture].match[i].team2]+".png";
				if(System.IO.File.Exists(FilePath))
					fixture.transform.Find("flag2").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
				//}                               // }
				if(realfixture==africa2){
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[africa2].match[i].team1]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag1").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {}
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[africa2].match[i].team2]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag2").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {}     }                           //  }
				if(realfixture==asia2){
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[asia2].match[i].team1]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag1").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {Debug.Log("no flag file found");}
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[asia2].match[i].team2]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag2").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {}      }                   //  }
				if(realfixture==northamerica2){
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[northamerica2].match[i].team1]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag1").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {}
					FilePath = Application.dataPath+"/flags/"+icon[Week[realweek].fixture[northamerica2].match[i].team2]+".png";
					if(System.IO.File.Exists(FilePath))
						fixture.transform.Find("flag2").GetComponent<Image>().sprite=Img2Sprite.LoadNewSprite(FilePath,100.0f);
					else {}     }                //} 
			}
			else
			{if(fixture!=null){
					fixture.transform.Find("flag2").GetComponent<Image>().enabled=false; //no flag
					fixture.transform.Find("flag1").GetComponent<Image>().enabled=false;}}
			// }//fixture same as i
		}//fixture exists
		if(((Week[realweek].fixture[realfixture].category=="clubs" && global.category=="clubs") || (Week[realweek].fixture[realfixture].category=="clountries" && global.category=="countries"))
			&&(Week[realweek].fixture[realfixture].match[i].team1==global.id || Week[realweek].fixture[realfixture].match[i].team2==global.id)){
			if(i==1)
				fixture.transform.Find("watch").gameObject.SetActive(false);
		}
	}//for loop



}//
void  HideFixtures (){
	if(fixturename==null)
		fixturename=GameObject.Find("Canvas").transform.Find("fixturename").gameObject;
	fixturename.SetActive(false);
	if(fixture1==null)
		fixture1=GameObject.Find("Canvas").transform.Find("fixture1").gameObject;
	if(fixture2==null)
		fixture2=GameObject.Find("Canvas").transform.Find("fixture2").gameObject;
	if(fixture3==null)
		fixture3=GameObject.Find("Canvas").transform.Find("fixture3").gameObject;
	if(fixture4==null)
		fixture4=GameObject.Find("Canvas").transform.Find("fixture4").gameObject;
	if(fixture5==null)
		fixture5=GameObject.Find("Canvas").transform.Find("fixture5").gameObject;
	if(fixture6==null)
		fixture6=GameObject.Find("Canvas").transform.Find("fixture6").gameObject;
	if(fixture7==null)
		fixture7=GameObject.Find("Canvas").transform.Find("fixture7").gameObject;
	if(fixture8==null)
		fixture8=GameObject.Find("Canvas").transform.Find("fixture8").gameObject;
	if(fixture9==null)
		fixture9=GameObject.Find("Canvas").transform.Find("fixture9").gameObject;
	if(fixture1.activeSelf){
		fixture1.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture1.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture1.transform.Find("score1").GetComponent<Text>().text="";
		fixture1.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture2.activeSelf){
		fixture2.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture2.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture2.transform.Find("score1").GetComponent<Text>().text="";
		fixture2.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture3.activeSelf){
		fixture3.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture3.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture3.transform.Find("score1").GetComponent<Text>().text="";
		fixture3.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture4.activeSelf){
		fixture4.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture4.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture4.transform.Find("score1").GetComponent<Text>().text="";
		fixture4.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture5.activeSelf){
		fixture5.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture5.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture5.transform.Find("score1").GetComponent<Text>().text="";
		fixture5.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture6.activeSelf){
		fixture6.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture6.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture6.transform.Find("score1").GetComponent<Text>().text="";
		fixture6.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture7.activeSelf){
		fixture7.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture7.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture7.transform.Find("score1").GetComponent<Text>().text="";
		fixture7.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture8.activeSelf){
		fixture8.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture8.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture8.transform.Find("score1").GetComponent<Text>().text="";
		fixture8.transform.Find("score2").GetComponent<Text>().text="";}
	if(fixture9.activeSelf){
		fixture9.transform.Find("flag1").GetComponent<Image>().enabled=false;
		fixture9.transform.Find("flag2").GetComponent<Image>().enabled=false;
		fixture9.transform.Find("score1").GetComponent<Text>().text="";
		fixture9.transform.Find("score2").GetComponent<Text>().text="";}
	fixture1.SetActive(false);
	fixture2.SetActive(false);
	fixture3.SetActive(false);
	fixture4.SetActive(false);
	fixture5.SetActive(false);
	fixture6.SetActive(false);
	fixture7.SetActive(false);
	fixture8.SetActive(false);
	fixture9.SetActive(false);
}//

void  ShowNews (){
	newspaper.SetActive(true);
	newspaper.GetComponent<Text>().text=news;
}//

void  HideNews (){
	if(newspaper==null)
		newspaper=GameObject.Find("Canvas").transform.Find("Newspaper").gameObject;
	newspaper.SetActive(false);
}

void  SimulateMatches (){ GameObject fixture=null;
	for (int i=1;i<=9;i++){
		if(i==1 && match1played==false && Week[realweek].fixture[realfixture].match[1].team1!=0)
		{ fixture= fixture1;}
		if(i==1 && match1played==false  && Week[realweek].fixture[realfixture].match[1].team1==0)
		{match1played=true;}
		if(i==2 && match2played==false && Week[realweek].fixture[realfixture].match[2].team1!=0)
		{ fixture = fixture2; }
		if(i==2 && match2played==false  && Week[realweek].fixture[realfixture].match[2].team1==0)
		{match2played=true;}
		if(i==3 && match3played==false && Week[realweek].fixture[realfixture].match[3].team1!=0)
		{ fixture = fixture3; }
		if(i==3 && match3played==false  && Week[realweek].fixture[realfixture].match[3].team1==0)
		{match3played=true;}
		if(i==4 && match4played==false && Week[realweek].fixture[realfixture].match[4].team1!=0)
		{ fixture = fixture4; }
		if(i==4 && match4played==false  && Week[realweek].fixture[realfixture].match[4].team1==0)
		{match4played=true;}
		if(i==5 && match5played==false && Week[realweek].fixture[realfixture].match[5].team1!=0)
		{ fixture = fixture5; }
		if(i==5 && match5played==false  && Week[realweek].fixture[realfixture].match[5].team1==0)
		{match5played=true;}
		if(i==6 && match6played==false && Week[realweek].fixture[realfixture].match[6].team1!=0)
		{ fixture = fixture6; }
		if(i==6 && match6played==false  && Week[realweek].fixture[realfixture].match[6].team1==0)
		{match6played=true;}
		if(i==7 && match7played==false && Week[realweek].fixture[realfixture].match[7].team1!=0)
		{ fixture = fixture7; }
		if(i==7 && match7played==false  && Week[realweek].fixture[realfixture].match[7].team1==0)
		{match7played=true;}
		if(i==8 && match8played==false && Week[realweek].fixture[realfixture].match[8].team1!=0)
		{ fixture = fixture8; }
		if(i==8 && match8played==false  && Week[realweek].fixture[realfixture].match[8].team1==0)
		{match8played=true;}
		if(i==9 && match9played==false && Week[realweek].fixture[realfixture].match[9].team1!=0)
		{ fixture = fixture9; }
		if(i==9 && match9played==false  && Week[realweek].fixture[realfixture].match[9].team1==0)
		{match9played=true;}

		//    Debug.Log("week "+realweek+" fixture "+realfixture+" i "+i+" kind "+Week[realweek].fixture[realfixture].kind+" team1 "+Week[realweek].fixture[realfixture].match[i].team1);
		if(match1played && match2played && i==9 && match3played && match4played && match5played && match6played && match7played && match8played && match9played)
		{state="advance";}
		if(fixture==null){continue;}  //watch
		if(Week[realweek].fixture[realfixture].match[i].team1!=0){
			global.team1=Week[realweek].fixture[realfixture].match[i].team1;
			global.team2=Week[realweek].fixture[realfixture].match[i].team2;
			if(Week[realweek].fixture[realfixture].match[i].team1==global.id ||Week[realweek].fixture[realfixture].match[i].team2==global.id )//player teams?
			{if((global.category=="clubs" && Week[realweek].fixture[realfixture].category=="clubs") ||
				(global.category=="countries" && Week[realweek].fixture[realfixture].category=="countries"))
				{GotoMatchEngine(realfixture,fixture,i);break;}
			else
				FixMatch(realfixture,fixture,i);
		} 
			else
			{FixMatch(realfixture,fixture,i);}
		}


	}//for

}//

void  GotoMatchEngine ( int real ,  GameObject fixture ,  int i  ){  // function for player
	if(Week[realweek].fixture[real].match[i].team1==0 || Week[realweek].fixture[real].match[i].team2==0){  //same community shield winner
		FixMatch(realfixture,fixture,i);Debug.Log("one of teams zero");return; }
	global.team1=Week[realweek].fixture[real].match[i].team1;  //team id
	global.team2=Week[realweek].fixture[real].match[i].team2;
	global.team1goals=0;
	global.team2goals=0;
	global.Event=Week[realweek].fixture[real].kind;  //ucl?
	if(Week[realweek].fixture[real].type=="aggregate")
	{global.isaggregate=true;global.team1aggregate=clubaggregate[global.team1];global.team2aggregate=clubaggregate[global.team2];
		if(Week[realweek].fixture[real].kind=="championsleague")
		{global.awaygoals=clubawaygoals[global.team2];global.homeawaygoals=clubawaygoals[global.team1];}} //global ones will be reset on match end
	if(Week[realweek].fixture[real].type=="knockout")
		global.isknockout=true;
	if(Week[realweek].fixture[real].leg=="second")
		global.issecondleg=true;
	global.frommatch=true;if(global.team1==global.id || global.team2==global.id)global.fromdashboard=true;
	global.fixture=fixture.name;
	global.realfixture=real;
	global.i=i;
	Application.LoadLevel("match");
}

void  FixMatch ( int real ,  GameObject fixture ,  int i  ){ float team1reputation;float team2reputation,team1rep,team2rep,totrep,diff,dice;
	int skittles,rand; //simulate match
	global.team1=Week[realweek].fixture[real].match[i].team1;
	global.team2=Week[realweek].fixture[real].match[i].team2;
	if(Week[realweek].fixture[real].category=="clubs"){
		 team1reputation=clubreputation[Week[realweek].fixture[real].match[i].team1];
		 team2reputation=clubreputation[Week[realweek].fixture[real].match[i].team2];}
	else
	{
		team1reputation=reputation[Week[realweek].fixture[real].match[i].team1];
		team2reputation=reputation[Week[realweek].fixture[real].match[i].team2];}

	if(team2reputation>=team1reputation){
		 team1rep=team1reputation*1.0f;  team2rep=team2reputation*1.0f;
		 totrep=team1reputation*1.0f+team2reputation*1.0f;
		 diff=team2reputation-team1reputation;  if(diff==0)diff=1;
		 dice=Random.Range(0.0f,team1rep/totrep*1.0f); ;//draw
		if(Random.Range(0.0f,1.0f)<team1rep/totrep*1.0f)
		{ rand=Random.Range(0,10);
			if(rand<=4){
				global.team1goals=0;
				global.team2goals=0;}
			else if(rand>4 && rand<=7){
				global.team1goals=1;
				global.team2goals=1;}
			else if(rand>7 && rand<=9){
				global.team1goals=2;
				global.team2goals=2;}
			else if(rand==9){
				global.team1goals=3;
				global.team2goals=3;}
			else if(rand>=9 ){
				global.team1goals=4;
				global.team2goals=4;}   
			global.winner=0;global.team1points=1;global.team2points=1;
			if(Week[realweek].fixture[real].type=="aggregate")
				clubawaygoals[global.team2]=global.team2goals;} //draw//////////
		else{  //win////////////////////////
			dice=Mathf.Clamp(dice,0.05f,0.5f);
			dice=(team1rep/10*1.0f)/(diff*2*1.0f); 
			dice=Mathf.Clamp(dice,0.05f,0.5f);  ;
			if(Random.Range(0.0f,1.0f)<dice){//team1 wins
				 skittles=Random.Range(0,3);
				if(skittles>2){
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team1goals=1;
						global.team2goals=0;}
					else if(rand>4 && rand<=7){
						global.team1goals=2;
						global.team2goals=0;}
					else if(rand>7 && rand<=9){
						global.team1goals=3;
						global.team2goals=0;}
					else if(rand==9){
						global.team1goals=4;
						global.team2goals=0;}
					else if(rand>=9 ){
						global.team1goals=5;
						global.team2goals=0;}
				}
				else{
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team1goals=2;
						global.team2goals=1;}
					else if(rand>4 && rand<=7){
						global.team1goals=3;
						global.team2goals=1;}
					else if(rand>7 && rand<=9){
						global.team1goals=3;
						global.team2goals=2;}
					else if(rand==9){
						global.team1goals=4;
						global.team2goals=1;}
					else if(rand>=9 ){
						global.team1goals=4;
						global.team2goals=2;}
				}
				global.winner=global.team1; global.team1points=3; global.team2points=0;
				if(Week[realweek].fixture[real].type=="aggregate")
					clubawaygoals[global.team2]=global.team2goals;
			}//team 1 wins
			else
			{   //team 2 wins

				skittles=Random.Range(0,3);
				if(skittles>2){
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team1goals=0;
						global.team2goals=1;}
					else if(rand>4 && rand<=7){
						global.team1goals=0;
						global.team2goals=2;}
					else if(rand>7 && rand<=9){
						global.team1goals=0;
						global.team2goals=3;}
					else if(rand==9){
						global.team1goals=0;
						global.team2goals=4;}
					else if(rand>=9 ){
						global.team1goals=0;
						global.team2goals=5;}
				}
				else{
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team1goals=1;
						global.team2goals=2;}
					else if(rand>4 && rand<=7){
						global.team1goals=1;
						global.team2goals=3;}
					else if(rand>7 && rand<=9){
						global.team1goals=2;
						global.team2goals=3;}
					else if(rand==9){
						global.team1goals=1;
						global.team2goals=4;}
					else if(rand>=9 ){
						global.team1goals=2;
						global.team2goals=4;}
				}
				global.winner=global.team2; global.team2points=3; global.team1points=0;  
				if(Week[realweek].fixture[real].type=="aggregate")
					clubawaygoals[global.team2]=global.team2goals;
			} //team 2 wins
		}//win

	}//rep
	else{   // team1 reputation > team2 reputation

		team1rep=team1reputation*1.0f; // totrep=Mathf.Pow(team2reputation,4)+temprep;
		team2rep=team2reputation*1.0f;
		totrep=team1reputation*1.0f+team2reputation*1.0f;
		diff=team1reputation-team2reputation;   if(diff==0)diff=1;
		dice=Random.Range(0.0f,(diff/5.0f)+1.0f);//draw
		if(Random.Range(0.0f,1.0f)<team2rep/totrep*1.0f)
		{ rand=Random.Range(0,10);
			if(rand<=4){
				global.team1goals=0;
				global.team2goals=0;}
			else if(rand>4 && rand<=7){
				global.team1goals=1;
				global.team2goals=1;}
			else if(rand>7 && rand<=9){
				global.team1goals=2;
				global.team2goals=2;}
			else if(rand==9){
				global.team1goals=3;
				global.team2goals=3;}
			else if(rand>=9 ){
				global.team1goals=4;
				global.team2goals=4;}   
			global.winner=0;global.team1points=1;global.team2points=1;
			if(Week[realweek].fixture[real].type=="aggregate")
				clubawaygoals[global.team2]=global.team2goals;} //draw//////////
		else{  //win////////////////////////
			dice=Mathf.Clamp(dice,0.05f,0.5f);
			dice=(team2rep/10*1.0f)/(diff*2*1.0f);
			dice=Mathf.Clamp(dice,0.05f,0.5f); 
			if(Random.Range(0.0f,1.0f)<dice){//team2 wins
				skittles=Random.Range(0,3);
				if(skittles>2){
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team2goals=1;
						global.team1goals=0;}
					else if(rand>4 && rand<=7){
						global.team2goals=2;
						global.team1goals=0;}
					else if(rand>7 && rand<=9){
						global.team2goals=3;
						global.team1goals=0;}
					else if(rand==9){
						global.team2goals=4;
						global.team1goals=0;}
					else if(rand>=9 ){
						global.team2goals=5;
						global.team1goals=0;}
				}
				else{
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team2goals=2;
						global.team1goals=1;}
					else if(rand>4 && rand<=7){
						global.team2goals=3;
						global.team1goals=1;}
					else if(rand>7 && rand<=9){
						global.team2goals=3;
						global.team1goals=2;}
					else if(rand==9){
						global.team2goals=4;
						global.team1goals=1;}
					else if(rand>=9 ){
						global.team2goals=4;
						global.team1goals=2;}
				}
				global.winner=global.team2; global.team2points=3; global.team1points=0;
				if(Week[realweek].fixture[real].type=="aggregate")
					clubawaygoals[global.team2]=global.team2goals;
			}//team 2 wins
			else
			{   //team 1 wins

				skittles=Random.Range(0,3);
				if(skittles>2){
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team2goals=0;
						global.team1goals=1;}
					else if(rand>4 && rand<=7){
						global.team2goals=0;
						global.team1goals=2;}
					else if(rand>7 && rand<=9){
						global.team2goals=0;
						global.team1goals=3;}
					else if(rand==9){
						global.team2goals=0;
						global.team1goals=4;}
					else if(rand>=9 ){
						global.team2goals=0;
						global.team1goals=5;}
				}
				else{
					rand=Random.Range(0,10);
					if(rand<=4){
						global.team2goals=1;
						global.team1goals=2;}
					else if(rand>4 && rand<=7){
						global.team2goals=1;
						global.team1goals=3;}
					else if(rand>7 && rand<=9){
						global.team2goals=2;
						global.team1goals=3;}
					else if(rand==9){
						global.team2goals=1;
						global.team1goals=4;}
					else if(rand>=9 ){
						global.team2goals=2;
						global.team1goals=4;}
				}
				global.winner=global.team1; global.team1points=3;  global.team2points=0; 
				if(Week[realweek].fixture[real].type=="aggregate")
					clubawaygoals[global.team2]=global.team2goals;
			} //team 1 wins
		}//win

	}//rep
	if(Week[realweek].fixture[real].type=="aggregate"){
		clubaggregate[global.team1]+=global.team1goals;
		clubaggregate[global.team2]+=global.team2goals;
		if(Week[realweek].fixture[real].leg=="second")
		{if(clubaggregate[global.team1]>clubaggregate[global.team2])
			global.winner=global.team1;
			if(clubaggregate[global.team1]<clubaggregate[global.team2])
				global.winner=global.team2;
			if(clubaggregate[global.team1]==clubaggregate[global.team2])
			{if(clubawaygoals[global.team1]>clubawaygoals[global.team2])
				global.winner=global.team1;
			else if(clubawaygoals[global.team1]<clubawaygoals[global.team2])
				global.winner=global.team2;
			else
			{if(Random.Range(0.0f,1.0f)<0.5f)
				global.winner=global.team1;
			else
				global.winner=global.team2;}
			clubawaygoals[global.team1]=0;clubawaygoals[global.team2]=0;
		} }
	} else if(Week[realweek].fixture[real].type=="knockout" && global.team1goals==global.team2goals){
		if(Random.Range(0.0f,1.0f)<0.5f)
			global.winner=global.team1;
		else
			global.winner=global.team2;

	}
	if(Week[realweek].fixture[real].kind=="worldcup" && Week[realweek].fixture[real].stage=="semifinal") //error fix, reposition code, what complex logic!
	{if(global.winner==global.team1)
		global.loser=global.team2;
	else
		global.loser=global.team1;}
	global.team1cards=Random.Range(0,5);
	global.team2cards=Random.Range(0,5);
	if(fixture!=null && fixture1.activeSelf){ //prevent setting inactive fixture
		fixture.transform.Find("score1").GetComponent<Text>().text=global.team1goals.ToString();//also set for match engine
		fixture.transform.Find("score2").GetComponent<Text>().text=global.team2goals.ToString();
	}
	FixResults(global.team1,global.team2,real,i);//fix all results to league
	if(i==1)
	{match1played=true;fixture1score1=global.team1goals.ToString();fixture1score2=global.team2goals.ToString();}
	if(i==2)
	{match2played=true;fixture2score1=global.team1goals.ToString();fixture2score2=global.team2goals.ToString();}
	if(i==3)
	{match3played=true;fixture3score1=global.team1goals.ToString();fixture3score2=global.team2goals.ToString();}
	if(i==4)
	{match4played=true;fixture4score1=global.team1goals.ToString();fixture4score2=global.team2goals.ToString();}
	if(i==5)
	{match5played=true;fixture5score1=global.team1goals.ToString();fixture5score2=global.team2goals.ToString();}
	if(i==6)
	{match6played=true;fixture6score1=global.team1goals.ToString();fixture6score2=global.team2goals.ToString();}
	if(i==7)
	{match7played=true;fixture7score1=global.team1goals.ToString();fixture7score2=global.team2goals.ToString();}
	if(i==8)
	{match8played=true;fixture8score1=global.team1goals.ToString();fixture8score2=global.team2goals.ToString();}
	if(i==9)
	{match9played=true;state="advance";}
	if(match1played && match2played && match3played && match4played && match5played && match6played && match7played && match8played && match9played)
		state="advance";
}//

void  FixResults ( int team1 ,  int team2 ,  int real ,  int i  ){  //function called from fixing matches and from coming from match engine

	if(Week[realweek].fixture[real].kind=="premierleague" || Week[realweek].fixture[real].kind=="laliga" ||
		Week[realweek].fixture[real].kind=="seriea" || Week[realweek].fixture[real].kind=="bundesliga")
	{clubleaguepoints[team1]+=global.team1points;
		clubleaguepoints[team2]+=global.team2points;
		clubgoals[team1]+=global.team1goals;
		clubgoals[team2]+=global.team2goals;
		if(Week[realweek].fixture[real].stage!=null && Week[realweek].fixture[real].match[i].position!=null){
			if(Week[realweek].fixture[real].stage=="final" && Week[realweek].fixture[real].match[i].stage=="last"){ 
				if(Week[realweek].fixture[real].kind=="premierleague" )
				{var PLtable=SortLeaguetable(plclubs);
					if(PLtable[0]==global.id)
					{news="Congratulations "+global.managername+", You and your team "+global.team+" have won the Premier League. The board is proud and "+
							" they always knew you would not let them down and wish you more glory in the coming future. n Also you win a cash prize.";
						global.trophies++;
						global.points++;
						global.majortrophies++;
						global.premierleagues++;money[global.id]+=5000000;Money.GetComponent<Text>().text=money[global.id].ToString();}
					else
					{news+=clubname[PLtable[0]]+" have won the Premier league. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
					ResetPLQuals();//determine ucl and uefa qualifiers relegated and promoted first reset bug nulls earlier qualifiers
					communityshield[PLtable[0]]=true;
					communityshield[communityshieldwinner]=true;
					qualifiedleague[PLtable[0]]="champions league";
					qualifiedleague[PLtable[1]]="champions league";
					qualifiedleague[PLtable[2]]="champions league";
					qualifiedleague[PLtable[3]]="champions league";
					qualifiedleague[PLtable[4]]="uefa cup"; 
					qualifiedleague[PLtable[5]]="uefa cup"; 
					clubleaguecup[PLtable[0]]=true;clubleaguecup[PLtable[1]]=true;clubleaguecup[PLtable[2]]=true;clubleaguecup[PLtable[3]]=true;
					clubleaguecup[PLtable[4]]=true;clubleaguecup[PLtable[5]]=true;clubleaguecup[PLtable[6]]=true;clubleaguecup[PLtable[7]]=true;
					var temp=new List<int>();
					for(int j=15;j<18;j++)
						temp.Add(PLtable[j]);
					// for(int j=17;j>=15;j--)        //this does not shorten array length so different method must be used
					// plclubs.Remove(PLtable[j]);
					int v=15;
					for(int k=0;k<3;k++){ 
						for(int m=0;m<18;m++){ Debug.Log(m+' '+v);
							if(plclubs[m]==PLtable[v])          //fixed error of continuing counting m after found v, just add break to reset
							{ plclubs[m]=relegated[k];v++;break;}   //correct code added
						}
					}
					// plclubs[PLtable[15]]=relegated[0];plclubs[16]=relegated[1];plclubs[17]=relegated[2]; //recorrect fotmatting
					relegated.Clear();relegated.Add(temp[0]);relegated.Add(temp[1]);relegated.Add(temp[2]); //relegated[0]=temp[0];relegated[1]=temp[1];relegated[2]=temp[2];
					plmatches=ShufflePLClubs();  //xxxxxxxREINITxxxxxxxxxx
					PLcommunityshield=GetCommunity(18,1,"PL");//xxxxxxxxxxxxx
					ResetClubStats("PL");
					FAcup_playoffs1[1,1]=relegated[0];
					FAcup_playoffs1[1,2]=relegated[1];
					FAcup_playoffs1[2,1]=relegated[2];
					FAcup_playoffs1[2,2]=plclubs[17];//xxxxxxxx
					FAcup_playoffs2=Fill_Facup_playoffs();  Init();
				}
				else{  //not pl
					if(Week[realweek].fixture[real].kind=="laliga"){
						var Ltable=SortArrLeaguetable(llclubs);
						if(Ltable[0]==global.id)
						{news="Congratulations "+global.managername+", You and your team "+global.team+" have won the Spanish La Liga. The board is proud and "+
								" they always knew you would not let them down and wish you more glory in the coming future.n And you win a cash prize.";
							global.trophies++;
							global.points++;
							global.majortrophies++;
							global.spanishleagues++;money[global.id]+=3000000;Money.GetComponent<Text>().text=money[global.id].ToString();}
						else
						{news+=clubname[Ltable[0]]+" have won the La Liga. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
						ResetLQuals("laliga");
						llmatches=ShuffleOtherClubs(llclubs,"laliga");//xxxxxxxreinitxxxxxxxxxxx
						communityshield[Ltable[0]]=true;
						communityshield[spanishsupercupwinner]=true;
						qualifiedleague[Ltable[0]]="champions league";
						qualifiedleague[Ltable[1]]="champions league";
						qualifiedleague[Ltable[2]]="champions league";
						qualifiedleague[Ltable[3]]="champions league";
						qualifiedleague[Ltable[4]]="uefa cup";
						qualifiedleague[Ltable[5]]="uefa cup"; 
						LLcommunityshield=GetCommunity(16,19,"LL");
						ResetClubStats("LL");  Init();}

				}
				if(Week[realweek].fixture[real].kind=="seriea"){
					var Ltable=SortArrLeaguetable(saclubs);
					if(Ltable[0]==global.id)
					{news="Congratulations "+global.managername+", You and your team "+global.team+" have won the Italian Serie A. The board is proud and "+
							" they always knew you would not let them down and wish you more glory in the coming future.";
						global.trophies++;
						global.points++;
						global.majortrophies++;
						global.italianleagues++;money[global.id]+=3000000;Money.GetComponent<Text>().text=money[global.id].ToString();}
					else
					{news=clubname[Ltable[0]]+" have won the Serie A.";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
					ResetLQuals("seriea");
					samatches=ShuffleOtherClubs(saclubs,"seriea"); //xxxxxxxxxxxxxxxxx
					communityshield[Ltable[0]]=true;
					communityshield[italiansupercupwinner]=true;
					qualifiedleague[Ltable[0]]="champions league";
					qualifiedleague[Ltable[1]]="champions league";
					qualifiedleague[Ltable[2]]="champions league";
					qualifiedleague[Ltable[3]]="champions league";
					qualifiedleague[Ltable[4]]="uefa cup";
					qualifiedleague[Ltable[5]]="uefa cup";
					ResetClubStats("SA");   Init();
				}
				if(Week[realweek].fixture[real].kind=="bundesliga"){
					var Ltable=SortArrLeaguetable(blclubs);
					if(Ltable[0]==global.id)
					{news="Congratulations "+global.managername+", You and your team "+global.team+" have won the German Bundesliga. The board is proud and "+
							" they always knew you would not let them down and wish you more glory in the coming future.";
						global.trophies++;
						global.points++;
						global.majortrophies++;
						global.germanleagues++;money[global.id]+=2000000;Money.GetComponent<Text>().text=money[global.id].ToString();}
					else
					{news+=clubname[Ltable[0]]+" have won the Bundesliga. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
					ResetLQuals("bundesliga");//determine ucl and uefa qualifiers relegated and promoted first reset
					blmatches=ShuffleOtherClubs(blclubs,"bundes");
					communityshield[Ltable[0]]=true;
					communityshield[germansupercupwinner]=true;
					qualifiedleague[Ltable[0]]="champions league";
					qualifiedleague[Ltable[1]]="champions league";
					qualifiedleague[Ltable[2]]="champions league";
					qualifiedleague[Ltable[3]]="champions league";
					qualifiedleague[Ltable[4]]="uefa cup";
					qualifiedleague[Ltable[5]]="uefa cup";
					ResetClubStats("BL");   Init();}//xxxxxxxxxxxxxxxxxxx

				//ResetClubStats("PL");//reset all club league and european points and stats
			}
		}
	} 
	if(Week[realweek].fixture[real].kind=="communityshield"){
		if(global.winner==global.id){
			news=global.team+" have won the community shield. Congratulations "+global.managername+", you have won the community shield with the club"+
				" and the board wants to let you know that they are delighted with the achievement and wish you further success in the future.";
			Winner.SetActive(true);Winnertext.GetComponent<Text>().text="You have won the community shield!";
			global.trophies++;
			global.points++;
			global.minortrophies++;
			global.communityshields++;money[global.id]+=500000;Money.GetComponent<Text>().text=money[global.id].ToString();
		}
		else
		{news=clubname[global.winner]+" have won the community shield.";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}

	}
	if(Week[realweek].fixture[real].kind=="eurovase"){
		if(global.winner==global.id){
			news=global.team+" have won the Euro vase trophy. The board would like to thank you "+global.managername+", for "+
				" winning the Euro vase trophy and are very pleased with the achievement.";
			global.trophies++;
			global.points++;
			global.minortrophies++;
			global.eurovases++;money[global.id]+=1000000;Money.GetComponent<Text>().text=money[global.id].ToString();
		}
		else
		{news+=clubname[global.winner]+" have won the Euro vase. ";}
	}
	if(Week[realweek].fixture[real].kind=="leaguecup"){
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Leaguecup_semi[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			Leaguecup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){   
				news="Congratulations, "+global.managername+", you have made "+global.team+" win the league cup and made the board proud.";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.leaguecups++;money[global.id]+=1000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
			{news+=clubname[global.winner]+" have won the League Cup. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
			Leaguecup_round1=Fill_Leaguecup();  Init();//xxxxxxxxxx
		}
	}
	if(Week[realweek].fixture[real].kind=="facup"){
		if(Week[realweek].fixture[real].stage=="playoffs"){
			var position=Week[realweek].fixture[real].match[i].position ;
			FAcup_playoffs2[1,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="playoffs2"){
			var position=Week[realweek].fixture[real].match[i].position;var group=Week[realweek].fixture[real].match[i].group;
			winner_facupplayoff2[position]=global.winner; 
			if(position==3){  
				FaCupPool=Fill_FAcup();
				Fill_FAcup_round1(); Init();}
		}
		if(Week[realweek].fixture[real].stage=="roundof16"){
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			FAcup_quarterfinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			FAcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			FAcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){   
				news="Congratulations, "+global.managername+", you have won the FA cup with "+global.team+" the board would like to express their delight "+
					"for achieving such a good result for the club.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.facups++;money[global.id]+=2000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
			{news+=clubname[global.winner]+" have won the FA Cup. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
			communityshield[global.winner]=true; communityshieldwinner=global.winner; Init();  //add snippet to prevent resetting
		}
	}
	if(Week[realweek].fixture[real].kind=="spanishcup"){
		if(Week[realweek].fixture[real].stage=="roundof16"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Spanishcup_quarterfinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Spanishcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			Spanishcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){   
				news="You have won the Spanish cup with "+global.team+". congratulations on your success and thank you for making the fans and board proud!";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.spanishcups++;money[global.id]+=1000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
				news+=clubname[global.winner]+" have won the Spanish Cup. ";
			communityshield[global.winner]=true; spanishsupercupwinner=global.winner;
			Spanishcup_round1=FillSpanishcup();//xxxxxxxxx
			Init();
		}
	}
	if(Week[realweek].fixture[real].kind=="italiancup"){
		if(Week[realweek].fixture[real].stage=="roundof16"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Italiancup_quarterfinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Italiancup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			Italiancup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){   
				news="You have won the Italian cup with "+global.team+". congratulations on your success and thank you for making the fans and board proud!";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.italiancups++;money[global.id]+=1000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
				news+=clubname[global.winner]+" have won the Italian Cup. ";
			communityshield[global.winner]=true; //italiansupercupwinner=global.winner;
			SAcommunityshield=GetCommunity(16,35,"SA");//xxxxxxxxxx
			Italiancup_round1=FillItaliancup();
			Init();
		}
	}
	if(Week[realweek].fixture[real].kind=="germancup"){
		if(Week[realweek].fixture[real].stage=="roundof16"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Germancup_quarterfinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			Germancup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			Germancup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){   
				news="You have won the German cup with "+global.team+". congratulations on your success and thank you for making the fans and board proud!";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.germancups++;money[global.id]+=1000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
				news+=clubname[global.winner]+" have won the German Cup. ";
			communityshield[global.winner]=true; //germansupercupwinner=global.winner; 
			BLcommunityshield=GetCommunity(16,51,"BL");//xxxxxxxxx
			Germancup_round1=Fillgermancup();  Init();
		}
	}
	if(Week[realweek].fixture[real].kind=="championsleague"){
		if(Week[realweek].fixture[real].stage=="group"){
			clubeupoints[team1]+=global.team1points;
			clubeupoints[team2]+=global.team2points;
			clubeugoals[team1]+=global.team1goals;
			clubeugoals[team2]+=global.team2goals;
			clubyellowcards[team1]+=global.team1cards;
			clubyellowcards[team2]+=global.team2cards; 
			// if(Week[realweek].fixture[real].match[i].position!=null){ bug fix
			if(Week[realweek].fixture[real].match[i].stage=="last"){
				SortChampionsLeagueGroups(); Init();
			} //}
		}

		if(Week[realweek].fixture[real].stage=="roundof16"){
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			if(Week[realweek].fixture[real].type=="aggregate" && Week[realweek].fixture[real].leg=="second")
			{Championsleague_quarterfinal[group,position]=global.winner;ResetClubAggregates(global.winner); Init();}
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ;  var group=Week[realweek].fixture[real].match[i].group;
			if(Week[realweek].fixture[real].type=="aggregate" && Week[realweek].fixture[real].leg=="second")
			{Championsleague_semifinal[group,position]=global.winner;ResetClubAggregates(global.winner); Init();}
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			if(Week[realweek].fixture[real].type=="aggregate" && Week[realweek].fixture[real].leg=="second")
			{Championsleague_final[position]=global.winner;ResetClubAggregates(global.winner); Init();}
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(championsleaguewins[global.id]==0){
					news="Congratulations, "+global.managername+", you have made history by making "+global.team+
						" win the Champions league for the first time ever! The board and fans would like to express their delight at you having achieved ."+
						"such monumental success, an incredible feat that is not easy to do.";Winner.SetActive(true);Winnertext.GetComponent<Text>().text="You have wo the championsleague!";}
				else
					news="Congratulations "+global.managername+", you have mase your team "+global.team+" win the champions league "+championsleaguewins[global.id]+
						" times now, proving that you and your team are among the best clubs in the world.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.championsleagues++;
				championsleaguewins[global.id]++;money[global.id]+=8000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
			{news+=clubname[global.winner]+" have won the Champions League. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
			EUROVase[1]=global.winner;
			Championsleague_group=Fill_championsleague();//xxxxxxxxxxxx
			cwc=global.winner;CWC_semi[1,1]=cwc;  Init();//xxxxxxxxxxxxxxxxxx
		}
	}
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="uefacup"){
		if(Week[realweek].fixture[real].stage=="group"){
			clubeupoints[team1]+=global.team1points;
			clubeupoints[team2]+=global.team2points;
			clubeugoals[team1]+=global.team1goals;
			clubeugoals[team2]+=global.team2goals;
			clubyellowcards[team1]+=global.team1cards;
			clubyellowcards[team2]+=global.team2cards; 
			// if(Week[realweek].fixture[real].match[i].position!=null){
			if(Week[realweek].fixture[real].match[i].stage=="last"){
				SortUefaCupGroups();  Init();
			}// }
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){
			var position=Week[realweek].fixture[real].match[i].position ;  var group=Week[realweek].fixture[real].match[i].group;
			if(Week[realweek].fixture[real].type=="aggregate" && Week[realweek].fixture[real].leg=="second")
			{Uefacup_semifinal[group,position]=global.winner;ResetClubAggregates(global.winner);  Init();}
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			if(Week[realweek].fixture[real].type=="aggregate" && Week[realweek].fixture[real].leg=="second")
			{Uefacup_final[position]=global.winner;ResetClubAggregates(global.winner); Init();}
		}  
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(uefacupwins[global.id]==0)
					news="Congratulations, "+global.managername+", you have made history by making "+global.team+
						" win the European cup for the first time ever! The board and fans would like to express their delight at you having achieved ."+
						"such great success.";
				else
					news="Congratulations "+global.managername+", you have made your team "+global.team+" win the European cup "+uefacupwins[global.id]+
						" times now, keeping the team's tradition and habit of winning trophies.";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.uefacups++;
				uefacupwins[global.id]++;money[global.id]+=4000000;Money.GetComponent<Text>().text=money[global.id].ToString();
			}
			else
			{news+=clubname[global.winner]+" have won the European Cup. ";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;}
			EUROVase[2]=global.winner;
			Uefacup_group=Fill_Uefacup();  Init();//xxxxxxxxxxxxx
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="cwc"){
		if(Week[realweek].fixture[real].stage=="semifinal"){
			var position=Week[realweek].fixture[real].match[i].position ; 
			CWC_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){
				news=global.team+" have won the Club World Cup. Excellent work, "+global.managername+", this "+
					"trophy officially makes "+global.team+" the best football club in the world. The board sends their gratitiude for your success.";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.clubworldcups++;
			}
			else
				news+=clubname[global.winner]+" have won the Club World Cup. ";
		}//xxxxxxxxxxx
	}
	//------------------------------------------------------------------------------
	//----------------------------------------------------------------------------
	if(Week[realweek].fixture[real].kind=="WCQeurope" || Week[realweek].fixture[real].kind=="WCQafrica"  //todo
		|| Week[realweek].fixture[real].kind=="WCQasia" || Week[realweek].fixture[real].kind=="WCQsouthamerica"
		|| Week[realweek].fixture[real].kind=="WCQnorthamerica" || Week[realweek].fixture[real].kind=="WCQoceania"){ //rror fix wcq  in caps
		if(Week[realweek].fixture[real].stage=="group"||Week[realweek].fixture[real].type=="group"||Week[realweek].fixture[real].type=="league"
			|| Week[realweek].fixture[real].type=="knockout"){
			if(Week[realweek].fixture[real].kind=="WCQafrica" &&  Week[realweek].fixture[real].type=="knockout" ){
				WCQAfrica_pool.Add(global.winner); 
				if(Week[realweek].fixture[real].match[i].stage=="last")
				{WCQualifier_af_group=FillWCqualifier_AFgroup(); Init();}     
			}
			else{
				qualpoints[team1]+=global.team1points;
				qualpoints[team2]+=global.team2points;
				qualgoals[team1]+=global.team1goals;
				qualgoals[team2]+=global.team2goals;
				qualyellowcards[team1]+=global.team1cards;      //if(Week[realweek].fixture[real].kind=="WCQnorthamerica")Debug.Log("played na wcq gr");
				qualyellowcards[team2]+=global.team2cards;       //if(Week[realweek].fixture[real].kind=="WCQafrica")Debug.Log("played af wcq gr");
				//if(Week[realweek].fixture[real].match[i].position!=null){ bug fix
				if(Week[realweek].fixture[real].match[i].stage=="last"){ Debug.Log("last wc qual");
					if(Week[realweek].fixture[real].kind=="WCQeurope")
					{SortWCQGroups(7,6,"europe");ResetCountryQualStats("europe"); }
					if(Week[realweek].fixture[real].kind=="WCQafrica")
					{SortWCQGroups(5,5,"africa"); ResetCountryQualStats("africa");}
					if(Week[realweek].fixture[real].kind=="WCQasia")
					{SortWCQGroups(4,5,"asia"); ResetCountryQualStats("asia");}
					if(Week[realweek].fixture[real].kind=="WCQsouthamerica")
					{SortWCQGroups(1,10,"southamerica"); 
						worldcup_draw();    //draw all qualified teams to wc groups from pool
						ResetCountryQualStats("southamerica");}
					if(Week[realweek].fixture[real].kind=="WCQnorthamerica")
					{SortWCQGroups(1,16,"northamerica"); ResetCountryQualStats("enorthamerica");}
					if(Week[realweek].fixture[real].kind=="WCQoceania")
					{SortWCQGroups(1,8,"oceania"); ResetCountryQualStats("oceania");}
					Init();
				} }
		}
		/*if(Week[realweek].fixture[real].stage=="playoff" && Week[realweek].fixture[real].kind=="WCQafrica"){
     wcqafrica_pool.Add(global.winner);
     if(Week[realweek].fixture[real].match[i].stage=="last")
      WCQAfrica_groups(); Init();}*/
	}
	////////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="worldcup"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 
			// if(Week[realweek].fixture[real].match[i].position!=null){
			if(Week[realweek].fixture[real].match[i].stage=="last"){
				SortWorldcupKO(); Init();
			} //}
		}
		if(Week[realweek].fixture[real].stage=="roundof16"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			worldcup_quarterfinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			worldcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			worldcup_final[position]=global.winner; 
			worldcup_third[position]=global.loser; Init(); Debug.Log( worldcup_third[position]+" "+global.loser);
		} 
		if(Week[realweek].fixture[real].stage=="3rdplace"){    
			if(global.winner==global.id){
				news="You have won third place!";Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news;global.thirdplaces++;}
		} 
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(wcwins[global.id]==0)  
					news=global.team+" win the World cup! congratulations "+global.managername+", you have helped "+global.team+" win the world cup for "+
						"the first time ever! An incredible achievement that only 8 countries on the planet have ever won. "+global.managername+" has now "+
						"become one of the best managers in the world in football and you will forever leave your mark in history.";
				else
					news=global.team+" have won the world cup "+wcwins[global.id]+" times now. Congratulations, "+global.managername+" on achieving this"+
						" remarkable feat proving that you are one of the greatest managers out there, the board would like to express their delight.";
				global.trophies++;
				global.points+=2;
				global.majortrophies++;
				global.worldcups++;
				wcwins[global.id]++;
			}
			else
			{news+=countryname[global.winner]+" have won the World Cup. "; wcwins[global.winner]++;Winner.SetActive(true);Winnertext.GetComponent<Text>().text=news; }//reset all temp stats 
			ResetCountryStats("europe");ResetCountryStats("africa");ResetCountryStats("asia");ResetCountryStats("southamerica");
			ResetCountryStats("northamerica");   ResetCountryStats("oceania");
			WCQualifier_playoff=FillWCQualifier_playoffAF();
			WCQualifier_eu_group=FillWCquals("europe");  //7 groups of 6
			WCQualifier_as_group=FillWCquals("asia");   //4 groups of 5
			//WCQualifier_af_group=FillWCqualifier_playoffAF("africa"); //set after playoff
			WCQualifier_oc_group=FillWCQuals2("oceania");   //8 teams in one league
			WCQualifier_na_group=FillWCQuals2("northamerica"); //1 group of 16
			WCQualifier_sa_group=FillWCQuals2("southamerica");  Init();//xxxxxxxxx
		}
		/*if(Week[realweek].fixture[real].stage=="3rdplace" && global.winner==global.id)
   {
   global.thirdplaces++;
   }*/
	}
	//////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="euroquals" || Week[realweek].fixture[real].kind=="afconquals"  ){
		qualpoints[team1]+=global.team1points;
		qualpoints[team2]+=global.team2points;
		qualgoals[team1]+=global.team1goals;
		qualgoals[team2]+=global.team2goals;
		qualyellowcards[team1]+=global.team1cards;
		qualyellowcards[team2]+=global.team2cards; 

		if(Week[realweek].fixture[real].match[i].stage=="last"){ Debug.Log("last eu/af qual");
			if(Week[realweek].fixture[real].kind=="euroquals")
			{SortGroups("europe",8,5);ResetCountryQualStats("europe"); }
			if(Week[realweek].fixture[real].kind=="afconquals")
			{SortGroups("africa",8,6); ResetCountryQualStats("africa");}
			Init();
		}

	}
	////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="euro"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 

			if(Week[realweek].fixture[real].match[i].stage=="last"){
				SortKO("euro",4,4); Init();
			} 
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			EURO_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			EURO_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" have won the Euro cup! congratulations "+global.managername+", you have helped "+global.team+" win the Euro cup for "+
						"the first time ever! A remarkable feat that makes "+global.team+" become the kings of Europe. Your hard work puts you up there among "+
						"the greatest managers in the game and the board is pleased that you put your mark in history of football.";
				else
					news=global.team+" have won the Euro cup "+rcwins[global.id]+" times now. Congratulations, "+global.managername+" on achieving this"+
						" remarkable feat proving that you are one of the greatest managers out there, the board would like to express their delight.";
				global.trophies++;
				global.points+=2;
				global.majortrophies++;
				global.euros++;
				rcwins[global.id]++;
			}
			else
			{news+=countryname[global.winner]+" have won the Euro Cup. "; rcwins[global.winner]++; }
			//reset all temp stats after tournament for nations and season for clubs
			CONFEDcup_semifinal[2,1]=global.winner;
			ResetCountryStats("europe");
			EUROqualifier_group=FillEUROquals();  Init();//xxxxxxx
		}
	}
	/////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="afcon"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 
			//if(Week[realweek].fixture[real].match[i].position!=null){
			if(Week[realweek].fixture[real].match[i].stage=="last"){
				SortKO("afcon",4,4); Init();
			} //}
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			AFCON_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			AFCON_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" win the African Cup! congratulations "+global.managername+", you have won the African cup with "+global.team+
						"for the first time ever! Making the country the kings of African Football. The board wishes you further success to climb to higher heights";
				else
					news=global.team+" have won the African cup "+rcwins[global.id]+" times now. Congratulations, "+global.managername+" on achieving this"+
						" success and showing that you have the reputation and calibre of winning trophies.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.afconcups++;
				rcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the African Cup."; rcwins[global.winner]++; }
			ResetCountryStats("africa");CONFEDcup_round1[2,1]=global.winner;
			AFCONqualifier_group=FillAfconquals(); Init();//xxxxx
		}
	}
	/////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="goldcup"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 
			if(Week[realweek].fixture[real].match[i].position!=null){
				if(Week[realweek].fixture[real].match[i].stage=="last"){
					SortKO("goldcup",4,4); Init();
				} }
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			Goldcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			Goldcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" have won their first ever Gold Cup! congratulations "+global.managername+" on showing that you are the manager "+
						"that has the ability to mine silverware.";
				else
					news=global.team+" have won the Gold cup "+rcwins[global.id]+" times now. Congratulations, "+global.managername+" on your "+
						"determination to make the journey to reach the top of the world on the football manager department.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.goldcups++;
				rcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Gold Cup.";  //reset all temp stats after tournament for nations and season for clubs
				rcwins[global.winner]++;}
			ResetCountryStats("northamerica");  CONFEDcup_round1[1,1]=global.winner;  Init();
		}
	}
	/////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="copa"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 
			if(Week[realweek].fixture[real].match[i].position!=null){
				if(Week[realweek].fixture[real].match[i].stage=="last"){
					SortKO("copa",2,5); Init();
				} }
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			Copa_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" have won the Copa America for the first time! congratulations "+global.managername+" on "+
						"leading your team to glory and the board and fans wish you further success in your endeavours.";
				else
					news=global.team+" have won the Copa America "+rcwins[global.id]+" times now. Congratulations, "+global.managername+" on achieving this"+
						" impressive feat proving that you are the right manager for the job.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.copaamericas++;
				rcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Copa America."; rcwins[global.winner]++; }
			ResetCountryStats("southamerica");CONFEDcup_round1[1,2]=global.winner; Init();
		}
	}
	/////////////////////////////////////////////////////////////////////////////////
	if(Week[realweek].fixture[real].kind=="asiancup"){
		if(Week[realweek].fixture[real].stage=="group"){
			points[team1]+=global.team1points;
			points[team2]+=global.team2points;
			goals[team1]+=global.team1goals;
			goals[team2]+=global.team2goals;
			yellowcards[team1]+=global.team1cards;
			yellowcards[team2]+=global.team2cards; 
			if(Week[realweek].fixture[real].match[i].position!=null){
				if(Week[realweek].fixture[real].match[i].stage=="last"){
					SortKO("asiancup",4,4); Init();
				} }
		}
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			ASIANcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			ASIANcup_final[position]=global.winner; Init();
		}

		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" win the Asian cup for the first time! "+global.managername+", you have made "+global.team+" kings of Asia "+
						"and the board and fans would like to share their gratitude on achieving this success!";
				else
					news=global.team+" have won the asian cup "+rcwins[global.id]+" times now. Congratulations, "+global.managername+", you have "+
						"made the board and the nation proud and have secured your reputation as one of the most capable managers out there.";
				global.trophies++;
				global.points++;
				global.majortrophies++;
				global.asiancups++;
				rcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Asian Cup."; rcwins[global.winner]++; }
			ResetCountryStats("asia");CONFEDcup_semifinal[2,2]=global.winner; Init();
		}
	}
	/////////////////////////////////////////////////////////////////////////////////ko
	if(Week[realweek].fixture[real].kind=="ocncup"){
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; var group=Week[realweek].fixture[real].match[i].group;
			ONCcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			ONCcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				if(rcwins[global.id]==0)  
					news=global.team+" win the Ocean Nations cup for the first time! Congratulations "+global.managername+".";
				else
					news=global.team+" have won the onc cup "+rcwins[global.id]+" times now. Congratulations, "+global.managername+", you are "+
						"getting into the habit of winning trophies.";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.oceancups++;
				rcwins[global.id]++;
			}
			else
			{news+=countryname[global.winner]+" have won the Ocean Nations Cup."; rcwins[global.winner]++; }
			ResetCountryStats("oceania");CONFEDcup_round1[2,2]=global.winner;
			if(global.category=="countries")  //reset it after 2 years
				Friendly=MakeFriendlies();
			FillCups();  Init();// re fill all minor 2 year cups
		}
	}
	/////////////////////////////////////////////////////////////////////////////////ko
	if(Week[realweek].fixture[real].kind=="cecafacup"){

		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			CECAFAcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			CECAFAcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				news=global.team+" have won the cecafa cup "+lcwins[global.id]+1+" times now. Congratulations, "+global.managername+".";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.cecafacups++;
				lcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Cecafa Cup."; lcwins[global.winner]++; }
		}

	}
	/////////////////////////////////////////////////////////////////////////////////ko
	if(Week[realweek].fixture[real].kind=="cosafacup"){

		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var  group=Week[realweek].fixture[real].match[i].group;
			COSAFAcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			COSAFAcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				news=global.team+" have won the cosafa cup "+lcwins[global.id]+1+" times now. Congratulations, "+global.managername+".";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.cosafacups++;
				lcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Cosafa Cup."; lcwins[global.winner]++; }
		}

	}
	if(Week[realweek].fixture[real].kind=="seagames"){  
		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var  group=Week[realweek].fixture[real].match[i].group;
			SEAgames_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			SEAgames_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				news=global.team+" have won the sea games "+global.seagames+1+" times now. Congratulations, "+global.managername+".";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.seagames++;
				lcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the Sea Games."; lcwins[global.winner]++; }
		} 
	}
	/////////////////////////////////////////////////////////////////////////////////ko
	if(Week[realweek].fixture[real].kind=="cabralcup"){

		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			CABRALcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			CABRALcup_final[position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				news=global.team+" have won the West African cup "+lcwins[global.id]+1+" times now. Congratulations, "+global.managername+".";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.cabralcups++;
				lcwins[global.id]++;
			}
			else
			{news=countryname[global.winner]+" have won the West African Cup."; lcwins[global.winner]++; }
			fill_yearly_cups();  Init();//xxxxxxxxxxxx
		}

	}
	/////////////////////////////////////////////////////////////////////////////////ko 
	if(Week[realweek].fixture[real].kind=="confed"){

		if(Week[realweek].fixture[real].stage=="quarterfinal"){   
			var position=Week[realweek].fixture[real].match[i].position ;var group=Week[realweek].fixture[real].match[i].group;
			CONFEDcup_semifinal[group,position]=global.winner; Init();
		}
		if(Week[realweek].fixture[real].stage=="semifinal"){   
			var position=Week[realweek].fixture[real].match[i].position ; 
			CONFEDcup_final[position]=global.winner;  Init();      //fix
		}
		if(Week[realweek].fixture[real].stage=="final"){
			if(global.winner==global.id){ 
				news=global.team+" have won the Confederations cup, Congratulations, "+global.managername+", "+
					"this proves that "+global.team+" are the best national team in "+global.category+" and better than the other regional champions.";
				global.trophies++;
				global.points++;
				global.minortrophies++;
				global.confederationscups++;
			}
			else
			{news=countryname[global.winner]+" have won the Confederations Cup."; }
		}
	}
	//---------------------------------------------------------------------------------
}//fixresults

//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
List<int> SortLeaguetable(List<int> tables){
	var group=new List<int>();
	group.AddRange(tables);
	for(int i=0;i<group.Count;i++){    //zero because group is a setarate pool
		for(int k=i+1;k<group.Count;k++){
			if(clubleaguepoints[group[k]]>clubleaguepoints[group[i]]){  //if second higher than base
				var temp=group[i]; group[i]=group[k];           //swap positions
				group[k]=temp;}
		}
	}                      //nrxt sort by goals
	for(int m=0;m<group.Count;m++){
		for(int j=m+1;j<group.Count;j++){
			if(clubleaguepoints[group[m]]==clubleaguepoints[group[j]]){                                  //work on those of the same points
				if(clubgoals[group[j]]>clubgoals[group[m]]){  //if second higher than base
					var temp=group[m]; group[m]=group[j];           //swap positions
					group[j]=temp;}
			}
		}
	}
	return group;
}

List<int>  SortArrLeaguetable ( List<int> tables  ){
	var group=new List<int>();
	group.AddRange(tables);
	for(int i=0;i<group.Count;i++){    //zero because group is a setarate pool
		for(int k=i+1;k<group.Count;k++){
			if(clubleaguepoints[group[k]]>clubleaguepoints[group[i]]){  //if second higher than base
				var temp=group[i]; group[i]=group[k];           //swap positions
				group[k]=temp;}
		}
	}                      //nrxt sort by goals
	for(int m=0;m<group.Count;m++){
		for(int j=m+1;j<group.Count;j++){
			if(clubleaguepoints[group[m]]==clubleaguepoints[group[j]]){                                  //work on those of the same points
				if(clubgoals[group[j]]>clubgoals[group[m]]){  //if second higher than base
					var temp=group[m]; group[m]=group[j];           //swap positions
					group[j]=temp;}
			}
		}
	}
	return group;
	//return temptable;
}

void  ResetPLQuals (){
	for(int i=0;i<18;i++)
	{qualifiedleague[plclubs[i]]="";
		communityshield[plclubs[i]]=false;
		clubleaguecup[plclubs[i]]=false;}
}
void  ResetLQuals ( string league  ){
	for(int i=0;i<16;i++)
	{if(league=="laliga"){
			qualifiedleague[llclubs[i]]="";
			communityshield[llclubs[i]]=false;
		}
		if(league=="seriea"){
			qualifiedleague[saclubs[i]]="";
			communityshield[saclubs[i]]=false;
		}
		if(league=="bundesliga"){
			qualifiedleague[blclubs[i]]="";
			communityshield[blclubs[i]]=false;
			clubleaguecup[blclubs[i]]=false;}
	}
}

void  SortChampionsLeagueGroups (){
	//FIXME_VAR_TYPE group=new List<int>();
	var group=new int[4];
	for(int i=1;i<=8;i++){
		for(int j=1;j<=4;j++){
			group[j-1]=Championsleague_group[i,j];  }

		for(int f=0;f<group.Length;f++){    //zero because group is a setarate pool
			for(int k=f+1;k<group.Length;k++){
				if(Control.clubeupoints[group[k]]>Control.clubeupoints[group[f]]){  //if second higher than base
					var temp=group[f]; group[f]=group[k];           //swap positions
					group[k]=temp;}
			}
		}                      //nrxt sort by goals
		for(int m=0;m<group.Length;m++){
			for(int g=m+1;g<group.Length;g++){
				if(Control.clubeupoints[group[m]]==Control.clubeupoints[group[g]]){                                  //work on those of the same points
					if(Control.clubeugoals[group[g]]>Control.clubeugoals[group[m]]){  //if second higher than base
						var temp=group[m]; group[m]=group[g];           //swap positions
						group[g]=temp;}
				}
			}
		}

		Championsleague_round16[i,1]=group[0];
		Championsleague_round16[i,2]=group[1];
	}
}

void  SortUefaCupGroups (){
	//FIXME_VAR_TYPE group=new List<int>();
	var group=new int[4];
	for(int i=1;i<=4;i++){
		for(int j=1;j<=4;j++){  //bug fix
			group[j-1]=Uefacup_group[i,j];  }

		for(int f=0;f<group.Length;f++){    //zero because group is a setarate pool
			for(int k=f+1;k<group.Length;k++){
				if(Control.clubeupoints[group[k]]>Control.clubeupoints[group[f]]){  //if second higher than base
					var temp=group[f]; group[f]=group[k];           //swap positions
					group[k]=temp;}
			}
		}                      //nrxt sort by goals
		for(int m=0;m<group.Length;m++){
			for(int g=m+1;g<group.Length;g++){
				if(Control.clubeupoints[group[m]]==Control.clubeupoints[group[g]]){                                  //work on those of the same points
					if(Control.clubeugoals[group[g]]>Control.clubeugoals[group[m]]){  //if second higher than base
						var temp=group[m]; group[m]=group[g];           //swap positions
						group[g]=temp;}
				}
			}
		}

		Uefacup_quarterfinal[i,1]=group[0];
		Uefacup_quarterfinal[i,2]=group[1];
	}
}

void  SortWCQGroups ( int groups ,  int teams ,  string region  ){
	var group=new List<int>();
	//FIXME_VAR_TYPE grouped=new int[4];
	for(int i=1;i<=groups;i++){ Debug.Log(i);
		for(int j=1;j<=teams;j++){ //bug fix
			if(region=="europe")
				group.Add(WCQualifier_eu_group[i,j]);
			if(region=="africa")
				group.Add(WCQualifier_af_group[i,j]);
			if(region=="asia")
				group.Add(WCQualifier_as_group[i,j]);
			if(region=="southamerica")
				group.Add(WCQualifier_sa_group[j]);
			if(region=="oceania")
				group.Add(WCQualifier_oc_group[j]);
			if(region=="northamerica")
				group.Add(WCQualifier_na_group[j]);  }

		for(int v=0;v<group.Count-1;v++){
			for(int k=i+1;k<group.Count;k++){
				if(qualpoints[group[k]]>qualpoints[group[v]]){  //if second higher than base
					var temp=group[v]; group[v]=group[k];           //swap positions
					group[k]=temp;}
			}
		}                      //nrxt sort by goals
		for(int m=0;m<group.Count-1;m++){
			for(int j=m+1;j<group.Count;j++){
				if(qualpoints[group[m]]==qualpoints[group[j]]){                                  //work on those of the same points
					if(qualgoals[group[j]]>qualgoals[group[m]]){  //if second higher than base
						var temp=group[m]; group[m]=group[j];           //swap positions
						group[j]=temp;}
				}
			}
		}
		/* FIXME_VAR_TYPE k=0;////
  foreach(var team in group){
  FIXME_VAR_TYPE top=team;
  for(j=0;j<group.length;j++){
     if(qualpoints[group[j]]>qualpoints[top] && group[j]!=top)
      {top=group[j];}
  }//
  grouped[k]=top;
  group.Remove(top);k++;
  }
   for(i=0;i<grouped.length;i++){ //re-sort teams of same points  
  FIXME_VAR_TYPE points=qualpoints[grouped[i]]; //points of club id
   for(int j=0;j<grouped.length;j++){
    if( j!=i && qualpoints[grouped[j]]==points){ //points same as chosen club
     if(qualgoals[grouped[j]]>qualgoals[grouped[i]] && j>i)
      {int temp;
       temp=grouped[i];grouped[i]=grouped[j];grouped[j]=temp;}
     }
     }
  }*/
		if(region=="europe"){
			worldcup_pool.Add(group[0]);Debug.Log("eu "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[1]); Debug.Log("eu "+i+" "+group[1]);if(group[1]==global.id)news="You have qualified for the world cup.";}
		if(region=="africa")
		{ worldcup_pool.Add(group[0]);Debug.Log("af "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";}
		if(region=="asia")
		{worldcup_pool.Add(group[0]);Debug.Log("as "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";}
		if(region=="southamerica"){
			worldcup_pool.Add(group[0]);Debug.Log("sa "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[1]);Debug.Log("sa "+i+" "+group[1]); if(group[1]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[2]);Debug.Log("sa "+i+" "+group[2]); if(group[2]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[3]);Debug.Log("sa "+i+" "+group[3]); if(group[3]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[4]);Debug.Log("sa "+i+" "+group[4]); if(group[4]==global.id)news="You have qualified for the world cup.";
		}
		if(region=="northamerica"){
			worldcup_pool.Add(group[0]);Debug.Log("na "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[1]);Debug.Log("na "+i+" "+group[1]); if(group[1]==global.id)news="You have qualified for the world cup.";
			worldcup_pool.Add(group[2]);Debug.Log("na "+i+" "+group[2]); if(group[2]==global.id)news="You have qualified for the world cup.";}
		if(region=="oceania")
		{worldcup_pool.Add(group[0]);Debug.Log("o "+i+" "+group[0]); if(group[0]==global.id)news="You have qualified for the world cup.";}
		group.Clear();
	}//each group
}

void  worldcup_draw (){
	int[] giants={3,15,140,48,41,94,68,52}; 
	for(int i=1;i<=8;i++){
		foreach( var team in worldcup_pool){  //add giants first
			if(team.Equals(giants[i-1]))
			{worldcup_group[i,1]=giants[i-1];
				worldcup_pool.Remove(giants[i-1]);break;
			}     
		}
	}
	for(int i=1;i<=8;i++){
		for(int j=1;j<=4;j++)
			if(worldcup_group[i,j]==0)
			{ var choice=Random.Range(0,worldcup_pool.Count);
				worldcup_group[i,j]=worldcup_pool[choice];worldcup_pool.RemoveAt(choice);}
	}

}

/*void  WCQAfrica_groups (){  //sets world cup africa qualifier groups from  pool
 for(FIXME_VAR_TYPE i=1;i<=5;i++){
  for(FIXME_VAR_TYPE j=1;j<=5;j++){
    FIXME_VAR_TYPE choice=Random.Range(0,wcqafrica_pool.length);
   WCQualifier_af_group[i,j]=wcqafrica_pool[choice]; wcqafrica_pool.RemoveAt(choice);
                }
 } 
}*/
///////////////////////////////////////////////////////////////////////////////////////////////////
void  SortGroups ( string conf ,  int groups ,  int teams  ){  //sort tables tops for tournament groups
	var group=new List<int>();
	var grouped=new int[teams]; var pool=new List<int>();  //fix at grouped size
	for(int i=1;i<=groups;i++){  
		for(int j=1;j<=teams;j++){ //bug fix
			if(conf=="africa")
				group.Add(AFCONqualifier_group[i,j]);  
			else
				group.Add(EUROqualifier_group[i,j]);
		}
		int k=0;
		foreach(var team in group){
			var top=team;
			for(int j=0;j<group.Count;j++){
				if(qualpoints[group[j]]>qualpoints[top] && group[j]!=top)
				{top=group[j];}
			}//
			grouped[k]=top;
			group.Remove(top);k++;
		}
		for(int j=0;j<3;j++){
			if(qualpoints[grouped[j]]==qualpoints[grouped[j+1]]){
				if(qualgoals[grouped[j+1]]>qualgoals[grouped[j]])
				{ var temp=grouped[j];grouped[j]=grouped[j+1];grouped[j+1]=temp; }} 
		}  
		pool.Add(grouped[0]);   //add top 2 each table
		pool.Add(grouped[1]);
	}
	for(int i=1;i<=4;i++){     //now add the pool to groups
		for(int j=1;j<=4;j++){
			if(conf=="europe")
			{ var choice=Random.Range(0,pool.Count);
				EURO_group[i,j]=pool[choice];pool.RemoveAt(choice);}
			else
			{ var choice=Random.Range(0,pool.Count);
				AFCON_group[i,j]=pool[choice];pool.RemoveAt(choice);}
		}
	}
}
////////////////////////////////////////////////////////////////////////////////////////
void  SortWorldcupKO (){ Debug.Log("sorting wc ko");
	var group=new List<int>();
	var grouped=new int[4];
	for(int i=1;i<=8;i++){
		for(int j=1;j<=4;j++){
			group.Add(worldcup_group[i,j]);  }
		int k=0;
		foreach(var team in group){
			var top=team;
			for(int j=0;j<group.Count;j++){
				if(points[group[j]]>points[top] && group[j]!=top)
				{top=group[j];}
			}//
			grouped[k]=top;
			group.Remove(top);k++;
		}
		for(int j=0;j<3;j++){
			if(points[grouped[j]]==points[grouped[j+1]]){
				if(goals[grouped[j+1]]>goals[grouped[j]])
				{ var temp=grouped[j];grouped[j]=grouped[j+1];grouped[j+1]=temp; }}
		}
		worldcup_round16[i,1]=grouped[0];
		worldcup_round16[i,2]=grouped[1]; //  reset team stats after tournament
	}
}
////////////////////////////////////////////////////////////////////////////////////////////
void  SortKO ( string tourni ,  int groups ,  int teams  ){
	var group=new List<int>();
	var grouped=new int[teams];
	for(int i=1;i<=groups;i++){
		for(int j=1;j<=teams;j++){ //error fix
			if(tourni=="euro")
				group.Add(EURO_group[i,j]);
			if(tourni=="afcon")
				group.Add(AFCON_group[i,j]);
			if(tourni=="asiancup")
				group.Add(ASIANcup_group[i,j]);
			if(tourni=="goldcup")
				group.Add(Goldcup_group[i,j]);
			if(tourni=="copa")
				group.Add(CopaAmerica[i,j]);
		}
		int k=0;
		foreach(var team in group){
			var top=team;
			for(int j=0;j<group.Count;j++){
				if(points[group[j]]>points[top] && group[j]!=top)
				{top=group[j];}
			}//
			grouped[k]=top;
			group.Remove(top);k++;
		}
		for(int j=0;j<teams-1;j++){
			if(points[grouped[j]]==points[grouped[j+1]]){
				if(goals[grouped[j+1]]>goals[grouped[j]])
				{ var temp=grouped[j];grouped[j]=grouped[j+1];grouped[j+1]=temp; }}
		}
		if(tourni=="euro"){
			EURO_quarterfinal[i,1]=grouped[0];
			EURO_quarterfinal[i,2]=grouped[1];} //  reset team stats after tournament
		if(tourni=="afcon"){
			AFCON_quarterfinal[i,1]=grouped[0];  //winner qualifies for confed cup
			AFCON_quarterfinal[i,2]=grouped[1];}
		if(tourni=="asiancup"){
			ASIANcup_quarterfinal[i,1]=grouped[0];
			ASIANcup_quarterfinal[i,2]=grouped[1];}
		if(tourni=="goldcup"){
			Goldcup_quarterfinal[i,1]=grouped[0];
			Goldcup_quarterfinal[i,2]=grouped[1];}
		if(tourni=="copa"){
			Copa_semifinal[i,1]=grouped[0];
			Copa_semifinal[i,2]=grouped[1];}
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////
void  ResetClubStats ( string league  ){
	for(int i=1;i<=96;i++){
		clubaggregate[i]=0;///////////
		clubgoals[i]=0;///////////////
		clubeupoints[i]=0;////////////////european competition points
		clubeugoals[i]=0;
		if(league=="PL" &&( i<19 || i==67 || i==69 || i==69)){
			clubleaguepoints[i]=0;///league points
			clubyellowcards[i]=0;///////////
			clubawaygoals[i]=0;}
		else if(league=="LL" && i>18 && i<35){
			clubleaguepoints[i]=0;///league points
			clubyellowcards[i]=0;///////////
			clubawaygoals[i]=0;}
		else if(league=="SA" && i>34 && i<51){
			clubleaguepoints[i]=0;///league points
			clubyellowcards[i]=0;///////////
			clubawaygoals[i]=0;}
		else if(league=="BL" && i>50 && i!=67 && i!=68 && i!=69){
			clubleaguepoints[i]=0;///league points
			clubyellowcards[i]=0;///////////
			clubawaygoals[i]=0;}
	}
}

void  ResetClubAggregates ( int winner  ){

	clubaggregate[winner]=0;///////////
	clubawaygoals[winner]=0;
}

void  ResetCountryQualStats ( string conf  ){
	for(int i=1;i<=146;i++){
		if(region[i]==conf){
			qualgoals[i]=0;  //remember to clean these stats after each competition
			qualpoints[i]=0;
			qualyellowcards[i]=0;}}
}

void  ResetCountryStats ( string conf  ){
	for(int i=1;i<=146;i++){
		if(region[i]==conf){
			goals[i]=0;
			points[i]=0;// major competition points
			yellowcards[i]=0;}}
}

//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int[,,]  ShufflePLClubs (){
	int i=1;
	var clubs=new List<int>(plclubs);

	while(clubs.Count>0){
		var d=Random.Range(0,clubs.Count-1);
		plclub[i]=clubs[d];  
		clubs.RemoveAt(d);
		i++;
	}
	FillPLMatches();                    
	return plmatches;
}
/////////////////////////////////////////////////////////////////////////////////////////
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int[,,]  ShuffleOtherClubs ( List<int> Oclubs ,  string league  ){
	int i=1;
	var clubs=new List<int>(Oclubs);

	while(clubs.Count>0){
		var d=Random.Range(0,clubs.Count-1);
		club[i]=clubs[d];  
		clubs.RemoveAt(d);
		i++;
	}

	FillMatches(league);
	if(league=="laliga")                    
		return llmatches;
	if(league=="seriea")                    
		return samatches;
	if(league=="bundes")                    
		return blmatches;
	else return null;

}////////////////////////////////////////////////////////////////////////////////////////////////////////

int[]  GetCommunity ( int count ,  int startteam ,  string league  ){  //bug fix on index diff
	int[] team=new int[3];
	for(int i=startteam;i<startteam+count;i++){  //bug fix
		if(league=="PL"){
			if(communityshield[plclubs[i-1]]==true){    //fix to correct format
				if(team[1]==0)   //bug fix
					team[1]=i;
				else
					team[2]=i;
			} 
		}////////////
		else{
			if(communityshield[i]==true){    //fix to correct format
				if(team[1]==0)   //bug fix
					team[1]=i;
				else
					team[2]=i;
			} 
		}////////////

	}
	return team;
}

//////////////////////////////////////////////////////////////////////////

int[,]  Fill_Facup_playoffs (){

	FAcup_playoffs2[1,1]=winner_facupplayoff1[1];
	FAcup_playoffs2[1,2]=winner_facupplayoff1[2];                           
	FAcup_playoffs2[2,1]=plclubs[14];
	FAcup_playoffs2[2,2]=plclubs[15];
	FAcup_playoffs2[3,1]=plclubs[13];
	FAcup_playoffs2[3,2]=plclubs[16];
	return FAcup_playoffs2;
}
//////////////////////////////////////////////////////////////////////////
int[]  Fill_FAcup (){
	var pool=new int[17];
	for (int i=1;i<=13;i++){
		FaCupPool[i]=plclubs[i];
	}
	FaCupPool[14]=winner_facupplayoff2[1];
	FaCupPool[15]=winner_facupplayoff2[2];
	FaCupPool[16]=winner_facupplayoff2[3];
	return FaCupPool;
}
///////////////////////////////////////////////////////////////////////
void  Fill_FAcup_round1 (){
	List<int> numbers=new List<int>(); //FIXME_VAR_TYPE range=[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16];
	numbers.AddRange(new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});
	int[] pool=new int[16];
	for(int i=0;i<pool.Length;i++){
		int number=Random.Range(0,numbers.Count);
		pool[i]=FaCupPool[numbers[number]];
		numbers.RemoveAt(number);
	}
	int k=0;
	for(int v=1;v<=8;v++){
		FAcup_round1[v,1]=pool[k];k++;
		FAcup_round1[v,2]=pool[k];k++;
	}
}
////////////////////////////////////////////////////////////
int[,] Fill_Leaguecup (){ 
	int[] pool=new int[17]; var clubs=new List<int>();
	for(int i=0;i<=17;i++){
		if(clubleaguecup[plclubs[i]]==true)
		{ clubs.Add(plclubs[i]);}
	}  
	for(int i=1;i<=16;i++){              //add random teams to pool
		int dice=Random.Range(0,clubs.Count);
		pool[i]=clubs[dice]; 
		clubs.RemoveAt(dice);
	}
	Leaguecup_round1[1,1]=pool[1];
	Leaguecup_round1[1,2]=pool[2];
	Leaguecup_round1[2,1]=pool[3];
	Leaguecup_round1[2,2]=pool[4];
	Leaguecup_round1[3,1]=pool[5];
	Leaguecup_round1[3,2]=pool[6];
	Leaguecup_round1[4,1]=pool[7];
	Leaguecup_round1[4,2]=pool[8];
	Leaguecup_round1[5,1]=pool[9];
	Leaguecup_round1[5,2]=pool[10];
	Leaguecup_round1[6,1]=pool[11];
	Leaguecup_round1[6,2]=pool[12];
	Leaguecup_round1[7,1]=pool[13];
	Leaguecup_round1[7,2]=pool[14];
	Leaguecup_round1[8,1]=pool[15];
	Leaguecup_round1[8,2]=pool[16];
	return Leaguecup_round1;
}
//////////////////////////////////////////////////////////////////////////
//void  Fill_FAcup_playoffs (){

//}
/////////////////////////////////////////////////////////////////////////
int[,]  Fill_championsleague (){
	int[] pool=new int[33]; var clubs=new List<int>();
	for(int i=0;i<=17;i++){                  //fill clubs in each league that qualify for champions league
		if(qualifiedleague[plclubs[i]]=="champions league")
		{clubs.Add(plclubs[i]);}
	}
	for(int i=0;i<=15;i++){                  //
		if(qualifiedleague[llclubs[i]]=="champions league")  
		{clubs.Add(llclubs[i]);}
	}
	for(int i=0;i<=15;i++){                  //
		if(qualifiedleague[saclubs[i]]=="champions league")
		{clubs.Add(saclubs[i]);}
	}
	for(int i=0;i<=15;i++){                  //
		if(qualifiedleague[blclubs[i]]=="champions league")  //typo fix
		{clubs.Add(blclubs[i]);}  
	}
	for(int i=0;i<=15;i++)          //next add other non playable clubs        
		clubs.Add(unplayableUCL[i]);

	for(int i=1;i<=32;i++){          //add random teams to pool
		int dice=Random.Range(0,clubs.Count-1);  //bug fix
		//if(clubs.length>0)
		pool[i]=clubs[dice];
		clubs.RemoveAt(dice);
	} int v=1;
	for (int i=1;i<=8;i++){               //add champions league 8 groups of 4 teams
		Championsleague_group[i,1]=pool[v];v++;
		Championsleague_group[i,2]=pool[v];v++;
		Championsleague_group[i,3]=pool[v];v++;
		Championsleague_group[i,4]=pool[v];v++;
		//v+=4;
	}
	return Championsleague_group;
}
////////////////////////////////////////////////////////////////////////

int[,]  Fill_Uefacup (){
	int[] pool=new int[17]; var clubs=new List<int>();
	//first reset qualified leagues

	for(int i=0;i<plclubs.Count;i++){                  //fill clubs in each league that qualify for uefa cup  former 17
		if(qualifiedleague[plclubs[i]]=="uefa cup")
		{clubs.Add(plclubs[i]);}
	}
	for(int i=0;i<=15;i++){                  
		if(qualifiedleague[llclubs[i]]=="uefa cup")  //bug fixes
		{clubs.Add(llclubs[i]); }
	}
	for(int i=0;i<=15;i++){                  
		if(qualifiedleague[saclubs[i]]=="uefa cup")
		{clubs.Add(saclubs[i]); }
	}
	for(int i=0;i<=15;i++){                  
		if(qualifiedleague[blclubs[i]]=="uefa cup")
		{clubs.Add(blclubs[i]);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }
	}
	for(int i=0;i<=7;i++)          //next add other non playable clubs      
		clubs.Add(unplayableUEFA[i]);

	for(int i=1;i<=16;i++){             //add random teams to pool  
		int dice=Random.Range(0,clubs.Count-1);
		pool[i]=clubs[dice];  
		clubs.RemoveAt(dice);
	} int v=1;
	for(int i=1;i<=4;i++){               //add uefa cup 4 groups of 4 teams
		Uefacup_group[i,1]=pool[v];v++;
		Uefacup_group[i,2]=pool[v];v++;
		Uefacup_group[i,3]=pool[v];v++;
		Uefacup_group[i,4]=pool[v];v++;
		//v+=4;
	}

	return Uefacup_group;
}
////////////////////////////////////////////////////////////////////////

int[,]  FillSpanishcup (){
	int[] pool=new int[17]; var clubs=new List<int>();
	for(int i=0;i<=15;i++){   //fill clubs with spanish cluns
		clubs.Add(llclubs[i]);
	}
	for(int i=1;i<=16;i++){              //add random teams to pool
		int dice=Random.Range(0,clubs.Count);
		pool[i]=clubs[dice];
		clubs.RemoveAt(dice);
	}  int v=1;
	for(int i=1;i<=8;i++){               //add uefa cup 4 groups of 4 teams
		Spanishcup_round1[i,1]=pool[v];
		Spanishcup_round1[i,2]=pool[v+1]; 
		v+=2;
	}  
	return Spanishcup_round1;
}
/////////////////////////////////////////////////////////////////////////

int[,]  FillItaliancup (){
	int[] pool=new int[17]; var clubs=new List<int>();
	for(int i=0;i<=15;i++){   //fill clubs with spanish cluns
		clubs.Add(saclubs[i]);
	}
	for(int i=1;i<=16;i++){              //add random teams to pool
		int dice=Random.Range(0,clubs.Count);
		pool[i]=clubs[dice];
		clubs.RemoveAt(dice);
	}  int v=1;
	for(int i=1;i<=8;i++){               //add uefa cup 4 groups of 4 teams
		Italiancup_round1[i,1]=pool[v];
		Italiancup_round1[i,2]=pool[v+1]; 
		v+=2;
	}
	return Italiancup_round1;
}
//////////////////////////////////////////////////////////////////////////////


int[,]  Fillgermancup (){
	int[] pool=new int[17]; var clubs=new List<int>();
	for(int i=0;i<=15;i++){   //fill clubs with spanish cluns
		clubs.Add(blclubs[i]);
	}
	for(int i=1;i<=16;i++){              //add random teams to pool
		int dice=Random.Range(0,clubs.Count);
		pool[i]=clubs[dice];
		clubs.RemoveAt(dice);
	}  int v=1;
	for(int i=1;i<=8;i++){               //add uefa cup 4 groups of 4 teams
		Germancup_round1[i,1]=pool[v];
		Germancup_round1[i,2]=pool[v+1]; 
		v+=2;
	}
	return Germancup_round1;
}

////////////////////////////////////////////////////////////////////////////
int[,]  MakeFriendlies (){
	int[] pool=new int[15]; 
	var eu=EUcountries; var sa=SAcountries; var af=AFcountries; var na=NAcountries; var o=Ocountries; var asi=AScountries;
	List<int> all= new List<int>(eu); all.AddRange(sa);all.AddRange(af);all.AddRange(na);all.AddRange(o);all.AddRange(asi);  //big bug fixed

	for(int i=1;i<=14;i++){              //add random teams to pool
		int dice=Random.Range(0,all.Count);
		if(all[dice]==global.id){
			all.RemoveAt(dice);dice=Random.Range(0,all.Count);}
		pool[i]=all[dice];
		all.RemoveAt(dice);
		Friendly[i,1]=global.id;  // own country
		Friendly[i,2]=pool[i];
	}  
	return Friendly;
}

//////////////////////////////////////////////////////////////////////////////

int[,] FillWCquals ( string region  ){  //7 groups of 6
	if(region=="europe"){
		var WCQuals=new int[8,7]; var countries=new List<int>(); countries.AddRange(EUcountries);
		int[] pool=new int[42];
		for(int i=0;i<42;i++){
			int max=countries.Count;
			int dice=Random.Range(0,max);
			pool[i]=countries[dice];
			countries.RemoveAt(dice);
		} int k=0;
		for(int i=1;i<=7;i++){
			for(int j=1;j<=6;j++)
			{WCQuals[i,j]=pool[k]; //Debug.Log("eu "+i+" "+WCQuals[i,j]);
				k++;}
		}
		return WCQuals;
	}
	if(region=="asia"){    // 4 groups of 5
		var WCQuals=new int[5,6];  var countries=new List<int>(); countries.AddRange(AScountries);
		var pool=new int[20];
		for(int i=0;i<20;i++){
			var max=countries.Count;
			var dice=Random.Range(0,max);
			pool[i]=countries[dice];
			countries.RemoveAt(dice);
		} 
		int k=0;
		for(int i=1;i<=4;i++){
			for(int j=1;j<=5;j++)
			{WCQuals[i,j]=pool[k]; 
				k++;}
		}
		return WCQuals;
	}
	else
	return null;
}
/////////////////////////////////////////////////////////////////
int[]  FillWCQuals2 ( string region  ){ int[] WCQuals; List<int> countries; 
	if(region=="oceania"){ 
		 WCQuals=new int[9];  countries=new List<int>(); countries.AddRange(Ocountries);
		for(int i=1;i<=8;i++){
			int max=countries.Count;
			int dice=Random.Range(0,max);
			WCQuals[i]=countries[dice]; 
			countries.RemoveAt(dice);
		}
		return WCQuals;
	}
	if(region=="northamerica"){ 
		WCQuals=new int[17];  countries=new List<int>(); countries.AddRange(NAcountries);
		for(int i=1;i<=16;i++){
			int max=countries.Count; 
			int dice=Random.Range(0,max);
			WCQuals[i]=countries[dice]; 
			countries.RemoveAt(dice);
		}
		return WCQuals;
	}
	if(region=="southamerica"){ 
		WCQuals=new int[11];  countries=new List<int>(); countries.AddRange(SAcountries);
		for(int i=1;i<=10;i++){
			int max=countries.Count;
			int dice=Random.Range(0,max);
			WCQuals[i]=countries[dice];  
			countries.RemoveAt(dice);
		}
		return WCQuals;
	}
	else
	return null;
}
////////////////////////////////////////////////////////////////////////////////

int[,]  FillWCQualifier_playoffAF (){  //50 teams playoff 26,3 world cup african qualifying
	var countries=new List<int>();countries.AddRange(AFcountries) ;//  AFcountries,countries;
	int[] pool=new int[50]; 
	for(int i=0;i<50;i++){
		if(countries.Count>0){
			int max=countries.Count-1;
			int dice=Random.Range(0,max); 
			if(dice<countries.Count)
				pool[i]=countries[dice];
			countries.RemoveAt(dice);}
	} int k=0; 
	for(int i=1;i<=25;i++){
		for(int j=1;j<=2;j++)
		{WCQualifier_playoff[i,j]=pool[k];k++;}
	}

	return WCQualifier_playoff;
}

////////////////////////////////////////////////////////////////////////////

int[,]  FillEUROquals (){   //8 groups of 5
	int[] pool=new int[43]; var nations=new List<int>(); var giants=new int[]{41,52,68,94,48,123,108,9};   // giants=(41,52,68,94,48,123,108,9);//
	for(int i=0;i<EUcountries.Count;i++){ 
		// FIXME_VAR_TYPE has=Contains(giants,EUcluntries[i]);
		if(!Contains(giants,EUcountries[i])) //exclude adding giants to nations
		{nations.Add(EUcountries[i]);} }//bug fix
	if(Random.Range(0.0f,1.0f)<0.5f)
		nations.Remove(33);
	else
		nations.Remove(89);
	if(Random.Range(0.0f,1.0f)<0.5f)
		nations.Remove(81);
	else
		nations.Remove(4);

	for(int i=1;i<=32;i++){              //add random teams to pool
		int dice=Random.Range(0,nations.Count);
		pool[i]=nations[dice];
		nations.RemoveAt(dice);
	}
	for(int i=1;i<=8;i++){  //first add guants
		EUROqualifier_group[i,1]=giants[i-1];  //<= bug fix
	}
	int v=1;
	for(int i=1;i<=8;i++){               //add teams to 8 groups of 5 teams (league)
		EUROqualifier_group[i,2]=pool[v];v++;  //giant already added so excluded
		EUROqualifier_group[i,3]=pool[v];v++;
		EUROqualifier_group[i,4]=pool[v];v++;
		EUROqualifier_group[i,5]=pool[v]; 
		v++;
	}

	return EUROqualifier_group;
}

int[,]  FillAfconquals (){  //8 groups of 6
	int[] pool=new int[51]; var countries=new List<int>();
	//for(FIXME_VAR_TYPE i=0;i<AFcountries.length;i++){   //fill countries
	countries.AddRange(AFcountries);
	// }
	for(int i=1;i<=50;i++){              //add random teams to pool
		int dice=Random.Range(0,countries.Count);//
		if(countries.Count>0){
			pool[i]=countries[dice];
			countries.RemoveAt(dice);}
	}  int v=1;
	for(int i=1;i<=8;i++){               //add 8 groups of 6
		AFCONqualifier_group[i,1]=pool[v];v++;
		AFCONqualifier_group[i,2]=pool[v];v++;
		AFCONqualifier_group[i,3]=pool[v];v++;
		AFCONqualifier_group[i,4]=pool[v];v++;
		AFCONqualifier_group[i,5]=pool[v];v++;
		AFCONqualifier_group[i,6]=pool[v];v++;

	}
	return AFCONqualifier_group;
}

//////////////////////////////////////////////////////////////////////////
void  FillCups (){
	int[] pool=new int[21]; var countries=new List<int>();
	for(int i=0;i<=9;i++){   //fill countries
		countries.Add(SAcountries[i]); }
	for(int i=1;i<=10;i++){              //add random teams to pool
		int dice=Random.Range(0,countries.Count);
		pool[i]=countries[dice];
		countries.RemoveAt(dice); } 
	CopaAmerica[1,1]=pool[1];CopaAmerica[1,2]=pool[2];CopaAmerica[1,3]=pool[3]; //2 groups of 5 teams then semi final the final
	CopaAmerica[1,4]=pool[4];CopaAmerica[1,5]=pool[5];
	CopaAmerica[2,1]=pool[6];CopaAmerica[2,2]=pool[7];CopaAmerica[2,3]=pool[8];
	CopaAmerica[2,4]=pool[9];CopaAmerica[2,5]=pool[10];
	////ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc
	for(int i=1;i<=10;i++)
		pool[i]=0; countries.Clear();
	for(int i=0;i<=15;i++){   //fill countries
		countries.Add(NAcountries[i]); }
	for(int i=1;i<=16;i++){              //add random teams to pool
		var dice=Random.Range(0,countries.Count);
		pool[i]=countries[dice];
		countries.RemoveAt(dice); } int v=1;
	for(int i=1;i<=4;i++){
		Goldcup_group[i,1]=pool[v];v++;
		Goldcup_group[i,2]=pool[v];v++;
		Goldcup_group[i,3]=pool[v];v++;
		Goldcup_group[i,4]=pool[v];v++;

	}
	//ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc
	for(int i=1;i<=20;i++)
		pool[i]=0; countries.Clear();
	for(int i=0;i<=19;i++){   //fill countries
		countries.Add(AScountries[i]); }
	for(int i=1;i<=20;i++){              //add random teams to pool
		var dice=Random.Range(0,countries.Count);
		pool[i]=countries[dice];
		countries.RemoveAt(dice); }  v=1;
	for(int i=1;i<=4;i++){
		ASIANcup_group[i,1]=pool[v];v++;
		ASIANcup_group[i,2]=pool[v];v++;
		ASIANcup_group[i,3]=pool[v];v++;
		ASIANcup_group[i,4]=pool[v];v++;
		ASIANcup_group[i,5]=pool[v];v++;
		//v+=5;
	}

	ONCcup_round1[1,1]=Ocountries[0];ONCcup_round1[1,2]=Ocountries[1];ONCcup_round1[2,1]=Ocountries[2];
	ONCcup_round1[2,2]=Ocountries[3];
	ONCcup_round1[3,1]=Ocountries[4];
	ONCcup_round1[3,2]=Ocountries[5];
	ONCcup_round1[4,1]=Ocountries[6];
	ONCcup_round1[4,2]=Ocountries[7];

}

void  fill_yearly_cups (){
	var pool= new List<int>{105,130,118,143,84,63,25,62};//philippines thailand singapore vietnam malaysia indonesia china india
	int[] SEAcountries=new int[8] ;
	for(int i=0;i<SEAcountries.Length;i++){
		int choice=Random.Range(0,pool.Count-1);  //bug fix
		SEAcountries[i]=pool[choice] ;pool.RemoveAt(choice); }

	SEAgames_round1[1,1]=SEAcountries[0]; SEAgames_round1[1,2]=SEAcountries[1];
	SEAgames_round1[2,1]=SEAcountries[2]; SEAgames_round1[2,2]=SEAcountries[3];
	SEAgames_round1[3,1]=SEAcountries[4]; SEAgames_round1[3,2]=SEAcountries[5];
	SEAgames_round1[4,1]=SEAcountries[6];
	SEAgames_round1[4,2]=SEAcountries[7];

	int[] CECAFAcountries={138,111,45,73,18,125,36,129} ; 
	CECAFAcup_round1[1,1]=CECAFAcountries[0]; CECAFAcup_round1[1,2]=CECAFAcountries[1];
	CECAFAcup_round1[2,1]=CECAFAcountries[2]; CECAFAcup_round1[2,2]=CECAFAcountries[3];
	CECAFAcup_round1[3,1]=CECAFAcountries[4]; CECAFAcup_round1[3,2]=CECAFAcountries[5];
	CECAFAcup_round1[4,1]=CECAFAcountries[6];
	CECAFAcup_round1[4,2]=CECAFAcountries[7];

	int[] COSAFAcountries={122,14,92,145,146,91,78,126} ; 
	COSAFAcup_round1[1,1]=COSAFAcountries[0]; COSAFAcup_round1[1,2]=COSAFAcountries[1];
	COSAFAcup_round1[2,1]=COSAFAcountries[2]; COSAFAcup_round1[2,2]=COSAFAcountries[3];
	COSAFAcup_round1[3,1]=COSAFAcountries[4]; COSAFAcup_round1[3,2]=COSAFAcountries[5];
	COSAFAcup_round1[4,1]=COSAFAcountries[6];
	COSAFAcup_round1[4,2]=COSAFAcountries[7];

	int[] CABRALcountries={85,98,69,131,114,53,11,42} ;   //mali senegal guinea ivory ghana nig
	CABRALcup_round1[1,1]=CABRALcountries[0]; CABRALcup_round1[1,2]=CABRALcountries[1];
	CABRALcup_round1[2,1]=CABRALcountries[2]; CABRALcup_round1[2,2]=CABRALcountries[3];
	CABRALcup_round1[3,1]=CABRALcountries[4]; CABRALcup_round1[3,2]=CABRALcountries[5];
	CABRALcup_round1[4,1]=CABRALcountries[6];
	CABRALcup_round1[4,2]=CABRALcountries[7];

}

int[,]  FillWCqualifier_AFgroup (){  //world cup africa todo
	int v=0;  Debug.Log("filling wcqaf groups "+WCQAfrica_pool.Count);
	for(int i=1;i<=5;i++){
		for(int j=1;j<=5;j++){
			WCQualifier_af_group[i,j]=WCQAfrica_pool[v];v++;
		}
	}
	WCQAfrica_pool.Clear();
	return WCQualifier_af_group;
}


void  LoadPlayers (){ Debug.Log("overwriting players");
	int i=0;bool stop=false; int k=1; int Id=0;
	string file = Application.dataPath + "/players";
	StreamReader reader = new StreamReader(file);
	reader.ReadLine();reader.ReadLine();   //loading.SetActive(true);
	while(i<18541 || stop==false){

		if(global.category=="clubs"){
			var piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxx
			for(int j= 0;j < piece.Length; j++){
				if(piece[j]==':'){
					 Id=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;   }     }
			var has=false;
			for(int man=0;man<=22;man++)  
			{if(Id==clubplayers[global.id,man] && Id!=0){has=true;break;}}
			if(has)    //  id==clubplayers[global.id,k-1]
			{ player[k]=new Players();
				player[k].id=Id;
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].playername=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].playername=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				reader.ReadLine();reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].country=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].country=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].overall=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].overall=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].potential=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].potential=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].club=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].club=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){ int first=j; int last=j;
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{ first=j+7;  }
						else
						{ first=j+6;}   }
					if(piece[j]=='M' || piece[j]=='K')
					{ last=piece.Length-first-3;}
					if(piece[j]=='M')
					{player[k].Value=float.Parse(piece.Substring(first,last))*1000000;break; } 
					if(piece[j]=='K')
					{player[k].Value=float.Parse(piece.Substring(first,last))*1000;break; }  }
				reader.ReadLine();//pass wage
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxSKIN
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].skin=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].skin=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxacceleration
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].acceleration=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].acceleration=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxaggression
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].aggression=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].aggression=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxagility
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].agility=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].agility=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxbalance
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].balance=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].balance=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxballcontrol
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].ballcontrol=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].ballcontrol=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcomposure
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].composure=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].composure=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcrossing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].crossing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].crossing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcurve
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].curve=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].curve=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdribbling
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].dribbling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].dribbling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfinishing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].finishing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].finishing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }

				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfreekicks
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].freekicks=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].freekicks=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }

				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdiving
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].diving=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].diving=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhandling
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].handling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].handling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxkicking
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].kicking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].kicking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreflexes
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].reflexes=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].reflexes=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxHEADER
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].heading=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].heading=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();//skip interceptions
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxjumping
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].jumping=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].jumping=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxlongshots
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].longshots=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].longshots=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxmarking
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].marking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].marking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpenalties
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].penalties=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].penalties=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpositioning
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].positioning=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].positioning=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreactions
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].reactions=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].reactions=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpassing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].passing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].passing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhotshot
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].hotshot=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].hotshot=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxtackle
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].tackle=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].tackle=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxspeed
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].speed=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].speed=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstamina
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].stamina=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].stamina=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstrength
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].strength=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].strength=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxDETERMINATION
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].determination=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].determination=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				for(int o=1;o<=17;o++)
					reader.ReadLine();//xxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxrole
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].role=piece.Substring(j+4,piece.Length-(j+4)-2);break;  } //position "CF' 'GK"
						else
						{player[k].role=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				player[k].vskeeper="mixed";
				player[k].play="mixed";
				player[k].ratio=1;
				player[k].wings="mixed";
				player[k].longshoot="normal";
				player[k].tackling="hard";
				player[k].passheight="mixed";
				player[k].rating=7;
				player[k].ratings[0]=0;
				player[k].ratings[1]=0;
				player[k].ratings[2]=0;
				player[k].ratings[3]=0;
				player[k].ratings[4]=0;
				player[k].consistency=0;
				player[k].training_attack[0]=2;
				player[k].training_defence[0]=2;
				player[k].training_midfield[0]=2;
				player[k].training_physical[0]=2;
				player[k].training_setpieces[0]=2;
				player[k].training_goalkeeper[0]=1;
				;k++;if(clubplayers[global.id,k-1]==-1 || k==23)stop=true;
				for(int o=1;o<=13;o++)
					reader.ReadLine();}//correct id
			else
			{for(int o=1;o<=76;o++)
				reader.ReadLine();} //search on to next id
		}//clubs
		if(global.category=="countries"){ int first=k,last=k;
			var piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxx
			if(k>=24 || piece==null){reader.Close();/*loading.SetActive(false)*/;return;}
			for(int j = 0;j < piece.Length; j++){ 
				if(piece[j]==':'){
					Id=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;  }     }
			var has=false;
			for(int man=0;man<=22;man++)  
			{if(Id==players[global.id,man] && Id!=0){has=true;break;}}
			if(has)
			{ player[k]=new Players(); 
				player[k].id=Id; 
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].playername=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].playername=piece.Substring(j+3,piece.Length-(j+3)-2);}   }     }
				reader.ReadLine();reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].country=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].country=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].overall=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{
							player[k].overall=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].potential=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{
							player[k].potential=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine(); //xxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].club=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].club=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxx
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{ first=j+7;  }
						else
						{first=j+6;}   }
					if(piece[j]=='M' || piece[j]=='K')
						last=piece.Length-first-3;
					if(piece[j]=='M')
					{player[k].Value=float.Parse(piece.Substring(first,last))*1000000;break; } 
					if(piece[j]=='K')
					{player[k].Value=float.Parse(piece.Substring(first,last))*1000;break; }  }
				reader.ReadLine();//pass wage
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxSKIN
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].skin=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].skin=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxacceleration
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].acceleration=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].acceleration=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxaggression
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].aggression=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].aggression=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxagility
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].agility=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].agility=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxbalance
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].balance=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].balance=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxballcontrol
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].ballcontrol=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].ballcontrol=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcomposure
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].composure=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].composure=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcrossing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].crossing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].crossing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxcurve
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].curve=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].curve=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdribbling
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].dribbling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].dribbling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfinishing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].finishing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].finishing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }

				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxfreekicks
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].freekicks=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].freekicks=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }

				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdiving
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].diving=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].diving=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhandling
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].handling=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].handling=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxkicking
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].kicking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].kicking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();//skip gk positioning
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreflexes
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].reflexes=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].reflexes=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxHEADER
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].heading=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].heading=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();//skip interceptions
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxjumping
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].jumping=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].jumping=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();//skip long passing
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxlongshots
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].longshots=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].longshots=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxmarking
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].marking=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].marking=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpenalties
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].penalties=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].penalties=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpositioning
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].positioning=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].positioning=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxreactions
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].reactions=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].reactions=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxpassing
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].passing=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].passing=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxhotshot
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].hotshot=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].hotshot=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxtackle
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].tackle=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].tackle=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxspeed
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].speed=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].speed=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstamina
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].stamina=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].stamina=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				reader.ReadLine();//skip standing tackle
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxstrength
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].strength=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].strength=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxdetermination
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].determination=int.Parse(piece.Substring(j+3,piece.Length-(j+3)-1));break;  }
						else
						{player[k].determination=int.Parse(piece.Substring(j+2,piece.Length-(j+2)-1));break;}   }     }
				for(int o=1;o<=17;o++)
					reader.ReadLine();//xxxxxxxxxxxxxxxxxxx
				piece=reader.ReadLine();//xxxxxxxxxxxxxxxxxxxxxxxxxxxxrole
				for(int j = 0;j < piece.Length; j++){
					if(piece[j]==':'){
						if(piece[j+2]==' ')
						{player[k].role=piece.Substring(j+4,piece.Length-(j+4)-2);break;  }
						else
						{player[k].role=piece.Substring(j+3,piece.Length-(j+3)-2);break;}   }     }
				player[k].vskeeper="mixed";
				player[k].play="mixed";
				player[k].ratio=1;     // 1->50:50 2,->twice as much 3->most often 4-> always
				player[k].wings="mixed";
				player[k].longshoot="normal";
				player[k].tackling="hard";
				player[k].passheight="mixed";
				player[k].rating=7;
				player[k].ratings[0]=0;
				player[k].ratings[1]=0;
				player[k].ratings[2]=0;
				player[k].ratings[3]=0;
				player[k].ratings[4]=0;
				player[k].consistency=0;  //increases with team talk
				player[k].training_attack[0]=2;
				player[k].training_defence[0]=2;
				player[k].training_midfield[0]=2;
				player[k].training_physical[0]=2;
				player[k].training_setpieces[0]=2;
				player[k].training_goalkeeper[0]=1;
				k++;
				if(k>=24){ stop=true;reader.Close();/*loading.SetActive(false);*/return;break;}
				if(k<24){if(players[global.id,k-1]==-1 ){stop=true;reader.Close();loading.SetActive(false);return;break;} }
				for(int o=1;o<=13;o++)
				{ var check=reader.ReadLine();if(check==null){reader.Close();/*loading.SetActive(false);*/return;}}
			} //true id
			else
			{ 
				for(int o=1;o<=76;o++) //there was an uncaught bug  that caused unity to freeze, it was zero instead of o
				{var check=reader.ReadLine();if(check==null){reader.Close();/*loading.SetActive(false);*/return;} }  }
		}//countries

		i++;        }//while
	reader.Close(); //loading.SetActive(false);

}

void  SavePlayers (){
	var file= Application.dataPath + "/ownplayers"; int[] men=new int[23]; int max;
	StreamWriter writer = new StreamWriter(file,false);
	if(global.category=="clubs")
	{ max=22;}
	else
		max=23;
	if(global.category=="clubs"){
		for(int o=0;o<max;o++)
			men[o]=clubplayers[global.id,o];}
	else{
		for(int o=0;o<max;o++)
		{men[o]=players[global.id,o];}}
	for(int j=0;j<max;j++ )//position
	{ 
		for(int i=1;i<=max;i++){ //iterate unordered players

			if(player[i].id==men[j] && player[i].id!=0)  //player[i].id==men[j]
			{
				if(player[i]!=null){                       
					writer.WriteLine(player[i].id);
					writer.WriteLine(player[i].playername);
					writer.WriteLine(player[i].country);
					writer.WriteLine(player[i].overall);
					writer.WriteLine(player[i].potential);
					writer.WriteLine(player[i].club);
					writer.WriteLine(player[i].Value);
					writer.WriteLine(player[i].skin);
					writer.WriteLine(player[i].acceleration);
					writer.WriteLine(player[i].aggression);
					writer.WriteLine(player[i].agility);
					writer.WriteLine(player[i].balance);
					writer.WriteLine(player[i].ballcontrol);
					writer.WriteLine(player[i].composure);
					writer.WriteLine(player[i].crossing);
					writer.WriteLine(player[i].curve);
					writer.WriteLine(player[i].dribbling);
					writer.WriteLine(player[i].finishing);
					writer.WriteLine(player[i].freekicks);
					writer.WriteLine(player[i].diving);
					writer.WriteLine(player[i].handling);
					writer.WriteLine(player[i].kicking);
					writer.WriteLine(player[i].reflexes);
					writer.WriteLine(player[i].heading);
					writer.WriteLine(player[i].jumping);
					writer.WriteLine(player[i].longshots);
					writer.WriteLine(player[i].marking);
					writer.WriteLine(player[i].penalties);
					writer.WriteLine(player[i].positioning);
					writer.WriteLine(player[i].reactions);
					writer.WriteLine(player[i].passing);
					writer.WriteLine(player[i].hotshot);
					writer.WriteLine(player[i].tackle);
					writer.WriteLine(player[i].speed);
					writer.WriteLine(player[i].stamina);
					writer.WriteLine(player[i].strength);
					writer.WriteLine(player[i].determination);
					writer.WriteLine(player[i].role);
					writer.WriteLine(player[i].vskeeper);
					writer.WriteLine(player[i].play);
					writer.WriteLine(player[i].ratio);
					writer.WriteLine(player[i].wings);
					writer.WriteLine(player[i].longshoot);
					writer.WriteLine(player[i].tackling);
					writer.WriteLine(player[i].passheight);
					writer.WriteLine(player[i].rating);
					writer.WriteLine(player[i].ratings[0]);
					writer.WriteLine(player[i].ratings[1]);
					writer.WriteLine(player[i].ratings[2]);
					writer.WriteLine(player[i].ratings[3]);
					writer.WriteLine(player[i].ratings[4]);
					writer.WriteLine(player[i].consistency);
					writer.WriteLine(player[i].training_attack[0]);
					writer.WriteLine(player[i].training_defence[0]);
					writer.WriteLine(player[i].training_midfield[0]);
					writer.WriteLine(player[i].training_physical[0]);
					writer.WriteLine(player[i].training_setpieces[0]);
					writer.WriteLine(player[i].training_goalkeeper[0]); //traiining intensity
					writer.WriteLine(player[i].training_attack[1]);  //points accumlated
					writer.WriteLine(player[i].training_defence[1]);
					writer.WriteLine(player[i].training_midfield[1]);
					writer.WriteLine(player[i].training_physical[1]);
					writer.WriteLine(player[i].training_setpieces[1]);
					writer.WriteLine(player[i].training_goalkeeper[1]);}
				else
				{for(i=1;i<=64;i++)
					writer.WriteLine(-1);}
			}//found
		}//players
		// i++; //increase position    
	}
	writer.Close();
	//now rearrange players
	LoadOwnPlayers();
}

void  SaveOwnPlayers (){  //this for players already arranged and loaded from loadplayers
	var file= Application.dataPath + "/ownplayers";
	StreamWriter writer = new StreamWriter(file,false);
	for(int i=1;i<=23;i++){ //

		if(player[i]!=null)  //player[i].id==men[j]
		{  if(player[i].id!=-1)                
			{writer.WriteLine(player[i].id);
				writer.WriteLine(player[i].playername);
				writer.WriteLine(player[i].country);
				writer.WriteLine(player[i].overall);
				writer.WriteLine(player[i].potential);
				writer.WriteLine(player[i].club);
				writer.WriteLine(player[i].Value);
				writer.WriteLine(player[i].skin);
				writer.WriteLine(player[i].acceleration);
				writer.WriteLine(player[i].aggression);
				writer.WriteLine(player[i].agility);
				writer.WriteLine(player[i].balance);
				writer.WriteLine(player[i].ballcontrol);
				writer.WriteLine(player[i].composure);
				writer.WriteLine(player[i].crossing);
				writer.WriteLine(player[i].curve);
				writer.WriteLine(player[i].dribbling);
				writer.WriteLine(player[i].finishing);
				writer.WriteLine(player[i].freekicks);
				writer.WriteLine(player[i].diving);
				writer.WriteLine(player[i].handling);
				writer.WriteLine(player[i].kicking);
				writer.WriteLine(player[i].reflexes);
				writer.WriteLine(player[i].heading);
				writer.WriteLine(player[i].jumping);
				writer.WriteLine(player[i].longshots);
				writer.WriteLine(player[i].marking);
				writer.WriteLine(player[i].penalties);
				writer.WriteLine(player[i].positioning);
				writer.WriteLine(player[i].reactions);
				writer.WriteLine(player[i].passing);
				writer.WriteLine(player[i].hotshot);
				writer.WriteLine(player[i].tackle);
				writer.WriteLine(player[i].speed);
				writer.WriteLine(player[i].stamina);
				writer.WriteLine(player[i].strength);
				writer.WriteLine(player[i].determination);
				writer.WriteLine(player[i].role);
				writer.WriteLine(player[i].vskeeper);
				writer.WriteLine(player[i].play);
				writer.WriteLine(player[i].ratio);
				writer.WriteLine(player[i].wings);
				writer.WriteLine(player[i].longshoot);
				writer.WriteLine(player[i].tackling);
				writer.WriteLine(player[i].passheight);
				writer.WriteLine(player[i].rating);
				writer.WriteLine(player[i].ratings[0]);
				writer.WriteLine(player[i].ratings[1]);
				writer.WriteLine(player[i].ratings[2]);
				writer.WriteLine(player[i].ratings[3]);
				writer.WriteLine(player[i].ratings[4]);
				writer.WriteLine(player[i].consistency);
				writer.WriteLine(player[i].training_attack[0]);
				writer.WriteLine(player[i].training_defence[0]);
				writer.WriteLine(player[i].training_midfield[0]);
				writer.WriteLine(player[i].training_physical[0]);
				writer.WriteLine(player[i].training_setpieces[0]);
				writer.WriteLine(player[i].training_goalkeeper[0]);
				writer.WriteLine(player[i].training_attack[1]);
				writer.WriteLine(player[i].training_defence[1]);
				writer.WriteLine(player[i].training_midfield[1]);
				writer.WriteLine(player[i].training_physical[1]);
				writer.WriteLine(player[i].training_setpieces[1]);
				writer.WriteLine(player[i].training_goalkeeper[1]);}
		else
		{for(i=1;i<=64;i++)
			writer.WriteLine(-1);}
	}
		else 
		{for(i=1;i<=64;i++)
			writer.WriteLine(-1);}
	}//for

	writer.Close();
}

void  LoadOwnPlayers (){      //load ordered players
	var file= Application.dataPath + "/ownplayers"; 
	StreamReader reader = new StreamReader(file); 
	for(int i=1;i<=23;i++ )//position
	{ 
		var check=reader.ReadLine();
		if(check==null){reader.Close();return;}
		if(check!="-1"){//no player
			player[i].id=int.Parse(check);
			player[i].playername=reader.ReadLine();
			player[i].country=reader.ReadLine();
			player[i].overall=int.Parse(reader.ReadLine());
			player[i].potential=int.Parse(reader.ReadLine());
			player[i].club=reader.ReadLine();
			player[i].Value=float.Parse(reader.ReadLine());
			player[i].skin=int.Parse(reader.ReadLine());
			player[i].acceleration=int.Parse(reader.ReadLine());
			player[i].aggression=int.Parse(reader.ReadLine());
			player[i].agility=int.Parse(reader.ReadLine());
			player[i].balance=int.Parse(reader.ReadLine());
			player[i].ballcontrol=int.Parse(reader.ReadLine());
			player[i].composure=int.Parse(reader.ReadLine());
			player[i].crossing=int.Parse(reader.ReadLine());
			player[i].curve=int.Parse(reader.ReadLine());
			player[i].dribbling=int.Parse(reader.ReadLine());
			player[i].finishing=int.Parse(reader.ReadLine());
			player[i].freekicks=int.Parse(reader.ReadLine());
			player[i].diving=int.Parse(reader.ReadLine());
			player[i].handling=int.Parse(reader.ReadLine());
			player[i].kicking=int.Parse(reader.ReadLine());
			player[i].reflexes=int.Parse(reader.ReadLine());
			player[i].heading=int.Parse(reader.ReadLine());
			player[i].jumping=int.Parse(reader.ReadLine());
			player[i].longshots=int.Parse(reader.ReadLine());
			player[i].marking=int.Parse(reader.ReadLine());
			player[i].penalties=int.Parse(reader.ReadLine());
			player[i].positioning=int.Parse(reader.ReadLine());
			player[i].reactions=int.Parse(reader.ReadLine());
			player[i].passing=int.Parse(reader.ReadLine());
			player[i].hotshot=int.Parse(reader.ReadLine());
			player[i].tackle=int.Parse(reader.ReadLine());
			player[i].speed=int.Parse(reader.ReadLine());
			player[i].stamina=int.Parse(reader.ReadLine());
			player[i].strength=int.Parse(reader.ReadLine());
			player[i].determination=int.Parse(reader.ReadLine());
			player[i].role=reader.ReadLine();
			player[i].vskeeper=reader.ReadLine();
			player[i].play=reader.ReadLine();
			player[i].ratio=int.Parse(reader.ReadLine());
			player[i].wings=reader.ReadLine();
			player[i].longshoot=reader.ReadLine();
			player[i].tackling=reader.ReadLine();
			player[i].passheight=reader.ReadLine();
			player[i].rating=int.Parse(reader.ReadLine());
			player[i].ratings[0]=int.Parse(reader.ReadLine());
			player[i].ratings[1]=int.Parse(reader.ReadLine());
			player[i].ratings[2]=int.Parse(reader.ReadLine());
			player[i].ratings[3]=int.Parse(reader.ReadLine());
			player[i].ratings[4]=int.Parse(reader.ReadLine());
			player[i].consistency=int.Parse(reader.ReadLine());
			player[i].training_attack[0]=int.Parse(reader.ReadLine());
			player[i].training_defence[0]=int.Parse(reader.ReadLine());
			player[i].training_midfield[0]=int.Parse(reader.ReadLine());
			player[i].training_physical[0]=int.Parse(reader.ReadLine());
			player[i].training_setpieces[0]=int.Parse(reader.ReadLine());
			player[i].training_goalkeeper[0]=int.Parse(reader.ReadLine());
			player[i].training_attack[1]=int.Parse(reader.ReadLine());
			player[i].training_defence[1]=int.Parse(reader.ReadLine());
			player[i].training_midfield[1]=int.Parse(reader.ReadLine());
			player[i].training_physical[1]=int.Parse(reader.ReadLine());
			player[i].training_setpieces[1]=int.Parse(reader.ReadLine());
			player[i].training_goalkeeper[1]=int.Parse(reader.ReadLine());}
	}
	reader.Close();
}



void  FillPLMatches (){

	plmatches[2,0,0]=plclub[1];    ;plmatches[3,0,0]=plclub[1];     plmatches[4,0,0]=plclub[1];     plmatches[5,0,0]=plclub[15];     
	plmatches[2,0,1]=plclub[18];   ;plmatches[3,0,1]=plclub[17];     plmatches[4,0,1]=plclub[16];     plmatches[5,0,1]=plclub[1];     
	plmatches[2,1,0]=plclub[2];    ;plmatches[3,1,0]=plclub[16];     plmatches[4,1,0]=plclub[17];     plmatches[5,1,0]=plclub[14];     
	plmatches[2,1,1]=plclub[17];    plmatches[3,1,1]=plclub[18];     plmatches[4,1,1]=plclub[15];     plmatches[5,1,1]=plclub[16];     
	plmatches[2,2,0]=plclub[3];     plmatches[3,2,0]=plclub[15];     plmatches[4,2,0]=plclub[18];     plmatches[5,2,0]=plclub[13];     
	plmatches[2,2,1]=plclub[16];     plmatches[3,2,1]=plclub[2];     plmatches[4,2,1]=plclub[14];     plmatches[5,2,1]=plclub[17];     
	plmatches[2,3,0]=plclub[4];      plmatches[3,3,0]=plclub[14];     plmatches[4,3,0]=plclub[2];     plmatches[5,3,0]=plclub[12];     
	plmatches[2,3,1]=plclub[15];     plmatches[3,3,1]=plclub[3];     plmatches[4,3,1]=plclub[13];     plmatches[5,3,1]=plclub[18];     
	plmatches[2,4,0]=plclub[5];     plmatches[3,4,0]=plclub[13];     plmatches[4,4,0]=plclub[3];     plmatches[5,4,0]=plclub[11];     
	plmatches[2,4,1]=plclub[14];     plmatches[3,4,1]=plclub[4];     plmatches[4,4,1]=plclub[12];     plmatches[5,4,1]=plclub[2];     
	plmatches[2,5,0]=plclub[6];     plmatches[3,5,0]=plclub[12];     plmatches[4,5,0]=plclub[4];     plmatches[5,5,0]=plclub[10];     
	plmatches[2,5,1]=plclub[13];      plmatches[3,5,1]=plclub[5];     plmatches[4,5,1]=plclub[11];     plmatches[5,5,1]=plclub[3];     
	plmatches[2,6,0]=plclub[7];     plmatches[3,6,0]=plclub[11];     plmatches[4,6,0]=plclub[5];     plmatches[5,6,0]=plclub[9];     
	plmatches[2,6,1]=plclub[12];     plmatches[3,6,1]=plclub[6];     plmatches[4,6,1]=plclub[10];     plmatches[5,6,1]=plclub[4];     
	plmatches[2,7,0]=plclub[8];     plmatches[3,7,0]=plclub[10];     plmatches[4,7,0]=plclub[6];     plmatches[5,7,0]=plclub[8];     
	plmatches[2,7,1]=plclub[11];      plmatches[3,7,1]=plclub[7];     plmatches[4,7,1]=plclub[9];     plmatches[5,7,1]=plclub[5];     
	plmatches[2,8,0]=plclub[9];     plmatches[3,8,0]=plclub[9];     plmatches[4,8,0]=plclub[7];     plmatches[5,8,0]=plclub[7];     
	plmatches[2,8,1]=plclub[10];      plmatches[3,8,1]=plclub[8];     plmatches[4,8,1]=plclub[8];     plmatches[5,8,1]=plclub[6];    

	plmatches[7,0,0]=plclub[1];    ;plmatches[8,0,0]=plclub[13];     plmatches[9,0,0]=plclub[1];     plmatches[11,0,0]=plclub[11];     
	plmatches[7,0,1]=plclub[14];   ;plmatches[8,0,1]=plclub[1];     plmatches[9,0,1]=plclub[12];     plmatches[11,0,1]=plclub[1];     
	plmatches[7,1,0]=plclub[15];    ;plmatches[8,1,0]=plclub[12];     plmatches[9,1,0]=plclub[13];     plmatches[11,1,0]=plclub[10];     
	plmatches[7,1,1]=plclub[13];    plmatches[8,1,1]=plclub[14];     plmatches[9,1,1]=plclub[11];     plmatches[11,1,1]=plclub[12];     
	plmatches[7,2,0]=plclub[16];     plmatches[8,2,0]=plclub[11];     plmatches[9,2,0]=plclub[14];     plmatches[11,2,0]=plclub[9];     
	plmatches[7,2,1]=plclub[12];     plmatches[8,2,1]=plclub[15];     plmatches[9,2,1]=plclub[10];     plmatches[11,2,1]=plclub[13];     
	plmatches[7,3,0]=plclub[17];      plmatches[8,3,0]=plclub[10];     plmatches[9,3,0]=plclub[15];     plmatches[11,3,0]=plclub[8];     
	plmatches[7,3,1]=plclub[11];     plmatches[8,3,1]=plclub[16];     plmatches[9,3,1]=plclub[9];     plmatches[11,3,1]=plclub[14];     
	plmatches[7,4,0]=plclub[18];     plmatches[8,4,0]=plclub[9];     plmatches[9,4,0]=plclub[16];     plmatches[11,4,0]=plclub[7];     
	plmatches[7,4,1]=plclub[10];     plmatches[8,4,1]=plclub[17];     plmatches[9,4,1]=plclub[8];     plmatches[11,4,1]=plclub[15];     
	plmatches[7,5,0]=plclub[2];     plmatches[8,5,0]=plclub[8];     plmatches[9,5,0]=plclub[17];     plmatches[11,5,0]=plclub[6];     
	plmatches[7,5,1]=plclub[9];      plmatches[8,5,1]=plclub[18];     plmatches[9,5,1]=plclub[7];     plmatches[11,5,1]=plclub[16];     
	plmatches[7,6,0]=plclub[3];     plmatches[8,6,0]=plclub[7];     plmatches[9,6,0]=plclub[18];     plmatches[11,6,0]=plclub[5];     
	plmatches[7,6,1]=plclub[8];     plmatches[8,6,1]=plclub[2];     plmatches[9,6,1]=plclub[6];     plmatches[11,6,1]=plclub[17];     
	plmatches[7,7,0]=plclub[4];     plmatches[8,7,0]=plclub[6];     plmatches[9,7,0]=plclub[2];     plmatches[11,7,0]=plclub[4];     
	plmatches[7,7,1]=plclub[7];      plmatches[8,7,1]=plclub[3];     plmatches[9,7,1]=plclub[5];     plmatches[11,7,1]=plclub[18];     
	plmatches[7,8,0]=plclub[5];     plmatches[8,8,0]=plclub[5];     plmatches[9,8,0]=plclub[3];     plmatches[11,8,0]=plclub[3];     
	plmatches[7,8,1]=plclub[6];      plmatches[8,8,1]=plclub[4];     plmatches[9,8,1]=plclub[4];     plmatches[11,8,1]=plclub[2];   

	plmatches[12,0,0]=plclub[1];    ;plmatches[13,0,0]=plclub[9];     plmatches[14,0,0]=plclub[1];     plmatches[15,0,0]=plclub[7];     
	plmatches[12,0,1]=plclub[10];   ;plmatches[13,0,1]=plclub[1];     plmatches[14,0,1]=plclub[8];     plmatches[15,0,1]=plclub[1];     
	plmatches[12,1,0]=plclub[11];    ;plmatches[13,1,0]=plclub[8];     plmatches[14,1,0]=plclub[7];     plmatches[15,1,0]=plclub[6];     
	plmatches[12,1,1]=plclub[9];    plmatches[13,1,1]=plclub[10];     plmatches[14,1,1]=plclub[9];     plmatches[15,1,1]=plclub[8];     
	plmatches[12,2,0]=plclub[12];     plmatches[13,2,0]=plclub[7];     plmatches[14,2,0]=plclub[10];     plmatches[15,2,0]=plclub[5];     
	plmatches[12,2,1]=plclub[8];     plmatches[13,2,1]=plclub[11];     plmatches[14,2,1]=plclub[6];     plmatches[15,2,1]=plclub[9];     
	plmatches[12,3,0]=plclub[13];      plmatches[13,3,0]=plclub[6];     plmatches[14,3,0]=plclub[11];     plmatches[15,3,0]=plclub[4];     
	plmatches[12,3,1]=plclub[7];     plmatches[13,3,1]=plclub[12];     plmatches[14,3,1]=plclub[5];     plmatches[15,3,1]=plclub[10];     
	plmatches[12,4,0]=plclub[14];     plmatches[13,4,0]=plclub[5];     plmatches[14,4,0]=plclub[12];     plmatches[15,4,0]=plclub[3];     
	plmatches[12,4,1]=plclub[6];     plmatches[13,4,1]=plclub[13];     plmatches[14,4,1]=plclub[4];     plmatches[15,4,1]=plclub[11];     
	plmatches[12,5,0]=plclub[15];     plmatches[13,5,0]=plclub[4];     plmatches[14,5,0]=plclub[13];     plmatches[15,5,0]=plclub[2];     
	plmatches[12,5,1]=plclub[5];      plmatches[13,5,1]=plclub[14];     plmatches[14,5,1]=plclub[3];     plmatches[15,5,1]=plclub[12];     
	plmatches[12,6,0]=plclub[16];     plmatches[13,6,0]=plclub[3];     plmatches[14,6,0]=plclub[14];     plmatches[15,6,0]=plclub[18];     
	plmatches[12,6,1]=plclub[4];     plmatches[13,6,1]=plclub[15];     plmatches[14,6,1]=plclub[2];     plmatches[15,6,1]=plclub[13];     
	plmatches[12,7,0]=plclub[17];     plmatches[13,7,0]=plclub[2];     plmatches[14,7,0]=plclub[15];     plmatches[15,7,0]=plclub[17];     
	plmatches[12,7,1]=plclub[3];      plmatches[13,7,1]=plclub[16];     plmatches[14,7,1]=plclub[18];     plmatches[15,7,1]=plclub[14];     
	plmatches[12,8,0]=plclub[18];     plmatches[13,8,0]=plclub[18];     plmatches[14,8,0]=plclub[16];     plmatches[15,8,0]=plclub[16];     
	plmatches[12,8,1]=plclub[2];      plmatches[13,8,1]=plclub[17];     plmatches[14,8,1]=plclub[17];     plmatches[15,8,1]=plclub[15]; 

	plmatches[16,0,0]=plclub[1];    ;plmatches[17,0,0]=plclub[5];     plmatches[19,0,0]=plclub[1];     plmatches[20,0,0]=plclub[3];     
	plmatches[16,0,1]=plclub[6];   ;plmatches[17,0,1]=plclub[1];     plmatches[19,0,1]=plclub[4];     plmatches[20,0,1]=plclub[1];     
	plmatches[16,1,0]=plclub[5];    ;plmatches[17,1,0]=plclub[4];     plmatches[19,1,0]=plclub[3];     plmatches[20,1,0]=plclub[2];     
	plmatches[16,1,1]=plclub[7];    plmatches[17,1,1]=plclub[6];     plmatches[19,1,1]=plclub[5];     plmatches[20,1,1]=plclub[4];     
	plmatches[16,2,0]=plclub[8];     plmatches[17,2,0]=plclub[3];     plmatches[19,2,0]=plclub[6];     plmatches[20,2,0]=plclub[18];     
	plmatches[16,2,1]=plclub[4];     plmatches[17,2,1]=plclub[7];     plmatches[19,2,1]=plclub[2];     plmatches[20,2,1]=plclub[5];     
	plmatches[16,3,0]=plclub[9];      plmatches[17,3,0]=plclub[2];     plmatches[19,3,0]=plclub[18];     plmatches[20,3,0]=plclub[17];     
	plmatches[16,3,1]=plclub[3];     plmatches[17,3,1]=plclub[8];     plmatches[19,3,1]=plclub[7];     plmatches[20,3,1]=plclub[6];     
	plmatches[16,4,0]=plclub[10];     plmatches[17,4,0]=plclub[18];     plmatches[19,4,0]=plclub[8];     plmatches[20,4,0]=plclub[16];     
	plmatches[16,4,1]=plclub[2];     plmatches[17,4,1]=plclub[9];     plmatches[19,4,1]=plclub[17];     plmatches[20,4,1]=plclub[7];     
	plmatches[16,5,0]=plclub[11];     plmatches[17,5,0]=plclub[17];     plmatches[19,5,0]=plclub[9];     plmatches[20,5,0]=plclub[15];     
	plmatches[16,5,1]=plclub[18];      plmatches[17,5,1]=plclub[10];     plmatches[19,5,1]=plclub[16];     plmatches[20,5,1]=plclub[8];     
	plmatches[16,6,0]=plclub[12];     plmatches[17,6,0]=plclub[16];     plmatches[19,6,0]=plclub[10];     plmatches[20,6,0]=plclub[14];     
	plmatches[16,6,1]=plclub[17];     plmatches[17,6,1]=plclub[11];     plmatches[19,6,1]=plclub[15];     plmatches[20,6,1]=plclub[9];     
	plmatches[16,7,0]=plclub[13];     plmatches[17,7,0]=plclub[15];     plmatches[19,7,0]=plclub[11];     plmatches[20,7,0]=plclub[13];     
	plmatches[16,7,1]=plclub[16];      plmatches[17,7,1]=plclub[12];     plmatches[19,7,1]=plclub[14];     plmatches[20,7,1]=plclub[10];     
	plmatches[16,8,0]=plclub[14];     plmatches[17,8,0]=plclub[14];     plmatches[19,8,0]=plclub[12];     plmatches[20,8,0]=plclub[12];     
	plmatches[16,8,1]=plclub[15];      plmatches[17,8,1]=plclub[13];     plmatches[19,8,1]=plclub[13];     plmatches[20,8,1]=plclub[11]; 

	plmatches[21,0,0]=plclub[1];
	plmatches[21,0,1]=plclub[2];
	plmatches[21,1,0]=plclub[18];
	plmatches[21,1,1]=plclub[3];
	plmatches[21,2,0]=plclub[4];
	plmatches[21,2,1]=plclub[17];
	plmatches[21,3,0]=plclub[16];
	plmatches[21,3,1]=plclub[5];
	plmatches[21,4,0]=plclub[6];
	plmatches[21,4,1]=plclub[15];
	plmatches[21,5,0]=plclub[7];
	plmatches[21,5,1]=plclub[14];
	plmatches[21,6,0]=plclub[8];
	plmatches[21,6,1]=plclub[13];
	plmatches[21,7,0]=plclub[9];
	plmatches[21,7,1]=plclub[12];
	plmatches[21,8,0]=plclub[10];
	plmatches[21,8,1]=plclub[11];

}

void  FillMatches ( string league  ){
	if(league=="laliga"){
		llmatches[2,0,0]=club[1];    llmatches[3,0,0]=club[15];    llmatches[4,0,0]=club[1];    llmatches[5,0,0]=club[13];    
		llmatches[2,0,1]=club[16];    llmatches[3,0,1]=club[1];    llmatches[4,0,1]=club[14];    llmatches[5,0,1]=club[1];    
		llmatches[2,1,0]=club[2];    llmatches[3,1,0]=club[14];    llmatches[4,1,0]=club[15];     llmatches[5,1,0]=club[12];    
		llmatches[2,1,1]=club[15];    llmatches[3,1,1]=club[16];     llmatches[4,1,1]=club[13];    llmatches[5,1,1]=club[14];    
		llmatches[2,2,0]=club[3];    llmatches[3,2,0]=club[13];     llmatches[4,2,0]=club[16];    llmatches[5,2,0]=club[11];    
		llmatches[2,2,1]=club[14];    llmatches[3,2,1]=club[2];    llmatches[4,2,1]=club[12];    llmatches[5,2,1]=club[15];    
		llmatches[2,3,0]=club[4];    llmatches[3,3,0]=club[12];    llmatches[4,3,0]=club[2];    llmatches[5,3,0]=club[10];    
		llmatches[2,3,1]=club[13];    llmatches[3,3,1]=club[3];    llmatches[4,3,1]=club[11];    llmatches[5,3,1]=club[16];    
		llmatches[2,4,0]=club[5];    llmatches[3,4,0]=club[11];    llmatches[4,4,0]=club[3];    llmatches[5,4,0]=club[9];    
		llmatches[2,4,1]=club[12];    llmatches[3,4,1]=club[4];    llmatches[4,4,1]=club[10];    llmatches[5,4,1]=club[2];    
		llmatches[2,5,0]=club[6];    llmatches[3,5,0]=club[10];    llmatches[4,5,0]=club[4];    llmatches[5,5,0]=club[8];    
		llmatches[2,5,1]=club[11];    llmatches[3,5,1]=club[5];    llmatches[4,5,1]=club[9];    llmatches[5,5,1]=club[3];    
		llmatches[2,6,0]=club[7];    llmatches[3,6,0]=club[9];     llmatches[4,6,0]=club[5];    llmatches[5,6,0]=club[7];      
		llmatches[2,6,1]=club[10];    llmatches[3,6,1]=club[6];    llmatches[4,6,1]=club[8];    llmatches[5,6,1]=club[4];    
		llmatches[2,7,0]=club[8];    llmatches[3,7,0]=club[8];    llmatches[4,7,0]=club[6];    llmatches[5,7,0]=club[6];    
		llmatches[2,7,1]=club[9];    llmatches[3,7,1]=club[7];    llmatches[4,7,1]=club[7];    llmatches[5,7,1]=club[5];   

		llmatches[7,0,0]=club[1];    llmatches[8,0,0]=club[11];    llmatches[9,0,0]=club[1];    llmatches[11,0,0]=club[9];    
		llmatches[7,0,1]=club[12];    llmatches[8,0,1]=club[1];    llmatches[9,0,1]=club[10];    llmatches[11,0,1]=club[1];    
		llmatches[7,1,0]=club[13];    llmatches[8,1,0]=club[10];    llmatches[9,1,0]=club[11];     llmatches[11,1,0]=club[8];    
		llmatches[7,1,1]=club[11];    llmatches[8,1,1]=club[12];     llmatches[9,1,1]=club[9];    llmatches[11,1,1]=club[10];    
		llmatches[7,2,0]=club[14];    llmatches[8,2,0]=club[9];     llmatches[9,2,0]=club[12];    llmatches[11,2,0]=club[7];    
		llmatches[7,2,1]=club[10];    llmatches[8,2,1]=club[13];    llmatches[9,2,1]=club[8];    llmatches[11,2,1]=club[11];    
		llmatches[7,3,0]=club[15];    llmatches[8,3,0]=club[14];    llmatches[9,3,0]=club[13];    llmatches[11,3,0]=club[6];    
		llmatches[7,3,1]=club[9];    llmatches[8,3,1]=club[8];    llmatches[9,3,1]=club[7];    llmatches[11,3,1]=club[12];    
		llmatches[7,4,0]=club[16];    llmatches[8,4,0]=club[7];    llmatches[9,4,0]=club[14];    llmatches[11,4,0]=club[5];    
		llmatches[7,4,1]=club[8];    llmatches[8,4,1]=club[15];    llmatches[9,4,1]=club[6];    llmatches[11,4,1]=club[13];    
		llmatches[7,5,0]=club[2];    llmatches[8,5,0]=club[16];    llmatches[9,5,0]=club[15];    llmatches[11,5,0]=club[4];    
		llmatches[7,5,1]=club[7];    llmatches[8,5,1]=club[6];    llmatches[9,5,1]=club[5];    llmatches[11,5,1]=club[14];    
		llmatches[7,6,0]=club[3];    llmatches[8,6,0]=club[5];     llmatches[9,6,0]=club[16];    llmatches[11,6,0]=club[3];      
		llmatches[7,6,1]=club[6];    llmatches[8,6,1]=club[2];    llmatches[9,6,1]=club[4];    llmatches[11,6,1]=club[15];    
		llmatches[7,7,0]=club[4];    llmatches[8,7,0]=club[4];    llmatches[9,7,0]=club[2];    llmatches[11,7,0]=club[2];    
		llmatches[7,7,1]=club[5];    llmatches[8,7,1]=club[3];    llmatches[9,7,1]=club[3];    llmatches[11,7,1]=club[16]; 

		llmatches[12,0,0]=club[1];    llmatches[13,0,0]=club[7];    llmatches[14,0,0]=club[1];    llmatches[15,0,0]=club[5];    
		llmatches[12,0,1]=club[8];    llmatches[13,0,1]=club[1];    llmatches[14,0,1]=club[6];    llmatches[15,0,1]=club[1];    
		llmatches[12,1,0]=club[9];    llmatches[13,1,0]=club[6];    llmatches[14,1,0]=club[7];     llmatches[15,1,0]=club[4];    
		llmatches[12,1,1]=club[7];    llmatches[13,1,1]=club[8];     llmatches[14,1,1]=club[5];    llmatches[15,1,1]=club[6];    
		llmatches[12,2,0]=club[10];    llmatches[13,2,0]=club[5];     llmatches[14,2,0]=club[8];    llmatches[15,2,0]=club[3];    
		llmatches[12,2,1]=club[6];    llmatches[13,2,1]=club[9];    llmatches[14,2,1]=club[4];    llmatches[15,2,1]=club[7];    
		llmatches[12,3,0]=club[11];    llmatches[13,3,0]=club[10];    llmatches[14,3,0]=club[9];    llmatches[15,3,0]=club[2];    
		llmatches[12,3,1]=club[5];    llmatches[13,3,1]=club[4];    llmatches[14,3,1]=club[3];    llmatches[15,3,1]=club[8];    
		llmatches[12,4,0]=club[12];    llmatches[13,4,0]=club[3];    llmatches[14,4,0]=club[10];    llmatches[15,4,0]=club[16];    
		llmatches[12,4,1]=club[4];    llmatches[13,4,1]=club[11];    llmatches[14,4,1]=club[2];    llmatches[15,4,1]=club[9];    
		llmatches[12,5,0]=club[13];    llmatches[13,5,0]=club[12];    llmatches[14,5,0]=club[11];    llmatches[15,5,0]=club[15];    
		llmatches[12,5,1]=club[3];    llmatches[13,5,1]=club[2];    llmatches[14,5,1]=club[16];    llmatches[15,5,1]=club[10];    
		llmatches[12,6,0]=club[14];    llmatches[13,6,0]=club[16];     llmatches[14,6,0]=club[12];    llmatches[15,6,0]=club[14];      
		llmatches[12,6,1]=club[2];    llmatches[13,6,1]=club[13];    llmatches[14,6,1]=club[15];    llmatches[15,6,1]=club[11];    
		llmatches[12,7,0]=club[15];    llmatches[13,7,0]=club[15];    llmatches[14,7,0]=club[13];    llmatches[15,7,0]=club[13];    
		llmatches[12,7,1]=club[16];    llmatches[13,7,1]=club[14];    llmatches[14,7,1]=club[14];    llmatches[15,7,1]=club[12]; 

		llmatches[16,0,0]=club[1];    llmatches[17,0,0]=club[3];    llmatches[19,0,0]=club[1];      
		llmatches[16,0,1]=club[4];    llmatches[17,0,1]=club[1];    llmatches[19,0,1]=club[2];    
		llmatches[16,1,0]=club[5];    llmatches[17,1,0]=club[2];    llmatches[19,1,0]=club[3];      
		llmatches[16,1,1]=club[3];    llmatches[17,1,1]=club[4];    llmatches[19,1,1]=club[16];       
		llmatches[16,2,0]=club[6];    llmatches[17,2,0]=club[16];    llmatches[19,2,0]=club[4];      
		llmatches[16,2,1]=club[2];    llmatches[17,2,1]=club[5];    llmatches[19,2,1]=club[15];     
		llmatches[16,3,0]=club[7];    llmatches[17,3,0]=club[6];    llmatches[19,3,0]=club[5];      
		llmatches[16,3,1]=club[16];    llmatches[17,3,1]=club[15];    llmatches[19,3,1]=club[14];      
		llmatches[16,4,0]=club[8];    llmatches[17,4,0]=club[14];    llmatches[19,4,0]=club[6];     
		llmatches[16,4,1]=club[15];    llmatches[17,4,1]=club[7];    llmatches[19,4,1]=club[13];     
		llmatches[16,5,0]=club[9];    llmatches[17,5,0]=club[8];    llmatches[19,5,0]=club[7];     
		llmatches[16,5,1]=club[14];    llmatches[17,5,1]=club[13];    llmatches[19,5,1]=club[12];    
		llmatches[16,6,0]=club[10];    llmatches[17,6,0]=club[12];    llmatches[19,6,0]=club[8];         
		llmatches[16,6,1]=club[13];    llmatches[17,6,1]=club[9];    llmatches[19,6,1]=club[11];    
		llmatches[16,7,0]=club[11];    llmatches[17,7,0]=club[11];    llmatches[19,7,0]=club[9];       
		llmatches[16,7,1]=club[12];    llmatches[17,7,1]=club[10];    llmatches[19,7,1]=club[10];    
	}

	if(league=="seriea"){
		samatches[2,0,0]=club[1];    samatches[3,0,0]=club[15];    samatches[4,0,0]=club[1];    samatches[5,0,0]=club[13];    
		samatches[2,0,1]=club[16];    samatches[3,0,1]=club[1];    samatches[4,0,1]=club[14];    samatches[5,0,1]=club[1];    
		samatches[2,1,0]=club[2];    samatches[3,1,0]=club[14];    samatches[4,1,0]=club[15];     samatches[5,1,0]=club[12];    
		samatches[2,1,1]=club[15];    samatches[3,1,1]=club[16];     samatches[4,1,1]=club[13];    samatches[5,1,1]=club[14];    
		samatches[2,2,0]=club[3];    samatches[3,2,0]=club[13];     samatches[4,2,0]=club[16];    samatches[5,2,0]=club[11];    
		samatches[2,2,1]=club[14];    samatches[3,2,1]=club[2];    samatches[4,2,1]=club[12];    samatches[5,2,1]=club[15];    
		samatches[2,3,0]=club[4];    samatches[3,3,0]=club[12];    samatches[4,3,0]=club[2];    samatches[5,3,0]=club[10];    
		samatches[2,3,1]=club[13];    samatches[3,3,1]=club[3];    samatches[4,3,1]=club[11];    samatches[5,3,1]=club[16];    
		samatches[2,4,0]=club[5];    samatches[3,4,0]=club[11];    samatches[4,4,0]=club[3];    samatches[5,4,0]=club[9];    
		samatches[2,4,1]=club[12];    samatches[3,4,1]=club[4];    samatches[4,4,1]=club[10];    samatches[5,4,1]=club[2];    
		samatches[2,5,0]=club[6];    samatches[3,5,0]=club[10];    samatches[4,5,0]=club[4];    samatches[5,5,0]=club[8];    
		samatches[2,5,1]=club[11];    samatches[3,5,1]=club[5];    samatches[4,5,1]=club[9];    samatches[5,5,1]=club[3];    
		samatches[2,6,0]=club[7];    samatches[3,6,0]=club[9];     samatches[4,6,0]=club[5];    samatches[5,6,0]=club[7];      
		samatches[2,6,1]=club[10];    samatches[3,6,1]=club[6];    samatches[4,6,1]=club[8];    samatches[5,6,1]=club[4];    
		samatches[2,7,0]=club[8];    samatches[3,7,0]=club[8];    samatches[4,7,0]=club[6];    samatches[5,7,0]=club[6];    
		samatches[2,7,1]=club[9];    samatches[3,7,1]=club[7];    samatches[4,7,1]=club[7];    samatches[5,7,1]=club[5];   

		samatches[7,0,0]=club[1];    samatches[8,0,0]=club[11];    samatches[9,0,0]=club[1];    samatches[11,0,0]=club[9];    
		samatches[7,0,1]=club[12];    samatches[8,0,1]=club[1];    samatches[9,0,1]=club[10];    samatches[11,0,1]=club[1];    
		samatches[7,1,0]=club[13];    samatches[8,1,0]=club[10];    samatches[9,1,0]=club[11];     samatches[11,1,0]=club[8];    
		samatches[7,1,1]=club[11];    samatches[8,1,1]=club[12];     samatches[9,1,1]=club[9];    samatches[11,1,1]=club[10];    
		samatches[7,2,0]=club[14];    samatches[8,2,0]=club[9];     samatches[9,2,0]=club[12];    samatches[11,2,0]=club[7];    
		samatches[7,2,1]=club[10];    samatches[8,2,1]=club[13];    samatches[9,2,1]=club[8];    samatches[11,2,1]=club[11];    
		samatches[7,3,0]=club[15];    samatches[8,3,0]=club[14];    samatches[9,3,0]=club[13];    samatches[11,3,0]=club[6];    
		samatches[7,3,1]=club[9];    samatches[8,3,1]=club[8];    samatches[9,3,1]=club[7];    samatches[11,3,1]=club[12];    
		samatches[7,4,0]=club[16];    samatches[8,4,0]=club[7];    samatches[9,4,0]=club[14];    samatches[11,4,0]=club[5];    
		samatches[7,4,1]=club[8];    samatches[8,4,1]=club[15];    samatches[9,4,1]=club[6];    samatches[11,4,1]=club[13];    
		samatches[7,5,0]=club[2];    samatches[8,5,0]=club[16];    samatches[9,5,0]=club[15];    samatches[11,5,0]=club[4];    
		samatches[7,5,1]=club[7];    samatches[8,5,1]=club[6];    samatches[9,5,1]=club[5];    samatches[11,5,1]=club[14];    
		samatches[7,6,0]=club[3];    samatches[8,6,0]=club[5];     samatches[9,6,0]=club[16];    samatches[11,6,0]=club[3];      
		samatches[7,6,1]=club[6];    samatches[8,6,1]=club[2];    samatches[9,6,1]=club[4];    samatches[11,6,1]=club[15];    
		samatches[7,7,0]=club[4];    samatches[8,7,0]=club[4];    samatches[9,7,0]=club[2];    samatches[11,7,0]=club[2];    
		samatches[7,7,1]=club[5];    samatches[8,7,1]=club[3];    samatches[9,7,1]=club[3];    samatches[11,7,1]=club[16]; 

		samatches[12,0,0]=club[1];    samatches[13,0,0]=club[7];    samatches[14,0,0]=club[1];    samatches[15,0,0]=club[5];    
		samatches[12,0,1]=club[8];    samatches[13,0,1]=club[1];    samatches[14,0,1]=club[6];    samatches[15,0,1]=club[1];    
		samatches[12,1,0]=club[9];    samatches[13,1,0]=club[6];    samatches[14,1,0]=club[7];     samatches[15,1,0]=club[4];    
		samatches[12,1,1]=club[7];    samatches[13,1,1]=club[8];     samatches[14,1,1]=club[5];    samatches[15,1,1]=club[6];    
		samatches[12,2,0]=club[10];    samatches[13,2,0]=club[5];     samatches[14,2,0]=club[8];    samatches[15,2,0]=club[3];    
		samatches[12,2,1]=club[6];    samatches[13,2,1]=club[9];    samatches[14,2,1]=club[4];    samatches[15,2,1]=club[7];    
		samatches[12,3,0]=club[11];    samatches[13,3,0]=club[10];    samatches[14,3,0]=club[9];    samatches[15,3,0]=club[2];    
		samatches[12,3,1]=club[5];    samatches[13,3,1]=club[4];    samatches[14,3,1]=club[3];    samatches[15,3,1]=club[8];    
		samatches[12,4,0]=club[12];    samatches[13,4,0]=club[3];    samatches[14,4,0]=club[10];    samatches[15,4,0]=club[16];    
		samatches[12,4,1]=club[4];    samatches[13,4,1]=club[11];    samatches[14,4,1]=club[2];    samatches[15,4,1]=club[9];    
		samatches[12,5,0]=club[13];    samatches[13,5,0]=club[12];    samatches[14,5,0]=club[11];    samatches[15,5,0]=club[15];    
		samatches[12,5,1]=club[3];    samatches[13,5,1]=club[2];    samatches[14,5,1]=club[16];    samatches[15,5,1]=club[10];    
		samatches[12,6,0]=club[14];    samatches[13,6,0]=club[16];     samatches[14,6,0]=club[12];    samatches[15,6,0]=club[14];      
		samatches[12,6,1]=club[2];    samatches[13,6,1]=club[13];    samatches[14,6,1]=club[15];    samatches[15,6,1]=club[11];    
		samatches[12,7,0]=club[15];    samatches[13,7,0]=club[15];    samatches[14,7,0]=club[13];    samatches[15,7,0]=club[13];    
		samatches[12,7,1]=club[16];    samatches[13,7,1]=club[14];    samatches[14,7,1]=club[14];    samatches[15,7,1]=club[12]; 

		samatches[16,0,0]=club[1];    samatches[17,0,0]=club[3];    samatches[19,0,0]=club[1];      
		samatches[16,0,1]=club[4];    samatches[17,0,1]=club[1];    samatches[19,0,1]=club[2];    
		samatches[16,1,0]=club[5];    samatches[17,1,0]=club[2];    samatches[19,1,0]=club[3];      
		samatches[16,1,1]=club[3];    samatches[17,1,1]=club[4];    samatches[19,1,1]=club[16];       
		samatches[16,4,0]=club[6];    samatches[17,2,0]=club[16];    samatches[19,2,0]=club[4];      
		samatches[16,2,1]=club[2];    samatches[17,2,1]=club[5];    samatches[19,2,1]=club[15];     
		samatches[16,3,0]=club[7];    samatches[17,3,0]=club[6];    samatches[19,3,0]=club[5];      
		samatches[16,3,1]=club[16];    samatches[17,3,1]=club[15];    samatches[19,3,1]=club[14];      
		samatches[16,4,0]=club[8];    samatches[17,4,0]=club[14];    samatches[19,4,0]=club[6];     
		samatches[16,4,1]=club[15];    samatches[17,4,1]=club[7];    samatches[19,4,1]=club[13];     
		samatches[16,5,0]=club[9];    samatches[17,5,0]=club[8];    samatches[19,5,0]=club[7];     
		samatches[16,5,1]=club[14];    samatches[17,5,1]=club[13];    samatches[19,5,1]=club[12];    
		samatches[16,6,0]=club[10];    samatches[17,6,0]=club[12];    samatches[19,6,0]=club[8];         
		samatches[16,6,1]=club[13];    samatches[17,6,1]=club[9];    samatches[19,6,1]=club[11];    
		samatches[16,7,0]=club[11];    samatches[17,7,0]=club[11];    samatches[19,7,0]=club[9];       
		samatches[16,7,1]=club[12];    samatches[17,7,1]=club[10];    samatches[19,7,1]=club[10];    
	}

	if(league=="bundes"){
		blmatches[2,0,0]=club[1];    blmatches[3,0,0]=club[15];    blmatches[4,0,0]=club[1];    blmatches[5,0,0]=club[13];    
		blmatches[2,0,1]=club[16];    blmatches[3,0,1]=club[1];    blmatches[4,0,1]=club[14];    blmatches[5,0,1]=club[1];    
		blmatches[2,1,0]=club[2];    blmatches[3,1,0]=club[14];    blmatches[4,1,0]=club[15];     blmatches[5,1,0]=club[12];    
		blmatches[2,1,1]=club[15];    blmatches[3,1,1]=club[16];     blmatches[4,1,1]=club[13];    blmatches[5,1,1]=club[14];    
		blmatches[2,2,0]=club[3];    blmatches[3,2,0]=club[13];     blmatches[4,2,0]=club[16];    blmatches[5,2,0]=club[11];    
		blmatches[2,2,1]=club[14];    blmatches[3,2,1]=club[2];    blmatches[4,2,1]=club[12];    blmatches[5,2,1]=club[15];    
		blmatches[2,3,0]=club[4];    blmatches[3,3,0]=club[12];    blmatches[4,3,0]=club[2];    blmatches[5,3,0]=club[10];    
		blmatches[2,3,1]=club[13];    blmatches[3,3,1]=club[3];    blmatches[4,3,1]=club[11];    blmatches[5,3,1]=club[16];    
		blmatches[2,4,0]=club[5];    blmatches[3,4,0]=club[11];    blmatches[4,4,0]=club[3];    blmatches[5,4,0]=club[9];    
		blmatches[2,4,1]=club[12];    blmatches[3,4,1]=club[4];    blmatches[4,4,1]=club[10];    blmatches[5,4,1]=club[2];    
		blmatches[2,5,0]=club[6];    blmatches[3,5,0]=club[10];    blmatches[4,5,0]=club[4];    blmatches[5,5,0]=club[8];    
		blmatches[2,5,1]=club[11];    blmatches[3,5,1]=club[5];    blmatches[4,5,1]=club[9];    blmatches[5,5,1]=club[3];    
		blmatches[2,6,0]=club[7];    blmatches[3,6,0]=club[9];     blmatches[4,6,0]=club[5];    blmatches[5,6,0]=club[7];      
		blmatches[2,6,1]=club[10];    blmatches[3,6,1]=club[6];    blmatches[4,6,1]=club[8];    blmatches[5,6,1]=club[4];    
		blmatches[2,7,0]=club[8];    blmatches[3,7,0]=club[8];    blmatches[4,7,0]=club[6];    blmatches[5,7,0]=club[6];    
		blmatches[2,7,1]=club[9];    blmatches[3,7,1]=club[7];    blmatches[4,7,1]=club[7];    blmatches[5,7,1]=club[5];   

		blmatches[7,0,0]=club[1];    blmatches[8,0,0]=club[11];    blmatches[9,0,0]=club[1];    blmatches[11,0,0]=club[9];    
		blmatches[7,0,1]=club[12];    blmatches[8,0,1]=club[1];    blmatches[9,0,1]=club[10];    blmatches[11,0,1]=club[1];    
		blmatches[7,1,0]=club[13];    blmatches[8,1,0]=club[10];    blmatches[9,1,0]=club[11];     blmatches[11,1,0]=club[8];    
		blmatches[7,1,1]=club[11];    blmatches[8,1,1]=club[12];     blmatches[9,1,1]=club[9];    blmatches[11,1,1]=club[10];    
		blmatches[7,2,0]=club[14];    blmatches[8,2,0]=club[9];     blmatches[9,2,0]=club[12];    blmatches[11,2,0]=club[7];    
		blmatches[7,2,1]=club[10];    blmatches[8,2,1]=club[13];    blmatches[9,2,1]=club[8];    blmatches[11,2,1]=club[11];    
		blmatches[7,3,0]=club[15];    blmatches[8,3,0]=club[14];    blmatches[9,3,0]=club[13];    blmatches[11,3,0]=club[6];    
		blmatches[7,3,1]=club[9];    blmatches[8,3,1]=club[8];    blmatches[9,3,1]=club[7];    blmatches[11,3,1]=club[12];    
		blmatches[7,4,0]=club[16];    blmatches[8,4,0]=club[7];    blmatches[9,4,0]=club[14];    blmatches[11,4,0]=club[5];    
		blmatches[7,4,1]=club[8];    blmatches[8,4,1]=club[15];    blmatches[9,4,1]=club[6];    blmatches[11,4,1]=club[13];    
		blmatches[7,5,0]=club[2];    blmatches[8,5,0]=club[16];    blmatches[9,5,0]=club[15];    blmatches[11,5,0]=club[4];    
		blmatches[7,5,1]=club[7];    blmatches[8,5,1]=club[6];    blmatches[9,5,1]=club[5];    blmatches[11,5,1]=club[14];    
		blmatches[7,6,0]=club[3];    blmatches[8,6,0]=club[5];     blmatches[9,6,0]=club[16];    blmatches[11,6,0]=club[3];      
		blmatches[7,6,1]=club[6];    blmatches[8,6,1]=club[2];    blmatches[9,6,1]=club[4];    blmatches[11,6,1]=club[15];    
		blmatches[7,7,0]=club[4];    blmatches[8,7,0]=club[4];    blmatches[9,7,0]=club[2];    blmatches[11,7,0]=club[2];    
		blmatches[7,7,1]=club[5];    blmatches[8,7,1]=club[3];    blmatches[9,7,1]=club[3];    blmatches[11,7,1]=club[16]; 

		blmatches[12,0,0]=club[1];    blmatches[13,0,0]=club[7];    blmatches[14,0,0]=club[1];    blmatches[15,0,0]=club[5];    
		blmatches[12,0,1]=club[8];    blmatches[13,0,1]=club[1];    blmatches[14,0,1]=club[6];    blmatches[15,0,1]=club[1];    
		blmatches[12,1,0]=club[9];    blmatches[13,1,0]=club[6];    blmatches[14,1,0]=club[7];     blmatches[15,1,0]=club[4];    
		blmatches[12,1,1]=club[7];    blmatches[13,1,1]=club[8];     blmatches[14,1,1]=club[5];    blmatches[15,1,1]=club[6];    
		blmatches[12,2,0]=club[10];    blmatches[13,2,0]=club[5];     blmatches[14,2,0]=club[8];    blmatches[15,2,0]=club[3];    
		blmatches[12,2,1]=club[6];    blmatches[13,2,1]=club[9];    blmatches[14,2,1]=club[4];    blmatches[15,2,1]=club[7];    
		blmatches[12,3,0]=club[11];    blmatches[13,3,0]=club[10];    blmatches[14,3,0]=club[9];    blmatches[15,3,0]=club[2];    
		blmatches[12,3,1]=club[5];    blmatches[13,3,1]=club[4];    blmatches[14,3,1]=club[3];    blmatches[15,3,1]=club[8];    
		blmatches[12,4,0]=club[12];    blmatches[13,4,0]=club[3];    blmatches[14,4,0]=club[10];    blmatches[15,4,0]=club[16];    
		blmatches[12,4,1]=club[4];    blmatches[13,4,1]=club[11];    blmatches[14,4,1]=club[2];    blmatches[15,4,1]=club[9];    
		blmatches[12,5,0]=club[13];    blmatches[13,5,0]=club[12];    blmatches[14,5,0]=club[11];    blmatches[15,5,0]=club[15];    
		blmatches[12,5,1]=club[3];    blmatches[13,5,1]=club[2];    blmatches[14,5,1]=club[16];    blmatches[15,5,1]=club[10];    
		blmatches[12,6,0]=club[14];    blmatches[13,6,0]=club[16];     blmatches[14,6,0]=club[12];    blmatches[15,6,0]=club[14];      
		blmatches[12,6,1]=club[2];    blmatches[13,6,1]=club[13];    blmatches[14,6,1]=club[15];    blmatches[15,6,1]=club[11];    
		blmatches[12,7,0]=club[15];    blmatches[13,7,0]=club[15];    blmatches[14,7,0]=club[13];    blmatches[15,7,0]=club[13];    
		blmatches[12,7,1]=club[16];    blmatches[13,7,1]=club[14];    blmatches[14,7,1]=club[14];    blmatches[15,7,1]=club[12]; 

		blmatches[16,0,0]=club[1];    blmatches[17,0,0]=club[3];    blmatches[19,0,0]=club[1];      
		blmatches[16,0,1]=club[4];    blmatches[17,0,1]=club[1];    blmatches[19,0,1]=club[2];    
		blmatches[16,1,0]=club[5];    blmatches[17,1,0]=club[2];    blmatches[19,1,0]=club[3];      
		blmatches[16,1,1]=club[3];    blmatches[17,1,1]=club[4];    blmatches[19,1,1]=club[16];       
		blmatches[16,2,0]=club[6];    blmatches[17,2,0]=club[16];    blmatches[19,2,0]=club[4];      
		blmatches[16,2,1]=club[2];    blmatches[17,2,1]=club[5];    blmatches[19,2,1]=club[15];     
		blmatches[16,3,0]=club[7];    blmatches[17,3,0]=club[6];    blmatches[19,3,0]=club[5];      
		blmatches[16,3,1]=club[16];    blmatches[17,3,1]=club[15];    blmatches[19,3,1]=club[14];      
		blmatches[16,4,0]=club[8];    blmatches[17,4,0]=club[14];    blmatches[19,4,0]=club[6];     
		blmatches[16,4,1]=club[15];    blmatches[17,4,1]=club[7];    blmatches[19,4,1]=club[13];     
		blmatches[16,5,0]=club[9];    blmatches[17,5,0]=club[8];    blmatches[19,5,0]=club[7];     
		blmatches[16,5,1]=club[14];    blmatches[17,5,1]=club[13];    blmatches[19,5,1]=club[12];    
		blmatches[16,6,0]=club[10];    blmatches[17,6,0]=club[12];    blmatches[19,6,0]=club[8];         
		blmatches[16,6,1]=club[13];    blmatches[17,6,1]=club[9];    blmatches[19,6,1]=club[11];    
		blmatches[16,7,0]=club[11];    blmatches[17,7,0]=club[11];    blmatches[19,7,0]=club[9];       
		blmatches[16,7,1]=club[12];    blmatches[17,7,1]=club[10];    blmatches[19,7,1]=club[10];    
	}

}

void  SetDashboard (){
	ShowFixtures();
}

void  OutOfJob (){   //set dashboard as when player is sacked or resigned
	TeamName.GetComponent<Text>().text="";
	colour.GetComponent<Image>().color=Color.white;
	Money.SetActive(false);

}
void  InJob (){
	TeamName.GetComponent<Text>().text=global.team;
	if(global.category=="clubs"){
		colour.GetComponent<Image>().color=clubmaincolour[global.id];
		TeamName.GetComponent<Text>().color=clubtextcolour[global.id];
		Money.SetActive(true);
		Money.GetComponent<Text>().text="$"+money[global.id].ToString();}
	else{
		colour.GetComponent<Image>().color=maincolour[global.id];
		TeamName.GetComponent<Text>().color=textcolour[global.id];
	}
	string expectations="";
	if(global.category=="clubs")
	{if(clubreputation[global.id]>187)
		{ expectations="win the league this season.";}
		if(clubreputation[global.id]>178 && clubreputation[global.id]<=187)
			expectations="challenge for the league title this season.";
		if(clubreputation[global.id]>168 && clubreputation[global.id]<=178)
			expectations="qualify for the champions league this season.";
		if(clubreputation[global.id]>160 && clubreputation[global.id]<=168)
			expectations="qualify for european competition this season.";
		if(clubreputation[global.id]>150 && clubreputation[global.id]<=160)
			expectations="finish in the top half of the league table.";
		if(clubreputation[global.id]<=150)
			expectations="avoid relegation.";
	}
	else
	{if(reputation[global.id]>187 || countryname[global.id]=="Brazil")
		expectations="win the world cup.";
	else if(reputation[global.id]>178 && reputation[global.id]<=187)
		expectations="reach the semi final of the world cup.";
	else if(reputation[global.id]>160 && reputation[global.id]<=178)
		expectations="qualify for the world cup.";
	if(reputation[global.id]>140 && reputation[global.id]<=160)
		expectations="make a good performance of the team in competitions.";
	if(reputation[global.id]<=140 )
		expectations="uphold the country's pride during competitions.";
}
	news="Welcome "+global.managername+". The board would like to welcome you as manager of "+global.team+". The board expects that "+
		"you "+expectations;
	HideFixtures();
	if(newspaper==null)
		newspaper=GameObject.Find("Canvas").transform.Find("Newspaper").gameObject;
	newspaper.SetActive(true);
	newspaper.GetComponent<Text>().text=news;
	state="news";
}

void  ResetMoney (){
	Money.GetComponent<Text>().text="$"+money[global.id].ToString();
}

void  SaveClubs (){
	var file= Application.dataPath + "/updatedclubs"; 
	StreamWriter writer = new StreamWriter(file,false);
	for(int k=1;k<=96;k++){
		writer.WriteLine(money[k]);
		writer.WriteLine(qualifiedleague[k]);
		writer.WriteLine(communityshield[k]);
		writer.WriteLine(clubaggregate[k]);///////////
		writer.WriteLine( clubgoals[k]);///////////////
		writer.WriteLine(clubeupoints[k]);////////////////european competition points
		writer.WriteLine( clubeugoals[k]);
		writer.WriteLine(clubleaguepoints[k]);///league points
		writer.WriteLine(clubyellowcards[k]);///////////
		writer.WriteLine(clubawaygoals[k]);///////////
		writer.WriteLine(clubleaguecup[k]);
		for(int i=0;i<=22;i++){
			writer.WriteLine(clubplayers[k,i]);
		}
	}
	writer.Close();
}

void  SaveCountries (){
	var file= Application.dataPath + "/updatedcountries"; 
	StreamWriter writer = new StreamWriter(file,false);
	for(int k=1;k<=146;k++){
		writer.WriteLine(goals[k]);
		writer.WriteLine(qualgoals[k]);  //remember to clean these stats after each competition
		writer.WriteLine(qualpoints[k]);
		writer.WriteLine(qualyellowcards[k]);
		writer.WriteLine(points[k]);// major competition points
		writer.WriteLine(yellowcards[k]);
	}
	writer.Close();
}

void  ResetConditions (){
	global.p1condition=0;global.p2condition=0;global.p3condition=0;global.p4condition=0;global.p5condition=0;
	global.p6condition=0;global.p7condition=0;global.p8condition=0;global.p9condition=0;global.p10condition=0;
	global.subbed1=false;global.subbed2=false;global.subbed3=false;global.subbed4=false;global.subbed5=false;global.subbed6=false;global.subbed7=false;
	global.subbed8=false;global.subbed9=false;global.subbed10=false;
}

void  Save (){

	PlayerPrefs.SetInt("inited", (global.inited ? 1:0));
	PlayerPrefs.SetString("managername",global.managername);
	PlayerPrefs.SetString("nationality",global.nationality);
	PlayerPrefs.SetInt("toldsuccess",(global.toldsuccess ? 1:0));
	PlayerPrefs.SetInt("boardopinioned",(global.boardopinioned?1:0));
	PlayerPrefs.SetInt("managertoldwon10",(global.managertoldwon10?1:0));  //manager told if he has won 10 trophies
	PlayerPrefs.SetInt("bmanagertoldwon14",(global.managertoldwon14?1:0));
	PlayerPrefs.SetInt("managertoldtopofworld",(global.managertoldtopofworld?1:0));  //when the manager reaches pinnacle
	PlayerPrefs.SetInt("matcheswon",global.matcheswon);
	PlayerPrefs.SetInt("matcheslost",global.matcheslost);       // reset these when sacked or resigns
	PlayerPrefs.SetInt("sacked",(global.sacked?1:0));
	PlayerPrefs.SetInt("retired",(global.retired?1:0));
	int i=1;
	foreach(var club in global.managedclubs){
		PlayerPrefs.SetInt("managedclub"+club,club);i++; }//club is an id index
	i=1;
	foreach(var country in global.managedcountries){
		PlayerPrefs.SetInt("managedcounties"+country,country);i++;}
	PlayerPrefs.SetString("mentality", global.mentality);             ////team instructions      normal, attacking, defensive , overload
	PlayerPrefs.SetInt( "formation",global.formation);           // 442, 433,  541, 352
	PlayerPrefs.SetInt( "width",global.width);                 //0-very narrow 1-narrow -2--normal 3-wide 4- very wide
	PlayerPrefs.SetString( "passingstyle",global.passingstyle);  // mixed,  short, direct, long
	PlayerPrefs.SetString("playstyle", global.playstyle);   //normal / onetwo / fwdruns / tikitaka 
	PlayerPrefs.SetString("marking", global.marking);       // zone / man / backup / cutoff / 
	PlayerPrefs.SetString("pressing", global.pressing);     // laidback, normal, pressure
	PlayerPrefs.SetString("tackling", global.tackling);          //Individual and team instructions  /hard / normal / soft
	PlayerPrefs.SetString("attacking", global.attacking);       // normal, channels, hugoffside
	PlayerPrefs.SetInt("freekicktaker", global.freekicktaker);   //the player's int position in squad
	PlayerPrefs.SetInt("penaltytaker", global.penaltytaker);
	PlayerPrefs.SetInt("cornertaker",  global.cornertaker);

	PlayerPrefs.SetString("team", global.team);
	PlayerPrefs.SetString("category",global.category);
	PlayerPrefs.SetString("league",global.league);
	PlayerPrefs.SetInt("id",global.id);        //own team id
	//PlayerPrefs.SetString("icon",icon);

	PlayerPrefs.SetInt("trophies", global.trophies);
	PlayerPrefs.SetInt("points", global.points);
	PlayerPrefs.SetInt("majortrophies",global.majortrophies);
	PlayerPrefs.SetInt("minortrophies", global.minortrophies);
	PlayerPrefs.SetInt("premierleagues",global.premierleagues);
	PlayerPrefs.SetInt("communityshields",global.communityshields);
	PlayerPrefs.SetInt("facups",global.facups);
	PlayerPrefs.SetInt("leaguecups",global.leaguecups);
	PlayerPrefs.SetInt("championsleagues",global.championsleagues);
	PlayerPrefs.SetInt("iuefacups",global.uefacups);
	PlayerPrefs.SetInt("eurovases", global.eurovases);
	PlayerPrefs.SetInt("spanishleagues", global.spanishleagues);
	PlayerPrefs.SetInt("italianleagues",global.italianleagues);
	PlayerPrefs.SetInt("igermanleagues", global.germanleagues);
	PlayerPrefs.SetInt("spanishcups",global.spanishcups);
	PlayerPrefs.SetInt("italiancups",global.italiancups);
	PlayerPrefs.SetInt("germancups", global.germancups);
	PlayerPrefs.SetInt("clubworldcups",global.clubworldcups);
	PlayerPrefs.SetInt("worldcups",global.worldcups);
	PlayerPrefs.SetInt("euros", global.euros);
	PlayerPrefs.SetInt("confederationscups",global.confederationscups);
	PlayerPrefs.SetInt("asiancups",global.asiancups);
	PlayerPrefs.SetInt("goldcups", global.goldcups);
	PlayerPrefs.SetInt("copaamericas",global.copaamericas);
	PlayerPrefs.SetInt("afconcups",global.afconcups);
	PlayerPrefs.SetInt("oceancups", global.oceancups);
	PlayerPrefs.SetInt("cecafacups",global.cecafacups);
	PlayerPrefs.SetInt("cosafacups",global.cosafacups);
	PlayerPrefs.SetInt("cabralcups",global.cabralcups);
	PlayerPrefs.SetInt("seagames",global.seagames);
	PlayerPrefs.SetInt("thirdplaces", global.thirdplaces);
	PlayerPrefs.SetInt("fromdashboard", (global.fromdashboard?1:0));
	PlayerPrefs.SetInt("age",global.age);
	PlayerPrefs.SetInt("communityshieldwinner",communityshieldwinner);
	PlayerPrefs.SetInt("spanishsupercupwinner",spanishsupercupwinner);
	PlayerPrefs.SetInt("italiansupercupwinner",italiansupercupwinner);
	PlayerPrefs.SetInt("germansupercupwinner",germansupercupwinner);
	PlayerPrefs.SetInt("timessacked",global.timessacked);
	//remember it's control holding this save function
	PlayerPrefs.SetInt("week", week);
	PlayerPrefs.SetString("month", month);
	PlayerPrefs.SetInt("year", year);
	PlayerPrefs.SetInt("realweek",realweek);
	PlayerPrefs.SetInt("realfixture",realfixture);
	PlayerPrefs.SetString("state",state);
	PlayerPrefs.Save();
	SaveFixtures();
	SaveCountries();
	SaveClubs();
	SaveOwnPlayers();
}

void  SaveFixtures (){  

	var file= Application.dataPath + "/fixtures"; 
	StreamWriter writer = new StreamWriter(file,false);
	for(int k=0;k<18;k++)
		writer.WriteLine(plclubs[k]);  //premier league clubs
	for(int k=0;k<3;k++)
		writer.WriteLine(relegated[k]);
	for(int k=1;k<=21;k++){
		for(int l=0;l<=8;l++){
			for(int m=0;m<2;m++){
				writer.WriteLine( plmatches[k,l,m]); //
			} } }
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				writer.WriteLine(llmatches[k,l,m]);}}}
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				writer.WriteLine(samatches[k,l,m]);}}}
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				writer.WriteLine(blmatches[k,l,m]);}}}
	for(int k=1;k<3;k++){
		writer.WriteLine(PLcommunityshield[k]);}
	for(int k=1;k<3;k++){
		writer.WriteLine(LLcommunityshield[k]);}
	for(int k=1;k<3;k++){
		writer.WriteLine(SAcommunityshield[k]);}
	for(int k=1;k<3;k++){
		writer.WriteLine(BLcommunityshield[k]);}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(FAcup_playoffs1[k,m]);}}  // overall last 2 pairs playoff then last 2 in pl play off 2 winners & 3rd last plays 17
	for(int k=1;k<4;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(FAcup_playoffs2[k,m]); }} //3 instead of 2 so that digit 1 can be used
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(FAcup_round1[k,m]); }} //group of 16 after last 3 winners of last 3 playoffs
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(FAcup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(FAcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine(FAcup_final[k]);}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Leaguecup_round1[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Leaguecup_semi[k,m]);}}//semi final
	for(int k=1;k<3;k++){
		writer.WriteLine(Leaguecup_final[k]);}//final
	for(int k=1;k<9;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine(Championsleague_group[k,m]);}} //group , team
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Championsleague_round16[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Championsleague_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Championsleague_semifinal[k,m]);}}
	for(int k=1;k<3;k++)
		writer.WriteLine(Championsleague_final[k]);
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine(Uefacup_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine(Uefacup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Uefacup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Uefacup_final[k]);}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Spanishcup_round1[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Spanishcup_quarterfinal[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Spanishcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Spanishcup_final[k]);}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Italiancup_round1[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Italiancup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Italiancup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Italiancup_final[k]);}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Germancup_round1[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Germancup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Germancup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Germancup_final[k]);}
	for(int k=1;k<15;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Friendly[k,m]);}}
	for(int k=1;k<8;k++){
		for(int m=1;m<7;m++){
			writer.WriteLine( WCQualifier_eu_group[k,m]);}}  //7 groups of 6
	for(int k=1;k<5;k++){
		for(int m=1;m<6;m++){
			writer.WriteLine( WCQualifier_as_group[k,m]); }}
	for(int k=1;k<6;k++){
		for(int m=1;m<6;m++){
			writer.WriteLine( WCQualifier_af_group[k,m]); }}//5 groups of 5
	for(int k=1;k<9;k++){
		writer.WriteLine( WCQualifier_oc_group[k]); }  //10 teams in one league
	for(int k=1;k<17;k++){
		writer.WriteLine( WCQualifier_na_group[k]);}
	for(int k=1;k<11;k++){
		writer.WriteLine( WCQualifier_sa_group[k]);}
	for(int k=1;k<9;k++){
		for(int m=1;m<6;m++){
			writer.WriteLine( EUROqualifier_group[k,m]); }} //8 groups of 5
	for(int k=1;k<26;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( WCQualifier_playoff[k,m]);}}  //first a playoff of all african teams is done
	for(int k=1;k<9;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine( worldcup_group[k,m]);}}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( worldcup_round16[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( worldcup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( worldcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( worldcup_third[k]);}
	for(int k=1;k<3;k++){
		writer.WriteLine( worldcup_final[k]);}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( AFCONQualifiers_playoff[k,m]);}}  //2 playoff of 4 teams
	for(int k=1;k<9;k++){
		for(int m=1;m<7;m++){
			writer.WriteLine( AFCONqualifier_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine( EURO_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( EURO_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( EURO_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( EURO_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine( AFCON_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( AFCON_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( AFCON_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( AFCON_final[k]);}
	for(int k=1;k<3;k++){
		for(int m=1;m<6;m++){
			writer.WriteLine( CopaAmerica[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Copa_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Copa_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine( Goldcup_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Goldcup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( Goldcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( Goldcup_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( ONCcup_round1[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( ONCcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( ONCcup_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<6;m++){
			writer.WriteLine( ASIANcup_group[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( ASIANcup_quarterfinal[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( ASIANcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( ASIANcup_final[k]);}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( SEAgames_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( SEAgames_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( SEAgames_round1[k,m]);}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CECAFAcup_round1[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CECAFAcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( CECAFAcup_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( COSAFAcup_round1[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( COSAFAcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( COSAFAcup_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CABRALcup_round1[k,m]);}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CABRALcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( CABRALcup_final[k]);}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			writer.WriteLine( CONFEDcup_round1[k,m]);}} //2 extra teams in last 2 groups
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CONFEDcup_semifinal[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( CONFEDcup_final[k]);}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			writer.WriteLine( CWC_semi[k,m]);}}
	for(int k=1;k<3;k++){
		writer.WriteLine( CWC_final[k]);}
	for(int k=1;k<3;k++){
		writer.WriteLine( EUROVase[k]);}
	for(int k=1;k<4;k++){
		writer.WriteLine(winner_facupplayoff1[k]);}
	for(int k=1;k<4;k++){
		writer.WriteLine( winner_facupplayoff2[k]);}
	writer.WriteLine(worldcup_pool.Count);
	for(int k=0;k<worldcup_pool.Count;k++){
		writer.WriteLine( worldcup_pool[k]);}
	writer.WriteLine(WCQAfrica_pool.Count);
	for(int k=0;k<WCQAfrica_pool.Count;k++){
		writer.WriteLine( WCQAfrica_pool[k]);}
	writer.Close();
}

void  LoadClubs (){
	var file= Application.dataPath + "/updatedclubs"; 
	StreamReader reader = new StreamReader(file);  //todo
	for(int k=1;k<=96;k++){
		money[k]=int.Parse(reader.ReadLine());
		qualifiedleague[k]=reader.ReadLine();
		communityshield[k]=(reader.ReadLine()=="True");
		clubaggregate[k]=int.Parse(reader.ReadLine());///////////
		clubgoals[k]=int.Parse(reader.ReadLine( ));///////////////
		clubeupoints[k]=int.Parse(reader.ReadLine());////////////////european competition points
		clubeugoals[k]=int.Parse(reader.ReadLine());
		clubleaguepoints[k]=int.Parse(reader.ReadLine());///league points
		clubyellowcards[k]=int.Parse(reader.ReadLine());///////////
		clubawaygoals[k]=int.Parse(reader.ReadLine());///////////
		clubleaguecup[k]=(reader.ReadLine()=="True");
		for(int i=0;i<=22;i++){
			clubplayers[k,i]= int.Parse(reader.ReadLine());
		}
	}
	reader.Close();
}

void  LoadCountries (){
	var file= Application.dataPath + "/updatedcountries"; 
	StreamReader reader = new StreamReader(file); 
	for(int k=1;k<=146;k++){
		goals[k]=int.Parse(reader.ReadLine());
		qualgoals[k]=int.Parse(reader.ReadLine());  //remember to clean these stats after each competition
		qualpoints[k]=int.Parse(reader.ReadLine());
		qualyellowcards[k]=int.Parse(reader.ReadLine());
		points[k]=int.Parse(reader.ReadLine());// major competition points
		yellowcards[k]=int.Parse(reader.ReadLine());
	}
	reader.Close();  
}

void  LoadFixtures (){  

	var file= Application.dataPath + "/fixtures"; 
	StreamReader reader = new StreamReader(file);
	for(int k=0;k<18;k++)
		plclubs[k]=int.Parse(reader.ReadLine());  //premier league clubs
	for(int k=0;k<3;k++)
		relegated[k]=int.Parse(reader.ReadLine());
	for(int k=1;k<=21;k++){
		for(int l=0;l<=8;l++){
			for(int m=0;m<2;m++){
				plmatches[k,l,m]=int.Parse(reader.ReadLine()); //
			} } }
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				llmatches[k,l,m]=int.Parse(reader.ReadLine());}}}
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				samatches[k,l,m] =int.Parse(reader.ReadLine());}}}
	for(int k=1;k<=19;k++){
		for(int l=0;l<=7;l++){
			for(int m=0;m<2;m++){
				blmatches[k,l,m]=int.Parse(reader.ReadLine());}}}
	for(int k=1;k<3;k++){
		PLcommunityshield[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		LLcommunityshield[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		SAcommunityshield[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		BLcommunityshield[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			FAcup_playoffs1[k,m]=int.Parse(reader.ReadLine());}}  // overall last 2 pairs playoff then last 2 in pl play off 2 winners & 3rd last plays 17
	for(int k=1;k<4;k++){
		for(int m=1;m<3;m++){
			FAcup_playoffs2[k,m]=int.Parse(reader.ReadLine()); }} //3 instead of 2 so that digit 1 can be used
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			FAcup_round1[k,m]=int.Parse(reader.ReadLine()); }} //group of 16 after last 3 winners of last 3 playoffs
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			FAcup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			FAcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		FAcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			Leaguecup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Leaguecup_semi[k,m]=int.Parse(reader.ReadLine());}}//semi final
	for(int k=1;k<3;k++){
		Leaguecup_final[k]=int.Parse(reader.ReadLine());}//final
	for(int k=1;k<9;k++){
		for(int m=1;m<5;m++){
			Championsleague_group[k,m]=int.Parse(reader.ReadLine());}} //group , team
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			Championsleague_round16[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Championsleague_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Championsleague_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++)
		Championsleague_final[k]=int.Parse(reader.ReadLine());
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			Uefacup_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Uefacup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Uefacup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Uefacup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			Spanishcup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Spanishcup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Spanishcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Spanishcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			Italiancup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Italiancup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Italiancup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Italiancup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			Germancup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Germancup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Germancup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Germancup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<15;k++){
		for(int m=1;m<3;m++){
			Friendly[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<8;k++){
		for(int m=1;m<7;m++){
			WCQualifier_eu_group[k,m]=int.Parse(reader.ReadLine());}}  //7 groups of 6
	for(int k=1;k<5;k++){
		for(int m=1;m<6;m++){
			WCQualifier_as_group[k,m]=int.Parse(reader.ReadLine()); }}
	for(int k=1;k<6;k++){
		for(int m=1;m<6;m++){
			WCQualifier_af_group[k,m]=int.Parse(reader.ReadLine()); }}//5 groups of 5
	for(int k=1;k<9;k++){
		WCQualifier_oc_group[k]=int.Parse(reader.ReadLine()); }  //10 teams in one league
	for(int k=1;k<17;k++){
		WCQualifier_na_group[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<11;k++){
		WCQualifier_sa_group[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<9;k++){
		for(int m=1;m<6;m++){
			EUROqualifier_group[k,m]=int.Parse(reader.ReadLine()); }} //8 groups of 5
	for(int k=1;k<26;k++){
		for(int m=1;m<3;m++){
			WCQualifier_playoff[k,m]=int.Parse(reader.ReadLine());}}  //first a playoff of all african teams is done
	for(int k=1;k<9;k++){
		for(int m=1;m<5;m++){
			worldcup_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<9;k++){
		for(int m=1;m<3;m++){
			worldcup_round16[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			worldcup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			worldcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		worldcup_third[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		worldcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			AFCONQualifiers_playoff[k,m]=int.Parse(reader.ReadLine());}}  //2 playoff of 4 teams
	for(int k=1;k<9;k++){
		for(int m=1;m<7;m++){
			AFCONqualifier_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			EURO_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			EURO_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			EURO_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		EURO_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			AFCON_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			AFCON_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			AFCON_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		AFCON_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		for(int m=1;m<6;m++){
			CopaAmerica[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Copa_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Copa_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			Goldcup_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			Goldcup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			Goldcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		Goldcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			ONCcup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			ONCcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		ONCcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<6;m++){
			ASIANcup_group[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			ASIANcup_quarterfinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			ASIANcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		ASIANcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			SEAgames_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		SEAgames_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			SEAgames_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			CECAFAcup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			CECAFAcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		CECAFAcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			COSAFAcup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			COSAFAcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		COSAFAcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<3;m++){
			CABRALcup_round1[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			CABRALcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		CABRALcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<5;k++){
		for(int m=1;m<5;m++){
			CONFEDcup_round1[k,m]=int.Parse(reader.ReadLine());}} //2 extra teams in last 2 groups
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			CONFEDcup_semifinal[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		CONFEDcup_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		for(int m=1;m<3;m++){
			CWC_semi[k,m]=int.Parse(reader.ReadLine());}}
	for(int k=1;k<3;k++){
		CWC_final[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<3;k++){
		EUROVase[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<4;k++){
		winner_facupplayoff1[k]=int.Parse(reader.ReadLine());}
	for(int k=1;k<4;k++){
		winner_facupplayoff2[k]=int.Parse(reader.ReadLine());}
	var count=int.Parse(reader.ReadLine());
	if(count>0){
		for(int k=0;k<count;k++){
			var item=int.Parse(reader.ReadLine());
			worldcup_pool.Add(item);} }
	count=int.Parse(reader.ReadLine());
	if(count>0){
		for(int k=0;k<count;k++){
			var item=int.Parse(reader.ReadLine());
			WCQAfrica_pool.Add(item);} }
	reader.Close();
}

void  Load (){

	//global.inited=(PlayerPrefs.GetInt("inited")!=0);   not necessary,   bug fix
	global.managername=PlayerPrefs.GetString("managername");
	global.nationality=PlayerPrefs.GetString("nationality");
	global.toldsuccess=(PlayerPrefs.GetInt("toldsuccess")!=0);
	global.boardopinioned=(PlayerPrefs.GetInt("boardopinioned")!=0);
	global.managertoldwon10=(PlayerPrefs.GetInt("managertoldwon10")!=0);  //manager told if he has won 10 trophies
	global.managertoldwon14=(PlayerPrefs.GetInt("bmanagertoldwon14")!=0);
	global.managertoldtopofworld=(PlayerPrefs.GetInt("managertoldtopofworld")!=0);  //when the manager reaches pinnacle
	global.matcheswon=PlayerPrefs.GetInt("matcheswon");
	global.matcheslost=PlayerPrefs.GetInt("matcheslost");       // reset these when sacked or resigns
	global.sacked=(PlayerPrefs.GetInt("sacked")!=0);
	global.retired=(PlayerPrefs.GetInt("retired")!=0);
	int i=1;
	foreach(var club in global.managedclubs){
		if(PlayerPrefs.HasKey("managedclub"+club))
			global.managedclubs[club]=PlayerPrefs.GetInt("managedclub"+club);i++; }//club is an id index
	i=1;
	foreach(var country in global.managedcountries){
		if(PlayerPrefs.HasKey("managedcounties"+country))
			global.managedcountries[country]=PlayerPrefs.GetInt("managedcounties"+club);i++;}
	global.mentality=PlayerPrefs.GetString("mentality");             ////team instructions      normal, attacking, defensive , overload
	global.formation=PlayerPrefs.GetInt( "formation");           // 442, 433,  541, 352
	global.width=PlayerPrefs.GetInt( "width");                 //0-very narrow 1-narrow -2--normal 3-wide 4- very wide
	global.passingstyle=PlayerPrefs.GetString( "passingstyle");  // mixed,  short, direct, long
	global.playstyle=PlayerPrefs.GetString("playstyle" );   //normal / onetwo / fwdruns / tikitaka 
	global.marking=PlayerPrefs.GetString("marking" );       // zone / man / backup / cutoff / 
	global.pressing=PlayerPrefs.GetString("pressing" );     // laidback, normal, pressure
	global.tackling=PlayerPrefs.GetString("tackling" );          //Individual and team instructions  /hard / normal / soft
	global.attacking=PlayerPrefs.GetString("attacking" );       // normal, channels, hugoffside
	global.freekicktaker=PlayerPrefs.GetInt("freekicktaker" );   //the =Player's int position in squad
	global.penaltytaker=PlayerPrefs.GetInt("penaltytaker" );
	global.cornertaker=PlayerPrefs.GetInt("cornertaker"  );

	global.team=PlayerPrefs.GetString("team" );
	global.category=PlayerPrefs.GetString("category");
	global.league=PlayerPrefs.GetString("league");
	global.id=PlayerPrefs.GetInt("id");        //own team id
	//=PlayerPrefs.GetString("icon",icon);

	global.trophies=PlayerPrefs.GetInt("trophies" );
	global.points=PlayerPrefs.GetInt("points" );
	global.majortrophies=PlayerPrefs.GetInt("majortrophies");
	global.minortrophies=PlayerPrefs.GetInt("minortrophies" );
	global.premierleagues=PlayerPrefs.GetInt("premierleagues");
	global.communityshields=PlayerPrefs.GetInt("communityshields");
	global.facups=PlayerPrefs.GetInt("facups");
	global.leaguecups=PlayerPrefs.GetInt("leaguecups");
	global.championsleagues=PlayerPrefs.GetInt("championsleagues");
	global.uefacups=PlayerPrefs.GetInt("iuefacups");
	global.eurovases=PlayerPrefs.GetInt("eurovases");
	global.spanishleagues=PlayerPrefs.GetInt("spanishleagues" );
	global.italianleagues=PlayerPrefs.GetInt("italianleagues");
	global.germanleagues=PlayerPrefs.GetInt("igermanleagues" );
	global.spanishcups=PlayerPrefs.GetInt("spanishcups");
	global.italiancups=PlayerPrefs.GetInt("italiancups");
	global.germancups=PlayerPrefs.GetInt("germancups" );
	global.clubworldcups=PlayerPrefs.GetInt("clubworldcups");
	global.worldcups=PlayerPrefs.GetInt("worldcups");
	global.euros=PlayerPrefs.GetInt("euros" );
	global.confederationscups=PlayerPrefs.GetInt("confederationscups");
	global.asiancups=PlayerPrefs.GetInt("asiancups");
	global.goldcups=PlayerPrefs.GetInt("goldcups" );
	global.copaamericas=PlayerPrefs.GetInt("copaamericas");
	global.afconcups=PlayerPrefs.GetInt("afconcups");
	global.oceancups=PlayerPrefs.GetInt("oceancups" );
	global.cecafacups=PlayerPrefs.GetInt("cecafacups");
	global.cosafacups=PlayerPrefs.GetInt("cosafacups");
	global.cabralcups=PlayerPrefs.GetInt("cabralcups");
	global.seagames=PlayerPrefs.GetInt("seagames");
	global.thirdplaces=PlayerPrefs.GetInt("thirdplaces" );
	global.fromdashboard=(PlayerPrefs.GetInt("fromdashboard")!=0);
	global.age=PlayerPrefs.GetInt("age");
	//=PlayerPrefs.GetInt("frommatch",(frommatch?1:0));
	communityshieldwinner=PlayerPrefs.GetInt("communityshieldwinner");
	spanishsupercupwinner=PlayerPrefs.GetInt("spanishsupercupwinner");
	italiansupercupwinner=PlayerPrefs.GetInt("italiansupercupwinner");
	germansupercupwinner=PlayerPrefs.GetInt("germansupercupwinner");
	//=PlayerPrefs.GetInt("id",(issecondleg?1:0));
	global.timessacked=PlayerPrefs.GetInt("timessacked");
	//remember it's control holding this save function
	week=PlayerPrefs.GetInt("week" );
	month=PlayerPrefs.GetString("month" );
	year=PlayerPrefs.GetInt("year" );
	realweek=PlayerPrefs.GetInt("realweek");
	realfixture=PlayerPrefs.GetInt("realfixture");
	state=PlayerPrefs.GetString("state");

	LoadFixtures();
	LoadCountries();
	LoadClubs();
	LoadOwnPlayers();
}

bool  Contains ( int[] array ,  int index  ){
	bool has=false;
	for(int i=0;i<array.Length;i++)
	{if(index==array[i])
		has=true;}
	return has;
}

bool  ContainsStr ( string[] array ,  string index  ){
	bool has=false;
	for(int i=0;i<array.Length;i++)
	{if(index==array[i])
		has=true;}
	return has;
}

}
