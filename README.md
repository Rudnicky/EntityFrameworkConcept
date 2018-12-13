# EntityFrameworkConcept

Prerequisites

- SQL Server 2017 (developer full-featured free edition or express)
- SQL Server Management Studio 

with database first approach:
(using SQL management studio)

- Create Database,
- Create Tables (relations et cetera)

Creating Project

- In solution explorer -> Add -> New Item -> ADO.NET Entity Data Model,
- choose EF Designer from database,
- establish connection with already existing local database,
- include tables of your database,
- this will generate automatically bunch of files as context and entity class for each table
  the most important are: <EDM Name>.Context.tt and <EDM Name>.tt

Important informations

- created class in <EDM Name>.Context.cs derive from DbContext,
- DBContext is an important class in Entity Framework API.
  It's a bridge between your domain or entity classes and the database.
  DbContext is a primary class that is responsible for interacting with 
  the database. It is responsible for the following activites:
  - Querying: Converts LINQ to Entities queries to SQL query and sends them to the database,
  - Change Tracking: Keeps track of changes that occurred on the entities after quering from the database,
  - Persisting Data: Performs the Insert, Update and Delete operations to the Database, based on entity states,
  - Caching: Provides first level caching by default. It stores the entities which have been retrieved 
    during the life time of a context class,
  - Manage Relationship: Manages relationships using CSDL, MSL, SSDL in Db-First or Model-First apporach,
    and using fluent API configurations in Code-First apporach,
  - Object Materialization: Converts raw data from the database into entity objects  
- DbSet class represents an entity set that can be used for create, read, update and delete operaions,
  the context class (derived from DbContext) must include the DbSet type properties for the entities which
  map to database tables and views. 
- Relational Database Pattern TIP: One-to-Many, One-to-One, Many-to-Many,  
- http://www.entityframeworktutorial.net/entityframework6/async-query-and-save.aspx
- https://maciejjedrzejewski.pl/2014/11/10/pytania-z-rozmow-vol-3-net-ef-model-first-db-first-code-first/

Insert Data

 Use the DbSet.Add method to add a new entity to a context (instance of DbContext),
 which will insert a new record in the database when you call SaveChanges() methods.
	      
            using (var context = new TestDatabaseEntities())
            {
                var company = new Company()
                {
                    Name = "Mobica",
                    Industry = "Outsourcing"
                };
                context.Companies.Add(company);
                context.SaveChanges();
            }

 In the above example, context.Students.Add(std) adds a newly created instance of the Student
 entity to a context with Added EntityState. The context.SaveChanges() method build and
 executes the following INSERT statement to the database.

Updating Data

 In the connected scenario, EF API keeps track of all the entities retrieved using a context.
 Therefore, when you edit entity data, EF automatically marks EntityState to Modified, which
 results in an updated statement in the database when you call the SaveChanges() method.

            using (var context = new TestDatabaseEntities())
            {
                var company = context.Companies.First<Company>();
                if (company != null)
                {
                    company.Industry = "ProductOwner";
                    context.SaveChanges();
                }
            }

 In the above example, we retrieve the first student from the database using context.Students.First<student>(). 
 As soon as we modify the FirstName, the context sets its EntityState to Modified because of the modification 
 performed in the scope of the DbContext instance (context). So, when we call the SaveChanges() method, 
 it builds and executes the following Update statement in the database. 

Deleting Data

 Use the DbSet.Remove() method to delete a record in the database table.

            using (var context = new TestDatabaseEntities())
            {
                List<Company> companies = context.Companies.ToList();
                foreach (var company in companies)
                {
                    context.Companies.Remove(company);
                }

                context.SaveChanges();
            }

 In the above example, context.Students.Remove(std) marks the std entity object as Deleted.
 Therefore, EF will build and execute the following DELETE statement in the database. 

LINQ MEthod syntax:

//Querying with LINQ to Entities 
using (var context = new TestDatabaseEntities())
{
    var query = context.Students
                       .where(s => s.Name == "Pawel")
                       .FirstOrDefault<Employee>();
}

LINQ Query syntax:

using (var context = new TestDatabaseEntities())
{
    var query = from st in context.Employees
                where st.Name == "Pawel"
                select st;
   
    var student = query.FirstOrDefault<Employee>();
}

Eager Loading

 Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query,
 so that we don't need to execute a separate query for related entities.
 Eager loading is achieved using the Include() method.

using (var ctx = new TestDatabaseEntities())
{
    var stud1 = ctx.Employees
                   .Include("Standard")
                   .Where(s => s.Name == "Pawel")
                   .FirstOrDefault<Employee>();
}

Lazy Loading

 Lazy loading is delaying the loading of related data, until you specifically request for it.
 It is the opposite of eager loading. For example, the Student entity contains the StudentAddress entity.
 In the lazy loading, the context first loads the Student entity data from the database, then it will load
 the StudentAddress entity when we access the StudentAddress property as shown below.

using (var ctx = new TestDatabaseEntities())
{
    //Loading students only
    IList<Student> studList = ctx.Students.ToList<Student>();

    Student std = studList[0];

    //Loads Student address for particular Student only (seperate SQL query)
    StudentAddress add = std.StudentAddress;
}

Query()

 You can also write LINQ-to-Entities queries to filter the related data before loading.
 The Query() method enables us to write further LINQ queries for the related entities to filter out related data.

using (var context = new TestDatabaseEntities())
{
    var student = context.Employees
                        .Where(s => s.FirstName == "Bill")
                        .FirstOrDefault<Employee>();
    
    context.Entry(student)
           .Collection(s => s.StudentCourses)
           .Query()
               .Where(sc => sc.CourseName == "Maths")
               .FirstOrDefault();
}

 In the above example, .Collection(s => s.StudentCourses).Query()
 allows us to write further queries for the StudentCourses entity. 
