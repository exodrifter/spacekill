using UnityEngine;
using System.Collections;

public class ControllerEnemySider : ControllerEntity {

	public int m_startHP;
	public Gun m_Gun1;
	public Gun m_Gun2;
	public Gun m_Gun3;
	
	void Start() {
		HP = m_startHP;
	}
	
	void Update() {
		if(Dead) {
			State.score += 5;
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
		if(thrust.Length2() < 10) {
			Vec2 temp = new Vec2(thrust);
			temp.radians += Mathf.PI;
			thrust = new Vec3(temp);
		}
		thrust = (thrust.Length2() < 10 ? -2 : 1) * thrust;
		Vel += thrust * Time.deltaTime;
		if(Vel.Length2() > MaxSpeed * MaxSpeed) {
			Vel = Vel.Normalize() * MaxSpeed;
		}
		rigidbody.velocity = Vel;
		
		m_thrusters.transform.rotation = Quaternion.identity;
		m_thrusters.transform.Rotate(0, 0, new Vec2(thrust).degrees);
		m_thrusters.emissionRate = Mathf.Clamp(thrust.Length2(), 0, 100);
		
		// Fire!
		m_Gun1.Fire(new Vec2(Vel), aim);
		m_Gun2.Fire(new Vec2(Vel), aim);
		m_Gun3.Fire(new Vec2(Vel), aim);
	}
}
