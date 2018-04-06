using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor
{

	private const float _directionScale = 0.5f;
    private const int _lineStep = 20;
    private BezierCurve _curve;
    private Transform _handlerTransform;
    private Quaternion _handleRotation;

    private void OnSceneGUI()
    {
        _curve = target as BezierCurve;
        _handlerTransform = _curve.transform;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ?
			_handlerTransform.rotation : Quaternion.identity;

        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);

        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p1, p2);

        Handles.color = Color.white;
        Vector3 lineStart = _curve.GetPoint(0f);
		Handles.color = Color.green;
		Handles.DrawLine(lineStart, lineStart+_curve.GetDirection(0f));

        for (int i = 1; i <= _lineStep; i++)
        {
            Vector3 lineEnd = _curve.GetPoint(i / (float)_lineStep);
			Handles.color = Color.white;
            Handles.DrawLine(lineStart, lineEnd);

			Handles.color = Color.green;
			Handles.DrawLine(lineEnd, lineEnd + _curve.GetDirection(i / (float)_lineStep));
            lineStart = lineEnd;
        }

    }


    private Vector3 ShowPoint(int index)
    {
        Vector3 point = _handlerTransform.TransformPoint(_curve._points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, _handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_curve, "Move Point");
            EditorUtility.SetDirty(_curve);
            _curve._points[index] = _handlerTransform.InverseTransformPoint(point);
        }

        return point;

    }
}
