using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private MovimentoDoPlayer movimentoDoPlayerScript;
    private Renderer playerRenderer;
    public GameObject tiroAzulPreFab;
    public GameObject tiroVermelhoPreFab;
    public GameObject tiroAmareloPreFab;
    public GameObject tiroCinzaPreFab;
    public GameObject tiroTransparentePreFab;
    private GameObject tiroAtual;

    public string corDoTiroAtual;
    public float speed;
    private float speedDeltaTime;
    private bool jaAtirou;

    // Use this for initialization
    void Start()
    {
        // Pega o objeto do outro script
        movimentoDoPlayerScript = GetComponent<MovimentoDoPlayer>();
        // Pega o objeto do Renderer
        playerRenderer = GetComponent<Renderer>();
        corDoTiroAtual = "Azul";
    }

    // Update is called once per frame
    void Update()
    {
        CorDoTiro();
        speedDeltaTime = speed * Time.deltaTime;

        // Mesmo esquema dos meteoros. Instancia o game object, pega transform e rigidbody, empurra ele e pronto
        // Só é ativado caso o identificadorDeSwipe do outro scirpt for zero, que significa apenas um toque na tela
        if (movimentoDoPlayerScript.identificadorDeSwipe == 0)
        {
            Atira();
        }

    }

    private void CorDoTiro()
    {

        if (corDoTiroAtual == "Azul")
        {

            tiroAtual = tiroAzulPreFab;

        }
        else if (corDoTiroAtual == "Amarelo")
        {

            tiroAtual = tiroAmareloPreFab;

        }
        else if (corDoTiroAtual == "Vermelho")
        {

            tiroAtual = tiroVermelhoPreFab;

        }
        else if (corDoTiroAtual == "Cinza")
        {

            tiroAtual = tiroCinzaPreFab;
        }

    }

    private void Atira()
    {

        // Tiros normais
        GameObject novoTiro = Instantiate(tiroAtual);
        GameObject novoTiro2 = Instantiate(tiroAtual);


        Transform novoTiroTransform = novoTiro.GetComponent<Transform>();
        Transform novoTiroTransform2 = novoTiro2.GetComponent<Transform>();

        Rigidbody2D novoTiroRigidbody = novoTiro.GetComponent<Rigidbody2D>();
        Rigidbody2D novoTiroRigidbody2 = novoTiro2.GetComponent<Rigidbody2D>();


        // Esquerda 
        novoTiroTransform.position = new Vector3(playerRenderer.bounds.center.x - playerRenderer.bounds.extents.x / transform.localScale.x, playerRenderer.bounds.center.y + playerRenderer.bounds.extents.y, transform.position.z);
        // Direita
        novoTiroTransform2.position = new Vector3(playerRenderer.bounds.center.x + playerRenderer.bounds.extents.x / transform.localScale.x, playerRenderer.bounds.center.y + playerRenderer.bounds.extents.y, transform.position.z);

        novoTiroRigidbody.AddForce(new Vector2(0, speedDeltaTime));
        novoTiroRigidbody2.AddForce(new Vector2(0, speedDeltaTime));

    }
}
