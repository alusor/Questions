using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
	Datagrama
	frame
	campos que componen un datagrama:
		Ethernet
		preambulo: sincroniza el receptor
		Pre|da|sa|crc
		1- Delimitadores
		2- Direcciones
		3- Control
		4- Informacion
				u
				operacion&mapas
		5- Verificación de integridad de la información
			crc
			fcs
				


		flag|add field| cntrl|info|flag
		
*/
public class GameManager : MonoBehaviour {

	public delegate void verificarRespuesta(bool res);
	public Text tiempoRestante;
	public int puntaje;
	private int timer;
	private controllerPreguntas p;
	public bool cambiando;
	public Text pun;
	public bool jugando;
	public RectTransform timerUI;
	public Image re;
	public Sprite correcto;
	public Sprite incorrecto;
    
	// Use this for initialization
	void Start () {
		re.enabled = false;
		jugando = true;
		comenzarContador ();
		cambiando = false;
		puntaje = 0;
		pun.text = puntaje.ToString ();
		p = FindObjectOfType<controllerPreguntas> ();
	}
	
	// Update is called once per frame
	void Update () {
		pun.text = puntaje.ToString ();
		if(jugando&&!cambiando)
			timerUI.localScale = Vector2.Lerp (timerUI.localScale, new Vector2 (timerUI.localScale.x -1f, 1f),Time.deltaTime*.1f);

	}


	IEnumerator contador(int tiempo){
		while (tiempo > 0) {
			if (!cambiando) {

				tiempoRestante.text = tiempo.ToString ();
				yield return new WaitForSeconds (1);
				tiempo -= 1;
				//timerUI.localScale = new Vector2 (timerUI.localScale.x-.1f,1f);
				if(!cambiando)
				tiempoRestante.text = tiempo.ToString ();
			} else {
			
				break;
			}
		}
		if (tiempo == 0) {
			tiempoRestante.text = "Fin del turno.";
			pun.text = puntaje.ToString ();
			finDelJuego ();
			//siguientePregunta ();
		}

	}
	void comenzarContador(){
		StartCoroutine ("contador",10);
	}
	public void siguientePregunta(){
		pun.text = puntaje.ToString ();
       // re.enabled = false;
		StartCoroutine ("next");
	}
	IEnumerator next(){
		tiempoRestante.text=":'D    ";
		cambiando = true;
		yield return new WaitForSeconds (1f);
		for (int i = 3; i >= 0; i--) {
			tiempoRestante.text = "Siguiente: " + i.ToString ();
			yield return new WaitForSeconds (1f);
		}
		p.nextQuestion ();
		cambiando = false;
		StartCoroutine ("comenzarContador");
	}
	void finDelJuego(){
		Debug.Log ("Lo siento perdiste");
		jugando = false;
	}
	public bool returnJugando(){
		return jugando;
	}
}
