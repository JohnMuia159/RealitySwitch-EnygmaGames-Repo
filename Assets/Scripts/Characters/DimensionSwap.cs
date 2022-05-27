using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DimensionSwap : MonoBehaviour
{

    GameObject[] d1;
    GameObject[] d2;

    public bool dim1 = true;
    public bool dim2 = false;
    private bool dim1Reset = true;
    private bool dim2Reset = false;

    // Start is called before the first frame update
    void Start()
    {
        d1 = GameObject.FindGameObjectsWithTag("D1");
        d2 = GameObject.FindGameObjectsWithTag("D2");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            dim1 = !dim1;
            dim2 = !dim2;
            CameraShaker.Instance.ShakeOnce(4f, 2f, 0.1f, 1f);
        }
        if (dim1 && !dim1Reset)
        {
            for (int i = 0; i < d1.Length; i++)
            {
                d1[i].GetComponent<DimensionOneActive>().ResetActive();
            }
            dim1Reset = true;
            dim2Reset = false;
        }
        if (dim2 && !dim2Reset)
        {
            for (int i = 0; i < d2.Length; i++)
            {
                d2[i].GetComponent<DimensionTwoActive>().ResetActive();
            }
            dim2Reset = true;
            dim1Reset = false;
        }
    }
}
