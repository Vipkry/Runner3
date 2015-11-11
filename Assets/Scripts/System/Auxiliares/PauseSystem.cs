using UnityEngine;
using System.Collections;

public class PauseSystem : MonoBehaviour {

    public GameObject PainelPause;

    public bool estaPausado;

    public void Resumer()
    {
        estaPausado = false;
        PainelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pauser()
    {
        estaPausado = true;
        Time.timeScale = 0;
        PainelPause.SetActive(true);
    }

}
