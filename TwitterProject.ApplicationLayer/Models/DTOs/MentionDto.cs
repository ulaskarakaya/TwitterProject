﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.ApplicationLayer.Models.DTOs
{
    public class MentionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public int TweetId { get; set; }
        public string UserImage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
