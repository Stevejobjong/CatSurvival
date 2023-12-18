using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipY : MonoBehaviour
{
    public Camera camera;
    
    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, attackDistance))
        {
            if(doesGatherResources && hit.collider.TryGetComponent(out ResourceY resource))
            {
                resource.Gather(hit.point, hit.normal);
            }

            if(doesDealDamage && hit.collider.TryGetComponent(out IDamagable damageable))
            {
                damageable.TakePhysicalDamage(damage);
            }
        }
    }
}
