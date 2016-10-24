using UnityEngine;
using System.Collections;
using UnityEngine.Events;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class registerController : MonoBehaviour {

	private string usuario;
	private string email;
	public InputField usr;
	public InputField pswd;
	public Text respesta;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("sesion")) {
			SceneManager.LoadScene ("seleccion");
		}

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void registrar(){
		if (usr.text != "" && pswd.text != "") {
			usuario = usr.text.ToString ();
			email = pswd.text.ToString ();
			guardar (usuario, email);
		} else {
			respesta.text = "Incorrecto, vuelva a intentarlo.";
		}
	}

	private void guardar( string a, string b){
		PlayerPrefs.SetString ("usuario",a);
		PlayerPrefs.SetString ("email",b);
		PlayerPrefs.SetInt ("sesion",1);
		Debug.Log ("guardado");
	}
}
