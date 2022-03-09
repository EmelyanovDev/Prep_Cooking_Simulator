using System;
using System.Collections.Generic;
using Skins;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public Skin headSkin;

        public List<Skin> boughtSkins = new List<Skin>();
    }
}