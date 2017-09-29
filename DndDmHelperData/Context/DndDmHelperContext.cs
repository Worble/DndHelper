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

        /// <summary>
        /// Gets or sets the note types.
        /// </summary>
        /// <value>
        /// The note types.
        /// </value>
        public virtual DbSet<NoteType> NoteTypes { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public virtual DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public virtual DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the template character skills.
        /// </summary>
        /// <value>
        /// The template character skills.
        /// </value>
        public virtual DbSet<TemplateCharacterSkill> TemplateCharacterSkills { get; set; }

        /// <summary>
        /// Gets or sets the game character skills.
        /// </summary>
        /// <value>
        /// The game character skills.
        /// </value>
        public virtual DbSet<GameCharacterSkill> GameCharacterSkills { get; set; }

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
            modelBuilder.Entity<TemplateCharacter>().HasMany(e => e.Skills).WithOne(e => e.Character);

            modelBuilder.Entity<GameCharacter>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.Level).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.RaceID).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.ClassID).IsRequired();
            modelBuilder.Entity<GameCharacter>().Property(e => e.GameID).IsRequired();
            modelBuilder.Entity<GameCharacter>().HasOne(e => e.Race);
            modelBuilder.Entity<GameCharacter>().HasOne(e => e.Class);
            modelBuilder.Entity<GameCharacter>().HasMany(e => e.BaseStats).WithOne(e => e.Character);
            modelBuilder.Entity<GameCharacter>().HasMany(e => e.Skills).WithOne(e => e.Character);

            modelBuilder.Entity<Class>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<Race>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<BaseStat>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<GameCharacterBaseStat>().Property(e => e.Value).IsRequired();

            modelBuilder.Entity<TemplateCharacterBaseStat>().Property(e => e.Value).IsRequired();

            modelBuilder.Entity<NoteType>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<Note>().HasOne(e => e.NoteType);
            modelBuilder.Entity<Note>().HasOne(e => e.Game);
            modelBuilder.Entity<Note>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Note>().Property(e => e.Content).IsRequired();
            modelBuilder.Entity<Note>().Property(e => e.NoteTypeID).IsRequired();
            modelBuilder.Entity<Note>().Property(e => e.GameID).IsRequired();

            modelBuilder.Entity<Skill>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<TemplateCharacterSkill>().Property(e => e.Value).IsRequired();
            modelBuilder.Entity<TemplateCharacterSkill>().Property(e => e.Proficient).IsRequired();

            modelBuilder.Entity<GameCharacterSkill>().Property(e => e.Value).IsRequired();
            modelBuilder.Entity<GameCharacterSkill>().Property(e => e.Proficient).IsRequired();

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
