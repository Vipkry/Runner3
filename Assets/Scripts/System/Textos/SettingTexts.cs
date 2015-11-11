using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingTexts : MonoBehaviour {

	Text porcentagem;
	//Exibe o texto da porcentagem atual da transparencia
	void Update(){
		float ValTransparencia = GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia;
		porcentagem = GetComponent<Text>();
		ValTransparencia =  Mathf.Round(ValTransparencia*100);
		porcentagem.text = ValTransparencia + "%";
	}
}
