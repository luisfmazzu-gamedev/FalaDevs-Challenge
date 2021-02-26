using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKeyType1 = false;
    private bool hasKeyType2 = false;

    public bool HasKeyType1 { get => hasKeyType1; }
    public bool HasKeyType2 { get => hasKeyType2;}

    public List<string> TypeKeys()
    {
        List<string> typeKeys = new List<string>();

        if (hasKeyType1)
            typeKeys.Add("Type1");
        if (hasKeyType2)
            typeKeys.Add("Type2");

        return typeKeys;
    }

    public void receiveKey(string keyType)
    {
        if (keyType == "Type1")
            hasKeyType1 = true;
        if (keyType == "Type2")
            hasKeyType2 = true;
    }
}
