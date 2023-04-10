using UnityEngine;

public class WindGenerator : MonoBehaviour
{
    [SerializeField] Vector3 _velocity;

    private WindSource _windSource;
    private WindStream _windStream;

    public void OnEnable()
    {
        _windSource = GetComponentInChildren<WindSource>(includeInactive: true);
        _windStream = GetComponentInChildren<WindStream>(includeInactive: true);

        _windStream.Velocity = _velocity;
    }

    public void TurnOn()
    {
        _windSource?.OnTurningOn();
        _windStream?.OnTurningOn();
    }

    public void TurnOff()
    {
        _windSource?.OnTurningOff();
        _windStream?.OnTurningOff();
    }
}
