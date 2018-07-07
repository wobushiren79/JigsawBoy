﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public interface ISteamUserInfo 
{
    /// <summary>
    /// 获取steam用户数据
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="responseHandler"></param>
    void getSteamUserInfo(List<ulong> userId, HttpResponseHandler<SteamUserInfoResult> responseHandler);
}