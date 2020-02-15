using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void empezarJuego(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		 

  


	}

	public void cerrarJuego()
	{


		Application.Quit();
	
	}
	public void creditos(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
	}





}
