﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    public class GameGenreDto
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int GenreID { get; set; }
        public string GameName { get; set; }
        public string GenreName { get; set; }
    }
}