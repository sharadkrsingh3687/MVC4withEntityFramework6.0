using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVCTrainningSample.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.RoleName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Roles");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Users)
                .WithMany(t => t.Roles)
                .Map(m =>
                    {
                        m.ToTable("UserRoles");
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("UserId");
                    });


        }
    }
}
