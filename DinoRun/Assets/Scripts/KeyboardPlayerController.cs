using UnityEngine;

public class KeyboardPlayerController : PlayerController
{
    protected override bool IsCharging()
    {
        return Input.GetKey(KeyCode.Space);
    }

    protected override bool IsJumped()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }
}
