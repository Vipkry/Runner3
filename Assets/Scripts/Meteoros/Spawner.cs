using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    // Esse código vai no GO onde queremos spawnar as coisas
    public GameObject[] meteoros;
    public Transform[] transformsDasPistas;
    public Transform transformMeteorCollector;
    public float delayTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(delay());
        if (delayTime == 0)
        {
            delayTime = 2f;
        }
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayTime);

        multiplos(4);

        StartCoroutine(delay());
    }


    // Cria multiplos asteróides um atrás do outro, na quantidade desejada
    void multiplos(int quantidade)
    {
        // Seleciona a pista em que vai ser spawnado o meteoro aleatoriamente
        int pistaSelecionada = Random.Range(0, transformsDasPistas.Length);
        Transform transformPistaSelecionada = transformsDasPistas[pistaSelecionada];

        // Stack para botar um em cima do outro, de acordo com o tamanho de cada um
        float stackTamanho = 0;

        for (int i = 0; i < quantidade; i++)
        {
            // Instancia o novo meteoro
            GameObject novoMeteoro = Instantiate(meteoros[Random.Range(0, meteoros.Length)]);
            // Pega o renderer dele, para conseguir a altura
            Renderer novoRenderer = novoMeteoro.GetComponent<Renderer>();
            // Usa o temp para posicionar o novo meteoro em cima do anterior
            Vector3 temp = new Vector3(transformPistaSelecionada.position.x, transform.position.y + stackTamanho, transform.position.z);
            novoMeteoro.transform.position = temp;
            // Aumenta o stack pro próximo meteoro
            stackTamanho += novoRenderer.bounds.size.y;

        }

    }
}
