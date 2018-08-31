using UnityEngine;

public class MoveLightTrigger : MonoBehaviour
{
    [SerializeField]
    Transform _obj;

    [SerializeField]
    Vector2 _restingPos;

    [SerializeField]
    Vector2 _onPosChange;

    [SerializeField]
    float speed = 3f;

    int numLights = 0;

    public Color reqColor = Color.white;

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
    }

    void OnTriggerExit2D(Collider2D _col2d)
    {
        if (reqColor != Color.white)
        {
            if (_col2d.gameObject.GetComponent<LineRenderer>().material.color != reqColor * LightSourceScript._col)
                return;
        }
        numLights--;
    }

    void Update()
    {
        _obj.position = Vector3.MoveTowards(_obj.position, (numLights > 0) ? _onPosChange : _restingPos, speed * Time.deltaTime);
    }
}