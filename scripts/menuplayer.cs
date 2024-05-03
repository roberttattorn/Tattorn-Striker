using UnityEngine;
using System.Collections;

public class menuplayer : MonoBehaviour {
	Animation animation;
	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation>();
		animation.Play("idle");
		animation["idle"].speed=0.25f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
