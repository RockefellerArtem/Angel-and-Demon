using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject _door;
    public HingeJoint2D _hingeJoint;
    public float _rotationAngle;
    public bool _invert;

    private Animator _doorAnim;
    private int chet = 0;
    private int invert = 1;
    private void Start()
    {
        if (_invert == true) { invert = -1; }
        _doorAnim = _door.GetComponent<Animator>();
    }

    private void Update()
    {
        float angle = _hingeJoint.jointAngle;
        if (invert * angle > _rotationAngle && chet == 0)
        {
            chet = 1;
            Collider2D colliderToDisable = _door.GetComponent<Collider2D>();
            colliderToDisable.enabled = false;
            _doorAnim.SetTrigger("Play");
        }
        else if (invert * angle < -_rotationAngle && chet == 1)
        {
            chet = 0;
            Collider2D colliderToDisable = _door.GetComponent<Collider2D>();
            colliderToDisable.enabled = true;
            _doorAnim.SetTrigger("Play2");
        }
    }
}
