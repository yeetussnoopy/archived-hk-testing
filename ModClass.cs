using System;
using System.Collections;
using System.Collections.Generic;
using DebugMod;
using Modding;
using Modding.Delegates;
using UnityEngine;
using UnityEngine.UI;

using System.IO;
using System.Linq;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using UnityEngine.UIElements;



namespace hit_counter
{
    public class hit_counter : Mod
    {
        private const string EmptyImage = "Empty";
        private const string BackgroundTopImage = "BackgroundTop";
        private const string BackgroundSplitImage = "BackgroundSplit";
        private const string BackgroundBottomImage = "BackgroundBottom";
        private const string SelectedSplitImage = "SelectedSplit";
        private const string SplitImage = "Split";
        private const float BackgroundWidth = 360f;
        private const float TitleHeight = 60f;
        private const float SplitHeight = 80f;
        private const float SplitImageSize = 55f;
        private const float SplitHitsWidth = 120f;
        private const float Margin = 25f;
        private const float Center = SplitHeight - 1.7f * Margin;
        private const int FontSizeNormal = 20;
        private const int FontSizeSmall = 16;
        private const int FontSizeMini = 14;

       

   
        new public string GetName() => "My First Mod";
        public override string GetVersion() => "v1";

        public GameObject canvas;
        public override void Initialize()
        {
            ModHooks.HeroUpdateHook += OnHeroSkibidiUpdate;

            ModHooks.AfterTakeDamageHook += ModHooks_AfterTakeDamageHook;

            canvas = new GameObject();
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = canvas.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);

            AddText("klkjkjkj", new Vector2(0, 60f), Vector2.zero, Modding.CanvasUtil.TrajanBold, FontSizeSmall);
        }

        public void AddText(string text, Vector2 pos, Vector2 size, Font font, int fontSize = 13, FontStyle style = FontStyle.Normal, TextAnchor alignment = TextAnchor.UpperLeft)
        {
            var t = new CanvasText(canvas, pos, size, font, text, fontSize, style, alignment);
        }






        private int ModHooks_AfterTakeDamageHook(int hazardType, int damageAmount)
        {
            hit_counter += 1;
            Log("you died skill issue!");
            Log("you died " + hit_counter + " times");
            return damageAmount;
        }

        public int hit_counter = 0;
        public void OnHeroSkibidiUpdate()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Log("Key Pressed");
            }
        }
        
        public void ModHooks_AfterTakeDamageHook()
        {
            hit_counter += 1;
                Log("you died skill issue!");
                Log("you died " + hit_counter + " times");
        }
    }
}