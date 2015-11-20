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
		//Utilizei um loop infinito para a coroutine ficar sendo chamada infinitamente, e sendo chamada apenas quando
		// ela termina, pois se eu colocasse ela no Update() ela ficaria sendo chamada sempre uma em cima da outra
		while (true){
			yield return new WaitForSeconds(segs);
			//Soma a pontuaçao atual o valor definido de pontos
			pontos += valorPeriodico;
		}
	}
	public void AdicionaPontos(){
		pontos += recompensa;
	}
}
