using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    [SerializeField] 
    bool m_IsTestMode;
    [SerializeField]
    ShopUpgrade m_Shop;
    [SerializeField]
    UIBtnManager m_UI;
    SaveManager m_Save;

    private void Awake()
    {
        m_Save = FindObjectOfType<SaveManager>();
    }
    private void Start()
    {
        var requestConfiguration = new RequestConfiguration
            .Builder()
            .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        LoadRewardAdCP();
        LoadRewardAdDP();
        LoadRewardAdRebirth();

    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region ¸®¿öµå ±¤°í
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "";
    RewardedAd rewardAd00;



    void LoadRewardAdCP()
    {
        rewardAd00 = new RewardedAd(m_IsTestMode ? rewardTestID : rewardID);
        rewardAd00.LoadAd(GetAdRequest());
        rewardAd00.OnUserEarnedReward += (sender, e) =>
        {
            m_Shop.CPAD();
            m_Save.SaveData();
        };
    }
    public void ShowRewardAdCP()
    {
         rewardAd00.Show();
         LoadRewardAdCP();
    }


    RewardedAd rewardAd01;
    void LoadRewardAdDP()
    {
        rewardAd01 = new RewardedAd(m_IsTestMode ? rewardTestID : rewardID);
        rewardAd01.LoadAd(GetAdRequest());
        rewardAd01.OnUserEarnedReward += (sender, e) =>
        {
            m_Shop.DPAD();
            m_Save.SaveData();
        };
    }

    public void ShowRewardAdDP()
    {
        rewardAd01.Show();
        LoadRewardAdDP();
    }


    RewardedAd rewardAd02;
    void LoadRewardAdRebirth()
    {
        rewardAd02 = new RewardedAd(m_IsTestMode ? rewardTestID : rewardID);
        rewardAd02.LoadAd(GetAdRequest());
        rewardAd02.OnUserEarnedReward += (sender, e) =>
        {
            m_UI.RebirthADBtn();
            m_Save.SaveData();
        };
    }

    public void ShowRewardAdRebirth()
    {
        rewardAd02.Show();
        LoadRewardAdRebirth();
    }
    #endregion

}

