using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightSourceScript : MonoBehaviour 
{
	public LayerMask _raycastMask;

	public LineRenderer _lineRend;

	Vector3[] positions = new Vector3[2];

	RaycastHit2D _hit2d;

	[ColorUsage(true, true)] public static Color _col = new Color(1.304f, 1.304f, 1.304f, 1f);

	public BoxCollider2D bc2d;

	public Color _lightColor = Color.white;

	GameObject _go;

	void Start()
	{
		_lineRend.material.SetColor("_Color", _lightColor * _col);
		_go = gameObject;
	}

	void Update()
	{
		_hit2d = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity, _raycastMask);
		if (PortalScript.dict.ContainsKey(_go) && _hit2d.transform.gameObject.name == "Portal(Clone)")
		{
			if (PortalScript.dict[_go] != null)
			{
				PortalScript.dict[_go].transform.localPosition = _hit2d.transform.InverseTransformPoint(_hit2d.point);
			}
		}
		positions[0] = transform.position;
		positions[1] = _hit2d.point;
		_lineRend.SetPositions(positions);
		bc2d.offset = transform.InverseTransformPoint(positions[1]);
	}
}
