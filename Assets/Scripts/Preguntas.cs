
using System.Collections;
[System.Serializable]
public class Preguntas {
	public string pregunta;
	public respuesta[] respuestas = new respuesta[4];

}
[System.Serializable]
public class respuesta{

	public string r;
	public bool correcta;

}
