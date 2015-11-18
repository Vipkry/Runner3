using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{

    public string corAtual;

    // Todos os botões
    public GameObject botaoAzul;
    public GameObject botaoCinza;
    public GameObject botaoVermelho;
    public GameObject botaoAmarelo;

    // Todos os botões pressionados
    public GameObject botaoAzulPressionado;
    public GameObject botaoCinzaPressionado;
    public GameObject botaoVermelhoPressionado;
    public GameObject botaoAmareloPressionado;

    private SwitchScript ultimoBotaoSwitchScript;
    private GameObject ultimoBotaoPressionado;

    // Use this for initialization
    void Start()
    {
        // Deixa o botão azul como padrão
        ultimoBotaoPressionado = botaoAzulPressionado;
        ultimoBotaoPressionado.SetActive(true);
        corAtual = "Azul";

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void mudaUltimoBotao(string corDoBotao)
    {
        
        if (corDoBotao == "botaoAzul" && corAtual != "Azul")
        {
            ultimoBotaoPressionado.SetActive(false);
           // ultimoBotaoSwitchScript = botaoAzul.GetComponent<SwitchScript>();
            corAtual = "Azul";
            ultimoBotaoPressionado = botaoAzulPressionado;
        
        }
        else if (corDoBotao == "botaoCinza" && corAtual != "Cinza")
        {
            
            ultimoBotaoPressionado.SetActive(false);
            //ultimoBotaoSwitchScript = botaoCinza.GetComponent<SwitchScript>();
            corAtual = "Cinza";
            ultimoBotaoPressionado = botaoCinzaPressionado;
        }
        else if (corDoBotao == "botaoVermelho" && corAtual != "Vermelho")
        {
            ultimoBotaoPressionado.SetActive(false);
           // ultimoBotaoSwitchScript = botaoVermelho.GetComponent<SwitchScript>();
            corAtual = "Vermelho";
            ultimoBotaoPressionado = botaoVermelhoPressionado;
        }
        else if (corDoBotao == "botaoAmarelo" && corAtual != "Amarelo")
        {
            ultimoBotaoPressionado.SetActive(false);
            //ultimoBotaoSwitchScript = botaoAmarelo.GetComponent<SwitchScript>();
            corAtual = "Amarelo";
            ultimoBotaoPressionado = botaoAmareloPressionado;
        }

        ultimoBotaoPressionado.SetActive(true);
        

    }
}
