using UnityEngine;
using System.Collections;

public class EntityUI : MonoBehaviour {

	
	private Rect lifeBarRect = new Rect();
	private Rect lifeBarBackgroundRect = new Rect();
	private Rect lifeBarBorderRect = new Rect();
	private Texture2D lifeBar;
	
	public Vector2 barsize = new Vector2(60f, 3f);
	public Vector2 offset = new Vector2(0, 0);
	
	public float lifePercent = 0.75f;

	public Color foregroundColor = Color.yellow;
	public Color backgroundColor = Color.red;
	public Color borderColor = Color.black;
	public float borderThickness = 2;


	// Use this for initialization
	void Start(){
		lifeBar = Resources.Load("whitePixel") as Texture2D;
	}
	
	void OnGUI()
	{
		//Limit variables into domains that make sense.
		lifePercent = Mathf.Clamp(lifePercent, 0, 1);
		borderThickness = Mathf.Max(0, borderThickness);
		barsize.x = Mathf.Max(1, barsize.x);
		barsize.y = Mathf.Max(1, barsize.y);
		
		Vector3 screenpos = Camera.mainCamera.WorldToScreenPoint(transform.position);
		screenpos.y = Camera.mainCamera.GetScreenHeight() - screenpos.y;
		
		lifeBarBorderRect.x = screenpos.x - barsize.x / 2 + offset.x - borderThickness;
		lifeBarBorderRect.y = screenpos.y + offset.y - borderThickness;
	    lifeBarBorderRect.width = barsize.x + borderThickness * 2;
	    lifeBarBorderRect.height = barsize.y + borderThickness * 2;
		
		lifeBarRect.x = screenpos.x - barsize.x / 2 + offset.x;
		lifeBarRect.y = screenpos.y + offset.y;
	    lifeBarRect.width = barsize.x * (lifePercent);
	    lifeBarRect.height = barsize.y;
	
		lifeBarBackgroundRect.x = screenpos.x - barsize.x / 2 + offset.x;
		lifeBarBackgroundRect.y = screenpos.y + offset.y;
	    lifeBarBackgroundRect.width = barsize.x;
	    lifeBarBackgroundRect.height = barsize.y;
		
		
		GUI.color = borderColor;
	    GUI.DrawTexture(lifeBarBorderRect, lifeBar);
		GUI.color = backgroundColor;
		GUI.DrawTexture(lifeBarBackgroundRect, lifeBar);
		GUI.color = foregroundColor;
	    GUI.DrawTexture(lifeBarRect, lifeBar);
	}
}