using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControlMusic : MonoBehaviour {

	public void PegaValor () {
		//Pega o valor do slider e manda para o GameControl para que possa ser exibido na tela e eventualmente
		//salvo para ser utilizado no jogo
		float ValMusica = GameObject.Find("Canvas/VolumeMusica/VolMusica").GetComponent<Slider>().value;
		GameObject.Find("GameControl").GetComponent<GameControl>().ValorMusica = ValMusica;
		
		
	}
}
