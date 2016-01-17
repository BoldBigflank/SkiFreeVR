using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Wipeout : MonoBehaviour {
	public float duration = 3.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			other.gameObject.GetComponent<RigidbodyFirstPersonController>().Wipeout(duration);
		}
	
	}
}
	