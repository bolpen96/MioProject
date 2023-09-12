using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public InputField inf;
    public Button start_Btn;

   public void OnClick()
   {
        GameManager.Instance.State = 2;
        GameManager.Instance.PlayerName = inf.text;
        LoadingManager.LoadScene(GameManager.Instance.State);
   }
    
}
