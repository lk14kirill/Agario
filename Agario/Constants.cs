namespace Agario
{
    class Constants
    {
        public const int windowX = 1920;
        public const int windowY = 1080;
        public delegate void RemoveDelegate(CircleObject circle);
        public static RemoveDelegate removeDelegate;                               //NE ZNAYU KAK NAZVAT
        public delegate void CreateDelegate(CircleObject circle);
        public static CreateDelegate createDelegate;
    }
}
