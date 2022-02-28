using System;
using System.Collections.Generic;
using Skins;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public Skin HeadSkin;
        public Skin FaceSkin;
        public Skin BodySkin;
        
        public List<Skin> Skins;
    }
}