﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.ApplicationLayer.Models.VMs
{
    public class TimeLineVm
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int AppUserId { get; set; }
        public int LikeCounts { get; set; }
        public int MentionsCounts { get; set; }
        public int ShareCounts { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public bool isLiked { get; set; }
        public List<int> Follows { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
