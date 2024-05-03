using UnityEngine;
using System.Collections;

public class databaseClubs : MonoBehaviour {
	Color navy= new Color(0,0,0.46f);
	Color purple= new Color(0.72f,0.0f,0.72f);
	Color darkgreen= new Color(0.0f,0.5f,0.0f);
	Color gold= new Color(1.0f,0.78f,0.0f);
	Color orange= new Color(1.0f, 0.64f, 0.0f);
	Color maroon= new Color(0.5f,0.0f,0.0f);
	Color pink= new Color(1.0f,0.68f,0.78f);
	Color teal= new Color(0.0f,0.63f,0.9f);
	Color vomit= new Color(0.7f,0.9f,0.11f);
	private int timeout=0;
	//GameObject Control;

	public class clubs : MonoBehaviour{      //some clubs are in non playable leagues that appear just in champions league etc.
		public int id;              // community shield  man city v chelsea
		public string clubname;
		public int reputation;  //there is a league called relegated
		public string league;
		public string icon;
		public Color maincolour;  //dashboard panel and match panel colour
		public Color textcolour;  //text colour to contrast the main colour
		public Color shirt;
		public Color shorts;
		public Color socks;
		public int shirtpattern;
		public string qualifiedleague;  //champions league uefa cup
		public bool  communityshield;  //and spanish 18 cup
		public bool  eurovase;
		public bool  leaguecup;
		public int championsleaguewins;
		public int uefacupwins;
		public int money;             // club gets more money upon winning leagues or finishing at certain positions
		public int formation;
		public string mentality;
		public string manager;
		public int[] players/*=new int[23]*/;   //.player ids from keeper to last substitute 23 man squad left to right
		public static clubs club;
		//{return }

	}

	public class objects {
		string objname;
		string objtype;
	}

	public objects[] Object=new objects[200];



	public clubs[] club= new clubs[99]; 

	void  Start (){

		for(int i=1;i<=198;i++)
			Object[i] = new objects();

	club[1]= new clubs();
	club[1].id=1;
	club[1].clubname="Arsenal";
	club[1].reputation=175;  //there is a league called relegated
	club[1].league="premier league";
	club[1].icon="arsenal";
	club[1].maincolour=Color.red;  //dashboard panel and match panel colour
	club[1].textcolour=Color.white;  //text colour to contrast the main colour
	club[1].shirt=Color.white;
	club[1].shorts=Color.white;
	club[1].socks=Color.white;
	club[1].shirtpattern=6;
	club[1].qualifiedleague="uefa cup";  //champions league uefa cup
	club[1].communityshield=false;  //and spanish super cup
	club[1].eurovase=false;
	club[1].leaguecup=true;
	club[1].championsleaguewins=0;
	club[1].uefacupwins=0;
	club[1].money=30000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[1].formation=442;
	club[1].mentality="normal";
	club[1].manager="Emery";
		club[1].players=new int[]{68,388,106,122,320,409,237,28,13,256,73,269,189,353,458,468,494,616,648,993,-1,-1,-1}; 

	club[2]= new clubs();
	club[2].id=2;
	club[2].clubname="Aston Villa";
	club[2].reputation=120;  //there is a league called relegated
	club[2].league="relegated";
	club[2].icon="astonvilla";
	club[2].maincolour=maroon;  //dashboard panel and match panel colour
	club[2].textcolour=Color.cyan;  //text colour to contrast the main colour
	club[2].shirt=Color.white;
	club[2].shorts=Color.white;
	club[2].socks=Color.cyan;
	club[2].shirtpattern=5;
	club[2].qualifiedleague="none";  //champions league uefa cup
	club[2].communityshield=false;  //and spanish super cup
	club[2].eurovase=false;
	club[2].leaguecup=true;
	club[2].championsleaguewins=0;
	club[2].uefacupwins=1;
	club[2].money=1000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[2].formation=442;
	club[2].mentality="normal";
	club[2].manager="Smith";
	club[2].players=new int[]{3319,2427,844,1614,2603,1657,2563,2556,2410,3084,1895,2619,2627,2784,2824,3102,3383,3471,3662,-1,-1,-1,-1}; 

	club[3]= new clubs();
	club[3].id=3;
	club[3].clubname="Bournemouth";
	club[3].reputation=140;  //there is a league called relegated
	club[3].league="premier league";
	club[3].icon="bournemouth";
	club[3].maincolour=Color.red;  //dashboard panel and match panel colour
	club[3].textcolour=Color.black;  //text colour to contrast the main colour
	club[3].shirt=Color.white;
	club[3].shorts=Color.black;
	club[3].socks=Color.black;
	club[3].shirtpattern=9;
	club[3].qualifiedleague="none";  //champions league uefa cup
	club[3].communityshield=false;  //and spanish super cup
	club[3].eurovase=false;
	club[3].leaguecup=true;
	club[3].championsleaguewins=0;
	club[3].uefacupwins=0;
	club[3].money=2000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[3].formation=433;
	club[3].mentality="attacking";
	club[3].manager="Howe";
	club[3].players=new int[]{276,1883,1200,1625,1513,2631,1106,3085,3132,1020,516,1063,1268,1799,1982,2062,2185,-1,-1,-1,-1,-1,-1}; 


	club[4]= new clubs();
	club[4].id=4;
	club[4].clubname="Brighton";
	club[4].reputation=130;  //there is a league called relegated
	club[4].league="premier league";
	club[4].icon="brighton";
	club[4].maincolour=Color.white;  //dashboard panel and match panel colour
	club[4].textcolour=Color.blue;  //text colour to contrast the main colour
	club[4].shirt=Color.white;
	club[4].shorts=Color.blue;
	club[4].socks=Color.blue;
	club[4].shirtpattern=0;
	club[4].qualifiedleague="none";  //champions league uefa cup
	club[4].communityshield=false;  //and spanish super cup
	club[4].eurovase=false;
	club[4].leaguecup=true;
	club[4].championsleaguewins=0;
	club[4].uefacupwins=0;
	club[4].money=5000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[4].formation=442;
	club[4].mentality="normal";
	club[4].manager="Hughton";
	club[4].players=new int[]{ 1035,716,1997,2302,1715,1274,1085,2657,1423,3974 ,2995,3594,1044,2429,2979,3032,-1,-1,-1,-1,-1,-1,-1}; 

	club[5]= new clubs();
	club[5].id=5;
	club[5].clubname="Burnley";
	club[5].reputation=135;  //there is a league called relegated
	club[5].league="premier league";
	club[5].icon="burnley";
	club[5].maincolour=Color.cyan;  //dashboard panel and match panel colour
	club[5].textcolour=maroon;  //text colour to contrast the main colour
	club[5].shirt=Color.white;
	club[5].shorts=Color.white;
	club[5].socks=Color.white;
	club[5].shirtpattern=5;
	club[5].qualifiedleague="none";  //champions league uefa cup
	club[5].communityshield=false;  //and spanish super cup
	club[5].eurovase=false;
	club[5].leaguecup=true;
	club[5].championsleaguewins=0;
	club[5].uefacupwins=0;
	club[5].money=3000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[5].formation=442;
	club[5].mentality="normal";
	club[5].manager="Dyche";
	club[5].players=new int[]{ 377,1459,918,2498,1523,2888,908,1635,1939,1813 ,1260,1944,2087,2877,2925,3195,3751,-1,-1,-1,-1
		,-1,-1}; 

	club[6]= new clubs();
	club[6].id=6;
	club[6].clubname="Chelsea";
	club[6].reputation=180;  //there is a league called relegated
	club[6].league="premier league";
	club[6].icon="chelsea";
	club[6].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[6].textcolour=Color.white;  //text colour to contrast the main colour
	club[6].shirt=Color.blue;
	club[6].shorts=Color.blue;
	club[6].socks=Color.white;
	club[6].shirtpattern=0;
	club[6].qualifiedleague="uefa cup";  //champions league uefa cup
	club[6].communityshield=true;  //and spanish super cup
	club[6].eurovase=false;
	club[6].leaguecup=true;
	club[6].championsleaguewins=1;
	club[6].uefacupwins=2;
	club[6].money=15000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[6].formation=442;
	club[6].mentality="normal";
	club[6].manager="Sarri";
	club[6].players=new int[]{12,82,57,221,109,7,65,33,114,101 ,58,123,200,309,346,417,626,653,-1,-1,-1,-1,-1};

	club[7]= new clubs();
	club[7].id=7;
	club[7].clubname="Crystal Palace";
	club[7].reputation=155;  //there is a league called relegated
	club[7].league="premier league";
	club[7].icon="crystalpalace";
	club[7].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[7].textcolour=maroon;  //text colour to contrast the main colour
	club[7].shirt=Color.white;
	club[7].shorts=Color.blue;
	club[7].socks=Color.blue;
	club[7].shirtpattern=2;
	club[7].qualifiedleague="none";  //champions league uefa cup
	club[7].communityshield=false;  //and spanish super cup
	club[7].eurovase=false;
	club[7].leaguecup=true;
	club[7].championsleaguewins=0;
	club[7].uefacupwins=0;
	club[7].money=7000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[7].formation=442;
	club[7].mentality="defensive";
	club[7].manager="Hodgson";
	club[7].players=new int[]{2280,1732,365,910,1338,333,664,3620,803,2489,361,3143,1185,1552,1942,2084,2240,2252,-1,-1,-1,-1,-1};

	club[8]= new clubs();
	club[8].id=8;
	club[8].clubname="Everton";
	club[8].reputation=165;  //there is a league called relegated
	club[8].league="premier league";
	club[8].icon="everton";
	club[8].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[8].textcolour=Color.white;  //text colour to contrast the main colour
	club[8].shirt=Color.blue;
	club[8].shorts=Color.white;
	club[8].socks=Color.white;
	club[8].shirtpattern=0;
	club[8].qualifiedleague="none";  //champions league uefa cup
	club[8].communityshield=false;  //and spanish super cup
	club[8].eurovase=false;
	club[8].leaguecup=true;
	club[8].championsleaguewins=0;
	club[8].uefacupwins=0;
	club[8].money=4000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[8].formation=442;
	club[8].mentality="normal";
	club[8].manager="Marco Silva";
	club[8].players=new int[]{1086,286,284,318,368,258,152,176,331,903 ,387,454,227,374,514,1081,1133,-1,-1,-1,-1,-1,-1};

	club[9]= new clubs();
	club[9].id=9;
	club[9].clubname="Fulham";
	club[9].reputation=125;  //there is a league called relegated
	club[9].league="premier league";
	club[9].icon="fulham";
	club[9].maincolour=Color.white;  //dashboard panel and match panel colour
	club[9].textcolour=Color.black;  //text colour to contrast the main colour
	club[9].shirt=Color.white;
	club[9].shorts=Color.black;
	club[9].socks=Color.white;
	club[9].shirtpattern=0;
	club[9].qualifiedleague="none";  //champions league uefa cup
	club[9].communityshield=false;  //and spanish super cup
	club[9].eurovase=false;
	club[9].leaguecup=true;
	club[9].championsleaguewins=0;
	club[9].uefacupwins=1;
	club[9].money=2000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[9].formation=442;
	club[9].mentality="normal";
	club[9].manager="Parker";
	club[9].players=new int[]{7538,1680,4419,5261,2417,2599,2422,1080,3798,2306,1183,3182,2474,3312,5779,2699,3390,5889,-1,-1,-1,-1,-1};

	club[10]= new clubs();
	club[10].id=10;
	club[10].clubname="Huddersfield";
	club[10].reputation=100;  //there is a league called relegated
	club[10].league="premier league";
	club[10].icon="huddersfield";
	club[10].maincolour=Color.white;  //dashboard panel and match panel colour
	club[10].textcolour=Color.blue;  //text colour to contrast the main colour
	club[10].shirt=Color.white;
	club[10].shorts=Color.white;
	club[10].socks=Color.blue;
	club[10].shirtpattern=10;
	club[10].qualifiedleague="none";  //champions league uefa cup
	club[10].communityshield=false;  //and spanish super cup
	club[10].eurovase=false;
	club[10].leaguecup=true;
	club[10].championsleaguewins=0;
	club[10].uefacupwins=0;
	club[10].money=6000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[10].formation=541;
	club[10].mentality="normal";
	club[10].manager="Stewart";
	club[10].players=new int[]{1600,2688,1938,3058,3322,4530,2294,1098,3416,2496 ,1393,2608,3269,3870,4172,4527,-1,-1,-1,-1,
		-1,-1,-1};

	club[11]= new clubs();
	club[11].id=11;
	club[11].clubname="Leicester";
	club[11].reputation=160;  //there is a league called relegated
	club[11].league="premier league";
	club[11].icon="leicester";
	club[11].maincolour=navy;  //dashboard panel and match panel colour
	club[11].textcolour=Color.white;  //text colour to contrast the main colour
	club[11].shirt=navy;
	club[11].shorts=navy;
	club[11].socks=navy;
	club[11].shirtpattern=0;
	club[11].qualifiedleague="none";  //champions league uefa cup
	club[11].communityshield=false;  //and spanish super cup
	club[11].eurovase=false;
	club[11].leaguecup=true;
	club[11].championsleaguewins=0;
	club[11].uefacupwins=0;
	club[11].money=30000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[11].formation=442;
	club[11].mentality="attacking";
	club[11].manager="Rogers";
	club[11].players=new int[]{182,1283,1084,1139,1822,1032,1854,249,143,202,316,995,1188,1214,1359,1918,-1,-1,-1,-1,-1,-1,-1};

	club[12]= new clubs();
	club[12].id=12;
	club[12].clubname="Liverpool";
	club[12].reputation=185;  //there is a league called relegated
	club[12].league="premier league";
	club[12].icon="liverpool";
	club[12].maincolour=Color.red;  //dashboard panel and match panel colour
	club[12].textcolour=Color.white;  //text colour to contrast the main colour
	club[12].shirt=Color.red;
	club[12].shorts=Color.red;
	club[12].socks=Color.red;
	club[12].shirtpattern=0;
	club[12].qualifiedleague="champions league";  //champions league uefa cup
	club[12].communityshield=false;  //and spanish super cup
	club[12].eurovase=false;
	club[12].leaguecup=true;
	club[12].championsleaguewins=6;
	club[12].uefacupwins=3;
	club[12].money=31000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[12].formation=442;
	club[12].mentality="attacking";
	club[12].manager="Klopp";
	club[12].players=new int[]{397,509,144,339,248,97,261,54,431,145,137,267,171,278,372,6160,151,-1,-1,-1,-1,-1,-1};

	club[13]= new clubs();
	club[13].id=13;
	club[13].clubname="Man City";
	club[13].reputation=190;  //there is a league called relegated
	club[13].league="premier league";
	club[13].icon="mancity";
	club[13].maincolour=Color.cyan;  //dashboard panel and match panel colour
	club[13].textcolour=Color.blue;  //text colour to contrast the main colour
	club[13].shirt=Color.cyan;
	club[13].shorts=Color.cyan;
	club[13].socks=Color.cyan;
	club[13].shirtpattern=0;
	club[13].qualifiedleague="champions league";  //champions league uefa cup
	club[13].communityshield=true;  //and spanish super cup
	club[13].eurovase=false;
	club[13].leaguecup=true;
	club[13].championsleaguewins=0;
	club[13].uefacupwins=0;
	club[13].money=63000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[13].formation=442;
	club[13].mentality="attacking";
	club[13].manager="Guardiola";
	club[13].players=new int[]{135,569,90,154,161,199,81,42,11,229,16,295,94,196,275,299,1082,-1,-1,-1,-1,-1,-1};

	club[14]= new clubs();
	club[14].id=14;
	club[14].clubname="Man Utd";
	club[14].reputation=170;  //there is a league called relegated
	club[14].league="premier league";
	club[14].icon="manutd";
	club[14].maincolour=Color.red;  //dashboard panel and match panel colour
	club[14].textcolour=Color.black;  //text colour to contrast the main colour
	club[14].shirt=Color.red;
	club[14].shorts=Color.white;
	club[14].socks=Color.black;
	club[14].shirtpattern=0;
	club[14].qualifiedleague="champions league";  //champions league uefa cup
	club[14].communityshield=false;  //and spanish super cup
	club[14].eurovase=false;
	club[14].leaguecup=true;
	club[14].championsleaguewins=3;
	club[14].uefacupwins=1;
	club[14].money=6000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[14].formation=442;
	club[14].mentality="normal";
	club[14].manager="Solskjaer";
	club[14].players=new int[]{6,233,92,351,181,75,107,35,118,31,50,210,155,392,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[15]= new clubs();
	club[15].id=15;
	club[15].clubname="Newcastle";
	club[15].reputation=145;  //there is a league called relegated
	club[15].league="premier league";
	club[15].icon="newcastle";
	club[15].maincolour=Color.black;  //dashboard panel and match panel colour
	club[15].textcolour=Color.white;  //text colour to contrast the main colour
	club[15].shirt=Color.white;
	club[15].shorts=Color.black;
	club[15].socks=Color.black;
	club[15].shirtpattern=4;
	club[15].qualifiedleague="none";  //champions league uefa cup
	club[15].communityshield=false;  //and spanish super cup
	club[15].eurovase=false;
	club[15].leaguecup=true;
	club[15].championsleaguewins=0;
	club[15].uefacupwins=0;
	club[15].money=3000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[15].formation=442;
	club[15].mentality="normal";
	club[15].manager="Benitez";
	club[15].players=new int[]{4834,1291,596,1358,3251,1257,1177,1194,1250,1879,1654,1776,1525,1631,3003,2431,4219,4126,3433,-1,-1,-1,-1};

	club[16]= new clubs();
	club[16].id=16;
	club[16].clubname="Tottenham";
	club[16].reputation=178;  //there is a league called relegated
	club[16].league="premier league";
	club[16].icon="tottenham";
	club[16].maincolour=Color.white;  //dashboard panel and match panel colour
	club[16].textcolour=teal;  //text colour to contrast the main colour
	club[16].shirt=Color.white;
	club[16].shorts=teal;
	club[16].socks=teal;
	club[16].shirtpattern=0;
	club[16].qualifiedleague="champions league";  //champions league uefa cup
	club[16].communityshield=false;  //and spanish super cup
	club[16].eurovase=false;
	club[16].leaguecup=true;
	club[16].championsleaguewins=0;
	club[16].uefacupwins=2;
	club[16].money=13000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[16].formation=442;
	club[16].mentality="attacking";
	club[16].manager="Pochetino";
	club[16].players=new int[]{29,279,56,86,335,96,183,36,251,46,235,304,232,486,685,751,907,1042,-1,-1,-1,-1,-1};

	club[17]= new clubs();
	club[17].id=17;
	club[17].clubname="Watford";
	club[17].reputation=150;  //there is a league called relegated
	club[17].league="premier league";
	club[17].icon="watford";
	club[17].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[17].textcolour=Color.black;  //text colour to contrast the main colour
	club[17].shirt=Color.yellow;
	club[17].shorts=Color.red;
	club[17].socks=Color.black;
	club[17].shirtpattern=0;
	club[17].qualifiedleague="none";  //champions league uefa cup
	club[17].communityshield=false;  //and spanish super cup
	club[17].eurovase=false;
	club[17].championsleaguewins=0;
	club[17].uefacupwins=0;
	club[17].money=34000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[17].formation=442;
	club[17].mentality="normal";
	club[17].manager="Javi Garcia";
	club[17].players=new int[]{263,892,641,1752,1205,1652,742,442,962,1033,1030,1136,687,1806,1841,-1,-1,-1,-1,-1,-1,-1,-1};

	club[18]= new clubs();
	club[18].id=18;
	club[18].clubname="West ham";
	club[18].reputation=155;  //there is a league called relegated
	club[18].league="premier league";
	club[18].icon="westham";
	club[18].maincolour=maroon;  //dashboard panel and match panel colour
	club[18].textcolour=Color.white;  //text colour to contrast the main colour
	club[18].shirt=Color.white;
	club[18].shorts=maroon;
	club[18].socks=maroon;
	club[18].shirtpattern=5;
	club[18].qualifiedleague="none";  //champions league uefa cup
	club[18].communityshield=false;  //and spanish super cup
	club[18].eurovase=false;
	club[18].championsleaguewins=0;
	club[18].uefacupwins=0;
	club[18].money=12000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[18].formation=442;
	club[18].mentality="normal";
	club[18].manager="Pellegrini";
	club[18].players=new int[]{291,1481,634,649,681,355,1062,647,260,449,271,599,656,1143,1278,1365,1602,1615,-1,-1,-1,-1,-1};

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	club[19]= new clubs();
	club[19].id=19;
	club[19].clubname="Alaves";
	club[19].reputation=140;  //there is a league called relegated
	club[19].league="la liga";
	club[19].icon="alaves";
	club[19].maincolour=Color.white;  //dashboard panel and match panel colour
	club[19].textcolour=Color.blue;  //text colour to contrast the main colour
	club[19].shirt=Color.white;
	club[19].shorts=Color.blue;
	club[19].socks=Color.white;
	club[19].shirtpattern=0;
	club[19].qualifiedleague="none";  //champions league uefa cup
	club[19].communityshield=false;  //and spanish super cup
	club[19].eurovase=false;
	club[19].championsleaguewins=0;
	club[19].uefacupwins=0;
	club[19].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[19].formation=442;
	club[19].mentality="normal";
	club[19].manager="Alberardo";
	club[19].players=new int[]{970,2060,1303,1479,2514,1477,994,1569,1757,644,1759,1905,2040,2209,2612,3021,3212,3521,-1,-1,-1,-1,-1};

	club[20]= new clubs();
	club[20].id=20;
	club[20].clubname="Athletic";
	club[20].reputation=155;  //there is a league called relegated
	club[20].league="la liga";
	club[20].icon="athletic";
	club[20].maincolour=Color.white;  //dashboard panel and match panel colour
	club[20].textcolour=Color.red;  //text colour to contrast the main colour
	club[20].shirt=Color.white;
	club[20].shorts=Color.black;
	club[20].socks=Color.red;
	club[20].shirtpattern=7;
	club[20].qualifiedleague="none";  //champions league uefa cup
	club[20].communityshield=false;  //and spanish super cup
	club[20].eurovase=false;
	club[20].championsleaguewins=0;
	club[20].uefacupwins=0;
	club[20].money=22000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[20].formation=442;
	club[20].mentality="normal";
	club[20].manager="Berizzo";
	club[20].players=new int[]{410,613,95,697,1405,350,821,272,352,852,307,126,1415,375,460,1887,-1,-1,-1,-1,-1,-1,-1};

	club[21]= new clubs();
	club[21].id=21;
	club[21].clubname="Atletico Madrid";
	club[21].reputation=180;  //there is a league called relegated
	club[21].league="la liga";
	club[21].icon="atleticomadrid";
	club[21].maincolour=Color.white;  //dashboard panel and match panel colour
	club[21].textcolour=Color.red;  //text colour to contrast the main colour
	club[21].shirt=Color.white;
	club[21].shorts=Color.blue;
	club[21].socks=Color.red;
	club[21].shirtpattern=7;
	club[21].qualifiedleague="champions league";  //champions league uefa cup
	club[21].communityshield=false;  //and spanish super cup
	club[21].eurovase=true;
	club[21].championsleaguewins=0;
	club[21].uefacupwins=3;
	club[21].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[21].formation=442;
	club[21].mentality="normal";
	club[21].manager="Alberardo";
	club[21].players=new int[]{20,89,26,130,187,104,214,381,69,178,21,223,386,169,390,471,534,553,567,1003,-1,-1,-1};

	club[22]= new clubs();
	club[22].id=22;
	club[22].clubname="Barcelona";
	club[22].reputation=197;  //there is a league called relegated
	club[22].league="la liga";
	club[22].icon="barcelona";
	club[22].maincolour=maroon;  //dashboard panel and match panel colour
	club[22].textcolour=Color.blue;  //text colour to contrast the main colour
	club[22].shirt=Color.white;
	club[22].shorts=navy;
	club[22].socks=navy;
	club[22].shirtpattern=2;
	club[22].qualifiedleague="champions league";  //champions league uefa cup
	club[22].communityshield=true;  //and spanish super cup
	club[22].eurovase=false;
	club[22].championsleaguewins=5;
	club[22].uefacupwins=0;
	club[22].money=17000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[22].formation=433;
	club[22].mentality="normal";
	club[22].manager="Valverde";
	club[22].players=new int[]{78,80,44,142,231,45,41,1,128,3,3106,190,53,209,294,300,325,327,806,-1,-1,-1,-1};

	club[23]= new clubs();
	club[23].id=23;
	club[23].clubname="Betis";
	club[23].reputation=145;  //there is a league called relegated
	club[23].league="la liga";
	club[23].icon="betis";
	club[23].maincolour=Color.white;  //dashboard panel and match panel colour
	club[23].textcolour=Color.green;  //text colour to contrast the main colour
	club[23].shirt=Color.green;
	club[23].shorts=Color.white;
	club[23].socks=Color.green;
	club[23].shirtpattern=0;
	club[23].qualifiedleague="uefa cup";  //champions league uefa cup
	club[23].communityshield=false;  //and spanish super cup
	club[23].eurovase=false;
	club[23].championsleaguewins=0;
	club[23].uefacupwins=0;
	club[23].money=3000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[23].formation=442;
	club[23].mentality="normal";
	club[23].manager="Quique";
	club[23].players=new int[]{370,1090,775,862,3886,1070,484,356,1129,817,714,992,984,894,1484,3117,3655,4995,5450,-1,-1,-1,-1};

	club[24]= new clubs();
	club[24].id=24;
	club[24].clubname="Eibar";
	club[24].reputation=135;  //there is a league called relegated
	club[24].league="la liga";
	club[24].icon="eibar";
	club[24].maincolour=Color.white;  //dashboard panel and match panel colour
	club[24].textcolour=navy;  //text colour to contrast the main colour
	club[24].shirt=Color.white;
	club[24].shorts=Color.white;
	club[24].socks=Color.white;
	club[24].shirtpattern=2;
	club[24].qualifiedleague="none";  //champions league uefa cup
	club[24].communityshield=false;  //and spanish super cup
	club[24].eurovase=false;
	club[24].championsleaguewins=0;
	club[24].uefacupwins=0;
	club[24].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[24].formation=442;
	club[24].mentality="normal";
	club[24].manager="Mendillibar";
	club[24].players=new int[]{1037,2053,735,920,721,754,308,1604,475, 1149,435,1215,810,935,1307,1411,1595,1884,-1,-1,-1,-1,-1};

	club[25]= new clubs();
	club[25].id=25;
	club[25].clubname="Espanyol";
	club[25].reputation=160;  //there is a league called relegated
	club[25].league="la liga";
	club[25].icon="espanyol";
	club[25].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[25].textcolour=Color.white;  //text colour to contrast the main colour
	club[25].shirt=Color.white;
	club[25].shorts=Color.blue;
	club[25].socks=Color.blue;
	club[25].shirtpattern=10;
	club[25].qualifiedleague="none";  //champions league uefa cup
	club[25].communityshield=false;  //and spanish super cup
	club[25].eurovase=false;
	club[25].championsleaguewins=0;
	club[25].uefacupwins=0;
	club[25].money=5000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[25].formation=442;
	club[25].mentality="normal";
	club[25].manager="Ferrer";
	club[25].players=new int[]{188,1224,772,965,1259,632,503,670,601,414,551,712,768,841,1324,1713,2432,2611,2724,3122,-1,-1,-1};

	club[26]= new clubs();
	club[26].id=26;
	club[26].clubname="Getafe";
	club[26].reputation=170;  //there is a league called relegated
	club[26].league="la liga";
	club[26].icon="getafe";
	club[26].maincolour=vomit;  //dashboard panel and match panel colour
	club[26].textcolour=navy;  //text colour to contrast the main colour
	club[26].shirt=vomit;
	club[26].shorts=vomit;
	club[26].socks=vomit;
	club[26].shirtpattern=0;
	club[26].qualifiedleague="none";  //champions league uefa cup
	club[26].communityshield=false;  //and spanish super cup
	club[26].eurovase=false;
	club[26].championsleaguewins=0;
	club[26].uefacupwins=0;
	club[26].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[26].formation=541;
	club[26].mentality="normal";
	club[26].manager="Bordalas";
	club[26].players=new int[]{3280,639,964,3484,2181,861,3451,3911,1629,1911,2409,2903,2372,3532,3720,3923,-1,-1,-1,-1,-1,-1,-1};

	club[27]= new clubs();
	club[27].id=27;
	club[27].clubname="Leganes";
	club[27].reputation=130;  //there is a league called relegated
	club[27].league="la liga";
	club[27].icon="leganes";
	club[27].maincolour=Color.white;  //dashboard panel and match panel colour
	club[27].textcolour=Color.cyan;  //text colour to contrast the main colour
	club[27].shirt=Color.white;
	club[27].shorts=Color.cyan;
	club[27].socks=Color.blue;
	club[27].shirtpattern=0;
	club[27].qualifiedleague="none";  //champions league uefa cup
	club[27].communityshield=false;  //and spanish super cup
	club[27].eurovase=false;
	club[27].championsleaguewins=0;
	club[27].uefacupwins=0;
	club[27].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[27].formation=442;
	club[27].mentality="normal";
	club[27].manager="Idiakez";
	club[27].players=new int[]{1473,1583,1593,1772,1981,837,636,736,1985,1606,2056,2049,1598,1950,1990,-1,-1,-1,-1,-1,-1,-1,-1};

	club[28]= new clubs();
	club[28].id=28;
	club[28].clubname="Levante";
	club[28].reputation=125;  //there is a league called relegated
	club[28].league="la liga";
	club[28].icon="levante";
	club[28].maincolour=Color.white;  //dashboard panel and match panel colour
	club[28].textcolour=Color.red;  //text colour to contrast the main colour
	club[28].shirt=Color.white;
	club[28].shorts=Color.blue;
	club[28].socks=maroon;
	club[28].shirtpattern=0;
	club[28].qualifiedleague="none";  //champions league uefa cup
	club[28].communityshield=false;  //and spanish super cup
	club[28].eurovase=false;
	club[28].championsleaguewins=0;
	club[28].uefacupwins=0;
	club[28].money=3000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[28].formation=433;
	club[28].mentality="normal";
	club[28].manager="Lisci";
	club[28].players=new int[]{2158,1964,2303,2351,3407,835,1099,1992,720,1395,1875,1937,2018,2421,2649,2794,2930,3110,-1,-1,-1,-1,-1};

	club[29]= new clubs();
	club[29].id=29;
	club[29].clubname="Real Madrid";
	club[29].reputation=195;  //there is a league called relegated
	club[29].league="la liga";
	club[29].icon="realmadrid";
	club[29].maincolour=Color.white;  //dashboard panel and match panel colour
	club[29].textcolour=navy;  //text colour to contrast the main colour
	club[29].shirt=Color.white;
	club[29].shorts=Color.white;
	club[29].socks=Color.white;
	club[29].shirtpattern=0;
	club[29].qualifiedleague="champions league";  //champions league uefa cup
	club[29].communityshield=false;  //and spanish super cup
	club[29].eurovase=true;
	club[29].championsleaguewins=14;
	club[29].uefacupwins=2;
	club[29].money=53000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[29].formation=442;
	club[29].mentality="attacking";
	club[29].manager="Solari";
	club[29].players=new int[]{74,39,10,70,98,400,14,8,15,280,64,93,48,71,111,117,218,-1,-1,-1,-1,-1,-1};

	club[30]= new clubs();
	club[30].id=30;
	club[30].clubname="Sociedad";
	club[30].reputation=150;  //there is a league called relegated
	club[30].league="la liga";
	club[30].icon="realsociedad";
	club[30].maincolour=Color.white;  //dashboard panel and match panel colour
	club[30].textcolour=Color.blue;  //text colour to contrast the main colour
	club[30].shirt=orange;
	club[30].shorts=orange;
	club[30].socks=Color.white;
	club[30].shirtpattern=0;
	club[30].qualifiedleague="none";  //champions league uefa cup
	club[30].communityshield=false;  //and spanish super cup
	club[30].eurovase=false;
	club[30].championsleaguewins=0;
	club[30].uefacupwins=0;
	club[30].money=0;             // club gets more money upon winning leagues or finishing at certain positions
	club[30].formation=442;
	club[30].mentality="normal";
	club[30].manager="Barrenetxea";
	club[30].players=new int[]{131,789,224,538,889,520,349,564,611,280,240,926,654,1137,1160,1176,1219,1353,-1,-1,-1,-1,-1};

	club[31]= new clubs();
	club[31].id=31;
	club[31].clubname="Sevilla";
	club[31].reputation=165;  //there is a league called relegated
	club[31].league="la liga";
	club[31].icon="sevilla";
	club[31].maincolour=Color.white;  //dashboard panel and match panel colour
	club[31].textcolour=Color.black;  //text colour to contrast the main colour
	club[31].shirt=Color.white;
	club[31].shorts=Color.white;
	club[31].socks=Color.black;
	club[31].shirtpattern=11;
	club[31].qualifiedleague="none";  //champions league uefa cup
	club[31].communityshield=true;  //and spanish super cup
	club[31].championsleaguewins=0;
	club[31].eurovase=false;
	club[31].uefacupwins=6;
	club[31].money=4000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[31].formation=442;
	club[31].mentality="normal";
	club[31].manager="Pablo Machin";
	club[31].players=new int[]{219,604,369,452,607,430,173,163,2713,217,329,429,456,527,666,669,743,-1,-1,-1,-1,-1,-1};

	club[32]= new clubs();
	club[32].id=32;
	club[32].clubname="Valencia";
	club[32].reputation=175;  //there is a league called relegated
	club[32].league="la liga";
	club[32].icon="valencia";
	club[32].maincolour=orange;  //dashboard panel and match panel colour
	club[32].textcolour=Color.blue;  //text colour to contrast the main colour
	club[32].shirt=Color.white;
	club[32].shorts=Color.blue;
	club[32].socks=Color.blue;
	club[32].shirtpattern=12;
	club[32].qualifiedleague="champions league";  //champions league uefa cup
	club[32].communityshield=false;  //and spanish super cup
	club[32].eurovase=false;
	club[32].championsleaguewins=0;
	club[32].uefacupwins=1;
	club[32].money=14000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[32].formation=442;
	club[32].mentality="normal";
	club[32].manager="Marcelino";
	club[32].players=new int[]{436,542,180,578,1025,868,444,157,1438,791,322,1000,579,1195,1472,1922,2202,2286,-1,-1,-1,-1,-1};

	club[33]= new clubs();
	club[33].id=33;
	club[33].clubname="Valladolid";
	club[33].reputation=120;  //there is a league called relegated
	club[33].league="la liga";
	club[33].icon="valladolid";
	club[33].maincolour=purple;  //dashboard panel and match panel colour
	club[33].textcolour=Color.white;  //text colour to contrast the main colour
	club[33].shirt=purple;
	club[33].shorts=Color.white;
	club[33].socks=Color.white;
	club[33].shirtpattern=0;
	club[33].qualifiedleague="none";  //champions league uefa cup
	club[33].communityshield=false;  //and spanish super cup
	club[33].eurovase=false;
	club[33].championsleaguewins=0;
	club[33].uefacupwins=0;
	club[33].money=0;             // club gets more money upon winning leagues or finishing at certain positions
	club[33].formation=442;
	club[33].mentality="normal";
	club[33].manager="Gonzalez";
	club[33].players=new int[]{1994,5615,2166,2574,6320,3957,2197,3899,3959,6598,2861,3717,2818,4223,5545,6425,-1,-1,-1,-1,-1,-1,-1};

	club[34]= new clubs();
	club[34].id=34;
	club[34].clubname="Villarreal";
	club[34].reputation=130;  //there is a league called relegated
	club[34].league="la liga";
	club[34].icon="villarreal";
	club[34].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[34].textcolour=navy;  //text colour to contrast the main colour
	club[34].shirt=Color.yellow;
	club[34].shorts=Color.yellow;
	club[34].socks=Color.yellow;
	club[34].shirtpattern=0;
	club[34].qualifiedleague="uefa cup";  //champions league uefa cup
	club[34].communityshield=false;  //and spanish super cup
	club[34].eurovase=false;
	club[34].championsleaguewins=0;
	club[34].uefacupwins=1;
	club[34].money=14000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[34].formation=442;
	club[34].mentality="normal";
	club[34].manager="Calleja";
	club[34].players=new int[]{117,602,243,718,345,402,111,220,575,332,216,748,439,828,876,948,990,1111,-1,-1,-1,-1,-1};

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	club[35]= new clubs();
	club[35].id=35;
	club[35].clubname="Ac Milan";
	club[35].reputation=177;  //there is a league called relegated
	club[35].league="serie a";
	club[35].icon="acmilan";
	club[35].maincolour=Color.red;  //dashboard panel and match panel colour
	club[35].textcolour=Color.black;  //text colour to contrast the main colour
	club[35].shirt=Color.white;
	club[35].shorts=Color.black;
	club[35].socks=Color.black;
	club[35].shirtpattern=9;
	club[35].qualifiedleague="uefa cup";  //champions league uefa cup
	club[35].communityshield=true;  //and italian super cup with juventus
	club[35].championsleaguewins=7;
	club[35].uefacupwins=0;
	club[35].money=28000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[35].formation=442;
	club[35].mentality="normal";
	club[35].manager="Gattuso";
	club[35].players=new int[]{198,343,24,164,230,550,159,186,1284,695,359,1356,493,548,1408,1445,1733,-1,-1,-1,-1,-1,-1};

	club[36]= new clubs();
	club[36].id=36;
	club[36].clubname="Atalanta";
	club[36].reputation=180;  //there is a league called relegated
	club[36].league="serie a";
	club[36].icon="atalanta";
	club[36].maincolour=Color.white;  //dashboard panel and match panel colour
	club[36].textcolour=Color.black;  //text colour to contrast the main colour
	club[36].shirt=Color.white;
	club[36].shorts=Color.black;
	club[36].socks=Color.black;
	club[36].shirtpattern=0;
	club[36].qualifiedleague="none";  //champions league uefa cup
	club[36].communityshield=false;  //and spanish super cup
	club[36].championsleaguewins=0;
	club[36].uefacupwins=0;
	club[36].money=9000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[36].formation=442;
	club[36].mentality="defensive";
	club[36].manager="Gasperini";
	club[36].players=new int[]{800,2355,1166,1302,1116,1422,1332,1653,3402,424,125,2994,1728,2914,3192,3589,-1,-1,-1,-1,-1,-1,-1};

	club[37]= new clubs();
	club[37].id=37;
	club[37].clubname="Bologna";
	club[37].reputation=150;  //there is a league called relegated
	club[37].league="serie a";
	club[37].icon="bologna";
	club[37].maincolour=Color.red;  //dashboard panel and match panel colour
	club[37].textcolour=Color.blue;  //text colour to contrast the main colour
	club[37].shirt=Color.blue;
	club[37].shorts=Color.red;
	club[37].socks=Color.blue;
	club[37].shirtpattern=0;
	club[37].qualifiedleague="none";  //champions league uefa cup
	club[37].communityshield=false;  //and spanish super cup
	club[37].championsleaguewins=0;
	club[37].uefacupwins=0;
	club[37].money=4000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[37].formation=433;
	club[37].mentality="normal";
	club[37].manager="Donadoni";
	club[37].players=new int[]{505,2355,1464,2032,2712,2731,796,1745,1213,1299,850,2063,2083,1778,2136,2769,-1,-1,-1,-1,-1,-1,-1};

	club[38]= new clubs();
	club[38].id=38;
	club[38].clubname="Cagliari";
	club[38].reputation=125;  //there is a league called relegated
	club[38].league="serie a";
	club[38].icon="cagliari";
	club[38].maincolour=Color.white;  //dashboard panel and match panel colour
	club[38].textcolour=navy;  //text colour to contrast the main colour
	club[38].shirt=navy;
	club[38].shorts=Color.blue;
	club[38].socks=navy;
	club[38].shirtpattern=0;
	club[38].qualifiedleague="none";  //champions league uefa cup
	club[38].communityshield=false;  //and spanish super cup
	club[38].championsleaguewins=0;
	club[38].uefacupwins=0;
	club[38].money=2300000;             // club gets more money upon winning leagues or finishing at certain positions
	club[38].formation=442;
	club[38].mentality="normal";
	club[38].manager="Rolando Maran";
	club[38].players=new int[]{1670,3075,963,4812,1416,5646,1362,1725,5675,2135,947,2502,1744,3461,3564,3966,4296,-1,-1,-1,-1,-1,-1};

	club[39]= new clubs();
	club[39].id=39;
	club[39].clubname="Fiorentina";
	club[39].reputation=120;  //there is a league called relegated
	club[39].league="serie a";
	club[39].icon="fiorentina";
	club[39].maincolour=purple;  //dashboard panel and match panel colour
	club[39].textcolour=Color.white;  //text colour to contrast the main colour
	club[39].shirt=purple;
	club[39].shorts=purple;
	club[39].socks=purple;
	club[39].shirtpattern=0;
	club[39].qualifiedleague="none";  //champions league uefa cup
	club[39].communityshield=false;  //and spanish super cup
	club[39].championsleaguewins=0;
	club[39].uefacupwins=0;
	club[39].money=11000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[39].formation=442;
	club[39].mentality="normal";
	club[39].manager="Pioli";
	club[39].players=new int[]{722,3080,373,973,1069,770,544,583,1334,1386,1066,1561,774,831,864,1041,1633,-1,-1,-1,-1,-1,-1};

	club[40]= new clubs();
	club[40].id=40;
	club[40].clubname="Genoa";
	club[40].reputation=115;  //there is a league called relegated
	club[40].league="serie a";
	club[40].icon="genoa";
	club[40].maincolour=pink;  //dashboard panel and match panel colour
	club[40].textcolour=Color.blue;  //text colour to contrast the main colour
	club[40].shirt=pink;
	club[40].shorts=pink;
	club[40].socks=Color.white;
	club[40].shirtpattern=0;
	club[40].qualifiedleague="none";  //champions league uefa cup
	club[40].communityshield=false;  //and spanish super cup
	club[40].championsleaguewins=0;
	club[40].uefacupwins=0;
	club[40].money=5500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[40].formation=442;
	club[40].mentality="normal";
	club[40].manager="Gillardino";
	club[40].players=new int[]{150,1868,1040,1677,1327,726,1009,1882,2111,1375,1961,2183,3326,833,3435,-1,-1,-1,-1,-1,-1,-1,-1};

	club[41]= new clubs();
	club[41].id=41;
	club[41].clubname="Inter Milan";
	club[41].reputation=180;  //there is a league called relegated
	club[41].league="serie a";
	club[41].icon="intermilan";
	club[41].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[41].textcolour=Color.black;  //text colour to contrast the main colour
	club[41].shirt=Color.white;
	club[41].shorts=Color.black;
	club[41].socks=Color.black;
	club[41].shirtpattern=8;
	club[41].qualifiedleague="champions league";  //champions league uefa cup
	club[41].communityshield=false;  //and spanish super cup
	club[41].championsleaguewins=3;
	club[41].uefacupwins=3;
	club[41].money=20000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[41].formation=442;
	club[41].mentality="attacking";
	club[41].manager="Spalletti";
	club[41].players=new int[]{43,950,63,1452,547,112,133,184,480,466,100,306,713,732,869,1270,1641,2437,-1,-1,-1,-1,-1};

	club[42]= new clubs();
	club[42].id=42;
	club[42].clubname="Juventus";
	club[42].reputation=186;  //there is a league called relegated
	club[42].league="serie a";
	club[42].icon="juventus";
	club[42].maincolour=Color.white;  //dashboard panel and match panel colour
	club[42].textcolour=Color.black;  //text colour to contrast the main colour
	club[42].shirt=Color.white;
	club[42].shorts=Color.black;
	club[42].socks=Color.black;
	club[42].shirtpattern=4;
	club[42].qualifiedleague="champions league";  //champions league uefa cup
	club[42].communityshield=true;  //and spanish super cup
	club[42].championsleaguewins=2;
	club[42].uefacupwins=3;
	club[42].money=21000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[42].formation=442;
	club[42].mentality="attacking";
	club[42].manager="Alblegri";
	club[42].players=new int[]{18,51,17,91,119,115,84,85,207,19,9,170,87,172,245,257,-1,-1,-1,-1,-1,-1,-1};

	club[43]= new clubs();
	club[43].id=43;
	club[43].clubname="Lazio";
	club[43].reputation=160;  //there is a league called relegated
	club[43].league="serie a";
	club[43].icon="lazio";
	club[43].maincolour=Color.cyan;  //dashboard panel and match panel colour
	club[43].textcolour=navy;  //text colour to contrast the main colour
	club[43].shirt=Color.cyan;
	club[43].shorts=navy;
	club[43].socks=navy;
	club[43].shirtpattern=0;
	club[43].qualifiedleague="uefa cup";  //champions league uefa cup
	club[43].communityshield=false;  //and spanish super cup
	club[43].championsleaguewins=0;
	club[43].uefacupwins=0;
	club[43].money=13500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[43].formation=442;
	club[43].mentality="normal";
	club[43].manager="Simone Inzaghi";
	club[43].players=new int[]{507,667,149,623,491,980,363,393,324,192,246,650,1021,1060,1109,1140,1866,2467,3635,4106,-1,-1,-1};

	club[44]= new clubs();
	club[44].id=44;
	club[44].clubname="Napoli";
	club[44].reputation=183;  //there is a league called relegated
	club[44].league="serie a";
	club[44].icon="napoli";
	club[44].maincolour=teal;  //dashboard panel and match panel colour
	club[44].textcolour=navy;  //text colour to contrast the main colour
	club[44].shirt=teal;
	club[44].shorts=Color.white;
	club[44].socks=navy;
	club[44].shirtpattern=0;
	club[44].qualifiedleague="champions league";  //champions league uefa cup
	club[44].communityshield=false;  //and spanish super cup
	club[44].championsleaguewins=0;
	club[44].uefacupwins=1;
	club[44].money=18700000;             // club gets more money upon winning leagues or finishing at certain positions
	club[44].formation=433;
	club[44].mentality="attacking";
	club[44].manager="Ancelotti";
	club[44].players=new int[]{194,72,182,290,166,1004,40,319,1165,561,61,530,426,403,546,582,1245,1930,-1,-1,-1,-1,-1};

	club[45]= new clubs();
	club[45].id=45;
	club[45].clubname="Parma";
	club[45].reputation=130;  //there is a league called relegated
	club[45].league="serie a";
	club[45].icon="parma";
	club[45].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[45].textcolour=darkgreen;  //text colour to contrast the main colour
	club[45].shirt=Color.yellow;
	club[45].shorts=Color.green;
	club[45].socks=Color.yellow;
	club[45].shirtpattern=0;
	club[45].qualifiedleague="none";  //champions league uefa cup
	club[45].communityshield=false;  //and spanish super cup
	club[45].championsleaguewins=0;
	club[45].uefacupwins=2;
	club[45].money=6000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[45].formation=541;
	club[45].mentality="normal";
	club[45].manager="D'Aversa";
	club[45].players=new int[]{10609,1422,4078,4192,5412,2661,6032,7969,2683,3944,2910,4729,5914,6929,8122,8266,9849,10551,-1,-1,-1,-1,-1};

	club[46]= new clubs();
	club[46].id=46;
	club[46].clubname="Roma";
	club[46].reputation=172;  //there is a league called relegated
	club[46].league="serie a";
	club[46].icon="roma";
	club[46].maincolour=maroon;  //dashboard panel and match panel colour
	club[46].textcolour=orange;  //text colour to contrast the main colour
	club[46].shirt=maroon;
	club[46].shorts=orange;
	club[46].socks=maroon;
	club[46].shirtpattern=0;
	club[46].qualifiedleague="champions league";  //champions league uefa cup
	club[46].communityshield=false;  //and spanish super cup
	club[46].championsleaguewins=0;
	club[46].uefacupwins=0;
	club[46].money=16500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[46].formation=442;
	club[46].mentality="normal";
	club[46].manager="Di Francesco";
	club[46].players=new int[]{1374,478,105,268,226,1115,59,108,737,362,113,193,441,448,627,1208,708,977,1001,1043,-1,-1,-1};

	club[47]= new clubs();
	club[47].id=47;
	club[47].clubname="Sampdoria";
	club[47].reputation=155;  //there is a league called relegated
	club[47].league="serie a";
	club[47].icon="sampdoria";
	club[47].maincolour=Color.white;  //dashboard panel and match panel colour
	club[47].textcolour=Color.blue;  //text colour to contrast the main colour
	club[47].shirt=Color.blue;
	club[47].shorts=Color.white;
	club[47].socks=Color.white;
	club[47].shirtpattern=0;
	club[47].qualifiedleague="none";  //champions league uefa cup
	club[47].communityshield=false;  //and spanish super cup
	club[47].championsleaguewins=0;
	club[47].uefacupwins=0;
	club[47].money=8100000;             // club gets more money upon winning leagues or finishing at certain positions
	club[47].formation=541;
	club[47].mentality="defensive";
	club[47].manager="Giampaolo";
	club[47].players=new int[]{281,1908,1672,2124,2841,771,1955,1969,1541,723,1601,2253,2254,2721,3019,-1,-1,-1,-1,-1,-1,-1,-1};

	club[48]= new clubs();
	club[48].id=48;
	club[48].clubname="Sassuolo";
	club[48].reputation=145;  //there is a league called relegated
	club[48].league="serie a";
	club[48].icon="sassuolo";
	club[48].maincolour=Color.green;  //dashboard panel and match panel colour
	club[48].textcolour=Color.black;  //text colour to contrast the main colour
	club[48].shirt=Color.green;
	club[48].shorts=Color.black;
	club[48].socks=Color.black;
	club[48].shirtpattern=0;
	club[48].qualifiedleague="none";  //champions league uefa cup
	club[48].communityshield=false;  //and spanish super cup
	club[48].championsleaguewins=0;
	club[48].uefacupwins=0;
	club[48].money=6800000;             // club gets more money upon winning leagues or finishing at certain positions
	club[48].formation=442;
	club[48].mentality="normal";
	club[48].manager="Roberto DeZerbi";
	club[48].players=new int[]{287,1029,236,2579,312,5302,1152,1450,6450,1403,2151,1861,1891,1983,3400,3420,7113,11489,-1,-1,-1,-1,-1};

	club[49]= new clubs();
	club[49].id=49;
	club[49].clubname="Udinese";
	club[49].reputation=140;  //there is a league called relegated
	club[49].league="serie a";
	club[49].icon="udinese";
	club[49].maincolour=Color.black;  //dashboard panel and match panel colour
	club[49].textcolour=Color.white;  //text colour to contrast the main colour
	club[49].shirt=Color.white;
	club[49].shorts=Color.black;
	club[49].socks=Color.white;
	club[49].shirtpattern=0;
	club[49].qualifiedleague="none";  //champions league uefa cup
	club[49].communityshield=false;  //and spanish super cup
	club[49].championsleaguewins=0;
	club[49].uefacupwins=0;
	club[49].money=1000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[49].formation=442;
	club[49].mentality="normal";
	club[49].manager="Velasquez";
	club[49].players=new int[]{1688,2885,665,2292,3496,1256,936,1588,1038,2152,1919,1849,1823,2365,2386,2828,3206,-1,-1,-1,-1,-1,-1};

	club[50]= new clubs();
	club[50].id=50;
	club[50].clubname="Torino";
	club[50].reputation=168;  //there is a league called relegated
	club[50].league="serie a";
	club[50].icon="torino";
	club[50].maincolour=Color.white;  //dashboard panel and match panel colour
	club[50].textcolour=Color.red;  //text colour to contrast the main colour
	club[50].shirt=Color.white;
	club[50].shorts=Color.red;
	club[50].socks=Color.white;
	club[50].shirtpattern=0;
	club[50].qualifiedleague="none";  //champions league uefa cup
	club[50].communityshield=false;  //and spanish super cup
	club[50].championsleaguewins=0;
	club[50].uefacupwins=0;
	club[50].money=11000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[5].formation=352;
	club[50].mentality="normal";
	club[50].manager="Mazzarri";
	club[50].players=new int[]{662,652,838,955,1343,2815,560,610,2058,760,138,2783,1016,1165,1729,1850,3096,3350,3559,4089,6011,-1,-1};

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	club[51]= new clubs();
	club[51].id=51;
	club[51].clubname="Bayern Munich";
	club[51].reputation=188;  //there is a league called relegated
	club[51].league="bundesliga";
	club[51].icon="bayernmunich";
	club[51].maincolour=Color.white;  //dashboard panel and match panel colour
	club[51].textcolour=Color.red;  //text colour to contrast the main colour
	club[51].shirt=Color.red;
	club[51].shorts=pink;
	club[51].socks=Color.white;
	club[51].shirtpattern=0;
	club[51].qualifiedleague="champions league";  //champions league uefa cup
	club[51].communityshield=true;  //and german super cup bayer and frankfurt
	club[51].championsleaguewins=6;
	club[51].uefacupwins=0;
	club[51].money=103000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[51].formation=442;
	club[51].mentality="attacking";
	club[51].manager="Kovac";
	club[51].players=new int[]{4,49,25,27,310,66,22,37,32,47,5,52,60,134,201,354,535,562,842,1511,-1,-1,-1};

	club[52]= new clubs();
	club[52].id=52;
	club[52].clubname="Bremen";
	club[52].reputation=160;  //there is a league called relegated
	club[52].league="bundesliga";
	club[52].icon="bremen";
	club[52].maincolour=orange;  //dashboard panel and match panel colour
	club[52].textcolour=Color.green;  //text colour to contrast the main colour
	club[52].shirt=Color.green;
	club[52].shorts=orange;
	club[52].socks=orange;
	club[52].shirtpattern=0;
	club[52].qualifiedleague="none";  //champions league uefa cup
	club[52].communityshield=false;  //and spanish super cup
	club[52].championsleaguewins=0;
	club[52].uefacupwins=0;
	club[52].money=4000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[52].formation=442;
	club[52].mentality="normal";
	club[52].manager="Kohfeldt";
	club[52].players=new int[]{2057,1764,1018,1305,1620,2541,651,1637,1974,1890,262,2122,1936,3077,3151,3351,3978,4388,-1,-1,-1,-1,-1};

	club[53]= new clubs();
	club[53].id=53;
	club[53].clubname="Dortmund";
	club[53].reputation=183;  //there is a league called relegated
	club[53].league="bundesliga";
	club[53].icon="dortmund";
	club[53].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[53].textcolour=Color.black;  //text colour to contrast the main colour
	club[53].shirt=Color.yellow;
	club[53].shorts=Color.black;
	club[53].socks=Color.yellow;
	club[53].shirtpattern=0;
	club[53].qualifiedleague="champions league";  //champions league uefa cup
	club[53].communityshield=false;  //and spanish super cup
	club[53].championsleaguewins=1;
	club[53].uefacupwins=0;
	club[53].money=22000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[53].formation=442;
	club[53].mentality="normal";
	club[53].manager="Favre";
	club[53].players=new int[]{110,453,62,165,179,315,158,303,282,55,23,347,340,334,440,528,657,698,782,-1,-1,-1,-1};

	club[54]= new clubs();
	club[54].id=54;
	club[54].clubname="Dusseldorf";
	club[54].reputation=150;  //there is a league called relegated
	club[54].league="bundesliga";
	club[54].icon="dusseldorf";
	club[54].maincolour=Color.white;  //dashboard panel and match panel colour
	club[54].textcolour=Color.red;  //text colour to contrast the main colour
	club[54].shirt=Color.white;
	club[54].shorts=Color.red;
	club[54].socks=Color.white;
	club[54].shirtpattern=0;
	club[54].qualifiedleague="none";  //champions league uefa cup
	club[54].communityshield=false;  //and spanish super cup
	club[54].championsleaguewins=0;
	club[54].uefacupwins=0;
	club[54].money=1300000;             // club gets more money upon winning leagues or finishing at certain positions
	club[54].formation=433;
	club[54].mentality="normal";
	club[54].manager="Funkel";
	club[54].players=new int[]{2228,5517,4315,4570,3473,4790,5874,5977,9960,4070,2402,5897,4903,4201,5978,6065,6590,9020,-1,-1,-1,-1,-1};

	club[55]= new clubs();
	club[55].id=55;
	club[55].clubname="frankfurt";
	club[55].reputation=165;  //there is a league called relegated
	club[55].league="bundesliga";
	club[55].icon="frankfurt";
	club[55].maincolour=Color.black;  //dashboard panel and match panel colour
	club[55].textcolour=Color.white;  //text colour to contrast the main colour
	club[55].shirt=Color.black;
	club[55].shorts=Color.red;
	club[55].socks=Color.black;
	club[55].shirtpattern=0;
	club[55].qualifiedleague="none";  //champions league uefa cup
	club[55].communityshield=true;  //and spanish super cup
	club[55].championsleaguewins=0;
	club[55].uefacupwins=2;
	club[55].money=9000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[55].formation=442;
	club[55].mentality="normal";
	club[55].manager="Hutter";
	club[55].players=new int[]{348,1132,668,1052,1328,1543,1451,1121,624,1023,476,1072,1557,1971,2076,2392,-1,-1,-1,-1,-1,-1,-1};

	club[56]= new clubs();
	club[56].id=56;
	club[56].clubname="freiburg";
	club[56].reputation=140;  //there is a league called relegated
	club[56].league="bundesliga";
	club[56].icon="freiburg";
	club[56].maincolour=Color.white;  //dashboard panel and match panel colour
	club[56].textcolour=Color.black;  //text colour to contrast the main colour
	club[56].shirt=Color.black;
	club[56].shorts=Color.black;
	club[56].socks=Color.black;
	club[56].shirtpattern=0;
	club[56].qualifiedleague="none";  //champions league uefa cup
	club[56].communityshield=false;  //and spanish super cup
	club[56].championsleaguewins=0;
	club[56].uefacupwins=0;
	club[56].money=1700000;             // club gets more money upon winning leagues or finishing at certain positions
	club[56].formation=442;
	club[56].mentality="normal";
	club[56].manager="Streich";
	club[56].players=new int[]{1649,3805,2105,2468,3817,3837,3069,3174,1571,1495,1251,3384,3863,3901,4363,4670,-1,-1,-1,-1,-1,-1,-1};

	club[57]= new clubs();
	club[57].id=57;
	club[57].clubname="Hamburg";
	club[57].reputation=130;  //there is a league called relegated
	club[57].league="bundesliga";
	club[57].icon="hamburg";
	club[57].maincolour=Color.white;  //dashboard panel and match panel colour
	club[57].textcolour=Color.red;  //text colour to contrast the main colour
	club[57].shirt=Color.cyan;
	club[57].shorts=Color.red;
	club[57].socks=Color.blue;
	club[57].shirtpattern=0;
	club[57].qualifiedleague="none";  //champions league uefa cup
	club[57].communityshield=false;  //and spanish super cup
	club[57].championsleaguewins=1;
	club[57].uefacupwins=0;
	club[57].money=0;             // club gets more money upon winning leagues or finishing at certain positions
	club[57].formation=442;
	club[57].mentality="normal";
	club[57].manager="Titz";
	club[57].players=new int[]{1811,1830,630,1320,2308,740,1204,1494,1449,5628,1921,2021,871,1493,2341,2512,4038,5504,-1,-1,-1,-1,-1};

	club[58]= new clubs();
	club[58].id=58;
	club[58].clubname="Hertha";
	club[58].reputation=160;  //there is a league called relegated
	club[58].league="bundesliga";
	club[58].icon="hertha";
	club[58].maincolour=Color.blue;  //dashboard panel and match panel colour
	club[58].textcolour=navy;  //text colour to contrast the main colour
	club[58].shirt=Color.blue;
	club[58].shorts=navy;
	club[58].socks=navy;
	club[58].shirtpattern=0;
	club[58].qualifiedleague="none";  //champions league uefa cup
	club[58].communityshield=false;  //and spanish super cup
	club[58].championsleaguewins=0;
	club[58].uefacupwins=0;
	club[58].money=7000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[58].formation=442;
	club[58].mentality="normal";
	club[58].manager="Gegenbauer";
	club[58].players=new int[]{298,2992,728,914,747,499,580,845,923,2503,497,1424,1406,1443,1564,1666,2856,-1,-1,-1,-1,-1,-1};

	club[59]= new clubs();
	club[59].id=59;
	club[59].clubname="Hoffenheim";
	club[59].reputation=155;  //there is a league called relegated
	club[59].league="bundesliga";
	club[59].icon="hoffenheim";
	club[59].maincolour=Color.white;  //dashboard panel and match panel colour
	club[59].textcolour=Color.black;  //text colour to contrast the main colour
	club[59].shirt=Color.black;
	club[59].shorts=Color.black;
	club[59].socks=Color.black;
	club[59].shirtpattern=0;
	club[59].qualifiedleague="champions league";  //champions league uefa cup
	club[59].communityshield=false;  //and spanish super cup
	club[59].championsleaguewins=0;
	club[59].uefacupwins=0;
	club[59].money=800000;             // club gets more money upon winning leagues or finishing at certain positions
	club[59].formation=541;
	club[59].mentality="defensive";
	club[59].manager="Nagelsmann";
	club[59].players=new int[]{241,1787,443,615,764,953,400,1049,556,631,305,1074,1243,1292,1421,1966,2023,-1,-1,-1,-1,-1,-1};

	club[60]= new clubs();
	club[60].id=60;
	club[60].clubname="Leipzig";
	club[60].reputation=175;  //there is a league called relegated
	club[60].league="bundesliga";
	club[60].icon="leipzig";
	club[60].maincolour=navy;  //dashboard panel and match panel colour
	club[60].textcolour=Color.red;  //text colour to contrast the main colour
	club[60].shirt=navy;
	club[60].shorts=navy;
	club[60].socks=Color.red;
	club[60].shirtpattern=0;
	club[60].qualifiedleague="uefa cup";  //champions league uefa cup
	club[60].communityshield=false;  //and spanish super cup
	club[60].championsleaguewins=0;
	club[60].uefacupwins=0;
	club[60].money=38600000;             // club gets more money upon winning leagues or finishing at certain positions
	club[60].formation=442;
	club[60].mentality="normal";
	club[60].manager="Rangnick";
	club[60].players=new int[]{1261,1996,563,1567,2894,3600,129,139,311,208,755,769,338,809,1480,1781,1909,3652,-1,-1,-1,-1,-1};

	club[61]= new clubs();
	club[61].id=61;
	club[61].clubname="Leverkusen";
	club[61].reputation=170;  //there is a league called relegated
	club[61].league="bundesliga";
	club[61].icon="leverkusen";
	club[61].maincolour=Color.red;  //dashboard panel and match panel colour
	club[61].textcolour=Color.black;  //text colour to contrast the main colour
	club[61].shirt=Color.red;
	club[61].shorts=Color.black;
	club[61].socks=Color.red;
	club[61].shirtpattern=0;
	club[61].qualifiedleague="uefa cup";  //champions league uefa cup
	club[61].communityshield=false;  //and spanish super cup
	club[61].championsleaguewins=0;
	club[61].uefacupwins=1;
	club[61].money=10700000;             // club gets more money upon winning leagues or finishing at certain positions
	club[61].formation=442;
	club[61].mentality="normal";
	club[61].manager="Peter Bosz";
	club[61].players=new int[]{77,1101,206,469,1404,1237,399,273,228,425 ,1275,1368,788,815,849,1540,1566,1855,-1,-1,-1,-1,-1};

	club[62]= new clubs();
	club[62].id=62;
	club[62].clubname="mainz";
	club[62].reputation=155;  //there is a league called relegated
	club[62].league="bundesliga";
	club[62].icon="mainz";
	club[62].maincolour=Color.grey;  //dashboard panel and match panel colour
	club[62].textcolour=Color.black;  //text colour to contrast the main colour
	club[62].shirt=Color.white;
	club[62].shorts=Color.grey;
	club[62].socks=Color.grey;
	club[62].shirtpattern=0;
	club[62].qualifiedleague="none";  //champions league uefa cup
	club[62].communityshield=false;  //and spanish super cup
	club[62].championsleaguewins=0;
	club[62].uefacupwins=0;
	club[62].money=6000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[62].formation=442;
	club[62].mentality="normal";
	club[62].manager="Schwarz";
	club[62].players=new int[]{688,1704,1169,1623,1394,1807,1186,1285,1261,1381,930,1753,1496,1862,1877,1923,-1,-1,-1,-1,-1,-1,-1};

	club[63]= new clubs();
	club[63].id=63;
	club[63].clubname="Mgladbach";
	club[63].reputation=167;  //there is a league called relegated
	club[63].league="bundesliga";
	club[63].icon="mgladbach";
	club[63].maincolour=darkgreen;  //dashboard panel and match panel colour
	club[63].textcolour=Color.black;  //text colour to contrast the main colour
	club[63].shirt=darkgreen;
	club[63].shorts=Color.black;
	club[63].socks=darkgreen;
	club[63].shirtpattern=0;
	club[63].qualifiedleague="none";  //champions league uefa cup
	club[63].communityshield=false;  //and spanish super cup
	club[63].championsleaguewins=0;
	club[63].uefacupwins=0;
	club[63].money=5300000;             // club gets more money upon winning leagues or finishing at certain positions
	club[63].formation=433;
	club[63].mentality="normal";
	club[63].manager="Hecking";
	club[63].players=new int[]{175,9252,570,745,643,595,254,566,463,293,421,884,919,1079,1104,1244,1296,2144,2289,2804,3692,6584,-1};

	club[64]= new clubs();
	club[64].id=64;
	club[64].clubname="Schalke";
	club[64].reputation=135;  //there is a league called relegated
	club[64].league="bundesliga";
	club[64].icon="schalke";
	club[64].maincolour=Color.white;  //dashboard panel and match panel colour
	club[64].textcolour=Color.blue;  //text colour to contrast the main colour
	club[64].shirt=Color.blue;
	club[64].shorts=Color.white;
	club[64].socks=Color.blue;
	club[64].shirtpattern=0;
	club[64].qualifiedleague="champions league";  //champions league uefa cup
	club[64].communityshield=false;  //and spanish super cup
	club[64].championsleaguewins=0;
	club[64].uefacupwins=1;
	club[64].money=8900000;             // club gets more money upon winning leagues or finishing at certain positions
	club[64].formation=442;
	club[64].mentality="normal";
	club[64].manager="Tedesco";
	club[64].players=new int[]{116,1167,277,415,483,585,211,396,895,1650,1447,1716,795,541,987,1209,3801,3853,-1,-1,-1,-1,-1};

	club[65]= new clubs();
	club[65].id=65;
	club[65].clubname="Stutggart";
	club[65].reputation=130;  //there is a league called relegated
	club[65].league="bundesliga";
	club[65].icon="stutggart";
	club[65].maincolour=Color.white;  //dashboard panel and match panel colour
	club[65].textcolour=orange;  //text colour to contrast the main colour
	club[65].shirt=Color.white;
	club[65].shorts=orange;
	club[65].socks=Color.white;
	club[65].shirtpattern=0;
	club[65].qualifiedleague="none";  //champions league uefa cup
	club[65].communityshield=false;  //and spanish super cup
	club[65].championsleaguewins=0;
	club[65].uefacupwins=0;
	club[65].money=2690000;             // club gets more money upon winning leagues or finishing at certain positions
	club[65].formation=442;
	club[65].mentality="normal";
	club[65].manager="Korkut";
	club[65].players=new int[]{625,1562,2394,3252,1665,1475,823,2764,2939,1925,1125,3397,2373,4259,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[66]= new clubs();
	club[66].id=66;
	club[66].clubname="Wolfsburg";
	club[66].reputation=165;  //there is a league called relegated
	club[66].league="bundesliga";
	club[66].icon="wolfsburg";
	club[66].maincolour=Color.white;  //dashboard panel and match panel colour
	club[66].textcolour=darkgreen;  //text colour to contrast the main colour
	club[66].shirt=Color.white;
	club[66].shorts=darkgreen;
	club[66].socks=darkgreen;
	club[66].shirtpattern=0;
	club[66].qualifiedleague="none";  //champions league uefa cup
	club[66].communityshield=false;  //and spanish super cup
	club[66].championsleaguewins=0;
	club[66].uefacupwins=0;
	club[66].money=16000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[66].formation=433;
	club[66].mentality="attacking";
	club[66].manager="Kovac";
	club[66].players=new int[]{893,1619,418,597,1047,827,357,432,727,605,292,576,555,438,1418,1622,1662,-1,-1,-1,-1,-1,-1};

	//xxxxxxxxxxxxxxxxxxxxxxrelegated teams xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	club[67]= new clubs();
	club[67].id=67;
	club[67].clubname="Norwich";
	club[67].reputation=127;  //there is a league called relegated
	club[67].league="premier league";
	club[67].icon="norwich";
	club[67].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[67].textcolour=darkgreen;  //text colour to contrast the main colour
	club[67].shirt=Color.yellow;
	club[67].shorts=Color.green;
	club[67].socks=Color.yellow;
	club[67].shirtpattern=0;
	club[67].qualifiedleague="none";  //champions league uefa cup
	club[67].communityshield=false;  //and spanish super cup
	club[67].championsleaguewins=0;
	club[67].uefacupwins=0;
	club[67].money=1000000;             // club gets more money upon winning leagues or finishing at certain positions
	club[67].formation=442;
	club[67].mentality="normal";
	club[67].manager="Farke";
	club[67].players=new int[]{6691,4235,1531,3988,3220,956,2734,3684,5723,3502,2330,3946,3984,4494,5858,6054,6310,6347,-1,-1,-1,-1,-1};

	club[68]= new clubs();
	club[68].id=68;
	club[68].clubname="Wolves";
	club[68].reputation=120;  //there is a league called relegated
	club[68].league="premier league";
	club[68].icon="wolves";
	club[68].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[68].textcolour=Color.black;  //text colour to contrast the main colour
	club[68].shirt=Color.yellow;
	club[68].shorts=Color.black;
	club[68].socks=Color.black;
	club[68].shirtpattern=0;
	club[68].qualifiedleague="none";  //champions league uefa cup
	club[68].communityshield=false;  //and spanish super cup
	club[68].championsleaguewins=0;
	club[68].uefacupwins=0;
	club[68].money=500000;             // club gets more money upon winning leagues or finishing at certain positions
	club[68].formation=442;
	club[68].mentality="normal";
	club[68].manager="Manager";
	club[68].players=new int[]{3349,2034,880,1469,3640,2130,966,2410,1279,2065,1162,3708,4660,4645,4832,-1,-1,-1,-1,-1,-1,-1,-1};

	club[69]= new clubs();
	club[69].id=69;
	club[69].clubname="Leeds";
	club[69].reputation=115;  //there is a league called relegated
	club[69].league="premier league";
	club[69].icon="leeds";
	club[69].maincolour=Color.white;  //dashboard panel and match panel colour
	club[69].textcolour=gold;  //text colour to contrast the main colour
	club[69].shirt=Color.white;
	club[69].shorts=gold;
	club[69].socks=Color.white;
	club[69].shirtpattern=0;
	club[69].qualifiedleague="none";  //champions league uefa cup
	club[69].communityshield=false;  //and spanish super cup
	club[69].championsleaguewins=0;
	club[69].uefacupwins=0;
	club[69].money=800000;             // club gets more money upon winning leagues or finishing at certain positions
	club[69].formation=442;
	club[69].mentality="normal";
	club[69].manager="Caldera";
	club[69].players=new int[]{8813,6154,4922,9695,16089,15434,6056,6523,5954,9449,7338,11618,6977,12505,13592,15073,16085,-1,-1,-1,-1,-1,-1};

	for(int i=35;i<=69;i++)
		club[i].eurovase=false;
	for(int i=1;i<=16;i++)
		club[i].leaguecup=true;
	for(int i=17;i<=18;i++)
		club[i].leaguecup=false;
	for(int i=67;i<=69;i++)
		club[i].leaguecup=false;
	//xxxxxxxxxxxxunplayablexxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	club[70]= new clubs();
	club[70].id=70;
	club[70].clubname="Porto";
	club[70].icon="clubblue";
	club[70].maincolour=teal;  
	club[70].textcolour=navy;
	club[70].reputation=185;  //there is a league called relegated
	//text colour to contrast the main colour
	club[70].shirt=Color.white;
	club[70].shorts=teal;
	club[70].socks=Color.white;
	club[70].shirtpattern=8;
	club[70].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[70].formation=442;
	club[70].mentality="attacking";
	club[70].players=new int[]{197,398,146,215,404,259,549,672,344,787,521,729,477,784,830,856,875,954,957,-1,-1,-1,-1};

	club[71]= new clubs();
	club[71].id=71;
	club[71].clubname="benfica";
	club[71].icon="wolfsburg";
	club[71].maincolour=darkgreen;  //dashboard panel and match panel colour
	club[71].textcolour=Color.red;
	club[71].reputation=175;  //there is a league called relegated
	//text colour to contrast the main colour
	club[71].shirt=maroon;
	club[71].shorts=darkgreen;
	club[71].socks=darkgreen;
	club[71].shirtpattern=0;
	club[71].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[71].formation=442;
	club[71].mentality="normal";
	club[71].players=new int[]{517,405,489,533,1354,446,741,264,239,719,177,757,673,705,870,902,1011,1051,1330,-1,-1,-1,-1};

	club[72]= new clubs();
	club[72].id=72;
	club[72].clubname="Ajax";
	club[72].icon="clubred";
	club[72].maincolour=Color.white;  //dashboard panel and match panel colour
	club[72].textcolour=Color.black;
	club[72].reputation=179;  //there is a league called relegated
	//text colour to contrast the main colour
	club[72].shirt=Color.white;
	club[72].shorts=Color.red;
	club[72].socks=Color.red;
	club[72].shirtpattern=0;
	club[72].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[72].formation=442;
	club[72].mentality="attacking";
	club[72].players=new int[]{700,1096,1083,1462,1555,2950,317,1054,2950,696,1002,872,1339,1350,1485,1689,1774,2212,2249,2380,-1,-1,-1};

	club[73]= new clubs();
	club[73].id=73;
	club[73].clubname="Psv Eindhoven";
	club[73].icon="clubmaroon";
	club[73].maincolour=Color.white;  //dashboard panel and match panel colour
	club[73].textcolour=Color.black;
	club[73].reputation=175;  //there is a league called relegated
	//text colour to contrast the main colour
	club[73].shirt=Color.white;
	club[73].shorts=Color.black;
	club[73].socks=Color.black;
	club[73].shirtpattern=7;
	club[73].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[73].formation=442;
	club[73].mentality="normal";
	club[73].players=new int[]{609,2414,1962,2356,1187,9064,783,1223,10362,1383,1335,1616,1284,710,-1,-1,-1,-1,-1,-1,-1,-1,-1};


	club[74]= new clubs();
	club[74].id=74;
	club[74].clubname="Club Brugge";
	club[74].icon="clubwhite";
	club[74].maincolour=Color.white;  //dashboard panel and match panel colour
	club[74].textcolour=Color.black;
	club[74].reputation=170;  //there is a league called relegated
	//text colour to contrast the main colour
	club[74].shirt=pink;
	club[74].shorts=Color.cyan;
	club[74].socks=Color.white;
	club[74].shirtpattern=0;
	club[74].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[74].formation=442;
	club[74].mentality="normal";
	club[74].players=new int[]{2173,2213,1496,2156,1608,2917,1210,1975,1196,1226,3562,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};


	club[75]= new clubs();
	club[75].id=75;
	club[75].clubname="Olympiakos";
	club[75].icon="clubred";
	club[75].maincolour=Color.red;  //dashboard panel and match panel colour
	club[75].textcolour=Color.white;
	club[75].reputation=168;  //there is a league called relegated
	//text colour to contrast the main colour
	club[75].shirt=Color.red;
	club[75].shorts=Color.white;
	club[75].socks=Color.red;
	club[75].shirtpattern=0;
	club[75].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[75].formation=442;
	club[75].mentality="normal";
	club[75].players=new int[]{985,2311,1420,1842,1779,761,801,878,946,2593,1865,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};


	club[76]= new clubs();
	club[76].id=76;
	club[76].clubname="AIK";
	club[76].icon="clubwhite";
	club[76].maincolour=Color.white;  //dashboard panel and match panel colour
	club[76].textcolour=Color.black;
	club[76].reputation=160;  //there is a league called relegated
	//text colour to contrast the main colour
	club[76].shirt=Color.yellow;
	club[76].shorts=Color.blue;
	club[76].socks=Color.yellow;
	club[76].shirtpattern=0;
	club[76].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[76].formation=442;
	club[76].mentality="normal";
	club[76].players=new int[]{11743,8420,3054,3522,8222,9741,5653,5890,6603,4407,2345,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[77]= new clubs();
	club[77].id=77;
	club[77].clubname="PSG";
	club[77].icon="clubblue";
	club[77].maincolour=navy;  //dashboard panel and match panel colour
	club[77].textcolour=Color.white;
	club[77].reputation=180;  //there is a league called relegated
	//text colour to contrast the main colour
	club[77].shirt=navy;
	club[77].shorts=navy;
	club[77].socks=Color.red;
	club[77].shirtpattern=0;
	club[77].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[77].formation=442;
	club[77].mentality="normal";
	club[77].players=new int[]{250,83,30,140,124,2,34,99,127,378,38,156,234,314,323,389,603,991,1178,2453,4735,6348,7049};

	club[78]= new clubs();
	club[78].id=78;
	club[78].clubname="Marseille";
	club[78].icon="clubcyan";
	club[78].maincolour=Color.white;  //dashboard panel and match panel colour
	club[78].textcolour=Color.black;
	club[78].reputation=173;  //there is a league called relegated
	//text colour to contrast the main colour
	club[78].shirt=Color.white;
	club[78].shorts=Color.cyan;
	club[78].socks=teal;
	club[78].shirtpattern=0;
	club[78].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[78].formation=442;
	club[78].mentality="normal";
	club[78].players=new int[]{285,515,366,459,1836,1309,120,313,222,422,364,2102,1148,1265,1603,1644,-1,-1,-1,-1,-1,-1,-1};

	club[79]= new clubs();
	club[79].id=79;
	club[79].clubname="Fc Basel";
	club[79].icon="clubred";
	club[79].maincolour=Color.white;  //dashboard panel and match panel colour
	club[79].textcolour=Color.black;
	club[79].reputation=165;  //there is a league called relegated
	//text colour to contrast the main colour
	club[79].shirt=Color.grey;
	club[79].shorts=Color.black;
	club[79].socks=maroon;
	club[79].shirtpattern=0;
	club[79].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[79].formation=442;
	club[79].mentality="normal";
	club[79].players=new int[]{1028,5945,1431,3630,1145,766,1050,1366,6475,6264 ,1838,5489,2296,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[80]= new clubs();
	club[80].id=80;
	club[80].clubname="Sparta Prague";
	club[80].icon="clubwhite";
	club[80].maincolour=Color.white;  //dashboard panel and match panel colour
	club[80].textcolour=Color.black;
	club[80].reputation=160;  //there is a league called relegated
	//text colour to contrast the main colour
	club[80].shirt=maroon;
	club[80].shorts=maroon;
	club[80].socks=maroon;
	club[80].shirtpattern=0;
	club[80].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[80].formation=442;
	club[80].mentality="normal";
	club[80].players=new int[]{5356,3690,2985,3228,3064,3410,2778,1820,690,3340,2381,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[81]= new clubs();
	club[81].id=81;
	club[81].clubname="legia Warsaw";
	club[81].icon="clubwhite";
	club[81].maincolour=Color.white;  //dashboard panel and match panel colour
	club[81].textcolour=Color.black;
	club[81].reputation=155;  //there is a league called relegated
	//text colour to contrast the main colour
	club[81].shirt=Color.white;
	club[81].shorts=Color.red;
	club[81].socks=Color.black;
	club[81].shirtpattern=0;
	club[81].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[81].formation=442;
	club[81].mentality="normal";
	club[81].players=new int[]{4921,4708,1483,4256,2969,4146,2216,3414,3251,2262,4840,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[82]= new clubs();
	club[82].id=82;
	club[82].clubname="Aalborg";
	club[82].icon="clubwhite";
	club[82].maincolour=Color.white;  //dashboard panel and match panel colour
	club[82].textcolour=Color.black;
	club[82].reputation=165;  //there is a league called relegated
	//text colour to contrast the main colour
	club[82].shirt=vomit;
	club[82].shorts=Color.black;
	club[82].socks=Color.white;
	club[82].shirtpattern=0;
	club[82].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[82].formation=442;
	club[82].mentality="normal";
	club[82].players=new int[]{7250,5447,2981,11069,11026,9783,5258,9186,8949,10082,10999,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[83]= new clubs();
	club[83].id=83;
	club[83].clubname="Rosenborg";
	club[83].icon="clubwhite";
	club[83].maincolour=Color.white;  //dashboard panel and match panel colour
	club[83].textcolour=Color.black;
	club[83].reputation=160;  //there is a league called relegated
	//text colour to contrast the main colour
	club[83].shirt=Color.white;
	club[83].shorts=navy;
	club[83].socks=teal;
	club[83].shirtpattern=0;
	club[83].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[83].formation=442;
	club[83].mentality="normal";
	club[83].players=new int[]{3997,5334,2975,6309,3409,6969,2551,4854,5534,4194,2697,6309,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};



	club[84]= new clubs();
	club[84].id=84;
	club[84].clubname="Rangers";
	club[84].icon="clubblue";
	club[84].maincolour=navy;  //dashboard panel and match panel colour
	club[84].textcolour=Color.white;
	club[84].reputation=163;  //there is a league called relegated
	//text colour to contrast the main colour
	club[84].shirt=navy;
	club[84].shorts=Color.white;
	club[84].socks=navy;
	club[84].shirtpattern=0;
	club[84].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[84].formation=442;
	club[84].mentality="normal";
	club[84].players=new int[]{2935,3608,812,2404,3214,4513,2781,2715,2095,4069,3271,3749,2145,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};


	club[85]= new clubs();
	club[85].id=85;
	club[85].clubname="Fenerbahche";
	club[85].icon="clubyellow";
	club[85].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[85].textcolour=Color.black;
	club[85].reputation=166;  //there is a league called relegated
	//text colour to contrast the main colour
	club[85].shirt=Color.yellow;
	club[85].shorts=navy;
	club[85].socks=Color.white;
	club[85].shirtpattern=0;
	club[85].qualifiedleague="champions league";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[85].formation=442;
	club[85].mentality="normal";
	club[85].players=new int[]{513,1901,376,511,1397,371,360,912,958,829,1190,1117,982,1235,1262,1453,1717,-1,-1,-1,-1,-1,-1};

	// xxxxxxx  unplayable uefa cup xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	club[86]= new clubs();
	club[86].id=86;
	club[86].clubname="Sporting Lisbon";
	club[86].icon="wolfsburg";
	club[86].maincolour=Color.green;  //dashboard panel and match panel colour
	club[86].textcolour=Color.black;
	club[86].reputation=165;  //there is a league called relegated
	//text colour to contrast the main colour
	club[86].shirt=Color.green;
	club[86].shorts=Color.green;
	club[86].socks=Color.green;
	club[86].shirtpattern=0;
	club[86].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[86].formation=442;
	club[86].mentality="normal";
	club[86].players=new int[]{174,512,336,1005,1163,524,141,715,301,620,160,725,731,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};



	club[87]= new clubs();
	club[87].id=87;
	club[87].clubname="Feyenoord";
	club[87].icon="clubmaroonpurple";
	club[87].maincolour=purple;  //dashboard panel and match panel colour
	club[87].textcolour=Color.white;
	club[87].reputation=165;  //there is a league called relegated
	//text colour to contrast the main colour
	club[87].shirt=Color.white;
	club[87].shorts=Color.red;
	club[87].socks=Color.black;
	club[87].shirtpattern=0;
	club[87].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[87].formation=442;
	club[87].mentality="normal";
	club[87].players=new int[]{897,1954,419,1357,2059,1360,498,765,1313,590,3406,4243,1048,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[88]= new clubs();
	club[88].id=88;
	club[88].clubname="Shakhtar Donetsk";
	club[88].icon="clubyellow";
	club[88].maincolour=Color.yellow;  //dashboard panel and match panel colour
	club[88].textcolour=Color.black;
	club[88].reputation=160;  //there is a league called relegated
	//text colour to contrast the main colour
	club[88].shirt=orange;
	club[88].shorts=Color.black;
	club[88].socks=Color.white;
	club[88].shirtpattern=0;
	club[88].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[88].formation=442;
	club[88].mentality="normal";
	club[88].players=new int[]{680,776,434,1269,383,412,252,406,253,3713,1491,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[89]= new clubs();
	club[89].id=89;
	club[89].clubname="Panathinaikos";
	club[89].icon="wolfsburg";
	club[89].maincolour=Color.green;  //dashboard panel and match panel colour
	club[89].textcolour=Color.black;
	club[89].reputation=157;  //there is a league called relegated
	//text colour to contrast the main colour
	club[89].shirt=Color.green;
	club[89].shorts=Color.white;
	club[89].socks=Color.green;
	club[89].shirtpattern=0;
	club[89].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[89].formation=442;
	club[89].mentality="normal";
	club[89].players=new int[]{4947,2285,1518,3369,3836,4333,3126,3135,3198,3568,1751,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[90]= new clubs();
	club[90].id=90;
	club[90].clubname="Galatasaray";
	club[90].icon="clubred";
	club[90].maincolour=Color.white;  //dashboard panel and match panel colour
	club[90].textcolour=Color.black;
	club[90].reputation=155;  //there is a league called relegated
	//text colour to contrast the main colour
	club[90].shirt=orange;
	club[90].shorts=Color.black;
	club[90].socks=Color.red;
	club[90].shirtpattern=0;
	club[90].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[90].formation=442;
	club[90].mentality="normal";
	club[90].players=new int[]{265,2517,445,2078,628,1647,341,1007,629,1592,671,385,1498,2096,2143,2195,2211,2501,-1,-1,-1,-1,-1};

	club[91]= new clubs();
	club[91].id=91;
	club[91].clubname="Celtic";
	club[91].icon="wolfsburg";
	club[91].maincolour=Color.green;  //dashboard panel and match panel colour
	club[91].textcolour=Color.white;
	club[91].reputation=162;  //there is a league called relegated
	//text colour to contrast the main colour
	club[91].shirt=Color.green;
	club[91].shorts=Color.white;
	club[91].socks=darkgreen;
	club[91].shirtpattern=0;
	club[91].qualifiedleague="uefa cup";  //champions league uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[91].formation=442;
	club[91].mentality="normal";
	club[91].players=new int[]{2328,2473,2258,2795,2747,1212,1465,1656,2101,1833,1659,2465,2157,2719,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[92]= new clubs();
	club[92].id=92;
	club[92].clubname="Lyon";
	club[92].icon="clubwhite";
	club[92].maincolour=Color.white;  //dashboard panel and match panel colour
	club[92].textcolour=Color.black;
	club[92].reputation=160;  //there is a league called relegated
	//text colour to contrast the main colour
	club[92].shirt=Color.magenta;
	club[92].shorts=Color.white;
	club[92].socks=Color.magenta;
	club[92].shirtpattern=0;
	club[92].qualifiedleague="uefa cup";  //uefa cup uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[92].formation=442;
	club[92].mentality="normal";
	club[92].players=new int[]{148,1034,638,1295,815,572,699,843,8350,552,205,1161,1507,1618,1984,2141,2236,-1,-1,-1,-1,-1,-1};

	club[93]= new clubs();
	club[93].id=93;
	club[93].clubname="Wisla Krakow";
	club[93].icon="clubwhite";
	club[93].maincolour=Color.white;  //dashboard panel and match panel colour
	club[93].textcolour=Color.black;
	club[93].reputation=150;  //there is a league called relegated
	//text colour to contrast the main colour
	club[93].shirt=gold;
	club[93].shorts=gold;
	club[93].socks=gold;
	club[93].shirtpattern=0;
	club[93].qualifiedleague="uefa cup";  //uefa cup uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[93].formation=442;
	club[93].mentality="normal";
	club[93].players=new int[]{7733,4945,5672,6409,9105,6048,6299,6559,7258,5229,3603,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	//xxxxxxxxxxxxx club world cup xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

	club[94]= new clubs();
	club[94].id=94;
	club[94].clubname="LA Galaxy";
	club[94].icon="clubwhite";
	club[94].maincolour=Color.white;  //dashboard panel and match panel colour
	club[94].textcolour=navy;
	club[94].reputation=140;  //there is a league called relegated
	//text colour to contrast the main colour
	club[94].shirt=Color.white;
	club[94].shorts=Color.white;
	club[94].socks=Color.white;
	club[94].shirtpattern=0;
	club[94].qualifiedleague="uefa cup";  //uefa cup uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[94].formation=442;
	club[94].mentality="normal";
	club[94].players=new int[]{8852,4108,3728,8107,5932,1216,3173,4176,845,4844,659,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[95]= new clubs();
	club[95].id=95;
	club[95].clubname="Al Nassr";
	club[95].icon="clubwhite";
	club[95].maincolour=Color.white;  //dashboard panel and match panel colour
	club[95].textcolour=Color.black;
	club[95].reputation=138;  //there is a league called relegated
	//text colour to contrast the main colour
	club[95].shirt=Color.white;
	club[95].shorts=pink;
	club[95].socks=Color.green;
	club[95].shirtpattern=0;
	club[95].qualifiedleague="club world cup";  //uefa cup uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[95].formation=442;
	club[95].mentality="attacking";
	club[95].players=new int[]{10000,6021,2072,3621,7786,1147,3254,3373,5310,7203,2678,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

	club[96]= new clubs();
	club[96].id=96;
	club[96].clubname="Gamba Osaka";
	club[96].icon="clubwhite";
	club[96].maincolour=Color.white;  //dashboard panel and match panel colour
	club[96].textcolour=Color.black;
	club[96].reputation=130;  //there is a league called relegated
	//text colour to contrast the main colour
	club[96].shirt=Color.white;
	club[96].shorts=Color.white;
	club[96].socks=Color.black;
	club[96].shirtpattern=8;
	club[96].qualifiedleague="uefa cup";  //uefa cup uefa cup
	// club gets more money upon winning leagues or finishing at certain positions
	club[96].formation=442;
	club[96].mentality="normal";
	club[96].players=new int[]{3992,10464,7809,7902,8191,6284,3761,5470,10028,6805,3204,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};







		//control=gameObject.GetComponent<Control>();

		for(int i=1;i<=96;i++){       //transfer all club data to control script
			Control.clubid[i]=club[i].id;
			Control.clubname[i]=club[i].clubname;
			Control.clubreputation[i]=club[i].reputation;
			Control.clubleague[i]=club[i].league;
			Control.clubicon[i]=club[i].icon;
			Control.clubmaincolour[i]=club[i].maincolour;
			Control.clubtextcolour[i]=club[i].textcolour;
			Control.clubshirt[i]=club[i].shirt;
			Control.clubshorts[i]=club[i].shorts;
			Control.clubsocks[i]=club[i].socks;
			Control.clubshirtpattern[i]=club[i].shirtpattern;
			Control.qualifiedleague[i]=club[i].qualifiedleague;
			Control.communityshield[i]=club[i].communityshield;
			Control.championsleaguewins[i]=club[i].championsleaguewins;
			Control.uefacupwins[i]=club[i].uefacupwins;
			Control.money[i]=club[i].money;
			Control.clubformation[i]=club[i].formation;
			Control.clubmentality[i]=club[i].mentality;
			Control.clubmanager[i]=club[i].manager;
			Control.clubleaguecup[i]=club[i].leaguecup;
			for(int j=0;j<club[i].players.Length;j++){ 
				Control.clubplayers[i,j]=club[i].players[j];
			}
		}



		if(global.category=="clubs"){  //set logo image clubname to chosen team
			for(int i=1;i<=96;i++ ){
				if(club[i].clubname==global.team)
				{ global.icon=club[i].icon; 
					global.id=i;}
			}
		}

	}//start

	void  OnLevelWasLoaded (){

	}

	void  Update (){
		if(global.inited==true)return;
		if(timeout<3)
			timeout+=1;
		if(timeout==1){
			if(global.category=="clubs"){  //set logo image clubname to chosen team
				for(int i=1;i<=96;i++){ 
					if(club[i].clubname==global.team)
					{ global.icon=club[i].icon; 
						global.id=i;}
				} 
			}
		}
	}

	//public void  Clubs (){
	//	return club;
	//}
}
