using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAct : MonoBehaviour
{
    public static PlayerAct playerAct;
    public GameObject triggerObj;
    public Sprite inObject;
    public float PlayerSpeed;
    public Item item;
    

    private void Awake()
    {
        playerAct = this;
    }

    public void addItem()
    {

        Sprite objSprite = inObject;

        if (inObject && triggerObj)
        {
            item.itemName = objSprite.name;
            item.itemIcon = objSprite;

            GameManager.instance.inventory.AddItem(item);

            Destroy(triggerObj);
            inObject = null;
            triggerObj = null;
        }
        
    }

    
    

}
