using UnityEngine;
using System.Collections;

public class Perdeu : MonoBehaviour {

	public GameObject PainelFim;
	public GameObject HighScoreText;
	public int MaiorPts;
	public int AtualPts;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void FimDeJogo(){
		Time.timeScale = 0;
		GameObject.Find("GameControl").GetComponent<GameControl>().LoadInfo();
		MaiorPts =  GameObject.Find("GameControl").GetComponent<GameControl>().MaiorPontuacao;
		AtualPts =  GameObject.Find("GameControl").GetComponent<Pontuacao>().pontos;
		PainelFim.SetActive(true);
		if( AtualPts > MaiorPts ) 
		{

			GameObject.Find("GameControl").GetComponent<GameControl>().MaiorPontuacao = AtualPts;
			GameObject.Find("GameControl").GetComponent<GameControl>().SaveInfo();
			HighScoreText.SetActive(true);
		}



	}
}
