using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public int Score = 0;

	private bool splitScreen = Global.isSplitscreen;
	public CharacterBody2D ball;

    public override void _Ready()
    {
        if (!splitScreen && Name == "Player2")
        {
            ball = GetNode<CharacterBody2D>("../Pong");
			if(ball != null){ 
				GD.Print("Found ball");
			}
        }
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

        if (splitScreen && Name == "Player2")
        {
            // Control setup for Player2 in splitscreen mode
            Vector2 direction = Input.GetVector(Global.p2_ui_left, Global.p2_ui_right, Global.p2_ui_up, Global.p2_ui_down);
            if (direction != Vector2.Zero)
            {
                velocity.X = direction.X * Speed;
                velocity.Y = direction.Y * Speed;
            }
            else
            {
                velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
                velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            }
        }
        else if (!splitScreen && Name == "Player2")
        {
            // AI behavior for Player2 when not in splitscreen
            velocity.X = 0; // Stay stationary on X-axis
            if (ball != null)
            {
                // Follow the ball's Y position
                float targetY = ball.Position.Y;
                float currentY = Position.Y;
                if (currentY < targetY)
                {
                    velocity.Y = Speed; // Move down
                }
                else if (currentY > targetY)
                {
                    velocity.Y = -Speed; // Move up
                }
            }
        }
        else if (Name == "Player")
        {
            // Standard input handling for Player1
            Vector2 direction = Input.GetVector(Global.p1_ui_left, Global.p1_ui_right, Global.p1_ui_up, Global.p1_ui_down);
            if (direction != Vector2.Zero)
            {
                velocity.X = direction.X * Speed;
                velocity.Y = direction.Y * Speed;
            }
            else
            {
                velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
                velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            }
        }
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
