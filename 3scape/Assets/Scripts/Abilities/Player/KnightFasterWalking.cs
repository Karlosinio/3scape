﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MorePPEffects;

public class KnightFasterWalking : ColorAbility
{
    CharacterController2D characterController2D;

    public Image SecondSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    private RadialBlur effect;

    public AudioClip eurobeat;
    public AudioSource source;
    public AudioSource musicSource;

    private Text secondSkillTextCdKnight;

    private Image skillImage;
    public Sprite skillSprite;
    public Sprite skillSpriteUsed;

    void Start()
    {
        secondSkillTextCdKnight = GameObject.Find("SecondSkillTextCdKnight").GetComponent<Text>();
        skillImage = GameObject.Find("SecondSkillKnight").GetComponent<Image>();
        findObjects();
        defaultColor = SecondSkillCoolDown.color;
        defaultDirection = SecondSkillCoolDown.fillClockwise;
        effect = FindObjectOfType<RadialBlur>();
    }

    void Update()
    {
        if (isAbilityReady())
        {
            skillImage.sprite = skillSprite;
            if (isButtonDownProper() && isPositionProper())
            {
                musicSource.Pause();
                source.PlayOneShot(eurobeat);

                PlayerMovement.runSpeed = 50f;

                SetAbilityColor();
                setCooldown();

                SecondSkillCoolDown.fillAmount = 1;

                if (effect != null)
                    effect.enabled = true;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            source.Stop();
            musicSource.UnPause();
            PlayerMovement.runSpeed = 20f;

            BackToNormalColor();
            reduceCooldown();

            //SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;

            if (effect != null)
                effect.enabled = false;
        }

        if (isAbilityStillWorking())
        {
            SecondSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            SecondSkillCoolDown.fillClockwise = !defaultDirection;
            SecondSkillCoolDown.fillAmount = remaindingDuration / duration;
        }
        else
        {
            skillImage.sprite = skillSprite;
            SecondSkillCoolDown.color = defaultColor;
            SecondSkillCoolDown.fillClockwise = defaultDirection;
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;

            int val = (int)currentCooldown;
            secondSkillTextCdKnight.text = val.ToString();
            if (currentCooldown < 0.1)
            {
                secondSkillTextCdKnight.text = "";
            }
        }

        if (!isPositionProper())
        {
            //SecondSkillCoolDown.color = defaultColor;
            //SecondSkillCoolDown.fillAmount = 1;
            skillImage.sprite = skillSpriteUsed;
        }
        else if (!isAbilityStillWorking())
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

}
