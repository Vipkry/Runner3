using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicText : MonoBehaviour {

	Text porcentagem;
	//Exibe o texto da porcentagem atual da transparencia
	void Update(){
		float ValMusica = GameObject.Find("GameControl").GetComponent<GameControl>().ValorMusica;
		porcentagem = GetComponent<Text>();
		ValMusica =  Mathf.Round(ValMusica*100);
		porcentagem.text = ValMusica + "%";
	}
}
