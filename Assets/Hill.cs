using UnityEngine;
using System.Collections;

public class Hill : MonoBehaviour {
	// What the floor looks like
	public GameObject floor;
	public float floorWidth = 5.0F;
	public float floorHeight = 5.0F;

	public float floorAngle = 20.0F;

	// How far away we need to generate
	public int rows = 5;
	public int columns = 5;
	
	// Objects to place
	public GameObject[] obstacles;
	
	// Use this for initialization
	void Start () {
		GameObject floorParent = new GameObject();
		floorParent.name = "Floor";
		floorParent.transform.parent = transform;
		for(int y = 0; y < rows; y++){
			for(int x = 0; x < columns; x++){
				GameObject o = Instantiate( floor, new Vector3(x * floorWidth, 0.0F, y * floorHeight), floor.transform.rotation) as GameObject;
				o.transform.localScale = new Vector3(floorWidth, floorHeight, 1.0F);
				o.transform.parent = floorParent.transform;
				
				if( obstacles.Length > 0 ){
					GameObject obs = Instantiate ( obstacles[0] , new Vector3(x * floorWidth, 0.0F, y * floorHeight), obstacles[0].transform.rotation) as GameObject;
					obs.transform.parent = floorParent.transform;
				} 
			}

		}
		floorParent.transform.rotation = Quaternion.Euler (Vector3.left * (-1)*floorAngle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
