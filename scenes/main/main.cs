using Godot;
using System;

public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print("global: " + Global.isSplitscreen);
		// GD.Print("button: " + GetNode<CheckButton>("CheckButton").ButtonPressed);
		Global.isSplitscreen = GetNode<CheckButton>("CheckButton").ButtonPressed;
	}
}
