using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager camManager;

    public GameObject Target;

    public float offsetX = 0.0f;
    public float offsetY = 10.0f;
    public float offsetZ = -20.0f;

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    //농작물 땅 설치시 카메라 상태
    public bool PlaneCam = false;

    private void Awake()
    {
        camManager = this;
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        //씬전환이 완료되었을때
        if(GameManager.instance.SceneSet)
        {
            if (PlaneCam == true)
            {
                Target = GameManager.instance.TouchPos;

                offsetX = 0.0f;
                offsetY = 30.0f;
                offsetZ = -50.0f;
                CameraSpeed = 30.0f;
            }
            else
            {
                Target = GameManager.instance.Player;
                offsetX = 0.0f;
                offsetY = 10.0f;
                offsetZ = -20.0f;
                CameraSpeed = 10.0f;
            }

            if(Target != null)
            {
                TargetPos = new Vector3(
                        Target.transform.position.x + offsetX,
                        Target.transform.position.y + offsetY,
                        Target.transform.position.z + offsetZ
                        );

                transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
            }
        }
        
    }
}
