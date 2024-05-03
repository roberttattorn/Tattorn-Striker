using UnityEngine;
using System.Collections;
using UnityEngine.UI;  //always use this for UI

public class Portrait : MonoBehaviour {
	public Sprite MySprite;
	//private SpriteRenderer Image;
	private string FilePath ;
	// Use this for initialization
	void Start () {
		//Image=gameObject.;
		 FilePath = Application.dataPath+"/../"+"portrait.jpg";
		 //FilePath = Application.streamingAssetsPath+"/portrait.jpg";
		if(System.IO.File.Exists(FilePath)){
		MySprite = Img2Sprite.LoadNewSprite(FilePath,100.0f); // former.y img2sprite.instance.
		//Debug.Log (Application.streamingAssetsPath);
			gameObject.GetComponent<Image>().sprite =   MySprite;}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
