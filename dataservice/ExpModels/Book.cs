﻿using System;
using System.Collections.Generic;

namespace dataservice.ExpModels
{
    public partial class Book
    {
        public Book()
        {
            Trainingsbook = new HashSet<Trainingsbook>();
        }

        public long Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }

        public ICollection<Trainingsbook> Trainingsbook { get; set; }
    }
}