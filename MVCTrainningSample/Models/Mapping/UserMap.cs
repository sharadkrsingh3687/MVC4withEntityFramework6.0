using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVCTrainningSample.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.Username)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.Password)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        }
    }
}
