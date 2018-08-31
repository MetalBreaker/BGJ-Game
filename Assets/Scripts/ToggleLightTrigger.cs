using UnityEngine;
using System.Collections;

public class ToggleLightTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject _obj;

    int numLights = 0;

    public Color reqColor = Color.white;

    public bool startState = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = reqColor;
        _obj.SetActive(startState);
    }

    void OnTriggerEnter2D(Collider2D _col2d)
    {
        if (reqColor != Color.white)
        {
            if (_col2d.gameObject.GetComponent<LightSourceScript>()._lightColor != reqColor)
                return;
        }
        numLights++;
    }

    void OnTriggerExit2D(Collider2D _col2d)
    {
        if (reqColor != Color.white)
        {
            if (_col2d.gameObject.GetComponent<LightSourceScript>()._lightColor != reqColor)
                return;
        }
        numLights--;
    }

    void Update()
    {
       if (numLights > 0 && _obj.activeSelf != !startState)
       {
           if (!startState == false)
           {
               StartCoroutine(DisableLight());
           }
           else
               _obj.SetActive(true);
       }
       else if (numLights == 0 && _obj.activeSelf != startState)
       {
           if (startState == false)
           {
               StartCoroutine(DisableLight());
           }
           else
               _obj.SetActive(true);
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