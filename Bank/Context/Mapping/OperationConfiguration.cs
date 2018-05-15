

namespace RevercePOCO
{


    public partial class OperationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Operation>
    {
        public OperationConfiguration()
            : this("dbo")
        {
        }

        public OperationConfiguration(string schema)
        {
            ToTable("Operations", schema);
            HasKey(x => x.OperationId);

            Property(x => x.OperationId).HasColumnName(@"OperationID").HasColumnType("int").IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OutId).HasColumnName(@"OutID").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(x => x.InId).HasColumnName(@"InId").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(x => x.Amount).HasColumnName(@"Amount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.OperationTime).HasColumnName(@"OperationTime").HasColumnType("datetime2").IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed);


            HasRequired(a => a.In).WithMany(b => b.Operations_In).HasForeignKey(c => c.InId).WillCascadeOnDelete(false); 
            HasRequired(a => a.Out).WithMany(b => b.Operations_Out).HasForeignKey(c => c.OutId).WillCascadeOnDelete(false);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

