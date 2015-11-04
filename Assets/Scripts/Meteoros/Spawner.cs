using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    // Esse código vai no GO onde queremos spawnar as coisas
    public GameObject[] meteoros;
    public Transform[] transformsDasPistas;
    public Transform transformMeteorCollector;
    public float delayTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(delay());
        if (delayTime == 0) {
            delayTime = 2f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator delay() {
        yield return new WaitForSeconds(delayTime);
        // Seleciona a pista em que vai ser spawnado o meteoro aleatoriamente (NÃO DEIXAR ASSIM, FAZER FUNÇÕES COM ORDEM DE OBSTÁCULOS PRÉ DEFINIDOS, ISSO É SÓ UM TESTE)
        Transform transformPistaSelecionada = transformsDasPistas[Random.Range(0, transformsDasPistas.Length)];
        // Faz o mesmo com os meteoros
        GameObject novoMeteoro = Instantiate(meteoros[Random.Range(0, meteoros.Length)]);
        // Posiciona o meteoro na posição x da pista mas y do spawner
        Vector3 temp = new Vector3(transformPistaSelecionada.position.x, transform.position.y, transform.position.z);
        novoMeteoro.transform.position = temp;
                 
        StartCoroutine(delay());
    }
}
