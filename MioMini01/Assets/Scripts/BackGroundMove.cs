using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    Transform tr;
    float x;
    float y;
    private void Start()
    {
        tr = this.transform;
        x = Time.deltaTime * 10f;
        y = Time.deltaTime * 10f;

    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == 1)
        {
            tr.Translate(x, y, 0);

            if (tr.localPosition.x < -118 || tr.localPosition.x > 118)
            {
                x = -x;
            }
            else if(tr.localPosition.y < -205 || tr.localPosition.y > 205)
            {
                y = -y;
            }

        }
    }
}
