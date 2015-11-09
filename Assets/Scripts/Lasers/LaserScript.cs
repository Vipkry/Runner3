using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	
    void OnTriggerEnter2D (Collider2D target) {

        GameObject targetGO = target.gameObject;
        
        // Layer 11 é a layer do meteoro
        if (targetGO.layer == 11) {

            Destroy(targetGO);

        }

        Destroy(gameObject);

    }


}
