using UnityEngine;
using System.Collections;

public class ZLock : MonoBehaviour {
	
	public float zLevel = 0;
	
	// Update is called once per frame
	void Update () {
		Vector3 vel = rigidbody.velocity;
		vel.z = 0;
		rigidbody.velocity = vel;
		
		Vector3 pos = transform.position;
		pos.z = zLevel;
		transform.position = pos;
	}
}
