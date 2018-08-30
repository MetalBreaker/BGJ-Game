using UnityEngine;

public class MoveLever : MonoBehaviour
{
    [SerializeField]
    Transform _obj;

    [SerializeField]
    Vector2 _restingPos;

    [SerializeField]
    Vector2 _onPosChange;

    bool state = false;

    [SerializeField]
    float speed = 3f;

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = !state;
        }
    }

    void Update()
    {
        _obj.position = Vector3.MoveTowards(_obj.position, (state) ? _onPosChange : _restingPos, speed * Time.deltaTime);
    }
}