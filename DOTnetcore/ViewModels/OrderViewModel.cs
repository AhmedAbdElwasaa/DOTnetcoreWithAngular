﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4,ErrorMessage ="too small")]
        public string OrderNumber { get; set; }
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
