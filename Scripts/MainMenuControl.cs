using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuControl : MonoBehaviour {

	public void LoadGame(){
		AsyncOperation operation = SceneManager.LoadSceneAsync (1);
	}

	public void ExitGame(){
		Application.Quit();
	}
}
