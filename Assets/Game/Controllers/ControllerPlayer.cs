using UnityEngine;
using System.Collections;

public class ControllerPlayer : ControllerEntity {
	
	#region Member Variables
	
	private float m_speed = 10;
	private float m_acceleration = 0.5f;
	private float m_slowDown = 0.8f;
	
	private float m_speedAccel;
	
	public Gun m_primaryGun;
	public Gun m_sideGun1;
	public Gun m_sideGun2;
	
	public Timer secondaryTime = new Timer(1.5f);
	
	#endregion
	
	#region Properties
	
	public float Speed {
		get { return m_speed; }
		set {
			m_speed = value;
			m_speedAccel = m_speed * m_acceleration;
		}
	}
	
	public float Acceleration {
		get { return m_acceleration; }
		set {
			m_acceleration = value;
			m_speedAccel = m_speed * m_acceleration;
		}
	}
	
	public float SlowDown {
		get { return m_slowDown; }
	}
	
	public float SpeedAccel {
		get { return m_speedAccel; }
	}
	
	#endregion
	
	#region Member Methods
	
	void Start() {
		m_speedAccel = m_speed * m_acceleration;
		if(null == m_primaryGun) {
			Debug.LogError("No Primary Gun defined for " + gameObject.name + ":PlayerController.cs");
		}
		if(null != State.player) {
			Debug.LogError("Player already defined in State for " + gameObject.name + ":PlayerController.cs");
		} else {
			State.player = this;
		}
		
		HP = 4;
		MaxSpeed = 9;
		secondaryTime.Elapsed = secondaryTime.Time;
	}
	
	void Update () {
		if(Dead) {
			Kill();
		}
		
		// Handle movement
		float xDelta = Input.GetAxis("Horizontal");
		float yDelta = Input.GetAxis("Vertical");
		
		if(0 == xDelta && 0 == yDelta) {
			Vel *= 1-((1-SlowDown)*Time.deltaTime);
		}
		Vec3 thrust = new Vec3(xDelta, yDelta, 0);
		Vel += new Vec3(xDelta, yDelta, 0) * SpeedAccel * Time.deltaTime;
		if(Vel.Length2() > MaxSpeed * MaxSpeed) {
			Vel = Vel.Normalize() * MaxSpeed;
		}	
		rigidbody.velocity = Vel;
		
		m_thrusters.transform.rotation = Quaternion.identity;
		m_thrusters.transform.Rotate(0, 0, new Vec2(thrust).degrees);
		m_thrusters.emissionRate = Mathf.Clamp(thrust.Length2() * 50, 0, 100);
		
		// Handle aim
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vec2 aim = (new Vec2(ray.origin) - new Vec2(transform.position)).Normalize();
		transform.rotation = Quaternion.identity;
		transform.Rotate(0,0,aim.degrees);
		
		//Update weapon status
		secondaryTime.Elapsed += Time.deltaTime;
		
		// Handle Fire
		if(null != m_primaryGun && Input.GetButton("Fire1") && secondaryTime.HasElapsed()) {
			m_primaryGun.Fire(new Vec2(Vel), aim);
		}
		if(null != m_primaryGun && Input.GetButton("Fire2") && secondaryTime.HasElapsed()) {
			secondaryTime.Elapsed = 0;
			m_sideGun1.Fire(new Vec2(Vel), aim);
			m_sideGun2.Fire(new Vec2(Vel), aim);
		}
	}
	
	#endregion
}
