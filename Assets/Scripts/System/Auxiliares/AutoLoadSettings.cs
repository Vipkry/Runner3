using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AutoLoadSettings : MonoBehaviour {


	//Tem o nome de AutoLoad porque apenas sera chamado uma vez e sem que o usuario precise fazer nada
	void Awake(){
		//Carrega as configuraçoes escolhidas no menu
		GameObject.Find("GameControl").GetComponent<GameControl>().LoadSettings();
		//Verifica se estamos na cena 3, que e a cena das configuraçoes(File> Build Settings, assim pode-se ver os numeros)
		if (Application.loadedLevel == 3){
			float ValorAtual = GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia;
			GameObject.Find("SlideDaTransparencia").GetComponent<Slider>().value = ValorAtual;
		}
	}
}
