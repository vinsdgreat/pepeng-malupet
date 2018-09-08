using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public GameObject[] platforms;
	public Transform generationPoint;
	//public ObjectPooler objectPooler;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	public float heightBetweenMin;
	public float heightBetweenMax;
	

	private float heightBetween;
	private float distanceBetween;
	private float platformWidth;
	private int platformSelector;

	// Use this for initialization
	void Start () {
		 platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			heightBetween = Random.Range(heightBetweenMin, heightBetweenMax);

			platformSelector = Random.Range(0, platforms.Length);

			platformWidth = platforms[platformSelector].GetComponent<BoxCollider2D>().size.x;

			transform.position = new Vector3(transform.position.x + (platformWidth*2) + distanceBetween,
				transform.position.y + heightBetween, transform.position.z);

			
			//== Normal Instatiation
			Instantiate (platforms[platformSelector], transform.position, transform.rotation);

			//=== User Object Pooling
			/*GameObject newPlatform = objectPooler.GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);*/
		}
	}
}
