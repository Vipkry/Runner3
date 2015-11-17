using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    public GameObject buttonPressedDown;
    private AudioSource buttonSwitchAudioSource;

    // Lembrando que deixei assim por que acho uma ideia interessante que cada botao tenha seu próprio som
    public AudioClip buttonSwitchAudioClip;

    void Start() {

        buttonSwitchAudioSource = GameObject.FindGameObjectWithTag("SwitchAudio").GetComponent<AudioSource>(); 

    }

    void OnMouseDown() {

        buttonPressedDown.SetActive(true);
        // Só pra ter certeza que o botão pressionado vai ficar "em cima do antigo" pra cobrir ele, e não deixar de aparecer
        buttonPressedDown.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        buttonSwitchAudioSource.PlayOneShot(buttonSwitchAudioClip, 1);


    }

    

}
