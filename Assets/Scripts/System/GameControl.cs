using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl controleGeral;
	public float ValorTransparencia;
	public float ValorMusica;

	//Verifica se ja existe um GameControl, se sim, destroi ele e torna este o GameControl
	void Awake () {
		if (controleGeral == null)
		{
			DontDestroyOnLoad(gameObject);
			controleGeral = this;
		}
		else if (controleGeral != this)
		{
			Destroy(gameObject);
		}
	}

	//Salva os dados em um arquivo binario
	public void SaveSettings (){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/settingsInfo.dat");
		SettingsData dados = new SettingsData();
		dados.ValorTransparencia = ValorTransparencia;
		dados.ValorMusica = ValorMusica;
		bf.Serialize(file, dados);
		file.Close();
	}
	//Carrega os dados de um arquivo binario
	public void LoadSettings()
	{
		if(File.Exists(Application.persistentDataPath + "/settingsInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/settingsInfo.dat", FileMode.Open);
			SettingsData dados = (SettingsData)bf.Deserialize(file);
			ValorTransparencia = dados.ValorTransparencia;
			ValorMusica = dados.ValorMusica;
			file.Close();
		}
	}

}
//Classe que permite uma "serializaçao"
[Serializable]
class SettingsData
{
	public float ValorTransparencia;
	public float ValorMusica;
}
