using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class controllerPreguntas : MonoBehaviour {


    public List<Preguntas> listapreguntas;
    public List<Preguntas> listapreguntaslv2;
    public Text pregunta;
    public Button[] opciones;
    public Text comprobacion;
    private int index;
    private GameManager GM;
    private bool a;
	// Use this for initialization
	void Start () {
		index = 0;
		Debug.Log ("instancia: " + index);
		obtenerPregunta ();
		GM = FindObjectOfType <GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void comprobarRespuesta(int id){
		if (!GM.returnJugando ())
			return;
		if (listapreguntas [index].respuestas [id].correcta) {
			//comprobacion.text = "Correcta";
			GM.siguientePregunta ();
			GM.puntaje += 10;
			GM.re.enabled = true;
			GM.re.sprite = GM.correcto;
            a = true;
		} else {
            //comprobacion.text = "Incorrecta";
            GM.re.sprite = GM.incorrecto;
            GM.re.enabled = true;
            a = false;
            finalizarJuego();

		}
		GM.cambiando = true;
	}

	void obtenerPregunta(){
		Debug.Log( Random.Range (1, 1));
		pregunta.text = listapreguntas [0].pregunta;
		for (int i = 0; i < 4; i++) {
			opciones [i].GetComponentInChildren<Text> ().text = listapreguntas [0].respuestas [i].r;
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
        if (index < listapreguntas.Count)
        {
            pregunta.text = listapreguntas[t].pregunta;
            for (int i = 0; i < 4; i++)
            {
                opciones[i].GetComponentInChildren<Text>().text = listapreguntas[t].respuestas[i].r;
                GM.re.enabled = false;
            }
            Debug.Log("Capacidad: " + listapreguntas.Capacity);
            Debug.Log(index);
        }
        else {
            finalizarJuego();
        }
    }
	public int topePreguntas(){
		return listapreguntas.Capacity;
	}
	public void cambirNivel(){
		listapreguntas = listapreguntaslv2;
	}
    public void finalizarJuego() {
        PlayerPrefs.SetInt("resultado",GM.puntaje);
        Debug.Log("puntaje: " + GM.puntaje);
        PlayerPrefs.SetString("win",a.ToString());
        SceneManager.LoadScene("resultado");
        Debug.Log("Juego terminado");

    }
}
