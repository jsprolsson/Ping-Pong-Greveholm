using Godot;
using System;

public partial class pong : CharacterBody2D
{
	public pong()
	{
		random = new Random();
	}
	private float Speed = 400f;
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
		
		if(collisionInfo != null) {
			
		}

		if (collisionInfo != null)
			Velocity = Velocity.Bounce(collisionInfo.GetNormal());
	}


	public override void _Process(double delta)
	{
		// Move the pong
		if (Input.IsActionPressed("r"))
	{
		Reset();
	}
	}

	public void Reset(){
		Position = new Vector2(0, 0);
		_Ready();
	}
}



