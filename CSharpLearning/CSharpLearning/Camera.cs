using System;

namespace CSharpLearning
{
    public class Camera
    {
        private Guid _deviceId;

        private Camera() => _deviceId = Guid.NewGuid();

        public Guid DeviceId => _deviceId;

        private static Camera _currentInstance = new Camera();

        public static Camera CurrentInstance => _currentInstance;
    }
}
