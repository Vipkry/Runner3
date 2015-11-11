using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControlTransp : MonoBehaviour {

	public void PegaValor () {
		//Pega o valor do slider e manda para o GameControl para que possa ser exibido na tela e eventualmente
		//salvo para ser utilizado no jogo
		float ValTransparencia = GameObject.Find("Canvas/Transparencia/SlideDaTransparencia").GetComponent<Slider>().value;
		GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia = ValTransparencia;

	
	}
}
