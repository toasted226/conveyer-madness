using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
	public LayerMask layer;
	public AudioClip turn;

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100f, layer, QueryTriggerInteraction.Collide))
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (hit.collider.CompareTag("MultiTurner"))
				{
					AudioSource main = GetComponent<AudioSource>();
					main.PlayOneShot(turn);
					Transform t = hit.transform;
					if (Mathf.RoundToInt(t.eulerAngles.y) < 270)
					{
						t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y + 90, t.eulerAngles.z);
					}
					else
					{
						t.eulerAngles = new Vector3(t.eulerAngles.x, 0, t.eulerAngles.z);
					}
				}
				else if (hit.collider.CompareTag("SingleTurner"))
				{
					Transform t = hit.transform;
					AudioSource main = GetComponent<AudioSource>();
					main.PlayOneShot(turn);
					if (t.eulerAngles.y == 0)
					{
						t.eulerAngles = new Vector3(t.eulerAngles.x, 90, t.eulerAngles.z);
					}
					else
					{
						t.eulerAngles = new Vector3(t.eulerAngles.x, 0, t.eulerAngles.z);
					}
				}
			}
		}
	}
}
