using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject PainelPause;

	public void Pauser(){
		Time.timeScale = 0;
		PainelPause.SetActive(true);
	}
}
