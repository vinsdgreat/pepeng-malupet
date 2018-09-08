using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Vector3 lastPlayerPosition;
	private float distanceToMoveX;
	private float distanceToMoveY;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
		distanceToMoveY = player.transform.position.y - lastPlayerPosition.y;

		
		transform.position = new Vector3(transform.position.x + distanceToMoveX, 
			transform.position.y + distanceToMoveY, transform.position.z);
		lastPlayerPosition = player.transform.position;
	}
}
