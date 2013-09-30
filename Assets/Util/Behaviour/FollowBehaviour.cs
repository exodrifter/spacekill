using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FollowBehaviour : MonoBehaviour {
	
	public GameObject target;
	
	public float strength = 20;
	
	void Start () {
		if(null == target) {
			Debug.LogWarning("No target defined for "+ gameObject.name + ":FollowBehaviour.cs!");
		}
	}
	
	void LateUpdate () {
		if(null == target) {
			return;
		}
		
		rigidbody.velocity = (target.transform.position - transform.position) * strength;
	}
}
