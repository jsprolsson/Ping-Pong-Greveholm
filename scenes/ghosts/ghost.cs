using Godot;
using System;

public partial class ghost : CharacterBody2D
{
	private const float Speed = 150f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Vector2 velocity = Velocity;
		var random = new Random();
		double angle = random.NextDouble() * 2 * Math.PI;

		velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
		velocity *= Speed;

		Velocity = velocity;
		MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		if (collisionInfo != null)
			Velocity = Velocity.Bounce(collisionInfo.GetNormal());
	}
}
