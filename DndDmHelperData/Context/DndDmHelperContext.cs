using DndDmHelperData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndDmHelperData.Context
{
    /// <summary>
    /// Handles the entities between the database and the application
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DndDmHelperContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DndDmHelperContext"/> class.
        /// </summary>
        public DndDmHelperContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DndDmHelperContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DndDmHelperContext(DbContextOptions<DndDmHelperContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the users in the database.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the games in the database.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public virtual DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the template characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public virtual DbSet<TemplateCharacter> TemplateCharacters { get; set; }

        /// <summary>
        /// Gets or sets the game owned characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public virtual DbSet<GameCharacter> GameCharacters { get; set; }

        /// <summary>
        /// Gets or sets the races in the database.
        /// </summary>
        /// <value>
        /// The races.
        /// </value>
        public virtual DbSet<Race> Races { get; set; }

        /// <summary>
        /// Gets or sets the classes in the database.
        /// </summary>
        /// <value>
        /// The classes.
        /// </value>
        public virtual DbSet<Class> Classes { get; set; }

        /// <summary>
        /// Gets or sets the base stats.
        /// </summary>
        /// <value>
        /// The base stats.
        /// </value>
        public virtual DbSet<BaseStat> BaseStats { get; set; }

        /// <summary>
        /// Gets or sets the game character base stats.
        /// </summary>
        /// <value>
        /// The game character base stats.
        /// </value>
        public virtual DbSet<GameCharacterBaseStat> GameCharacterBaseStats { get; set; }

        /// <summary>
        /// Gets or sets the template character base stats.
        /// </summary>
        /// <value>
        /// The template character base stats.
        /// </value>
        public virtual DbSet<TemplateCharacterBaseStat> TemplateCharacterBaseStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //remove this in production, use global variable instead
                optionsBuilder.UseNpgsql(@"User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=DndDmHelper;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.EmailAddress).IsRequired();
            modelBuilder.Entity<User>().HasIndex(e => e.EmailAddress).IsUnique();
            modelBuilder.Entity<User>().HasMany(e => e.Games).WithOne(e => e.Owner);

            modelBuilder.Entity<Game>().Property(e => e.OwnerID).IsRequired();
            modelBuilder.Entity<Game>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Game>().HasMany(e => e.Characters).WithOne(e => e.Game);

            modelBuilder.Entity<TemplateCharacter>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<TemplateCharacter>().Property(e => e.Level).IsRequired();
            modelBuilder.Entity<TemplateCharacter>().Property(e => e.RaceID).IsRequired();
            modelBuilder.Entity<TemplateCharacter>().Property(e => e.ClassID).IsRequired();
            modelBuilder.Entity<TemplateCharacter>().HasOne(e => e.Race);
            modelBuilder.Entity<TemplateCharacter>().HasOne(e => e.Class);
            modelBuilder.Entity<TemplateCharacter>().HasMany(e => e.BaseStats).WithOne(e => e.Character);

            modelBuilder.Entity<GameCharacter>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.Level).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.RaceID).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.ClassID).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.GameID).IsRequired();
            modelBuilder.Entity<GameCharacter>().HasOne(e => e.Race);
            modelBuilder.Entity<GameCharacter>().HasOne(e => e.Class);
            modelBuilder.Entity<GameCharacter>().HasMany(e => e.BaseStats).WithOne(e => e.Character);

            modelBuilder.Entity<Class>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<Race>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<BaseStat>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<GameCharacterBaseStat>().Property(e => e.Value).IsRequired();

            modelBuilder.Entity<TemplateCharacterBaseStat>().Property(e => e.Value).IsRequired();


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var changes = from e in this.ChangeTracker.Entries<BaseEntity>()
                          where e.State != EntityState.Unchanged
                          select e;
            foreach (var change in changes)
            {
                if (change.State == EntityState.Added)
                {
                    change.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (change.State == EntityState.Modified)
                {
                    change.Entity.EditedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
