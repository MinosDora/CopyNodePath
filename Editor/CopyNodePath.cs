using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class CopyNodePath
{
	[MenuItem("GameObject/Copy Node Path", false, 0)]
	public static void CopyNodePathFunc()
	{
		string nodePath = "";
		if (Selection.activeGameObject != null)
		{
			GetNodePath(Selection.activeGameObject.transform, ref nodePath);
			TextEditor textEditor = new TextEditor();
			textEditor.text = nodePath;
			textEditor.SelectAll();
			textEditor.Copy();
			Debug.Log("Copy Node Path: " + nodePath);
		}
	}

	private static void GetNodePath(Transform trans, ref string path)
	{
		path = path == "" ? trans.name : trans.name + "/" + path;
		if (trans.parent != null && trans.parent.parent != null)
		{
			GetNodePath(trans.parent, ref path);
		}
	}
}
