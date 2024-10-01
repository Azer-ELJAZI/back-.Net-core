using System;
using System.ComponentModel.DataAnnotations;

namespace stage1.Models
{
    public class ServiceCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Technician { get; set; }

        [Required]
        public string ServiceCaseNo { get; set; }

        public string ServiceCaseTemplate { get; set; }

        public string ServiceObject { get; set; }

        public string AffectedCompany { get; set; }

        public string ContactPerson { get; set; }

        public string AffectedInstallation { get; set; }

        public string OriginatingServiceOrder { get; set; }

        public string OriginatingJob { get; set; }

        public string Skills { get; set; }

        public string Checklist { get; set; }

        public string Element { get; set; }

        public string Message { get; set; }

        public string Priority { get; set; }

        public string ServiceCaseCategory { get; set; }

        public string ResponsibleUser { get; set; }

        [Required]
        public string Visibility { get; set; }
    }
}
