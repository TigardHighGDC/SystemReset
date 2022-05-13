/*
 *   Copyright 2022 TigardHighGDC
 *
 *   Licensed under the Apache License, Version 2.0 (the "License");
 *   you may not use this file except in compliance with the License.
 *   You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   Unless required by applicable law or agreed to in writing, software
 *   distributed under the License is distributed on an "AS IS" BASIS,
 *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *   See the License for the specific language governing permissions and
 *   limitations under the License.
 */

using UnityEngine;

public class Gun
{
    public static int select = 1;

    public class Pistol
    {
        public static float damage = 10.0f;
        public static float timeBetweenShots = 0f;
        public static float spread = 0.10f; 
        public static float reloadTime = 2.0f; 
        public static float fireRate = 1.0f; 
        public static float range = 0f;
        public static int magSize = 8;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = false;
    }

    public class Shotgun
    {
        public static float damage = 18.0f;
        public static float timeBetweenShots = 0.0f;
        public static float spread = 2.5f; 
        public static float reloadTime = 2f; 
        public static float fireRate = 2f; 
        public static float range = 25f;
        public static int magSize = 80;
        public static int shotsPerTap = 10;
        public static bool allowButtonHold = false;
    }

    public class MachineGun
    {
        public static float damage = 20.0f;
        public static float timeBetweenShots = 0.05f;
        public static float spread = 0.05f;
        public static float range = 100.0f;
        public static float reloadTime = 3f;
        public static float fireRate = 0.1f;
        public static int magSize = 100;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = true;
    }

    public class SniperRifle
    {
        public static float damage = 100.0f;
        public static float timeBetweenShots = 5.0f;
        public static float spread = 0.0f;
        public static float range = 300.0f;
        public static float reloadTime = 3f;
        public static float fireRate = 0.0f;
        public static int magSize = 1;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = false;
    }

    public class AssaultRifle
    {
        public static float damage = 25.0f;
        public static float timeBetweenShots = 0.1f;
        public static float spread = 0.02f;
        public static float range = 100.0f;
        public static float reloadTime = 1.5f;
        public static float fireRate = 0.3f;
        public static int magSize = 25;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = true;
    }
}
