using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject _door;
    public HingeJoint2D _hingeJoint;
    public float _rotationAngle;

    private Animator _doorAnim;

    private void Start()
    {
        _doorAnim = _door.GetComponent<Animator>();
    }

    private void Update()
    {
        float angle = _hingeJoint.jointAngle;
        if (angle > _rotationAngle)
        {
            Collider2D colliderToDisable = _door.GetComponent<Collider2D>();
            colliderToDisable.enabled = false;
            _doorAnim.SetTrigger("Play");
        }
        else if (angle < -_rotationAngle)
        {
            Collider2D colliderToDisable = _door.GetComponent<Collider2D>();
            colliderToDisable.enabled = true;
            _doorAnim.SetTrigger("Play2");
        }
    }
}
