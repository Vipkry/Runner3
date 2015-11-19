using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    // Esse código vai no GO onde queremos spawnar as coisas
    public GameObject[] meteoros;
    public Transform[] transformsDasPistas;
    public Transform transformMeteorCollector;
    private GameObject ultimoMeteoro;
    private MovimentoDosMeteoros ultimoMeteoroMovimentoScript;

    public float delayTime;
    private int ultimoPadrao;
    // Stack para botar um em cima do outro, de acordo com o tamanho de cada um
    float stackTamanho;

    // Use this for initialization
    void Start()
    {

        stackTamanho = 0;

        if (delayTime == 0)
        {
            delayTime = 2f;
        }

        Padrao1();

    }

    void Update()
    {

        ultimoMeteoroMovimentoScript = ultimoMeteoro.GetComponent<MovimentoDosMeteoros>();


        if (ultimoMeteoroMovimentoScript.atingiuOLaserCollector)
        {
            PadraoRandom();
        }

    }


    // Cria multiplos asteróides um atrás do outro, na quantidade desejada e na vertical
    void multiplosVerticais(int quantidade, int pista, bool horizontal = false)
    {
        // Seleciona a pista em que vai ser spawnado o meteoro aleatoriamente
        Transform transformPistaSelecionada = transformsDasPistas[pista - 1];

        for (int i = 0; i < quantidade; i++)
        {
            // Instancia o novo meteoro
            GameObject novoMeteoro = Instantiate(meteoros[Random.Range(0, meteoros.Length)]);
            // Pega o renderer dele, para conseguir a altura
            Renderer novoRenderer = novoMeteoro.GetComponent<Renderer>();
            // Usa o temp para posicionar o novo meteoro em cima do anterior
            Vector3 temp = new Vector3(transformPistaSelecionada.position.x, transform.position.y + stackTamanho + 6f, transform.position.z);
            novoMeteoro.transform.position = temp;
            // Aumenta o stack pro próximo meteoro
            stackTamanho += horizontal ? 0 : novoRenderer.bounds.size.y;

            if (i == quantidade - 1)
            {

                ultimoMeteoro = novoMeteoro;
                MovimentoDosMeteoros ultimoMeteoroScript = ultimoMeteoro.GetComponent<MovimentoDosMeteoros>();
                ultimoMeteoroScript.ultimoMeteoro = true;
            }

        }


    }

    void multiplosHorizontais(int quantidadeVerticais, bool pista1 = false, bool pista2 = false, bool pista3 = false)
    {


        for (int i = 0; i < quantidadeVerticais; i++)
        {

            if (pista1)
            {

                multiplosVerticais(1, 1, true);

            }
            if (pista2)
            {

                multiplosVerticais(1, 2, true);

            }
            if (pista3)
            {

                multiplosVerticais(1, 3, true);

            }
            Renderer ultimoMeteoroRenderer = ultimoMeteoro.GetComponent<Renderer>();
            stackTamanho += ultimoMeteoroRenderer.bounds.size.y;
        }

    }

    // Adiciona a quantidade de espaços desejada no stack tamanho para ajuda na elaboração dos padrões
    void espaco(float quantidade)
    {

        Renderer ultimoMeteoroRenderer = ultimoMeteoro.GetComponent<Renderer>();
        float espacoAdd = ultimoMeteoroRenderer.bounds.size.y;
        espacoAdd *= quantidade;
        stackTamanho += espacoAdd;
    }

    private void Padrao1()
    {


        int random1 = Random.Range(1, 4);
        multiplosVerticais(2, random1);
        multiplosVerticais(2, 2);
        int random2;

        if (random1 == 2)
        {

            random2 = Random.Range(1, 4);
            if (random2 == 2)
            {
                int randomAux = Random.Range(0, 100);
                random2 = randomAux > 50 ? 3 : 1;
            }

        }
        else
        {

            random2 = random1;

        }

        multiplosVerticais(2, random2);


        int random3 = random2 == 1 ? 3 : 1;

        multiplosVerticais(2, random3);


    }

    private void Padrao2()
    {


        int random1 = Random.Range(0, 100);
        if (random1 >= 50)
        {

            multiplosHorizontais(1, false, true, true);
            multiplosVerticais(4, 2);
            multiplosHorizontais(1, false, true, true);

        }
        else
        {

            multiplosHorizontais(1, true, true, false);
            multiplosVerticais(4, 2);
            multiplosHorizontais(1, true, true, false);
        }
    }

    private void Padrao3()
    {


        int random1 = Random.Range(0, 100);
        if (random1 >= 50)
        {

            multiplosVerticais(1, 3);
            multiplosVerticais(1, 2);
            multiplosVerticais(1, 3);
            multiplosVerticais(1, 2);
            multiplosVerticais(2, 3);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(2, 3);
            multiplosVerticais(3, 2);


        }
        else
        {

            multiplosVerticais(1, 1);
            multiplosVerticais(1, 2);
            multiplosVerticais(1, 1);
            multiplosVerticais(1, 2);
            multiplosVerticais(2, 1);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(2, 1);
            multiplosVerticais(3, 2);

        }

    }

    private void Padrao4()
    {

        stackTamanho = 0;
        multiplosHorizontais(2, true, false, true);
        espaco(2);
        multiplosHorizontais(1, true, false, true);
        espaco(1);
        multiplosVerticais(2, 2);
        espaco(1);
        multiplosHorizontais(1, true, true, true);
        espaco(2);
        multiplosVerticais(1, 2);


    }

    private void Padrao5()
    {



        int randomDireitaOuEsquerda = Random.Range(0, 100);
        if (randomDireitaOuEsquerda >= 50)
        {

            multiplosHorizontais(2, false, true, true);
            multiplosVerticais(2, 3);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(2, 1);
            multiplosVerticais(3, 2);
            multiplosVerticais(2, 1);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(1, 3);

        }
        else
        {

            multiplosHorizontais(2, true, true, false);
            multiplosVerticais(2, 1);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(2, 3);
            multiplosVerticais(3, 2);
            multiplosVerticais(2, 3);
            multiplosHorizontais(2, true, false, true);
            multiplosVerticais(1, 1);

        }

    }

    private void Padrao6()
    {


        int randomNumeroDeLinhas = Random.Range(4, 10);

        for (int i = 0; i < randomNumeroDeLinhas; i++)
        {

            int randomDireitaOuEsquerda = Random.Range(0, 100);

            int randomAux = Random.Range(1, 5);

            // Esse if dificulta que o rendomAux fique com número 4, mas não o impede
            if (randomAux == 4)
            {

                randomAux = Random.Range(1, 5);

            }

            // Vai posicionar na direita ou na esquerda da pista os meteoros
            if (randomDireitaOuEsquerda >= 50)
            {

                multiplosHorizontais(randomAux, false, true, true);

            }
            else
            {

                multiplosHorizontais(randomAux, true, true, false);

            }

            espaco(3);

        }

    }

    private void PadraoRandom()
    {

        stackTamanho = 0;
        int random = Random.Range(1, 7);

        if (random == 1 && ultimoPadrao != 1)
        {
            Padrao1();
        }
        else if (random == 2 && ultimoPadrao != 2)
        {
            Padrao2();
        }
        else if (random == 3 && ultimoPadrao != 3)
        {
            Padrao3();
        }
        else if (random == 4 && ultimoPadrao != 4)
        {
            Padrao4();
        }
        else if (random == 5 && ultimoPadrao != 5)
        {
            Padrao5();
        }
        else if (random == 6 && ultimoPadrao != 6)
        {
            Padrao6();
        }else {
            PadraoRandom();

        }

    }


}
