using UnityEngine;
using System.Collections;

public class DontDestroyPLS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Evita que o objeto em que esta fixado seja destruido. Criado para o som do click dos botoes funcionar
		DontDestroyOnLoad(gameObject);
	}

}
