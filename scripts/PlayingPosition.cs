using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayingPosition : MonoBehaviour {
	global Global;
	// Use this for initialization
	void Start () {
		Global=GameObject.Find("Global").GetComponent<global>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetPlayerPosition(){
		global.role=GetComponent<Dropdown>().value;
	}

}
