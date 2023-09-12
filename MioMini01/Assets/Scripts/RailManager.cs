using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailManager : MonoBehaviour
{
    public Image rail01;
    public Image rail02;
    public Image rail03;

    public float speed;

    Vector2 startPos01;
    Vector2 startPos02;
    Vector2 startPos03;

    public float offset01;
    public float offset02;
    public float offset03;

    public float posValue01;
    public float posValue02;
    public float posValue03;

    private void Start()
    {
        startPos01 = rail01.transform.position;
        startPos02 = rail02.transform.position;
        startPos03 = rail03.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset01 = Mathf.Repeat(Time.time * speed, posValue01);
        rail01.transform.position = startPos01 + Vector2.right * offset01;
    }
}
