using Godot;
using System;

public partial class PongSpeed : Label
{
	pong pong;
	public override void _Ready()
	{
		var levelRoot = GetTree().Root.GetNode<Node2D>("Level");
		pong = levelRoot.GetNode("Pong") as pong;
		Text = GetSpeed();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = GetSpeed();
	}

	private string GetSpeed(){
		return "Ball speed: " + pong.Speed.ToString() + " (Z/X)";
	}
}
