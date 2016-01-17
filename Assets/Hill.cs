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
	public int obstacleCount = 25;
	
	// Slalom
	public GameObject leftGate;
	public GameObject rightGate;
	
	// Use this for initialization
	void Start () {
		// The floor
		GameObject floorParent = new GameObject();
		floorParent.name = "Floor";
		floorParent.transform.parent = transform;
		for(int y = 0; y < rows; y++){
			for(int x = 0; x < columns; x++){
				GameObject o = Instantiate( floor, new Vector3(x * floorWidth, 0.0F, y * floorHeight), floor.transform.rotation) as GameObject;
				o.transform.localScale = new Vector3(floorWidth, floorHeight, 1.0F);
				o.transform.parent = floorParent.transform;
				
//				if( obstacles.Length > 0 ){
//					GameObject obs = Instantiate ( obstacles[0] , new Vector3(x * floorWidth, 0.0F, y * floorHeight), obstacles[0].transform.rotation) as GameObject;
//					obs.transform.parent = floorParent.transform;
//				} 
			}

		}
		
		// The obstacles
		GameObject obstaclesParent = new GameObject();
		obstaclesParent.name = "Obstacles";
		obstaclesParent.transform.parent = transform;
		for( int i = 0; i < obstacleCount; i++){
			int obstacleNumber = Random.Range(0,obstacles.Length);
			float xPos = Random.Range (0.0F, columns * floorWidth) - floorWidth / 2.0F;
			float yPos = Random.Range (0.0F, rows * floorWidth) - floorHeight / 2.0F;
			
			GameObject obs = Instantiate ( obstacles[obstacleNumber] , new Vector3(xPos, 0.0F, yPos), obstacles[obstacleNumber].transform.rotation) as GameObject;
			obs.transform.parent = obstaclesParent.transform;
			obs.transform.localRotation = Quaternion.Euler (Vector3.left * floorAngle);
			
		}
		// The slalom
		SetupSlalom();
		
		transform.position = new Vector3(columns * floorWidth/-2.0F , 0.0F, 0.0F);
		transform.rotation = Quaternion.Euler (Vector3.left * (-1)*floorAngle);
		
	}
	
	void SetupSlalom(){
		GameObject slalomParent = new GameObject();
		slalomParent.name = "Slalom";
		slalomParent.transform.parent = transform;
		
		float xPos = columns * floorWidth / 2.0F;
		
		for(int y = 2; y < rows; y++){
			GameObject nextGate = (y % 2 == 0) ? leftGate : rightGate;
			GameObject gate = Instantiate( nextGate, new Vector3(xPos, 0.0F, y * floorHeight), nextGate.transform.rotation) as GameObject;
			gate.transform.parent = slalomParent.transform;
			gate.transform.localRotation = Quaternion.Euler (Vector3.left * floorAngle);
			
			xPos += Random.Range (-floorWidth, floorWidth);
			if(y == rows - 1){
				gate.GetComponent<SlalomGate>().SetLast(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
