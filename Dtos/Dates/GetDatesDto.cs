using System;
using System.Collections.Generic;
using Cis_part2.Models;

namespace Cis_part2.Dtos.Dates
{
    public class GetDatesDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}