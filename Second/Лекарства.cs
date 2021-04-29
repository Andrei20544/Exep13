namespace Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Лекарства
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Лекарства()
        {
            Болезни = new HashSet<Болезни>();
            Болезни1 = new HashSet<Болезни>();
            Болезни2 = new HashSet<Болезни>();
        }

        [Key]
        [Column("Код лекарства")]
        public long Код_лекарства { get; set; }

        [StringLength(100)]
        public string Наименование { get; set; }

        public string Показания { get; set; }

        public string Противопоказания { get; set; }

        [StringLength(30)]
        public string Упаковка { get; set; }

        [Column(TypeName = "money")]
        public decimal? Стоимость { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Болезни> Болезни { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Болезни> Болезни1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Болезни> Болезни2 { get; set; }
    }
}
