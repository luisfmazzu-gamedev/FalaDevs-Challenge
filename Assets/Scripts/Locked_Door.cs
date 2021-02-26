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
	public Text txt_DoorState;
	public bool haveKey = false;

	[Header("Door")]
	public Transform Door_To_Open;


	private void Update()
	{
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1f))
		{
			if (hit.collider.CompareTag("Key"))
			{
				CancelInvoke("DesactivateLabel");
				txt_DoorState.text = "<b><Color=Lime>Chave!</Color> \n" +
				"<Color=Magenta>Aperte 'E' para pegar a chave.</Color></b>";

				if (Input.GetKeyDown("e"))
				{
					Destroy(hit.transform.gameObject);
					haveKey = true;

					txt_DoorState.text = "<b><Color=Lime>Parabéns, você encontrou a chave.</Color> \n" +
						"<Color=Magenta>Vá até a porta para tentar abri-la.</Color></b>";
					
				}
			}
			if (hit.collider.CompareTag("Door"))
			{
				if (locked && haveKey)
				{
					txt_DoorState.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
					"<Color=Magenta>Aperte 'E' para destrancar a porta.</Color></b>";

					if (Input.GetKeyDown("e"))
					{
						locked = false;
						haveKey = true;

						txt_DoorState.text = "<b><Color=Lime>Parabéns, você encontrou a chave.</Color> \n" +
							"<Color=Magenta>Vá até a porta para tentar abri-la.</Color></b>";

					}
				}
				else if (locked)
				{
					txt_DoorState.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
					"<Color=Magenta>Desenvolva um script capaz de destrancar ela juntamente com uma chave, a chave está em cima de uma mesa em um dos cômodos. Pegue ela " +
					"e crie a lógica para destrancar a porta com esta chave.</Color></b>";
				}
				else
				{
					txt_DoorState.text = "<b><Color=Lime>A porta foi destrancada!</Color> \n" +
					"<Color=Magenta>Parabéns!, está livre agora.</Color></b>";
				}
			}
			else
				Invoke("DesactivateLabel", 3);
		}
	}

	void DesactivateLabel()
	{
		txt_DoorState.text = "";
	}
}
