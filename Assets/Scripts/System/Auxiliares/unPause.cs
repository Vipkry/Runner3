using UnityEngine;
using System.Collections;

public class unPause : MonoBehaviour {

	public GameObject PainelPause;	

	public void Resumer(){

	
		PainelPause.SetActive(false);
		Time.timeScale = 1;
	}
}
