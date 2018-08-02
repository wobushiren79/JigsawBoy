﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainUIControl : BaseUIControl
{
    //开始按钮
    public Button startGameBT;
    public Text startGameText;
    //自定义按钮
    public Button customBT;
    public Text customText;
    //设置按钮
    public Button settingBT;
    public Text settingText;
    //退出按钮
    public Button exitBT;
    public Text exitText;


    private new void Awake()
    {
        base.Awake();
      
        startGameBT = CptUtil.getCptFormParentByName<Canvas, Button>(mUICanvas, "StartGameBT");
        startGameText = CptUtil.getCptFormParentByName<Button, Text>(startGameBT, "StartGameText");
     
        customBT = CptUtil.getCptFormParentByName<Canvas, Button>(mUICanvas, "CustomBT");
        customText = CptUtil.getCptFormParentByName<Button, Text>(customBT, "CustomText");
 
        settingBT = CptUtil.getCptFormParentByName<Canvas, Button>(mUICanvas, "SettingBT");
        settingText = CptUtil.getCptFormParentByName<Button, Text>(settingBT, "SettingText");
   
        exitBT = CptUtil.getCptFormParentByName<Canvas, Button>(mUICanvas, "ExitBT");
        exitText = CptUtil.getCptFormParentByName<Button, Text>(exitBT, "ExitText");

        startGameBT.onClick.AddListener(startGameOnClick);
        customBT.onClick.AddListener(customOnClick);
        settingBT.onClick.AddListener(settingOnClick);
        exitBT.onClick.AddListener(exitOnClick);

        refreshUI();
    }

    /// <summary>
    /// 进入拼图选择界面
    /// </summary>
    private void startGameOnClick()
    {
        SoundUtil.playSoundClip(AudioButtonOnClickEnum.btn_sound_1);
        if (mUIMasterControl == null)
            return;
        mUIMasterControl.openUIByTypeAndCloseOther(UIEnum.MenuSelectUI);
    }

    /// <summary>
    /// 进入自定义装扮界面
    /// </summary>
    private void customOnClick()
    {
        SoundUtil.playSoundClip(AudioButtonOnClickEnum.btn_sound_1);
        DialogManager.createToastDialog().setToastText(CommonData.getText(27));
    }

    /// <summary>
    /// 进入设置界面
    /// </summary>
    private void settingOnClick()
    {
        SoundUtil.playSoundClip(AudioButtonOnClickEnum.btn_sound_1);
        if (mUIMasterControl == null)
            return;
        mUIMasterControl.openUIByTypeAndCloseOther(UIEnum.MenuSettingUI);
    }

    /// <summary>
    /// 离开游戏
    /// </summary>
    private void exitOnClick()
    {
        SoundUtil.playSoundClip(AudioButtonOnClickEnum.btn_sound_1);
        SystemUtil.exitGame();
    }


    public override void openUI()
    {
        mUICanvas.enabled = true;
        loadUIData();
    }

    public override void closeUI()
    {
        mUICanvas.enabled = false;
    }

    public override void loadUIData()
    {
      
    }
    public override void refreshUI()
    {
        if(startGameText!=null)
            startGameText.text = CommonData.getText(1);
        if (startGameText != null)
            customText.text = CommonData.getText(2);
        if (startGameText != null)
            settingText.text = CommonData.getText(3);
        if (startGameText != null)
            exitText.text = CommonData.getText(4);
    }
}
