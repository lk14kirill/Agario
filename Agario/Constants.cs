namespace Agario
{
    class Constants
    {
        public const int windowX = 1920;
        public const int windowY = 1080;
        public delegate void RemoveDelegate(CircleObject circle);
        public static RemoveDelegate CircleRemoved;
        public delegate void CreateDelegate(CircleObject circle);
        public static CreateDelegate CircleCreated;
        public const int TARGET_FPS = 500;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;
    }
}
