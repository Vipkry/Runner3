using UnityEngine;
using System.Collections;

public class MovimentoDosMeteoros : MonoBehaviour {

    
    private Rigidbody2D meteorRigidbody;
    

    public float force;
    private float forceDeltaTime;
	// Use this for initialization
	void Start () {

        meteorRigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        forceDeltaTime = force * Time.deltaTime;
        meteorRigidbody.AddForce(new Vector2(0,-forceDeltaTime));

	}
}
