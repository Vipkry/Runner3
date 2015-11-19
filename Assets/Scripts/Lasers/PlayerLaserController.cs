using UnityEngine;
using System.Collections;

public class PlayerLaserController : MonoBehaviour
{

    private MovimentoDoPlayer movimentoDoPlayerScript;
    private Renderer playerRenderer;
    public GameObject tiroAzulPreFab;
    public GameObject tiroVermelhoPreFab;
    public GameObject tiroAmareloPreFab;
    public GameObject tiroCinzaPreFab;
    public GameObject tiroTransparentePreFab;
    
    public string corDoTiroAtual;
    public float laserForce;
    public bool podeAtirar;
    private bool recarregou;


    // Use this for initialization
    void Start()
    {
        recarregou = true;
        setPodeAtirar(true);
        // Pega o objeto do outro script
        movimentoDoPlayerScript = GetComponent<MovimentoDoPlayer>();
        
        corDoTiroAtual = "Amarelo";
    }

    // Update is called once per frame
    void Update()
    {

        // Mesmo esquema dos meteoros. Instancia o game object, pega transform e rigidbody, empurra ele e pronto
        // Só é ativado caso o identificadorDeSwipe do outro scirpt for zero, que significa apenas um toque na tela
        if (movimentoDoPlayerScript.identificadorDeSwipe == 0 && podeAtirar && recarregou)
        {
            setPodeAtirar(false);
            AtiraLaserTransparente();
        }

    }

    void AtiraLaserTransparente() {

            StartCoroutine(reloadDelay());    

            Renderer playerRenderer = GetComponent<Renderer>();

            GameObject novoTiroTransparente = Instantiate(tiroTransparentePreFab);

            novoTiroTransparente.transform.position = new Vector3(playerRenderer.bounds.center.x, playerRenderer.bounds.center.y + playerRenderer.bounds.extents.y, transform.position.z);

        
    }

    public void setPodeAtirar(bool boolean) {

        podeAtirar = boolean;



    }

    IEnumerator reloadDelay() {

        recarregou = false;

        yield return new WaitForSeconds(2f);

        recarregou = true;

    }
    
}
