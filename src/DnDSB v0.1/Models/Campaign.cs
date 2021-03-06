﻿using DnDSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDSB
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }      
        public string System { get; set; } = "DnD 3.5";
        public DateTime EmbarkDate { get; set; }

        public virtual ICollection<Playercs> Gm { get; set; }
        public virtual ICollection<Playercs> Players { get; set; }
        public virtual ICollection<CharacterBase> CharacterBase { get; set; }
    }
}
