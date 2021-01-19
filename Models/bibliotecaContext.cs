using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class bibliotecaContext : DbContext
    {
        public bibliotecaContext()
        {
        }

        public bibliotecaContext(DbContextOptions<bibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<AutoresLibro> AutoresLibro { get; set; }
        public virtual DbSet<Bibliotecario> Bibliotecario { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Lector> Lector { get; set; }
        public virtual DbSet<Libreros> Libreros { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        public virtual DbSet<Subclasificacion> Subclasificacion { get; set; }
        public virtual DbSet<TipoPrestamo> TipoPrestamo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=biblioteca;user=root;password=12345", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PRIMARY");

                entity.ToTable("autor");

                entity.Property(e => e.IdAutor).HasColumnName("ID_Autor");

                entity.Property(e => e.ApellidoAutor)
                    .HasColumnName("Apellido_Autor")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nacionalidad)
                    .HasColumnName("Nacionalidad")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NombreAutor)
                    .HasColumnName("Nombre_Autor")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AutoresLibro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("autores_libro");

                entity.HasIndex(e => e.RAutor)
                    .HasName("ID_Autor_idx");

                entity.HasIndex(e => e.RIsbn)
                    .HasName("ISBN_idx");

                entity.Property(e => e.RAutor).HasColumnName("R_Autor");

                entity.Property(e => e.RIsbn)
                    .HasColumnName("R_ISBN")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.RAutorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID_Autor");

                entity.HasOne(d => d.RIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RIsbn)
                    .HasConstraintName("ISBN");
            });

            modelBuilder.Entity<Bibliotecario>(entity =>
            {
                entity.HasKey(e => e.IdBibliotecario)
                    .HasName("PRIMARY");

                entity.ToTable("bibliotecario");

                entity.Property(e => e.IdBibliotecario).HasColumnName("ID_Bibliotecario");

                entity.Property(e => e.ApellidoBibliotecario)
                    .HasColumnName("Apellido_Bibliotecario")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Contraseña)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NombreBibliotecario)
                    .HasColumnName("Nombre_Bibliotecario")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.HasKey(e => e.IdClasificacion)
                    .HasName("PRIMARY");

                entity.ToTable("clasificacion");

                entity.Property(e => e.IdClasificacion).HasColumnName("ID_Clasificacion");

                entity.Property(e => e.NombreClasificacion)
                    .HasColumnName("Nombre_Clasificacion")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PRIMARY");

                entity.ToTable("editorial");

                entity.Property(e => e.IdEditorial).HasColumnName("ID_Editorial");

                entity.Property(e => e.NombreEditorial)
                    .HasColumnName("Nombre_Editorial")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Lector>(entity =>
            {
                entity.HasKey(e => e.IdLector)
                    .HasName("PRIMARY");

                entity.ToTable("lector");

                entity.Property(e => e.IdLector).HasColumnName("ID_Lector");

                entity.Property(e => e.Apellido)
                    .HasColumnName("Apellido")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Correo)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrestamosActivos).HasColumnName("Prestamos_Activos");
            });

            modelBuilder.Entity<Libreros>(entity =>
            {
                entity.HasKey(e => e.IdLibrero)
                    .HasName("PRIMARY");

                entity.ToTable("libreros");

                entity.Property(e => e.IdLibrero).HasColumnName("ID_Librero");

                entity.Property(e => e.NombreLibrero)
                    .HasColumnName("Nombre_Librero")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PRIMARY");

                entity.ToTable("libro");

                entity.HasIndex(e => e.RClasificacion)
                    .HasName("ID_Clasificacion_idx");

                entity.HasIndex(e => e.REditorial)
                    .HasName("ID_Editorial_idx");

                entity.HasIndex(e => e.RSubclasificacion)
                    .HasName("ID_Subclasificacion_idx");

                entity.HasIndex(e => e.RUbicacion)
                    .HasName("ID_Area_idx");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RClasificacion).HasColumnName("R_Clasificacion");

                entity.Property(e => e.REditorial).HasColumnName("R_Editorial");

                entity.Property(e => e.RSubclasificacion).HasColumnName("R_Subclasificacion");

                entity.Property(e => e.RUbicacion).HasColumnName("R_Ubicacion");

                entity.Property(e => e.Titulo)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.RClasificacionNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.RClasificacion)
                    .HasConstraintName("ID_Clasificacion");

                entity.HasOne(d => d.REditorialNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.REditorial)
                    .HasConstraintName("ID_Editorial");

                entity.HasOne(d => d.RSubclasificacionNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.RSubclasificacion)
                    .HasConstraintName("ID_Subclasificacion");

                entity.HasOne(d => d.RUbicacionNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.RUbicacion)
                    .HasConstraintName("ID_Area");
            });

            modelBuilder.Entity<Prestamos>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PRIMARY");

                entity.ToTable("prestamos");

                entity.HasIndex(e => e.RLector)
                    .HasName("ID_Lector_idx");

                entity.HasIndex(e => e.RLibro)
                    .HasName("ID_Libro_idx");

                entity.HasIndex(e => e.RTipoPrestamo)
                    .HasName("ID_Tipo_Prestamo_idx");

                entity.Property(e => e.IdPrestamo).HasColumnName("ID_Prestamo");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnName("Fecha_Devolucion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("Fecha_Entrega")
                    .HasColumnType("date");

                entity.Property(e => e.RLector).HasColumnName("R_Lector");

                entity.Property(e => e.RLibro)
                    .HasColumnName("R_Libro")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RTipoPrestamo).HasColumnName("R_Tipo_Prestamo");

                entity.HasOne(d => d.RLectorNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.RLector)
                    .HasConstraintName("ID_Lector");

                entity.HasOne(d => d.RLibroNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.RLibro)
                    .HasConstraintName("ID_Libro");

                entity.HasOne(d => d.RTipoPrestamoNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.RTipoPrestamo)
                    .HasConstraintName("ID_Tipo");
            });

            modelBuilder.Entity<Subclasificacion>(entity =>
            {
                entity.HasKey(e => e.IdSubclasificacion)
                    .HasName("PRIMARY");

                entity.ToTable("subclasificacion");

                entity.Property(e => e.IdSubclasificacion).HasColumnName("ID_Subclasificacion");

                entity.Property(e => e.NombreSubclasificacion)
                    .HasColumnName("Nombre_Subclasificacion")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TipoPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_prestamo");

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.Property(e => e.Tipo)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
