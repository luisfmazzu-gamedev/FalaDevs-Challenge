/*

 Bem vindo ao FalaDevs!

 Seu codigo começa aqui, edite ele para poder usar a chave para abrir a porta!

 Depois Grave um breve video e envie seu projeto para o GitHub, e no grupo Unity Brasil no Facebook,
 poste o link do GitHub com seu projeto e o video feito por você.

 Boa sorte!

 Link GitHub:  https://github.com/RafaelReis891/FalaDevs

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locked_Door : MonoBehaviour
{
    [SerializeField]
    private bool locked = true;
    [SerializeField]
    private string KeyTypeAccepted = "Any";

    public bool Locked { get => locked; set => locked = value; }

    public bool AttemptUnlock(List<string> TypeOfKeys)
    {
        if (KeyTypeAccepted == "Any")
        {
            if (TypeOfKeys.Count >= 1)
            {
                locked = false;
                return true;
            }
        }
        foreach (string TypeOfKey in TypeOfKeys)
        {
            if (TypeOfKey == KeyTypeAccepted)
            {
                locked = false;
                Debug.Log("Door unlocked with a " + TypeOfKey + " key!");
                return true;
            }
        }

        return false;
    }


}
