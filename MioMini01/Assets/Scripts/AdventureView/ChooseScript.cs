using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBtn : MonoBehaviour
{
    public void Onclick()
    {
        StoryManager.instance.ckNum = this.transform.GetSiblingIndex();

        StoryManager.instance.ChooseOne();
    }
}
