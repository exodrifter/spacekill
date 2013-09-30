using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour
{
	public static ControllerPlayer player;
	public static Dictionary<int, ControllerEntity> enemies = new Dictionary<int, ControllerEntity>();
	
	public static int level = 0;
	public static int score = 0;
	
	public ControllerEntity m_enemyCharge;
	public ControllerEntity m_enemyMosquito;
	public ControllerEntity m_enemySider;
	public ControllerEntity m_enemyBlocker;
	
	private Timer gameoverTimer = new Timer(2);
	public tk2dTextMesh tryagain;
	
	private bool playGameOver = true;
	public AudioClip gameoverSound;
	private AudioSource music;
	
	void Start() {
		if(null == m_enemyCharge) {
			Debug.LogWarning("m_enemyCharge not defined for "+ gameObject.name + ":State.cs!");
		}
		if(null == m_enemyMosquito) {
			Debug.LogWarning("m_enemyMosquito not defined for "+ gameObject.name + ":State.cs!");
		}
		if(null == m_enemySider) {
			Debug.LogWarning("m_enemySider not defined for "+ gameObject.name + ":State.cs!");
		}
		if(null == m_enemyBlocker) {
			Debug.LogWarning("m_enemyBlocker not defined for "+ gameObject.name + ":State.cs!");
		}
		
		music = GetComponent<AudioSource>();
	}
	
	void Update() {
		if(null == player || player.Dead) {
			music.Stop();
			if(playGameOver) {
				AudioSource.PlayClipAtPoint(gameoverSound, transform.position);
				playGameOver = !playGameOver;
			}
			gameoverTimer.Elapsed += Time.deltaTime;
			if(gameoverTimer.HasElapsed()) {
				tryagain.renderer.enabled = true;
				if(Input.GetButton("Fire1")) {
					score = 0;
					gameoverTimer.Elapsed = 0;
					tryagain.renderer.enabled = false;
					Application.LoadLevel("Test");
				}
			}
			return;
		}
		
		if(enemies.Count == 0) {
			level++;
			if(level % 5 == 0) {
				CreateBlockerEnemy();
			} else if(level % 4 == 0) {
				for(int i = 0; i < level/4; i++) {
					CreateSiderEnemy();
				}
			} else if(level % 3 == 0) {
				for(int i = 0; i < level/3; i++) {
					CreateMosquitoEnemy();
				}
			} else {
				for(int i = 0; i < (level/5)+2; i++) {
					CreateChargeEnemy();
				}
			}
			for(int i = 0; i < level / 10; i++) {
				CreateChargeEnemy();
			}
		}
	}
	
	void CreateChargeEnemy() {
		ControllerEntity ce = Instantiate(m_enemyCharge) as ControllerEntity;
		ce.rigidbody.velocity = player.rigidbody.velocity;
		ce.rigidbody.angularVelocity = player.rigidbody.angularVelocity;
		ce.transform.position = player.transform.position + RandomPosition(15);
		ce.Dictionary = enemies;
		enemies.Add(ce.GetHashCode(), ce);
	}
	
	void CreateMosquitoEnemy() {
		ControllerEntity ce = Instantiate(m_enemyMosquito) as ControllerEntity;
		ce.rigidbody.velocity = player.rigidbody.velocity;
		ce.rigidbody.angularVelocity = player.rigidbody.angularVelocity;
		ce.transform.position = player.transform.position + RandomPosition(20);
		ce.Dictionary = enemies;
		enemies.Add(ce.GetHashCode(), ce);
	}
	
	void CreateSiderEnemy() {
		ControllerEntity ce = Instantiate(m_enemySider) as ControllerEntity;
		ce.rigidbody.velocity = player.rigidbody.velocity;
		ce.rigidbody.angularVelocity = player.rigidbody.angularVelocity;
		ce.transform.position = player.transform.position + RandomPosition(15);
		ce.Dictionary = enemies;
		enemies.Add(ce.GetHashCode(), ce);
	}
	
	void CreateBlockerEnemy() {
		ControllerEntity ce = Instantiate(m_enemyBlocker) as ControllerEntity;
		ce.rigidbody.velocity = player.rigidbody.velocity;
		ce.rigidbody.angularVelocity = player.rigidbody.angularVelocity;
		ce.transform.position = player.transform.position + RandomPosition(40);
		ce.Dictionary = enemies;
		enemies.Add(ce.GetHashCode(), ce);
	}
	
	Vec3 RandomPosition(float distance) {
		Vec2 ret = new Vec2(0, distance);
		ret.radians = Random.value * Mathf.PI * 2;
		return new Vec3(ret);
	}
}
