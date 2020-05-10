using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataHolder:IGameDataHolder
{
    private GameTexts _texts;

    public GameDataHolder()
    {
        LoadAssets();
    }

    public string GetText(TextType type)
    {
        return _texts.gameTexts.FirstOrDefault(t=>t.type==type).phrase;
    }


    private void LoadAssets()
    {
        _texts = (GameTexts)Resources.Load("GameTexts", typeof(GameTexts));
    }

}
