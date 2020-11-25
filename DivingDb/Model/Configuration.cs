using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivingDb.Model
{
    public class DivingLaborConfiguration: IEntityTypeConfiguration<DivingLabor>
    {
        public void Configure(EntityTypeBuilder<DivingLabor> builder)
        {
            builder.ToTable("DivingLabors");
            builder.HasKey(x => x.DivingLaborId);

            builder.Property(x => x.DivingLaborId).HasColumnName(@"DivingLaborId").HasColumnType("int").IsRequired();
            builder.Property(x => x.EventId).HasColumnName(@"EventId").HasColumnType("int").IsRequired();
            builder.Property(x => x.RegistrationDate).HasColumnName(@"RegistrationDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Comments).HasColumnName(@"Comments").HasColumnType("nvarchar(700)");
            builder.Property(x => x.WaveHeight).HasColumnName(@"WaveHeight").HasColumnType("float").IsRequired();
            builder.Property(x => x.WindDirection).HasColumnName(@"WindDirection").HasColumnType("float").IsRequired();
            builder.Property(x => x.Flowing).HasColumnName(@"Flowing").HasColumnType("float").IsRequired();
            builder.Property(x => x.TypeOfPermisionId).HasColumnName(@"TypeOfPermisionId").HasColumnType("int").IsRequired();
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("varchar(450)").IsRequired();
            builder.Property(x => x.DivingLaborStatusId).HasColumnName(@"DivingLaborStatusId").HasColumnType("int").IsRequired();
            builder.Property(x => x.CommentReview).HasColumnName(@"CommentReview").HasColumnType("nvarchar(700)");
            
            builder.HasMany(a => a.DivingActivities).WithOne(b => b.DivingLabor).HasForeignKey(c => c.DivingLaborId);
            builder.HasMany(a => a.Equipments).WithOne(b => b.DivingLabor).HasForeignKey(c => c.DivingLaborId);
            

        }   
    }
    public class DivingActivityConfiguration: IEntityTypeConfiguration<DivingActivity>
    {
        public void Configure(EntityTypeBuilder<DivingActivity> builder)
        {
            builder.ToTable("DivingActivities");
            builder.HasKey(x => x.DivingActivityId);
            builder.Property(x => x.DivingActivityId).HasColumnName(@"DivingActivityId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingLaborId).HasColumnName(@"DivingLaborId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DiverId).HasColumnName(@"DiverId").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsBackup).HasColumnName(@"IsBackup").HasColumnType("bit").IsRequired();
            builder.Property(x => x.MaxDeep).HasColumnName(@"MaxDeep").HasColumnType("float").IsRequired();
            builder.Property(x => x.DeepGroupId).HasColumnName(@"DeepGroupId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DeepTableId).HasColumnName(@"DeepTableId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingTimePeriodId).HasColumnName(@"DivingTimePeriodId").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsColdWater).HasColumnName(@"IsColdWater").HasColumnType("bit").IsRequired();
            builder.Property(x => x.StartTime).HasColumnName(@"StartTime").HasColumnType("varchar(5)").IsRequired();
            builder.Property(x => x.EndTime).HasColumnName(@"EndTime").HasColumnType("varchar(5)").IsRequired();
            builder.Property(x => x.TotalTime).HasColumnName(@"TotalTime").HasColumnType("float").IsRequired();

            builder.HasMany(a => a.ActivityDetails).WithOne(b => b.DivingActivity).HasForeignKey(c => c.DivingActivityId);
        }
    }
    public class DivingActivityDetailConfiguration: IEntityTypeConfiguration<DivingActivityDetail>
    {
        public void Configure(EntityTypeBuilder<DivingActivityDetail> builder)
        {
            builder.ToTable("DivingActivityDetails");
            builder.HasKey(x => x.DivingActivityDetailId);
            builder.Property(x => x.DivingActivityDetailId).HasColumnName(@"DivingActivityDetailId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingTypeSubJobId).HasColumnName(@"DivingTypeSubJobId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingActivityId).HasColumnName(@"DivingActivityId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ModuleId).HasColumnName(@"ModuleId").HasColumnType("int").IsRequired();
            builder.Property(x => x.UnitId).HasColumnName(@"UnitId").HasColumnType("int").IsRequired();
            builder.Property(x => x.FileId).HasColumnName(@"FileId").HasColumnType("int");
        }
    }
    public class DivingEquipmentConfiguration: IEntityTypeConfiguration<DivingEquipment>
    {
        public void Configure(EntityTypeBuilder<DivingEquipment> builder)
        {
            builder.ToTable("DivingEquipments");
            builder.HasKey(x => x.DivingEquipmentId);
            builder.Property(x => x.DivingEquipmentId).HasColumnName(@"DivingEquipmentId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingEquipmentCategoryId).HasColumnName(@"DivingEquipmentCategoryId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Identifier).HasColumnName(@"Identifier").HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.ExpirationTime).HasColumnName(@"DivingActivExpirationTimeityId").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DivingLaborId).HasColumnName(@"DivingLaborId").HasColumnType("int").IsRequired();
           

            builder.HasMany(a => a.AssignedTo).WithOne(b => b.DivingEquipment).HasForeignKey(c => c.DivingEquipmentId);
        }
    }
    public class DivingTypeJobConfiguration : IEntityTypeConfiguration<DivingTypeJob>
    {
        public void Configure(EntityTypeBuilder<DivingTypeJob> builder)
        {
            builder.ToTable("DivingTypeJobs");
            builder.HasKey(x => x.DivingTypeJobId);
            builder.Property(x => x.DivingTypeJobId).HasColumnName(@"DivingTypeJobId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(50)").IsRequired();

            builder.HasMany(a => a.SubJobs).WithOne(b => b.DivingTypeJob).HasForeignKey(c => c.DivingTypeJobId);
        }

    }
    public class DivingTypeSubJobConfiguration : IEntityTypeConfiguration<DivingTypeSubJob>
    {
        public void Configure(EntityTypeBuilder<DivingTypeSubJob> builder)
        {
            builder.ToTable("DivingTypeSubJobs");
            builder.HasKey(x => x.DivingTypeSubJobId);
            builder.Property(x => x.DivingTypeSubJobId).HasColumnName(@"DivingTypeSubJobId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DivingTypeJobId).HasColumnName(@"DivingTypeJobId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(50)").IsRequired();
        }
    }
    public class DiverConfiguration : IEntityTypeConfiguration<Diver>
    {
        public void Configure(EntityTypeBuilder<Diver> builder)
        {
            builder.ToTable("Divers");
            builder.HasKey(x => x.DiverId);
            builder.Property(x => x.DiverId).HasColumnName(@"DiverId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Identifier).HasColumnName(@"Identifier").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }
    public class DeepTableConfiguration : IEntityTypeConfiguration<DeepTable>
    {
        public void Configure(EntityTypeBuilder<DeepTable> builder)
        {
            builder.ToTable("DeepTables");
            builder.HasKey(x => x.DeepTableId);
            builder.Property(x => x.DeepTableId).HasColumnName(@"DeepTableId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }
    public class DeepGroupConfiguration : IEntityTypeConfiguration<DeepGroup>
    {
        public void Configure(EntityTypeBuilder<DeepGroup> builder)
        {
            builder.ToTable("DeepGroups");
            builder.HasKey(x => x.DeepGroupId);
            builder.Property(x => x.DeepGroupId).HasColumnName(@"DeepGroupId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }
    public class DiveTypePermissionConfiguration : IEntityTypeConfiguration<DiveTypePermission>
    {
        public void Configure(EntityTypeBuilder<DiveTypePermission> builder)
        {
            builder.ToTable("DiveTypePermissions");
            builder.HasKey(x => x.DiveTypePermissionId);
            builder.Property(x => x.DiveTypePermissionId).HasColumnName(@"DiveTypePermissionId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }
    public class DivingTimePeriodConfiguration : IEntityTypeConfiguration<DivingTimePeriod>
    {
        public void Configure(EntityTypeBuilder<DivingTimePeriod> builder)
        {
            builder.ToTable("DivingTimePeriods");
            builder.HasKey(x => x.DivingTimePeriodId);
            builder.Property(x => x.DivingTimePeriodId).HasColumnName(@"DivingTimePeriodId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }
    public class DivingEquipmentCategoryConfiguration : IEntityTypeConfiguration<DivingEquipmentCategory>
    {
        public void Configure(EntityTypeBuilder<DivingEquipmentCategory> builder)
        {
            builder.ToTable("DivingEquipmentCategories");
            builder.HasKey(x => x.DivingEquipmentCategoryId);
            builder.Property(x => x.DivingEquipmentCategoryId).HasColumnName(@"DivingEquipmentCategory").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(100)").IsRequired();
        }
    }




    

}
