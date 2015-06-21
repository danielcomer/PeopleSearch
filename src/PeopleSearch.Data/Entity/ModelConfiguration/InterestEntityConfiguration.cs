using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Data.Entity.ModelConfiguration
{
    public class InterestEntityConfiguration : EntityTypeConfiguration<Interest>
    {
        public InterestEntityConfiguration()
        {
            Property(i => i.Text)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute {IsUnique = true}));
        }
    }
}
