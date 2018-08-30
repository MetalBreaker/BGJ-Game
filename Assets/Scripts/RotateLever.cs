using UnityEngine;

public class RotateLever : MonoBehaviour
{
    [SerializeField]
    Transform _obj;

    [SerializeField]
    Vector3 _restingRot;

    [SerializeField]
    Vector3 _onRot;

    Quaternion _quatRestingRot;

    Quaternion _quatRot;

    bool state = false;

    [SerializeField]
    float speed = 55f;

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = !state;
            _quatRestingRot = Quaternion.Euler(_restingRot);
            _quatRot = Quaternion.Euler(_onRot);
        }
            
    }

    void Update()
    {
        _obj.rotation = Quaternion.RotateTowards(_obj.rotation, (state) ? _quatRot : _quatRestingRot, speed * Time.deltaTime);
    }
}