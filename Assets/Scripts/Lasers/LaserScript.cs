using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{

    private PlayerLaserController playerLaserContollerScript;
    private GameObject player;
    private Renderer playerRenderer;
    private GameObject tiroAtual;

    private GameObject novoTiro;
    private GameObject novoTiro2;

    private float laserForce;
    private float laserForceDeltaTime;

    void Start()
    {
        
        // Pega o objeto do player
        player = GameObject.FindGameObjectWithTag("Player");
        // Pega o objeto do playerLaserControllerScript
        playerLaserContollerScript = player.GetComponent<PlayerLaserController>();
        // Pega a força do tiro
        laserForce = playerLaserContollerScript.laserForce;
        // Pega o objeto do Renderer do player
        playerRenderer = player.GetComponent<Renderer>();
        // Muda a cor do tiro se necessário
        CorDoTiro();
        // Atira
        Atira();      

    }

    void Update() {
        
        // Multiplica por delta time para permanecer igual em todos os dispositivos
        laserForceDeltaTime = laserForce * Time.deltaTime;
        // Essa é a movimentação dele. Não usei Rigidbody2D.AddForce() Pois o mesmo leva um tempo no disparo
        transform.position = new Vector3(transform.position.x, transform.position.y + laserForceDeltaTime, transform.position.z);
        // Faz os sprites acompanharem
        novoTiro.transform.position = new Vector3(novoTiro.transform.position.x, transform.position.y, novoTiro.transform.position.z);
        novoTiro2.transform.position = new Vector3(novoTiro2.transform.position.x, transform.position.y, novoTiro2.transform.position.z);


    }

    void OnTriggerEnter2D(Collider2D target)
    {

        // Faz com que o player possa atirar de novo
        playerLaserContollerScript.setPodeAtirar(true);

        GameObject targetGO = target.gameObject;

        // Layer 11 é a layer do meteoro
        if (targetGO.layer == 11)
        {
            // Destrói o meteoro
            Destroy(targetGO);

        }

        Destroy(novoTiro);
        Destroy(novoTiro2);

        // Destrói o controlador do tiro
        Destroy(gameObject);
        
    }    

    private void CorDoTiro()
    {

        if (playerLaserContollerScript.corDoTiroAtual == "Azul")
        {

            tiroAtual = playerLaserContollerScript.tiroAzulPreFab;

        }
        else if (playerLaserContollerScript.corDoTiroAtual == "Amarelo")
        {

            tiroAtual = playerLaserContollerScript.tiroAmareloPreFab;

        }
        else if (playerLaserContollerScript.corDoTiroAtual == "Vermelho")
        {

            tiroAtual = playerLaserContollerScript.tiroVermelhoPreFab;

        }
        else if (playerLaserContollerScript.corDoTiroAtual == "Cinza")
        {

            tiroAtual = playerLaserContollerScript.tiroCinzaPreFab;
        }

    }

    private void Atira()
    {

        // Tiros normais
        novoTiro = Instantiate(tiroAtual);
        novoTiro2 = Instantiate(tiroAtual);


        Transform novoTiroTransform = novoTiro.GetComponent<Transform>();
        Transform novoTiroTransform2 = novoTiro2.GetComponent<Transform>();

        // Esquerda 
        novoTiroTransform.position = new Vector3(playerRenderer.bounds.center.x - playerRenderer.bounds.extents.x * 3/4 , playerRenderer.bounds.center.y + playerRenderer.bounds.extents.y, transform.position.z);
        // Direita
        novoTiroTransform2.position = new Vector3(playerRenderer.bounds.center.x + playerRenderer.bounds.extents.x * 3/4, playerRenderer.bounds.center.y + playerRenderer.bounds.extents.y, transform.position.z);        

    }
}
