using UnityEngine;
using System.Collections;

public class MovimentoDoFundo : MonoBehaviour {
	public float velocidade = 0.1f;
	public bool ativador = true;
	public float posYFinal = -20.79f;
	public float posYInicial = 20.81f;
	public float posZ = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ativador == true){
			ativador = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -velocidade));
		}
		
		if (transform.position.y < posYFinal){

			transform.position = new Vector3(transform.position.x,posYInicial,posZ);
		}
		//float posX = transform.position.x;
		//float posY = transform.position.y;
		//Debug.Log(posX + "," + posY);

	}
}
