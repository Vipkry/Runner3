using UnityEngine;
using System.Collections;

public class MovimentoDosMeteoros : MonoBehaviour {

    //private Transform meteorTransform;
    private Rigidbody2D meteorRigidbody;

    public float force;
    private float forceDeltaTime;
	// Use this for initialization
	void Start () {

        meteorRigidbody = GetComponent<Rigidbody2D>();
       // meteorTransform = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        forceDeltaTime = force * Time.deltaTime;
        meteorRigidbody.AddForce(new Vector2(0,-forceDeltaTime));
	}
}
