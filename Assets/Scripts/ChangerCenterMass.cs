using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ChangerCenterMass : MonoBehaviour
{
    [SerializeField]
    private Vector3 [] _points;

    private Rigidbody2D _rigidbody2D;
    public void Generate()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if (_points.Length == 1)
            _rigidbody2D.centerOfMass = _points[0];
        else
        {
            var centerMass = CenterMass.Points(_points);
            _rigidbody2D.centerOfMass = centerMass;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (_rigidbody2D)
            Gizmos.DrawSphere(_rigidbody2D.worldCenterOfMass, 0.1f);
    }

}
/*
[CustomEditor(typeof(ChangerCenterMass))]
class ChangerCenterMassEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ChangerCenterMass script = (ChangerCenterMass)target;

        if (GUILayout.Button("Change Center Mass"))
            script.Generate();

    }
}
*/