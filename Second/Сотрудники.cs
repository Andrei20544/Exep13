namespace Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Сотрудники
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сотрудники()
        {
            Пациенты = new HashSet<Пациенты>();
        }

        [Key]
        [Column("Код сотрудника")]
        public long Код_сотрудника { get; set; }

        public string ФИО { get; set; }

        public int? Возраст { get; set; }

        [StringLength(10)]
        public string Пол { get; set; }

        public string Адрес { get; set; }

        [StringLength(15)]
        public string Телефон { get; set; }

        [Column("Паспортные данные")]
        public string Паспортные_данные { get; set; }

        [Column("Код должности")]
        public long? Код_должности { get; set; }

        public virtual Должности Должности { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пациенты> Пациенты { get; set; }
    }
}
