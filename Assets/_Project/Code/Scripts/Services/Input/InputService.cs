using UnityEngine;

namespace Project.Services
{
    public interface IInputService
    {
        Vector2 GetMoveAxis();
        Vector2 GetLookDelta();
        float GetLookMin();
        float GetLookMax();
        bool IsJumpPressedDown();
    }
    
    public class InputService : IInputService
    {
        private readonly InputServiceConfig _config;

        public InputService(InputServiceConfig config)
        {
            _config = config;
        }
        
        public Vector2 GetMoveAxis()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public Vector2 GetLookDelta()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        public float GetLookMin()
        {
            return _config.LookMin;
        }

        public float GetLookMax()
        {
            return _config.LookMax;
        }

        public bool IsJumpPressedDown()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}