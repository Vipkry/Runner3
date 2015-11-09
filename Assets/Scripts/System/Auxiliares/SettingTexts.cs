using UnityEngine;
using System.Collections;

public class SettingTexts : MonoBehaviour {

	// Use this for initialization
	void OnGUI(){
		Vector2 Pos = Camera.main.ScreenToWorldPoint(GameObject.Find("SlideDaTransparencia").transform.position);
		float ValTransparencia = GameControl.controleGeral.ValorTransparencia; 
		ValTransparencia = Mathf.Round(ValTransparencia*100);
		GUI.Label(new Rect((Screen.width/2), (Pos.y + 37), 100, 30),"" + ValTransparencia + "%");
		
		}
}
