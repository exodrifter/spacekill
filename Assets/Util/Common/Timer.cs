using UnityEngine;
using System.Collections;

public class Timer {
	
	private float m_time;
	private float m_elapsed;
	
	public float Time {
		get { return m_time; }
		set { m_time = value; }
	}
	
	public float Elapsed {
		get { return m_elapsed; }
		set { m_elapsed = value; }
	}
	
	public float Percent {
		get { return m_elapsed/m_time; }
		set { m_elapsed = m_time * value; }
	}
	
	public Timer(float time) {
		this.m_time = time;
	}
	
	public bool HasElapsed() {
		return m_elapsed >= m_time;
	}
	
	public void Reset() {
		m_elapsed = 0;
	}
}
