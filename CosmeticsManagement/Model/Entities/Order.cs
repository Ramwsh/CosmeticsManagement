﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsManagement.Model.Entities
{
    // Orders table
    [Table("Заказ")]
    public class Order
    {
        // Поле код заказа (ключевое)
        [Key]
        public int OCode { get; set; }

        // Поле код предприятия
        public int FCode { get; set; }

        // Название предприятия
        public string? FName { get; set; }

        // Поле код товара
        public int PCode { get; set; }

        // название товара
        public string? PName { get; set; }

        // Поле количество товаров
        public int ProductCountInOrder { get; set; }

        // Поле дата заказа
        public DateTime OrderDate { get; set; }

        // Поле дата исполнения заказа
        public DateTime ExecutionDate { get; set; }
    }
}
