#pragma warning disable 618

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /*
		Will fix later
	 */
    public float _moveSpeed = 4.5f;
    public Rigidbody2D rb2d;
    Vector3[] positions = new Vector3[2];

    public Material portalFire;

    Vector2 target;

    float v, h;

    RaycastHit2D hit;

    public Transform _gunNozzle;

    public LayerMask _wallMask;

    [ColorUsage(true, true)] public Color _portal1Col;

    [ColorUsage(true, true)] public Color _portal2Col;

    Vector3 _portalSpawnPos;

    GameObject[] portals = new GameObject[2];

    public GameObject _portal;

    void Update()
    {
        Move();
        ShootPortal();
    }

    void Move()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        target = new Vector2(v, h).normalized;

        if (v != 0f || h != 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg), Time.deltaTime * 10f);
            rb2d.velocity = transform.up * _moveSpeed * Time.fixedDeltaTime;
        }
        else
            rb2d.velocity = Vector3.zero;
    }

    void ShootPortal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnPortal(0));
        }
        else if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(SpawnPortal(1));
        }
    }

    IEnumerator SpawnPortal(int portal)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(_gunNozzle.position, (mousePos - (Vector2)_gunNozzle.position).normalized, Mathf.Infinity, _wallMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 15 || hit.collider.gameObject.layer == 16)
                yield break;
            positions[1] = hit.point;
            _portalSpawnPos = hit.point;
        }
        else
            yield break;
        if (portals[portal] != null)
            GameObject.Destroy(portals[portal]);
        LineRenderer rend = new GameObject().AddComponent<LineRenderer>();
        positions[0] = _gunNozzle.position;
        rend.SetWidth(0.113f, 0.113f);
        rend.material = portalFire;
        rend.alignment = LineAlignment.TransformZ;
        rend.numCapVertices = 10;
        rend.SetPositions(positions);
        portals[portal] = GameObject.Instantiate(_portal, _portalSpawnPos, Quaternion.identity) as GameObject;
        portals[portal].transform.up = hit.normal;
        portals[portal].GetComponent<FollowParent>().parent = hit.transform;
        portals[portal].GetComponent<FollowParent>().localPos = hit.transform.InverseTransformPoint(portals[portal].transform.position);
        portals[portal].GetComponent<FollowParent>().localRot = Quaternion.Inverse(hit.transform.rotation) * portals[portal].transform.rotation;
        if (portal == 0)
        {
            if (portals[1] != null)
            {
                portals[portal].GetComponent<PortalScript>()._otherPortal = portals[1];
                portals[1].GetComponent<PortalScript>()._otherPortal = portals[0];
            }
                
        }
        else
        {
            if (portals[0] != null)
            {
                portals[portal].GetComponent<PortalScript>()._otherPortal = portals[0];
                portals[0].GetComponent<PortalScript>()._otherPortal = portals[1];
            }
        }
        switch (portal)
        {
            case 0:
                rend.material.SetColor("_Color", _portal1Col);
                portals[portal].GetComponent<Renderer>().material.SetColor("_Color", _portal1Col);
                break;
            case 1:
                rend.material.SetColor("_Color", _portal2Col);
                portals[portal].GetComponent<Renderer>().material.SetColor("_Color", _portal2Col);
                break;
        }

        yield return new WaitForSeconds(0.094f);
        GameObject.Destroy(rend.gameObject);
    }
}
