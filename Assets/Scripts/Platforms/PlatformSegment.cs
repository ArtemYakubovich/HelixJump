using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    public void Bounce(float force, Vector3 center, float radius)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, center, radius);
        }
    }
    
}
