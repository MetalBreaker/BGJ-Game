using UnityEngine;

public class RotateLightTrigger : MonoBehaviour
{
    [SerializeField]
    Transform _obj;

    [SerializeField]
    Vector3 _restingRot;

    [SerializeField]
    Vector3 _onRot;

    Quaternion _quatRestingRot;

    Quaternion _quatRot;

    int numLights = 0;

    [SerializeField]
    float speed = 55f;

    void OnTriggerEnter2D()
    {
        numLights++;
        _quatRestingRot = Quaternion.Euler(_restingRot);
        _quatRot = Quaternion.Euler(_onRot);
    }

    void OnTriggerExit2D()
    {
        numLights--;
        _quatRestingRot = Quaternion.Euler(_restingRot);
        _quatRot = Quaternion.Euler(_onRot);
    }

    void Update()
    {
        _obj.rotation = Quaternion.RotateTowards(_obj.rotation, (numLights > 0) ? _quatRot : _quatRestingRot, speed * Time.deltaTime);
    }
}