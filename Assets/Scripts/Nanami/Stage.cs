using UnityEngine;

public class RotateLocalAxis : MonoBehaviour
{
    public void RotateStage(float rotationSpeed)
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}