﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class UnlockingChestsHUD : PlayerAbility
{
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;

    public Transform unlockPos;
    public float unlockRange;
    public LayerMask whatCanOpen;

    public Image FirstSkillCoolDown;

    void Update()
    {
        if (isAbilityReady())
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(unlockPos.position, unlockRange, whatCanOpen);

            //animator.SetBool("jakasAnimacja", false);
            if (isButtonPressedProper() && ready == false)
            {
                downTime = Time.time;
                pressTime = downTime + countDown;
                ready = true;
            }

            if (isButtonUpProper())
            {
                ready = false;
            }

            if (Time.time >= pressTime && ready == true && isPositionProper())
            {
                ready = false;
                //animator.SetBool("jakasAnimacja", true);
                Collider2D[] col = Physics2D.OverlapCircleAll(unlockPos.position, unlockRange, whatCanOpen);
                Debug.Log(col.Length);

                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].tag == "Chest")
                    {
                        col[i].GetComponent<Chest>().checkIfOpen();
                        setCooldown();

                        //FirstSkillCoolDown.fillAmount = 1;
                    }
                }
            }
        }

        else
        {
            currentCooldown -= Time.deltaTime;

            //FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (!isPositionProper())
            FirstSkillCoolDown.fillAmount = 1;
        else
            FirstSkillCoolDown.fillAmount = 0;
    }
}
*/