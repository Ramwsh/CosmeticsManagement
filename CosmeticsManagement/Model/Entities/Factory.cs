using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsManagement.Model.Entities
{
    // Таблица предприятия
    [Table("Предприятие")]
    public class Factory
    {
        // Ключевое поле
        [Key]
        public int FCode { get; set; }

        // Поле название предприятия
        public string? FName { get; set; }

        // Поле адресс предприятия
        public string? Address { get; set; }

        // Поле номер телефона предприятия
        public string? Phone { get; set; }
    }
}
