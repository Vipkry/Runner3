using UnityEngine;
using System.Collections;

public class Rotacao : MonoBehaviour {
	public int Maximo = 5;
	public int Minimo = 1;
	private float rotationUpdate = 0f;
	private float rotation = 0f;

	// Use this for initialization
	void Start () {
		Maximo = Maximo + 1;
		rotationUpdate = Random.Range(Minimo, Maximo); 
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine("Rotacionador");
		//rotation = rotation + rotationUpdate;
		//transform.rotation = Quaternion.AngleAxis(30, Vector3.forward);

	}
	
	IEnumerator Rotacionador(){
		rotation = rotation + rotationUpdate;
		transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
		yield return new WaitForSeconds(1f);
	}
}
