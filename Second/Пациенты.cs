namespace Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Пациенты
    {
        [Column("ФИО пациента")]
        [StringLength(50)]
        public string ФИО_пациента { get; set; }

        public int? Возраст { get; set; }

        [StringLength(10)]
        public string Пол { get; set; }

        public string Адрес { get; set; }

        [Key]
        [StringLength(15)]
        public string Телефон { get; set; }

        [Column("Дата обращения", TypeName = "date")]
        public DateTime? Дата_обращения { get; set; }

        [Column("Код болезни")]
        public long? Код_болезни { get; set; }

        [Column("Код сотрудника")]
        public long? Код_сотрудника { get; set; }

        [Column("Результат лечения")]
        [StringLength(50)]
        public string Результат_лечения { get; set; }

        public virtual Болезни Болезни { get; set; }

        public virtual Сотрудники Сотрудники { get; set; }
    }
}
