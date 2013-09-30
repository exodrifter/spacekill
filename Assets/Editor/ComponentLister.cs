using UnityEngine;
using UnityEditor;
using System.Collections;
 
// Thanks to AngryAnt: http://angryant.com/2009/08/31/where-did-that-component-go/
public class ComponentLister : EditorWindow
{
	private SortedList sets = new SortedList();
	private Vector2 scrollPosition;
	
	[ MenuItem( "Window/Component Lister" ) ]
	public static void Launch()
	{
		EditorWindow window = GetWindow( typeof( ComponentLister ) );
		window.Show();
	}

	public void UpdateList()
	{
		Object[] objects;

		sets.Clear();

		objects = Resources.FindObjectsOfTypeAll( typeof( Component ) );
		foreach( Component component in objects ) {
			if( !sets.ContainsKey( component.GetType().Name ) ) {
				sets[ component.GetType().Name ] = new ArrayList();
			}

			( ( ArrayList )sets[ component.GetType().Name ] ).Add( component.gameObject );
		}
	}

	public void OnGUI()
	{
		GUILayout.BeginHorizontal( GUI.skin.GetStyle( "Box" ) );
		GUILayout.Label( "Components in scene:" );
		GUILayout.FlexibleSpace();

		if( GUILayout.Button( "Refresh" ) ) {
			UpdateList();
		}
		GUILayout.EndHorizontal();

		scrollPosition = GUILayout.BeginScrollView(scrollPosition);

		foreach( string name in sets.Keys ) {
			GUILayout.Label( name + ":" );
			foreach( GameObject gameObject in ( ArrayList )sets[ name ] ) {
				if( gameObject != null && GUILayout.Button( gameObject.name ) ) {
					Selection.activeObject = gameObject;
				}
			}
		}

		GUILayout.EndScrollView();
	}
}