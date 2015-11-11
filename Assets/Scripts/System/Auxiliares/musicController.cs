using UnityEngine;
using System.Collections;

public class musicController : MonoBehaviour {

	public AudioClip[] musicas;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		//Pega o valor salvo anteriormente para o volume e coloca no AudioSource da musica
		float musicVolume = GameObject.Find("GameControl").GetComponent<GameControl>().ValorMusica;
		audio.volume = musicVolume;


	}
	
	// Update is called once per frame
	void Update () {
		//Destroi o AudioSource se estiver na cena do jogo
		if (Application.loadedLevel == 1){
			Destroy(gameObject);
		}
		//Verifica se nao tem nenhuma musica rodando atualmente, se nao tiver executa uma
		if(!audio.isPlaying ){
			MusicSelector();
		}
		float musicVolumeAtual = GameObject.Find("GameControl").GetComponent<GameControl>().ValorMusica;
		if (audio.volume != musicVolumeAtual){
			audio.volume = musicVolumeAtual;
		}
		DestruidorMtNervosao();
	
	}
	//Seleciona uma musica aleatoria dentro da lista de 4 elementos
	public void MusicSelector(){
		int atual = Random.Range(0, 4);
		audio.clip = musicas[atual];
		audio.Play();

	}
	//Destroi um dos AudioSources caso exista mais de um, impede que toque 2x a musica quando volta para a tela do menu
	public void DestruidorMtNervosao(){
		if ((GameObject.FindGameObjectsWithTag("Audio")).Length > 1){
			//Destroi o AudioSource na posicao 1 pois ele eh o que foi adicionado por ultimo, permitindo entao
			// que a musica continue rodando normalmente enquanto um deles eh destruido
			Destroy(GameObject.FindGameObjectsWithTag("Audio")[1]);

		}
	}

}
