﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamComeback_V2.Models;

namespace TeamComeback_V2
{
    public class Common
    {
        public static List<Answer> GetAnswers()
        {
            List<Answer> list = new List<Answer>();
            list.Add(new Answer() { ID = 4, Name = "Excellent", Css = "check w3"});
            list.Add(new Answer() { ID = 3, Name = "Good", Css = "check w3ls" });
            list.Add(new Answer() { ID = 2, Name = "Neutral", Css = "check wthree" });
            list.Add(new Answer() { ID = 1, Name = "Poor", Css = "check w3_agileits" });
            return list;
        }
    }
}