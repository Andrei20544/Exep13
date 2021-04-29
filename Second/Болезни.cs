namespace Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Болезни
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Болезни()
        {
            Пациенты = new HashSet<Пациенты>();
        }

        [Key]
        [Column("Код болезни")]
        public long Код_болезни { get; set; }

        [StringLength(50)]
        public string Наиенование { get; set; }

        public string Симптомы { get; set; }

        public string Продолжительнось { get; set; }

        public string Последствия { get; set; }

        [Column("Код лекарства 1")]
        public long? Код_лекарства_1 { get; set; }

        [Column("Код лекарства 2")]
        public long? Код_лекарства_2 { get; set; }

        [Column("Код лекарства 3")]
        public long? Код_лекарства_3 { get; set; }

        public virtual Лекарства Лекарства { get; set; }

        public virtual Лекарства Лекарства1 { get; set; }

        public virtual Лекарства Лекарства2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пациенты> Пациенты { get; set; }
    }
}
