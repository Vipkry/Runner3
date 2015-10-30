using UnityEngine;
using System.Collections;

public class Transparencia : MonoBehaviour {
	//Este script controla a transparencia das sprites(criado para o HUD)
	// transparencia, 0 = 100% transparente , 0.3 = 70% transparente, 0.5 = 50% transparente, 1 = 0% transparente
	public float transparencia = 0.3f;

	// Use this for initialization
	void Start () {
		SpriteRenderer renderizador =  GetComponent<SpriteRenderer>();
		renderizador.color = new Color(1f,1f,1f,transparencia);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
