using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class showResult : MonoBehaviour {
    public Text t;
    public Text r;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("win") == "False")
        {
            t.text = "Perdiste";
        }
        else {
            t.text = "Ganaste";
        }
        r.text = "Total: " + PlayerPrefs.GetInt("resultado").ToString();
        //t.text = "Perdiste";
        PlayerPrefs.SetInt("partidasJugadas",1+ PlayerPrefs.GetInt("partidasJugadas")); 

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
