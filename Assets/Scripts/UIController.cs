﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class UIController : MonoBehaviour {
	public GameObject gameSetupPanel;
	public GameObject startScreenPanel;
	public  GameObject joinPanel;
	public GameObject lobbyPanel;

	public InputField IPInput;
	public InputField seedInput;
	public InputField sizeXInput;
	public InputField sizeYInput;
	public Dropdown playerCountSelection;

	public Text networkToast;
	IEnumerator toastRoutine;


	// Use this for initialization

	void Start () {

	}

	void Awake(){
		
		gameSetupPanel.SetActive (false);
		if (SceneManager.GetActiveScene ().name == "MazeLevel") {
			startScreenPanel.SetActive (false);
		}
	}



	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleGameSetup(bool value)
	{
		Debug.Log ("toggle game setup " + value);
		gameSetupPanel.SetActive (value);

		if (value == true) {
			//seedInput. = GameControl.gameControl.maze.seed.ToString();
			if (GameControl.gameControl != null) {
				seedInput.text = GameControl.gameControl.maze.seed.ToString ();
				sizeXInput.text = GameControl.gameControl.maze.xSize.ToString ();
				sizeYInput.text = GameControl.gameControl.maze.ySize.ToString ();
			}
		}
	}

	public void ToggleJoinPanel(bool value)
	{
		joinPanel.SetActive (value);
	}

	public void Host(){
		ToggleJoinPanel (false);
		ToggleGameSetup (true);
	}

	public void Join(){
		ToggleJoinPanel (true);
		ToggleGameSetup (false);
	}

	//Update seed to match input field
	public void UpdateSeedValue(){
		GameControl.gameControl.maze.seed = int.Parse(seedInput.text);
	}
	//Update maze size to match input fields
	public void UpdateSizes(){
		/*if (int.Parse (sizeXInput.text) < 10)
			sizeXInput.text = "10";
		if (int.Parse (sizeYInput.text) < 10)
			sizeYInput.text = "10";*/
	}

	//Update input field after generation
	public void UpdateSeedInput(){
		seedInput.text = GameControl.gameControl.maze.seed.ToString ();
	}
		
	public void PlayToast(string text){
		toastRoutine = Toast (text);
		StartCoroutine (toastRoutine);
	}

	IEnumerator Toast(string text){
		networkToast.gameObject.SetActive (true);
		networkToast.text = text;
		yield return new WaitForSeconds (2f);
		networkToast.gameObject.SetActive (false);
	}
}
