using UnityEngine;
using System.Collections;

public class ToggleLever : MonoBehaviour
{
    [SerializeField]
    GameObject _obj;

    bool state = false;

    public bool startState = false;

    void Start()
    {
        _obj.SetActive(startState);
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = !state;
        }
    }

    void Update()
    {
        if (state && _obj.activeSelf != !startState)
        {
            if (!startState == false)
            {
                StartCoroutine(DisableLight());
            }
            else
            {
                _obj.SetActive(true);
            }
        }
        else if (!state && _obj.activeSelf != startState)
        {
            if (startState == false)
                StartCoroutine(DisableLight());
            else
            {
                _obj.SetActive(true);
            }
        }
    }

    IEnumerator DisableLight()
    {
        _obj.GetComponent<LineRenderer>().enabled = false;
        _obj.GetComponent<LightSourceScript>().enabled = false;
        _obj.transform.position = PortalScript._oob;
        yield return new WaitForFixedUpdate();
        _obj.SetActive(false);
        _obj.transform.localPosition = PortalScript._localLightPos;
        _obj.GetComponent<LineRenderer>().enabled = true;
        _obj.GetComponent<LightSourceScript>().enabled = true;
    }
}