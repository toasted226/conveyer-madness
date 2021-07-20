using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
	public bool colourSpecific;
	public enum Colours {Green, Red, Blue, Yellow };
	public Colours colour;
	public Vector3 direction;

	public Transform turner;
	[Space]
	public Vector3 zone_zero;
	public Vector3 zone_ninety;
	public Vector3 zone_negNinety;
	public Vector3 zone_oneEighty;
	[Space]
	public Vector3 znone_zero;
	public Vector3 znone_ninety;
	public Vector3 znone_negNinety;
	public Vector3 znone_oneEighty;
	[Space]
	public Vector3 xone_zero;
	public Vector3 xone_ninety;
	public Vector3 xone_negNinety;
	public Vector3 xone_oneEighty;
	[Space]
	public Vector3 xnone_zero;
	public Vector3 xnone_ninety;
	public Vector3 xnone_negNinety;
	public Vector3 xnone_oneEighty;

	public Vector3 ChangeDirection(Vector3 player, CrateMover.colours _colour)
	{
		if (colourSpecific)
		{
			if (_colour == CrateMover.colours.Green)
			{
				if (colour == Colours.Green)
				{
					return direction;
				}
				else 
				{
					return player;
				}
			}
			if (_colour == CrateMover.colours.Blue)
			{
				if (colour == Colours.Blue)
				{
					return direction;
				}
				else
				{
					return player;
				}
			}
			if (_colour == CrateMover.colours.Red)
			{
				if (colour == Colours.Red)
				{
					return direction;
				}
				else
				{
					return player;
				}
			}
			if (_colour == CrateMover.colours.Yellow)
			{
				if (colour == Colours.Yellow)
				{
					return direction;
				}
				else
				{
					return player;
				}
			}
		}

		if (player.z == 1)
		{
			if (turner != null)
			{
				switch (Mathf.RoundToInt(turner.eulerAngles.y))
				{
					case 0:
						return zone_zero;
					case 90:
						return zone_ninety;
					case 270:
						return zone_negNinety;
					case 180:
						return zone_oneEighty;
				}
			}
			else 
			{
				return zone_zero;
			}
		}
		else if (player.z == -1)
		{
			if (turner != null)
			{
				switch (Mathf.RoundToInt(turner.eulerAngles.y))
				{
					case 0:
						return znone_zero;
					case 90:
						return znone_ninety;
					case 270:
						return znone_negNinety;
					case 180:
						return znone_oneEighty;
				}
			}
			else 
			{
				return znone_zero;
			}
		}
		else if (player.x == 1)
		{
			if (turner != null)
			{
				switch (Mathf.RoundToInt(turner.eulerAngles.y))
				{
					case 0:
						return xone_zero;
					case 90:
						return xone_ninety;
					case 270:
						return xone_negNinety;
					case 180:
						return xone_oneEighty;
				}
			}
			else
			{
				return xone_zero;
			}
		}
		else if (player.x == -1) 
		{
			if (turner != null)
			{
				switch (Mathf.RoundToInt(turner.eulerAngles.y))
				{
					case 0:
						return xnone_zero;
					case 90:
						return xnone_ninety;
					case 270:
						return xnone_negNinety;
					case 180:
						return xnone_oneEighty;
				}
			}
			else 
			{
				return xnone_zero;
			}
		}

		return player;
	}
}
