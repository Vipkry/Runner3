using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{

    public MovimentoDoPlayer scriptDeMovimento;
    private Transform playerTransform;

    void Awake()
    {

        playerTransform = GetComponent<Transform>();

    }
    // Update is called once per frame
    void Update()
    {
        if (scriptDeMovimento.pulandoParaDireita)
        {

            Quaternion temp = playerTransform.localRotation;
            temp.y = 15;
            playerTransform.localRotation = temp;

        }else if (scriptDeMovimento.pulandoParaEsquerda) {

            Quaternion temp = playerTransform.localRotation;
            temp.y = -15;
            playerTransform.localRotation = temp;


        }
    }
}
