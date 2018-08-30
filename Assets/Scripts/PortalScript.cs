using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour 
{
	public GameObject _otherPortal;

	public static readonly float _offset = 0.01f;

	static readonly Vector3 _scale = new Vector3(0.02f, 0.2f, 1f);

	static readonly Vector3 _rotOffset = new Vector3(0f, 0f, 180f);

	public static Dictionary<GameObject, GameObject> dict = new Dictionary<GameObject, GameObject>();

	void OnTriggerStay2D(Collider2D _col2d)
	{
		if (_otherPortal != null && !_col2d.gameObject.name.Contains("(Clone)"))
		{
			GameObject colObj = _col2d.gameObject;
			if (!dict.ContainsKey(colObj))
			{
				GameObject obj = GameObject.Instantiate(colObj, _otherPortal.transform.position, Quaternion.identity, _otherPortal.transform) as GameObject;
				dict.Add(colObj, obj);
			}
			else if (dict[colObj] == null)
			{
				GameObject obj = GameObject.Instantiate(colObj, _otherPortal.transform.position, Quaternion.identity, _otherPortal.transform) as GameObject;
				dict[colObj] = obj;
			}
			dict[colObj].transform.localScale = _scale;
			dict[colObj].transform.localRotation = Quaternion.Inverse(Quaternion.Euler(transform.eulerAngles - _rotOffset)) * _col2d.transform.rotation;
		}
	}

	void OnTriggerExit2D(Collider2D _col2d)
	{
		if (_otherPortal != null)
		{
			if (dict.ContainsKey(_col2d.gameObject))
			{
				GameObject.Destroy(dict[_col2d.gameObject]);
				dict.Remove(_col2d.gameObject);
			}
		}
	}
}
