using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroup : MonoBehaviour {
	
	private Dictionary<int, GameObject> m_objects = new Dictionary<int, GameObject>();
	
	public void Add(GameObject go) {
		if(null == go) {
			return;
		}
		m_objects.Add(go.GetHashCode(), go);
		go.transform.parent = this.transform;
	}
}
