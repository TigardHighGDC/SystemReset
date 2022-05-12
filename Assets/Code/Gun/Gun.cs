using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public static int select = 1;
    public class Pistol
    {
        public static float damage = 50.0f;
        public static float timeBetweenShots = 0f;
        public static float spread = 20f; 
        public static float reloadTime = 2f; 
        public static float fireRate = 1f; 
        public static float range = 0f;
        public static int magSize = 15;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = false;
    }
    public class Shotgun
    {
        public static float damage = 50.0f;
        public static float timeBetweenShots = 0f;
        public static float spread = 40f; 
        public static float reloadTime = 2f; 
        public static float fireRate = 1f; 
        public static float range = 20f;
        public static int magSize = 15;
        public static int shotsPerTap = 10;
        public static bool allowButtonHold = false;
    }
    public class MachineGun
    {

    }
}
