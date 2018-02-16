﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawContainerCpt : MonoBehaviour
{
    //容器所含拼图对象数据
    public List<JigsawBean> listJigsaw;
    //是否被选中
    public bool isSelect;
    //是否开启合并检测
    public bool isOpenMergeCheck;



    public JigsawContainerCpt()
    {
        isOpenMergeCheck = true;
        listJigsaw = new List<JigsawBean>();
        isSelect = false;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 添加拼图块
    /// </summary>
    /// <param name="jigsawData"></param>
    public void addJigsaw(JigsawBean jigsawData)
    {
        if (jigsawData == null)
        {
            LogUtil.logError("给拼图容器添加子拼图失败：没有JigsawBean");
            return;
        }
        GameObject jigsawGameObj = jigsawData.JigsawGameObj;
        if (jigsawGameObj == null)
        {
            LogUtil.logError("给拼图容器添加子拼图失败：没有JigsawGameObj");
            return;
        }
        jigsawGameObj.transform.parent = null;
        jigsawGameObj.transform.parent = transform;
        listJigsaw.Add(jigsawData);
        //设置质量为拼图数量和
        Rigidbody2D thisRB = gameObject.GetComponent<Rigidbody2D>();
        if(thisRB!=null)
        thisRB.mass = listJigsaw.Count;
    }

    /// <summary>
    /// 添加拼图块
    /// </summary>
    /// <param name="jigsawData"></param>
    public void addJigsawList(List<JigsawBean> jigsawDataList)
    {
        foreach (JigsawBean itemData in jigsawDataList)
        {
            addJigsaw(itemData);
        }
    }

    /// <summary>
    /// 获取容器下所有拼图对象列表 
    /// </summary>
    public List<JigsawBean> getJigsawList()
    {
        return listJigsaw;
    }

    /// <summary>
    /// 设置合并检测状态
    /// </summary>
    /// <param name="openStatus"></param>
    public void setMergeCheck(bool openStatus)
    {
        isOpenMergeCheck = openStatus;
    }

    /// <summary>
    /// 碰撞开始
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isOpenMergeCheck)
            return;
        if (!isSelect)
            return;

        //获取被撞物体和其父对象
        JigsawContainerCpt collisionJCC = collision.gameObject.GetComponent<JigsawContainerCpt>();
        if (collisionJCC == null)
            return;
        //设置不可在拖拽
        CommonData.isDargMove = false;

        collisionJCC.addJigsawList(getJigsawList());
        // 最后删除当前容器
        Destroy(gameObject);
    }

}
