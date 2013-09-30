using UnityEngine;
using System.Collections;

public class GunSide : Gun {
	
	public float m_time = 0;
	public float m_randTime = 0;
	private Timer m_timer;
	
	public bool left = false;
	
	new void Start() {
		base.Start();
		m_timer = new Timer(m_time + m_randTime * Random.value);
	}
	
	void Update() {
		m_timer.Elapsed += Time.deltaTime;
	}
	
	public override void Fire(Vec2 vel, Vec2 aim) {
		if(left)
			aim.radians += Mathf.PI/2;
		else
			aim.radians -= Mathf.PI;
		if(m_timer.HasElapsed()) {
			m_timer.Reset();
			m_timer.Time = m_time + m_randTime * Random.value;
			base.Shoot(vel, aim);
			Vec2 lvec = new Vec2(aim);
			lvec.degrees += 5;
			base.Shoot(vel, lvec, true);
			Vec2 rvec = new Vec2(aim);
			rvec.degrees -= 5;
			base.Shoot(vel, rvec, true);
			Vec2 llvec = new Vec2(aim);
			llvec.degrees += 3;
			base.Shoot(vel, llvec, true);
			Vec2 rrvec = new Vec2(aim);
			rrvec.degrees -= 3;
			base.Shoot(vel, rrvec, true);
			//StartCoroutine(FireMulti(vel, aim));
		}
	}
	
	public IEnumerator FireMulti(Vec2 vel, Vec2 aim) {
		yield return new WaitForSeconds(0.2f);
		base.Shoot(vel, aim);
		Vec2 lvec = new Vec2(aim);
		lvec.degrees += 5;
		base.Shoot(vel, lvec, true);
		Vec2 rvec = new Vec2(aim);
		rvec.degrees -= 5;
		base.Shoot(vel, rvec, true);
	}
}
