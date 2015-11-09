using UnityEngine;
using System.Collections;

public class SaveSettings : MonoBehaviour {

	// Use this for initialization
	//Apenas chama a funçao SaveSettings que esta no GameControl
	public void AjudanteDoSave(){
		GameControl.controleGeral.SaveSettings();
	}
}
