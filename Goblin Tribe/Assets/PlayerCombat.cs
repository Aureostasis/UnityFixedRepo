using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    // Combat Variables
    int comboCounter;
    float comboCD = 0.1f;
    float lastClicked;
    float lastComboEnded;

    // Character Info
    WeaponInfo CurrentWeapon;
    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentWeapon != null) {
            attack(CurrentWeapon.weaponName);
        }
    }

    void attack(string weapon) {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time - lastComboEnded > comboCD) {
            comboCounter++;
            comboCounter = Mathf.Clamp(comboCounter, 0 , CurrentWeapon.comboLength);

            // Create attack names
            for (int i = 0; i < comboCounter; i++)
            {
                if (i == 0)
                {
                    if (comboCounter == 1 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Movement")) { 
                        animator.SetBool("AttackStart", true);
                        animator.SetBool(weapon + "Attack" + (i + 1), true);
                        lastClicked = Time.time;
                    }
                }

                else
                {
                    if (comboCounter >= (i+1) && animator.GetCurrentAnimatorStateInfo(0).IsName(weapon + "Attack"  + i))
                    {
                        animator.SetBool(weapon + "Attack" + (i + 1), true);
                        animator.SetBool(weapon + "Attack" + (i), true);
                        lastClicked = Time.time;
                    }
                }
            }
        }

        // Animation exit bool reset

        for (int i = 0; i < comboCounter; i++)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && animator.GetCurrentAnimatorStateInfo(0).IsName(weapon + "Attack" + (i+1)))
            {
                comboCounter = 0;
                lastComboEnded = Time.time;
                animator.SetBool(weapon + "Attack" + (i + 1), false);
                animator.SetBool("AttackStart", false);

            }    
        }

    }
}
