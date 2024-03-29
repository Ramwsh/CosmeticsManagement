﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsManagement.Model.Entities
{
    // Таблица "Товар"
    [Table("Товар")]
    public class Product
    {
        // Поле код товара (ключ)
        [Key]
        public int PCode { get; set; }

        // код бренда
        public int BCode { get; set; }

        // название бренда
        public string? BName { get; set; }

        // Поле имя товара
        public string? PName { get; set; }

        // Поле величина измерения (литр, кг, шт. и т.д).
        public string? Measure { get; set; }

        // Поле цена
        public int Price { get; set; }
    }
}

