

namespace RevercePOCO
{

    
public partial class ClientConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Client>
{
    public ClientConfiguration(string schema)
    {
        ToTable("Clients", schema);
        HasKey(x => x.ClientId);

        Property(x => x.ClientId).HasColumnName(@"ClientID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        Property(x => x.Birthday).HasColumnName(@"Birthday").HasColumnType("date").IsRequired();
        Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(20);
        InitializePartial();
    }

        public ClientConfiguration()
            : this("dbo")
        {
        }

        partial void InitializePartial();
    }

}

