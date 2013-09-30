using UnityEngine;
using System.Collections;

public class AutoKill : MonoBehaviour {
	
	public float m_seconds;
	
	void Start () {
		StartCoroutine(Kill());
	}
	
	IEnumerator Kill() {
		yield return new WaitForSeconds(m_seconds);
		DestroyImmediate(this.gameObject);
	}
}
