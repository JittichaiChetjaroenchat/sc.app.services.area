using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Services.Area.Database.Models
{
    public class Region
    {
        [Key]
        [Column(Constants.Region.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.Region.Column.Code, TypeName = "varchar(16)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.Region.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.Region.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}