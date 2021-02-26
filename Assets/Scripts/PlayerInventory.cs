using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKey = false;

    public bool HasKey { get => hasKey; set => hasKey = value; }
}
