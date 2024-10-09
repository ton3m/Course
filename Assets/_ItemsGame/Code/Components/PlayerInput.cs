using UnityEngine;

namespace ItemsGame
{
    public class PlayerInput : IMoverInput
    {
        public Vector3 MoveDirection =>
            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
                .normalized;

        public bool UseItemKeyDown => Input.GetKeyDown(KeyCode.F);
    }
    
    public interface IMoverInput
    {
        Vector3 MoveDirection { get; }
    }
}