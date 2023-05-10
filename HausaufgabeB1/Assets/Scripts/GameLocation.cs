using UnityEngine;

public class GameLocation : ScriptableObject
{
	public GameLocation(Sprite backgroundImage, bool foreGround = false)
	{
		BackgroundImage = backgroundImage;
		ForeGround = foreGround;
	}

	public Sprite BackgroundImage { get; private set; }
	public bool ForeGround { get; private set; }
}