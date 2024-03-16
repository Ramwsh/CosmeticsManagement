using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsManagement.JetEFTest.Entities
{
    // Таблица доставка
    [Table("Доставка")]
    public class Delivery
    {
        // Ключевое поле
        [Key]
        public int DCode { get; set; }

        // Поле кода заказа
        public int OCode { get; set; }

        // Поле дата доставки
        public DateTime RealDeliveryDate { get; set; }

        // Поле - количество товаров в доставке
        public int PCountInDelivery { get; set; }
    }
}
