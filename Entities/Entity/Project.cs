using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Project:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? ProjectTitle { get; set; }
        [Required]
        public DateTime? BidDate { get; set; }
        public double BidAmount { get; set; }
        [Required]
        public int NumOfDWGs { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        public bool? CompleteQTO { get; set; }
        public bool? ScopeQTO { get; set; }
        public bool? CompleteEstimate { get; set; }
        public bool? ScopeEstimate { get; set; }
        public bool? QTOEstimatorId { get; set; }
        public string? Remarks { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? TargetDateAndTime { get; set; }
        public int DaysRemaining { get; set; }
        public bool Pricing { get; set; }
        public int QTOProgressPercentage { get; set; }
        public bool QCStatus { get; set; }
        public string? CostEstimatorId { get; set; }
        public string? QTOUpload { get; set; }
        public double QTOPrice { get; set; }
        public double Bonus { get; set; }
        public bool PricingStatus { get; set; }
        public DateTime? UploadDate { get; set; }
        public int TotalBids { get; set; }
        public int BidPosition { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasedByCompanyId { get; set; }
        //public string? ProjectType { get; set; }
    }
}
