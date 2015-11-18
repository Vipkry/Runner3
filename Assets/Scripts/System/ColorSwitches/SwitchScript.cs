using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    private SwitchController switchControllerScript;
    private AudioSource buttonSwitchAudioSource;

    // Lembrando que deixei assim por que acho uma ideia interessante que cada botao tenha seu próprio som
    public AudioClip buttonSwitchAudioClip;

    void Start() {

        switchControllerScript = GameObject.FindGameObjectWithTag("SwitchController").GetComponent<SwitchController>();
        buttonSwitchAudioSource = GameObject.FindGameObjectWithTag("SwitchAudio").GetComponent<AudioSource>(); 

    }

    void OnMouseDown() {

        switchControllerScript.mudaUltimoBotao(gameObject.name);
        
        buttonSwitchAudioSource.PlayOneShot(buttonSwitchAudioClip, 1);


    }

    

}
