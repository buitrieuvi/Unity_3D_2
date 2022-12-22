using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
	public GameObject td;

	void OnTriggerEnter ( Collider obj  ){
		thedoor= GameObject.FindWithTag("SF_Door");
		td.GetComponent<Animation>().Play("open");
	}

	void OnTriggerExit ( Collider obj  ){
		thedoor= GameObject.FindWithTag("SF_Door");
		td.GetComponent<Animation>().Play("close");
	}
}