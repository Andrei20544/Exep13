namespace Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Должности
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Должности()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        [Key]
        [Column("Код должности")]
        public long Код_должности { get; set; }

        [Column("Наименование должности")]
        [StringLength(50)]
        public string Наименование_должности { get; set; }

        [Column(TypeName = "money")]
        public decimal? Оклад { get; set; }

        public string Обязонности { get; set; }

        public string Требования { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
