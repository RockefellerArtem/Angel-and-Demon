using UnityEngine;

public class WindStream : MonoBehaviour
{
    public Vector3 Velocity;

    public void OnTurningOn()
    {
        gameObject.SetActive(true);
    }

    public void OnTurningOff()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.TryGetComponent(out WindChanger _))
        {
            otherCollider.transform.position = otherCollider.transform.position + Velocity * Time.deltaTime;
        }
    }
}
