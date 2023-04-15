using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject _doorOrFan;
    public HingeJoint2D _hingeJoint;
    public float _rotationAngle;
    public bool _invert;
    public bool _door;
    public bool _fan;

    private Animator _doorAnim;
    private int chet = 0;
    private int invert = 1;
    private void Start()
    {
        if (_invert == true) { invert = -1; }
        if (_door == true) { 
        _doorAnim = _doorOrFan.GetComponent<Animator>();
            }
    }

    private void Update()
    {
        float angle = _hingeJoint.jointAngle;
        if (_door == true)
        {
            if (invert * angle > _rotationAngle && chet == 0)
            {
                chet = 1;
                Collider2D colliderToDisable = _doorOrFan.GetComponent<Collider2D>();
                colliderToDisable.enabled = false;
                _doorAnim.SetTrigger("Play");
            }

            else if (invert * angle < -_rotationAngle && chet == 1)
            {
                chet = 0;
                Collider2D colliderToDisable = _doorOrFan.GetComponent<Collider2D>();
                colliderToDisable.enabled = true;
                _doorAnim.SetTrigger("Play2");
            }
        }
        else if (_fan == true)
        {
            if (invert * angle > _rotationAngle && chet == 0)
            {
                chet = 1;
                _doorOrFan.GetComponent <WindGenerator>().TurnOn();
            }

            else if (invert * angle < -_rotationAngle && chet == 1)
            {
                chet = 0;
                _doorOrFan.GetComponent<WindGenerator>().TurnOff();
            }
        }
        
    }
}
