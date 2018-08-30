using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public Transform parent;
    public Vector3 localPos;
    public Quaternion localRot;

    void LateUpdate()
    {
        if (parent != null)
        {
            transform.rotation = parent.rotation * localRot;
            transform.position = parent.TransformPoint(localPos);
        }
    }
}