using UnityEngine;
using System.Collections;

public class CarregaCena : MonoBehaviour {
	public string Cena = "EmJogo";

	public void Iniciador(){
		Application.LoadLevel (Cena);
	}
}
