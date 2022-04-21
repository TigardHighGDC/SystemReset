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

public class cameraRecoil : MonoBehaviour
{
    // Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    // Settings
    [SerializeField] public float recoilX;
    [SerializeField] public float recoilY;

    // Properties
    [SerializeField] public float snappiness;
    [SerializeField] public float returnSpeed;

    private cameraMovement camMovement;

    private void Start() 
    {
        currentRotation = new Vector3(0, 0, 0);
        targetRotation = currentRotation;
        camMovement = GetComponentInParent<cameraMovement>();
    }

    private void FixedUpdate() 
    {
        targetRotation = Vector3.
            Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.
            Slerp(
                currentRotation, 
                targetRotation, 
                snappiness * Time.fixedDeltaTime
            );

        camMovement.currentrecoil = currentRotation;
    }

    public void RecoilFire() 
    {
        targetRotation = new Vector3(
            recoilX,
            Random.Range(-recoilY, recoilY),
            0.0f
        );
    }
}
