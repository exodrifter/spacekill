using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	
	public int damage;
	
	void OnCollisionEnter(Collision collision) {
		// Get the controller and do damage
		ControllerEntity ce = collision.collider.gameObject.GetComponent<ControllerEntity>();
		if(ce != null)
			ce.Damage += damage;
		
		// Destroy this bullet
		StopAllCoroutines();
		this.renderer.enabled = false;
		this.collider.enabled = false;
		StartCoroutine(DestroyAtEndOfFrame());
	}
	
	IEnumerator DestroyAtEndOfFrame() {
		yield return new WaitForEndOfFrame();
		DestroyImmediate(this);
	}
}
