using UnityEngine;
using System.Collections;

public class MovimentoDoFundo : MonoBehaviour {
	public float velocidade = 0.1f;
	public bool ativador = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ativador == true){
			ativador = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -velocidade));
		}

		if (transform.position.y < -10.79f){

			transform.position = new Vector3(transform.position.x,10.81f,2);
		}
		//float posX = transform.position.x;
		//float posY = transform.position.y;
		//Debug.Log(posX + "," + posY);

	}
}
