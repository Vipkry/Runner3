using UnityEngine;
using System.Collections;

public class MovimentoDoPlayer : MonoBehaviour
{
    public GameObject[] pistasEmOrdem;
    private Rigidbody2D playerRigidibody;
    private GameObject pistaAtual;

    // Força do "pulo" que a nave dá de uma pista pra outra. Isso vai afetar a velocidade com que isso acontece
    public float forcaPulo;
    private float forcaPuloDeltaTime;
    private bool pulandoParaDireita;
    private bool pulandoParaEsquerda;
    private int numeroDaPistaNaArray;
    private int framesDelay;

    // Use this for initialization
    void Start()
    {
        framesDelay = 0;
        numeroDaPistaNaArray = 1;
        pistaAtual = pistasEmOrdem[numeroDaPistaNaArray];
        pulandoParaDireita = false;
        pulandoParaEsquerda = false;
        playerRigidibody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        forcaPuloDeltaTime = forcaPulo * Time.deltaTime;
        // Estou chamando apenas o movimentoPC pq testei no celular e ele funciona tambem, entao talvez seja melhor usar
        // so ele, uma vez que ele funciona para os dois
        movimentoPC();
        // movimentoMobile();

    }

    // Faz o movimento do player pelo mouse, servira mais para proposito de teste, para nao precisar o celular sempre
    void movimentoPC()
    {
        // Verifica se o botao foi apertado antes de executar o codigo
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posicaoMouseAtual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 posicaoPlayerAtual = transform.position;
            if (!pulandoParaDireita && !pulandoParaEsquerda)
            {

                if (posicaoMouseAtual.x > 0 && numeroDaPistaNaArray != pistasEmOrdem.Length - 1)
                {
                    numeroDaPistaNaArray += 1;
                    pulandoParaDireita = true;
                }
                else if (posicaoMouseAtual.x < 0 && numeroDaPistaNaArray != 0)
                {
                    numeroDaPistaNaArray -= 1;
                    pulandoParaEsquerda = true;
                }
            }
        }

        // Aqui ele vai aplicar a força pro player se mexer
        if (pulandoParaEsquerda)
        {
            playerRigidibody.AddForce(new Vector2(-forcaPuloDeltaTime, 0));
        }
        // Aqui ele vai aplicar a força pro player se mexer, na direção contrária
        else if (pulandoParaDireita)
        {
            playerRigidibody.AddForce(new Vector2(forcaPuloDeltaTime, 0));
        }


        // Aqui ele vai ver se o player já chegou na pista certa. Se já, o player vai ter passado um pouco de onde ele devia estar
        // O vetor temp vai ser criado pra ajeitar isso pegando a posição x da pista e botando o player lá de volta no mesmo frame
        // É importanto que a pista atual seja declarada só aqui, pro player não ficar 'preso' em uma só
        if (pulandoParaEsquerda && transform.position.x < pistasEmOrdem[numeroDaPistaNaArray].transform.position.x)
        {
            pistaAtual = pistasEmOrdem[numeroDaPistaNaArray];
            Vector3 temp = new Vector3(pistaAtual.transform.position.x, transform.position.y, transform.position.z);
            pulandoParaEsquerda = false;
            transform.position = temp;
            framesDelay = 5;

        }
        else if (pulandoParaDireita && transform.position.x > pistasEmOrdem[numeroDaPistaNaArray].transform.position.x)
        {
            pistaAtual = pistasEmOrdem[numeroDaPistaNaArray];
            Vector3 temp = new Vector3(pistaAtual.transform.position.x, transform.position.y, transform.position.z);
            pulandoParaDireita = false;
            transform.position = temp;
            framesDelay = 5;

        }

        // Esse if é para posicionar a nave de novo na pista por algum mínimo tempo. Serve para a nave não andar um pouquinho depois de chegar na pista
        if (framesDelay > 0)
        {
            Vector3 temp = new Vector3(pistaAtual.transform.position.x, transform.position.y, transform.position.z);
            transform.position = temp;
            framesDelay -= 1;
        }


    }
    /**void movimentoMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch inputDoUsuario = Input.GetTouch(0);
            if (inputDoUsuario.phase == TouchPhase.Began)
            {
                Vector2 posicaoMouseAtual = Camera.main.ScreenToWorldPoint(new Vector2(inputDoUsuario.position.x, inputDoUsuario.position.y));
                Vector2 posicaoPlayerAtual = transform.position;
                if (posicaoMouseAtual.x > 0 && posicaoPlayerAtual.x < limite)
                {
                    posicaoPlayerAtual.x += tamanhoDoSetor;
                    transform.position = posicaoPlayerAtual;
                }
                else if (posicaoMouseAtual.x < 0 && posicaoPlayerAtual.x > -limite)
                {
                    posicaoPlayerAtual.x -= tamanhoDoSetor;
                    transform.position = posicaoPlayerAtual;
                }
            }

        }
    }**/
}
