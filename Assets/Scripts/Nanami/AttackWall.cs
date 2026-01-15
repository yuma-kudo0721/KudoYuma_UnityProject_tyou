using UnityEngine;

public class ZAxisAcceleration : MonoBehaviour
{
    public float initialVelocityZ = 1.0f;
    public float accelerationZ = 1.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbodyコンポーネントがアタッチされていません。");
            enabled = false;
            return;
        }

        Vector3 initialVelocity = new Vector3(0, 0, initialVelocityZ);
        rb.linearVelocity = initialVelocity;
    }

    void FixedUpdate()
    {
        Vector3 accelerationForce = new Vector3(0, 0, accelerationZ);
        rb.AddForce(accelerationForce, ForceMode.Acceleration);
    }
}