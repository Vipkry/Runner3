﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextoPontuacao : MonoBehaviour {

	Text pontuacaoAtual;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int ptsAtual = GameObject.Find("GameControl").GetComponent<Pontuacao>().pontos;
		pontuacaoAtual = GetComponent<Text>();
		pontuacaoAtual.text ="Points: " + ptsAtual;
	
	}
}
