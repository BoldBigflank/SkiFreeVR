using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	GameObject player;
	Vector3 playerPosition;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 || Input.GetMouseButtonDown(0) ){
			player.transform.position = playerPosition;
		}
	}
}
