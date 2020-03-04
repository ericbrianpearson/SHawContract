﻿using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Models.Common;

namespace ShawContract.Providers.PDMS.Models
{
    public class CarpetSpecification : BaseSpecification
    {
        [JsonProperty("secondaryBacking")]
        public string Backing { get; set; }

        [JsonProperty("fiber")]
        public string Fiber { get; set; }

        [JsonProperty("tuftedWeight")]
        public MeasuringSystem TuftedWeight { get; set; }
    }
}