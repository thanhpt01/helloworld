using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    public partial class UserAttachment
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(32)]
        public string Code { get; set; }

        [StringLength(150)]
        public string Name { get; set; }
    }

    public class UserAttachmentConfiguration : EntityTypeConfiguration<UserAttachment>
    {
        public UserAttachmentConfiguration()
            : base()
        {
            HasKey(p => p.UserId);
            ToTable("UserAttachment");

            //HasRequired(t => t.User)
            //    .WithOptional(t => t.UserAttachment);
        }
    }
}
