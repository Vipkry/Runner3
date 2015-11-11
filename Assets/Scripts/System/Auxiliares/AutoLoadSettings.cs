using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AutoLoadSettings : MonoBehaviour {


	//Tem o nome de AutoLoad porque apenas sera chamado uma vez e sem que o usuario precise fazer nada
	void Start(){
		//Carrega as configuraçoes escolhidas no menu
		GameObject.Find("GameControl").GetComponent<GameControl>().LoadSettings();
		//Verifica se estamos na cena 3, que e a cena das configuraçoes(File> Build Settings, assim pode-se ver os numeros)
		// Este codigo torna o local aonde a "bolinha" do slide esta correspondente ao seu valor atual.
		if (Application.loadedLevel == 3){
			float ValorAtualTransp = GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia;
			GameObject.Find("SlideDaTransparencia").GetComponent<Slider>().value = ValorAtualTransp;
			float ValorAtualMusica = GameObject.Find("GameControl").GetComponent<GameControl>().ValorMusica;
			GameObject.Find("VolMusica").GetComponent<Slider>().value = ValorAtualMusica;

		}
	}
}
