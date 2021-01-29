using System;
using System.Collections.Generic;
using System.Text;
using Day5Homework5.Entities;

namespace Day5Homework5.Abstract
{
    interface ICampaignService
    {
        public void ApplyDiscountToGame(Game game, Campaign campaign);
        public void Add(Campaign campaign);
        public void Delete(Campaign campaign);
        public void Update(Campaign campaign);
        public void GetCampaigns();

    }
}
