﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace dataservice.Models
{
    public partial class Infotosession
    {
        public int TrainingId { get; set; }
        public int TrainingSessionId { get; set; }

        [JsonIgnore]
        public Traininginfo Training { get; set; }
    }
}
