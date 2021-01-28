using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
 public class GameData
 {
     public int score;
     public int coins;
     public int Ecoins;
     public int CurrentChar;
     public List<bool> character;
     public List<bool> worlds;
 
     public GameData(int scoreInt, int monedas, int Especialmon, int perActual, List<bool> personajes, List<bool> mundos)
     {
         score = scoreInt;
         coins = monedas;
         Ecoins = Especialmon;
         CurrentChar = perActual;
         character = personajes;
         worlds = mundos;
     }

     public void Prueba(){
     	Debug.Log(PlayerPrefs.GetFloat("Speed"));
     }
 }