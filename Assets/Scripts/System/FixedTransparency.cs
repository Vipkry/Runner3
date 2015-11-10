using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FixedTransparency : MonoBehaviour 
	{
	//Este script controla a transparencia das sprites(criado para o HUD)
	// transparencia, 0 = 100% transparente , 0.3 = 70% transparente, 0.5 = 50% transparente, 1 = 0% transparente
	public float transparencia;

	void Start(){
		Image imagem = GetComponent<Image>();
		imagem.color = new Color(255f, 255f, 100f, transparencia);
	}
	
	}