using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 moveVec;
    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.SceneSet)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("isEat");
                //StartCoroutine(ResetToIdleAfterAnimation("isEat"));
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    animator.SetTrigger("isRun");
                    StartCoroutine(ResetToIdleAfterAnimation("isRun"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    animator.SetTrigger("isRun2");
                    StartCoroutine(ResetToIdleAfterAnimation("isRun2"));
                }
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("isCraft");
                //StartCoroutine(ResetToIdleAfterAnimation("isCraft"));
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    animator.SetTrigger("isFishing1");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing1"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    animator.SetTrigger("isFishing2");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing2"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    animator.SetTrigger("isFishing3");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing3"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    animator.SetTrigger("isFishing4");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing4"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    animator.SetTrigger("isFishing5");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing5"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    animator.SetTrigger("isFishing6");
                    StartCoroutine(ResetToIdleAfterAnimation("isFishing6"));
                }
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("isGrab");
                StartCoroutine(ResetToIdleAfterAnimation("isGrab"));
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                animator.SetTrigger("isHi");
                StartCoroutine(ResetToIdleAfterAnimation("isHi"));
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("isJump");
                StartCoroutine(ResetToIdleAfterAnimation("isJump"));
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    animator.SetTrigger("isTree2");
                    StartCoroutine(ResetToIdleAfterAnimation("isTree2"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    animator.SetTrigger("isTree3");
                    StartCoroutine(ResetToIdleAfterAnimation("isTree3"));
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    animator.SetTrigger("isTree4");
                    StartCoroutine(ResetToIdleAfterAnimation("isTree4"));
                }
            }else if(Input.GetKeyDown(KeyCode.I))
            {
                animator.SetTrigger("IdleTrigger");
            }

            float x = GameManager.instance.stick.Horizontal;
            float z = GameManager.instance.stick.Vertical;

            moveVec = new Vector3(x, 0, z) * PlayerAct.playerAct.PlayerSpeed * Time.deltaTime * 0.4f;

            if (CameraManager.camManager.PlaneCam == true)
            {

                moveVec =
                    new Vector3(Mathf.Round(moveVec.x), Mathf.Round(moveVec.z));

                GameManager.instance.TouchPos.transform.position = moveVec;

            }
            else
            {

                CameraManager.camManager.Target.GetComponent<Rigidbody>().MovePosition(CameraManager.camManager.Target.GetComponent<Rigidbody>().position + moveVec);

            }
            //left:x- , right:x+ 
            if(x != 0)
            {
                if(x > 0)
                {
                    this.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    this.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                animator.SetBool("ismove", true);
            }
            else
            {
                animator.SetBool("ismove", false);
            }

            if (moveVec.sqrMagnitude == 0) return;

            
        }
       

    }

    private IEnumerator ResetToIdleAfterAnimation(string triggerName)
    {
        //현재 재생 중인 애니메이션 상태 정보 가져오기
        AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo(0);

        //애니메이션이 재생되는 동안 대기
        while (currentAnimation.normalizedTime < 1.0f)
        {
            currentAnimation = animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        //idle 상태로 돌아가기
        //animator.SetTrigger("IdleTrigger");
    }
}
