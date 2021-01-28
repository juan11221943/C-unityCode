using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monedas : MonoBehaviour
{
	private int MonedasIngame;

	private void cambiar(){
		this.GetComponent<UnityEngine.UI.Text>().text = MonedasIngame.ToString();
		PlayerPrefs.SetInt("TotalCoins", MonedasIngame);
	}

	public void añadir(){
		MonedasIngame += Random.Range(2, 8);
		cambiar();
	}
    // Start is called before the first frame update
    void Start()
    {
        MonedasIngame = 0;
        cambiar();
    }

}
