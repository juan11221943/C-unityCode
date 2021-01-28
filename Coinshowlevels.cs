using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coinshowlevels : MonoBehaviour
{
	public Text monedas;
	public Text monedasE;
    // Start is called before the first frame update
    void Start()
    {
        monedas.text = PlayerPrefs.GetInt("Monedas", 0).ToString();
        monedasE.text = PlayerPrefs.GetInt("Especiales", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        monedas.text = PlayerPrefs.GetInt("Monedas", 0).ToString();
        monedasE.text = PlayerPrefs.GetInt("Especiales", 0).ToString();
    }
}
