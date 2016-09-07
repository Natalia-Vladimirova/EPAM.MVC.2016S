using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3.Repository
{
    public class CustomRepository
    {
        public static List<string> Sides { get; set; } = new List<string>()
        {
            "White",
            "Black"
        };



    }

    public enum Sides
    {
        White,
        Black
    }
}