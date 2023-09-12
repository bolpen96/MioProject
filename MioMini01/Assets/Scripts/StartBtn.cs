using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public TMP_InputField inf;
    public Button start_Btn;

   public void OnClick()
   {
        GameManager.Instance.State = 2;
        GameManager.Instance.PlayerName = inf.text;
        SceneManager.LoadScene(1);
   }
    
}
