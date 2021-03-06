﻿using MorePPEffects;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalShield : ColorAbility
{
    CharacterController2D characterController2D;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    private Colorization effect;
    public float timeLeft = 3.3f;

    private Text firstSkillTextCdKnight;

    private Image skillImage;
    public Sprite skillSprite;
    public Sprite skillSpriteUsed;

    void Start()
    {
        firstSkillTextCdKnight = GameObject.Find("FirstSkillTextCdKnight").GetComponent<Text>();
        skillImage = GameObject.Find("FirstSkillKnight").GetComponent<Image>();
        findObjects();
        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
        effect = FindObjectOfType<Colorization>();
    }

    void Update()
    {
        if (isAbilityReady())
        {

            timeLeft = 3.3f;

            skillImage.sprite = skillSprite;
            // animator.SetBool("IsShield", false);
            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsShield", true);

                PlayerMovement.runSpeed = 10f;
                knight.SetPhysicalImmunity();
                SetAbilityColor(true, false, false);
                setCooldown();
                FirstSkillCoolDown.fillAmount = 1;

                if (effect != null)
                    effect.enabled = true;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;
            knight.DisablePhysicalImmunity();
            BackToNormalColor(true, false, false);
            reduceCooldown();
            // FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;

            if (effect != null)
                effect.enabled = false;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && animator.GetBool("IsShield"))
        {

            animator.SetBool("IsShield", false);
            timeLeft = 3.3f;
        }


        if (isAbilityStillWorking())
        {
            FirstSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            FirstSkillCoolDown.fillClockwise = !defaultDirection;
            FirstSkillCoolDown.fillAmount = remaindingDuration / duration;
        }
        else
        {
            skillImage.sprite = skillSprite;
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillClockwise = defaultDirection;
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;

            int val = (int)currentCooldown;
            firstSkillTextCdKnight.text = val.ToString();
            if (currentCooldown < 0.1)
            {
                firstSkillTextCdKnight.text = "";
            }
        }

        if (!isPositionProper())
        {
            //FirstSkillCoolDown.color = defaultColor;
            //FirstSkillCoolDown.fillAmount = 1;
            skillImage.sprite = skillSpriteUsed;
        }
        else if (!isAbilityStillWorking())
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}