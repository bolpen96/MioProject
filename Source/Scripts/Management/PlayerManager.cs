using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerAct.playerAct.triggerObj = other.gameObject;

        if (other.name == "RedFlower")
        {
            PlayerAct.playerAct.inObject = GameManager.instance.Flower[0];
        }
        else if(other.name == "YellowFlower")
        {
            PlayerAct.playerAct.inObject= GameManager.instance.Flower[1];
        }
        else if (other.name == "Tree1")
        {
            PlayerAct.playerAct.inObject = GameManager.instance.Tree[0];
        }
        else if (other.name == "Tree2")
        {
            PlayerAct.playerAct.inObject = GameManager.instance.Tree[1];
        }
        else
        {
            PlayerAct.playerAct.inObject = null;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerAct.playerAct.triggerObj = null;
        PlayerAct.playerAct.inObject = null;
    }

}
