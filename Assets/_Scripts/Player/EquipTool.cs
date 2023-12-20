using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float fishingDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResources;
    public bool doesGatherFish;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;

    public float useStamina;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }

    public override void OnAttackInput(PlayerConditions conditions)
    {
        if (!attacking)
        {
            if (conditions.UseStamina(useStamina))
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }
    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }


            if (doesDealDamage && hit.collider.TryGetComponent(out IDamagable damageable))
            {
                damageable.TakePhysicalDamage(damage);
            }
        }
    }
    public void OnFishing()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, fishingDistance))
        {
            if (doesGatherFish && hit.collider.TryGetComponent(out Resource resource))
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Water"))
                    return;
                print("´ê¾Ò´Ù");
                resource.Fishing(hit.point);

                //Äù½ºÆ®
                if (QuestManager.Instance.drink == true)
                {
                    if (QuestManager.Instance.fishing == false)
                    {
                        QuestManager.Instance.QuestCount++;
                        if (QuestManager.Instance.QuestCount == 6)
                        {
                            QuestManager.Instance.fishing = true;
                        }
                        QuestManager.Instance.FishingQuest(QuestManager.Instance.fishing, QuestManager.Instance.QuestCount);
                    }
                }

            }

        }
    }

}