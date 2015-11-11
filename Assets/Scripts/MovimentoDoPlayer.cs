using UnityEngine;
using System.Collections;

public class MovimentoDoPlayer : MonoBehaviour
{
    public GameObject[] pistasEmOrdem;
    private Rigidbody2D playerRigidibody;
    private GameObject pistaAtual;
    public Renderer spaceRoadRenderer;
    public GameObject pauseSystem;

    // Força do "pulo" que a nave dá de uma pista pra outra. Isso vai afetar a velocidade com que isso acontece
    public float forcaPulo;
    private float forcaPuloDeltaTime;
    public bool pulandoParaDireita;
    public bool pulandoParaEsquerda;
    private int numeroDaPistaNaArray;
    private int framesDelay;
    private Vector2 posicao1 = new Vector2(0f, 0f);
    private int swipe = -1;
    private bool mouseButtonDownDentroDaPista;
    private bool estaPausado;

    public int identificadorDeSwipe;

    // Use this for initialization
    void Start()
    {
        identificadorDeSwipe = -1;
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

        // Vai evitar o bug de atirar ou mudar de pista enquanto estiver no menu de pausa
        estaPausado = pauseSystem.GetComponent<PauseSystem>().estaPausado;
        if (!estaPausado)
        {
            SwipeDetec();
        }
        // Atualizar sempre para -1, para indicar que nada foi apertado/ ainda está sendo apertado
        // Isso vai evitar que o identificador "estacione" em um valor apenas
        identificadorDeSwipe = -1;
        // Só altera o identificador de swipe quando tira o dedo / mouse
        // Isso serve pra não dar update todo frame, conseguindo manipular outras funções apropriadamente
        if (Input.GetMouseButtonUp(0))
        {
            identificadorDeSwipe = swipe;
        }
        // Estou chamando apenas o movimentoPC pq testei no celular e ele funciona tambem, entao talvez seja melhor usar
        // so ele, uma vez que ele funciona para os dois
        movimentoPC();

    }

    // Faz o movimento do player pelo mouse, servira mais para proposito de teste, para nao precisar o celular sempre
    void movimentoPC()
    {
        // Verifica se o botao foi apertado antes de executar o codigo
        if (identificadorDeSwipe != -1)
        {
            //Vector3 posicaoMouseAtual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!pulandoParaDireita && !pulandoParaEsquerda)
            {
                //identificadorDeSwipe = 1 significa um swipe para a direita
                if (identificadorDeSwipe == 1 && numeroDaPistaNaArray != pistasEmOrdem.Length - 1)
                {
                    numeroDaPistaNaArray += 1;
                    pulandoParaDireita = true;
                }
                //identificadorDeSwipe = 2 significa um swipe para a esquerda
                else if (identificadorDeSwipe == 2 && numeroDaPistaNaArray != 0)
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
        // É importante que a pista atual seja declarada só aqui, pro player não ficar 'preso' em uma só
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
    private Vector2 POSAtual()
    {
        Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos1 = new Vector2(posMouse.x, posMouse.y);
        return pos1;
    }

    // função serve para verificar se o touch/ mouse está em cima da pista para evitar bugs quando utilizar a hud
    private bool mouseEmCimaDaPista()
    {

        bool dentroDaPista = false;
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < spaceRoadRenderer.bounds.center.x + spaceRoadRenderer.bounds.extents.x && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > spaceRoadRenderer.bounds.center.x - spaceRoadRenderer.bounds.extents.x)
        {
            dentroDaPista = true;
        }
        return dentroDaPista;

    }

    public int SwipeDetec()
    {

        //Coloca o valor inicial do swipe, para caso ele seja alterado volte ao normal depois quando o codigo for
        //executado novamente
        swipe = -1;
        //Pega a posiçao de quando o botao e apertado(ou quando inicia-se o "touch")        
        if (Input.GetMouseButtonDown(0) && mouseEmCimaDaPista())
        {
            posicao1 = POSAtual();
            mouseButtonDownDentroDaPista = true;
        }
        //Pega a posiçao de quando solta-se o botao(ou quando termina-se o "touch")
        else if (Input.GetMouseButtonUp(0) && mouseButtonDownDentroDaPista)
        {
            mouseButtonDownDentroDaPista = false;
            // Swipe = 0 significa só um toque sem swipe
            swipe = 0;
            //Debug.Log("Soltou");
            Vector2 posicao2 = POSAtual();
            //Detecta se ocorreu um SWIPE(se deslizou)
            if (posicao1.x != posicao2.x)
            {
                //a diferença server para o script funcionar no celular, ja que as mediçoes nao sao precisas
                float diferenca = (posicao1.x - posicao2.x);
                if (posicao1.x < posicao2.x && diferenca < -1.5)
                {
                    //Debug.Log("Swipe para a Direita");
                    //Swipe = 1 significa um swipe para a direita
                    swipe = 1;
                }
                else if (posicao1.x > posicao2.x && diferenca > 1.5)
                {
                    //Debug.Log("Swipe para a Esquerda");
                    //Swipe = 2 significa um swipe para a esquerda
                    swipe = 2;
                }
            }
        }

        return swipe;
    }


}
