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

    public int numLights = 0;

    void OnTriggerEnter2D()
    {
        numLights++;
    }

    void OnTriggerExit2D()
    {
        numLights--;
    }

    void Update()
    {
        _obj.position = Vector3.MoveTowards(_obj.position, (numLights > 0) ? _onPosChange : _restingPos, speed * Time.deltaTime);
    }
}