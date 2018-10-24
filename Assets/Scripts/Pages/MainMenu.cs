using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gui3D.Controls;
using Scripts.Data;

using UnityEngine.SceneManagement;

public class MainMenu : Page
{
    //---Label para cada Juego---
    MyGameLabel LabelGovernmentWorkOut;
    MyGameLabel LabelBalanceTheWorld;
    MyGameLabel LabelTaxMan;
    MyGameLabel LabelInvestment;
    MyGameLabel LabelCensorship;
    MyGameLabel LabelNetworking;
    MyGameLabel LabelB;
    MyGameLabel LabelTRadeBarriers;
    MyGameLabel LabelMemory;

    MyGameLabel LabelMenu;
    

    public void create()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Lives", 3);
        var mainLayout = MyGameObject.Instantiate<VerticalStack>();
        mainLayout.ActualDimentions = this.ActualDimentions;

        LabelMenu = MyGameObject.Instantiate<MyGameLabel>();
        LabelMenu.create("MENU", 5f, Color.white);
        LabelMenu.TextFontSize = 15;
        LabelMenu.AligmentMode = TextAnchor.MiddleCenter;
        mainLayout.AddChildren(LabelMenu);
        
        //------------Boton GovermentWorkOut----------
        EmptySpace GovermentWorkOut_Button = MyGameObject.Instantiate<EmptySpace>();
        GovermentWorkOut_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        GovermentWorkOut_Button.MarginProperty.Top = 0.05f;
        GovermentWorkOut_Button.createColiderBackground();
        GovermentWorkOut_Button.setBackground("Textures/MenuGamesMain/yellowButton", true);
        LabelGovernmentWorkOut = MyGameObject.Instantiate<MyGameLabel>();
        LabelGovernmentWorkOut.create("Government work out", 2f, Color.white);
        LabelGovernmentWorkOut.TextFontSize = 3;
        LabelGovernmentWorkOut.AligmentMode = TextAnchor.MiddleCenter;
        GovermentWorkOut_Button.AddChildren(LabelGovernmentWorkOut);
        // -- Redirecciona a la Scene correspondiente
        GovermentWorkOut_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("GovermentWorkOut");
        };
        //------------------------------------------------

        //------------Boton BalanceTheWorld----------
        EmptySpace BalanceTheWorld_Button = MyGameObject.Instantiate<EmptySpace>();
        BalanceTheWorld_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        BalanceTheWorld_Button.MarginProperty.Top = 0.05f;
        BalanceTheWorld_Button.createColiderBackground();
        BalanceTheWorld_Button.setBackground("Textures/MenuGamesMain/redButton", true);
        LabelBalanceTheWorld = MyGameObject.Instantiate<MyGameLabel>();
        LabelBalanceTheWorld.create("Balance The World", 2f, Color.white);
        LabelBalanceTheWorld.TextFontSize = 3;
        LabelBalanceTheWorld.AligmentMode = TextAnchor.MiddleCenter;
        BalanceTheWorld_Button.AddChildren(LabelBalanceTheWorld);
        // -- Redirecciona a la Scene correspondiente
        BalanceTheWorld_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("TheWorldBalance");
        };
        //------------------------------------------------

        //------------Boton TaxMan----------
        EmptySpace TaxMan_Button = MyGameObject.Instantiate<EmptySpace>();
        TaxMan_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        TaxMan_Button.MarginProperty.Top = 0.05f;
        TaxMan_Button.createColiderBackground();
        TaxMan_Button.setBackground("Textures/MenuGamesMain/yellowButton", true);
        LabelTaxMan = MyGameObject.Instantiate<MyGameLabel>();
        LabelTaxMan.create("Avoid the TaxMan", 2f, Color.white);
        LabelTaxMan.TextFontSize = 3;
        LabelTaxMan.AligmentMode = TextAnchor.MiddleCenter;
        TaxMan_Button.AddChildren(LabelTaxMan);
        // -- Redirecciona a la Scene correspondiente
        TaxMan_Button.TapEvent += (MyGameObject sender, System.EventArgs e) =>
        {
            SceneManager.LoadScene("TaxMan");
        };
        //------------------------------------------------

        //------------Boton Investment----------
        EmptySpace Investment_Button = MyGameObject.Instantiate<EmptySpace>();
        Investment_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        Investment_Button.MarginProperty.Top = 0.05f;
        Investment_Button.createColiderBackground();
        Investment_Button.setBackground("Textures/MenuGamesMain/redButton", true);
        LabelInvestment = MyGameObject.Instantiate<MyGameLabel>();
        LabelInvestment.create("Invest To Progress", 2f, Color.white);
        LabelInvestment.TextFontSize = 3;
        LabelInvestment.AligmentMode = TextAnchor.MiddleCenter;
        Investment_Button.AddChildren(LabelInvestment);
        // -- Redirecciona a la Scene correspondiente
        Investment_Button.TapEvent += (MyGameObject sender, System.EventArgs e) =>
        {
            SceneManager.LoadScene("InvestToProgress");
        };
        //------------------------------------------------


        //------------Boton Censorship----------
        EmptySpace Censorship_Button = MyGameObject.Instantiate<EmptySpace>();
        Censorship_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        Censorship_Button.MarginProperty.Top = 0.05f;
        Censorship_Button.createColiderBackground();
        Censorship_Button.setBackground("Textures/MenuGamesMain/yellowButton", true);
        LabelCensorship = MyGameObject.Instantiate<MyGameLabel>();
        LabelCensorship.create("Censorship", 2f, Color.white);
        LabelCensorship.TextFontSize = 3;
        LabelCensorship.AligmentMode = TextAnchor.MiddleCenter;
        Censorship_Button.AddChildren(LabelCensorship);
        // -- Redirecciona a la Scene correspondiente
        Censorship_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("CensorShip");
        };
        //------------------------------------------------

        //------------Boton NetWorking----------
        EmptySpace NetWorking_Button = MyGameObject.Instantiate<EmptySpace>();
        NetWorking_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        NetWorking_Button.MarginProperty.Top = 0.05f;
        NetWorking_Button.createColiderBackground();
        NetWorking_Button.setBackground("Textures/MenuGamesMain/redButton", true);
        LabelNetworking = MyGameObject.Instantiate<MyGameLabel>();
        LabelNetworking.create("Free Trade", 2f, Color.white);
        LabelNetworking.TextFontSize = 3;
        LabelNetworking.AligmentMode = TextAnchor.MiddleCenter;
        NetWorking_Button.AddChildren(LabelNetworking);
        // -- Redirecciona a la Scene correspondiente
        NetWorking_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("Networking");
        };
        //------------------------------------------------

        //------------Boton Bureaucracy_Button----------
        EmptySpace Bureaucracy_Button = MyGameObject.Instantiate<EmptySpace>();
        Bureaucracy_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        Bureaucracy_Button.MarginProperty.Top = 0.05f;
        Bureaucracy_Button.createColiderBackground();
        Bureaucracy_Button.setBackground("Textures/MenuGamesMain/yellowButton", true);
        LabelB = MyGameObject.Instantiate<MyGameLabel>();
        LabelB.create("Bureaucracy", 2f, Color.white);
        LabelB.TextFontSize = 3;
        LabelB.AligmentMode = TextAnchor.MiddleCenter;
        Bureaucracy_Button.AddChildren(LabelB);
        // -- Redirecciona a la Scene correspondiente
        Bureaucracy_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("Bureaucracy");
        };
        //------------------------------------------------

        //------------Boton TradeBarriers_Button----------
        EmptySpace TradeBarriers_Button = MyGameObject.Instantiate<EmptySpace>();
        TradeBarriers_Button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        TradeBarriers_Button.MarginProperty.Top = 0.05f;
        TradeBarriers_Button.createColiderBackground();
        TradeBarriers_Button.setBackground("Textures/MenuGamesMain/redButton", true);
        LabelTRadeBarriers = MyGameObject.Instantiate<MyGameLabel>();
        LabelTRadeBarriers.create("JumpTheTradeBarriers", 2f, Color.white);
        LabelTRadeBarriers.TextFontSize = 3;
        LabelTRadeBarriers.AligmentMode = TextAnchor.MiddleCenter;
        TradeBarriers_Button.AddChildren(LabelTRadeBarriers);
        // -- Redirecciona a la Scene correspondiente
        TradeBarriers_Button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("JumpTheTradeBarriers");
        };
        //------------------------------------------------


        //------------Boton Memory_button----------
        EmptySpace Memory_button = MyGameObject.Instantiate<EmptySpace>();
        Memory_button.ActualDimentions = new Vector3(0.6f, 0.2f, 1f);
        Memory_button.MarginProperty.Top = 0.05f;
        Memory_button.createColiderBackground();
        Memory_button.setBackground("Textures/MenuGamesMain/yellowButton", true);
        LabelMemory = MyGameObject.Instantiate<MyGameLabel>();
        LabelMemory.create("Memory", 2f, Color.white);
        LabelMemory.TextFontSize = 3;
        LabelMemory.AligmentMode = TextAnchor.MiddleCenter;
        Memory_button.AddChildren(LabelMemory);
        // -- Redirecciona a la Scene correspondiente
        Memory_button.TapEvent += (MyGameObject sender, System.EventArgs e) => {
            SceneManager.LoadScene("Memory");
        };
        //------------------------------------------------

        // se hace el boton hijo de la Scene principal
        mainLayout.AddChildren(GovermentWorkOut_Button);
        mainLayout.AddChildren(BalanceTheWorld_Button);
        mainLayout.AddChildren(TaxMan_Button);
        mainLayout.AddChildren(Investment_Button);
        mainLayout.AddChildren(Censorship_Button);
        mainLayout.AddChildren(NetWorking_Button);
        mainLayout.AddChildren(Bureaucracy_Button);
        mainLayout.AddChildren(TradeBarriers_Button);
        mainLayout.AddChildren(Memory_button);




        this.AddChildren(mainLayout);
        this.setBackground("Textures/MenuGamesMain/blackButton", true);
        this.correctCenter(false);
    }
}
