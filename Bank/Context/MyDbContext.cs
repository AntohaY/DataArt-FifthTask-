
namespace RevercePOCO
{

    using System.Linq;

    public partial class MyDbContext : System.Data.Entity.DbContext, IMyDbContext
    {
        public System.Data.Entity.IDbSet<Card> Cards { get; set; } // Cards
        public System.Data.Entity.IDbSet<Client> Clients { get; set; } // Clients
        public System.Data.Entity.IDbSet<Operation> Operations { get; set; } // Operations

        static MyDbContext()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext() : base("Name=DataBase") { }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CardConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new OperationConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public MyDbContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public MyDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            DisposePartial(disposing);
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CardConfiguration(schema));
            modelBuilder.Configurations.Add(new ClientConfiguration(schema));
            modelBuilder.Configurations.Add(new OperationConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void DisposePartial(bool disposing);
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
}

