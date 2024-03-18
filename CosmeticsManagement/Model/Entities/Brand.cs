using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsManagement.Model.Entities
{
    // Таблица для сущностей типа Ьренд
    [Table("Бренд")]
    public class Brand
    {

        // Поле кода. Ключевое поле указывается с аттрибутом [Key]
        [Key]
        public int BCode { get; set; }

        // Поле имени.
        public string? BName { get; set; }        
    }
}
