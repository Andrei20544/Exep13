using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Second
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Болезни> Болезни { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Лекарства> Лекарства { get; set; }
        public virtual DbSet<Пациенты> Пациенты { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Болезни>()
                .Property(e => e.Наиенование)
                .IsUnicode(false);

            modelBuilder.Entity<Болезни>()
                .Property(e => e.Симптомы)
                .IsUnicode(false);

            modelBuilder.Entity<Болезни>()
                .Property(e => e.Продолжительнось)
                .IsUnicode(false);

            modelBuilder.Entity<Болезни>()
                .Property(e => e.Последствия)
                .IsUnicode(false);

            modelBuilder.Entity<Должности>()
                .Property(e => e.Наименование_должности)
                .IsUnicode(false);

            modelBuilder.Entity<Должности>()
                .Property(e => e.Оклад)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Должности>()
                .Property(e => e.Обязонности)
                .IsUnicode(false);

            modelBuilder.Entity<Должности>()
                .Property(e => e.Требования)
                .IsUnicode(false);

            modelBuilder.Entity<Лекарства>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Лекарства>()
                .Property(e => e.Показания)
                .IsUnicode(false);

            modelBuilder.Entity<Лекарства>()
                .Property(e => e.Противопоказания)
                .IsUnicode(false);

            modelBuilder.Entity<Лекарства>()
                .Property(e => e.Упаковка)
                .IsUnicode(false);

            modelBuilder.Entity<Лекарства>()
                .Property(e => e.Стоимость)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Лекарства>()
                .HasMany(e => e.Болезни)
                .WithOptional(e => e.Лекарства)
                .HasForeignKey(e => e.Код_лекарства_1);

            modelBuilder.Entity<Лекарства>()
                .HasMany(e => e.Болезни1)
                .WithOptional(e => e.Лекарства1)
                .HasForeignKey(e => e.Код_лекарства_2);

            modelBuilder.Entity<Лекарства>()
                .HasMany(e => e.Болезни2)
                .WithOptional(e => e.Лекарства2)
                .HasForeignKey(e => e.Код_лекарства_3);

            modelBuilder.Entity<Пациенты>()
                .Property(e => e.ФИО_пациента)
                .IsUnicode(false);

            modelBuilder.Entity<Пациенты>()
                .Property(e => e.Пол)
                .IsUnicode(false);

            modelBuilder.Entity<Пациенты>()
                .Property(e => e.Адрес)
                .IsUnicode(false);

            modelBuilder.Entity<Пациенты>()
                .Property(e => e.Телефон)
                .IsUnicode(false);

            modelBuilder.Entity<Пациенты>()
                .Property(e => e.Результат_лечения)
                .IsUnicode(false);

            modelBuilder.Entity<Сотрудники>()
                .Property(e => e.ФИО)
                .IsUnicode(false);

            modelBuilder.Entity<Сотрудники>()
                .Property(e => e.Пол)
                .IsUnicode(false);

            modelBuilder.Entity<Сотрудники>()
                .Property(e => e.Адрес)
                .IsUnicode(false);

            modelBuilder.Entity<Сотрудники>()
                .Property(e => e.Телефон)
                .IsUnicode(false);

            modelBuilder.Entity<Сотрудники>()
                .Property(e => e.Паспортные_данные)
                .IsUnicode(false);
        }
    }
}
