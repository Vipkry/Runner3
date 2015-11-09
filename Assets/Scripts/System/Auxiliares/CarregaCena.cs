using UnityEngine;
using System.Collections;

public class CarregaCena : MonoBehaviour {
	public string Cena = "EmJogo";

	public void Iniciador(){
		//Carrega uma nova cena determinada
		Application.LoadLevel (Cena);
	}
}
