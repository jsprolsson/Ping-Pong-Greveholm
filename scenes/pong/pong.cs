using Godot;
using System;

public partial class pong : CharacterBody2D
{
	private float Speed = 400f;

public override void _Ready()
{
	Vector2 velocity = Velocity;
	var random = new Random();

	// Limit the angle to a range between 45 and 135 degrees (in radians) for the left direction
	// and between 225 and 315 degrees for the right direction.
	double angle;
	if (random.Next(0, 2) == 0)
	{
		// Angle for the left direction
		angle = (random.NextDouble() * (Math.PI / 2)) + Math.PI / 4;
	}
	else
	{
		// Angle for the right direction
		angle = (random.NextDouble() * (Math.PI / 2)) + 5 * Math.PI / 4;
	}

	// Convert angle from degrees to radians
	angle = angle * (Math.PI / 180);

	velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

	velocity *= Speed;
	Velocity = velocity;
	MoveAndSlide();
}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		
		if(collisionInfo != null) {
			
		}

		if (collisionInfo != null)
			Velocity = Velocity.Bounce(collisionInfo.GetNormal());
	}

	public void Reset(){
		Position = new Vector2(0, 0);
		_Ready();
	}
}



