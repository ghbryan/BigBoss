using UnityEngine;
using System.Collections;

public class EntityUI : MonoBehaviour {

	
	public Rect lifeBarRect;
	public Rect lifeBarLabelRect;
	public Rect lifeBarBackgroundRect;
	public Texture2D lifeBarBackground;
	public Texture2D lifeBar;
	
	private float LifeBarWidth = 300f;
	
	// Use this for initialization
	void Start(){
	}
	
	void OnGUI()
	{
	    lifeBarRect.width = LifeBarWidth * (100.0f/200.0f);
	    lifeBarRect.height = 20;
	
	    lifeBarBackgroundRect.width = LifeBarWidth;
	    lifeBarBackgroundRect.height= 20;
	
	    GUI.DrawTexture(lifeBarRect, lifeBar);
	    GUI.DrawTexture(lifeBarBackgroundRect, lifeBarBackground);
	
	    GUI.Label(lifeBarLabelRect, "LIFE");
	}
}