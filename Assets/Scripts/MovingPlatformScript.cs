using UnityEngine;
public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField]
    Vector3 _leftBound;

    [SerializeField]
    Vector3 _rightBound;

    [SerializeField]
    float speed = 2.55f;

    bool dir = true;

    void Update()
    {
        if (dir)
        {
            if (transform.position == _rightBound)
                dir = false;
        }
        else
        {
            if (transform.position == _leftBound)
                dir = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, (dir) ? _rightBound : _leftBound, speed * Time.deltaTime);
    }
}