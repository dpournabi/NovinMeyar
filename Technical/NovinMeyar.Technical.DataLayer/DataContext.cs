using Microsoft.EntityFrameworkCore;
using NovinMeyar.Domain.Models;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.Entities.FiveSecurityParts;
using NovinMeyar.Technical.Domain.Views;

namespace NovinMeyar.Technical.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<CounterWightAntiShocksInformations> CounterWightAntiShocksInformations { get; set; }
        public DbSet<CabinAntiShocksInformations> CabinAntiShocksInformations { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<CounterWeightAntiShockType> CounterWeightAntiShockTypes { get; set; }
        public DbSet<CounterWeightInformation> CounterWeightInformations { get; set; }
        public DbSet<CabinDoor> CabinDoors { get; set; }
        public DbSet<CounterWeightType> CounterWeightTypes { get; set; }
        public DbSet<BrakeType> BrakeTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<TractionPulleyType> TractionPulleyTypes { get; set; }
        public DbSet<UseType> UseTypes { get; set; }
        public DbSet<PulleyMaterialType> PulleyMaterialTypes { get; set; }
        public DbSet<TractionPulleiesInformation> TractionPulleiesInformations { get; set; }
        public DbSet<CabinAntiShockType> CabinAntiShockTypes { get; set; }
        public DbSet<CabinInformation> CabinInformations { get; set; }
        public DbSet<DoorType> DoorTypes { get; set; }
        public DbSet<InstallationType> InstallationTypes { get; set; }
        public DbSet<ElevatorInformation> ElevatorInformations { get; set; }
        public DbSet<ElevatorType> ElevatorTypes { get; set; }

        public DbSet<EnginRoomInformation> EngineInformations { get; set; }
        public DbSet<FloorDoorsInformation> FloorDoorsInformations { get; set; }
        public DbSet<GovernerInformations> GovernerInformations { get; set; }
        public DbSet<GeneralTechnicalformation> GeneralTechnicalformations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<DoorLockInformation> MechanicalDoorLockInformations { get; set; }
        public DbSet<ObjectDetail> ObjectDetails { get; set; }
        public DbSet<ObjectDetailProperty> ObjectDetailProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RailsInformation> RailsInformations { get; set; }
        public DbSet<SafetyBrakesInformation> SafetyBrakesInformations { get; set; }
        public DbSet<SerialResource> SerialResources { get; set; }
        public DbSet<SteelRopeInformation> SteelRopeInformations { get; set; }
        public DbSet<MainBoardInformation> SteeringControlInformations { get; set; }
        public DbSet<ShoesType> WeightShoesTypes { get; set; }
        public DbSet<InstallatinCompany> InstallatinCompanies { get; set; }
        public DbSet<LatestCertificateType> LatestCertificateTypes { get; set; }
        public DbSet<ChainsCableInformation> ChainsCableInformations { get; set; }
        public DbSet<BedMaterialType> BedMaterialTypes { get; set; }
        public DbSet<WallMaterialType> WallMaterialTypes { get; set; }
        public DbSet<VMFastRegistration> VMFastRegistrations { get; set; }
        public DbSet<InspectionTariff> InspectionTariffs { get; set; }
        public DbSet<ElevatorInspection> ElevatorInspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VMFastRegistration>()
                        .ToView(nameof(VMFastRegistration))
                        .HasKey(t => t.Id);

            modelBuilder.Entity<SteelRopeInformation>()
                        .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                        .WithOne(s=>s.SteelRopeInformation)
                        .HasForeignKey<SteelRopeInformation>(s => s.Id);

            modelBuilder.Entity<EnginRoomInformation>()
                    .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                    .WithOne(s => s.EngineInformation)
                    .HasForeignKey<EnginRoomInformation>(s => s.Id);

            modelBuilder.Entity<CounterWightAntiShocksInformations>()
                    .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                    .WithOne(s => s.CounterWightAntiShocksInformations)
                    .HasForeignKey<CounterWightAntiShocksInformations>(s => s.Id);

            modelBuilder.Entity<CabinAntiShocksInformations>()
                .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                .WithOne(s => s.CabinAntiShocksInformations)
                .HasForeignKey<CabinAntiShocksInformations>(s => s.Id);

            modelBuilder.Entity<GovernerInformations>()
                   .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                   .WithOne(s => s.GovernerInformations)
                   .HasForeignKey<GovernerInformations>(s => s.Id);

            modelBuilder.Entity<SafetyBrakesInformation>()
                    .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                    .WithOne(s => s.SafetyBrakesInformation)
                    .HasForeignKey<SafetyBrakesInformation>(s => s.Id);

            modelBuilder.Entity<DoorLockInformation>()
                    .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                    .WithOne(s => s.MechanicalDoorLockInformation)
                    .HasForeignKey<DoorLockInformation>(s => s.Id);

            modelBuilder.Entity<CounterWeightInformation>()
                    .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                    .WithOne(s => s.BalanceWeightInformation)
                    .HasForeignKey<CounterWeightInformation>(s => s.Id);

            modelBuilder.Entity<MainBoardInformation>()
                   .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                   .WithOne(s => s.SteeringControlInformation)
                   .HasForeignKey<MainBoardInformation>(s => s.Id);

            modelBuilder.Entity<CabinInformation>()
                   .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                   .WithOne(s => s.CabinInformation)
                   .HasForeignKey<CabinInformation>(s => s.Id);

            modelBuilder.Entity<GeneralTechnicalformation>()
                   .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
                   .WithOne(s => s.GeneralTechnicalformation)
                   .HasForeignKey<GeneralTechnicalformation>(s => s.Id);

            modelBuilder.Entity<ChainsCableInformation>()
               .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
               .WithOne(s => s.WroupsInformation)
               .HasForeignKey<ChainsCableInformation>(s => s.Id);

            modelBuilder.Entity<TractionPulleiesInformation>()
               .HasOne<ElevatorInformation>(s => s.ElevatorInformation)
               .WithOne(s => s.TractionPulleiesInformation)
               .HasForeignKey<TractionPulleiesInformation>(s => s.Id);

            modelBuilder.Entity<EnginRoomInformation>()
                        .HasOne<ObjectDetail>(x => x.GeerType)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MainBoardInformation>()
                       .HasOne<ObjectDetail>(x => x.TravelingCableType)
                       .WithMany()
                       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GeneralTechnicalformation>()
                       .HasOne<LocationType>(x => x.MachineLocation)
                       .WithMany()
                       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GeneralTechnicalformation>()
                       .HasOne<LocationType>(x => x.GovernerLocation)
                       .WithMany()
                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
