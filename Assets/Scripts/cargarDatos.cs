using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cargarDatos : MonoBehaviour {

	public Text informacion;
	// Use this for initialization
	void Start () {
		cargar ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void cargar(){
		if (PlayerPrefs.HasKey ("sesion")) {
			informacion.text = "Usuario: " + PlayerPrefs.GetString ("usuario") + "\nEmail: " + PlayerPrefs.GetString ("email") + "\nPuntaje Maximo: " + PlayerPrefs.GetInt ("puntajeMax").ToString () + "\nUltimo nivel jugado: " + PlayerPrefs.GetInt ("ultimoNivel").ToString () + "\nPartidas jugadas: " + PlayerPrefs.GetInt ("partidasJugadas").ToString (); 
		}
	}
}
