using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class CrateMover : MonoBehaviour
{
	public enum colours { Green, Red, Blue, Yellow };
	public colours colour;
	public float speed;
	public Vector3 dir;
	public LayerMask layer;
	bool changedDir;
	public AudioClip score;
	public AudioClip drop;

	private void Update()
	{
		transform.Translate(dir * speed * Time.deltaTime, Space.World);
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Point")) 
		{
			float distance = Vector3.Distance(transform.position, other.transform.position);

			if(distance <= 0.2f) 
			{
				if (!changedDir)
				{
					dir = other.GetComponent<Rotater>().ChangeDirection(dir, colour);
					changedDir = true;
					StartCoroutine(ReadyChange());
				}
			}
		}
	}

	IEnumerator ReadyChange()
	{
		yield return new WaitForSeconds(1f);
		changedDir = false;
		transform.position = new Vector3(
			Mathf.RoundToInt(transform.position.x), 
			Mathf.RoundToInt(transform.position.y), 
			Mathf.RoundToInt(transform.position.z));
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameManager gm = Camera.main.GetComponent<GameManager>();
		AudioSource main = Camera.main.GetComponent<AudioSource>();

		if (collision.collider.CompareTag("Ground")) 
		{
			gm.LoseCrate();
			main.clip = drop;
			main.Play();
			Destroy(gameObject);
		}

		if (collision.collider.name == "GreenTarget") 
		{
			if (colour == colours.Green)
			{
				gm.AddScore();
				main.clip = score;
				main.Play();
			}
			else 
			{
				gm.LoseCrate();
				main.clip = drop;
				main.Play();
			}
			Destroy(gameObject);
		}

		if (collision.collider.name == "RedTarget")
		{
			if (colour == colours.Red)
			{
				gm.AddScore();
				main.clip = score;
				main.Play();
			}
			else
			{
				gm.LoseCrate();
				main.clip = drop;
				main.Play();
			}
			Destroy(gameObject);
		}

		if (collision.collider.name == "BlueTarget")
		{
			if (colour == colours.Blue)
			{
				gm.AddScore();
				main.clip = score;
				main.Play();
			}
			else
			{
				gm.LoseCrate();
				main.clip = drop;
				main.Play();
			}
			Destroy(gameObject);
		}

		if (collision.collider.name == "YellowTarget")
		{
			if (colour == colours.Yellow)
			{
				gm.AddScore();
				main.clip = score;
				main.Play();
			}
			else
			{
				gm.LoseCrate();
				main.clip = drop;
				main.Play();
			}
			Destroy(gameObject);
		}
	}
}
