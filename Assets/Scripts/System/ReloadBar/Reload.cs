using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {


    public GameObject[] barrasEmOrdem;

    public PlayerLaserController playerLaserControllerScript;
    public SpriteRenderer readyRenderer;

    private float dividedReloadTime;
    private int barraAtual; 

	// Use this for initialization
	void Start () {

        dividedReloadTime = playerLaserControllerScript.reloadTime / barrasEmOrdem.Length;
        dividedReloadTime -= dividedReloadTime / 8;
        
	}
	
	private IEnumerator proximaBarra() {

        yield return new WaitForSeconds(dividedReloadTime);
        if (barraAtual < barrasEmOrdem.Length) {
            barrasEmOrdem[barraAtual].SetActive(true);
            barraAtual++;
            StartCoroutine(proximaBarra());
            if (barraAtual == barrasEmOrdem.Length) {
                readyRenderer.color = new Color(255, 0, 0);

            }
        }
    } 

    public void reload() {

        barraAtual = 0;
        readyRenderer.color = new Color(0, 255 , 0);
        for (int i = 0; i < barrasEmOrdem.Length; i++) {

            barrasEmOrdem[i].SetActive(false);

        }
        StartCoroutine(proximaBarra());

    }

}
