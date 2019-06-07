using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Private.CorLib;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;


namespace PFSoftware.Business
{
    //
    // Resumen:
    //     A DbContext instance represents a combination of the Unit Of Work and Repository
    //     patterns such that it can be used to query from a database and group together
    //     changes that will then be written back to the store as a unit. DbContext is conceptually
    //     similar to ObjectContext.
    //
    // Comentarios:
    //     DbContext is usually used with a derived type that contains System.Data.Entity.DbSet`1
    //     properties for the root entities of the model. These sets are automatically initialized
    //     when the instance of the derived class is created. This behavior can be modified
    //     by applying the System.Data.Entity.Infrastructure.SuppressDbSetInitializationAttribute
    //     attribute to either the entire derived context class, or to individual properties
    //     on the class. The Entity Data Model backing the context can be specified in several
    //     ways. When using the Code First approach, the System.Data.Entity.DbSet`1 properties
    //     on the derived context are used to build a model by convention. The protected
    //     OnModelCreating method can be overridden to tweak this model. More control over
    //     the model used for the Model First approach can be obtained by creating a System.Data.Entity.Infrastructure.DbCompiledModel
    //     explicitly from a System.Data.Entity.DbModelBuilder and passing this model to
    //     one of the DbContext constructors. When using the Database First or Model First
    //     approach the Entity Data Model can be created using the Entity Designer (or manually
    //     through creation of an EDMX file) and then this model can be specified using
    //     entity connection string or an System.Data.Entity.Core.EntityClient.EntityConnection
    //     object. The connection to the database (including the name of the database) can
    //     be specified in several ways. If the parameterless DbContext constructor is called
    //     from a derived context, then the name of the derived context is used to find
    //     a connection string in the app.config or web.config file. If no connection string
    //     is found, then the name is passed to the DefaultConnectionFactory registered
    //     on the System.Data.Entity.Database class. The connection factory then uses the
    //     context name as the database name in a default connection string. (This default
    //     connection string points to .\SQLEXPRESS on the local machine unless a different
    //     DefaultConnectionFactory is registered.) Instead of using the derived context
    //     name, the connection/database name can also be specified explicitly by passing
    //     the name to one of the DbContext constructors that takes a string. The name can
    //     also be passed in the form "name=myname", in which case the name must be found
    //     in the config file or an exception will be thrown. Note that the connection found
    //     in the app.config or web.config file can be a normal database connection string
    //     (not a special Entity Framework connection string) in which case the DbContext
    //     will use Code First. However, if the connection found in the config file is a
    //     special Entity Framework connection string, then the DbContext will use Database/Model
    //     First and the model specified in the connection string will be used. An existing
    //     or explicitly created DbConnection can also be used instead of the database/connection
    //     name. A System.Data.Entity.DbModelBuilderVersionAttribute can be applied to a
    //     class derived from DbContext to set the version of conventions used by the context
    //     when it creates a model. If no attribute is applied then the latest version of
    //     conventions will be used.
    public class DbContext : IDisposable, IObjectContextAdapter
    {
        //
        // Resumen:
        //     Constructs a new context instance using the given string as the name or connection
        //     string for the database to which a connection will be made. See the class remarks
        //     for how this is used to create a connection.
        //
        // Parámetros:
        //   nameOrConnectionString:
        //     Either the database name or a connection string.
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public DbContext(string nameOrConnectionString);
        //
        // Resumen:
        //     Constructs a new context instance using the given string as the name or connection
        //     string for the database to which a connection will be made, and initializes it
        //     from the given model. See the class remarks for how this is used to create a
        //     connection.
        //
        // Parámetros:
        //   nameOrConnectionString:
        //     Either the database name or a connection string.
        //
        //   model:
        //     The model that will back this context.
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public DbContext(string nameOrConnectionString, DbCompiledModel model);
        //
        // Resumen:
        //     Constructs a new context instance using the existing connection to connect to
        //     a database. The connection will not be disposed when the context is disposed
        //     if contextOwnsConnection is false.
        //
        // Parámetros:
        //   existingConnection:
        //     An existing connection to use for the new context.
        //
        //   contextOwnsConnection:
        //     If set to true the connection is disposed when the context is disposed, otherwise
        //     the caller must dispose the connection.
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public DbContext(DbConnection existingConnection, bool contextOwnsConnection);
        //
        // Resumen:
        //     Constructs a new context instance around an existing ObjectContext.
        //
        // Parámetros:
        //   objectContext:
        //     An existing ObjectContext to wrap with the new context.
        //
        //   dbContextOwnsObjectContext:
        //     If set to true the ObjectContext is disposed when the DbContext is disposed,
        //     otherwise the caller must dispose the connection.
        public DbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext);
        //
        // Resumen:
        //     Constructs a new context instance using the existing connection to connect to
        //     a database, and initializes it from the given model. The connection will not
        //     be disposed when the context is disposed if contextOwnsConnection is false.
        //
        // Parámetros:
        //   existingConnection:
        //     An existing connection to use for the new context.
        //
        //   model:
        //     The model that will back this context.
        //
        //   contextOwnsConnection:
        //     If set to true the connection is disposed when the context is disposed, otherwise
        //     the caller must dispose the connection.
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public DbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection);
        //
        // Resumen:
        //     Constructs a new context instance using conventions to create the name of the
        //     database to which a connection will be made. The by-convention name is the full
        //     name (namespace + class name) of the derived context class. See the class remarks
        //     for how this is used to create a connection.
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected DbContext();
        //
        // Resumen:
        //     Constructs a new context instance using conventions to create the name of the
        //     database to which a connection will be made, and initializes it from the given
        //     model. The by-convention name is the full name (namespace + class name) of the
        //     derived context class. See the class remarks for how this is used to create a
        //     connection.
        //
        // Parámetros:
        //   model:
        //     The model that will back this context.
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected DbContext(DbCompiledModel model);

        //
        // Resumen:
        //     Creates a Database instance for this context that allows for creation/deletion/existence
        //     checks for the underlying database.
        public Database Database { get; }
        //
        // Resumen:
        //     Provides access to features of the context that deal with change tracking of
        //     entities.
        public DbChangeTracker ChangeTracker { get; }
        //
        // Resumen:
        //     Provides access to configuration options for the context.
        public DbContextConfiguration Configuration { get; }

        //
        // Resumen:
        //     Calls the protected Dispose method.
        public void Dispose();
        //
        // Resumen:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry object for the given entity
        //     providing access to information about the entity and the ability to perform actions
        //     on the entity.
        //
        // Parámetros:
        //   entity:
        //     The entity.
        //
        // Devuelve:
        //     An entry for the entity.
        public DbEntityEntry Entry(object entity);
        //
        // Resumen:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry`1 object for the given
        //     entity providing access to information about the entity and the ability to perform
        //     actions on the entity.
        //
        // Parámetros:
        //   entity:
        //     The entity.
        //
        // Parámetros de tipo:
        //   TEntity:
        //     The type of the entity.
        //
        // Devuelve:
        //     An entry for the entity.
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Type GetType();
        //
        // Resumen:
        //     Validates tracked entities and returns a Collection of System.Data.Entity.Validation.DbEntityValidationResult
        //     containing validation results.
        //
        // Devuelve:
        //     Collection of validation results for invalid entities. The collection is never
        //     null and must not contain null values or results for valid entities.
        //
        // Comentarios:
        //     1. This method calls DetectChanges() to determine states of the tracked entities
        //     unless DbContextConfiguration.AutoDetectChangesEnabled is set to false. 2. By
        //     default only Added on Modified entities are validated. The user is able to change
        //     this behavior by overriding ShouldValidateEntity method.
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IEnumerable<DbEntityValidationResult> GetValidationErrors();
        //
        // Resumen:
        //     Saves all changes made in this context to the underlying database.
        //
        // Devuelve:
        //     The number of state entries written to the underlying database. This can include
        //     state entries for entities and/or relationships. Relationship state entries are
        //     created for many-to-many relationships and relationships where there is no foreign
        //     key property included in the entity class (often referred to as independent associations).
        //
        // Excepciones:
        //   T:System.Data.Entity.Infrastructure.DbUpdateException:
        //     An error occurred sending updates to the database.
        //
        //   T:System.Data.Entity.Infrastructure.DbUpdateConcurrencyException:
        //     A database command did not affect the expected number of rows. This usually indicates
        //     an optimistic concurrency violation; that is, a row has been changed in the database
        //     since it was queried.
        //
        //   T:System.Data.Entity.Validation.DbEntityValidationException:
        //     The save was aborted because validation of entity property values failed.
        //
        //   T:System.NotSupportedException:
        //     An attempt was made to use unsupported behavior such as executing multiple asynchronous
        //     commands concurrently on the same context instance.
        //
        //   T:System.ObjectDisposedException:
        //     The context or connection have been disposed.
        //
        //   T:System.InvalidOperationException:
        //     Some error occurred attempting to process entities in the context either before
        //     or after sending commands to the database.
        public virtual int SaveChanges();
        //
        // Resumen:
        //     Asynchronously saves all changes made in this context to the underlying database.
        //
        // Parámetros:
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Devuelve:
        //     A task that represents the asynchronous save operation. The task result contains
        //     the number of state entries written to the underlying database. This can include
        //     state entries for entities and/or relationships. Relationship state entries are
        //     created for many-to-many relationships and relationships where there is no foreign
        //     key property included in the entity class (often referred to as independent associations).
        //
        // Excepciones:
        //   T:System.InvalidOperationException:
        //     Thrown if the context has been disposed.
        //
        // Comentarios:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "cancellationToken")]
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //
        // Resumen:
        //     Asynchronously saves all changes made in this context to the underlying database.
        //
        // Devuelve:
        //     A task that represents the asynchronous save operation. The task result contains
        //     the number of state entries written to the underlying database. This can include
        //     state entries for entities and/or relationships. Relationship state entries are
        //     created for many-to-many relationships and relationships where there is no foreign
        //     key property included in the entity class (often referred to as independent associations).
        //
        // Excepciones:
        //   T:System.Data.Entity.Infrastructure.DbUpdateException:
        //     An error occurred sending updates to the database.
        //
        //   T:System.Data.Entity.Infrastructure.DbUpdateConcurrencyException:
        //     A database command did not affect the expected number of rows. This usually indicates
        //     an optimistic concurrency violation; that is, a row has been changed in the database
        //     since it was queried.
        //
        //   T:System.Data.Entity.Validation.DbEntityValidationException:
        //     The save was aborted because validation of entity property values failed.
        //
        //   T:System.NotSupportedException:
        //     An attempt was made to use unsupported behavior such as executing multiple asynchronous
        //     commands concurrently on the same context instance.
        //
        //   T:System.ObjectDisposedException:
        //     The context or connection have been disposed.
        //
        //   T:System.InvalidOperationException:
        //     Some error occurred attempting to process entities in the context either before
        //     or after sending commands to the database.
        //
        // Comentarios:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public virtual Task<int> SaveChangesAsync();
        //
        // Resumen:
        //     Returns a non-generic System.Data.Entity.DbSet instance for access to entities
        //     of the given type in the context and the underlying store.
        //
        // Parámetros:
        //   entityType:
        //     The type of entity for which a set should be returned.
        //
        // Devuelve:
        //     A set for the given entity type.
        //
        // Comentarios:
        //     Note that Entity Framework requires that this method return the same instance
        //     each time that it is called for a given context instance and entity type. Also,
        //     the generic System.Data.Entity.DbSet`1 returned by the System.Data.Entity.DbContext.Set(System.Type)
        //     method must wrap the same underlying query and set of entities. These invariants
        //     must be maintained if this method is overridden for anything other than creating
        //     test doubles for unit testing. See the System.Data.Entity.DbSet class for more
        //     details.
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Set")]
        public virtual DbSet Set(Type entityType);
        //
        // Resumen:
        //     Returns a System.Data.Entity.DbSet`1 instance for access to entities of the given
        //     type in the context and the underlying store.
        //
        // Parámetros de tipo:
        //   TEntity:
        //     The type entity for which a set should be returned.
        //
        // Devuelve:
        //     A set for the given entity type.
        //
        // Comentarios:
        //     Note that Entity Framework requires that this method return the same instance
        //     each time that it is called for a given context instance and entity type. Also,
        //     the non-generic System.Data.Entity.DbSet returned by the System.Data.Entity.DbContext.Set(System.Type)
        //     method must wrap the same underlying query and set of entities. These invariants
        //     must be maintained if this method is overridden for anything other than creating
        //     test doubles for unit testing. See the System.Data.Entity.DbSet`1 class for more
        //     details.
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Set")]
        public virtual DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString();
        //
        // Resumen:
        //     Disposes the context. The underlying System.Data.Entity.Core.Objects.ObjectContext
        //     is also disposed if it was created is by this context or ownership was passed
        //     to this context when this context was created. The connection to the database
        //     (System.Data.Common.DbConnection object) is also disposed if it was created is
        //     by this context or ownership was passed to this context when this context was
        //     created.
        //
        // Parámetros:
        //   disposing:
        //     true to release both managed and unmanaged resources; false to release only unmanaged
        //     resources.
        protected virtual void Dispose(bool disposing);
        //
        // Resumen:
        //     This method is called when the model for a derived context has been initialized,
        //     but before the model has been locked down and used to initialize the context.
        //     The default implementation of this method does nothing, but it can be overridden
        //     in a derived class such that the model can be further configured before it is
        //     locked down.
        //
        // Parámetros:
        //   modelBuilder:
        //     The builder that defines the model for the context being created.
        //
        // Comentarios:
        //     Typically, this method is called only once when the first instance of a derived
        //     context is created. The model for that context is then cached and is for all
        //     further instances of the context in the app domain. This caching can be disabled
        //     by setting the ModelCaching property on the given ModelBuidler, but note that
        //     this can seriously degrade performance. More control over caching is provided
        //     through use of the DbModelBuilder and DbContextFactory classes directly.
        protected virtual void OnModelCreating(DbModelBuilder modelBuilder);
        //
        // Resumen:
        //     Extension point allowing the user to override the default behavior of validating
        //     only added and modified entities.
        //
        // Parámetros:
        //   entityEntry:
        //     DbEntityEntry instance that is supposed to be validated.
        //
        // Devuelve:
        //     true to proceed with validation; false otherwise.
        protected virtual bool ShouldValidateEntity(DbEntityEntry entityEntry);
        //
        // Resumen:
        //     Extension point allowing the user to customize validation of an entity or filter
        //     out validation results. Called by System.Data.Entity.DbContext.GetValidationErrors.
        //
        // Parámetros:
        //   entityEntry:
        //     DbEntityEntry instance to be validated.
        //
        //   items:
        //     User-defined dictionary containing additional info for custom validation. It
        //     will be passed to System.ComponentModel.DataAnnotations.ValidationContext and
        //     will be exposed as System.ComponentModel.DataAnnotations.ValidationContext.Items
        //     . This parameter is optional and can be null.
        //
        // Devuelve:
        //     Entity validation result. Possibly null when overridden.
        protected virtual DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
    }
}
