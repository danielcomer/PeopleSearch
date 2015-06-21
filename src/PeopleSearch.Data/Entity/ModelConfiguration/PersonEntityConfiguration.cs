using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Data.Entity.ModelConfiguration
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            HasMany(p => p.Interests)
                .WithMany(i => i.People);

            HasRequired(p => p.HomeAddress)
                .WithMany(s => s.People)
                .HasForeignKey(p => p.HomeAddressId)
                .WillCascadeOnDelete(false);

            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
        }
    }
}
