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
	public bool locked = true;
	public bool haveKey = false;

	[Header("Door")]
	public Transform Door_To_Open;


	private void Update()
	{
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1f))
		{
		}
	}

	
}
