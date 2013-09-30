using UnityEngine;
using System.Collections;

public class GunPrimary : Gun {
	
	public float m_time = 1;
	public float m_randTime = 0;
	private Timer m_timer;
	
	new void Start() {
		base.Start();
		m_timer = new Timer(m_time + m_randTime * Random.value);
	}
	
	void Update() {
		m_timer.Elapsed += Time.deltaTime;
	}
	
	public override void Fire(Vec2 vel, Vec2 aim) {
		if(m_timer.HasElapsed()) {
			m_timer.Reset();
			m_timer.Time = m_time + m_randTime * Random.value;
			base.Shoot(vel, aim);
		}
	}
}
