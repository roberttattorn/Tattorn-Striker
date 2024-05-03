using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class global : MonoBehaviour {
	public static int minutes;
	public static int seconds;
	public static int p1goals;
	public static int p2goals;
	public static int p1penalties;
	public static int p2penalties;
	public static bool inited=false;
	 private int timeout=0;
	private int sminutes;
	private int sseconds;
	private int sp1goals;
	private int sp2goals;
	public static string Event;
	public static string managername;
	public static string nationality;
	public static int awaygoals;
	public static int homeawaygoals;
	public static string[] categories={"countries","clubs"};// new string[2];
	public static string[] leagues={"Premier League","La Liga","Serie A","Bundesliga"};
	public static string[] regions={"Europe","South America","Africa","Asia","North America","Oceania"};
	public static string fixture; public static int loser;
	public static int i;        private bool onlyone=false; public static bool reinit=false; public static bool extratime=false; public static bool penalties=false;
	public static int realfixture;
	public static bool kickedoff=false;
	public static bool hasControl=false;  //prevents 2 controls from respawning in dashboard room
	public static bool  load;
	//static string sateams [];
	public static bool p1booked=false;public static bool p2booked=false;public static bool p3booked=false;public static bool p4booked=false;
	public static bool p5booked=false;public static bool p6booked=false;public static bool p7booked=false;public static bool p8booked=false;
	public static bool p9booked=false;public static bool p10booked=false;
	public static bool p12booked=false;public static bool p22booked=false;public static bool p32booked=false;public static bool p42booked=false;
	public static bool p52booked=false;public static bool p62booked=false;public static bool p72booked=false;public static bool p82booked=false;
	public static bool p92booked=false;public static bool p102booked=false;
	public static int number1sentoff=0;
	public static int number2sentoff=0;
	public static bool p1sentoff=false;
	public static bool p2sentoff=false;
	public static bool p3sentoff=false;
	public static bool p4sentoff=false;
	public static bool p5sentoff=false;
	public static bool p6sentoff=false;
	public static bool p7sentoff=false;
	public static bool p8sentoff=false;
	public static bool p9sentoff=false; 
	public static bool p10sentoff=false;public static int p1acc; public static int p1agile;public static int p1speed;
	public static bool p11sentoff=false;public static int p2acc; public static int p2agile;public static int p2speed;
	public static bool p22sentoff=false;public static int p3acc; public static int p3agile;public static int p3speed;
	public static bool p33sentoff=false;public static int p4acc; public static int p4agile;public static int p4speed;
	public static bool p44sentoff=false;public static int p5acc; public static int p5agile;public static int p5speed;
	public static bool p55sentoff=false;public static int p6acc; public static int p6agile;public static int p6speed;
	public static bool p66sentoff=false;public static int p7acc; public static int p7agile;public static int p7speed;
	public static bool p77sentoff=false;public static int p8acc; public static int p8agile;public static int p8speed;
	public static bool p88sentoff=false;public static int p9acc; public static int p9agile;public static int p9speed;
	public static bool p99sentoff=false;public static int p10acc; public static int p10agile;public static int p10speed;
	public static bool p1010sentoff=false;
	public static int p1condition;public static int p2condition;public static int p3condition;public static int p4condition;public static int p5condition;
	public static int p6condition;private float condtimeout=0.0f;
	public static int p7condition;public static int p8condition;public static int p9condition;public static int p10condition;
	//static var list[] = new list.<list.<String>, >();
	public static bool toldsuccess=false;  // manager on a good run after 20 matches
	public static bool boardopinioned=false;  //board tells you what they think 4 times a season.
	public static bool managertoldwon10=false;  //manager told if he has won 10 trophies
	public static bool managertoldwon14=false;
	public static bool managertoldtopofworld=false;  //when the manager reaches pinnacle
	public static int matcheswon=0;
	public static int matcheslost=0;       // reset these when sacked or resigns
	public static bool sacked=false;
	public static bool retired=false;
	public static List<int> managedclubs=new List<int>(); //clubs player managed so he cannot return to them
	public static List<int> managedcountries=new List<int>();
	/////////TACTICS//////////////////////////////
	public static string mentality="normal";             ////team instructions      normal, attacking, defensive , overload
	public static int formation=442;           // 442, 433,  541, 352
	public static int width=2;                 //0-very narrow 1-narrow -2--normal 3-wide 4- very wide
	public static string passingstyle="normal";  // mixed,  short,  long
	public static string playstyle="normal";   //normal / onetwo / fwdruns / tikitaka 
	public static string marking="zone";       // zone / man / backup / cutoff / 
	public static string pressing="normal";     // laidback, normal, pressure
	public static string tackling="hard";          //Individual and team instructions  /hard / normal / soft
	public static string attacking="normal";       // normal, channels, hugoffside  
	//static FIXME_VAR_TYPE focuspassing="mixed";    // mixed, middle, flanks
	public static int freekicktaker=10;   //the player's int position in squad
	public static int penaltytaker=10;
	public static int cornertaker=10;
	private int goaltimeout=0;     public static bool subbed1=false;public static bool subbed2=false;public static bool subbed3=false;public static bool subbed4=false;public static bool subbed5=false;
	public static bool subbed6=false;public static bool subbed7=false;public static bool subbed8=false;public static bool subbed9=false;public static bool subbed10=false;
	/////////individual instructions ....
	public static string t2mentality="normal";  // teams mentality
	public static string t1mentality="normal";  // teams mentality
	public static int rating1=7;public static int rating2=7;public static int rating3=7;public static int rating4=7;public static int rating5=7;public static int rating6=7;
	public static int rating7=7;public static int rating8=7;public static int rating9=7;public static int rating10=7;
	public static int rating21=7;public static int rating22=7;public static int rating23=7;public static int rating24=7;public static int rating25=7;public static int rating26=7;
	public static int rating27=7;public static int rating28=7;public static int rating29=7;public static int rating210=7;

	public static int role; private int striker=0;private int midfielder=1;private int defender=2;private int goalkeeper=3;
	/////////////////////////////////////////////////
	//categories 
	//categories = ["countries","clubs"];
	//leagues = new string[4];
	//leagues=["Premier League","La Liga","Serie A","Bundesliga"];
	//regions=new string[6];
	//regions=["Europe","South America","Africa","Asia","North America","Oceania"];
	//plteams=new string[18];
	//llteams=new string[16];
	//sateams=new string[16];
	//blteams=new string[16];
	public static List<string> plteams=new List<string>{"Arsenal","Bournemouth","Brighton","Burnley","Chelsea",
		"Everton","Fulham","Huddersfield","Leicester","Liverpool","Man city","Man utd","Newcastle","Crystal Palace","Tottenham","Watford","West ham","Aston Villa"};
	
	public static List<string> llteams=new List<string>{"Barcelona","Real Madrid","Atletico Madrid","Villarreal","Valencia","Sevilla","Getafe","Espanyol","Athletic","Sociedad","Betis","Alaves","Eibar","Leganes","Levante","Valladolid"} ;

	public static List<string> sateams=new List<string>{"Atalanta","Juventus","Napoli","Ac Milan","Inter Milan","Roma","Torino","Lazio","Sampdoria","Bologna","Sassuolo","Udinese","Parma","Cagliari","Fiorentina","Genoa"};

	public static List<string> blteams=new List<string>{"Bayern Munich","Dortmund","Leverkusen","Leipzig","Mgladbach","Wolfsburg","Frankfurt","Bremen","Hoffenheim","Dusseldorf","Hertha","Freiburg","Schalke","Stutggart","Hamburg","mainz"};

	//eucountries= new string[42];
				public static List<string> eucountries= new List<string> {"Ireland","England","Wales","Scotland","Northern Ireland","Norway","Sweden","Finland","Denmark","Netherlands","Belgium","Germany","Poland","France",
		"Portugal","Spain","Italy","Switzerland","Austria","Czech republic","Slovakia","Slovenia","Serbia","Hungary","Romania","Bulgaria","Turkey","Ukraine","Israel",
		"Croatia","Greece","Georgia","Azerbaijan","Iceland","Lithuania","Estonia","Latvia","Cyprus","Moldova","Macedonia","Armenia","Bosnia"};
	//sacountries= new string[10];
	public static List<string> sacountries= new List<string>{"Argentina","Brazil","Uruguay","Paraguay","Ecuador","Bolivia","Chile","Peru","Venezuela","Colombia"};
	//afcountries= new string[50];
						public static List<string> afcountries= new List<string> {"Morocco","Algeria","Tunisia","Equatorial Guinea","Egypt","Mauritania","Mali","Niger","Nigeria","Chad","Sudan","Djibouti","Ethiopia","Senegal","Gambia",
		"Sierra Leone","Guinea","Liberia","Ivory Coast","Burkina Faso","Ghana","Togo","Benin","Cameroon","Comoros","Gabon",
		"Congo","DR Congo","Uganda","Kenya","Tanzania","Rwanda","Burundi","Angola","Zambia","Zimbabwe","Malawi","Mozambique","Madagascar",
		"Namibia","Botswana","South Africa","Mauritius","Seychelles","Swaziland","Lesotho","Eritrea","Guinea Bissau","Central African Republic"};
	//ascountries=new string[20];
							public static List<string> ascountries= new List<string> {"Japan","Korea","China","UAE","Malaysia","Thailand","Philippines","Vietnam","Singapore","India","Pakistan","Nepal","Iran","Iraq",
		"Saudi Arabia","Kazakhstan","Qatar","Sri Lanka","Lebanon","Indonesia"};
	//nacountries=new string[16];
								public static List<string> nacountries=new List<string>  {"U.S.A","Canada","Mexico","Costa Rica","Panama","Honduras","Nicaragua","El Salvador","Guatemala","Belize","Jamaica","Cuba","Dominican Republic",
		"Haiti","Trinidad","Bahamas"};
	//ocountries=new string[8];
	public static List<string> ocountries= new List<string> {"Australia","New Zealand","Solomon Islands","Papua New Guinea","Kiribati","Vanuatu","Tuvalu","Fiji"};
	public static List<string> eu=eucountries; public static List<string> sa=sacountries; public static List<string> af=afcountries; public static List<string> ass=ascountries; public static List<string> na=nacountries; public static List<string> oc=ocountries;
	public static List<string> allcountries;


	public static string team;
	public static string category;
	public static string league;
	public static int id;        //own team id
	public static string icon;
	public static int ownteam;
	public static bool goal=false;
	public static int team1;   //variables to simulate matches and to keep match engine scores
	public static int team2;
	public static int team1goals;
	public static int team2goals;
	public static int team1aggregate;
	public static int team2aggregate;
	public static int team2awaygoals;
	public static int team1points;
	public static int team2points;
	public static int team1cards;
	public static int team2cards;
	public static int winner;
	public static int team1formation;
	public static string team1mentality;
	public static int team2formation;
	public static string team2mentality;

	public static int trophies;
	public static int points;
	public static int majortrophies;
	public static int minortrophies;
	public static int premierleagues;
	public static int communityshields;
	public static int facups;
	public static int leaguecups;
	public static int championsleagues;
	public static int uefacups;
	public static int eurovases;
	public static int spanishleagues;
	public static int italianleagues;
	public static int germanleagues;
	public static int spanishcups;
	public static int italiancups;
	public static int germancups;
	public static int clubworldcups;
	public static int worldcups;
	public static int euros;
	public static int confederationscups;
	public static int asiancups;
	public static int goldcups;
	public static int copaamericas;
	public static int afconcups;
	public static int oceancups;
	public static int cecafacups;
	public static int cosafacups;
	public static int cabralcups;
	public static int seagames;
	public static int thirdplaces;
	public static bool  fromdashboard;
	public static int age=30;
	public static bool frommatch=false;
	public static bool isaggregate=false;
	public static bool isknockout=false;
	public static bool issecondleg=false;
	public static int timessacked=0;
	////////////onetwo
	public static int p1onetwo=0;
	public static int p2onetwo=0;
	public static GameObject returnto;

	void  Start (){
		GameObject[] objects= GameObject.FindGameObjectsWithTag("global");int i=0;
		foreach(var obj in objects)
			i++;
		if(i>1 && onlyone==false)
			Destroy(gameObject);
		onlyone=true;

		if(Application.loadedLevelName=="team")
			Destroy(gameObject);
		DontDestroyOnLoad(this.gameObject);
		timeout=9;
		if(Application.loadedLevelName=="team"){
			for(int Category=1;Category<=2;Category++){ //bug fix
				for(int league=1;league<=6;league++){

				}
			}
		}
		plteams.Sort();
		llteams.Sort();
		sateams.Sort();
		blteams.Sort();
		allcountries.AddRange(eu);allcountries.AddRange(sa);allcountries.AddRange(af);
		allcountries.AddRange(ass);allcountries.AddRange(na);allcountries.AddRange(oc);
		allcountries.Sort();
		//if(hasControl==false)
		// hasControl=true;
	}

	void  OnLevelWasLoaded (){
		timeout=0;
		DontDestroyOnLoad(this.gameObject);
		//Debug.Log(minutes+" "+p1goals+" "+p2goals);
		if(Application.loadedLevelName=="match")
		{//p1goals=sp1goals;p2goals=sp2goals;
			AI.minutes=minutes;AI.seconds=seconds;AI.p1goals=p1goals;AI.p2goals=p2goals;}
		if(Application.loadedLevelName=="intro")
			global.inited=false;

		if(Application.loadedLevelName=="dashboard"){
			p1booked=false; p2booked=false; p3booked=false; p4booked=false;
			p5booked=false; p6booked=false; p7booked=false; p8booked=false;
			p9booked=false; p10booked=false;
			p12booked=false; p22booked=false; p32booked=false; p42booked=false;
			p52booked=false; p62booked=false; p72booked=false; p82booked=false;
			p92booked=false; p102booked=false;
			number1sentoff=0;
			number2sentoff=0;
			p1sentoff=false;
			p2sentoff=false;
			p3sentoff=false;
			p4sentoff=false;
			p5sentoff=false;
			p6sentoff=false;
			p7sentoff=false;
			p8sentoff=false;
			p9sentoff=false;
			p10sentoff=false;
			p11sentoff=false;
			p22sentoff=false;
			p33sentoff=false;
			p44sentoff=false;
			p55sentoff=false;
			p66sentoff=false;
			p77sentoff=false;
			p88sentoff=false;
			p99sentoff=false;
			p1010sentoff=false; 
		}//app
	}

	void  Update (){
		if(timeout==1){
			/*if(Application.loadedLevelName=="dashboard"){
if(hasControl==false)
   hasControl=true;} */}

		if(timeout<10){
			timeout+=1;
		}
		if(timeout<7 && Application.loadedLevelName=="match"){
			AI.minutes =minutes;
			AI.seconds =seconds; 
			AI.p1goals =p1goals; 
			AI.p2goals =p2goals;  }

		if(goaltimeout>0)
			goaltimeout--;

		if(goal==true && goaltimeout==0)
			goaltimeout=2;
		if(goaltimeout==2)
			goal=true;

		if(p1onetwo>0)  
			p1onetwo--; 
		if(p2onetwo>0)  
			p2onetwo--;

	}

	void  LateUpdate (){
		if(timeout>=9 && Application.loadedLevelName=="match"){
			minutes=AI.minutes;
			seconds=AI.seconds;
			//p1goals=AI.p1goals;
			//p2goals=AI.p2goals;
			sminutes=minutes;
			sseconds=seconds;
			sp1goals=p1goals;
			sp2goals=p2goals;}
		if(goaltimeout==1)
			goal=false;
	}
}
