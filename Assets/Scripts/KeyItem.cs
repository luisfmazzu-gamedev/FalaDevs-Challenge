using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField]
    private string keyType;

    public string KeyType { get => keyType; set => keyType = value; }
}
