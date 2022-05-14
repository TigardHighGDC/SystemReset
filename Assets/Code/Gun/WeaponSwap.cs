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

public class WeaponSwap : MonoBehaviour
{
    public class Pistol
    {
        public static float damage = 25.0f;
        public static float timeBetweenShots = 0f;
        public static float spread = 0.10f;
        public static float reloadTime = 2.0f;
        public static float fireRate = 0.5f;
        public static float range = 0f;
        public static int magSize = 8;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = false;
    }

    public class Shotgun
    {
        public static float damage = 18.0f;
        public static float timeBetweenShots = 0.0f;
        public static float spread = 0.4f;
        public static float reloadTime = 2f;
        public static float fireRate = 0.8f;
        public static float range = 25f;
        public static int magSize = 120;
        public static int shotsPerTap = 25;
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
        public static float damage = 150.0f;
        public static float timeBetweenShots = 0.0f;
        public static float spread = 0.0f;
        public static float range = 300.0f;
        public static float reloadTime = 2f;
        public static float fireRate = 0.0f;
        public static int magSize = 1;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = false;
    }

    public class AssaultRifle
    {
        public static float damage = 20.0f;
        public static float timeBetweenShots = 0.1f;
        public static float spread = 0.02f;
        public static float range = 100.0f;
        public static float reloadTime = 1.5f;
        public static float fireRate = 0.3f;
        public static int magSize = 25;
        public static int shotsPerTap = 1;
        public static bool allowButtonHold = true;
    }

    public GameObject weapon;
    private basicShoot basicShoot;

    public GameObject pistol;
    public GameObject shotgun;
    public GameObject machineGun;
    public GameObject sniperRifle;
    public GameObject assaultRifle;
    
    private void Start()
    {
        basicShoot = weapon.GetComponent<basicShoot>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            shotgun.SetActive(false);
            machineGun.SetActive(false);
            sniperRifle.SetActive(false);
            assaultRifle.SetActive(false);
            SelectPistol();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);
            machineGun.SetActive(false);
            sniperRifle.SetActive(false);
            assaultRifle.SetActive(false);
            SelectShotgun();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            machineGun.SetActive(true);
            sniperRifle.SetActive(false);
            assaultRifle.SetActive(false);
            SelectMachineGun();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            machineGun.SetActive(false);
            sniperRifle.SetActive(true);
            assaultRifle.SetActive(false);
            SelectSniperRifle();
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            machineGun.SetActive(false);
            sniperRifle.SetActive(false);
            assaultRifle.SetActive(true);
            SelectAssaultRifle();
        }
    }

    private void SelectPistol()
    {
        basicShoot.damage = Pistol.damage;
        basicShoot.spread = Pistol.spread;
        basicShoot.timeBetweenShots = Pistol.timeBetweenShots;
        basicShoot.reloadTime = Pistol.reloadTime;
        basicShoot.fireRate = Pistol.fireRate;
        basicShoot.range = Pistol.range;
        basicShoot.magSize = Pistol.magSize;
        basicShoot.shotsPerTap = Pistol.shotsPerTap;
        basicShoot.allowButtonHold = Pistol.allowButtonHold;
        basicShoot.bulletsLeft = basicShoot.magSize;
    }

    private void SelectShotgun()
    {
        basicShoot.damage = Shotgun.damage;
        basicShoot.spread = Shotgun.spread;
        basicShoot.timeBetweenShots = Shotgun.timeBetweenShots;
        basicShoot.reloadTime = Shotgun.reloadTime;
        basicShoot.fireRate = Shotgun.fireRate;
        basicShoot.range = Shotgun.range;
        basicShoot.magSize = Shotgun.magSize;
        basicShoot.shotsPerTap = Shotgun.shotsPerTap;
        basicShoot.allowButtonHold = Shotgun.allowButtonHold;
        basicShoot.bulletsLeft = basicShoot.magSize;
    }

    private void SelectMachineGun()
    {
        basicShoot.damage = MachineGun.damage;
        basicShoot.spread = MachineGun.spread;
        basicShoot.timeBetweenShots = MachineGun.timeBetweenShots;
        basicShoot.reloadTime = MachineGun.reloadTime;
        basicShoot.fireRate = MachineGun.fireRate;
        basicShoot.range = MachineGun.range;
        basicShoot.magSize = MachineGun.magSize;
        basicShoot.shotsPerTap = MachineGun.shotsPerTap;
        basicShoot.allowButtonHold = MachineGun.allowButtonHold;
        basicShoot.bulletsLeft = basicShoot.magSize;
    }

    private void SelectSniperRifle()
    {
        basicShoot.damage = SniperRifle.damage;
        basicShoot.spread = SniperRifle.spread;
        basicShoot.timeBetweenShots = SniperRifle.timeBetweenShots;
        basicShoot.reloadTime = SniperRifle.reloadTime;
        basicShoot.fireRate = SniperRifle.fireRate;
        basicShoot.range = SniperRifle.range;
        basicShoot.magSize = SniperRifle.magSize;
        basicShoot.shotsPerTap = SniperRifle.shotsPerTap;
        basicShoot.allowButtonHold = SniperRifle.allowButtonHold;
        basicShoot.bulletsLeft = basicShoot.magSize;
    }

    private void SelectAssaultRifle()
    {
        basicShoot.damage = AssaultRifle.damage;
        basicShoot.spread = AssaultRifle.spread;
        basicShoot.timeBetweenShots = AssaultRifle.timeBetweenShots;
        basicShoot.reloadTime = AssaultRifle.reloadTime;
        basicShoot.fireRate = AssaultRifle.fireRate;
        basicShoot.range = AssaultRifle.range;
        basicShoot.magSize = AssaultRifle.magSize;
        basicShoot.shotsPerTap = AssaultRifle.shotsPerTap;
        basicShoot.allowButtonHold = AssaultRifle.allowButtonHold;
        basicShoot.bulletsLeft = basicShoot.magSize;
    }
}
