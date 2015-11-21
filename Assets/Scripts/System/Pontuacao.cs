using UnityEngine;
using System.Collections;

public class Pontuacao : MonoBehaviour {

	public int pontos;
	public int valorPeriodico;
	public float segundos;
	// !!POSTERIORMENTE SERA PUXADA DO GAMECONTROL, QUE CONTERA DADOS SALVOS SOBRE ESSE VALOR!!
	// Valor somado a pontuacao quando um meteoro(ou obstaculo) e destruido
	public int recompensa;

	// Use this for initialization
	void Start () {
		StartCoroutine(AdicionaPontosPeriodicamente(segundos));
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	IEnumerator AdicionaPontosPeriodicamente(float segs){
		
			yield return new WaitForSeconds(segs);
			//Soma a pontuaçao atual o valor definido de pontos
			pontos += valorPeriodico;
            StartCoroutine(AdicionaPontosPeriodicamente(segundos));
		
	}
	public void AdicionaPontos(){
		pontos += recompensa;
	}
}
