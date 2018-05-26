using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{
    private void OnSceneGUI()
    {
        var line = target as Line;
        Transform handleTransform = line.transform;
        var handlerRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        var p0 = handleTransform.TransformPoint(line._p0);
        var p1 = handleTransform.TransformPoint(line._p1);

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);

		EditorGUI.BeginChangeCheck();
		p0 = Handles.DoPositionHandle(p0, handlerRotation);
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line._p0 = handleTransform.InverseTransformPoint(p0);
		}

		EditorGUI.BeginChangeCheck();
		p1 = Handles.DoPositionHandle(p1, handlerRotation);
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line._p1 = handleTransform.InverseTransformPoint(p1);
		}

    }
}
