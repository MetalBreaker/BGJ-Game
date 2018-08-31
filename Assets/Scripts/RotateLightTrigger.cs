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

    public Color reqColor = Color.white;

    int numLights = 0;

    [SerializeField]
    float speed = 55f;

    void Start()
    {
        if (reqColor != Color.white)
        {
            GetComponent<SpriteRenderer>().color = reqColor;
        }
    }

    void OnTriggerEnter2D(Collider2D _col2d)
    {
        if (reqColor != Color.white)
        {
            if (_col2d.gameObject.GetComponent<LineRenderer>().material.color != reqColor * LightSourceScript._col)
                return;
        }
        numLights++;
        _quatRestingRot = Quaternion.Euler(_restingRot);
        _quatRot = Quaternion.Euler(_onRot);
    }

    void OnTriggerExit2D(Collider2D _col2d)
    {
        if (reqColor != Color.white)
        {
            if (_col2d.gameObject.GetComponent<LineRenderer>().material.color != reqColor * LightSourceScript._col)
                return;
        }
        numLights--;
        _quatRestingRot = Quaternion.Euler(_restingRot);
        _quatRot = Quaternion.Euler(_onRot);
    }

    void Update()
    {
        _obj.rotation = Quaternion.RotateTowards(_obj.rotation, (numLights > 0) ? _quatRot : _quatRestingRot, speed * Time.deltaTime);
    }
}