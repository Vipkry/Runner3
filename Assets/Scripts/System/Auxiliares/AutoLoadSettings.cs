using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AutoLoadSettings : MonoBehaviour {



	void Awake(){
		GameObject.Find("GameControl").GetComponent<GameControl>().LoadSettings();
		float ValorAtual = GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia;
		GameObject.Find("SlideDaTransparencia").GetComponent<Slider>().value = ValorAtual;
	}
}
