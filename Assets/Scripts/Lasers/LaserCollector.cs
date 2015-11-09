using UnityEngine;
using System.Collections;

public class LaserCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target) {

        
        GameObject targetGO = target.gameObject;

        // Layer 9 é a layer do laser
        if (targetGO.layer == 9) {

            Destroy(targetGO);

        }

        

    }
}
