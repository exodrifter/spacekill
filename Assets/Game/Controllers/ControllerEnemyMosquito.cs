using UnityEngine;
using System.Collections;

public class ControllerEnemyMosquito : ControllerEntity {

	public int m_startHP;
	public Gun m_primaryGun;
	
	void Start() {
		HP = m_startHP;
		MaxSpeed = 30;
	}
	
	void Update() {
		if(Dead) {
			State.score += 1;
			Kill();
			return;
		}
		if(null == State.player || State.player.Dead) {
			Kill();
			return;
		}
		
		// Handle Aim
		Vec2 aim = new Vec2(State.player.transform.position - this.transform.position);
		transform.rotation = Quaternion.identity;
		transform.Rotate(0,0,aim.degrees);
		
		// Handle Movement
		Vec3 thrust = new Vec3(State.player.transform.position - this.transform.position);
		thrust = (thrust.Length2() < 10 ? -2 : 1) * thrust;
		Vel += thrust * Time.deltaTime;
		if(Vel.Length2() > MaxSpeed * MaxSpeed) {
			Vel = Vel.Normalize() * MaxSpeed;
		}
		rigidbody.velocity = Vel;
		
		m_thrusters.transform.rotation = Quaternion.identity;
		m_thrusters.transform.Rotate(0, 0, new Vec2(thrust).degrees);
		m_thrusters.emissionRate = Mathf.Clamp(thrust.Length2(), 0, 10);
		
		// Fire!
		m_primaryGun.Fire(new Vec2(Vel), aim);
	}
}
