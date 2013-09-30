using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {
	
	private SpawnGroup spawnGroup;
	
	public GameObject bullet;
	public AudioClip shootSound;
	
	public float bulletSpeed = 1f;
	
	public void Start() {
		if(null == bullet) {
			Debug.LogWarning("No Game Object set for "+ gameObject.name + ":bullet");
		}
		GameObject go = new GameObject("Bullets"+gameObject.name);
		go.transform.parent = null;
		spawnGroup = go.AddComponent<SpawnGroup>();
	}
	
	protected void Shoot(Vec2 vel, Vec2 aim, bool silent = false) {
		if(null == spawnGroup || null == bullet) {
			return;
		}
		
		GameObject b = Instantiate(bullet) as GameObject;
		b.transform.position = transform.position;
		b.rigidbody.velocity = (Vector3)(aim * bulletSpeed + vel) ;
		spawnGroup.Add(b);
		
		if(!silent)
			AudioSource.PlayClipAtPoint(shootSound, transform.position);
	}
	
	public abstract void Fire(Vec2 vel, Vec2 aim);
}
