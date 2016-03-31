using UnityEngine;
using System.Collections;
using UnityEditor;


/**
 * [XBaseWindow 基础类]
 * @type {[◑▂◑]}
 */
using System;
using Object = UnityEngine.Object;
using System.IO;


public class XBaseWindow : EditorWindow, IHasCustomMenu
{

	internal Vector2 _scrollPos = Vector2.zero;
	const int Xoffset = 5;
	const int XButtonWidth = 100;
	const int XButtonHeight = 20;

	public static T InitWindow<T>() where T : XBaseWindow
	{
		string cmdPrefs = typeof( T ).ToString() + "_isPrefix";
		bool isPrefix = EditorPrefs.GetBool( cmdPrefs, false );
		T window = EditorWindow.GetWindow<T>( isPrefix, typeof( T ).Name );
		window.OnInitialization();
		return window;
	}

	public virtual void OnInitialization(params object[] args)
	{
	}

	public static void DrawLogo(GUILayoutOption widthLayout)
	{
		GUILayout.Box( XResources.LogoTexture, widthLayout, GUILayout.Height( 100 ) );
	}

	public void OnGUI()
	{
		DrawLogo( GUILayout.ExpandWidth( true ) );
		if( GUI.Button( GUILayoutUtility.GetLastRect(), XResources.LogoTexture ) ) {
			this.Close();
			string cmdPrefs = GetType().ToString() + "_isPrefix";
			bool isPrefix = EditorPrefs.GetBool( cmdPrefs, false );
			EditorPrefs.SetBool( cmdPrefs, !isPrefix );
			XBaseWindow window = EditorWindow.GetWindow( GetType(), !isPrefix, GetType().Name, true ) as XBaseWindow;
			window.OnInitialization( closeRecordArgs );
			return;

		}
		if( IsAutoScroll )
			_scrollPos = EditorGUILayout.BeginScrollView( _scrollPos );

		OnXGUI();

		if( IsAutoScroll )
			EditorGUILayout.EndScrollView();
	}

	public virtual bool IsAutoScroll {
		get {
			return true;
		}
	}

	public virtual object[] closeRecordArgs {
		get;
		set;
	}

	public virtual void OnXGUI()
	{
    
	}

	public void CreateSpaceBox()
	{
		GUILayout.Box( "", GUILayout.Width( this.position.width - Xoffset ), GUILayout.Height( 3 ) );
	}

	public static bool CreateSpaceButton(string btnName, float width = XButtonWidth)
	{
		return GUILayout.Button( btnName, GUILayout.ExpandWidth( true ) );
	}

	public static void DoButton(string btnName, Action callback)
	{
		if( GUILayout.Button( btnName, GUILayout.ExpandWidth( true ) ) ) {
			callback();
		}
	}

	public static void DoButton(string btnName, Action callback, GUIStyle style)
	{
		if( GUILayout.Button( btnName, style, GUILayout.ExpandWidth( true ) ) ) {
			callback();
		}
	}

	public static void DoButton(GUIContent content, Action callback, params GUILayoutOption[] options)
	{
		if( GUILayout.Button( content, options ) ) {
			callback();
		}
	}

	public static void DoButton<T>(string btnName, Action<T> callback, T arg)
	{
		if( GUILayout.Button( btnName, GUILayout.ExpandWidth( true ) ) ) {
			callback( arg );
		}
	}

	public static void DoButton<T, T1>(string btnName, Action<T, T1> callback, T arg, T1 arg1)
	{
		if( GUILayout.Button( btnName, GUILayout.ExpandWidth( true ) ) ) {
			callback( arg, arg1 );
		}
	}

	public static Object CreateObjectField(string fieldName, Object obj, System.Type type = null, params GUILayoutOption[] options)
	{
		if( null == type )
			type = typeof( Object );
		return EditorGUILayout.ObjectField( fieldName, obj, type, true, options ) as Object;
	}

	public static Object CreateObjectField(Object obj, System.Type type = null)
	{
		if( null == type )
			type = typeof( Object );
		return EditorGUILayout.ObjectField( obj, type, true ) as Object;
	}

	public static bool CreateCheckBox(string fieldName, bool value)
	{
		return EditorGUILayout.Toggle( fieldName, value );
	}

	public static bool CreateCheckBox(bool value)
	{
		return EditorGUILayout.Toggle( value );
	}

	public static float CreateFloatField(string fieldName, float value)
	{
		return EditorGUILayout.FloatField( fieldName, value );
	}

	public static float CreateFloatField(float value)
	{
		return EditorGUILayout.FloatField( value );
	}

	public static int CreateIntField(int value)
	{
		return EditorGUILayout.IntField( value );
	}

	public static int CreateIntField(string fieldName, int value)
	{
		return EditorGUILayout.IntField( fieldName, value );
	}

	public static string CreateStringField(string fieldName, string value)
	{
		return EditorGUILayout.TextField( fieldName, value );
	}

	public static string CreateStringField(string value)
	{
		return EditorGUILayout.TextField( value );
	}

	public static void CreateLabel(string fieldName, bool canSelect = false)
	{
		if( canSelect )
			EditorGUILayout.SelectableLabel( fieldName );
		else
			EditorGUILayout.LabelField( fieldName );
	}

	public static void CreateLabel(string fieldName, string value, bool canSelect = false)
	{
		if( canSelect )
			EditorGUILayout.SelectableLabel( fieldName, value );
		else
			EditorGUILayout.LabelField( fieldName, value );
	}

	public static void CreateMessageField(string value, MessageType type)
	{
		EditorGUILayout.HelpBox( value, type );
	}

	public static System.Enum CreateEnumSelectable(System.Enum value)
	{
		return EditorGUILayout.EnumPopup( value );
	}

	public static System.Enum CreateEnumSelectable(string fieldName, System.Enum value)
	{
		return EditorGUILayout.EnumPopup( fieldName, value );
	}

	public static System.Enum CreateEnumPopup(string fieldName, System.Enum value)
	{
		return EditorGUILayout.EnumMaskField( fieldName, value );
	}

	public static System.Enum CreateEnumPopup(System.Enum value)
	{
		return EditorGUILayout.EnumMaskField( value );
	}

	public static int CreateSelectableFromString(int rootID, string[] array)
	{
		return EditorGUILayout.Popup( array[rootID], rootID, array );
	}

	public static int CreateSelectableString(int rootID, string[] array)
	{
		return EditorGUILayout.Popup( rootID, array );
	}

	public static void BeginHorizontal()
	{
		EditorGUILayout.BeginHorizontal();
	}

	public static void EndHorizontal()
	{
		EditorGUILayout.EndHorizontal();
	}

	public static void BeginVertical()
	{
		EditorGUILayout.BeginVertical();
	}

	public static void EndVertical()
	{
		EditorGUILayout.EndVertical();
	}

	public static void DisableFragment(bool isDisable, Action action)
	{
		EditorGUI.BeginDisabledGroup( true );
		action();
		EditorGUI.EndDisabledGroup();
	}

	public void CreateNotification(string message)
	{
		ShowNotification( new GUIContent( message ) );
	}

	public virtual void AddItemsToMenu(GenericMenu menu)
	{
		menu.AddItem( new GUIContent( "OpenEditorScript" ), false, OpenEditorScript, "FuckThisWindow" );
		menu.ShowAsContext();
	}

	void OpenEditorScript(object handle)
	{
		string type = this.GetType().Name;
		string absolutelyPath = FindFile( type, "Assets" );

		Object[] obj = AssetDatabase.LoadAllAssetsAtPath( absolutelyPath );
		AssetDatabase.OpenAsset( obj );

	}

	static String FindFile(String filename, String path)
	{
		if( Directory.Exists( path ) ) {
			if( File.Exists( path + "/" + filename + ".cs" ) )
				return path + "/" + filename + ".cs";
			String[] directorys = Directory.GetDirectories( path );
			foreach( String d in directorys ) {
				string str = d.Replace( '\\', '/' );
				String p = FindFile( filename, str );
				if( p != null )
					return p;
			}
		}
		return null;
	}
}

