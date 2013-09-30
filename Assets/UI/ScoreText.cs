using UnityEngine;
using System.Collections;

/// <summary>
/// Sets a text mesh to display the player's score.
/// </summary>
[RequireComponent(typeof(tk2dTextMesh))]
public class ScoreText : MonoBehaviour
{
	private tk2dTextMesh mesh;
	
	void Start()
	{
		mesh = GetComponent<tk2dTextMesh>();
	}
	
	void Update ()
	{
		mesh.text = ""+State.score;
	}
}
