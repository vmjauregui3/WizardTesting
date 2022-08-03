﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WizardTesting
{
    public class MenuManager
    {
        /*
        Menu menu;
        bool isTransitioning;

        void Transition(GameTime gameTime)
        {
            if(isTransitioning)
            {
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    menu.Items[i].Image.Update(gameTime);
                    float first = menu.Items[0].Image.Alpha;
                    float last = menu.Items[menu.Items.Count - 1].Image.Alpha;
                    if(first == 0.0f && last == 0.0f)
                    { menu.ID = menu.Items[menu.ItemNumber].LinkID; }
                    else if(first == 1.0f && last == 1.0f)
                    { 
                        isTransitioning = false; 
                        foreach(MenuItem item in menu.Items)
                        { item.Image.RestoreEffects(); }
                    }
                }
            }
        }

        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            menu.Unloadcontent();
            menu = xmlMenuManager.Load(menu.ID);
            menu.Loadcontent();
            menu.OnMenuChange += menu_OnMenuChange;
            menu.Transition(0.0f);

            foreach (MenuItem item in menu.Items)
            {
                item.Image.StoreEffects();
                item.Image.ActivateEffect("FadeEffect");
            }
        }

        public void Loadcontent(string menuPath)
        {
            if(menuPath != String.Empty)
            { menu.ID = menuPath; }    
        }

        public void Unloadcontent()
        {
            menu.Unloadcontent();
        }

        public void Update(GameTime gameTime)
        {
            if (!isTransitioning)
            { menu.Update(gameTime); }
            if(InputManager.Instance.KeyPressed(Keys.Enter) && !isTransitioning)
            {
                if(menu.Items[menu.ItemNumber].LinkType == "Screen")
                { ScreenManager.Instance.ChangeScreens(menu.Items[menu.ItemNumber].LinkID); }
                else
                { 
                    isTransitioning = true;
                    menu.Transition(1.0f);
                    foreach (MenuItem item in menu.Items)
                    {
                        item.Image.StoreEffects();
                        item.Image.ActivateEffect("FadeEffect");
                    }
                }
            }
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
        */
    }
}
