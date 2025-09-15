using UnityEngine;
using System.Collections.Generic;

public class KeyCodeList : MonoBehaviour
{
    public List<KEY_CODE> KeyCodes = new List<KEY_CODE>();

    public void AddKey(KEY_CODE key)
    {
       
            KeyCodes.Add(key);
        
    }
}
public enum KEY_CODE
{
    BlueDoor,
    GreenDoor,
    RedDoor,
    YellowDoor,
}

