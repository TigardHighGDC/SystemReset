using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    // Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    // Settings
    [SerializeField] public float recoilX;
    [SerializeField] public float recoilY;
    [SerializeField] public float recoilZ;

    // Properties
    [SerializeField] public float snappiness;
    [SerializeField] public float returnSpeed;

    private void Start() 
    {
        currentRotation = new Vector3(0, 0, 0);
        targetRotation = currentRotation;
    }

    private void Update() 
    {
        targetRotation = Vector3.
            Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.
            Slerp(
                currentRotation, 
                targetRotation, 
                snappiness * Time.fixedDeltaTime
            );

        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire() 
    {
        targetRotation = new Vector3(
            recoilX,
            Random.Range(-recoilY, recoilY),
            Random.Range(-recoilZ, recoilZ)
        );
    }
}
