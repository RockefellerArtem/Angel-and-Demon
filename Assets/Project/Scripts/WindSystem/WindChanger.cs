using UnityEngine;

public class WindChanger : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;

    public void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
}
