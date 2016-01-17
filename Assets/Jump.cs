using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Jump : MonoBehaviour {
	public float strength = 5.0F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other){
		if(other.CompareTag("Player")){
			Debug.Log ("Player TRIGGERED");
//			other.attachedRigidbody.AddForce(0.0F, strength, 0.0F, ForceMode.Impulse);
			other.gameObject.GetComponent<RigidbodyFirstPersonController>().Jump(strength);
		}
	}
}
