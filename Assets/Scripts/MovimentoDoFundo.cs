using UnityEngine;
using System.Collections;

public class MovimentoDoFundo : MonoBehaviour {

    private Material currentMaterial;
    public float speed;
    // Offset é quanto a textura está "rodando" dentro da "bola" no material. Aumentar o valor disso faz ela ir "andando" pela bola
    private float offset;

    // Use this for initialization
    void Start()
    {
        // Pega o material que o renderer está usando
        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // aumenta o offset multiplicando por deltaTime para manter a velocidade em qualquer dispositivo
        offset += speed * Time.deltaTime;
        
        // Carrega o offset no material.  
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}

