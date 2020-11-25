using System;
using System.Collections.Generic;
using System.Text;

namespace DivingDb.Model
{

    //Faena
    public class DivingLabor 
    {
        public int DivingLaborId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Comments { get; set; }
        public double WaveHeight { get; set; }
        public double WindDirection { get; set; }

        public double Flowing { get; set; } //Corriente

        public int TypeOfPermisionId { get; set; }

        public DiveTypePermission DiveTypePermission { get; set; }
        public string UserId { get; set; }

        
        public int DivingLaborStatusId { get; set; } //Ok; NoOk;WithNoReview
        public DivingLaborStatus DivingLaborStatus { get; set; }
        public string CommentReview { get; set; }

        public List<DivingActivity> DivingActivities { get; set; }

        public List<DivingEquipment> Equipments { get; set; }

    }

    public class DivingLaborStatus
    {
        public int DivingLaborStatusId { get; set; }
        public string Name { get; set; }
    }

    public class DivingActivity
    {
        public int DivingActivityId { get; set; }

        public DivingLabor DivingLabor { get; set; }
        public int DivingLaborId { get; set; }
        public Diver Diver { get; set; }
        public int DiverId { get; set; }
        public bool IsBackup { get; set; }
        public double MaxDeep { get; set; }

        public int DeepGroupId { get; set; }
        public DeepGroup DeepGroup { get; set; }

        public int DeepTableId { get; set; }
        public DeepTable DeepTable { get; set; }

        public DivingTimePeriod DivingTimePeriod { get; set; }
        public int DivingTimePeriodId { get; set; }

        public bool IsColdWater { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double TotalTime { get; set; }
       
        public List<DivingActivityDetail>  ActivityDetails { get; set; }
    }

    public class DivingActivityDetail
    {
        public int DivingActivityDetailId { get; set; }
        public int DivingTypeSubJobId { get; set; }
        public DivingTypeSubJob DivingTypeSubJob { get; set; }
        public int DivingActivityId { get; set; }
        public DivingActivity DivingActivity { get; set; }
        public int ModuleId { get; set; }
        public int UnitId { get; set; }
        public int FileId { get; set; }
    }

    public class DivingEquipment
    {
        public int DivingEquipmentId { get; set; }
        public DivingEquipmentCategory DivingEquipmentCategory { get; set; }
        public int DivingEquipmentCategoryId { get; set; }
        public string Identifier { get; set; }
        public DateTime ExpirationTime { get; set; }

        public DivingLabor DivingLabor { get; set; }
        public int DivingLaborId { get; set; }
        public List<DivingEquipmentAssignment> AssignedTo { get; set; }
    }

    public class DivingTypeJob
    {
        public int DivingTypeJobId { get; set; }
        public string Name { get; set; }

        public List<DivingTypeSubJob> SubJobs { get; set; }
    }
    public class DivingTypeSubJob
    {
        public int DivingTypeSubJobId { get; set; }
        public string Name { get; set; }

        public DivingTypeJob DivingTypeJob { get; set; }
        public int  DivingTypeJobId { get; set; }
    }

    public class Diver
    {
        public int DiverId { get; set; }
        public string Name { get; set; }

        public string Identifier { get; set; }
    }

    public class DeepTable
    {
     
        public int DeepTableId { get; set; }
        public string Name { get; set; }
    }

    public class DeepGroup
    {
        
        public int DeepGroupId { get; set; }
        public string Name { get; set; }
    }

    public class DiveTypePermission
    {
        public int DiveTypePermissionId { get; set; }
        public string Name { get; set; }
    }

    public class DivingTimePeriod
    {
        public int DivingTimePeriodId { get; set; }
        public string Name { get; set; }
    }

    


    public class DivingEquipmentAssignment
    {
        public int DivingEquipmentAssignmentId { get; set; }

        public int DiverId { get; set; }
        public Diver Diver { get; set; }
        public DivingEquipment DivingEquipment { get; set; }
        public int DivingEquipmentId { get; set; }


    }

    public class DivingEquipmentCategory
    {
        public int DivingEquipmentCategoryId { get; set; }
        public string Name { get; set; }
    }



}
