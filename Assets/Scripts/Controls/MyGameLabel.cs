using System;
using Gui3D.Base;
using UnityEngine;

public class MyGameLabel : TextBox
{


	public void create (string text, float textWidth, Color color)
	{

		this.create ("Fonts/Venera-700",Color.white,12);
		this.create (text);

	}

}
