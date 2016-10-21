using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {
    private SceneManager sm;
	// Use this for initialization
	void Start () {
	
	}
	

    public void cambiarEscena(string escena) {
        SceneManager.LoadScene(escena);
    }

}
