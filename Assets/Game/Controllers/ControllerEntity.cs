using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ControllerEntity : MonoBehaviour {

	#region HP Properties
	
	/// <summary> The maximum hp </summary>
	private int m_hp = 0;
	/// <summary> The amount of damage </summary>
	private int m_damage = 0;
	
	/// <summary> The sound to play when damage is increased </summary>
	public AudioClip m_damageSound;
	/// <summary> The sound to play when the entity dies </summary>
	public AudioClip m_deathSound;
	
	public int HP {
		get { return m_hp; }
		set { m_hp = value; }
	}
	
	public int Damage {
		get { return m_damage; }
		set {
			if(value > m_damage && null != m_damageSound) {
				AudioSource.PlayClipAtPoint(m_damageSound, transform.position);
			}
			m_damage = value;
		}
	}
	
	public float PercentHP {
		get { return Dead ? 0 : ((float)(HP-Damage))/((float)HP); }
	}
	
	public bool Dead {
		get { return Damage >= HP; }
	}
	
	#endregion
	
	#region Movement Properties
	
	private Vec3 m_vel = new Vec3();
	
	private float m_maxSpeed = 15;
	
	public Vec3 Vel {
		get { return m_vel; }
		set { m_vel = value; }
	}
	
	public float MaxSpeed {
		get { return m_maxSpeed; }
		set { m_maxSpeed = value; }
	}
	
	#endregion
	
	#region Dictionary/Spawn Group Methods
	
	private IDictionary m_dictionary;
	
	public IDictionary Dictionary {
		get { return m_dictionary; }
		set { m_dictionary = value; }
	}
	
	#endregion
	
	#region Thrusters
	
	public ParticleSystem m_thrusters;
	
	#endregion
	
	#region Member Methods
	
	public void Kill() {
		AudioSource.PlayClipAtPoint(m_deathSound, transform.position);
		StopAllCoroutines();
		Destroy(this.gameObject);
		if(null != m_dictionary) {
			m_dictionary.Remove(this.GetHashCode());
		}
	}
	
	#endregion
}