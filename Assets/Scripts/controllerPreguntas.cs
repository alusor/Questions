using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class controllerPreguntas : MonoBehaviour {


	public List<Preguntas> listapreguntas;
	public List<Preguntas> listapreguntaslv2;
	public Text pregunta;
	public Button[] opciones;
	public Text comprobacion;
	private int index;
	private GameManager GM;
	// Use this for initialization
	void Start () {
		index = 0;
		Debug.Log ("instancia: " + index);
		//cambirNivel ();
		obtenerPregunta ();


		GM = FindObjectOfType <GameManager> ();

//		GameManager.verificarRespuesta += obtenerPregunta ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void comprobarRespuesta(int id){
		if (!GM.returnJugando ())
			return;
		if (listapreguntas [index].respuestas [id].correcta) {
			comprobacion.text = "Correcta";
			GM.siguientePregunta ();
			GM.puntaje += 10;

		} else {
			comprobacion.text = "Incorrecta";
			GM.siguientePregunta ();

		}
		GM.cambiando = true;
	
	}

	void obtenerPregunta(){


		Debug.Log( Random.Range (1, 1));
		pregunta.text = listapreguntas [0].pregunta;
		for (int i = 0; i < 4; i++) {
			opciones [i].GetComponentInChildren<Text> ().text = listapreguntas [0].respuestas [i].r;
			if (listapreguntas [0].respuestas [i].correcta) {
				opciones [i].GetComponentInChildren<Text> ().color = new Color (1.0f,0,0);
			}
		}

		Debug.Log ("Final primera");

	}
	int returnIndex (){
		return index; 
	}
	public void nextQuestion(){
		
		GM.timerUI.localScale =  new Vector2 (1f,1f);
		++index;
		Debug.Log (index + "primro ");
		int t = returnIndex ();
		pregunta.text = listapreguntas [t].pregunta;
		for (int i = 0; i < 4; i++) {
			opciones [i].GetComponentInChildren<Text> ().text = listapreguntas [t].respuestas [i].r;
			if (listapreguntas [t].respuestas [i].correcta) {
				opciones [i].GetComponentInChildren<Text> ().color = new Color (1.0f, 0, 0);
			} else {
				opciones [i].GetComponentInChildren<Text> ().color = new Color (0, 0, 0);
			}
		}
		Debug.Log ("Capacidad: " + listapreguntas.Capacity);
		Debug.Log (index);
	}
	public int topePreguntas(){
		return listapreguntas.Capacity;
	}
	public void cambirNivel(){
		listapreguntas = listapreguntaslv2;
	}
}
