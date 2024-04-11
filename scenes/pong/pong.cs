using Godot;
using System;

public partial class pong : CharacterBody2D
{
	public pong()
	{
		random = new Random();
	}
	private float Speed = 950f;
	private Random random;

	public override void _Ready()
	{
		Vector2 velocity;

		// Choose a direction: left or right.
		if (random.Next(0, 2) == 0)
		{
			// Left direction
			velocity = new Vector2(-1, 0);
		}
		else
		{
			// Right direction
			velocity = new Vector2(1, 0);
		}

		velocity *= Speed;
		Velocity = velocity;
		MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		if(collisionInfo != null){
			GD.Print("collision info wasnt null");
		Vector2 newVelocity = Velocity.Bounce(collisionInfo.GetNormal());

		// 65% chance to modify the bounce angle slightly

		// Add a small random angle to the new velocity
		float angleOffset = (float)(random.NextDouble() * Math.PI / 18) - (float)(Math.PI / 36); // +/- 2.5 degrees
		GD.Print("Angled: " + angleOffset);
		newVelocity = newVelocity.Rotated(angleOffset);

		Velocity = newVelocity;

		}
		
	}


	public override void _Process(double delta)
	{
		// Move the pong
		if (Input.IsActionPressed("r"))
		{
			Reset();
		}
	}

	public void Reset()
	{
		Position = new Vector2(0, 0);
		_Ready();
	}
}



