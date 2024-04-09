using Godot;
using System;

public partial class Play : Button
{
	private void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/level/level.tscn");
	}
}



