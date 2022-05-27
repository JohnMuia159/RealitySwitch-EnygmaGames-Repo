using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionOneActive : MonoBehaviour
{
    private DimensionSwap player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<DimensionSwap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dim2)
        {
            gameObject.SetActive(false);
        }

        
    }

    public void ResetActive()
    {
        gameObject.SetActive(true);
    }
}
