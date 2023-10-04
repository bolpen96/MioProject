using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject obj;
    Color currentColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lerpColor());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator lerpColor()
    {
        float prog = 0;
        float increment = 0.02f / 5;

        while(prog < 1)
        {
            currentColor = Color.Lerp(Color.blue, Color.green, prog);
            obj.GetComponent<Image>().color = currentColor;
            prog += increment;
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }
}
