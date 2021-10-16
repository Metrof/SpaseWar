using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject poi;
    public GameObject[] panels;
    public float scroolSpeed = -30f;

    public float motionMult = 0.25f;

    private float panelHt;
    private float depth;

    private void Start()
    {
        panelHt = panels[0].transform.localScale.x;
        depth = panels[0].transform.position.z;

        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(panelHt, 0, depth);
    }

    private void Update()
    {
        float tX, tY = 0;
        tX = Time.time * scroolSpeed % panelHt + (panelHt * 0.5f);

        if (poi != null)
        {
            tY = -poi.transform.position.x * motionMult;
        }

        panels[0].transform.position = new Vector3(tX, tY, depth);

        if (tX >= 0)
        {
            panels[1].transform.position = new Vector3(tX - panelHt, tY, depth);
        } else
        {
            panels[1].transform.position = new Vector3(tX + panelHt, tY, depth);
        }
    }

}
