using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
	private bool no;
	private int puntaje;
    private int monedas;
    private int monedasE;
    private int personajeActual;
    private List<bool> personajes = new List<bool> {};
    private List<bool> mundos = new List<bool> {};

    public void personajeDispo(int posicion){
        if(personajes[posicion]){
            PlayerPrefs.SetInt("disponible", 1);
        }else{
            PlayerPrefs.SetInt("disponible", 0);
        }
    }

    public void Seleccion(int i){
        personajeActual = i;
        SaveFile();
    }

    public void Mundodispo(int i){
        if(mundos[i]){
            PlayerPrefs.SetInt("Dispo", 1);
        }else{
            PlayerPrefs.SetInt("Dispo", 0);
        }
    }

    public void ComprarMundo(int precio){
        int posicion = PlayerPrefs.GetInt("MundoAcom", 0);
        if(precio <= monedas){
            mundos[posicion] = true;
            monedas -= precio;
            SaveFile();
            PlayerPrefs.SetInt("Sepudo", 1);
        }else{
            PlayerPrefs.SetInt("Sepudo", 0);
        }
    }

    public void Compra(int precio){
        int lugar = PlayerPrefs.GetInt("PersoCom", 0);
        if(precio < 1000){
            if(precio <= monedasE){
                personajes[lugar] = true;
                monedasE -= precio;
                SaveFile();
                PlayerPrefs.SetInt("Compra", 1);
            }else{
                PlayerPrefs.SetInt("Compra", 0);
            }
        }else if(precio > 1000){
            if(precio <= monedas){
                personajes[lugar] = true;
                monedas -= precio;
                SaveFile();
                PlayerPrefs.SetInt("Compra", 1);
            }else{
                PlayerPrefs.SetInt("Compra", 0);
            }
        }
    }

    public void Guardar(){
    	int s = PlayerPrefs.GetInt("TotalScore");
        int tc = PlayerPrefs.GetInt("TotalCoins");
        int M = PlayerPrefs.GetInt("Moneda");
        if(puntaje < s){
        	puntaje = s;
        	PlayerPrefs.SetInt("Nuevo", 1);
        }
        monedas += tc;
        monedasE += M;
        SaveFile();
    }

	private void AgregarDatos(){
		for(int i = 0; i < 10; i++){
			if(i == 0){
				personajes.Add(true);
			}else{
				personajes.Add(false);
			}
		}
		for(int i = 0; i < 5; i++){
			if(i == 0){
				mundos.Add(true);
			}else{
				mundos.Add(false);
			}
		}
	}

	public void delFile(){
		string destination = Application.persistentDataPath + "/save.dat";
         if(File.Exists(destination)) {
         		File.Delete(destination);
         	}else {
         		print("no hay");
         	}
	}

	public void SaveFile()
     {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;
 		GameData data;
         if(File.Exists(destination)) {
         		file = File.OpenWrite(destination);
         		no = false;
         	}else {
         		file = File.Create(destination);
         		no = true;
         	}

        if(no){
        	AgregarDatos();
        	puntaje = 0;
        	monedas = 0;
        	monedasE = 0;
        	personajeActual = 0;
        }
 		
        data = new GameData(puntaje, monedas, monedasE, personajeActual, personajes, mundos); 
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        LoadFile();
     }

     public void LoadFile()
     {
         string destination = Application.persistentDataPath + "/save.dat";
         FileStream file;
 
         if(File.Exists(destination)){
			file = File.OpenRead(destination);
			BinaryFormatter bf = new BinaryFormatter();
			GameData data = (GameData) bf.Deserialize(file);
			file.Close();

			puntaje = data.score;
			monedas = data.coins;
			monedasE = data.Ecoins;
			personajeActual = data.CurrentChar;
			personajes = data.character;
			mundos = data.worlds;
            PlayerPrefs.SetInt("Monedas", monedas);
            PlayerPrefs.SetInt("Especiales", monedasE);
			PlayerPrefs.SetInt("Personajeactual", personajeActual);
      	}
         else
         {
             SaveFile();
         }
 
         
     }

    // Start is called before the first frame update
    void Start()
    {
        //delFile();
        LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
}
