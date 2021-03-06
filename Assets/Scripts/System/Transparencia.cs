﻿using UnityEngine;
using System.Collections;

public class Transparencia : MonoBehaviour
{
    //Este script controla a transparencia das sprites(criado para o HUD)
    // transparencia, 0 = 100% transparente , 0.3 = 70% transparente, 0.5 = 50% transparente, 1 = 0% transparente
	public float transparencia;
	
    
	void Start()
	{
		// Carrega o valor da transparencia ja carregado pelo AutoLoad no GameControl
		transparencia = GameObject.Find("GameControl").GetComponent<GameControl>().ValorTransparencia;


        try
        {
            // Pega o spriteRenderer e muda os pixels alpha
            SpriteRenderer renderizador = GetComponent<SpriteRenderer>();
            renderizador.color = new Color(1f, 1f, 1f, transparencia);
        }


        catch (MissingComponentException)
        {
            // Pega o MeshRenderer e muda os pixels alpha caso não haja SpriteRenderer no GameObject
            MeshRenderer tempMeshRenderer = GetComponent<MeshRenderer>();
            Material temp = tempMeshRenderer.material;
            temp.color = new Color(0f, 255f, 0f, transparencia);

        }


    }
}
