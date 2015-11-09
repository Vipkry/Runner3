using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl controleGeral;
	public float ValorTransparencia;

	//public float vida;
	//public float experiencia;
	
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

	/**public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/geralInfo.dat");
		DadosGerais dados = new DadosGerais();
		dados.vida = vida;
		dados.experiencia = experiencia;
		bf.Serialize(file, dados);
		file.Close();
	}**/


	public void SaveSettings (){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/settingsInfo.dat");
		SettingsData dados = new SettingsData();
		dados.ValorTransparencia = ValorTransparencia;
		bf.Serialize(file, dados);
		file.Close();
		Debug.Log("Salvou" + ValorTransparencia);
	}

	public void LoadSettings()
	{
		if(File.Exists(Application.persistentDataPath + "/settingsInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/settingsInfo.dat", FileMode.Open);
			SettingsData dados = (SettingsData)bf.Deserialize(file);
			ValorTransparencia = dados.ValorTransparencia;
		}
	}
	/**public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/geralInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/geralInfo.dat", FileMode.Open);
			DadosGerais dados = (DadosGerais)bf.Deserialize(file);
			vida = dados.vida;
			experiencia = dados.experiencia;
		}
	}**/

}
[Serializable]
class SettingsData
{
	public float ValorTransparencia;
}

/*[Serializable]
class DadosGerais
{
	public float vida;
	public float experiencia;
}**/