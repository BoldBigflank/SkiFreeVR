using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager current;
	
	public GameObject player;
	Vector3 playerPosition;
	
	// Game Variables
	public bool gameInProgress;
	float timer;
	float lastTime;
	float bestTime;
	
	// UI stuff
	public Text bestTimeText;
	public Text currentTimeText;
	public Text lastTimeText;
	public Text gameInfoText;
	
	// Use this for initialization
	void Start () {
		current = this;
		player = GameObject.FindGameObjectWithTag("Player");
		playerPosition = player.transform.position;
		gameInProgress = false;
		timer = 0.0f;
		bestTime = 0.0f;
		lastTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameInProgress){
			timer += Time.deltaTime;
		}
		
		if(Input.touchCount > 0 || Input.GetMouseButtonDown(0) ){
			ResetGame();
		}
		
		// Update the UI
		currentTimeText.text = "Timer: " + timer.ToString("F2") + "s";
		lastTimeText.text = "Last\n" + lastTime.ToString ("F2") + "s";
		bestTimeText.text = "Best\n" + bestTime.ToString("F2") + "s";
	}
	
	void ResetGame(){
		player.transform.position = playerPosition;
		player.GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameInProgress = false;
		timer = 0.0f;
		gameInfoText.text = "Game Over";
	}
	
	public void EndGame(){
		// Last gate should call this
		gameInProgress = false;
		lastTime = timer;
		if(bestTime == 0.0f || timer < bestTime){
			bestTime = timer;
		}
		
		ResetGame ();
	}
	
	public void SlalomGate(bool success){
		gameInProgress = true;
		if(!success) timer += 5.0f;
		gameInfoText.text = (success) ? "Gate passed" : "Gate missed (+5s)";
	}
}
