﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CurrencyConverter;

namespace WebApplication1.Models
{
    public class CurrencyConverterModel
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("GBP", "USD", "CAD", "EUR")]
        public string CurrencyFrom { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("GBP", "USD", "CAD", "EUR")]
        public string CurrencyTo { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal Quantity { get; set; }

        public CurrencyConverterModel()
        {

        }
    }
}
