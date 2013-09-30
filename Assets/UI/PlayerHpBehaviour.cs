using UnityEngine;
using System.Collections;

/// <summary>
/// Sets a renderable component to be visible or invisible based on the player's
/// total amount of damage.
/// </summary>
public class PlayerHpBehaviour : MonoBehaviour
{
	/// <summary>
	/// The amount of damage the player must have for this UI element to appear
	/// or disappear.
	/// </summary>
	public int m_renderDamage;
	
	/// <summary>
	/// True if this UI element should be hidden when the player's damage is at
	/// least m_renderDamage.
	/// </summary>
	public bool m_hideWhenDead = true;
	
	private bool doCoroutine = true;
	
	void Update ()
	{
		if(State.player.Damage >= m_renderDamage) {
			if(doCoroutine) {
				StartCoroutine(StartTransitionAnim());
				doCoroutine = false;
			}
		} else {
			renderer.enabled = m_hideWhenDead;
			doCoroutine = true;
		}
	}
	
	IEnumerator StartTransitionAnim()
	{
		for(int i = 0; i < 4; i++) {
			renderer.enabled = !m_hideWhenDead;
			yield return new WaitForSeconds(0.1f);
			renderer.enabled = m_hideWhenDead;
			yield return new WaitForSeconds(0.1f);
		}
		renderer.enabled = !m_hideWhenDead;
	}
}
