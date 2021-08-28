using UnityEditor;
using UnityEngine;

namespace Mother
{
    [CustomEditor(typeof(MotherVision))]
    public class MotherVisionEditor : Editor
    {
        private void OnSceneGUI()
        {
            MotherVision fov = (MotherVision) target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

            Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, +fov.angle / 2);

            Handles.color = Color.yellow;
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

            if (fov.canSeePlayer)
            {
                Handles.color = Color.green;
                Handles.DrawLine(fov.transform.position, fov.player.position);
            }
        }

        private Vector3 DirectionFromAngle(float eulerY, float anglesInDegrees)
        {
            anglesInDegrees += eulerY;

            return new Vector3(Mathf.Sin(anglesInDegrees * Mathf.Deg2Rad), 0,
                Mathf.Cos(anglesInDegrees * Mathf.Deg2Rad));
        }
    }
}