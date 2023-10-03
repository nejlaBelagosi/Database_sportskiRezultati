using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sportskiRezultati.Models
{
    public partial class sportskiRezultatiContext : DbContext
    {
        public sportskiRezultatiContext()
        {
        }

        public sportskiRezultatiContext(DbContextOptions<sportskiRezultatiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AwayTeam> AwayTeams { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<HomeTeam> HomeTeams { get; set; } = null!;
        public virtual DbSet<League> Leagues { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<ShowLeague> ShowLeagues { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<VwMatch> VwMatches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MAC1B56\\SQLEXPRESS;Database=sportskiRezultati;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AwayTeam>(entity =>
            {
                entity.ToTable("awayTeam");

                entity.Property(e => e.AwayTeamId)
                    .ValueGeneratedNever()
                    .HasColumnName("awayTeamID");

                entity.Property(e => e.AwayTeam1).HasColumnName("awayTeam");

                entity.HasOne(d => d.AwayTeam1Navigation)
                    .WithMany(p => p.AwayTeams)
                    .HasForeignKey(d => d.AwayTeam1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__awayTeam__awayTe__300424B4");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("countryID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .HasColumnName("countryName");
            });

            modelBuilder.Entity<HomeTeam>(entity =>
            {
                entity.ToTable("homeTeam");

                entity.Property(e => e.HomeTeamId)
                    .ValueGeneratedNever()
                    .HasColumnName("homeTeamID");

                entity.Property(e => e.HomeTeam1).HasColumnName("homeTeam");

                entity.HasOne(d => d.HomeTeam1Navigation)
                    .WithMany(p => p.HomeTeams)
                    .HasForeignKey(d => d.HomeTeam1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__homeTeam__homeTe__30F848ED");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.ToTable("league");

                entity.Property(e => e.LeagueId)
                    .ValueGeneratedNever()
                    .HasColumnName("leagueID");

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.LeagueName)
                    .HasMaxLength(50)
                    .HasColumnName("leagueName");

                entity.Property(e => e.NumberOfTeams).HasColumnName("numberOfTeams");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__league__countryI__31EC6D26");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("match");

                entity.Property(e => e.MatchId)
                    .ValueGeneratedNever()
                    .HasColumnName("matchID");

                entity.Property(e => e.AwayTeamGoal).HasColumnName("awayTeamGoal");

                entity.Property(e => e.HomeTeamGoal).HasColumnName("homeTeamGoal");

                entity.Property(e => e.MatchDate)
                    .HasColumnType("date")
                    .HasColumnName("matchDate");

                entity.Property(e => e.MatchTime).HasColumnName("matchTime");

                entity.Property(e => e.Results)
                    .HasMaxLength(50)
                    .HasColumnName("results");

                entity.Property(e => e.Venue)
                    .HasMaxLength(50)
                    .HasColumnName("venue");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("playerID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.JerseyNumber).HasColumnName("jerseyNumber");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(50)
                    .HasColumnName("playerName");

                entity.Property(e => e.PlayerSurname)
                    .HasMaxLength(50)
                    .HasColumnName("playerSurname");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");

                entity.Property(e => e.TeamId).HasColumnName("teamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__players__teamID__35BCFE0A");
            });

            modelBuilder.Entity<ShowLeague>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("showLeague");

                entity.Property(e => e.LeagueName)
                    .HasMaxLength(50)
                    .HasColumnName("leagueName");

                entity.Property(e => e.NumberOfTeams).HasColumnName("numberOfTeams");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.TeamId)
                    .ValueGeneratedNever()
                    .HasColumnName("teamID");

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.LeagueId).HasColumnName("leagueID");

                entity.Property(e => e.MatchId).HasColumnName("matchID");

                entity.Property(e => e.NumberOfPlayers).HasColumnName("numberOfPlayers");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .HasColumnName("teamName");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__team__countryID__32E0915F");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__team__leagueID__33D4B598");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__team__matchID__34C8D9D1");
            });

            modelBuilder.Entity<VwMatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMatch");

                entity.Property(e => e.MatchDate)
                    .HasColumnType("date")
                    .HasColumnName("matchDate");

                entity.Property(e => e.Venue)
                    .HasMaxLength(50)
                    .HasColumnName("venue");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
